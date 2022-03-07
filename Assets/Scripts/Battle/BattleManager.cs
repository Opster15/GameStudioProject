using System;
using System.Collections;
using System.Collections.Generic;
using GSP.Battle.Party;
using GSP.LUA;
using UnityEngine;
namespace GSP.Battle
{
    public class BattleManager : MonoBehaviour
    {
        private ActionManager m_actionManager;
        private ScriptManager m_scriptManager;
    
        private GameParty[] m_parties;

        public Action<int, GameParty> OnEnableParty;

        private void Awake()
        {
            m_actionManager = FindObjectOfType<ActionManager>();
            m_scriptManager = FindObjectOfType<ScriptManager>();
            
            m_parties = new GameParty[2];
        }

        //TODO: Create battle
        [SerializeField] private PartyObject m_A;
        [SerializeField] private PartyObject m_B;
        
        private void Start()
        {
            StartBattle(m_A.GetParty(), m_B.GetParty());
        }

        public void StartBattle(GameParty _a, GameParty _b)
        {
            m_parties[0] = _a;
            m_parties[1] = _b;

            for (var i = 0; i < m_parties.Length; i++)
            {
                var party = m_parties[i];
                OnEnableParty?.Invoke(i, party);
                
                foreach (var character in party.PartyMembers)
                {
                    character.EnableScripts(m_scriptManager);
                }
            }

            StartTurn();
        }

        private void EndBattle()
        {
            foreach(var party in m_parties)
            {
                foreach (var character in party.PartyMembers)
                {
                    character.DisableScripts(m_scriptManager);
                }
            }
        }

        private IEnumerator Turn()
        {
            for (var i = 0; i < m_parties.Length; i++)
            {
                yield return ChooseMoves(m_parties[m_parties.Length - i - 1], m_parties[i]);
            }
            yield return m_actionManager.ExecuteActions();

            EndTurn();
        }

        private void StartTurn()
        {
            StartCoroutine(Turn());
        }

        private void EndTurn()
        {
            StartTurn();
        }

        private IEnumerator ChooseMoves(GameParty _party, GameParty _opposingParty)
        {
            _party.BattleController.SetOpposingParty(_opposingParty);
            for (var i = 0; i < _party.PartyMembers.Count; i++)
            {
                if (_party.PartyMembers[i].IsDead) { continue; }
                
                // Tell the battle controller which party member is active.
                _party.BattleController.SetPartyMember(i);

                // Select the move to use, based on the current battle state.
                yield return new WaitUntil(() => _party.BattleController.GetSelectedMove() != null);
                var move = _party.BattleController.GetSelectedMove();

                // If the move is manually targeted, select the target. Otherwise, use all valid targets.
                var targets = move.TargetingMethod.GetValidTargets(i, _party, _opposingParty);
                _party.BattleController.SetTargets(targets);
                if(move.TargetingMethod.IsTargetingManual())
                {
                    yield return new WaitUntil(() => _party.BattleController.GetSelectedTarget() != null);
                    targets = new List<GameCharacter> { _party.BattleController.GetSelectedTarget() };
                }

                m_actionManager.QueueAction(new Action(move, _party.PartyMembers[i], targets));
            }
        }
    }
}