using System.Text;
using Microsoft.AspNetCore.Http;

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
            if (Headers.Count > 0)
            {
                foreach (var pair in Headers)
                {
                    builder.AppendLine();
                    builder.Append(pair.Key).Append(": ").Append(pair.Value);
                }
            }
            if (Body.Length > 0)
            {
                builder.AppendLine();
                builder.AppendLine();
                builder.Append(Body);
            }
        }
    }
}
