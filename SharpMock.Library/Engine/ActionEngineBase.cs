using SharpMock.Library.Action;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using System;
using System.Text;

namespace SharpMock.Library.Engine
{
    public abstract class ActionEngineBase : AbstractEngine
    {
        public ActionEngineBase(string methodName) : base(methodName) { }

        public void Execute(Func<IMatcher, StringBuilder, bool> match, Action<IAction> action)
        {
            var index = FindMatcher(match);
            Act(index, action);
            RetireIf(index);
        }

        private void Act(int index, Action<IAction> action)
        {
            ((IActionSetupAct)_activeSetups[index]).Act(action);
        }
    }
}
