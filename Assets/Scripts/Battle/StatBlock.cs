using System;
using UnityEngine;
namespace GSP.Battle
{
    /// <summary>
    /// A character's base stats.
    /// </summary>
    [Serializable]
    public struct StatBlock
    {
        /// <summary>
        /// The character's maximum health.
        /// </summary>
        [SerializeField] private int m_HP;

        /// <summary>
        /// The character's offensive ability.
        /// </summary>
        [SerializeField] private int m_attack;

        /// <summary>
        /// The character's defensive ability.
        /// </summary>
        [SerializeField] private int m_defence;

        /// <summary>
        /// The character's speed modifier.
        /// </summary>
        [SerializeField] private int m_speed;

        /// <summary>
        /// The character's maximum health.
        /// </summary>
        public int HP => m_HP;

        /// <summary>
        /// The character's offensive ability.
        /// </summary>
        public int Attack => m_attack;

        /// <summary>
        /// The character's defensive ability.
        /// </summary>
        public int Defence => m_defence;

        /// <summary>
        /// The character's speed modifier.
        /// </summary>
        public int Speed => m_speed;
    }
}
