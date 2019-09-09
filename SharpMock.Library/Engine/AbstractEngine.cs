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

        protected void RetireIf(ISetup setup)
        {
            if (!setup.IsSaturated()) return;

            _depletedSetups.Add(setup);
            _activeSetups.Remove(setup);
        }

        protected ISetup FindMatcher(Func<IMatcher, IMatchResultListener, bool> match)
        {
            if (_activeSetups.Count == 0) throw new ArgumentException("nothing set up");

            var listener = new MatchResultListener();
            listener.Append("Trying to find a match for: ").AppendLine(_methodName);

            var setup = FindAccrodingToArgs(listener, match);
            MarkCardinality(setup, listener);

            return setup;
        }

        private ISetup FindAccrodingToArgs(IMatchResultListener listener, Func<IMatcher, IMatchResultListener, bool> match)
        {
            int i = _activeSetups.Count - 1;

            using (var scope = listener.NewScope())
            {
                while (i >= 0)
                {
                    if (TryMatcher(_activeSetups[i].Matcher, listener, match))
                    {
                        scope.DropScope();
                        break;
                    }

                    --i;
                }
            }

            if (i < 0) throw new ArgumentException(listener.Message());
            return _activeSetups[i];
        }

        private bool TryMatcher(IMatcher matcher, IMatchResultListener listener, Func<IMatcher, IMatchResultListener, bool> match)
        {
            listener.Append("Setup with matcher:").AppendLine(matcher.ToPrint());
            using (var scope = listener.NewScope())
            {
                return match(matcher, listener);
            }
        }

        private void MarkCardinality(ISetup setup, IMatchResultListener listener)
        {
            using (var scope = listener.NewScope())
            {
                scope.Append($"Found Setup with matchers: ").Append(setup.Matcher.ToPrint()).AppendLine(": Failed on cardinality: ");

                using (var inner = listener.NewScope())
                {
                    if (!setup.Mark(listener))
                    {
                        throw new ArgumentException(listener.Message());
                    }
                }

                scope.DropScope();
            }
        }

        public bool Verify(IMatchResultListener output)
        {
            using (var scope = output.NewScope())
            {
                output.Append("For method: ").AppendLine(_methodName);
                var satisfied = true;
                foreach (var s in _activeSetups)
                {
                    using (var inner = output.NewScope())
                    {
                        inner.Append("with matchers: ").Append(s.Matcher.ToPrint()).AppendLine(": ");
                        var localSatisfied = s.IsSatisfied(output);
                        if (localSatisfied) inner.DropScope();
                        satisfied = localSatisfied && satisfied;
                    }
                }

                if (satisfied) scope.DropScope();
                return satisfied;
            }
        }
    }
}
