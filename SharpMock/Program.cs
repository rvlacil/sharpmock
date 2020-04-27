using System;
using System.Threading.Tasks;
using SharpMock.Http;
using SharpMock.Http.Matcher;
using SharpMock.Library.Engine.Setup;

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

                var mock = new HttpMock();

                var rqst1 = new HttpRequestMatcherBuilder().Method("GET").Path("/test").Build();
                var rqst2 = new HttpRequestMatcherBuilder().Method("POST").Path("/xyz").Build();
                var rspn1 = new HttpResponseMessageBuilder().Status(200).Body("test").Build();
                var rspn2 = new HttpResponseMessageBuilder().Status(200).Body("xyz").Build();

                mock.Setup(rqst1)
                    .ReturnAsync(rspn1)
                    .ReturnAsync(rspn1)
                    .ReturnAsync(rspn1)
                    .DoRepeatedly(async (rqst) =>
                    {
                        Console.WriteLine(rqst.ToString());
                        return rspn2;
                    });
                mock.Setup(rqst2).ReturnAsyncRepeatedly(rspn2);

                Console.WriteLine($"Listening on: {mock.Address}");

                Task.Delay(10000000).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + Environment.NewLine + e.Message);
            }
        }
    }
}
