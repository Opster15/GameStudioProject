using GSP.Battle;
using UnityEngine;
namespace GSP.UI.Battle
{
    public abstract class UICharacterTargetedElement : MonoBehaviour
    {
        /// <summary>
        /// The character to represent.
        /// </summary>
        protected GameCharacter m_target;

        /// <summary>
        /// Set the element's target character.
        /// </summary>
        /// <param name="_target">The character to represent.</param>
        public virtual void SetTarget(GameCharacter _target)
        {
            m_target = _target;
        }
    }
}
