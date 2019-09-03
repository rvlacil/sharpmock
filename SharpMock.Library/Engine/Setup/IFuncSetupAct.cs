using SharpMock.Library.Action;
using System;

namespace SharpMock.Library
{
    public interface IFuncSetupAct<Ret> : ISetup
    {
        Ret Act(Func<IReturn<Ret>, Ret> applier);
    }
}
