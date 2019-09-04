using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Engine.Setup
{
    public interface ISetupDo<TChild, TFunc> where TChild : ISetupDo<TChild, TFunc>
    {
        TChild Do(TFunc func, bool repeated);
    }
}
