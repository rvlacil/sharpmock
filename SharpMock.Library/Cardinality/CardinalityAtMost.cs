using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Cardinality
{
    public class CardinalityAtMost : ICardinality
    {
        private int _actual;
        private readonly int  _requested;

        public CardinalityAtMost(int count)
        {
            _actual = 0;
            _requested = count;
        }

        public bool IsDepleted()
        {
            return _actual >= _requested;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            var ret = _actual <= _requested;
            if (!ret)
            {
                output.Append("requested AtMost: ");
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
