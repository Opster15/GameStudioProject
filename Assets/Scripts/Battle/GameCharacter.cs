using System;
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
        /// The character's maximum possible health.
        /// </summary>
        public int MaxHP => m_maxHP;

        /// <summary>
        /// The character's current health.
        /// </summary>
        public int CurrentHP => m_currentHP;

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
        /// <param name="_HP"></param>
        public void SetHealth(int _HP)
        {
            _HP = Mathf.Clamp(_HP, 0, m_maxHP);
            m_currentHP = _HP;
        }

        /// <summary>
        /// Damage the character by a certain amount.
        /// Their health can not go below 0.
        /// </summary>
        /// <param name="_amount"></param>
        public void Damage(int _amount) => SetHealth(m_currentHP - _amount);

        /// <summary>
        /// Heal the character by a certain amount.
        /// Their health can not exceed their maximum health.
        /// </summary>
        /// <param name="_amount"></param>
        public void Heal(int _amount) => SetHealth(m_currentHP + _amount);
    }
}