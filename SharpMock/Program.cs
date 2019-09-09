using SharpMock.Library;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using SharpMock.Factory;
using System;

namespace SharpMock
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var mock = MockFactory.Create<ITest>();
                var i = mock.I;

                mock.Add().Setup(i.Do, M.Any(0)).
                    DoRepeatedly(o => Console.WriteLine($"args: {o}"));

                mock.Add().Setup(i.Do, M.Eq(4)).Times(C.AtLeast(1)).
                    DoRepeatedly(o => Console.WriteLine($"args special: {o}"));

                i.Do(4);
                i.Do(5);
                i.Do(6);

                mock.Verify();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + Environment.NewLine + e.Message);
            }
        }
    }
}
