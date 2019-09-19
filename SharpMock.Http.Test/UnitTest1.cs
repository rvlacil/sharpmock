using NUnit.Framework;
using SharpMock.Http;
using SharpMock.Http.Matcher;
using SharpMock.Library;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var mock = new HttpProcessorMock();
            var server = new HttpServer(mock.I);
            await server.StartAsync();

            mock.Add().Setup(mock.I.Reply, new MethodMatcher("GET")).ReturnAsync(new HttpResponseMessage { Status = 200, Body = "test" });

            var port = server.Address;

            Task.Delay(1000000).Wait();
        }
    }
}