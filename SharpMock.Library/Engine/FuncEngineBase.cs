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

        public Ret Execute(Func<IMatcher, IMatchResultListener, bool> match, Func<IReturn<Ret>, Ret> response)
        {
            var setup = FindMatcher(match);
            var ret = Act(setup, response);
            RetireIf(setup);

            return ret;
        }

        private Ret Act(ISetup setup, Func<IReturn<Ret>, Ret> response)
        {
            return ((IFuncSetupAct<Ret>)setup).Act(response);
        }
    }
}
