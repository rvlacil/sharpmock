using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SharpMock.Library
{
    public static class MockFactory
    {
        private static ConcurrentDictionary<Type, object> _factories = new ConcurrentDictionary<Type, object>();

        public static IMock<T> Create<T>() where T : class
        {
            var factory = _factories.GetOrAdd(typeof(T), (k) => CreateFactory<T>());
            return ((Func<IMock<T>>)factory)();
        }

        private static Func<IMock<T>> CreateFactory<T>()
        {
            var mockTypeName = "Mock" + Guid.NewGuid().ToString("n");
            var code = GetMockCode<T>(mockTypeName);

            var compilation = CSharpCompilation.Create(Path.GetRandomFileName()).
                WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)).
                AddReferences(GetReferences<T>()).
                AddSyntaxTrees(code);

            using (var ms = new MemoryStream())
            {
                var result = compilation.Emit(ms);
                if (!result.Success)
                {
                    ThrowWithFailures(result);
                }

                ms.Seek(0, SeekOrigin.Begin);
                var assembly = Assembly.Load(ms.ToArray());
                var type = assembly.GetType("SharpMock.Library.GeneratedMocks." + mockTypeName);

                return Expression.Lambda<Func<IMock<T>>>(Expression.New(type)).Compile();
            }
        }

        private static MetadataReference[] GetReferences<T>()
        {
            var assemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            return new MetadataReference[] {
                    MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Collections.dll")),
                    MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Runtime.dll")),
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(IMock<>).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(T).Assembly.Location)
                };
        }

        private static void ThrowWithFailures(EmitResult result)
        {
            var failures = result.Diagnostics.Where(diagnostic =>
                   diagnostic.IsWarningAsError ||
                   diagnostic.Severity == DiagnosticSeverity.Error);

            var stream = new StringBuilder();
            foreach (var diagnostic in failures)
            {
                stream.Append(diagnostic.Id).Append(":").AppendLine(diagnostic.GetMessage());
            }
            throw new ArgumentException(stream.ToString());
        }

        private static SyntaxTree GetMockCode<T>(string mockTypeName)
        {
            var mockedTypeName = typeof(T).FullName;

            var code =
$@"using System;
using SharpMock.Library;
using SharpMock.Library.Engine;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SharpMock.Library.GeneratedMocks
{{
    public class {mockTypeName}: IMock<{mockedTypeName}>
    {{
        public Dictionary<MethodInfo, IEngine> Engines {{ get; }}

        public {mockedTypeName} I {{ get; }}
        
        private class MockedInterface : {mockedTypeName}
        {{
            private IMock<{mockedTypeName}> Mock {{ get; }}

            public MockedInterface(IMock<{mockedTypeName}> mock)
            {{
                Mock = mock;
            }}

            {ImplementEngineHooks<T>()}
        }}

        public {mockTypeName}()
        {{
            Engines = new Dictionary<MethodInfo, IEngine>();
            I = new MockedInterface(this);

            MethodInfo methodInfo;

            {CreateEngines<T>()}
        }}

        public void Dispose()
        {{
            this.Verify();
        }}
    }}
}}";
            return CSharpSyntaxTree.ParseText(code);
        }


        private static string CreateEngines<T>()
        {
            return ForEachMethod<T>(CreateSingleEngine);
        }

        private static string CreateSingleEngine(MethodInfo info)
        {
            var returnType = info.ReturnType;
            var isFunction = returnType != typeof(void);
            var argsStr = GetGenericArgs(isFunction, info);

            var delegateTypeStr = (isFunction ? "Func" : "Action") + argsStr;
            var engineTypeStr = (isFunction ? "FuncEngine" : "ActionEngine") + argsStr;

            return $"methodInfo = new {delegateTypeStr}(I.{info.Name}).Method;" + Environment.NewLine +
                   $"Engines[methodInfo] = new {engineTypeStr}(methodInfo.Name);";
        }

        private static string ImplementEngineHooks<T>()
        {
            return ForEachMethod<T>(ImplementSingleEngineHook);
        }

        private static string ForEachMethod<T>(Func<MethodInfo, string> call)
        {
            var builder = new StringBuilder();

            foreach (var info in typeof(T).GetMethods())
            {
                builder.AppendLine(call(info));
            }

            return builder.ToString();
        }

        private static string ImplementSingleEngineHook(MethodInfo info)
        {
            var returnType = info.ReturnType;
            var isFunction = returnType != typeof(void);
            var engineTypeStr = (isFunction ? "IFuncEngine" : "IActionEngine") + GetGenericArgs(isFunction, info);
            var returnStatement = isFunction ? "return " : "";
            var returnTypeStr = isFunction ? returnType.FullName : "void";
            var argTypesNamesStr = string.Join(", ", info.GetParameters().Select(i => i.ParameterType.FullName + " " + i.Name));
            var argNamesStr = string.Join(", ", info.GetParameters().Select(i => i.Name));

            return
                $@"public {returnTypeStr} {info.Name}({argTypesNamesStr})
                {{
                    var info = (MethodInfo)MethodBase.GetCurrentMethod();
                    {returnStatement}(({engineTypeStr})Mock.Engines[info]).Execute({argNamesStr});
                }}";
        }

        private static string GetGenericArgs(bool isFunction, MethodInfo info)
        {
            var argsStr = string.Join(", ", info.GetParameters().Select(i => i.ParameterType.FullName));
            if (isFunction)
            {
                argsStr = argsStr + (string.IsNullOrEmpty(argsStr) ? "" : ", ") + info.ReturnType.FullName;
            }
            return "<" + argsStr + ">";
        }
    }
}
