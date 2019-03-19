using SharpMock.Library.Setup;
using SharpMock.Library.Setup.Action;
using SharpMock.Library.Setup.Matchers;
using System;
using System.Text;

namespace SharpMock.Library
{
    public class ActionEngineBase : AbstractEngine
    {
        public ActionEngineBase(string methodName)
            : base(methodName)
        {
        }

        public void Execute(Func<IMatcher, StringBuilder, bool> match, Action<IAction> action)
        {
            var index = FindMatcher(match);
            Act(_activeSetups[index], action);
            DepleteIf(index);
        }
    }

    public class ActionEngine : ActionEngineBase, IActionEngine
    {
        public ActionEngine(string methodName) : base(methodName) { }

        public void Execute()
        {
            Execute((m, o) => ((MultiArgMatcher) m).Match(o), x => ((MultiArgAction) x).Execute());
        }

        public IActionSetup Setup()
        {
            var setup = new ActionSetup();
            _activeSetups.Add(setup);

            return setup;
        }
    }

    public class ActionEngine<T> : ActionEngineBase, IActionEngine<T>
    {
        public ActionEngine(string methodName) : base(methodName) { }

        public void Execute(T arg)
        {
            Execute((m, o) => ((MultiArgMatcher<T>)m).Match(arg, o), x => ((MultiArgAction<T>) x).Execute(arg));
        }

        public IActionSetup<T> Setup()
        {
            var setup = new ActionSetup<T>();
            _activeSetups.Add(setup);

            return setup;
        }
    }

    public class ActionEngine<T1, T2> : ActionEngineBase, IActionEngine<T1, T2>
    {
        public ActionEngine(string methodName) : base(methodName) { }

        public void Execute(T1 arg1, T2 arg2)
        {
            Execute((m, o) => ((MultiArgMatcher<T1, T2>)m).Match(arg1, arg2, o), x => ((MultiArgAction<T1, T2>) x).Execute(arg1, arg2));
        }

        public IActionSetup<T1, T2> Setup()
        {
            var setup = new ActionSetup<T1, T2>();
            _activeSetups.Add(setup);

            return setup;
        }
    }
}
