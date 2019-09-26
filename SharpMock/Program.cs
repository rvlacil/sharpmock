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
                var i = mock.O;

                mock.Add().Setup(i.Do, M.Any(0)).
                    DoRepeatedly(o => Console.WriteLine($"new args: {o}"));
                mock.Add().Setup(i.Do, M.Any(0)).
                    Do(o => Console.WriteLine($"args: {o}")).RetireOnSaturation();

                mock.Add().Setup(i.Do, M.Eq(4)).Times(C.Times(0));

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
