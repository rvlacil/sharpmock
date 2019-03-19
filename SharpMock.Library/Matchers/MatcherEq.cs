using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Matchers
{
    public class MatcherEq<T> : TypedMatcher<T>
    {
        private readonly T _value;

        public MatcherEq(T value)
            : base("Eq<" + typeof(T).Name + ">(" + value.ToString() + ")")
        {
            _value = value;
        }

        override public bool Match(T arg, StringBuilder output)
        {
            var ret = EqualityComparer<T>.Default.Equals(arg, _value);
            if (!ret) output.AppendLine("Expected: '" + _value.ToString() + "' Passed: '" + arg.ToString() + "'");

            return ret;
        }
    }
}
