using System;
using UnityEngine;
using GSP.Camera;

namespace GSP.Minigames
{
    /// <summary>
    /// A skeleton framework which provides basic functionality for minigames.
    /// </summary>
    public abstract class Minigame : MonoBehaviour
    {

        private InputManager m_inputManager;

        public GameObject m_tutorialObject;

        private CameraShake m_cameraShake;

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
        /// Value added to the TimeOutScore
        /// </summary>
        [SerializeField] protected float m_pointGain;

        /// <summary>
        /// Value Given to timeoutscore at start of minigame
        /// </summary>
        [SerializeField] protected float m_starting_points;
        /// <summary>
        /// Value taken from targets speed stat
        /// </summary>
        [SerializeField] protected float m_targetSpeed;
        /// <summary>
        /// Value taken from targets power stat
        /// </summary>
        [SerializeField] protected float m_targetPower;

        /// <summary>
        /// The current time spent in the minigame.
        /// </summary>
        public float m_timer;

        /// <summary>
        /// Whether the minigame is still running.
        /// </summary>
        private bool m_running;

        /// <summary>
        /// Whether the minigame is still running.
        /// </summary>
        public bool m_attract;

        /// <summary>
        /// The length of the minigame in seconds.
        /// A negative value gives infinite time.
        /// </summary>
        public float Length => m_length;

        /// <summary>
        /// Whether the minigame is still running.
        /// </summary>
        public bool Running => m_running;

        /// <summary>
        /// The current time spent in the minigame, from 0.0 to 1.0.
        /// </summary>
        public float PointGain => m_pointGain;
        /// <summary>
        /// The targeted enemies speed stat
        /// </summary>
        public float TargetSpeed => m_targetSpeed;
        /// <summary>
        /// The targeted enemies power stat
        /// </summary>
        public float TargetPower => m_targetPower;

        /// <summary>
        /// Value Given to timeoutscore at start of minigame
        /// </summary>
        public float StartingPoints => m_starting_points;

        /// <summary>
        /// Value added to the TimeOutScore
        /// </summary>
        public float TimeTaken => Mathf.Clamp(m_timer / m_length, 0.0f, 1.0f);

        protected virtual void Awake()
        {
            m_inputManager = GetComponent<InputManager>();
            m_cameraShake = FindObjectOfType<CameraShake>();
            m_timeOutScore = StartingPoints;
            m_running = false;

            if (m_attract)
            {
                m_running = true;
            }
        }

        protected virtual void Update()
        {
            if (m_inputManager.spacePress)
            {
                Destroy(m_tutorialObject);
                m_running = true;
            }

            // If the minigame is no longer running, or if it has infinite time.
            if (!m_running || m_length < 0.0f) { return; }
        
            m_timer += Time.deltaTime;
            if (m_timer >= m_length)
            {
                Finish(m_timeOutScore);
                m_running = false;
                Destroy(gameObject);
            }
        }

        public virtual void ChangeScore()
        {
            m_timeOutScore += m_pointGain;
            m_timeOutScore = Mathf.Round(m_timeOutScore * 100f) / 100;

            if(m_pointGain < 0)
            {
                m_cameraShake.ShakeCam(1f, Mathf.Lerp(0.1f, 0.2f, 2));
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
