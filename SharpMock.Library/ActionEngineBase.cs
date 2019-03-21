using SharpMock.Library.Action;
using SharpMock.Library.Matchers;
using System;
using System.Text;

namespace SharpMock.Library
{
    public class ActionEngineBase : AbstractEngine
    {
        public ActionEngineBase(string methodName)
            : base(methodName)
        {
        }

        public void Execute(Func<IMatcher, StringBuilder, bool> match, Action<IAction> action)
        {
            var index = FindMatcher(match);
            Act(_activeSetups[index], action);
            DepleteIf(index);
        }
    }
}
