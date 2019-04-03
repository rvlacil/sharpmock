using SharpMock.Library;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Matchers;
using System;

namespace SharpMock
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var mock = new MockTest();
                var i = mock.I;
                mock.Add().Setup(i.OneArgA, M.Any(0)).
                    Times(1).
                    Do(o => { });

                i.OneArgA(4);
                i.OneArgA(5);
                i.OneArgA(6);

                mock.Verify();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
