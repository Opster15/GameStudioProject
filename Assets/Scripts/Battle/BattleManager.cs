﻿using System.Collections;
using GSP.Battle.Party;
using UnityEngine;
namespace GSP.Battle
{
    public class BattleManager : MonoBehaviour
    {
        private ActionManager m_actionManager;

        private GameParty[] m_parties;

        //TODO: Create battle
        [SerializeField] private PartyObject m_A;
        [SerializeField] private PartyObject m_B;

        private void Awake()
        {
            m_actionManager = FindObjectOfType<ActionManager>();

            m_parties = new GameParty[2];
        }

        //TODO: Create battle
        private void Start()
        {
            StartBattle(m_A.GetParty(), m_B.GetParty());
        }

        public void StartBattle(GameParty _a, GameParty _b)
        {
            m_parties[0] = _a;
            m_parties[1] = _b;

            StartCoroutine(Turn());
        }

        private IEnumerator Turn()
        {
            StartTurn();
            for (var i = 0; i < m_parties.Length; i++) { yield return ChooseMoves(m_parties[m_parties.Length - i - 1], m_parties[i]); }
            m_actionManager.ExecuteActions();
            EndTurn();
        }

        private void StartTurn()
        {

        }

        private void EndTurn()
        {
            StartCoroutine(Turn());
        }

        private IEnumerator ChooseMoves(GameParty _party, GameParty _opposingParty)
        {
            Debug.Log("Party Moves Start");
            _party.BattleController.SetOpposingParty(_opposingParty);
            for (var i = 0; i < _party.PartyMembers.Count; i++)
            {
                _party.BattleController.SelectPartyMember(i);
                yield return new WaitUntil(() => _party.BattleController.GetChosenAction() != null);
                m_actionManager.QueueAction(_party.BattleController.GetChosenAction());
            }
        }
    }
}