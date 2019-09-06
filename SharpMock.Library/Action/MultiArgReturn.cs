using System;

namespace SharpMock.Library.Action
{
    public class MultiArgReturn<Ret> : IReturn<Ret>
    {
        private readonly Func<Ret> _action;
    
        public MultiArgReturn(Func<Ret> action)
        {
            _action = action;
        }
    
        public Ret Respond()
        {
            return _action();
        }
    }
    
    public class MultiArgReturn<T1, Ret> : IReturn<Ret>
    {
        private readonly Func<T1, Ret> _action;
    
        public MultiArgReturn(Func<T1, Ret> action)
        {
            _action = action;
        }
    
        public Ret Respond(T1 arg1)
        {
            return _action(arg1);
        }
    }
    
    public class MultiArgReturn<T1, T2, Ret> : IReturn<Ret>
    {
        private readonly Func<T1, T2, Ret> _action;
    
        public MultiArgReturn(Func<T1, T2, Ret> action)
        {
            _action = action;
        }
    
        public Ret Respond(T1 arg1, T2 arg2)
        {
            return _action(arg1, arg2);
        }
    }
}
