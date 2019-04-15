using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library
{
    public static class MockExtensions
    {
        public static void Verify<T>(this IMock<T> mock)
        {
            var output = new StringBuilder("Not satisfied cardinality of setups:").AppendLine();
            var ret = true;
            foreach (var engine in mock.Engines.Values)
            {
                ret = engine.Verify(output) && ret;
            }

            if (ret == false) throw new ArgumentException(output.ToString());
        }
    }
}
