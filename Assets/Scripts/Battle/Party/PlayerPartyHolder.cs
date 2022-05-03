using UnityEngine;

namespace GSP.Battle.Party
{
    public class PlayerPartyHolder : MonoBehaviour
    {
        private PlayerPartyHolder m_instance;

        [SerializeField] private PartyObject m_party;

        private GameParty m_gameParty;

        private void Awake()
        {
           if(m_instance != null) { m_instance = this; }
           else { Destroy(gameObject); }

            DontDestroyOnLoad(gameObject);
        }

        public GameParty GetParty()
        {
            if(m_gameParty == null) { m_gameParty = m_party.GetParty(); }
            return m_gameParty;
        }
    }
}
