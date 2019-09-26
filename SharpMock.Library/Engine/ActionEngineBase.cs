using SharpMock.Library.Action;
using SharpMock.Library.Matchers;
using System;

namespace SharpMock.Library.Engine
{
    public abstract class ActionEngineBase : AbstractEngine
    {
        public ActionEngineBase(string methodName) : base(methodName) { }

        public void Execute(Func<IMatcher, IMatchResultListener, bool> match, Action<IAction> action)
        {
            var foundAction = FindAction(match);
            if (foundAction == null) return;
            action(foundAction);
        }
    }
}
