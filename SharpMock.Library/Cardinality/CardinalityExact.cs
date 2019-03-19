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
       
        public bool IsDepleted()
        {
            return _actual >= _requested;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            var ret = _actual == _requested;
            if (!ret)
            {
                output.Append("requested Exact: ").Append(_requested).Append(" actual: ").Append(_actual).AppendLine();
            }
            return ret;
        }

        public void Mark()
        {
            ++_actual;
        }
    }
}
