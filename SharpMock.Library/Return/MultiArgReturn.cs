using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Return
{
    public class MultiArgReturn<Ret> : IReturn<Ret>
    {
        private readonly Func<Ret> _func;

        public MultiArgReturn(Func<Ret> func)
        {
            _func = func;
        }

        public Ret Respond(params object[] args)
        {
            return Respond();
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

        public Ret Respond(params object[] args)
        {
            return Respond((T) args[0]);
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

        public Ret Respond(params object[] args)
        {
            return Respond((T1) args[0], (T2) args[1]);
        }

        public Ret Respond(T1 arg1, T2 arg2)
        {
            return _func(arg1, arg2);
        }
    }
}
