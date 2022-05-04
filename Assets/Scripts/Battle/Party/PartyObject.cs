using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
namespace GSP.Battle.Party
{
    public abstract class PartyObject : ScriptableObject
    {
        [SerializeField] private EventReference m_musicPath;

        public FMOD.GUID MusicPath => m_musicPath.Guid;

        public abstract GameParty GetParty();
    }
}
