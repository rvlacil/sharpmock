using SharpMock.Library.Action;
using SharpMock.Library.Matchers;
using System;

namespace SharpMock.Library.Engine
{
    public abstract class FuncEngineBase<Ret> : AbstractEngine
    {
        public FuncEngineBase(string methodName) : base(methodName) { }

        public Ret Execute(Func<IMatcher, IMatchResultListener, bool> match, Func<IReturn<Ret>, Ret> response)
        {
            var action = FindAction(match);
            if (action == null) return default(Ret);
            return response((IReturn<Ret>)action);
        }
    }
}
