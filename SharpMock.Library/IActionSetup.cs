namespace SharpMock.Library
{
    public interface IActionSetup : IArgSetupBase<IActionSetup>
    {
    }

    public interface IActionSetup<T> : IArgSetupBase<IActionSetup<T>, T>
    {
    }

    public interface IActionSetup<T1, T2> : IArgSetupBase<IActionSetup<T1, T2>, T1, T2>
    {
    }
}
