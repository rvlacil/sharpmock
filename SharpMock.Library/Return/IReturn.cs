using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Setup.Return
{
    public interface IReturn<Ret>
    {
        Ret Respond(params object[] args);
    }
}
