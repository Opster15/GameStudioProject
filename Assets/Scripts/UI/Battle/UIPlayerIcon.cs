using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSP.Battle;
using UnityEngine.UI;

namespace GSP.UI.Battle
{
    public class UIPlayerIcon : CharacterTargetedElement
    {

        public Sprite m_icon;
        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);
            if (m_target == null) { return; }
            SetIcon();
        }

        public void SetIcon()
        {
            m_icon = m_target.BaseCharacter.Icon;
            GetComponentInParent<Image>().sprite = m_icon;
        }
    }
}
