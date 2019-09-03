using SharpMock.Library.Cardinality;

namespace SharpMock.Library.Engine.Setup
{
    public interface ISetupCardinality<Self> : ISetup where Self : ISetupCardinality<Self>
    {
        Self Times(ICardinality arity);
        Self Times(int arity);
        Self RetireOnSaturation();
    }
}
