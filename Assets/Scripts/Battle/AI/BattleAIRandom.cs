using GSP.Battle.Party;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
namespace GSP.Battle.AI
{
    /// <summary>
    /// An AI which chooses a random move and selects a random target(s).
    /// </summary>
    [CreateAssetMenu(fileName = "Random", menuName = "GSP/AI/Battle AI Random")]
    public class BattleAIRandom : BattleAIBase
    {
        public override GameMove SelectMove(int _characterID, GameParty _party, GameParty _opposingParty)
        {
            var character = _party.PartyMembers[_characterID];
            var usableMoves = character.Moveset.Where(move => move.IsUsable).ToArray();
            
            return usableMoves[Random.Range(0, usableMoves.Length)];
        }

        public override GameCharacter SelectTarget(Move _move, List<GameCharacter> _targets)
        {
            return _targets[Random.Range(0, _targets.Count)];
        }
    }
}
