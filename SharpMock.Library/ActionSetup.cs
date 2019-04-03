using SharpMock.Library.Matchers;
using SharpMock.Library.Action;
using System;

namespace SharpMock.Library
{
    public class ActionSetupBase<Self> : SetupBase<Self> where Self : ISetup
    {
        public void Act(Action<IAction> action)
        {
            action(ActionContainer.Top());
            ActionContainer.Pop();
        }
    }

    public class ActionSetup : ActionSetupBase<IActionSetup>, IActionSetup
    {
        public ActionSetup()
        {
            Matcher = new MultiArgMatcher();
        }

        public IActionSetup Do(System.Action action)
        {
            ActionContainer.Add(new MultiArgAction(action));
            return this;
        }

        public IActionSetup DoRepeatedly(System.Action action)
        {
            ActionContainer.AddRepeatedly(new MultiArgAction(action));
            return this;
        }

        public IActionSetup Match()
        {
            return this;
        }
    }

    public class ActionSetup<T> : ActionSetupBase<IActionSetup<T>>, IActionSetup<T>
    {
        public ActionSetup()
        {
            Matcher = new MultiArgMatcher<T>(new MatcherAny<T>());
        }

        public IActionSetup<T> Do(Action<T> action)
        {
            ActionContainer.Add(new MultiArgAction<T>(action));
            return this;
        }

        public IActionSetup<T> DoRepeatedly(Action<T> action)
        {
            ActionContainer.AddRepeatedly(new MultiArgAction<T>(action));
            return this;
        }

        public IActionSetup<T> Match(TypedMatcher<T> arg)
        {
            Matcher = new MultiArgMatcher<T>(arg);
            return this;
        }
    }

    public class ActionSetup<T1, T2> : ActionSetupBase<IActionSetup<T1, T2>>, IActionSetup<T1, T2>
    {
        public ActionSetup()
        {
            Matcher = new MultiArgMatcher<T1, T2>(new MatcherAny<T1>(), new MatcherAny<T2>());
        }

        public IActionSetup<T1, T2> Do(Action<T1, T2> action)
        {
            ActionContainer.Add(new MultiArgAction<T1, T2>(action));
            return this;
        }

        public IActionSetup<T1, T2> DoRepeatedly(Action<T1, T2> action)
        {
            ActionContainer.AddRepeatedly(new MultiArgAction<T1, T2>(action));
            return this;
        }

        public IActionSetup<T1, T2> Match(TypedMatcher<T1> arg1, TypedMatcher<T2> arg2)
        {
            Matcher = new MultiArgMatcher<T1, T2>(arg1, arg2);
            return this;
        }
    }
}
