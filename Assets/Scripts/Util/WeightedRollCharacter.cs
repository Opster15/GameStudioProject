using System;
using GSP.Battle;
namespace GSP.Util
{
    /// <summary>
    /// A serializable wrapper of a weighted chance to roll a character.
    /// </summary>
    [Serializable] public class WeightedRollCharacter : WeightedRoll<Character> {}
}
