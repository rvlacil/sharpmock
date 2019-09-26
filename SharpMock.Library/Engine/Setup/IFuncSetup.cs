using System;

namespace SharpMock.Library.Engine.Setup
{
    public interface IFuncSetup<Ret> : 
        ISetup,
        ISetupMatch<IFuncSetup<Ret>>,
        ISetupCardinality<IFuncSetup<Ret>>,
        ISetupDo<IFuncSetup<Ret>, Func<Ret>>
    {
    }

    public interface IFuncSetup<T1, Ret> : 
        ISetup,
        ISetupMatch<IFuncSetup<T1, Ret>, T1>,
        ISetupCardinality<IFuncSetup<T1, Ret>>,
        ISetupDo<IFuncSetup<T1, Ret>, Func<T1, Ret>>
    {
    }

    public interface IFuncSetup<T1, T2, Ret> :
        ISetup,
        ISetupMatch<IFuncSetup<T1, T2, Ret>, T1, T2>,
        ISetupCardinality<IFuncSetup<T1, T2, Ret>>,
        ISetupDo<IFuncSetup<T1, T2, Ret>, Func<T1, T2, Ret>>
    {
    }
}


