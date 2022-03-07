using GSP.Battle;
using MoonSharp.Interpreter;
namespace GSP.LUA.Wrappers
{
    /// <summary>
    /// A LUA wrapper for the GameCharacter class.
    /// </summary>
    [MoonSharpUserData]
    public class GameCharacterWrapper : ScriptWrapper<GameCharacter>
    {
        public string Name => m_baseObject.Name;
        
        [MoonSharpHidden] public GameCharacterWrapper(GameCharacter _baseObject) : base(_baseObject) { }

        public void Damage(int _amount)
            => m_baseObject.Damage(_amount);
    }
}