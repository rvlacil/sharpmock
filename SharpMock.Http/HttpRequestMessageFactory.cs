using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SharpMock.Http
{
    public static class HttpRequestMessageFactory
    {
        public static async Task<HttpRequestMessage> Create(HttpContext ctx)
        {
            return new HttpRequestMessage
            {
                HttpContext = ctx,
                Method = ctx.Request.Method,
                Path = ctx.Request.Path,
                Headers = ctx.Request.Headers,
                Body = await GetBody(ctx.Request.Body)
            };
        }

        private static async Task<string> GetBody(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }
}
