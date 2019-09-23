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
    public class HeaderMatcherTest
    {
        [Test]
        public void WhenDoesMatch()
        {
            var sut = new HeaderMatcher("Header", "Value");
            var rqst = new HttpRequestMessageBuilder().AddHeader("Header", "Value").Build();

            Assert.IsTrue(sut.Match(rqst, null));
        }

        [Test]
        public void WhenHeaderMissing()
        {
            var sut = new HeaderMatcher("Header", "Value");
            var rqst = new HttpRequestMessageBuilder().Build();
            var listener = MockFactory.Create<IMatchResultListener>();

            listener.Add().Setup(listener.O.Append, M.Any("")).ReturnRepeatedly(new StringBuilder());

            Assert.IsFalse(sut.Match(rqst, listener.O));
        }

        [Test]
        public void WhenHeaderWithWrongValue()
        {
            var sut = new HeaderMatcher("Header", "Value");
            var rqst = new HttpRequestMessageBuilder().AddHeader("Header", "DifferentValue").Build();
            var listener = MockFactory.Create<IMatchResultListener>();

            listener.Add().Setup(listener.O.Append, M.Any("")).ReturnRepeatedly(new StringBuilder());

            Assert.IsFalse(sut.Match(rqst, listener.O));
        }
    }
}
