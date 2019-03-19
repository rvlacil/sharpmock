﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpMock.Library.Setup.Matchers
{
    public class MatcherComposite<T> : TypedMatcher<T>
    {
        private readonly List<ITypedMatcher<T>> _matchers;

        public MatcherComposite(List<ITypedMatcher<T>> matchers)
            : base(string.Join(", ", matchers.Select(i => i.ToString())))
        {
            _matchers = matchers;
        }

        public override bool Match(T arg, StringBuilder output)
        {
            bool ret = true;
            foreach (var matcher in _matchers)
            {
                ret = ret && matcher.Match(arg, output);
                if (ret == false) return false;
            }

            return ret;
        }
    }
}
