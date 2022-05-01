using System.Collections.Generic;
using GSP.LUA;
namespace GSP.Battle
{
    /// <summary>
    /// An in-game "live" version of a move.
    /// </summary>
    public class GameMove
    {
        /// <summary>
        /// The move's data.
        /// </summary>
        private Move m_baseMove;

        /// <summary>
        /// The user of this move.
        /// </summary>
        private GameCharacter m_user;

        /// <summary>
        /// The turns until this move is usable.
        /// </summary>
        private int m_cooldown;

        /// <summary>
        /// The move's data.
        /// </summary>
        public Move BaseMove => m_baseMove;

        /// <summary>
        /// The user of this move.
        /// </summary>
        public GameCharacter User => m_user;

        /// <summary>
        /// The turns until this move is usable.
        /// </summary>
        public int Cooldown => m_cooldown;

        /// <summary>
        /// Is the move currently usable?
        /// </summary>
        public bool IsUsable => m_cooldown < 1;
        
        public GameMove(Move _baseMove, GameCharacter _user)
        {
            m_baseMove = _baseMove;
            m_user = _user;

            m_cooldown = _baseMove.Warmup + 1;
        }

        // Lock in the move.
        public void Use(ActionManager _actionManager, List<GameCharacter> _targets)
        {
            m_user.SelectMove(this);
            _actionManager.QueueAction(new Action(m_baseMove, m_user, _targets));
            
            // +1 as the cooldown is ticked at the end of every turn, including the turn the move is used.
            m_cooldown = m_baseMove.Cooldown + 1;
        }

        public void Tick()
        {
            if (m_cooldown < 1) { return; }
            m_cooldown--;
        }
        
        /// <summary>
        /// Arm the move's script for use during battle.
        /// </summary>
        /// <param name="_scriptManager">The active script manager.</param>
        public void EnableScript(ScriptManager _scriptManager)
        {
            m_baseMove.EnableScript(_scriptManager);
        }

        /// <summary>
        /// Disarm the move's script from use during battle.
        /// </summary>
        /// <param name="_scriptManager">The active script manager.</param>
        public void DisableScript(ScriptManager _scriptManager)
        {
            m_baseMove.DisableScript(_scriptManager);
        }
    }
}
