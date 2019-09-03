using SharpMock.Library.Action;

namespace SharpMock.Library
{
    public interface IActionSetupAct : ISetup
    {
        void Act(System.Action<IAction> action);
    }
}
