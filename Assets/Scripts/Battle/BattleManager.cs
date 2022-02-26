using System;
using System.Collections;
using System.Collections.Generic;
using GSP.Battle.Party;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private EnemyPartyObject m_enemyParty;

    private void Start()
    {
        var party = m_enemyParty.GetParty();
        foreach (var partyMember in party.PartyMembers)
        {
            Debug.Log(partyMember.BaseCharacter.Name);
        }
    }
}
