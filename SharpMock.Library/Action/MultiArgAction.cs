using System;

namespace SharpMock.Library.Action
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
    
    public class MultiArgAction<T1> : IAction
    {
        private readonly System.Action<T1> _action;
    
        public MultiArgAction(System.Action<T1> action)
        {
            _action = action;
        }
    
        public void Execute(T1 arg1)
        {
            _action(arg1);
        }
    }
    
    public class MultiArgAction<T1, T2> : IAction
    {
        private readonly System.Action<T1, T2> _action;
    
        public MultiArgAction(System.Action<T1, T2> action)
        {
            _action = action;
        }
    
        public void Execute(T1 arg1, T2 arg2)
        {
            _action(arg1, arg2);
        }
    }
    
}
