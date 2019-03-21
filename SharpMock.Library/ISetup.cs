using SharpMock.Library.Action;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Matchers;
using System;
using System.Text;

namespace SharpMock.Library
{
    public interface ISetup
    {
        IMatcher Matcher { get; }
        bool IsDepleted();
        bool IsSatisfied(StringBuilder output);
        void Act(Action<IAction> applier);
    }

    public interface ISetup<Self> : ISetup where Self : ISetup<Self>
    {
        Self Times(ICardinality arity);
    }
}
