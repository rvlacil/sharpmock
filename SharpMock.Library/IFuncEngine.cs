
namespace SharpMock.Library
{
    public interface IFuncEngine<Ret> : IEngine
    {
        Ret Execute();
        IFuncSetup<Ret> Setup();
    }
    
    public interface IFuncEngine<T1, Ret> : IEngine
    {
        Ret Execute(T1 arg1);
        IFuncSetup<T1, Ret> Setup();
    }
    
    public interface IFuncEngine<T1, T2, Ret> : IEngine
    {
        Ret Execute(T1 arg1, T2 arg2);
        IFuncSetup<T1, T2, Ret> Setup();
    }
    
}
