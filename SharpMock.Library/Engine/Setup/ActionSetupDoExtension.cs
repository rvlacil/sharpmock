using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Engine.Setup
{
    public static class ActionSetupDoExtension
    {
        public static IActionSetup<T1> Do<T1>(this IActionSetup<T1> setup, System.Action value)
        {
            setup.Do((i) => value());
            return setup;
        }

        public static IActionSetup<T1, T2> Do<T1, T2>(this IActionSetup<T1, T2> setup, System.Action value)
        {
            setup.Do((i, j) => value());
            return setup;
        }

        public static IActionSetup<T1> DoRepeatedly<T1>(this IActionSetup<T1> setup, System.Action value)
        {
            setup.DoRepeatedly((i) => value());
            return setup;
        }

        public static IActionSetup<T1, T2> DoRepeatedly<T1, T2>(this IActionSetup<T1, T2> setup, System.Action value)
        {
            setup.DoRepeatedly((i, j) => value());
            return setup;
        }


        public static IActionSetup Throws(this IActionSetup setup, Exception e)
        {
            setup.Do(() => throw e);
            return setup;
        }

        public static IActionSetup<T1> Throws<T1>(this IActionSetup<T1> setup, Exception e)
        {
            setup.Do((i) => throw e);
            return setup;
        }

        public static IActionSetup<T1, T2> Throws<T1, T2>(this IActionSetup<T1, T2> setup, Exception e)
        {
            setup.Do((i, j) => throw e);
            return setup;
        }

        public static IActionSetup ThrowsRepeatedly(this IActionSetup setup, Exception e)
        {
            setup.DoRepeatedly(() => throw e);
            return setup;
        }

        public static IActionSetup<T1> ThrowsRepeatedly<T1>(this IActionSetup<T1> setup, Exception e)
        {
            setup.DoRepeatedly((i) => throw e);
            return setup;
        }

        public static IActionSetup<T1, T2> ThrowsRepeatedly<T1, T2>(this IActionSetup<T1, T2> setup, Exception e)
        {
            setup.DoRepeatedly((i, j) => throw e);
            return setup;
        }
    }
}
