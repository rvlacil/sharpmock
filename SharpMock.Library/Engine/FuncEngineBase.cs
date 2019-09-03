using SharpMock.Library.Action;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using System;
using System.Text;

namespace SharpMock.Library.Engine
{
    public abstract class FuncEngineBase<Ret> : AbstractEngine
    {
        public FuncEngineBase(string methodName) : base(methodName) { }

        public Ret Execute(Func<IMatcher, StringBuilder, bool> match, Func<IReturn<Ret>, Ret> response)
        {
            var index = FindMatcher(match);
            var ret = Act(index, response);
            RetireIf(index);

            return ret;
        }

        private Ret Act(int index, Func<IReturn<Ret>, Ret> response)
        {
            return ((IFuncSetupAct<Ret>)_activeSetups[index]).Act(response);
        }
    }
}
