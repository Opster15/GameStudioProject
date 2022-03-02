using GSP.Battle.Party;
using UnityEngine;
namespace GSP.Battle.AI
{
    /// <summary>
    /// An AI which chooses a random move and selects a random target(s).
    /// </summary>
    [CreateAssetMenu(fileName = "Random", menuName = "GSP/AI/Battle AI Random")]
    public class BattleAIRandom : BattleAIBase
    {
        public override Action SelectAction(int _characterID, GameParty _party, GameParty _opposingParty)
        {
            var character = _party.PartyMembers[_characterID];
            
            // Choose a random move and a random enemy to target.
            var move = character.Moveset[Random.Range(0, character.Moveset.Count)];
            var target = _opposingParty.PartyMembers[Random.Range(0, _opposingParty.PartyMembers.Count)];

            return new Action(move, _party.PartyMembers[_characterID], target);
        }
    }
}
