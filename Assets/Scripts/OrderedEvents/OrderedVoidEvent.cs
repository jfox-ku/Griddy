using System;
using System.Collections.Generic;

namespace Features.OrderedEvents
{
    public class OrderedVoidEvent
    {
        private SortedDictionary<int, Action> _actions = new SortedDictionary<int, Action>();

        // Method to add a listener with an index (order)
        public void AddListener(int index, Action action)
        {
            if (!_actions.ContainsKey(index))
            {
                _actions.Add(index, action);
            }
            else
            {
                // Combine the existing action with the new one at the same index
                _actions[index] += action;
            }
        }

        // Method to remove a listener
        public void RemoveListener(int index, Action action)
        {
            if (_actions.ContainsKey(index))
            {
                _actions[index] -= action;

                // Remove the key if no actions are left
                if (_actions[index] == null)
                {
                    _actions.Remove(index);
                }
            }
        }

        // Method to invoke all actions in the order of their keys
        public void Invoke()
        {
            foreach (var action in _actions)
            {
                action.Value?.Invoke();
            }
        }
        
        public bool IsEmpty => _actions.Count == 0;

        public override string ToString()
        {
            string output = $"<color=#03fc13>OrderedVoidEvent with {_actions.Count} actions.</color>";
            foreach (var action in _actions)
            {
                output += $"<color=#03ebfc>\nIndex: {action.Key} Action: {action.Value.Method.Name}</color>";
            }

            return output;
        }
    }
}