using Cinemachine;
using UnityEngine;
namespace GSP.Camera
{
    public class CameraShake : MonoBehaviour
    {
        public static CameraShake Instance { get; private set; }

        private CinemachineVirtualCamera cam;

        float shakeTimer;
        public void Awake()
        {
            Instance = this;
            cam = GetComponent<CinemachineVirtualCamera>();
        }

        public void ShakeCam(float intensity, float time)
        {
            CinemachineBasicMultiChannelPerlin perl = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            perl.m_AmplitudeGain = intensity;
            shakeTimer = time;
        }

        public void Update()
        {
            if (shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;
                if (shakeTimer <= 0f)
                {
                    CinemachineBasicMultiChannelPerlin perl = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                    perl.m_AmplitudeGain = 0f;
                }
            }
        }
    }
}
