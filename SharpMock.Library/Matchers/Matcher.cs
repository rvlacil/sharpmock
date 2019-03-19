using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Matchers
{
    public static class M
    {
        public static MatcherEq<T> Eq<T>(T arg)
        {
            return new MatcherEq<T>(arg);
        }

        public static MatcherAny<T> Any<T>()
        {
            return new MatcherAny<T>();
        }

        public static MatcherAny<T> Any<T>(T arg)
        {
            return new MatcherAny<T>();
        }

        public static MatcherAny _ => new MatcherAny();
    }
}
