using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace SharpMock.Http
{
    [ExcludeFromCodeCoverage]
    public class HttpMock
    {
        public HttpProcessorMock ProcessorMock { get; }
        public HttpServer Server { get; }
        public string Address => Server.Address;

        public HttpMock()
            : this(IPAddress.Loopback, 0)
        {
        }

        public HttpMock(int port)
            : this(IPAddress.Loopback, port)
        {
        }

        public HttpMock(IPAddress address, int port)
        {
            ProcessorMock = new HttpProcessorMock();
            Server = new HttpServer(ProcessorMock.O, address, port);
            Server.StartAsync().Wait();
        }
    }
}
