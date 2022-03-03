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
        /// The character's speed modifier.
        /// </summary>
        [SerializeField] private int m_speed;

        /// <summary>
        /// The character's maximum health.
        /// </summary>
        public int HP => m_HP;

        /// <summary>
        /// The character's speed modifier.
        /// </summary>
        public int Speed => m_speed;
    }
}
