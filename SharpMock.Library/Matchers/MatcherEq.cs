using System.Collections.Generic;

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

        override public bool Match(T arg, IMatchResultListener output)
        {
            var ret = EqualityComparer<T>.Default.Equals(arg, _value);
            if (!ret)
            {
                output.Append("Expected: '").Append(_value.ToString()).AppendLine("'");
                output.Append("Passed: '").Append(arg.ToString()).AppendLine("'");
            }

            return ret;
        }
    }
}
