using SharpMock.Library;
using SharpMock.Library.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http.Matcher
{
    public class HeaderMatcher : TypedMatcher<HttpRequestMessage>
    {
        private readonly string _name;
        private readonly string _value;

        public HeaderMatcher(string name, string value)
            : base($"Header({name},{value})")
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override bool Match(HttpRequestMessage arg, IMatchResultListener listener)
        {
            if (arg.Headers.TryGetValue(_name, out var value))
            {
                if (value == _value)
                {
                    return true;
                }
                else
                {
                    listener.Append("Expected header: ").AppendLine(_name);
                    listener.Append("Expected value: ").AppendLine(_value);
                    listener.Append("Actual value: ").AppendLine(value);
                    return false;
                }
            }
            else
            {
                listener.Append("Expected header missing: ").AppendLine(_name);
                return false;
            }
        }
    }
}
