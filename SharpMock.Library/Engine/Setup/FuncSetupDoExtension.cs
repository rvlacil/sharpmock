using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Engine.Setup
{
    public static class FuncSetupDoExtension
    {
        public static IFuncSetup<T1, TRet> Do<T1, TRet>(this IFuncSetup<T1, TRet> setup, Func<TRet> value)
        {
            setup.Do((i) => value());
            return setup;
        }

        public static IFuncSetup<T1, T2, TRet> Do<T1, T2, TRet>(this IFuncSetup<T1, T2, TRet> setup, Func<TRet> value)
        {
            setup.Do((i, j) => value());
            return setup;
        }

        public static IFuncSetup<T1, TRet> DoRepeatedly<T1, TRet>(this IFuncSetup<T1, TRet> setup, Func<TRet> value)
        {
            setup.DoRepeatedly((i) => value());
            return setup;
        }

        public static IFuncSetup<T1, T2, TRet> DoRepeatedly<T1, T2, TRet>(this IFuncSetup<T1, T2, TRet> setup, Func<TRet> value)
        {
            setup.DoRepeatedly((i, j) => value());
            return setup;
        }
    }
}
