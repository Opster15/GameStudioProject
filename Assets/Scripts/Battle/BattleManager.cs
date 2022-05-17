using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GSP.Battle.Party;
using GSP.LUA;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
namespace GSP.Battle
{
    public class BattleManager : MonoBehaviour
    {
        private ActionManager m_actionManager;
        private ScriptManager m_scriptManager;

        private Animator m_anim;
    
        private GameParty[] m_parties;

        //TODO: Create battle
        [SerializeField] private PartyObject m_defaultPlayerParty;
        [SerializeField] private PartyObject m_enemyParty;

        [SerializeField] private bool m_useSharedParty = true;

        private EventInstance m_musicEvent;

        public Action<int, GameParty> OnEnableParty;
        public System.Action OnBattleEnd;

        public System.Action OnTurnStart;
        public System.Action OnTurnEnd;
        public Action<int, GameParty> OnPartyTurn;

        private void Awake()
        {
            m_actionManager = FindObjectOfType<ActionManager>();
            m_scriptManager = FindObjectOfType<ScriptManager>();

            m_anim = GetComponent<Animator>();
            
            m_parties = new GameParty[2];
        }
        
        private void Start()
        {
            // If no player party holder exists, resort to a pre-set default.
            var playerPartyHolder = FindObjectOfType<PlayerPartyHolder>();
            var playerParty = m_useSharedParty && playerPartyHolder == null ? m_defaultPlayerParty.GetParty() : playerPartyHolder.GetParty();

            if (m_musicEvent.isValid())
            {
                m_musicEvent.stop(STOP_MODE.ALLOWFADEOUT);
                m_musicEvent.release();
            }
            m_musicEvent = FMODUnity.RuntimeManager.CreateInstance(m_enemyParty.MusicPath);
            m_musicEvent.start();

            StartBattle(playerParty, m_enemyParty.GetParty());
        }

        private void OnDisable()
        {
            if (!m_musicEvent.isValid()) { return; }
            m_musicEvent.stop(STOP_MODE.ALLOWFADEOUT);
            m_musicEvent.release();
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
                    OnTurnStart += character.StartTurn;
                    OnTurnEnd += character.EndTurn;
                }
            }

            StartTurn();
        }

        private void EndBattle(int partyDown)
        {
            foreach(var party in m_parties)
            {
                foreach (var character in party.PartyMembers)
                {
                    character.DisableScripts(m_scriptManager);
                    OnTurnStart -= character.StartTurn;
                    OnTurnEnd -= character.EndTurn;
                }
                OnBattleEnd?.Invoke();
            }

            m_musicEvent.stop(STOP_MODE.ALLOWFADEOUT);
            m_musicEvent.release();

            if(partyDown == 0)
            {
                m_anim.SetTrigger("OnLose");
            }
            else if (partyDown == 1)
            {
                m_anim.SetTrigger("OnWin");
            }
        }

        private IEnumerator Turn()
        {
            for (var i = 0; i < m_parties.Length; i++)
            {
                var partyID = m_parties.Length - i - 1;
                
                OnPartyTurn?.Invoke(partyID, m_parties[partyID]);
                yield return ChooseMoves(m_parties[partyID], m_parties[i]);
            }
            OnPartyTurn?.Invoke(-1, null);
            yield return m_actionManager.ExecuteActions();

            EndTurn();
        }

        private void StartTurn()
        {
            OnTurnStart?.Invoke();
            StartCoroutine(Turn());
        }

        private void EndTurn()
        {
            var partyDown = -1;
            for(var i = 0; i < m_parties.Length; i++)
            {
                var allPartyMembersDead = true;
                foreach(var partyMember in m_parties[i].PartyMembers)
                {
                    if(!partyMember.IsDead) { allPartyMembersDead = false; }
                }

                if(allPartyMembersDead)
                {
                    partyDown = i;
                    break;
                }
            }
            
            OnTurnEnd?.Invoke();

            if(partyDown < 0) { StartTurn(); }
            else { EndBattle(partyDown); }
        }

        private IEnumerator ChooseMoves(GameParty _party, GameParty _opposingParty)
        {
            _party.BattleController.SetOpposingParty(_opposingParty);
            for (var i = 0; i < _party.PartyMembers.Count; i++)
            {
                var character = _party.PartyMembers[i];
                if (character.IsDead || character.Moveset.Count(move => move.IsUsable) < 1) { continue; } // The character has no valid options.
                
                character.SetSelected(true);
               
                // Ensure the move chosen is currently usable. (Max 20 attempts before breaking)
                int attempts = 0;
                GameMove move = null;
                while (move is not { IsUsable: true } && attempts < 20)
                {
                    // Tell the battle controller which party member is active.
                    _party.BattleController.SetPartyMember(i);
                
                    // Select the move to use, based on the current battle state.
                    yield return new WaitUntil(() => _party.BattleController.GetSelectedMove() != null);
                    
                    move = _party.BattleController.GetSelectedMove();
                    attempts++;
                }
                if (attempts >= 20)
                { continue; } // No valid move could be found.
                
                // If the move is manually targeted, select the target. Otherwise, use all valid targets.
                var targets = move.BaseMove.TargetingMethod.GetValidTargets(i, _party, _opposingParty);
                _party.BattleController.SetTargets(targets);
                if(move.BaseMove.TargetingMethod.IsTargetingManual())
                {
                    character.SetTargeting(targets);
                    
                    yield return new WaitUntil(() => _party.BattleController.GetSelectedTarget() != null);
                    targets = new List<GameCharacter> { _party.BattleController.GetSelectedTarget() };
                    
                    character.SetTargeting(null);
                }

                // Lock in the move.
                move.Use(m_actionManager, targets);

                character.SetSelected(false);
            }
        }
    }
}