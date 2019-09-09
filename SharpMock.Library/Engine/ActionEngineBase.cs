using SharpMock.Library.Action;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using System;

namespace SharpMock.Library.Engine
{
    public abstract class ActionEngineBase : AbstractEngine
    {
        public ActionEngineBase(string methodName) : base(methodName) { }

        public void Execute(Func<IMatcher, IMatchResultListener, bool> match, Action<IAction> action)
        {
            var index = FindMatcher(match);
            Act(index, action);
            RetireIf(index);
        }

        private void Act(ISetup setup, Action<IAction> action)
        {
            ((IActionSetupAct)setup).Act(action);
        }
    }
}
