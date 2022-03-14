using GSP.Battle;
using GSP.UI.Battle;
using UnityEngine;
namespace GSP.FX
{
    public abstract class OnHealthChangedBase : CharacterTargetedElement
    {
        private int m_currentHP;

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);

            m_currentHP = _target.CurrentHP;
        }

        private void Update()
        {
            if (m_currentHP == m_target.CurrentHP) { return; }
            var difference = m_target.CurrentHP - m_currentHP;
            m_currentHP = m_target.CurrentHP;

            OnHealthChanged(difference);
        }

        protected abstract void OnHealthChanged(int _amount);
    }
}
