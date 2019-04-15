using SharpMock.Library;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SharpMock
{
    /*
    public class MockTest : IMock<ITest>
    {
        public Dictionary<MethodInfo, IEngine> Engines { get; }

        public ITest I { get; }
        
        private class MockedInterface : ITest
        {
            private IMock<ITest> Mock { get; }

            public MockedInterface(IMock<ITest> mock)
            {
                Mock = mock;
            }

            public void OneArgA(int i)
            {
                MethodInfo info = (MethodInfo)MethodBase.GetCurrentMethod();
                ((IActionEngine<int>)Mock.Engines[info]).Execute(i);
            }

            public string Call(string s, int i)
            {
                MethodInfo info = (MethodInfo)MethodBase.GetCurrentMethod();
                return ((IFuncEngine<string, int, string>)Mock.Engines[info]).Execute(s, i);
            }

            public string ZeroArgs()
            {
                MethodInfo info = (MethodInfo)MethodBase.GetCurrentMethod();
                return ((IFuncEngine<string>)Mock.Engines[info]).Execute();
            }

            public string OneArg(int i)
            {
                MethodInfo info = (MethodInfo)MethodBase.GetCurrentMethod();
                return ((IFuncEngine<int, string>)Mock.Engines[info]).Execute(i);
            }
        }

        public MockTest()
        {
            Engines = new Dictionary<MethodInfo, IEngine>();
            I = new MockedInterface(this);

            MethodInfo methodInfo;
            // Call
            methodInfo = new Action<int>(I.OneArgA).Method;
            Engines[methodInfo] = new ActionEngine<int>(methodInfo.Name);

            methodInfo = new Func<string, int, string>(I.Call).Method;
            Engines[methodInfo] = new FuncEngine<string, int, string>(methodInfo.Name);

            methodInfo = new Func<string>(I.ZeroArgs).Method;
            Engines[methodInfo] = new FuncEngine<string>(methodInfo.Name);

            methodInfo = new Func<int, string>(I.OneArg).Method;
            Engines[methodInfo] = new FuncEngine<int, string>(methodInfo.Name);
        }
    }
    */
}
