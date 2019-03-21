using SharpMock.Library.Action;
using SharpMock.Library.Matchers;
using SharpMock.Library.Return;
using System;
using System.Text;

namespace SharpMock.Library
{
    public abstract class FuncEngineBase<Ret> : AbstractEngine
    {
        public FuncEngineBase(string methodName) : base(methodName) { }

        public Ret Execute(Func<IMatcher, StringBuilder, bool> match, Action<IAction> action, Func<IReturn<Ret>, Ret> response)
        {
            var index = FindMatcher(match);
            Act(_activeSetups[index], action);

            var ret = Return(index, response);
            DepleteIf(index);

            return ret;
        }

        private Ret Return(int index, Func<IReturn<Ret>, Ret> response)
        {
            return ((IFuncSetupBase<Ret>)_activeSetups[index]).Respond(response);
        }
    }
}
