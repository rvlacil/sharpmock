using SharpMock.Library;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using System.Threading.Tasks;

namespace SharpMock.Http
{
    public static class HttpProcessorMockExtension
    {
        public static IFuncSetup<HttpRequestMessage, Task<HttpResponseMessage>> Setup(this HttpProcessorMock mock, TypedMatcher<HttpRequestMessage> requestMatcher)
        {
            return mock.Add().Setup(mock.O.Reply, requestMatcher);
        }
    }
}
