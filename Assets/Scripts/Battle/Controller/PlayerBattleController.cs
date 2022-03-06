using GSP.Battle.Party;
using UnityEngine;
using System.Collections.Generic;
namespace GSP.Battle.Controller
{
    public class PlayerBattleController : MonoBehaviour, IBattleController
    {
        /// <summary>
        /// The party to control.
        /// </summary>
        private GameParty m_party;

        /// <summary>
        /// The opponent's party.
        /// </summary>
        private GameParty m_opposingParty;

        /// <summary>
        /// The targets to select from.
        /// </summary>
        private List<GameCharacter> m_targets;

        private int m_selectedPartyMember;
        private Move m_selectedMove;
        private GameCharacter m_selectedTarget;

        private void Awake()
        {
            m_targets = null;
            m_selectedPartyMember = -1;
            m_selectedMove = null;
            m_selectedTarget = null;
        }

        public void SetParty(GameParty _party)
        {
            m_party = _party;
        }

        public void SetOpposingParty(GameParty _opposingParty)
        {
            m_opposingParty = _opposingParty;
        }

        public void SetPartyMember(int _partyMember)
        {
            m_selectedPartyMember = _partyMember;

            m_targets = null;
            m_selectedMove = null;
            m_selectedTarget = null;
        }

        public void SetTargets(List<GameCharacter> _targets)
        {
            m_targets = _targets;
        }

        public void SelectMove(int _moveID)
        {
            if(m_selectedPartyMember < 0) { return; }
            m_selectedMove = m_party.PartyMembers[m_selectedPartyMember].Moveset[_moveID];
        }

        public void SelectTarget(int _targetID)
        {
            if(m_targets == null || m_selectedPartyMember < 0 || m_selectedMove == null) { return; }
            m_selectedTarget = m_targets[_targetID];
        }

        public Move GetSelectedMove()
            => m_selectedMove;

        public GameCharacter GetSelectedTarget()
            => m_selectedTarget;
    }
}