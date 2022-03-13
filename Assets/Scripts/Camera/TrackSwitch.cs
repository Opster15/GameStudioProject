using Cinemachine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
namespace GSP.Camera
{
    public class TrackSwitch : MonoBehaviour
    {
        private CameraFocuses m_focuses;
    
        private CinemachineVirtualCamera m_cineCam;

        [EnumToggleButtons]
        public enum FocusState
        {
            All,
            Enemy,
            Player
        }

        /// <summary>
        /// The current focus state of the camera.
        /// </summary>
        [SerializeField] private FocusState m_state = FocusState.All;

        /// <summary>
        /// The duration it takes for the camera to move between focus state positions.
        /// </summary>
        [SerializeField] private float m_moveTime;

        private FocusState m_previousState;

        /// <summary>
        /// The current focus state of the camera.
        /// </summary>
        public FocusState CurrentState
        {
            get => m_state;
            set => m_state = value;
        }

        private void Awake()
        {
            m_focuses = FindObjectOfType<CameraFocuses>();
        
            m_cineCam = GetComponent<CinemachineVirtualCamera>();

            m_previousState = m_state;
        }

        public void Update()
        {
            if (m_state == m_previousState) { return; }
            var targetId = (int) m_state;
        
            m_cineCam.m_LookAt = m_focuses.GetFocusPoint(targetId);
            transform.DOMove(m_focuses.GetCameraPosition(targetId).position, m_moveTime);

            m_previousState = m_state;
        }
    }
}
