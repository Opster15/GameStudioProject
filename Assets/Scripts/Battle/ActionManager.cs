using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GSP.Minigames;
using UnityEngine;

namespace GSP.Battle
{
    public class ActionManager : MonoBehaviour
    {
        /// <summary>
        /// All currently queued actions.
        /// </summary>
        private List<Action> m_actions;

        /// <summary>
        /// The score of the current action's minigame.
        /// </summary>
        private float m_currentMinigameScore;
        
        /// <summary>
        /// Whether the current action's minigame has finished play.
        /// </summary>
        private bool m_isCurrentMinigameFinished;

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
        public IEnumerator ExecuteActions()
        {
            SortQueue();
            foreach (var action in m_actions)
            {
                yield return ExecuteAction(action);
            }
            m_actions.Clear();
        }

        /// <summary>
        /// Execute an action, waiting until its current minigame is finished if necessary.
        /// </summary>
        /// <param name="_action">The action to execute.</param>
        private IEnumerator ExecuteAction(Action _action)
        {
            if (_action.User.IsDead) { yield break; }
            m_currentMinigameScore = 1.0f;
            
            _action.User.SelectMove(null);
            _action.User.SetActing(true);
            
            // Only continue if the move user is a player and there's a valid minigame prefab assigned.
            if (!_action.SkipsMinigame && _action.Move.MinigamePrefab)
            {
                var minigamePrefab = _action.Move.MinigamePrefab;
                var minigame = Instantiate(minigamePrefab).GetComponent<Minigame>();

                if (minigame)
                {
                    m_isCurrentMinigameFinished = false;

                    minigame.OnFinished += OnMinigameFinished;
                    yield return new WaitUntil(() => m_isCurrentMinigameFinished);
                    minigame.OnFinished -= OnMinigameFinished;
                }
            }

            _action.Execute(m_currentMinigameScore);
            _action.User.SetActing(false);
        }

        /// <summary>
        /// Retrieve the results of the most recently played minigame.
        /// </summary>
        /// <param name="_score">The score of the most recent minigame, from 0 to 1.</param>
        void OnMinigameFinished(float _score)
        {
            m_currentMinigameScore = _score;
            m_isCurrentMinigameFinished = true;
        }

        /// <summary>
        /// Sort the actions in the queue from lowest to highest speed.
        /// </summary>
        private void SortQueue()
        {
            // Shuffle the list beforehand, to account for speed ties.
            for (var i = 0; i < m_actions.Count; i++)
            {
                var j = Random.Range(0, m_actions.Count - i);
                (m_actions[j], m_actions[i]) = (m_actions[i], m_actions[j]);
            }
            m_actions = m_actions.OrderBy(p => p.Speed).ToList();
        }
    }
}