using System;
using System.Collections.Generic;

namespace Features.OrderedEvents
{
    public class OrderedEvent<T>
    {
        private SortedDictionary<int, Action<T>> _actions = new SortedDictionary<int, Action<T>>();

        // Method to add a listener with an index (order)
        public void AddListener(int index, Action<T> action)
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
        public void RemoveListener(int index, Action<T> action)
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
        public void Invoke(T param)
        {
            foreach (var action in _actions)
            {
                action.Value?.Invoke(param);
            }
        }
        
        public bool IsEmpty => _actions.Count == 0;

        public override string ToString()
        {
            string output = $"<color=#03fc13>OrderedEvent with {_actions.Count} actions.</color>";
            foreach (var action in _actions)
            {
                output += $"<color=#03ebfc>\nIndex: {action.Key} Action: {action.Value.Method.Name}</color>";
            }

            return output;
        }
    }
}