using SharpMock.Library.Action;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Matchers;
using System.Text;

namespace SharpMock.Library.Engine.Setup
{
    public interface ISetup : ICardinality
    {
        IMatcher Matcher { get; }
        IActionContainer ActionContainer { get; }
    }
}
