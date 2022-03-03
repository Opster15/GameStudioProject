using System.Collections.Generic;
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
        /// <param name="_opposingParty">The controlled party's opponents.</param>
        void SetOpposingParty(GameParty _opposingParty);
        
        /// <summary>
        /// Choose a party member to select the actions for.
        /// </summary>
        /// <param name="_partyMember">The index of the party member.</param>
        void SetPartyMember(int _partyMember);

        /// <summary>
        /// Set the targets to choose from.
        /// </summary>
        /// <param name="_targets">A list of valid targets to select from.</param>
        void SetTargets(List<GameCharacter> _targets);

        /// <summary>
        /// Returns the currently selected move, if any.
        /// </summary>
        /// <returns>The currently selected move.</returns>
        Move GetSelectedMove();

        /// <summary>
        /// Returns the currently selected target, if any.
        /// </summary>
        /// <returns>The currently selected target.</returns>
        GameCharacter GetSelectedTarget();
    }
}
