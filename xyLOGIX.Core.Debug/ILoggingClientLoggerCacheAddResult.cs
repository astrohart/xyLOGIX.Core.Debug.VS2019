using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// object that describes the result of an attempt to add a logger to the
    /// logging-client logger cache.
    /// </summary>
    internal interface ILoggingClientLoggerCacheAddResult
    {
        /// <summary>
        /// Gets a
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the Handler Chain link that accepted
        /// responsibility for the cache-add operation.
        /// </summary>
        LoggingClientLoggerCacheAddHandlerType HandlerType { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
        /// enumeration value that describes the final outcome of the cache-add operation.
        /// </summary>
        LoggingClientLoggerCacheAddOutcome Outcome { [DebuggerStepThrough] get; }
    }
}