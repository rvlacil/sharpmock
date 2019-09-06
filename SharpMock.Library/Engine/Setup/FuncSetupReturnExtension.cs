using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpMock.Library.Engine.Setup
{
    public static class FuncSetupReturnExtension
    {
        public static IFuncSetup<TRet> Return<TRet>(this IFuncSetup<TRet> setup, TRet value)
        {
            setup.Do(() => value);
            return setup;
        }

        public static IFuncSetup<T1, TRet> Return<T1, TRet>(this IFuncSetup<T1, TRet> setup, TRet value)
        {
            setup.Do((_) => value);
            return setup;
        }

        public static IFuncSetup<T1, T2, TRet> Return<T1, T2, TRet>(this IFuncSetup<T1, T2, TRet> setup, TRet value)
        {
            setup.Do((i, j) => value);
            return setup;
        }

        public static IFuncSetup<Task<TRet>> ReturnAsync<TRet>(this IFuncSetup<Task<TRet>> setup, TRet value)
        {
            setup.Do(() => Task.FromResult(value));
            return setup;
        }

        public static IFuncSetup<T1, Task<TRet>> ReturnAsync<T1, TRet>(this IFuncSetup<T1, Task<TRet>> setup, TRet value)
        {
            setup.Do((_) => Task.FromResult(value));
            return setup;
        }

        public static IFuncSetup<T1, T2, Task<TRet>> ReturnAsync<T1, T2, TRet>(this IFuncSetup<T1, T2, Task<TRet>> setup, TRet value)
        {
            setup.Do((i, j) => Task.FromResult(value));
            return setup;
        }

        public static IFuncSetup<TRet> Throws<TRet>(this IFuncSetup<TRet> setup, Exception e)
        {
            setup.Do(() => throw e);
            return setup;
        }

        public static IFuncSetup<T1, TRet> Throws<T1, TRet>(this IFuncSetup<T1, TRet> setup, Exception e)
        {
            setup.Do((_) => throw e);
            return setup;
        }

        public static IFuncSetup<T1, T2, TRet> Throws<T1, T2, TRet>(this IFuncSetup<T1, T2, TRet> setup, Exception e)
        {
            setup.Do((i, j) => throw e);
            return setup;
        }

        public static IFuncSetup<TRet> ReturnRepeatedly<TRet>(this IFuncSetup<TRet> setup, TRet value)
        {
            setup.DoRepeatedly(() => value);
            return setup;
        }

        public static IFuncSetup<T1, TRet> ReturnRepeatedly<T1, TRet>(this IFuncSetup<T1, TRet> setup, TRet value)
        {
            setup.DoRepeatedly((_) => value);
            return setup;
        }

        public static IFuncSetup<T1, T2, TRet> ReturnRepeatedly<T1, T2, TRet>(this IFuncSetup<T1, T2, TRet> setup, TRet value)
        {
            setup.DoRepeatedly((i, j) => value);
            return setup;
        }

        public static IFuncSetup<Task<TRet>> ReturnAsyncRepeatedly<TRet>(this IFuncSetup<Task<TRet>> setup, TRet value)
        {
            setup.DoRepeatedly(() => Task.FromResult(value));
            return setup;
        }

        public static IFuncSetup<T1, Task<TRet>> ReturnAsyncRepeatedly<T1, TRet>(this IFuncSetup<T1, Task<TRet>> setup, TRet value)
        {
            setup.DoRepeatedly((_) => Task.FromResult(value));
            return setup;
        }

        public static IFuncSetup<T1, T2, Task<TRet>> ReturnAsyncRepeatedly<T1, T2, TRet>(this IFuncSetup<T1, T2, Task<TRet>> setup, TRet value)
        {
            setup.DoRepeatedly((i, j) => Task.FromResult(value));
            return setup;
        }

        public static IFuncSetup<TRet> ThrowsRepeatedly<TRet>(this IFuncSetup<TRet> setup, Exception e)
        {
            setup.DoRepeatedly(() => throw e);
            return setup;
        }

        public static IFuncSetup<T1, TRet> ThrowsRepeatedly<T1, TRet>(this IFuncSetup<T1, TRet> setup, Exception e)
        {
            setup.DoRepeatedly((_) => throw e);
            return setup;
        }

        public static IFuncSetup<T1, T2, TRet> ThrowsRepeatedly<T1, T2, TRet>(this IFuncSetup<T1, T2, TRet> setup, Exception e)
        {
            setup.Do((i, j) => throw e);
            return setup;
        }
    }
}
