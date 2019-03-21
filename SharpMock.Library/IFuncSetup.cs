using System;

namespace SharpMock.Library
{
    public interface IFuncSetup<Ret> : IArgSetup<IFuncSetup<Ret>>, IFuncSetupBase<Ret>
    {
    	IFuncSetup<Ret> Return(Ret func);
    	IFuncSetup<Ret> Return(Func<Ret> func);
    }
    
    public interface IFuncSetup<T1, Ret> : IArgSetup<IFuncSetup<T1, Ret>, T1>, IFuncSetupBase<Ret>
    {
    	IFuncSetup<T1, Ret> Return(Ret func);
    	IFuncSetup<T1, Ret> Return(Func<T1, Ret> func);
    }
    
    public interface IFuncSetup<T1, T2, Ret> : IArgSetup<IFuncSetup<T1, T2, Ret>, T1, T2>, IFuncSetupBase<Ret>
    {
    	IFuncSetup<T1, T2, Ret> Return(Ret func);
    	IFuncSetup<T1, T2, Ret> Return(Func<T1, T2, Ret> func);
    }
    
}


