using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http
{
    public class HttpMessage
    {
        public IHeaderDictionary Headers { get; set; }
        public string Body { get; set;}

        public HttpMessage()
        {
            Headers = new HeaderDictionary();
        }

        protected void SerializeTo(StringBuilder builder)
        {
            foreach (var pair in Headers)
            {
                builder.Append(pair.Key).Append(": ").AppendLine(pair.Value);
            }
            builder.Append(Body);
        }
    }
}
