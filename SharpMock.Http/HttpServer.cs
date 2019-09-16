using Microsoft.AspNetCore.Hosting;
using System.IO;
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
                .UseKestrel()
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
    }
}
