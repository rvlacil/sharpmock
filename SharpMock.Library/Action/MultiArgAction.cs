using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Action
{
    public class MultiArgAction : IAction
    {
        private readonly System.Action _action;

        public MultiArgAction(System.Action action)
        {
            _action = action;
        }

        public void Execute()
        {
            _action();
        }
    }

    public class MultiArgAction<T> : IAction
    {
        private readonly Action<T> _action;

        public MultiArgAction(Action<T> action)
        {
            _action = action;
        }

        public void Execute(T arg)
        {
            _action(arg);
        }
    }

    public class MultiArgAction<T1, T2> : IAction
    {
        private readonly Action<T1, T2> _action;

        public MultiArgAction(Action<T1, T2> action)
        {
            _action = action;
        }

        public void Execute(T1 arg1, T2 arg2)
        {
            _action(arg1, arg2);
        }
    }
}
