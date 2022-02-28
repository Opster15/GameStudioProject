using GSP.Battle.Party;
using UnityEngine;
namespace GSP.Battle.AI
{
    public abstract class BattleAIBase : ScriptableObject
    {
        public abstract Action SelectAction(int _characterID, GameParty _party, GameParty _opposingParty);
    }
}
