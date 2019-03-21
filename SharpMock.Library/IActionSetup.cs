
namespace SharpMock.Library
{
    public interface IActionSetup : IArgSetup<IActionSetup>
    {
    }
    
    public interface IActionSetup<T1> : IArgSetup<IActionSetup<T1>, T1>
    {
    }
    
    public interface IActionSetup<T1, T2> : IArgSetup<IActionSetup<T1, T2>, T1, T2>
    {
    }
    
}
