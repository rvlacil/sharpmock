using System.Text;

namespace SharpMock.Library.Engine
{
    public interface IEngine
    {
        bool Verify(StringBuilder output);
    }
}
