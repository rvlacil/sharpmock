using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http
{
    public class HttpResponseMessageBuilder : HttpMessageBuilder<HttpResponseMessageBuilder>
    {
        public int _status;

        public HttpResponseMessageBuilder Status(int status)
        {
            _status = status;
            return this;
        }

        public HttpResponseMessage Build()
        {
            return new HttpResponseMessage { Status = _status, Headers = _headers, Body = _body };
        }
    }
}
