using log4net;
using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// narrowly-scoped target upon which a logging-client logger-cache <c>Add</c>
    /// handler strategy can perform a cache mutation.
    /// </summary>
    /// <remarks>
    /// Implementers retain exclusive ownership of their underlying
    /// synchronization object(s) and cache collection(s).
    /// <para />
    /// This interface does not expose either implementation detail to handler strategy
    /// object(s).
    /// </remarks>
    internal interface ILoggingClientLoggerCacheAddTarget
    {
        /// <summary>
        /// Attempts to store the specified <paramref name="logger" /> under the
        /// specified <paramref name="cacheKey" /> and verifies that the resulting cache
        /// entry contains the same logger object reference.
        /// </summary>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that identifies the cache entry to be updated.
        /// </param>
        /// <param name="logger">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that is to be stored.
        /// </param>
        /// <remarks>
        /// The implementer is responsible for performing the cache mutation and
        /// its verification atomically.
        /// <para />
        /// If either parameter has a <see langword="null" /> reference for a value, the
        /// logger cannot be stored, the resulting cache entry cannot be found, or the
        /// resulting entry does not contain the same logger object reference, then this
        /// method returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the specified logger is stored and the
        /// resulting cache entry contains the same logger object reference; otherwise,
        /// <see langword="false" />.
        /// </returns>
        bool TryStore([NotLogged] ILoggingClientLoggerCacheKey cacheKey, [NotLogged] ILog logger);
    }
}