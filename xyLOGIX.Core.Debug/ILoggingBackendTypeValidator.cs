namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a validator of
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> enumeration values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> enumeration.
    /// </remarks>
    public interface ILoggingBackendTypeValidator
    {
        /// <summary>
        /// Determines whether the logging backend <paramref name="type" /> value
        /// passed is within the value set that is defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> enumeration.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> values that is to be
        /// examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the logging backend
        /// <paramref name="type" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(LoggingBackendType type);
    }
}