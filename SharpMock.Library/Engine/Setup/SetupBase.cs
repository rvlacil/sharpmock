﻿using SharpMock.Library.Action;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Matchers;
using System.Text;

namespace SharpMock.Library.Engine.Setup
{
    public abstract class SetupBase<Self> where Self : ISetup
    {
        protected bool _retireOnSaturation;
        protected ICardinality _cardinality;

        public IActionContainer ActionContainer { get; }
        public IMatcher Matcher { get; protected set; }

        public SetupBase()
        {
            _retireOnSaturation = false;
            ActionContainer = new ActionContainer();
        }

        public bool IsSaturated()
        {
            return _retireOnSaturation &&
                (_cardinality?.IsSaturated() ?? ActionContainer.IsSaturated());
        }

        public bool IsSatisfied(IMatchResultListener output)
        {
            return _cardinality?.IsSatisfied(output) ?? ActionContainer.IsSatisfied(output);
        }

        public bool Mark(IMatchResultListener output)
        {
            return (_cardinality?.Mark(output) ?? true) && ActionContainer.Mark(output);
        }

        public Self Times(ICardinality cardinality)
        {
            _cardinality = cardinality;
            return (Self)(ISetup)this;
        }

        public Self Times(int cardinality)
        {
            _cardinality = C.Times(cardinality);
            return (Self)(ISetup)this;
        }

        public Self RetireOnSaturation()
        {
            _retireOnSaturation = true;
            return (Self)(ISetup)this;
        }
    }
}
