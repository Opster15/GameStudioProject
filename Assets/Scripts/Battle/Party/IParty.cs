using System.Collections.Generic;
namespace GSP.Battle.Party
{
    /// <summary>
    /// A party of characters who can enter combat.
    /// </summary>
    public interface IParty
    {
        /// <summary>
        /// Get all members of the party.
        /// </summary>
        /// <returns>The party's members.</returns>
        List<Character> GetPartyMembers();
    }
}
