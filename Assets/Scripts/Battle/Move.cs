using GSP.LUA;
using UnityEngine;
namespace GSP.Battle
{
    /// <summary>
    /// The data for a move, including unchanging values and LUA script / minigame prefab references.
    /// </summary>
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

        /// <summary>
        /// The LUA script file to execute when the move is used.
        /// </summary>
        [SerializeField] private TextAsset m_scriptFile;
        
        /// <summary>
        /// The active version of the script.
        /// </summary>
        private GameScript m_script;

        //TODO: Implement priority system
        //TODO: Implement move targeting style
        
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

        /// <summary>
        /// The LUA script file to execute when the move is used.
        /// </summary>
        public TextAsset ScriptFile => m_scriptFile;

        /// <summary>
        /// The active version of the script.
        /// </summary>
        public GameScript Script => m_script;

        /// <summary>
        /// Arm the move's script for use during battle.
        /// </summary>
        /// <param name="_scriptManager">The active script manager.</param>
        public void EnableScript(ScriptManager _scriptManager)
        {
            m_script = _scriptManager.GetScript(m_scriptFile);
        }

        /// <summary>
        /// Disarm the move's script from use during battle.
        /// </summary>
        /// <param name="_scriptManager">The active script manager.</param>
        public void DisableScript(ScriptManager _scriptManager)
        {
            _scriptManager.ReturnScript(m_script);
            m_script = null;
        }
    }
}
