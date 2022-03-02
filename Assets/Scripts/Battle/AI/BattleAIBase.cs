using GSP.Battle.Party;
using UnityEngine;
namespace GSP.Battle.AI
{
    /// <summary>
    /// A base class for AI used for non-playable characters during battle.
    /// </summary>
    public abstract class BattleAIBase : ScriptableObject
    {
        public abstract Action SelectAction(int _characterID, GameParty _party, GameParty _opposingParty);
    }
}
