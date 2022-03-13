using GSP.Battle;
using UnityEngine;
using UnityEngine.UI;
namespace GSP.UI.Battle
{
    public class UIHealthBar : CharacterTargetedElement
    {
        private Slider m_slider;

        [SerializeField] private Gradient m_barGradient;
        
        [SerializeField] private Graphic m_barGraphic;
        
        [SerializeField] private float m_tickdownSpeed;
        
        private int m_currentHP;

        private float m_timer;
        private float m_tickdownScale;

        public bool TakingDamage => m_currentHP != m_target.CurrentHP;
        
        private void Awake()
        {
            m_slider = GetComponentInChildren<Slider>();
        }

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);
            if (m_target == null) { return; }
            
            m_slider.maxValue = m_target.MaxHP;
            m_slider.value = m_target.CurrentHP;
            
            m_currentHP = m_target.CurrentHP;
            m_tickdownScale = 1.0f / m_target.MaxHP * m_tickdownSpeed;
            
            SetColor();
        }

        private void Update()
        {
            if (m_target == null) { return;}
            if(m_currentHP != m_target.CurrentHP)
            { 
                m_timer += Time.deltaTime;
                if (m_timer < m_tickdownScale) { return; }
                m_timer -= m_tickdownScale;

                m_currentHP += (int)Mathf.Sign(m_target.CurrentHP - m_currentHP);
                SetColor();
            }
            m_slider.value = m_currentHP;
        }

        private void SetColor()
        {
            var color = m_barGradient.Evaluate((float) m_currentHP / m_target.MaxHP);
            color.a = m_barGraphic.color.a;
            m_barGraphic.color = color;
        }
    }
}
