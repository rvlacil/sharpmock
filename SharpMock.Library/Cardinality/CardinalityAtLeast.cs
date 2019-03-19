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

        public bool IsDepleted()
        {
            return false;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            var ret = _actual >= _requested;
            if (!ret)
            {
                output.Append("requested AtLeast: ").Append(_requested).Append(" actual: ").Append(_actual).AppendLine();
            }
            return ret;
        }

        public void Mark()
        {
            ++_actual;
        }
    }
}
