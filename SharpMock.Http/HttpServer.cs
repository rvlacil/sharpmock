using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;

namespace SharpMock.Http
{
    public class HttpServer
    {
        private readonly IWebHost _host;
        private readonly IHttpProcessor _processor;
        public HttpServer(IHttpProcessor processor, IPAddress address, int port)
        {
            _processor = processor;
            _host = new WebHostBuilder()
                .UseKestrel(o => o.Listen(address, port))
                .Configure(app =>
                {
                    app.Use((next) => ProcessMessage);
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

        private async Task ProcessMessage(HttpContext context)
        {
            var request = await HttpRequestMessageFactory.Create(context);
            try
            {
                var response = await _processor.Reply(request);
                await HttpResponseMessageApplier.Apply(context, response);
            }
            catch (Exception e)
            {
                var response = new HttpResponseMessageBuilder().Status(500).Body(e.Message).Build();
                await HttpResponseMessageApplier.Apply(context, response);
            }
        }
    }
}
