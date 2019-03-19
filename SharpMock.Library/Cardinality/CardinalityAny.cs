using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Cardinality
{
    public class CardinalityAny : ICardinality
    {
        public bool IsDepleted()
        {
            return false;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            return true;
        }

        public void Mark()
        {
        }
    }
}
