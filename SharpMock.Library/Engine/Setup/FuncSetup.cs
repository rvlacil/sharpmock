using System;
using SharpMock.Library.Action;
using SharpMock.Library.Matchers;

namespace SharpMock.Library.Engine.Setup
{
    public abstract class FuncSetupBase<Self, Ret> : SetupBase<Self> where Self : ISetup
    {
    }

    public class FuncSetup<Ret> : FuncSetupBase<IFuncSetup<Ret>, Ret>, IFuncSetup<Ret>
    {
        public FuncSetup()
        {
            Matcher = new MultiArgMatcher();
        }

        public IFuncSetup<Ret> Match()
        {
            return this;
        }

        public IFuncSetup<Ret> Do(Func<Ret> func, bool repeated)
        {
            ActionContainer.Add(new MultiArgReturn<Ret>(func), repeated);
            return this;
        }
    }

    public class FuncSetup<T, Ret> : FuncSetupBase<IFuncSetup<T, Ret>, Ret>, IFuncSetup<T, Ret>
    {
        public FuncSetup()
        {
            Matcher = new MultiArgMatcher<T>(new MatcherAny<T>());
        }

        public IFuncSetup<T, Ret> Match(TypedMatcher<T> arg)
        {
            Matcher = new MultiArgMatcher<T>(arg);
            return this;
        }

        public IFuncSetup<T, Ret> Do(Func<T, Ret> func, bool repeated)
        {
            ActionContainer.Add(new MultiArgReturn<T, Ret>(func), repeated);
            return this;
        }
    }

    public class FuncSetup<T1, T2, Ret> : FuncSetupBase<IFuncSetup<T1, T2, Ret>, Ret>, IFuncSetup<T1, T2, Ret>
    {
        public FuncSetup()
        {
            Matcher = new MultiArgMatcher<T1, T2>(new MatcherAny<T1>(), new MatcherAny<T2>());
        }

        public IFuncSetup<T1, T2, Ret> Match(TypedMatcher<T1> arg1, TypedMatcher<T2> arg2)
        {
            Matcher = new MultiArgMatcher<T1, T2>(arg1, arg2);
            return this;
        }

        public IFuncSetup<T1, T2, Ret> Do(Func<T1, T2, Ret> func, bool repeated)
        {
            ActionContainer.Add(new MultiArgReturn<T1, T2, Ret>(func), repeated);
            return this;
        }
    }
}
