using System.Text;

namespace SharpMock.Library.Matchers
{
    public class MatcherAny<T> : TypedMatcher<T>
    {
        public MatcherAny()
            : base("Any<" + typeof(T).Name + ">")
        {
        }

        public override bool Match(T request, StringBuilder output)
        {
            return true;
        }
    }

    public class MatcherAny
    {
    }
}
