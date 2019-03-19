using System.Text;

namespace SharpMock.Library.Setup.Matchers
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

    public class MultiArgMatcher : MultiArgMatcherBase
    {
        public MultiArgMatcher()
            : base("")
        {
        }

        public bool Match(StringBuilder output)
        {
            return true;
        }
    }

    public class MultiArgMatcher<T> : MultiArgMatcherBase
    {
        private readonly ITypedMatcher<T> _matcher1;

        public MultiArgMatcher(ITypedMatcher<T> matcher)
            : base(matcher.ToPrint())
        {
            _matcher1 = matcher;
        }

        public bool Match(T arg, StringBuilder output)
        {
            return DoMatch(_matcher1, arg, "1", output);
        }
    }

    public class MultiArgMatcher<T1, T2> : MultiArgMatcherBase
    {
        private readonly ITypedMatcher<T1> _matcher1;
        private readonly ITypedMatcher<T2> _matcher2;

        public MultiArgMatcher(ITypedMatcher<T1> matcher1, ITypedMatcher<T2> matcher2)
            : base(matcher1.ToPrint() + ", " + matcher2.ToPrint())
        {
            _matcher1 = matcher1;
            _matcher2 = matcher2;
        }

        public bool Match(T1 arg1, T2 arg2, StringBuilder output)
        {
            return
                DoMatch(_matcher1, arg1, "1", output) &&
                DoMatch(_matcher2, arg2, "2", output);
        }
    }
}
