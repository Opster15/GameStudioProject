using System;
using System.Collections.Generic;
using GSP.Battle;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GSP.UI.Battle
{
    public class UISelectedCharacterScale : UIResizingElement
    {
        [Flags] [EnumToggleButtons]
        private enum Mode
        {
            None  = 0,
            Selected = 1,
            HideOnTargeting = 2,
            Acting = 4
        }
        
        [SerializeField] private Mode m_mode;

        public override void SetTarget(GameCharacter _target)
        {
            if (m_target != null)
            {
                m_target.OnSelected -= OnCharacterSelected;
                m_target.OnTargeting -= OnCharacterTargeting;
                m_target.OnActing -= OnCharacterActing;
            }
            
            base.SetTarget(_target);
            if (_target == null) { return; }
            
            _target.OnSelected += OnCharacterSelected;
            m_target.OnTargeting += OnCharacterTargeting;
            _target.OnActing += OnCharacterActing;
        }

        private void OnCharacterSelected(bool _selected)
        {
            if (!m_mode.HasFlag(Mode.Selected)) { return; }
            SetScale(_selected);
        }

        private void OnCharacterTargeting(List<GameCharacter> _targetOptions)
        {
            if (!m_mode.HasFlag(Mode.HideOnTargeting)) { return; }
            SetScale(false);
        }

        private void OnCharacterActing(bool _acting)
        {
            if (!m_mode.HasFlag(Mode.Acting)) { return; }
            SetScale(_acting);
        }
    }
}
