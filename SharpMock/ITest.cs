using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock
{
    public interface ITest
    {
        void OneArgA(int i);
        string Call(string s, int i);
        string ZeroArgs();
        string OneArg(int i);
    }
}
