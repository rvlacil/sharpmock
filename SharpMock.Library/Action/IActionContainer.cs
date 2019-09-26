using SharpMock.Library.Cardinality;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Action
{
    public interface IActionContainer : ICardinality
    {
        void Add(IAction action, bool repeated);
        IAction Pop();
    }
}
