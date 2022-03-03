using System.Collections.Generic;
using GSP.Battle.Controller;
using UnityEngine;
namespace GSP.Battle.Party
{
    /// <summary>
    /// The player's party
    /// </summary>
    [CreateAssetMenu(fileName = "New Player Party", menuName = "GSP/Player Party")]
    class PlayerParty : PartyObject
    {
        /// <summary>
        /// The party's members.
        /// </summary>
        [SerializeField] private List<Character> m_partyMembers;

        public override GameParty GetParty()
        {
            return new GameParty(m_partyMembers, FindObjectOfType<PlayerBattleController>());
        }
    }
}
