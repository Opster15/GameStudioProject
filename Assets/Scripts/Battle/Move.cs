using UnityEngine;
namespace GSP.Battle
{
    [CreateAssetMenu(fileName = "New Move", menuName = "GSP/Move")]
    public class Move : ScriptableObject
    {
        /// <summary>
        /// The move's name.
        /// </summary>
        [SerializeField] private string m_name;

        /// <summary>
        /// The base power of the move.
        /// </summary>
        [SerializeField] private int m_power;

        /// <summary>
        /// The base speed of the move.
        /// </summary>
        [SerializeField] private int m_speed;

        /// <summary>
        /// The minigame for the player to play when this move is triggered.
        /// Leave as null for no minigame.
        /// </summary>
        [SerializeField] private GameObject m_minigamePrefab;
        //TODO: Some way to allow minigameless moves to calculate power in varied ways, rather than raw prefabs

        //TODO: Implement priority system
        //TODO: Implement move targeting style
        //TODO: Implement move effect (LUA?)
        
        /// <summary>
        /// The move's name.
        /// </summary>
        public string Name => m_name;

        /// <summary>
        /// The base power of the move.
        /// </summary>
        public int Power => m_power;

        /// <summary>
        /// The base speed of the move.
        /// </summary>
        public int Speed => m_speed;
    }
}
