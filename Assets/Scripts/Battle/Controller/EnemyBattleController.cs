using System.Collections.Generic;
using GSP.Battle.Party;
namespace GSP.Battle.Controller
{
    public class EnemyBattleController : IBattleController
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
        private GameMove m_selectedMove;
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
            m_selectedTarget = null;

            var character = m_party.PartyMembers[m_selectedPartyMember];
            m_selectedMove = character.AI.SelectMove(_partyMember, m_party, m_opposingParty);
        }

        public void SetTargets(List<GameCharacter> _targets)
        {
            m_targets = _targets;

            var character = m_party.PartyMembers[m_selectedPartyMember];
            m_selectedTarget = character.AI.SelectTarget(m_selectedMove.BaseMove, _targets);
        }

        public GameMove GetSelectedMove()
            => m_selectedMove;

        public GameCharacter GetSelectedTarget()
            => m_selectedTarget;
    }
}
