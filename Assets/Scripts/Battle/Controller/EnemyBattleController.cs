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
        /// The currently selected move, as an action.
        /// </summary>
        private Action m_selectedAction;

        public void SetParty(GameParty _party)
        {
            m_party = _party;
        }

        public void SetOpposingParty(GameParty _opposingParty)
        {
            m_opposingParty = _opposingParty;
        }

        public void SelectPartyMember(int _partyMember)
            => m_selectedAction = m_party.PartyMembers[_partyMember].AI.SelectAction(_partyMember, m_party, m_opposingParty);

        public Action GetChosenAction()
            => m_selectedAction;
    }
}
