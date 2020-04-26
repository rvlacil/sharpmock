using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http
{
    public class HttpMessageBuilder<T> where T : HttpMessageBuilder<T>
    {
        protected readonly IHeaderDictionary _headers = new HeaderDictionary();
        protected string _body = "";

        public T Body(string body)
        {
            _body = body;
            return (T) this;
        }

        public T AddHeader(string name, string value)
        {
            _headers.Append(name, value);
            return (T)this;
        }

        public T ReplaceHeader(string name, string value)
        {
            _headers.Add(name, value);
            return (T)this;
        }
    }
}
