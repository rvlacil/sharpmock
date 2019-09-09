using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SharpMock.Library;
using SharpMock.Library.Engine;

namespace SharpMock.Http
{
    public class HttpMock : IMock<IHttpServer>
    {
        public Dictionary<MethodInfo, IEngine> Engines { get; }

        public IHttpServer I { get; }

        internal class HttpServer : IHttpServer
        {
            private readonly IMock<IHttpServer> _mock;

            public HttpServer(IMock<IHttpServer> mock)
            {
                _mock = mock;
            }

            public Task<HttpResponse> Reply(HttpRequest request)
            {
                var info = (MethodInfo)MethodBase.GetCurrentMethod();
                return ((IFuncEngine<HttpRequest, Task<HttpResponse>>)_mock.Engines[info]).Execute(request);
            }
        }

        public HttpMock()
        {
            Engines = new Dictionary<MethodInfo, IEngine>();
            I = new HttpServer(this);

            var info = (new Func<HttpRequest, Task<HttpResponse>>(I.Reply)).Method;
            Engines[info] = new FuncEngine<HttpRequest, Task<HttpResponse>>(info.Name);
        }
    }
}
