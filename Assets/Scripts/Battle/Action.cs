using System.Collections.Generic;
namespace GSP.Battle
{
    /// <summary>
    /// An active move within the turn order.
    /// </summary>
    public class Action
    {
        private Move m_move;

        private List<GameCharacter> m_targets;
        
        public Action(Move _move, List<GameCharacter> _targets)
        {
            m_move = _move;
            
            m_targets = _targets;
        }
        
        public Action(Move _move, GameCharacter _target)
        {
            m_move = _move;

            m_targets = new List<GameCharacter> { _target };
        }
    }
}
