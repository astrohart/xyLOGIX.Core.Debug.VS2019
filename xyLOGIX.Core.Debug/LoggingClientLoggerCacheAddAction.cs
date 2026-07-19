namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Specifies the action(s) that may be performed while adding a logger to
    /// the logging-client logger cache.
    /// </summary>
    /// <remarks>
    /// A logging-client logger-cache <c>Add</c> handler strategy returns one
    /// of these value(s) after being selected for the current cache-entry state.
    /// <para />
    /// The logging-client logger cache is responsible for applying the selected
    /// action, verifying its result, and constructing the corresponding
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult" /> object.
    /// </remarks>
    internal enum LoggingClientLoggerCacheAddAction
    {
        /// <summary>
        /// Indicates that the supplied logger is to be added to a cache entry
        /// that does not currently exist.
        /// </summary>
        AddLogger,

        /// <summary>
        /// Indicates that the usable logger already contained in the cache is to
        /// be preserved without modification.
        /// </summary>
        PreserveExistingLogger,

        /// <summary>
        /// Indicates that the supplied logger is to replace a
        /// <see langword="null" /> logger reference contained in an existing cache entry.
        /// </summary>
        ReplaceNullLogger,

        /// <summary>
        /// Indicates that the cache-add action is unknown or has not been
        /// determined.
        /// </summary>
        Unknown = -1
    }
}