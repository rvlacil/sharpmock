using SharpMock.Library.Return;
using System;

namespace SharpMock.Library
{
    public interface IFuncSetupBase<Ret> : ISetupBase
    {
        Ret Respond(Func<IReturn<Ret>, Ret> applier);
    }

    public interface IFuncSetup<Ret> : IArgSetupBase<IFuncSetup<Ret>>, IFuncSetupBase<Ret>
    {
        IFuncSetup<Ret> Return(Ret func);
        IFuncSetup<Ret> Return(Func<Ret> func);
    }

    public interface IFuncSetup<T, Ret> : IArgSetupBase<IFuncSetup<T, Ret>, T>, IFuncSetupBase<Ret>
    {
        IFuncSetup<T, Ret> Return(Ret func);
        IFuncSetup<T, Ret> Return(Func<T, Ret> func);
    }

    public interface IFuncSetup<T1, T2, Ret> : IArgSetupBase<IFuncSetup<T1, T2, Ret>, T1, T2>, IFuncSetupBase<Ret>
    {
        IFuncSetup<T1, T2, Ret> Return(Ret func);
        IFuncSetup<T1, T2, Ret> Return(Func<T1, T2, Ret> func);
    }
}
