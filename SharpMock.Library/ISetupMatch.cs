using SharpMock.Library.Matchers;
using System;

namespace SharpMock.Library
{
    public interface ISetupMatch<Self> : ISetup where Self : ISetupMatch<Self>
    {
        Self Match();
    }

    public interface ISetupMatch<Self, T1> : ISetup where Self : ISetupMatch<Self, T1>
    {
    	Self Match(TypedMatcher<T1> arg1);
    }
    
    public interface ISetupMatch<Self, T1, T2> : ISetup where Self : ISetupMatch<Self, T1, T2>
    {
    	Self Match(TypedMatcher<T1> arg1, TypedMatcher<T2> arg2);
    }
    
}
