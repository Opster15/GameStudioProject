using System.Collections.Generic;
namespace GSP.Battle.Party
{
    /// <summary>
    /// A general party.
    /// </summary>
    public class PlayerParty : IParty
    {
        /// <summary>
        /// The party's members.
        /// </summary>
        private List<GameCharacter> m_partyMembers;

        public List<GameCharacter> GetPartyMembers()
        {
            return m_partyMembers;
        }
    }
}
