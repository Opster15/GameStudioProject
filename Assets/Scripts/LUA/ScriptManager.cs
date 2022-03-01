using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
namespace GSP.LUA
{
    public class ScriptManager : MonoBehaviour
    {
        private class ScriptReference
        {
            /// <summary>
            /// The number of times this script is referenced.
            /// </summary>
            private int m_referenceCount;

            /// <summary>
            /// The script being referenced.
            /// </summary>
            private GameScript m_script;
            
            /// <summary>
            /// The number of times this script is referenced.
            /// </summary>
            public int ReferenceCount => m_referenceCount;

            /// <summary>
            /// The script being referenced.
            /// </summary>
            public GameScript Script => m_script;

            public ScriptReference(ScriptManager _scriptManager, TextAsset _scriptFile)
            {
                m_script = new GameScript(_scriptManager, _scriptFile);
                IncrementCount();
            }
            
            /// <summary>
            /// Increment the reference counter.
            /// </summary>
            public void IncrementCount()
                => m_referenceCount++;

            /// <summary>
            /// Decrement the reference counter.
            /// </summary>
            public void DecrementCount()
                => m_referenceCount--;
        }

        private Dictionary<string, ScriptReference> m_scripts;

        private void Awake()
        {
            RegisterTypes();

            m_scripts = new Dictionary<string, ScriptReference>();
        }

        public GameScript GetScript(TextAsset _scriptFile)
        {
            var scriptExists = m_scripts.TryGetValue(_scriptFile.name, out var script);
            if (!scriptExists)
            {
                script = new ScriptReference(this, _scriptFile);
                m_scripts.Add(_scriptFile.name, script);
            }

            return script.Script;
        }

        public void ReturnScript(GameScript _script)
        {
            var scriptExists = m_scripts.TryGetValue(_script.ScriptName, out var script);
            if (scriptExists)
            {
                script.DecrementCount();
                if (script.ReferenceCount < 1) { m_scripts.Remove(_script.ScriptName); }
            }
            else
            {
                Debug.LogWarning("Tried to return a script which has no references.");
            }
        }

        public void AssignScriptGlobals(Script _script)
        {
            // do things lol :-)
        }

        private void RegisterTypes()
        {
            UserData.RegisterAssembly();
        }
    }
}
