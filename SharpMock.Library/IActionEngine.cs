using SharpMock.Library.Setup;
using SharpMock.Library.Setup.Matchers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharpMock.Library
{
    public interface IActionEngine : IEngine
    {
        void Execute();
        IActionSetup Setup();
    }

    public interface IActionEngine<T> : IEngine
    {
        void Execute(T arg);
        IActionSetup<T> Setup();
    }

    public interface IActionEngine<T1, T2> : IEngine
    {
        void Execute(T1 arg1, T2 arg2);
        IActionSetup<T1, T2> Setup();
    }
}
