using SharpMock.Library;
using SharpMock.Library.Cardinality;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using SharpMock.Factory;
using System;
using SharpMock.Http;
using SharpMock.Http.Matcher;
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
                var http = new HttpServer(mock.O);
                http.StartAsync();

                var rqst1 = new HttpRequestMatcherBuilder().Method("GET").Path("/test").Build();
                var rqst2 = new HttpRequestMatcherBuilder().Method("POST").Path("/prd").Build();
                var rspn1 = new HttpResponseMessageBuilder().Status(200).Body("test").Build();
                var rspn2 = new HttpResponseMessageBuilder().Status(200).Body("prd").Build();

                mock.Setup(rqst1)
                    .ReturnAsync(rspn1)
                    .ReturnAsync(rspn1)
                    .ReturnAsync(rspn1)
                    .ReturnAsyncRepeatedly(rspn2);
                mock.Setup(rqst2).ReturnAsyncRepeatedly(rspn2);

                Console.WriteLine($"Listening on: {http.Address}");

                Task.Delay(10000000).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + Environment.NewLine + e.Message);
            }
        }
    }
}
