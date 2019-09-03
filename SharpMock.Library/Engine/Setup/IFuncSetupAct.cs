using SharpMock.Library.Action;
using System;

namespace SharpMock.Library.Engine.Setup
{
    public interface IFuncSetupAct<Ret> : ISetup
    {
        Ret Act(Func<IReturn<Ret>, Ret> applier);
    }
}
