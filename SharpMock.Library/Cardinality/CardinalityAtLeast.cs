using System.Text;

namespace SharpMock.Library.Cardinality
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

        public bool IsSaturated()
        {
            return false;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            if (_actual < _requested)
            {
                output.Append("requested AtLeast: ").Append(_requested).Append(" actual: ").Append(_actual).AppendLine();
                return false;
            }
            return true;
        }

        public bool Mark(StringBuilder output)
        {
            ++_actual;
            return true;
        }
    }
}
