using SharpMock.Library.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Http.Matcher
{
    public class HttpRequestMatcherBuilder
    {
        private readonly List<ITypedMatcher<HttpRequestMessage>> _matchers;

        public HttpRequestMatcherBuilder()
        {
            _matchers = new List<ITypedMatcher<HttpRequestMessage>>();
        }

        public HttpRequestMatcherBuilder Method(string method)
        {
            _matchers.Add(new MethodMatcher(method));
            return this;
        }

        public HttpRequestMatcherBuilder Header(string name, string value)
        {
            _matchers.Add(new HeaderMatcher(name, value));
            return this;
        }

        public HttpRequestMatcherBuilder Path(string path)
        {
            _matchers.Add(new PathMatcher(path));
            return this;
        }

        public ITypedMatcher<HttpRequestMessage> Build()
        {
            return new MatcherComposite<HttpRequestMessage>(_matchers);
        }
    }
}
