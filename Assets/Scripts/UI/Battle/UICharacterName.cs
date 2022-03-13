using System;
using GSP.Battle;
using TMPro;
using UnityEngine;
namespace GSP.UI.Battle
{
    public class UICharacterName : CharacterTargetedElement
    {
        private TMP_Text m_text;

        private void Awake()
        {
            m_text = GetComponentInChildren<TMP_Text>();
        }

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);
            if (m_target == null) { return; }
            
            UpdateText();
        }

        private void UpdateText()
        {
            m_text.text = m_target.Name;
        }
    }
}
