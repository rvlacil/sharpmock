using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SharpMock.Http
{
    public class HttpServer
    {
        private readonly IWebHost _host;
        private readonly IHttpProcessor _processor;
        public HttpServer(IHttpProcessor processor)
        {
            _processor = processor;
            _host = new WebHostBuilder()
                .UseKestrel(o => o.Listen(IPAddress.Loopback, 55555))
                .Configure(app =>
                {
                    app.Use((next) => async (context) =>
                    {
                        var request = await HttpRequestMessageFactory.Create(context);
                        var response = await _processor.Reply(request);
                        await HttpResponseMessageApplier.Apply(context, response);
                    });
                })
                .Build();
        }

        public Task StartAsync()
        {
            return _host.StartAsync();
        }

        public Task StopAsync()
        {
            return _host.StopAsync();
        }

        public string Address => _host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First();
    }
}
