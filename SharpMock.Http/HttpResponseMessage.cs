using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http
{
    public class HttpResponseMessage : HttpMessage
    {
        public int Status { get; set; }
    }
}
