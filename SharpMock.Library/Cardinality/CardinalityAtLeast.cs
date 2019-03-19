using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Cardinality
{
    public class CardinalityAtLeast : ICardinality
    {
        private int _actual;
        private readonly int  _requested;


        public CardinalityAtLeast(int i)
        {
            _actual = 0;
            _requested = i;
        }

        public bool IsDepleted()
        {
            return false;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            var ret = _actual >= _requested;
            if (!ret)
            {
                output.Append("requested AtLeast: ");
                output.Append(_requested);
                output.Append(" actual: ");
                output.Append(_actual);
                output.AppendLine();
            }
            return ret;
        }

        public void Mark()
        {
            ++_actual;
        }
    }
}
