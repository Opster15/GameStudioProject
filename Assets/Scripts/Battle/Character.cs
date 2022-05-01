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
        /// The character's icon
        /// </summary>
        [SerializeField] private Sprite m_icon;

        /// <summary>
        /// The character's stat values.
        /// </summary>
        [SerializeField] private StatBlock m_statBlock;

        /// <summary>
        /// Whether the character skips minigames.
        /// </summary>
        [SerializeField] private bool m_skipsMinigames = true;

        /// <summary>
        /// All moves the character can select in the menu.
        /// </summary>
        [SerializeField] private List<Move> m_moveset;
        
        /// <summary>
        /// The character's in-game model.
        /// </summary>
        [SerializeField] private GameObject m_modelPrefab;

        /// <summary>
        /// Whether the character walks up when selected for a move.
        /// </summary>
        [SerializeField] private bool m_walkOnSelected;

        /// <summary>
        /// How long the character's attack windup takes.
        /// </summary>
        [SerializeField] private float m_attackWindupTime;

        /// <summary>
        /// The character's AI, for selecting moves in battle.
        /// </summary>
        [SerializeField] private BattleAIBase m_AI;

        /// <summary>
        /// The character's name.
        /// </summary>
        public string Name => m_name;
        
        /// <summary>
        /// The character's icon.
        /// </summary>
        public Sprite Icon => m_icon;

        /// <summary>
        /// The character's stat values.
        /// </summary>
        public StatBlock StatBlock => m_statBlock;

        /// <summary>
        /// Whether the character skips minigames.
        /// </summary>
        public bool SkipsMinigames => m_skipsMinigames;

        /// <summary>
        /// All moves the character can select in the menu.
        /// </summary>
        public List<Move> Moveset => m_moveset;

        /// <summary>
        /// The character's in-game model.
        /// </summary>
        public GameObject ModelPrefab => m_modelPrefab;

        /// <summary>
        /// Whether the character walks up when selected for a move.
        /// </summary>
        public bool WalkOnSelected => m_walkOnSelected;

        /// <summary>
        /// How long the character's attack windup takes.
        /// </summary>
        public float AttackWindupTime => m_attackWindupTime;

        /// <summary>
        /// The character's AI, for selecting moves in battle.
        /// </summary>
        public BattleAIBase AI => m_AI;
    }
}
