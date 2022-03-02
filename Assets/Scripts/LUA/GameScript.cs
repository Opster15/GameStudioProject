using UnityEngine;
using MoonSharp.Interpreter;
namespace GSP.LUA
{
    /// <summary>
    /// An actively usable script for gameplay.
    /// </summary>
    public class GameScript
    {
        private ScriptManager m_scriptManager;

        private string m_scriptName;
        private Script m_script;

        public string ScriptName => m_scriptName;

        public GameScript(ScriptManager _scriptManager, TextAsset _scriptFile)
        {
            m_scriptManager = _scriptManager;

            m_scriptName = _scriptFile.name;
            
            m_script = new Script(CoreModules.Preset_SoftSandbox);
            m_scriptManager.AssignScriptGlobals(m_script);
            
            m_script.DoString(_scriptFile.text);
        }

        /// <summary>
        /// Set a unique global for the script.
        /// </summary>
        /// <param name="_name">The name of the global for use in LUA.</param>
        /// <param name="_value">The value to set the global to. Must be a LUA-valid type.</param>
        public void SetGlobal(string _name, object _value)
            => m_script.Globals[_name] = _value;
        
        /// <summary>
        /// Call a function within the script.
        /// </summary>
        /// <param name="_func">The name of the function in the script.</param>
        /// <param name="_objects">Any arguments to pass in.</param>
        public void CallFunction(string _func, params object[] _objects)
            => m_script.Call(m_script.Globals[_func], _objects);
    }
}
