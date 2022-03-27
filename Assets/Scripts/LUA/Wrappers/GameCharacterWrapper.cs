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
        /// <summary>
        /// The character's name.
        /// </summary>
        public string Name => m_baseObject.Name;

        /// <summary>
        /// The character's maximum possible health.
        /// </summary>
        public int MaxHP => m_baseObject.MaxHP;

        /// <summary>
        /// The character's current health.
        /// </summary>
        public int CurrentHP => m_baseObject.CurrentHP;
        
        [MoonSharpHidden] public GameCharacterWrapper(GameCharacter _baseObject) : base(_baseObject) { }

        /// <summary>
        /// Change the character's health to a certain amount.
        /// Their health cannot go below 0 and cannot exceed their maximum health.
        /// </summary>
        /// <param name="_HP">The value to set the character's health to.</param>
        public void SetHealth(int _HP)
            => m_baseObject.SetHealth(_HP);
        
        /// <summary>
        /// Damage the character by a certain amount.
        /// Their health can not go below 0.
        /// </summary>
        /// <param name="_amount">The damage to deal.</param>
        public void Damage(int _amount)
            => m_baseObject.Damage(_amount);

        /// <summary>
        /// Heal the character by a certain amount.
        /// Their health can not exceed their maximum health.
        /// </summary>
        /// <param name="_amount">The amount to heal the character.</param>
        public void Heal(int _amount)
            => m_baseObject.Heal(_amount);

        /// <summary>
        /// Kill the character.
        /// </summary>
        public void Kill()
            => m_baseObject.Kill();

        public void AddStatModifier(Stats _stat, int _amount, int _duration)
            => m_baseObject.StatModifiers.AddModifier(_stat, _amount, _duration);
        
        public void SetStatModifier(Stats _stat, int _amount, int _duration)
            => m_baseObject.StatModifiers.SetModifier(_stat, _amount, _duration);

        public void ResetStatModifier(Stats _stat)
            => m_baseObject.StatModifiers.ResetModifier(_stat);
    }
}