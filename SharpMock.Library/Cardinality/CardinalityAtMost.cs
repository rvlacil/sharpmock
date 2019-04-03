using System.Text;

namespace SharpMock.Library.Cardinality
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

        public bool IsSaturated()
        {
            return _actual >= _requested;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            if (_actual > _requested)
            {
                output.Append("requested AtMost: ").Append(_requested).Append(" actual: ").Append(_actual).AppendLine();
                return false;
            }
            return true;
        }

        public bool Mark(StringBuilder output)
        {
            ++_actual;
            return IsSatisfied(output);
        }
    }
}
