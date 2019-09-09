using System.Text;

namespace SharpMock.Library.Matchers
{
    public interface ITypedMatcher<T>
    {
        bool Match(T arg, IMatchResultListener listener);
        string ToPrint();
    }

    public abstract class TypedMatcher<T> : ITypedMatcher<T>
    {
        protected readonly string _toPrint;

        public TypedMatcher(string toPrint)
        {
            _toPrint = toPrint;
        }

        public string ToPrint()
        {
            return _toPrint;
        }

        public abstract bool Match(T arg, IMatchResultListener listener);

        public static implicit operator TypedMatcher<T>(MatcherAny any)
        {
            return new MatcherAny<T>();
        }

        public static implicit operator TypedMatcher<T>(T arg)
        {
            return new MatcherEq<T>(arg);
        }
    }
}
