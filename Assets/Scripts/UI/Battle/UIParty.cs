using System;
using GSP.Battle.Party;
using UnityEngine;
namespace GSP.UI.Battle
{
    public class UIParty : MonoBehaviour
    {
        private UIPartyMember[] m_partyMembers;

        private void Awake()
        {
            m_partyMembers = GetComponentsInChildren<UIPartyMember>();
        }

        public void SetParty(GameParty _party)
        {
            for(var i = 0; i < m_partyMembers.Length; i++)
            {
                var partyMember = m_partyMembers[i];
                if (i < _party.PartyMembers.Count)
                {
                    partyMember.gameObject.SetActive(true);
                    partyMember.SetTarget(_party.PartyMembers[i]);
                }
                else
                {
                    partyMember.SetTarget(null);
                    partyMember.gameObject.SetActive(false);
                }
            }
        }
    }
}
