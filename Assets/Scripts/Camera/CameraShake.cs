using Cinemachine;
using UnityEngine;
namespace GSP.Camera
{
    public class CameraShake : MonoBehaviour
    {
        private CinemachineVirtualCamera m_cam;
        private CinemachineBasicMultiChannelPerlin m_perl;

        [SerializeField] private float m_maxIntensity;

        private float m_amplitude;
        private float m_shakeDuration;

        private float m_shakeTimer;

        public void Awake()
        {
            m_cam = GetComponent<CinemachineVirtualCamera>();
            m_perl = m_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void ShakeCam(float _intensity, float _time)
        {
            m_amplitude = Mathf.Min(m_amplitude + _intensity, m_maxIntensity);
            m_perl.m_AmplitudeGain = m_amplitude;

            if (m_shakeTimer < _time)
            {
                m_shakeTimer = _time;
                m_shakeDuration = _time;
            }
        }

        public void Update()
        {
            if (m_shakeTimer > 0)
            {
                m_shakeTimer -= Time.deltaTime;
                m_perl.m_AmplitudeGain = Mathf.Lerp(0, m_amplitude, m_shakeTimer / m_shakeDuration);
                if (m_shakeTimer <= 0f)
                {
                    m_perl.m_AmplitudeGain = 0f;
                }
            }
        }
    }
}
