using System;
using System.Collections.Generic;
using GSP.Battle.AI;
using GSP.LUA;
using UnityEngine;
namespace GSP.Battle
{
    /// <summary>
    /// An in-game "live" instance of a character.
    /// </summary>
    [Serializable]
    public class GameCharacter
    {
        /// <summary>
        /// The character's data.
        /// </summary>
        private Character m_baseCharacter;

        /// <summary>
        /// The character's maximum possible health.
        /// </summary>
        private int m_maxHP;

        /// <summary>
        /// The character's current health.
        /// </summary>
        private int m_currentHP;

        /// <summary>
        /// The character's data.
        /// </summary>
        public Character BaseCharacter => m_baseCharacter;

        /// <summary>
        /// The character's name.
        /// </summary>
        public string Name => m_baseCharacter.Name;

        /// <summary>
        /// The character's maximum possible health.
        /// </summary>
        public int MaxHP => m_maxHP;

        /// <summary>
        /// The character's current health.
        /// </summary>
        public int CurrentHP => m_currentHP;

        /// <summary>
        /// The character's stat values.
        /// </summary>
        public StatBlock StatBlock => m_baseCharacter.StatBlock;

        /// <summary>
        /// Whether the character skips minigames.
        /// </summary>
        public bool SkipsMinigames => m_baseCharacter.SkipsMinigames;

        /// <summary>
        /// All moves the character can select in the menu.
        /// </summary>
        public List<Move> Moveset => m_baseCharacter.Moveset;

        /// <summary>
        /// The character's AI, for selecting moves in battle.
        /// </summary>
        public BattleAIBase AI => m_baseCharacter.AI;

        /// <summary>
        /// Is the current character dead?
        /// </summary>
        public bool IsDead => m_currentHP < 1;
        
        /// <summary>
        /// Called upon the character being selected to choose a move.
        /// </summary>
        public Action<bool> OnSelected;
        
        /// <summary>
        /// Called upon the character being selected to target for a move.
        /// </summary>
        public Action<List<GameCharacter>> OnTargeting;

        /// <summary>
        /// Called upon the character locking in a move to use.
        /// </summary>
        public Action<Move> OnMoveChosen;

        /// <summary>
        /// Called upon the character being called to perform an action.
        /// </summary>
        public Action<bool> OnActing;

        /// <summary>
        /// The in-game "live" instance of a character.
        /// </summary>
        /// <param name="_baseCharacter">The data for the character.</param>
        public GameCharacter(Character _baseCharacter)
        {
            m_baseCharacter = _baseCharacter;
            
            m_maxHP = _baseCharacter.StatBlock.HP;
            m_currentHP = m_maxHP;
        }

        /// <summary>
        /// Change the character's health to a certain amount.
        /// Their health cannot go below 0 and cannot exceed their maximum health.
        /// </summary>
        /// <param name="_HP">The value to set the character's health to.</param>
        public void SetHealth(int _HP)
        {
            _HP = Mathf.Clamp(_HP, 0, m_maxHP);
            m_currentHP = _HP;

            if (m_currentHP < 1) { Kill(); }
        }

        /// <summary>
        /// Damage the character by a certain amount.
        /// Their health can not go below 0.
        /// </summary>
        /// <param name="_amount">The damage to deal.</param>
        public void Damage(int _amount)
            => SetHealth(m_currentHP - _amount);

        /// <summary>
        /// Heal the character by a certain amount.
        /// Their health can not exceed their maximum health.
        /// </summary>
        /// <param name="_amount">The amount to heal the character.</param>
        public void Heal(int _amount)
            => SetHealth(m_currentHP + _amount);

        /// <summary>
        /// Kill the character.
        /// </summary>
        public void Kill()
        {
            m_currentHP = 0;
            SelectMove(null);
        }

        /// <summary>
        /// Select the character.
        /// </summary>
        /// <param name="_selected">Whether the character is selected.</param>
        public void SetSelected(bool _selected)
            => OnSelected?.Invoke(_selected);

        /// <summary>
        /// Call the character to target for a move.
        /// </summary>
        /// <param name="_targeting">Whether the character is targeting.</param>
        public void SetTargeting(List<GameCharacter> _targetOptions)
            => OnTargeting?.Invoke(_targetOptions);

        /// <summary>
        /// Lock in a move for this character.
        /// </summary>
        /// <param name="_move">The chosen move.</param>
        public void SelectMove(Move _move)
            => OnMoveChosen?.Invoke(_move);

        /// <summary>
        /// Call the character up to perform an action.
        /// </summary>
        /// <param name="_acting">Whether the character is performing an action.</param>
        public void SetActing(bool _acting)
            => OnActing?.Invoke(_acting);

        /// <summary>
        /// Arm the character's move's scripts for use during battle.
        /// </summary>
        /// <param name="_scriptManager">The active script manager.</param>
        public void EnableScripts(ScriptManager _scriptManager)
        {
            foreach (var move in Moveset)
            {
                move.EnableScript(_scriptManager);
            }
        }

        /// <summary>
        /// Disarm the character's move's scripts from use during battle.
        /// </summary>
        /// <param name="_scriptManager">The active script manager.</param>
        public void DisableScripts(ScriptManager _scriptManager)
        {
            foreach (var move in Moveset)
            {
                move.DisableScript(_scriptManager);
            }
        }
    }
}