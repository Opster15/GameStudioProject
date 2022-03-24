using System;
using System.Collections.Generic;
using GSP.Battle;
using GSP.Battle.Party;
using GSP.UI.Battle;
using UnityEngine;
namespace GSP.World.Battle
{
    public class WorldParty : MonoBehaviour
    {
        private BattleManager m_battleManager;
        
        private List<CharacterTarget> m_partyMembers;
        
        [SerializeField] private int m_partyID;

        [SerializeField] private GameObject m_characterPrefab;

        [SerializeField] private Vector3 m_characterOffset;
        
        [SerializeField] private Vector2 m_characterSpreadOffset;
        [SerializeField] private float m_characterSpreadAngle;
        [SerializeField] private float m_partyAngleOffset;
        
        private void Awake()
        {
            m_battleManager = FindObjectOfType<BattleManager>();

            m_partyMembers = new List<CharacterTarget>();
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

            var partyOffset = transform.position - m_characterOffset * _party.PartyMembers.Count / 2;

            var partyAngle = m_partyAngleOffset * Mathf.Deg2Rad;
            var characterAngle = m_characterSpreadAngle / _party.PartyMembers.Count * Mathf.Deg2Rad;

            var flip = partyOffset.x > 0 ? 1 : -1;
            
            for (var i = 0; i < _party.PartyMembers.Count; i++)
            {
                var angleOffset = new Vector3(Mathf.Cos(partyAngle + characterAngle * i) * m_characterSpreadOffset.x, 0, Mathf.Sin(partyAngle + characterAngle * i) * m_characterSpreadOffset.y);
                
                var offset = partyOffset + angleOffset + m_characterOffset * i;
                var rotation = new Vector3(0, 90 * flip, 0);
                
                var partyMember = Instantiate(m_characterPrefab, offset, Quaternion.Euler(rotation), transform).GetComponent<CharacterTarget>();
                partyMember.SetTarget(_party.PartyMembers[i]);
                m_partyMembers.Add(partyMember);
            }
        }
    }
}
