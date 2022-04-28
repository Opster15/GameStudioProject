using GSP.Battle.Party;
using UnityEngine;
using System.Collections.Generic;
namespace GSP.Battle.AI
{
    /// <summary>
    /// A base class for AI used for non-playable characters during battle.
    /// </summary>
    public abstract class BattleAIBase : ScriptableObject
    {
        /// <summary>
        /// Select a move, based on the current state of both parties.
        /// </summary>
        /// <param name="_characterID">The active character.</param>
        /// <param name="_party">The character's party.</param>
        /// <param name="_opposingParty">The opposing party.</param>
        /// <returns>The chosen move.</returns>
        public abstract GameMove SelectMove(int _characterID, GameParty _party, GameParty _opposingParty);

        /// <summary>
        /// Select a target, based on a list of valid options and the chosen move.
        /// </summary>
        /// <param name="_move">The chosen move.</param>
        /// <param name="_targets">All valid targets.</param>
        /// <returns>The chosen target.</returns>
        public abstract GameCharacter SelectTarget(Move _move, List<GameCharacter> _targets);
    }
}
