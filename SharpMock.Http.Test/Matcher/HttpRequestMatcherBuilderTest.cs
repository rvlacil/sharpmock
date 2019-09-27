using NUnit.Framework;
using SharpMock.Factory;
using SharpMock.Http.Matcher;
using SharpMock.Library;
using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using System.Text;

namespace SharpMock.Http.Test.Matcher
{
    [TestFixture]
    public class HttpRequestMatcherBuilderTest
    {
        [Test]
        public void WhenMethodHeaderMatch()
        {
            var sut = new HttpRequestMatcherBuilder()
                .Header("Header", "Value")
                .Header("Header2", "Value2")
                .Method("POST")
                .Path("/test")
                .Build();
            var rqst = new HttpRequestMessageBuilder()
                .AddHeader("Header2", "Value2")
                .AddHeader("Header", "Value")
                .Method("POST")
                .Path("/test")
                .Build();

            Assert.IsTrue(sut.Match(rqst, null));
        }

        [Test]
        public void WhenMethodHeaderDoesNotMatch()
        {
            var sut = new HttpRequestMatcherBuilder().Header("Header", "Value").Method("POST").Build();
            var rqst = new HttpRequestMessageBuilder().AddHeader("Header", "Value").Method("GET").Build();

            var listener = MockFactory.Create<IMatchResultListener>();

            listener.Add().Setup(listener.O.Append, M.Any("")).ReturnRepeatedly(new StringBuilder());
            listener.Add().Setup(listener.O.NewScope).ReturnRepeatedly(null);

            Assert.IsFalse(sut.Match(rqst, listener.O));
        }
    }
}
