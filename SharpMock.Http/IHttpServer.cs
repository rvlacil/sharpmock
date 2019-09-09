using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SharpMock.Http
{
    public interface IHttpServer
    {
        Task<HttpResponse> Reply(HttpRequest request);
    }
}
