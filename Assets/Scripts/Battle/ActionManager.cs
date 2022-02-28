using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GSP.Battle
{
    public class ActionManager : MonoBehaviour
    {
        private List<Action> m_actions;

        private void Awake()
        {
            m_actions = new List<Action>();
        }

        public void QueueAction(Action _action)
            => m_actions.Add(_action);

        public void ExecuteActions()
        {
            SortQueue();

            foreach(var action in m_actions)
            {
                Debug.Log("Action " + action.Move.Name + " Speed: " + action.Speed);
            }
            m_actions.Clear();
        }

        private void SortQueue()
            => m_actions = m_actions.OrderBy(p => p.Speed).ToList();
    }
}