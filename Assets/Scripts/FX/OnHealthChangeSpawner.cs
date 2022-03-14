using GSP.Battle;
using GSP.UI.Battle;
using UnityEngine;

namespace GSP
{
    public class OnHealthChangeSpawner : CharacterTargetedElement
    {
        [SerializeField] private GameObject m_spawnPrefab;
        
        private int m_currentHP;

        public override void SetTarget(GameCharacter _target)
        {
            base.SetTarget(_target);

            m_currentHP = _target.CurrentHP;
        }

        private void Update()
        {
            if (m_currentHP == m_target.CurrentHP) { return; }
            var difference = m_currentHP - m_target.CurrentHP;
            m_currentHP = m_target.CurrentHP;
            
            var spawnObject = Instantiate(m_spawnPrefab, transform.position + m_spawnPrefab.transform.position, Quaternion.identity);
            var spawn = spawnObject.GetComponent<ISpawnedOnHealthChange>();
            spawn?.SetAmount(difference);
        }
    }
}
