using SharpMock.Library.Return;
using System;

namespace SharpMock.Library
{
    public interface IFuncSetupBase<Ret> : ISetup
    {
        Ret Respond(Func<IReturn<Ret>, Ret> applier);
    }
}
