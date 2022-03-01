using UnityEngine;
using MoonSharp.Interpreter;
namespace GSP.LUA
{
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

        public void SetGlobal(string _name, object _value)
            => m_script.Globals[_name] = _value;
        
        public void CallFunction(string _func, params object[] _objects)
            => m_script.Call(m_script.Globals[_func], _objects);
    }
}
