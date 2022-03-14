using UnityEngine;
using GSP.Camera;
namespace GSP.FX
{
    public class OnHealthChangedShakeScreen : OnHealthChangedBase
    {
        private CameraShake m_cameraShake;

        [SerializeField] private float m_intensityModifier;
        [SerializeField] private float m_minShakeTime, m_maxShakeTime;

        private void Awake()
        {
            m_cameraShake = FindObjectOfType<CameraShake>();
        }

        protected override void OnHealthChanged(int _amount)
        {
            if(_amount > 0) { return; }
            var amount = (float) -_amount / m_target.MaxHP;
            m_cameraShake.ShakeCam(amount * m_intensityModifier, Mathf.Lerp(m_minShakeTime, m_maxShakeTime, amount));
        }
    }
}
