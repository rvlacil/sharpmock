using System.Text;

namespace SharpMock.Library.Matchers
{
    public abstract class MultiArgMatcherBase : IMatcher
    {
        protected readonly string _toPrint;

        public MultiArgMatcherBase(string toPrint)
        {
            _toPrint = "(" + toPrint + ")";
        }

        public string ToPrint()
        {
            return _toPrint;
        }

        protected static bool DoMatch<T>(ITypedMatcher<T> matcher, T arg, string argIndex, StringBuilder output)
        {
            var local = new StringBuilder();
            var matched = matcher.Match(arg, local);
            if (!matched)
            {
                output.Append("Arg").Append(argIndex).Append(": ").Append(local);
            }
            return matched;
        }
    }
}
