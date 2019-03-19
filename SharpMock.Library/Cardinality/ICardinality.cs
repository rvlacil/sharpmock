using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Cardinality
{
    public interface ICardinality
    {
        bool IsDepleted();
        void Mark();
        bool IsSatisfied(StringBuilder output);
    }
}
