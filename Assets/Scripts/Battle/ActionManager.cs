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

        /// <summary>
        /// Queue an action for execution in the turn order.
        /// </summary>
        /// <param name="_action"></param>
        public void QueueAction(Action _action)
            => m_actions.Add(_action);

        /// <summary>
        /// Execute all actions within the turn order.
        /// </summary>
        public void ExecuteActions()
        {
            SortQueue();

            foreach(var action in m_actions)
            {
                action.Execute();
            }
            m_actions.Clear();
        }
        //TODO: Make ExecuteActions a coroutine to allow for delay during execution for minigames & animations

        /// <summary>
        /// Sort the actions in the queue from lowest to highest speed.
        /// </summary>
        private void SortQueue()
            => m_actions = m_actions.OrderBy(p => p.Speed).ToList();
    }
}