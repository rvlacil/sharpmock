using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SharpMock.Http
{
    [ExcludeFromCodeCoverage]
    public class HttpRequestMessageBuilder
    {
        private string _method = "GET";
        private string _path = "";
        private readonly IHeaderDictionary _headers = new HeaderDictionary();
        private string _body = "";

        public HttpRequestMessageBuilder Body(string body)
        {
            _body = body;
            return this;
        }

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

        public HttpRequestMessageBuilder AddHeader(string name, string value)
        {
            _headers.Append(name, value);
            return this;
        }

        public HttpRequestMessageBuilder ReplaceHeader(string name, string value)
        {
            _headers.Add(name, value);
            return this;
        }

        public HttpRequestMessage Build()
        {
            return new HttpRequestMessage { Method = _method, Path = _path, Headers = _headers, Body = _body, HttpContext = new DefaultHttpContext() };
        }
    }
}
