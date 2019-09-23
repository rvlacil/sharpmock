namespace SharpMock.Library.Cardinality
{
    public interface ICardinality
    {
        bool IsSaturated();
        bool Mark(IMatchResultListener output);
        bool IsSatisfied(IMatchResultListener output);
    }
}
