using GSP.Battle;
using GSP.UI.Battle;
using UnityEngine;
namespace GSP.World.Battle
{
    public class CharacterModel : CharacterTargetedElement
    {
        private GameObject m_model;
        
        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);

            var modelPrefab = _target.BaseCharacter.ModelPrefab;
            if (!modelPrefab) { return; }

            m_model = Instantiate(modelPrefab, transform.position + modelPrefab.transform.position, transform.rotation, transform);
        }

        private void Update()
        {
            if (m_target == null) { return; }

            if(m_target.CurrentHP <= 0)
            {
                Destroy(m_model);
            }
        }
    }
}