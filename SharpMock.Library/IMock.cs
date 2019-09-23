using SharpMock.Library.Engine;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SharpMock.Library
{
    public interface IMock<T>
    {
        Dictionary<MethodInfo, IEngine> Engines { get; }

        T O { get; }
    }
}
