using System;

namespace SharpMock.Library.Return
{
    public class MultiArgReturn<Ret> : IReturn<Ret>
    {
        private readonly Func<Ret> _func;

        public MultiArgReturn(Func<Ret> func)
        {
            _func = func;
        }

        public Ret Respond()
        {
            return _func();
        }
    }

    public class MultiArgReturn<T, Ret> : IReturn<Ret>
    {
        private readonly Func<T, Ret> _func;

        public MultiArgReturn(Func<T, Ret> func)
        {
            _func = func;
        }

        public Ret Respond(T arg)
        {
            return _func(arg);
        }
    }

    public class MultiArgReturn<T1, T2, Ret> : IReturn<Ret>
    {
        private readonly Func<T1, T2, Ret> _func;

        public MultiArgReturn(Func<T1, T2, Ret> func)
        {
            _func = func;
        }

        public Ret Respond(T1 arg1, T2 arg2)
        {
            return _func(arg1, arg2);
        }
    }
}
