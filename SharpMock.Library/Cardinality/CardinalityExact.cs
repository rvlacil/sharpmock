using System.Text;

namespace SharpMock.Library.Cardinality
{
    public class CardinalityExact : ICardinality
    {
        private int _actual;
        private readonly int  _requested;

        public CardinalityExact(int count)
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
            if (_actual != _requested)
            {
                PrintError(output);
                return false;
            }
            return true;
        }

        public bool Mark(StringBuilder output)
        {
            ++_actual;
            if (_actual > _requested)
            {
                PrintError(output);
                return false;
            }
            return true;
        }

        private void PrintError(StringBuilder output)
        {
            output.Append("requested Exact: ").Append(_requested).Append(" actual: ").Append(_actual).AppendLine();
        }
    }
}
