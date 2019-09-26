using System;
using System.Collections.Generic;

namespace SharpMock.Library.Action
{
    public class ActionContainer : IActionContainer
    {
        private readonly List<(IAction Action, bool IsRepeated)> _actions;
        private readonly List<IAction> _used;

        public ActionContainer()
        {
            _actions = new List<(IAction Action, bool IsRepeated)>();
            _used = new List<IAction>();
        }

        public void Add(IAction action, bool repeated)
        {
            _actions.Add((action, repeated));
        }

        public bool IsSaturated()
        {
            return _actions.Count == 0;
        }

        public bool IsSatisfied(IMatchResultListener output)
        {
            if (_actions.Count == 0) return true;
            if (_actions[0].IsRepeated == false)
            {
                output.AppendLine("Action Implicit Cardinality:");
                output.NewScope();
                output.AppendLine($"Set up: {_actions.Count + _used.Count}");
                output.AppendLine($"Remaining: {_actions.Count}");
                return false;
            }
            return true;
        }

        public bool Mark(IMatchResultListener output)
        {
            if (_actions.Count == 0)
            {
                output.AppendLine("Action Implicit Cardinality:");
                output.NewScope();
                output.AppendLine($"Set up: {_actions.Count + _used.Count}");
                output.AppendLine($"Remaining: all processed");
                return false;
            }
            return true;
        }

        public IAction Pop()
        {
            var result = Top();

            if (_actions[0].IsRepeated) return result;
            _used.Add(_actions[0].Action);
            _actions.RemoveAt(0);

            return result;
        }

        private IAction Top()
        {
            if (_actions.Count == 0) throw new ArgumentException("No actions set up");
            return _actions[0].Action;
        }
    }
}
