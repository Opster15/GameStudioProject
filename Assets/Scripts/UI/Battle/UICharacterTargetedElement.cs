using GSP.Battle;
using UnityEngine;
namespace GSP.UI.Battle
{
    public abstract class UICharacterTargetedElement : MonoBehaviour
    {
        /// <summary>
        /// The character to represent the health of.
        /// </summary>
        protected GameCharacter m_target;

        /// <summary>
        /// Set the slider's target character.
        /// </summary>
        /// <param name="_target">The character to represent the health of.</param>
        public virtual void SetTarget(GameCharacter _target)
        {
            m_target = _target;
        }
    }
}
