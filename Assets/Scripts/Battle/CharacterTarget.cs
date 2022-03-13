using System.Collections.Generic;
using System.Linq;
using GSP.Battle;
namespace GSP.UI.Battle
{
    public class CharacterTarget : CharacterTargetedElement
    {
        private List<CharacterTargetedElement> m_targetedElements;
        
        private void Awake()
        {
            // If the components list included this object, it would lead to an infinitely recurring loop. Which is bad, obviously.
            m_targetedElements = GetComponentsInChildren<CharacterTargetedElement>().ToList();
            if(m_targetedElements.Contains(this)) { m_targetedElements.Remove(this); }
        }

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);

            foreach (var targetedElement in m_targetedElements)
            {
                targetedElement.SetTarget(_target);
            }
        }
    }
}