using SharpMock.Library.Cardinality;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpMock.Library.Action
{
    public class ActionContainer : IActionContainer
    {
        private readonly List<(IAction Action, bool IsRepeated)> _actions;

        public ActionContainer()
        {
            _actions = new List<(IAction Action, bool IsRepeated)>();
        }

        public void Add(IAction action)
        {
            _actions.Add((action, false));
        }

        public void AddRepeatedly(IAction action)
        {
            _actions.Add((action, true));
        }

        public bool IsSaturated()
        {
            return _actions.Count == 0;
        }

        public bool IsSatisfied(StringBuilder output)
        {
            if (_actions.Count == 0) return true;
            if (_actions[0].IsRepeated == false)
            {
                output.Append($"Action Implicit Cardinality: There is still {_actions.Count} action(s) to be processed");
                return false;
            }
            return true;
        }

        public bool Mark(StringBuilder output)
        {
            if (_actions.Count == 0)
            {
                output.Append($"Action Implicit Cardinality: There are no actions set up");
                return false;
            }
            return true;
        }

        public void Pop()
        {
            if (_actions.Count == 0) return;
            if (_actions[0].IsRepeated) return;
            _actions.RemoveAt(0);
        }

        public IAction Top()
        {
            if (_actions.Count == 0) throw new ArgumentException("No actions set up");
            return _actions[0].Action;
        }
    }
}
