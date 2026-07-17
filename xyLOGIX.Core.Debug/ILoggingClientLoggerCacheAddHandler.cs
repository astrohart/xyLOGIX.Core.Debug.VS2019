using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// handler strategy that selects the action to perform for a particular
    /// logging-client logger-cache <c>Add</c> scenario.
    /// </summary>
    internal interface ILoggingClientLoggerCacheAddHandler
    {
        /// <summary>
        /// Gets a
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the cache-add handler strategy implemented by
        /// this object.
        /// </summary>
        LoggingClientLoggerCacheAddHandlerType HandlerType { [DebuggerStepThrough] get; }

        /// <summary>
        /// Selects the logging-client logger-cache <c>Add</c> action that
        /// corresponds to the scenario represented by this handler strategy.
        /// </summary>
        /// <remarks>
        /// This method does not access or mutate the logging-client logger cache.
        /// <para />
        /// The caller is responsible for applying the returned action, verifying the
        /// resulting cache state, and constructing the corresponding
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult" /> object.
        /// <para />
        /// If the correct action cannot be selected, or an error occurs, then this method
        /// returns
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />.
        /// </remarks>
        /// <returns>
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
        /// enumeration value(s) that identifies the action to perform; otherwise,
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />
        /// is returned.
        /// </returns>
        LoggingClientLoggerCacheAddAction Handle();
    }
}