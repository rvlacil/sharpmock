using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library
{
    public interface IScope : IDisposable
    {
        void DropScope();
        StringBuilder Append(string message);
        StringBuilder AppendLine(string message);
    }

    public interface IMatchResultListener
    {
        IScope NewScope();
        string Message();
        StringBuilder Append(string message);
        StringBuilder AppendLine(string message);
    }
}
