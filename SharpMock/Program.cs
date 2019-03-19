using SharpMock.Library;
using SharpMock.Library.Setup.Cardinality;
using SharpMock.Library.Setup.Matchers;
using System;

namespace SharpMock
{
    class Program
    {
        delegate void Test<T>(T v, int a);
        static void Main(string[] args)
        {
            try
            {
                var mock = new MockTest();
                var i = mock.I;
                mock.Do().SetupM<string, int, string>(i.Call, M._, 4).Times(C.Once()).Return("test");

                mock.Verify();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
