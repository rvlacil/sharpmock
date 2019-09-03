using SharpMock.Library.Action;

namespace SharpMock.Library.Engine.Setup
{
    public interface IActionSetupAct : ISetup
    {
        void Act(System.Action<IAction> action);
    }
}
