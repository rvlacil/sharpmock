
using SharpMock.Library.Matchers;
using System;

namespace SharpMock.Library
{
    public struct MockHolder<I>
    {
        private readonly IMock<I> _mock;

        public MockHolder(IMock<I> mock)
        {
            _mock = mock;
        }

		public IActionSetup Setup(System.Action action)
		{
			return ((IActionEngine)_mock.Engines[action.Method]).Setup();
		}

        public IFuncSetup<Ret> Setup<Ret>(Func<Ret> action)
        {
            return ((IFuncEngine<Ret>)_mock.Engines[action.Method]).Setup().Match();
        }

        public IActionSetup<T1> Setup<T1>(Action<T1> action, TypedMatcher<T1> m1)
        {
        	return ((IActionEngine<T1>)_mock.Engines[action.Method]).Setup().Match(m1);
        }
        
        public IFuncSetup<T1, Ret> Setup<T1, Ret>(Func<T1, Ret> action, TypedMatcher<T1> m1)
        {
        	return ((IFuncEngine<T1, Ret>)_mock.Engines[action.Method]).Setup().Match(m1);
        }
        
        public IActionSetup<T1, T2> Setup<T1, T2>(Action<T1, T2> action, TypedMatcher<T1> m1, TypedMatcher<T2> m2)
        {
        	return ((IActionEngine<T1, T2>)_mock.Engines[action.Method]).Setup().Match(m1, m2);
        }
        
        public IFuncSetup<T1, T2, Ret> Setup<T1, T2, Ret>(Func<T1, T2, Ret> action, TypedMatcher<T1> m1, TypedMatcher<T2> m2)
        {
        	return ((IFuncEngine<T1, T2, Ret>)_mock.Engines[action.Method]).Setup().Match(m1, m2);
        }
        
	}
}
