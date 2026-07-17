namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// validator of
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
    /// enumeration value(s).
    /// </summary>
    internal interface ILoggingClientLoggerCacheAddActionValidator
    {
        /// <summary>
        /// Determines whether the logging-client logger-cache <c>Add</c>
        /// <paramref name="action" /> value passed is within the value set defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
        /// enumeration.
        /// </summary>
        /// <param name="action">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" /> value(s)
        /// that is to be examined.
        /// </param>
        /// <remarks>
        /// If the value of the <paramref name="action" /> parameter is outside
        /// the defined value set, or is equal to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />,
        /// then this method returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the logging-client logger-cache <c>Add</c>
        /// <paramref name="action" /> falls within the defined value set and is not equal
        /// to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        bool IsValid(LoggingClientLoggerCacheAddAction action);
    }
}