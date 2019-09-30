using SharpMock.Library;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using System.Threading.Tasks;

namespace SharpMock.Http
{
    public static class HttpSetupExtension
    {
        public static IFuncSetup<HttpRequestMessage, Task<HttpResponseMessage>> Setup(this IMock<IHttpProcessor> mock, TypedMatcher<HttpRequestMessage> matcher)
        {
            return mock.Add().Setup(mock.O.Reply, matcher);
        }
    }
}
