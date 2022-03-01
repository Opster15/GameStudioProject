using GSP.Battle;
using MoonSharp.Interpreter;
namespace GSP.LUA.Wrappers
{
    [MoonSharpUserData]
    public class GameCharacterWrapper : ScriptWrapper<GameCharacter>
    {
        public string Name => m_baseObject.Name;
        
        [MoonSharpHidden] public GameCharacterWrapper(GameCharacter _baseObject) : base(_baseObject) { }
    }
}