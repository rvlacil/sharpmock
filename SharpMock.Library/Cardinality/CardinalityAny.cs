using System.Text;

namespace SharpMock.Library.Cardinality
{
    public class CardinalityAny : ICardinality
    {
        public bool IsSaturated()
        {
            return false;
        }

        public bool IsSatisfied(IMatchResultListener output)
        {
            return true;
        }

        public bool Mark(IMatchResultListener output)
        {
            return true;
        }
    }
}
