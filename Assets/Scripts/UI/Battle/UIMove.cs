using System.Collections.Generic;
using System.Linq;
using GSP.Battle;
using UnityEngine;
namespace GSP.UI.Battle
{
    public class UIMove : UIMoveTargetedElement
    {
        private List<UIMoveTargetedElement> m_targetedElements;
        
        private void Awake()
        {
            // If the components list included this object, it would lead to an infinitely recurring loop. Which is bad, obviously.
            m_targetedElements = GetComponentsInChildren<UIMoveTargetedElement>().ToList();
            if(m_targetedElements.Contains(this)) { m_targetedElements.Remove(this); }
        }

        public override void SetTarget(GameMove _target, GameCharacter _user)
        {
            base.SetTarget(_target, _user);

            foreach (var targetedElement in m_targetedElements)
            {
                targetedElement.SetTarget(_target, _user);
            }
        }
    }
}
