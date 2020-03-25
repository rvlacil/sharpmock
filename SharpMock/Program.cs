using SharpMock.Library;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using SharpMock.Factory;
using System;
using SharpMock.Http;
using System.Threading.Tasks;

namespace SharpMock
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                var mock = MockFactory.Create<ITest>();
                var i = mock.O;

                mock.Add().Setup(i.Do, M.Any(0)).
                    DoRepeatedly(o => Console.WriteLine($"args: {o}"));

                mock.Add().Setup(i.Do, M.Eq(4))
                    .Times(C.AtMost(1))
                    .DoRepeatedly(o => Console.WriteLine($"args: {o}"));

                i.Do(4);
                i.Do(4);
                i.Do(5);
                i.Do(6);

                mock.Verify();
                */

                var mock = new HttpProcessorMock();
                var i = mock.O;
                var server = new HttpServer(i);
                server.StartAsync().Wait();


                mock.Setup(M.Any<HttpRequestMessage>()).DoRepeatedly(async (rqst) => {
                    Console.WriteLine(rqst.ToString());
                    await Task.Delay(20000);
                    return new HttpResponseMessage() { Status = 500 };
                });


                Console.WriteLine($"Started Server, listing on: {server.Address}");


                Task.Delay(1000000000).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + Environment.NewLine + e.Message);
            }
        }
    }
}
