namespace SharpMock.Library
{
    public interface IActionEngine : IEngine
    {
        void Execute();
        IActionSetup Setup();
    }

    public interface IActionEngine<T> : IEngine
    {
        void Execute(T arg);
        IActionSetup<T> Setup();
    }

    public interface IActionEngine<T1, T2> : IEngine
    {
        void Execute(T1 arg1, T2 arg2);
        IActionSetup<T1, T2> Setup();
    }
}
