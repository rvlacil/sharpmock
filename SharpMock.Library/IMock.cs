using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SharpMock.Library
{
    public interface IMock<T>
    {
        Dictionary<MethodInfo, IEngine> Engines { get; }

        T I { get; }

        void Verify();
    }
}
