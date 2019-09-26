using SharpMock.Library.Action;
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

        protected IAction FindAction(Func<IMatcher, IMatchResultListener, bool> match)
        {
            var listener = new MatchResultListener();
            listener.Append("Trying to find a match for: ").AppendLine(_methodName);

            if (_activeSetups.Count == 0)
            {
                listener.NewScope().AppendLine("Nothing setup up");
                throw new ArgumentException(listener.Message());
            }

            var setup = FindAccrodingToArgs(listener, match);
            var result = GetAction(setup, listener);
            RetireIf(setup);

            return result;
        }

        private void RetireIf(ISetup setup)
        {
            if (!setup.IsSaturated()) return;

            _depletedSetups.Add(setup);
            _activeSetups.Remove(setup);
        }

        private ISetup FindAccrodingToArgs(IMatchResultListener listener, Func<IMatcher, IMatchResultListener, bool> match)
        {
            using (var scope = listener.NewScope())
            {
                for (var i = _activeSetups.Count - 1; i >= 0; --i)
                {
                    if (TryMatcher(_activeSetups[i].Matcher, listener, match))
                    {
                        scope.DropScope();
                        return _activeSetups[i];
                    }
                }

                throw new ArgumentException(listener.Message());
            }
        }

        private bool TryMatcher(IMatcher matcher, IMatchResultListener listener, Func<IMatcher, IMatchResultListener, bool> match)
        {
            listener.Append("Setup: ").Append(_methodName).AppendLine(matcher.ToPrint());
            using (var scope = listener.NewScope())
            {
                return match(matcher, listener);
            }
        }

        private IAction GetAction(ISetup setup, IMatchResultListener listener)
        {
            using (var scope = listener.NewScope())
            {
                scope.Append($"Setup: ").Append(_methodName).Append(setup.Matcher.ToPrint()).AppendLine(": Failed on cardinality: ");

                using (var inner = listener.NewScope())
                {
                    if (!setup.Mark(listener))
                    {
                        throw new ArgumentException(listener.Message());
                    }
                }

                scope.DropScope();
            }

            return setup.ActionContainer.Pop();
        }

        public bool Verify(IMatchResultListener output)
        {
            using (var scope = output.NewScope())
            {
                output.Append("For method: ").AppendLine(_methodName);
                var satisfied = true;
                foreach (var s in _activeSetups)
                {
                    satisfied = VerifySingleSetup(s, output) && satisfied;
                }

                if (satisfied) scope.DropScope();
                return satisfied;
            }
        }

        private bool VerifySingleSetup(ISetup setup, IMatchResultListener output)
        {
            using (var outer = output.NewScope())
            {
                output.Append(_methodName).Append(setup.Matcher.ToPrint()).AppendLine(":");
                using (var inner = output.NewScope())
                {
                    if (setup.IsSatisfied(output))
                    {
                        outer.DropScope();
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
