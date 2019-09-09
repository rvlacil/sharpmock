using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library
{
    public static class MockExtensions
    {
        public static void Verify<T>(this IMock<T> mock)
        {
            var output = new MatchResultListener();
            output.AppendLine("Not satisfied cardinality of setups:");

            var ret = true;
            foreach (var engine in mock.Engines.Values)
            {
                ret = engine.Verify(output) && ret;
            }

            if (ret == false) throw new ArgumentException(output.Message());
        }

        public static MockHolder<I> Add<I>(this IMock<I> mock)
        {
            return new MockHolder<I>(mock);
        }
    }
}
