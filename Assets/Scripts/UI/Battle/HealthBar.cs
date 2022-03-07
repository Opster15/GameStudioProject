using GSP.Battle;
using UnityEngine;
using UnityEngine.UI;
namespace GSP.UI.Battle
{
    public class HealthBar : CharacterTargetedUI
    {
        private Slider m_slider;

        private void Awake()
        {
            m_slider = GetComponentInChildren<Slider>();
        }

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);
            
            m_slider.maxValue = m_target.MaxHP;
            m_slider.value = m_target.CurrentHP;
        }

        private void Update()
        {
            if (m_target == null) { return; }
            m_slider.value = Mathf.Lerp(m_slider.value, m_target.CurrentHP, Time.deltaTime * 10f);
        }
    }
}
