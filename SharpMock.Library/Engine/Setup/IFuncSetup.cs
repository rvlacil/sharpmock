using System;

namespace SharpMock.Library
{
    public interface IFuncSetup<Ret> : ISetup, ISetupMatch<IFuncSetup<Ret>>, ISetupCardinality<IFuncSetup<Ret>>, IFuncSetupAct<Ret>
    {
    	IFuncSetup<Ret> Do(Ret func);
    	IFuncSetup<Ret> Do(Func<Ret> func);
    }
    
    public interface IFuncSetup<T1, Ret> : ISetup, ISetupMatch<IFuncSetup<T1, Ret>, T1>, ISetupCardinality<IFuncSetup<T1, Ret>>, IFuncSetupAct<Ret>
    {
    	IFuncSetup<T1, Ret> Do(Ret func);
    	IFuncSetup<T1, Ret> Do(Func<T1, Ret> func);
    }
    
    public interface IFuncSetup<T1, T2, Ret> : ISetup, ISetupMatch<IFuncSetup<T1, T2, Ret>, T1, T2>, ISetupCardinality<IFuncSetup<T1, T2, Ret>>, IFuncSetupAct<Ret>
    {
    	IFuncSetup<T1, T2, Ret> Do(Ret func);
    	IFuncSetup<T1, T2, Ret> Do(Func<T1, T2, Ret> func);
    }
    
}


