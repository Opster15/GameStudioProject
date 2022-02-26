using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace GSP.Battle.Party
{
    /// <summary>
    /// A pre-set enemy party.
    /// </summary>
    [CreateAssetMenu(fileName = "New Fixed Enemy Party", menuName = "GSP/Fixed Enemy Party")]
    public class FixedEnemyParty : EnemyPartyObject
    {
        /// <summary>
        /// The party's members.
        /// </summary>
        [SerializeField] private List<Character> m_partyMembers;
        
        public override Party GetParty()
        {
            return new Party(m_partyMembers);
        }
    }
}
