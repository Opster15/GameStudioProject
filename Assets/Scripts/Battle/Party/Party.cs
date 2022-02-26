using System;
using System.Collections.Generic;
using System.Linq;
namespace GSP.Battle.Party
{
    /// <summary>
    /// A party of characters who can enter combat.
    /// </summary>
    [Serializable]
    public class Party
    {
        /// <summary>
        /// The party's members.
        /// </summary>
        private List<GameCharacter> m_partyMembers;

        /// <summary>
        /// The party's members.
        /// </summary>
        public List<GameCharacter> PartyMembers => m_partyMembers;

        public Party(List<GameCharacter> _partyMembers)
        {
            m_partyMembers = _partyMembers;
        }

        public Party(List<Character> _partyMembers)
        {
            m_partyMembers = _partyMembers.Select(partyMember => new GameCharacter(partyMember)).ToList();
        }
    }
}
