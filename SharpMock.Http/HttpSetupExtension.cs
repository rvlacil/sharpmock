using System.Threading.Tasks;
using SharpMock.Library;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;

namespace SharpMock.Http
{
    public static class HttpSetupExtension
    {
        public static IFuncSetup<HttpRequestMessage, Task<HttpResponseMessage>> Setup(this HttpMock mock, TypedMatcher<HttpRequestMessage> matcher)
        {
            return mock.ProcessorMock.Add().Setup(mock.ProcessorMock.O.Reply, matcher);
        }
    }
}
