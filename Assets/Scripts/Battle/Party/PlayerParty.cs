using System.Collections.Generic;
namespace GSP.Battle.Party
{
    /// <summary>
    /// The player's party.
    /// </summary>
    public class PlayerParty : IParty
    {
        /// <summary>
        /// The party's members.
        /// </summary>
        private List<Character> m_partyMembers;

        public List<Character> GetPartyMembers()
        {
            return m_partyMembers;
        }
    }
}
