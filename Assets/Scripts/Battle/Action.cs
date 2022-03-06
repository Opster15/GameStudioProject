using System.Collections.Generic;
using System.Linq;
using GSP.LUA.Wrappers;
using MoonSharp.Interpreter;
using UnityEngine;
namespace GSP.Battle
{
    /// <summary>
    /// An active move within the turn order.
    /// </summary>
    public class Action
    {
        /// <summary>
        /// The move to execute.
        /// </summary>
        private Move m_move;

        /// <summary>
        /// The move's user.
        /// </summary>
        private GameCharacter m_user;

        /// <summary>
        /// All targets chosen by the move.
        /// </summary>
        private List<GameCharacter> m_targets;

        /// <summary>
        /// The total power of the action, determining how strong its effect is.
        /// </summary>
        private int m_power;
        
        /// <summary>
        /// The total speed of the action, determining its place in the turn order.
        /// </summary>
        private int m_speed;

        /// <summary>
        /// The move to execute.
        /// </summary>
        public Move Move => m_move;
        
        /// <summary>
        /// All targets chosen by the move.
        /// </summary>
        public List<GameCharacter> Targets => m_targets;

        /// <summary>
        /// The total power of the action, determining how strong its effect is.
        /// </summary>
        public int Power => m_power;

        /// <summary>
        /// The total speed of the action, determining its place in the turn order.
        /// </summary>
        public int Speed => m_speed;

        /// <summary>
        /// Whether this action should skip the move's minigame.
        /// </summary>
        public bool SkipsMinigame => m_user.SkipsMinigames;
        
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

        /// <summary>
        /// Execute the action's script, based on all determined variables.
        /// </summary>
        public void Execute(float _score)
        {
            var script = m_move.Script;
            
            script.SetGlobal("power", m_power);
            script.SetGlobal("user", new GameCharacterWrapper(m_user));
            script.SetGlobal("targets", m_targets.Select(chara => new GameCharacterWrapper(chara)).ToList());
            
            script.CallFunction("execute", _score);
        }

        private void CalculateStats()
        {
            m_power = m_move.Power;
            m_speed = Mathf.Max(m_move.Speed + m_user.StatBlock.Speed, 1);
        }
    }
}
