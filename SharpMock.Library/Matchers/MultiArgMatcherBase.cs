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

        protected static bool TryMatch<T>(ITypedMatcher<T> matcher, T arg, string argIndex, IMatchResultListener output)
        {
            output.Append("Arg").Append(argIndex).AppendLine(": ");
            using (var scope = output.NewScope())
            {
                return matcher.Match(arg, output);
            }
        }
    }
}
