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
    }
}
