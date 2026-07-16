namespace xyLOGIX.Core.Debug
{
    /// <summary>Specifies the outcome(s) that can result from an attempt to add a logger to the logging-client logger cache.</summary>
    /// <remarks>This value describes the final result of the cache-add operation, rather than merely identifying the Handler Chain link that processed the request.</remarks>
    internal enum LoggingClientLoggerCacheAddOutcome
    {
        /// <summary>Indicates that the cache already contained a usable logger and that the existing logger was preserved.</summary>
        ExistingLoggerPreserved,

        /// <summary>Indicates that the supplied logger was added to a previously missing cache entry.</summary>
        LoggerAdded,

        /// <summary>Indicates that the cache could not be updated or that the updated entry could not be verified.</summary>
        LoggerUpdateFailed,

        /// <summary>Indicates that an existing cache entry contained a <see langword="null" /> logger reference and was replaced with the supplied logger.</summary>
        NullLoggerReplaced,

        /// <summary>Indicates that the outcome is unknown or has not been determined.</summary>
        Unknown = -1
    }
}