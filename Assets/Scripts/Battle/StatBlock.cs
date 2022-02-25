using System;
using UnityEngine;
namespace GSP.Battle
{
    [Serializable]
    public struct StatBlock
    {
        /// <summary>
        /// The character's maximum health.
        /// </summary>
        [SerializeField] private int m_HP;

        /// <summary>
        /// The character's maximum health.
        /// </summary>
        public int HP => m_HP;
    }
}
