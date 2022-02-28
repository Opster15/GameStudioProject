using System;
using System.Collections.Generic;
using System.Linq;
using GSP.Battle.Controller;
namespace GSP.Battle.Party
{
    /// <summary>
    /// A party of characters who can enter combat.
    /// </summary>
    [Serializable]
    public class GameParty
    {
        /// <summary>
        /// The party's members.
        /// </summary>
        private List<GameCharacter> m_partyMembers;

        /// <summary>
        /// The party's method of choosing moves.
        /// </summary>
        private IBattleController m_battleController;

        /// <summary>
        /// The party's members.
        /// </summary>
        public List<GameCharacter> PartyMembers => m_partyMembers;

        /// <summary>
        /// The party's method of choosing moves.
        /// </summary>
        public IBattleController BattleController => m_battleController;

        public GameParty(List<GameCharacter> _partyMembers, IBattleController _battleController)
        {
            m_partyMembers = _partyMembers;
            m_battleController = _battleController;
            
            m_battleController.SetParty(this);
        }

        public GameParty(List<Character> _partyMembers, IBattleController _battleController)
        {
            m_partyMembers = _partyMembers.Select(partyMember => new GameCharacter(partyMember)).ToList();
            m_battleController = _battleController;
            
            m_battleController.SetParty(this);
        }
    }
}
