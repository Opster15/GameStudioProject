using System.Collections;
namespace GSP.LUA
{
    /// <summary>
    /// A declaration that this wrapper can be used as the return of a yield within a script.
    /// </summary>
    public interface IYieldable
    {
        /// <summary>
        /// Yield the script until a condition is met.
        /// </summary>
        IEnumerator Yield();
    }
}
