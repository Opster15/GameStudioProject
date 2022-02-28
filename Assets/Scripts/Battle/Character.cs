using System.Collections.Generic;
using GSP.Battle.AI;
using UnityEngine;
namespace GSP.Battle
{
    /// <summary>
    /// The data for a character, including unchanging values such as stats and usable moves.
    /// </summary>
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
        /// The character's AI, for selecting moves in battle.
        /// </summary>
        [SerializeField] private BattleAIBase m_AI;

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

        /// <summary>
        /// The character's AI, for selecting moves in battle.
        /// </summary>
        public BattleAIBase AI => m_AI;
    }
}
