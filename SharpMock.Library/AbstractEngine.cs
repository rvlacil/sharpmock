using SharpMock.Library.Action;
using SharpMock.Library.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library
{
    public abstract class AbstractEngine
    {
        protected readonly string _methodName;
        protected List<ISetupBase> _activeSetups;
        protected List<ISetupBase> _depletedSetups;

        public AbstractEngine(string methodName)
        {
            _methodName = methodName;
            _activeSetups = new List<ISetupBase>();
            _depletedSetups = new List<ISetupBase>();
        }

        protected void Act(ISetupBase setup, Action<IAction> action)
        {
            setup.Act(action);
        }

        protected void DepleteIf(int index)
        {
            if (!_activeSetups[index].IsDepleted()) return;

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

            return i;
        }

        public void Verify()
        {
            var output = new StringBuilder("Not satisfied cardinality of setups for method: ").AppendLine(_methodName);
            var satisfied = true;
            foreach (var s in _activeSetups)
            {
                var local = new StringBuilder();
                var ret = s.IsSatisfied(local);
                if (!ret)
                {
                    output.Append("with matchers: ").Append(s.Matcher.ToPrint()).Append(": ").Append(local);
                }

                satisfied = satisfied && ret;
            }
            if (!satisfied) throw new ArgumentException(output.ToString());
        }
    }
}
