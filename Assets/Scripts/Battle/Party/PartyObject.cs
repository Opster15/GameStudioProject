using System.Collections.Generic;
using UnityEngine;
namespace GSP.Battle.Party
{
    public abstract class PartyObject : ScriptableObject
    {
        public abstract GameParty GetParty();
    }
}
