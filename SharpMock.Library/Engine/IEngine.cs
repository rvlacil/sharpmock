using System.Text;

namespace SharpMock.Library
{
    public interface IEngine
    {
        bool Verify(StringBuilder output);
    }
}
