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
        /// Set the opponent's party.
        /// </summary>
        /// <param name="_opposingParty"></param>
        void SetOpposingParty(GameParty _opposingParty);
        
        /// <summary>
        /// Choose a party member to select the actions for.
        /// </summary>
        /// <param name="_partyMember">The index of the party member.</param>
        void SelectPartyMember(int _partyMember);

        /// <summary>
        /// Return the selected move.
        /// </summary>
        /// <returns>The selected move, as an action.</returns>
        Action GetChosenAction();
    }
}
