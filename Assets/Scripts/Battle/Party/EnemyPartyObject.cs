using System.Collections.Generic;
using UnityEngine;
namespace GSP.Battle.Party
{
    public abstract class EnemyPartyObject : ScriptableObject
    {
        public abstract GameParty GetParty();
    }
}
