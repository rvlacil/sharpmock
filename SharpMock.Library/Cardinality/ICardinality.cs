using System.Text;

namespace SharpMock.Library.Cardinality
{
    public interface ICardinality
    {
        bool IsDepleted();
        void Mark();
        bool IsSatisfied(StringBuilder output);
    }
}
