using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpMock.Http
{
    public static class HttpResponseMessageApplier
    {
        public static Task Apply(HttpContext context, HttpResponseMessage message)
        {
            context.Response.StatusCode = message.Status;
            foreach (var (name, value) in message.Headers)
            {
                context.Response.Headers.Add(name, value);
            }
            message.Body = message.Body ?? string.Empty;
            return context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(message.Body), 0, message.Body.Length);
        }
    }
}
