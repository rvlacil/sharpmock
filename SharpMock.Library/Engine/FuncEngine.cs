using SharpMock.Library.Action;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;

namespace SharpMock.Library.Engine
{
    public class FuncEngine<Ret> : FuncEngineBase<Ret>, IFuncEngine<Ret>
    {
        public FuncEngine(string methodName) : base(methodName) { }

        public Ret Execute()
        {
            return Execute((m, o) => ((MultiArgMatcher)m).Match(o), x => ((MultiArgReturn<Ret>)x).Respond());
        }

        public IFuncSetup<Ret> Setup()
        {
            var setup = new FuncSetup<Ret>();
            _activeSetups.Add(setup);

            return setup;
        }
    }

    public class FuncEngine<T, Ret> : FuncEngineBase<Ret>, IFuncEngine<T, Ret>
    {
        public FuncEngine(string methodName) : base(methodName) { }

        public Ret Execute(T arg)
        {
            return Execute((m, o) => ((MultiArgMatcher<T>)m).Match(arg, o), x => ((MultiArgReturn<T, Ret>)x).Respond(arg));
        }

        public IFuncSetup<T, Ret> Setup()
        {
            var setup = new FuncSetup<T, Ret>();
            _activeSetups.Add(setup);

            return setup;
        }
    }

    public class FuncEngine<T1, T2, Ret> : FuncEngineBase<Ret>, IFuncEngine<T1, T2, Ret>
    {
        public FuncEngine(string methodName) : base(methodName) { }

        public Ret Execute(T1 arg1, T2 arg2)
        {
            return Execute((m, o) => ((MultiArgMatcher<T1, T2>)m).Match(arg1, arg2, o), x => ((MultiArgReturn<T1, T2, Ret>)x).Respond(arg1, arg2));
        }

        public IFuncSetup<T1, T2, Ret> Setup()
        {
            var setup = new FuncSetup<T1, T2, Ret>();
            _activeSetups.Add(setup);

            return setup;
        }
    }
}
