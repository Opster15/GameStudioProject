using System.Collections.Generic;
using UnityEngine;
namespace GSP.Battle.Party
{
    public abstract class EnemyParty : ScriptableObject, IParty
    {
        public abstract List<GameCharacter> GetPartyMembers();
    }
}
