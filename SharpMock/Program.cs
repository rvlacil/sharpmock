using SharpMock.Library;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Matchers;
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
                mock.Do().Setup(i.Call, M.Any(""), M.Eq(4)).Times(C.Once()).Action((x, y) => Console.WriteLine("Args: " + x + " " + y)).Return("test");
                mock.Do().Setup(i.OneArgA, M.Eq(4)).Times(C.Once()).Action((x) => Console.WriteLine("Args: " + x));

                mock.Verify();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
