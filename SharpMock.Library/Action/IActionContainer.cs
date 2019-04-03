using SharpMock.Library.Cardinality;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Action
{
    public interface IActionContainer : ICardinality
    {
        void AddRepeatedly(IAction action);
        void Add(IAction action);
        IAction Top();
        void Pop();
    }
}
