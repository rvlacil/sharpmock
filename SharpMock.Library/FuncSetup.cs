using System;
using System.Collections.Generic;
using System.Text;
using SharpMock.Library.Setup.Action;
using SharpMock.Library.Setup.Matchers;
using SharpMock.Library.Setup.Return;

namespace SharpMock.Library.Setup
{
    public abstract class FuncSetupBase<Self, Ret> : SetupBase<Self> where Self : ISetupBase<Self>
    {
        protected IReturn<Ret> _return;

        public Ret Respond(Func<IReturn<Ret>, Ret> applier)
        {
            return applier(_return);
        }
    }

    public class FuncSetup<Ret> : FuncSetupBase<IFuncSetup<Ret>, Ret>, IFuncSetup<Ret>
    {
        public FuncSetup()
        {
            Matcher = new MultiArgMatcher();
            _action = new MultiArgAction(() => { });
            _return = new MultiArgReturn<Ret>(() => default(Ret));
        }

        public IFuncSetup<Ret> Action(System.Action action)
        {
            _action = new MultiArgAction(action);
            return this;
        }

        public IFuncSetup<Ret> Match()
        {
            return this;
        }

        public IFuncSetup<Ret> Return(Ret value)
        {
            _return = new MultiArgReturn<Ret>(() => value);
            return this;
        }

        public IFuncSetup<Ret> Return(Func<Ret> func)
        {
            _return = new MultiArgReturn<Ret>(func);
            return this;
        }
    }

    public class FuncSetup<T, Ret> : FuncSetupBase<IFuncSetup<T, Ret>, Ret>, IFuncSetup<T, Ret>
    {
        public FuncSetup()
        {
            Matcher = new MultiArgMatcher<T>(new MatcherAny<T>());
            _action = new MultiArgAction<T>(x => { });
            _return = new MultiArgReturn<T, Ret>((x) => default(Ret));
        }

        public IFuncSetup<T, Ret> Action(Action<T> action)
        {
            _action = new MultiArgAction<T>(action);
            return this;
        }

        public IFuncSetup<T, Ret> Action(System.Action action)
        {
            _action = new MultiArgAction<T>((x) => action());
            return this;
        }

        public IFuncSetup<T, Ret> Match(TypedMatcher<T> arg)
        {
            Matcher = new MultiArgMatcher<T>(arg);
            return this;
        }

        public IFuncSetup<T, Ret> Return(Ret value)
        {
            _return = new MultiArgReturn<T, Ret>((x) => value);
            return this;
        }

        public IFuncSetup<T, Ret> Return(Func<T, Ret> func)
        {
            _return = new MultiArgReturn<T, Ret>(func);
            return this;
        }
    }

    public class FuncSetup<T1, T2, Ret> : FuncSetupBase<IFuncSetup<T1, T2, Ret>, Ret>, IFuncSetup<T1, T2, Ret>
    {
        public FuncSetup()
        {
            Matcher = new MultiArgMatcher<T1, T2>(new MatcherAny<T1>(), new MatcherAny<T2>());
            _action = new MultiArgAction<T1, T2>((x, y) => { });
            _return = new MultiArgReturn<T1, T2, Ret>((x, y) => default(Ret));
        }

        public IFuncSetup<T1, T2, Ret> Action(Action<T1, T2> action)
        {
            _action = new MultiArgAction<T1, T2>(action);
            return this;
        }

        public IFuncSetup<T1, T2, Ret> Action(System.Action action)
        {
            _action = new MultiArgAction<T1, T2>((x, y) => action());
            return this;
        }

        public IFuncSetup<T1, T2, Ret> Match(TypedMatcher<T1> arg1, TypedMatcher<T2> arg2)
        {
            Matcher = new MultiArgMatcher<T1, T2>(arg1, arg2);
            return this;
        }

        public IFuncSetup<T1, T2, Ret> Return(Ret value)
        {
            _return = new MultiArgReturn<T1, T2, Ret>((x, y) => value);
            return this;
        }

        public IFuncSetup<T1, T2, Ret> Return(Func<T1, T2, Ret> func)
        {
            _return = new MultiArgReturn<T1, T2, Ret>(func);
            return this;
        }
    }
}
