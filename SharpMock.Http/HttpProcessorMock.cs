using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using SharpMock.Library;
using SharpMock.Library.Engine;

namespace SharpMock.Http
{
    public class HttpProcessorMock : IMock<IHttpProcessor>
    {
        public Dictionary<MethodInfo, IEngine> Engines { get; }

        public IHttpProcessor O { get; }

        internal class HttpProcessor : IHttpProcessor
        {
            private readonly IMock<IHttpProcessor> _mock;

            public HttpProcessor(IMock<IHttpProcessor> mock)
            {
                _mock = mock;
            }

            public Task<HttpResponseMessage> Reply(HttpRequestMessage request)
            {
                var info = (MethodInfo)MethodBase.GetCurrentMethod();
                return ((IFuncEngine<HttpRequestMessage, Task<HttpResponseMessage>>)_mock.Engines[info]).Execute(request);
            }
        }

        public HttpProcessorMock()
        {
            Engines = new Dictionary<MethodInfo, IEngine>();
            O = new HttpProcessor(this);

            var info = new Func<HttpRequestMessage, Task<HttpResponseMessage>>(O.Reply).Method;
            Engines[info] = new FuncEngine<HttpRequestMessage, Task<HttpResponseMessage>>(info.Name);
        }
    }
}
