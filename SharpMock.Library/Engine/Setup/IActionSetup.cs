
namespace SharpMock.Library
{
    public interface IActionSetup : ISetup, ISetupMatch<IActionSetup>, ISetupCardinality<IActionSetup>, IActionSetupAct
    {
        IActionSetup Do(System.Action action);
        IActionSetup DoRepeatedly(System.Action action);
    }
    
    public interface IActionSetup<T1> : ISetup, ISetupMatch<IActionSetup<T1>, T1>, ISetupCardinality<IActionSetup<T1>>, IActionSetupAct
    {
        IActionSetup<T1> Do(System.Action<T1> action);
        IActionSetup<T1> DoRepeatedly(System.Action<T1> action);
    }
    
    public interface IActionSetup<T1, T2> : ISetup, ISetupMatch<IActionSetup<T1, T2>, T1, T2>, ISetupCardinality<IActionSetup<T1, T2>>, IActionSetupAct
    {
        IActionSetup<T1, T2> Do(System.Action<T1, T2> action);
        IActionSetup<T1, T2> DoRepeatedly(System.Action<T1, T2> action);
    }
    
}
