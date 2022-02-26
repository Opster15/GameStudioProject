using System.Collections.Generic;
using UnityEngine;
namespace GSP.Battle.Party
{
    /// <summary>
    /// A pre-set enemy party.
    /// </summary>
    [CreateAssetMenu(fileName = "New Fixed Enemy Party", menuName = "GSP/Fixed Enemy Party")]
    public class FixedEnemyParty : EnemyParty
    {
        [SerializeField] private List<Character> m_partyMembers;
        
        public override List<Character> GetPartyMembers()
        {
            return m_partyMembers;
        }
    }
}
