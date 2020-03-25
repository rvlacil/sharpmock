using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http
{
    public class HttpRequestMessage : HttpMessage
    {
        public string Method { get; set; }
        public PathString Path { get; set; }
        public HttpContext HttpContext { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(Method).Append(" ").Append(Path);
            SerializeTo(builder);

            return builder.ToString();
        }
    }
}
