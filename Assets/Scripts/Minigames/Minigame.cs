using System;
using UnityEngine;
namespace GSP.Minigames
{
    /// <summary>
    /// A skeleton framework which provides basic functionality for minigames.
    /// </summary>
    public abstract class Minigame : MonoBehaviour
    {
        /// <summary>
        /// Called once the minigame is finished, providing the player's score from 0.0 to 1.0.
        /// </summary>
        public Action<float> OnFinished;
    
        /// <summary>
        /// The length of the minigame in seconds.
        /// A negative value gives infinite time.
        /// </summary>
        [SerializeField] protected float m_length = 5.0f;
    
        /// <summary>
        /// The default score to use when the minigame runs out of time.
        /// </summary>
        [SerializeField] protected float m_timeOutScore = 0.0f;

        /// <summary>
        /// The current time spent in the minigame.
        /// </summary>
        private float m_timer;

        /// <summary>
        /// The length of the minigame in seconds.
        /// A negative value gives infinite time.
        /// </summary>
        public float Length => m_length;

        /// <summary>
        /// The current time spent in the minigame, from 0.0 to 1.0.
        /// </summary>
        public float TimeTaken => Mathf.Clamp(m_timer / m_length, 0.0f, 1.0f);

        private void Update()
        {
            if (m_length < 0.0f) { return; }
        
            m_timer += Time.deltaTime;
            if (m_timer >= m_length)
            {
                Finish(m_timeOutScore);
            }
        }

        /// <summary>
        /// Finish the minigame and return the given score.
        /// </summary>
        /// <param name="_score">The player's score, from 0.0 to 1.0.</param>
        protected void Finish(float _score)
            => OnFinished?.Invoke(Mathf.Clamp(_score, 0.0f, 1.0f));
    }
}
