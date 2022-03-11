using System;
using GSP.Battle;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
namespace GSP.UI.Battle
{
    public class UIMoveText : UIMoveTargetedElement
    {
        [EnumToggleButtons]
        private enum Type
        {
            Name,
            Power,
            Speed
        }

        private TMP_Text m_text;

        [SerializeField] private Type m_type;
        
        [SerializeField] private string m_textFormat = "{0}";

        private void Awake()
        {
            m_text = GetComponent<TMP_Text>();
        }

        public override void SetTarget(Move _target, GameCharacter _user)
        {
            base.SetTarget(_target, _user);
            if (_target == null) { return; }

            var value = m_type switch
            {
                Type.Name => _target.Name,
                Type.Power => _target.CalculatePower(_user).ToString(),
                Type.Speed => _target.CalculateSpeed(_user).ToString(),
                _ => ""
            };

            m_text.text = string.Format(m_textFormat, value);
        }
    }
}
