using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SharpMock.Http
{
    [ExcludeFromCodeCoverage]
    public class HttpRequestMessageBuilder : HttpMessageBuilder<HttpRequestMessageBuilder>
    {
        private string _method = "GET";
        private string _path = "";

        public HttpRequestMessageBuilder Path(string path)
        {
            _path = path;
            return this;
        }

        public HttpRequestMessageBuilder Method(string method)
        {
            _method = method;
            return this;
        }

        public HttpRequestMessage Build()
        {
            return new HttpRequestMessage { Method = _method, Path = _path, Headers = _headers, Body = _body, HttpContext = new DefaultHttpContext() };
        }
    }
}
