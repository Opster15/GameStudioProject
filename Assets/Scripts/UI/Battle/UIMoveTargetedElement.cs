using GSP.Battle;
using UnityEngine;
namespace GSP.UI.Battle
{
    public abstract class UIMoveTargetedElement : MonoBehaviour
    {
        /// <summary>
        /// The move to represent.
        /// </summary>
        protected GameMove m_target;
        
        /// <summary>
        /// The move's user.
        /// </summary>
        protected GameCharacter m_user;

        /// <summary>
        /// Set the element's target move.
        /// </summary>
        /// <param name="_target">The move to represent.</param>
        /// <param name="_user">The move's user.</param>
        public virtual void SetTarget(GameMove _target, GameCharacter _user)
        {
            m_target = _target;
            m_user = _user;
        }
    }
}
