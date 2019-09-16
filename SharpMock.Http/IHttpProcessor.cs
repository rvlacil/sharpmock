using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SharpMock.Http
{
    public interface IHttpProcessor
    {
        Task<HttpResponseMessage> Reply(HttpRequestMessage request);
    }
}
