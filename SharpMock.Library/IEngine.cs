using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library
{
    public interface IEngine
    {
        void Verify();
        void Verify(StringBuilder b);
    }
}
