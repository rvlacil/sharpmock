using SharpMock.Library;
using SharpMock.Library.Matchers;

namespace SharpMock.Http.Matcher
{
    public class PathMatcher : TypedMatcher<HttpRequestMessage>
    {
        private readonly string _path;

        public PathMatcher(string path)
            : base($"Path({path})")
        {
            _path = path;
        }

        public override bool Match(HttpRequestMessage arg, IMatchResultListener listener)
        {
            if (arg.Path == _path) return true;

            listener.Append("Expected Path: ").AppendLine(_path);
            listener.Append("Actual Path: ").AppendLine(arg.Path);

            return false;
        }
    }
}
