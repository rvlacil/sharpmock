using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Cardinality
{
    public static class C
    {
        public static ICardinality Any() => new CardinalityAny();
        public static ICardinality Times(int i) => new CardinalityExact(i);
        public static ICardinality Once() => new CardinalityExact(1);
        public static ICardinality AtLeast(int i) => new CardinalityAtLeast(i);
        public static ICardinality AtMost(int i) => new CardinalityAtMost(i);
    }
}
