using System;
using GSP.Battle;
using GSP.Battle.Party;
using UnityEngine;
namespace GSP.UI.Battle
{
    public class UIParty : MonoBehaviour
    {
        private BattleManager m_battleManager;
        
        private CharacterTarget[] m_partyMembers;
        
        [SerializeField] private int m_partyID;

        private void Awake()
        {
            m_battleManager = FindObjectOfType<BattleManager>();
            
            m_partyMembers = GetComponentsInChildren<CharacterTarget>();
        }

        private void OnEnable()
        {
            m_battleManager.OnEnableParty += SetParty;
        }

        private void OnDisable()
        {
            m_battleManager.OnEnableParty -= SetParty;
        }

        private void SetParty(int _partyID, GameParty _party)
        {
            if (m_partyID != _partyID) { return; }
            
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
