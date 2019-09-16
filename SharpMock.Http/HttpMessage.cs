using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http
{
    public class HttpMessage
    {
        public IHeaderDictionary Headers { get; set; }
        public string Body {get; set;}
    }
}
