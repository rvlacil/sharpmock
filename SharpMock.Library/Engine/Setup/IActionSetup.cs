namespace SharpMock.Library.Engine.Setup
{
    public interface IActionSetup :
        ISetup,
        ISetupMatch<IActionSetup>,
        ISetupCardinality<IActionSetup>,
        ISetupDo<IActionSetup, System.Action>,
        IActionSetupAct
    {
    }

    public interface IActionSetup<T1> :
        ISetup,
        ISetupMatch<IActionSetup<T1>, T1>,
        ISetupCardinality<IActionSetup<T1>>,
        ISetupDo<IActionSetup<T1>, System.Action<T1>>,
        IActionSetupAct
    {
    }

    public interface IActionSetup<T1, T2> :
        ISetup,
        ISetupMatch<IActionSetup<T1, T2>, T1, T2>,
        ISetupCardinality<IActionSetup<T1, T2>>,
        ISetupDo<IActionSetup<T1, T2>, System.Action<T1, T2>>,
        IActionSetupAct
    {
    }
}
