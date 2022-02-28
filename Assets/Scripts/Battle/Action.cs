using System.Collections.Generic;
using UnityEngine;
namespace GSP.Battle
{
    /// <summary>
    /// An active move within the turn order.
    /// </summary>
    public class Action
    {
        private Move m_move;

        private GameCharacter m_user;

        private List<GameCharacter> m_targets;

        private int m_power;
        private int m_speed;

        public Move Move => m_move;

        public List<GameCharacter> Targets => m_targets;

        public int Power => m_power;

        public int Speed => m_speed;
        
        public Action(Move _move, GameCharacter _user, List<GameCharacter> _targets)
        {
            m_move = _move;
            m_user = _user;

            m_targets = _targets;

            CalculateStats();
        }
        
        public Action(Move _move, GameCharacter _user, GameCharacter _target)
        {
            m_move = _move;
            m_user = _user;

            m_targets = new List<GameCharacter> { _target };

            CalculateStats();
        }

        private void CalculateStats()
        {
            m_power = m_move.Power;
            m_speed = Mathf.Max(m_move.Speed + m_user.StatBlock.Speed, 1);
        }
    }
}
