using GSP.Battle.Party;
using UnityEngine;
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
        /// The currently selected move, as an action.
        /// </summary>
        private Action m_selectedAction;

        private int m_selectedPartyMember;
        private int m_selectedMove;

        private void Awake()
        {
            m_selectedPartyMember = -1;
            m_selectedMove = -1;
        }

        public void SetParty(GameParty _party)
        {
            m_party = _party;
        }

        public void SetOpposingParty(GameParty _opposingParty)
        {
            m_opposingParty = _opposingParty;
        }

        public void SelectPartyMember(int _partyMember)
        {
            m_selectedAction = null;
            m_selectedPartyMember = _partyMember;
        }

        public void SelectMove(int _moveID)
        {
            if(m_selectedPartyMember < 0) { return; }
            m_selectedMove = _moveID;
        }

        public void SelectTarget(int _targetID)
        {
            if(m_selectedPartyMember < 0 || m_selectedMove < 0) { return; }

            m_selectedAction = new Action(m_party.PartyMembers[m_selectedPartyMember].Moveset[m_selectedMove], m_opposingParty.PartyMembers[_targetID]);

            m_selectedPartyMember = -1;
            m_selectedMove = -1;
        }

        public Action GetChosenAction()
            => m_selectedAction;
    }
}