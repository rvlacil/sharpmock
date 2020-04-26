using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SharpMock.Http
{
    [ExcludeFromCodeCoverage]
    public class HttpResponseMessage : HttpMessage
    {
        public int Status { get; set; }
    }
}
