using SharpMock.Library.Action;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Matchers;
using System;
using System.Text;

namespace SharpMock.Library
{
    public interface ISetupBase
    {
        IMatcher Matcher { get; }
        bool IsDepleted();
        bool IsSatisfied(StringBuilder output);
        void Act(Action<IAction> applier);
    }

    public interface ISetupBase<Self> : ISetupBase where Self : ISetupBase<Self>
    {
        Self Times(ICardinality arity);
    }

    public interface IArgSetupBase<Self> : ISetupBase<Self> where Self : IArgSetupBase<Self>
    {
        Self Match();
        Self Action(System.Action action);
    }

    public interface IArgSetupBase<Self, T1> : ISetupBase<Self> where Self : IArgSetupBase<Self, T1>
    {
        Self Match(TypedMatcher<T1> arg);
        Self Action(System.Action action);
        Self Action(Action<T1> action);
    }

    public interface IArgSetupBase<Self, T1, T2> : ISetupBase<Self> where Self : IArgSetupBase<Self, T1, T2>
    {
        Self Match(TypedMatcher<T1> arg1, TypedMatcher<T2> arg2);
        Self Action(System.Action action);
        Self Action(Action<T1, T2> action);
    }
}
