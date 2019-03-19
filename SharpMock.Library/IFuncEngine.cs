namespace SharpMock.Library
{
    public interface IFuncEngine<Ret> : IEngine
    {
        Ret Execute();
        IFuncSetup<Ret> Setup();
    }

    public interface IFuncEngine<T, Ret> : IEngine
    {
        Ret Execute(T arg);
        IFuncSetup<T, Ret> Setup();
    }

    public interface IFuncEngine<T1, T2, Ret> : IEngine
    {
        Ret Execute(T1 arg1, T2 arg2);
        IFuncSetup<T1, T2, Ret> Setup();
    }
}
