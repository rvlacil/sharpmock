using System.Text;

namespace SharpMock.Library.Cardinality
{
    public interface ICardinality
    {
        bool IsSaturated();
        bool Mark(StringBuilder output);
        bool IsSatisfied(StringBuilder output);
    }
}
