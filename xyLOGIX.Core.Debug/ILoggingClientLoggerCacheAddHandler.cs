using log4net;
using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// handler strategy that processes a particular logging-client logger-cache
    /// <c>Add</c> scenario.
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
        /// Handles the logging-client logger-cache <c>Add</c> scenario
        /// represented by this strategy and returns an object describing the final
        /// outcome.
        /// </summary>
        /// <param name="target">
        /// (Required.) Reference to an instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddTarget" />
        /// interface upon which any required cache mutation is to be performed.
        /// </param>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that identifies the cache entry being processed.
        /// </param>
        /// <param name="logger">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that the caller wants to
        /// store in the cache.
        /// </param>
        /// <remarks>
        /// The handler strategy identified by the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler.HandlerType" />
        /// property determines whether the existing cache entry is preserved or whether
        /// the
        /// <see
        ///     cref="M:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddTarget.TryStore(xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey,log4net.ILog)" />
        /// method must be called.
        /// <para />
        /// If a required parameter is invalid, the required cache operation fails, or an
        /// error occurs, then this method returns a result having the appropriate failure
        /// outcome or a <see langword="null" /> reference if a result cannot be
        /// constructed.
        /// </remarks>
        /// <returns>
        /// If the scenario is processed, a reference to an instance of an object
        /// that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult" />
        /// interface that describes the final outcome; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        ILoggingClientLoggerCacheAddResult Handle(
            [NotLogged] ILoggingClientLoggerCacheAddTarget target,
            [NotLogged] ILoggingClientLoggerCacheKey cacheKey,
            [NotLogged] ILog logger
        );
    }
}