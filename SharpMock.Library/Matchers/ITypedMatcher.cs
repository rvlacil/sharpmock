using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Matchers
{
    public interface ITypedMatcher<T>
    {
        bool Match(T arg, StringBuilder builder);
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

        public abstract bool Match(T arg, StringBuilder builder);

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
