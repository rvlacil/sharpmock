using System.Text;

namespace SharpMock.Library.Matchers
{
    
    public class MultiArgMatcher : MultiArgMatcherBase
    {
        public MultiArgMatcher()
            : base("")
        {
        }
    
        public bool TryMatch(IMatchResultListener output)
        {
            return true;
        }
    }
    
    
    public class MultiArgMatcher<T1> : MultiArgMatcherBase
    {
        private readonly ITypedMatcher<T1> _matcher1;
    
        public MultiArgMatcher(ITypedMatcher<T1> matcher1)
            : base(matcher1.ToPrint())
        {
            _matcher1 = matcher1;
        }
    
        public bool TryMatch(T1 arg1, IMatchResultListener output)
        {
            return TryMatch(_matcher1, arg1, "1", output);
        }
    }
    
    
    public class MultiArgMatcher<T1, T2> : MultiArgMatcherBase
    {
        private readonly ITypedMatcher<T1> _matcher1; private readonly ITypedMatcher<T2> _matcher2;
    
        public MultiArgMatcher(ITypedMatcher<T1> matcher1, ITypedMatcher<T2> matcher2)
            : base(matcher1.ToPrint() + ", " + matcher2.ToPrint())
        {
            _matcher1 = matcher1;
            _matcher2 = matcher2;
        }
    
        public bool TryMatch(T1 arg1, T2 arg2, IMatchResultListener output)
        {
            return TryMatch(_matcher1, arg1, "1", output) && TryMatch(_matcher2, arg2, "2", output);
        }
    }
}
