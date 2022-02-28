using GSP.Battle.Party;
namespace GSP.Battle.Controller
{
    public class EnemyBattleController : IBattleController
    {
        private GameParty m_party;

        private Move m_selectedMove;

        public void SetParty(GameParty _party)
        {
            m_party = _party;
        }

        public void SelectPartyMember(int _partyMember)
        {
            m_selectedMove = m_party.PartyMembers[_partyMember].BaseCharacter.Moveset[0];
        }

        public bool IsMoveChosen()
            => m_selectedMove != null;

        public Move GetChosenMove()
            => m_selectedMove;
    }
}
