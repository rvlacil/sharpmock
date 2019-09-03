using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Matchers
{
    public class TupleBasedMultiMatcher<T> : ITypedMatcher<T>
    {
        public bool Match(T arg, StringBuilder builder)
        {
            throw new NotImplementedException();
        }

        public string ToPrint()
        {
            return "TupleBasedMultiMatcher";
        }
    }
}
