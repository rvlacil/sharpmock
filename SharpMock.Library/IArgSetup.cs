using SharpMock.Library.Matchers;
using System;

namespace SharpMock.Library
{
    public interface IArgSetup<Self> : ISetup<Self> where Self : ISetup<Self>
    {
        Self Match();
        Self Action(System.Action action);
    }

    public interface IArgSetup<Self, T1> : ISetup<Self> where Self : ISetup<Self>
    {
    	Self Match(TypedMatcher<T1> arg1);
    	Self Action(System.Action action);
    	Self Action(Action<T1> action);
    }
    
    public interface IArgSetup<Self, T1, T2> : ISetup<Self> where Self : ISetup<Self>
    {
    	Self Match(TypedMatcher<T1> arg1, TypedMatcher<T2> arg2);
    	Self Action(System.Action action);
    	Self Action(Action<T1, T2> action);
    }
    
}
