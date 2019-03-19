using SharpMock.Library.Setup.Matchers;
using SharpMock.Library.Setup.Cardinality;
using SharpMock.Library.Setup.Action;
using System;
using System.Threading.Tasks;

namespace SharpMock.Library.Setup
{
    public class ActionSetup : SetupBase<IActionSetup>, IActionSetup
    {
        public ActionSetup()
        {
            Matcher = new MultiArgMatcher();
            _action = new MultiArgAction(() => { });
        }

        public IActionSetup Action(System.Action action)
        {
            _action = new MultiArgAction(action);
            return this;
        }

        public IActionSetup Match()
        {
            return this;
        }
    }

    public class ActionSetup<T> : SetupBase<IActionSetup<T>>, IActionSetup<T>
    {
        public ActionSetup()
        {
            Matcher = new MultiArgMatcher<T>(new MatcherAny<T>());
            _action = new MultiArgAction<T>(x => { });
        }

        public IActionSetup<T> Action(Action<T> action)
        {
            _action = new MultiArgAction<T>(action);
            return this;
        }

        public IActionSetup<T> Action(System.Action action)
        {
            _action = new MultiArgAction<T>((x) => action());
            return this;
        }

        public IActionSetup<T> Match(TypedMatcher<T> arg)
        {
            Matcher = new MultiArgMatcher<T>(arg);
            return this;
        }
    }

    public class ActionSetup<T1, T2> : SetupBase<IActionSetup<T1, T2>>, IActionSetup<T1, T2>
    {
        public ActionSetup()
        {
            Matcher = new MultiArgMatcher<T1, T2>(new MatcherAny<T1>(), new MatcherAny<T2>());
            _action = new MultiArgAction<T1, T2>((x, y) => { });
        }

        public IActionSetup<T1, T2> Action(Action<T1, T2> action)
        {
            _action = new MultiArgAction<T1, T2>(action);
            return this;
        }

        public IActionSetup<T1, T2> Action(System.Action action)
        {
            _action = new MultiArgAction<T1, T2>((x, y) => action());
            return this;
        }

        public IActionSetup<T1, T2> Match(TypedMatcher<T1> arg1, TypedMatcher<T2> arg2)
        {
            Matcher = new MultiArgMatcher<T1, T2>(arg1, arg2);
            return this;
        }
    }
}
