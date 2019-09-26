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

        public bool IsSatisfied(IMatchResultListener output)
        {
            if (_actual > _requested)
            {
                output.AppendLine("AtMost Cardinality:");
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
            return IsSatisfied(output);
        }
    }
}
