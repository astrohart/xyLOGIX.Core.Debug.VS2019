namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Specifies the handler type(s) that can determine how a logger is to be
    /// added to the logging-client logger cache.
    /// </summary>
    /// <remarks>
    /// Each value identifies one mutually-exclusive state that may be
    /// encountered when attempting to add a logger to the cache.
    /// <para />
    /// The applicable handler terminates the Handler Chain after determining how the
    /// cache-add operation is to proceed.
    /// </remarks>
    internal enum LoggingClientLoggerCacheAddHandlerType
    {
        /// <summary>
        /// Indicates that the cache already contains a usable logger
        /// corresponding to the specified cache key.
        /// </summary>
        ExistingLogger,

        /// <summary>
        /// Indicates that the cache does not contain an entry corresponding to
        /// the specified cache key.
        /// </summary>
        MissingLogger,

        /// <summary>
        /// Indicates that the cache contains an entry corresponding to the
        /// specified cache key, but its logger has a <see langword="null" /> reference for
        /// a value.
        /// </summary>
        NullLogger,

        /// <summary>Indicates that the handler type is unknown or has not been determined.</summary>
        Unknown = -1
    }
}