using SharpMock.Library.Setup.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup
{
    public interface IActionSetup : IArgSetupBase<IActionSetup>
    {
    }

    public interface IActionSetup<T> : IArgSetupBase<IActionSetup<T>, T>
    {
    }

    public interface IActionSetup<T1, T2> : IArgSetupBase<IActionSetup<T1, T2>, T1, T2>
    {
    }
}
