using System;
using GSP.Battle;
using TMPro;
using UnityEngine;
namespace GSP.UI.Battle
{
    public class UIHealthCounter : UICharacterTargetedElement
    {
        private TMP_Text m_text;

        [SerializeField] private string m_healthText;
        
        [SerializeField] private float m_tickdownSpeed;

        private int m_maxHP;
        private int m_currentHP;

        private float m_timer;
        private float m_tickdownScale;

        private void Awake()
        {
            m_text = GetComponentInChildren<TMP_Text>();
        }

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);
            if (m_target == null) { return; }
            
            m_maxHP = m_target.MaxHP;
            m_currentHP = m_target.CurrentHP;
            m_tickdownScale = 1.0f / m_maxHP * m_tickdownSpeed;
            UpdateText();
        }

        private void Update()
        {
            if (m_target == null || m_currentHP == m_target.CurrentHP) { return; }

            m_timer += Time.deltaTime;
            if (m_timer < m_tickdownScale) { return; }
            m_timer -= m_tickdownScale;
            
            m_currentHP += (int) Mathf.Sign(m_target.CurrentHP - m_currentHP);
            UpdateText();
        }

        private void UpdateText()
        {
            m_text.text = String.Format(m_healthText, m_currentHP, m_maxHP);
        }
    }
}
