using SharpMock.Library.Engine.Setup;
using SharpMock.Library.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Engine
{
    public abstract class AbstractEngine
    {
        protected readonly string _methodName;
        protected List<ISetup> _activeSetups;
        protected List<ISetup> _depletedSetups;

        public AbstractEngine(string methodName)
        {
            _methodName = methodName;
            _activeSetups = new List<ISetup>();
            _depletedSetups = new List<ISetup>();
        }

        protected void RetireIf(int index)
        {
            if (!_activeSetups[index].IsSaturated()) return;

            _depletedSetups.Add(_activeSetups[index]);
            _activeSetups.RemoveAt(index);
        }

        protected int FindMatcher(Func<IMatcher, StringBuilder, bool> match)
        {
            if (_activeSetups.Count == 0) throw new ArgumentException("nothing set up");

            int i = _activeSetups.Count - 1;
            int j = 1;
            var output = new StringBuilder("Trying to find a match for: ").AppendLine(_methodName);

            while (i >= 0)
            {
                var local = new StringBuilder();
                if (match(_activeSetups[i].Matcher, local)) break;

                output.Append("Setup").Append(j).Append(": matchers: ").AppendLine(_activeSetups[i].Matcher.ToPrint());
                output.Append("".PadLeft(4)).Append(local);

                --i;
                ++j;
            }

            if (i < 0)
            {
                throw new ArgumentException(output.ToString());
            }

            var cardinalityOutput = new StringBuilder();
            if (!_activeSetups[i].Mark(cardinalityOutput))
            {
                throw new ArgumentException($"Found match for: {_methodName}:{Environment.NewLine}Setup{j}: matchers: {_activeSetups[i].Matcher.ToPrint()}{Environment.NewLine}Failed on cardinality: {cardinalityOutput.ToString()}");
            }

            return i;
        }

        public bool Verify(StringBuilder output)
        {
            var methodOutput = new StringBuilder("For method: ").AppendLine(_methodName);
            var satisfied = true;
            foreach (var s in _activeSetups)
            {
                var local = new StringBuilder();
                var ret = s.IsSatisfied(local);
                if (!ret)
                {
                    methodOutput.Append("with matchers: ").Append(s.Matcher.ToPrint()).Append(": ").Append(local);
                    satisfied = false;
                }
            }

            if (!satisfied) output.Append(methodOutput);
            return satisfied;
        }
    }
}
