using System.Text;

namespace SharpMock.Library.Cardinality
{
    public class CardinalityAny : ICardinality
    {
        public bool IsSaturated()
        {
            return false;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            return true;
        }

        public bool Mark(StringBuilder output)
        {
            return true;
        }
    }
}
