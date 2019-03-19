using SharpMock.Library.Setup;
using SharpMock.Library.Setup.Matchers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SharpMock.Library
{
    public static class MockEngineAccessor
    {
        public static InterfaceHolder<I> Do<I>(this IMock<I> mock)
        {
            return new InterfaceHolder<I>(mock);
        }
    }

    public struct InterfaceHolder<I>
    {
        private readonly IMock<I> _mock;

        public InterfaceHolder(IMock<I> mock)
        {
            _mock = mock;
        }

        public IActionSetup Setup(Action action)
        {
            return ((IActionEngine)_mock.Engines[action.Method]).Setup();
        }

        public IActionSetup<T> Setup<T>(Action<T> action)
        {
            return ((IActionEngine<T>)_mock.Engines[action.Method]).Setup();
        }

        public IActionSetup<T1, T2> Setup<T1, T2>(Action<T1, T2> action)
        {
            return ((IActionEngine<T1, T2>)_mock.Engines[action.Method]).Setup();
        }

        public IFuncSetup<Ret> Setup<Ret>(Func<Ret> action)
        {
            return ((IFuncEngine<Ret>)_mock.Engines[action.Method]).Setup();
        }

        public IFuncSetup<T, Ret> Setup<T, Ret>(Func<T, Ret> action)
        {
            return ((IFuncEngine<T, Ret>)_mock.Engines[action.Method]).Setup();
        }

        public IFuncSetup<T, Ret> SetupM<T, Ret>(Func<T, Ret> action, TypedMatcher<T> matcher)
        {
            return ((IFuncEngine<T, Ret>)_mock.Engines[action.Method]).Setup().Match(matcher);
        }

        public IFuncSetup<T1, T2, Ret> Setup<T1, T2, Ret>(Func<T1, T2, Ret> action)
        {
            return ((IFuncEngine<T1, T2, Ret>)_mock.Engines[action.Method]).Setup();
        }

        public IFuncSetup<T1, T2, Ret> SetupM<T1, T2, Ret>(Func<T1, T2, Ret> action, TypedMatcher<T1> m1, TypedMatcher<T2> m2)
        {
            return ((IFuncEngine<T1, T2, Ret>)_mock.Engines[action.Method]).Setup().Match(m1, m2);
        }
        
    }
}
