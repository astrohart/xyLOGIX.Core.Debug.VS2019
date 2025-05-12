namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a validator of
    /// <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> enumeration values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> enumeration.
    /// </remarks>
    public interface IDebugLevelValidator
    {
        /// <summary>
        /// Determines whether the debug <paramref name="level" /> value passed is
        /// within the value set that is defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> enumeration.
        /// </summary>
        /// <param name="level">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> value(s) that is to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the debug <paramref name="level" /> falls
        /// within the defined value set; <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(DebugLevel level);
    }
}