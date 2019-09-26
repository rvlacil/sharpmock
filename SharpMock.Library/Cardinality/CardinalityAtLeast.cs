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

        public bool IsSatisfied(IMatchResultListener output)
        {
            if (_actual < _requested)
            {
                output.AppendLine("AtLeast Cardinality: ");
                output.NewScope();
                output.AppendLine($"Set up: {_requested}");
                output.AppendLine($"Actual: {_actual}");
                return false;
            }
            return true;
        }

        public bool Mark(IMatchResultListener output)
        {
            ++_actual;
            return true;
        }
    }
}
