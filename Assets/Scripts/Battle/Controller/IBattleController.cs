using GSP.Battle.Party;
namespace GSP.Battle.Controller
{
    /// <summary>
    /// A framework for methods of controlling which moves party members select in battle.
    /// </summary>
    public interface IBattleController
    {
        /// <summary>
        /// Set the party to control the actions of.
        /// </summary>
        /// <param name="_party">The party to control the actions of.</param>
        void SetParty(GameParty _party);
        
        /// <summary>
        /// Choose a party member to select the actions for.
        /// </summary>
        /// <param name="_partyMember">The index of the party member.</param>
        void SelectPartyMember(int _partyMember);
        
        /// <summary>
        /// Returns whether a move has been selected for the current party member.
        /// </summary>
        /// <returns>Whether a move has been selected.</returns>
        bool IsMoveChosen();

        /// <summary>
        /// Return the selected move.
        /// </summary>
        /// <returns>The selected move.</returns>
        Move GetChosenMove();
    }
}
