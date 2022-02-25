using System.Collections.Generic;
using UnityEngine;
namespace GSP.Battle
{
    [CreateAssetMenu(fileName = "New Character", menuName = "GSP/Character")]
    public class Character : ScriptableObject
    {
        /// <summary>
        /// The character's name.
        /// </summary>
        [SerializeField] private string m_name;

        /// <summary>
        /// The character's stat values.
        /// </summary>
        private StatBlock m_statBlock;

        /// <summary>
        /// All moves the character can select in the menu.
        /// </summary>
        [SerializeField] private List<Move> m_moveset;

        /// <summary>
        /// The character's name.
        /// </summary>
        public string Name => m_name;

        /// <summary>
        /// The character's stat values.
        /// </summary>
        public StatBlock StatBlock => m_statBlock;

        /// <summary>
        /// All moves the character can select in the menu.
        /// </summary>
        public List<Move> Moveset => m_moveset;
    }
}
