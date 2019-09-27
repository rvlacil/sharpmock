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
    public class PathMatcherTest
    {
        [Test]
        public void WhenDoesNotMatch()
        {
            var sut = new PathMatcher("/test");
            var rqst = new HttpRequestMessageBuilder().Path("/test").Build();

            Assert.IsTrue(sut.Match(rqst, null));
        }

        [Test]
        public void WhenDoesMatch()
        {
            var sut = new MethodMatcher("test");
            var rqst = new HttpRequestMessageBuilder().Method("GET").Build();
            var listener = MockFactory.Create<IMatchResultListener>();

            var o = listener.O;
            listener.Add().Setup(o.Append, M.Any("")).ReturnRepeatedly(new StringBuilder());

            var result = sut.Match(rqst, o);

            Assert.IsFalse(result);

            listener.Verify();
        }
    }
}
