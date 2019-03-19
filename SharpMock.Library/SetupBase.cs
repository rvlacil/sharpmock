using SharpMock.Library.Setup.Action;
using SharpMock.Library.Setup.Cardinality;
using SharpMock.Library.Setup.Matchers;
using System;
using System.Text;

namespace SharpMock.Library.Setup
{
    public abstract class SetupBase<Self> : ISetupBase<Self> where Self : ISetupBase<Self>
    {
        protected ICardinality _cardinality;
        protected IAction _action;

        public IMatcher Matcher { get; protected set; }

        public SetupBase()
        {
            _cardinality = C.Once();
        }

        public bool IsDepleted()
        {
            return _cardinality.IsDepleted();
        }

        public bool IsSatisfied(StringBuilder output)
        {
            return _cardinality.IsSatisfied(output);
        }

        public void Act(System.Action<IAction> action)
        {
            if (_cardinality.IsDepleted()) throw new ArgumentException("acting on setup more than arity allows");
            _cardinality.Mark();

            action(_action);
        }

        public Self Times(ICardinality cardinality)
        {
            _cardinality = cardinality;
            return (Self) (ISetupBase<Self>) this;
        }
    }
}
