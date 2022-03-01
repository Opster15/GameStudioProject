using MoonSharp.Interpreter;
namespace GSP.LUA
{
    public class ScriptWrapper<T>
    {
        protected T m_baseObject;

        [MoonSharpHidden]
        public T BaseObject => m_baseObject;

        [MoonSharpHidden]
        public ScriptWrapper(T _baseObject)
        {
            m_baseObject = _baseObject;
        }
    }
}