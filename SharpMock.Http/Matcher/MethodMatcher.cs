using Microsoft.AspNetCore.Http;
using SharpMock.Library;
using SharpMock.Library.Matchers;

namespace SharpMock.Http.Matcher
{
    public class MethodMatcher : TypedMatcher<HttpRequest>
    {
        private readonly string _method;

        public MethodMatcher(string method)
            : base($"HttpMethod({method})")
        {
            _method = method;
        }

        public override bool Match(HttpRequest arg, IMatchResultListener listener)
        {
            if (arg.Method == _method) return true;

            listener.Append("Expected HttpMethod: ").AppendLine(_method);
            listener.Append("Actual HttpMethod: ").AppendLine(arg.Method);

            return false;
        }
    }
}
