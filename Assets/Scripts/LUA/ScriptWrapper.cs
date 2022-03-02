using MoonSharp.Interpreter;
namespace GSP.LUA
{
    /// <summary>
    /// A base class for LUA wrappers.
    /// These ensure that scripts can only access the values they should be able to.
    /// </summary>
    /// <typeparam name="T">The class that is being wrapped.</typeparam>
    public class ScriptWrapper<T>
    {
        /// <summary>
        /// The encapsulated object of the wrapped type.
        /// </summary>
        protected T m_baseObject;

        /// <summary>
        /// The encapsulated object of the wrapped type.
        /// </summary>
        [MoonSharpHidden] public T BaseObject => m_baseObject;

        [MoonSharpHidden]
        public ScriptWrapper(T _baseObject)
        {
            m_baseObject = _baseObject;
        }
    }
}