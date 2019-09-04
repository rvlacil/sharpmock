using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Engine.Setup
{
    public static class SetupDoExtensions
    {
        public static TChild Do<TChild, TFunc>(this ISetupDo<TChild, TFunc> setup, TFunc func) where TChild : ISetupDo<TChild, TFunc>
        {
            return setup.Do(func, false);
        }

        public static TChild DoRepeatedly<TChild, TFunc>(this ISetupDo<TChild, TFunc> setup, TFunc func) where TChild : ISetupDo<TChild, TFunc>
        {
            return setup.Do(func, true);
        }
    }
}
