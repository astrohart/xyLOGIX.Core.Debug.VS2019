namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the internally-exposed events, methods and properties of a
    /// validator of
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
    /// enumeration values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
    /// enumeration.
    /// </remarks>
    internal interface ILoggingClientLoggerCacheAddOutcomeValidator
    {
        /// <summary>
        /// Determines whether the logging-client logger-cache <c>Add</c>
        /// <paramref name="outcome" /> value passed is within the value set that is
        /// defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
        /// enumeration.
        /// </summary>
        /// <param name="outcome">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" /> values
        /// that is to be examined.
        /// </param>
        /// <remarks>
        /// If the value of the <paramref name="outcome" /> parameter is outside
        /// the defined value set, or is equal to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown" />,
        /// then this method returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the logging-client logger-cache <c>Add</c>
        /// <paramref name="outcome" /> falls within the defined value set and is not equal
        /// to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        bool IsValid(LoggingClientLoggerCacheAddOutcome outcome);
    }
}