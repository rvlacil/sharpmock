using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http.Test
{
    [TestFixture]
    public class HttpRequestMessageTest
    {
        [Test]
        public void WhenBuildToStringIsCorrect()
        {
            var rqst = new HttpRequestMessageBuilder().Method("GET").Path("/test").AddHeader("Test", "test1").Body("testBody").Build();

            var expected =
@"GET /test
Test: test1

testBody";
            Assert.AreEqual(expected, rqst.ToString());
        }
    }
}
