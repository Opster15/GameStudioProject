using System;
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

        /// <summary>
        /// Get a live version of a script and increment its reference counter.
        /// </summary>
        /// <param name="_scriptFile">The script file to use.</param>
        /// <returns>The live script.</returns>
        public GameScript GetScript(TextAsset _scriptFile)
        {
            var scriptExists = m_scripts.TryGetValue(_scriptFile.name, out var script);
            if (scriptExists)
            {
                script.IncrementCount();
            }
            else
            {
                script = new ScriptReference(this, _scriptFile);
                m_scripts.Add(_scriptFile.name, script);
            }

            return script.Script;
        }

        /// <summary>
        /// State that whatever is currently using the script no longer needs it, decrementing its reference counter.
        /// </summary>
        /// <param name="_script">The live script to return.</param>
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
            _script.Globals["Debug"] = (Action<string>) Debug.Log;
        }

        private void RegisterTypes()
        {
            UserData.RegisterAssembly();
        }
    }
}
