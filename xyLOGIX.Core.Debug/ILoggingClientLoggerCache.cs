using log4net;
using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// component that stores and retrieves logger object(s) by their logging-client
    /// logger-cache key(s).
    /// </summary>
    /// <remarks>
    /// Implementers must perform each cache operation atomically and must not
    /// expose their synchronization object(s) or underlying collection(s) to callers.
    /// </remarks>
    internal interface ILoggingClientLoggerCache
    {
        /// <summary>
        /// Gets an <see cref="T:System.Int32" /> value that indicates the number
        /// of logger object(s) currently stored in the cache.
        /// </summary>
        /// <remarks>
        /// The value returned by this property is an atomic, point-in-time
        /// snapshot of the cache element count.
        /// <para />
        /// Callers must not assume that the count remains unchanged after the property
        /// getter returns.
        /// </remarks>
        int Count { [DebuggerStepThrough] get; }

        /// <summary>Removes all logger object(s) from the cache.</summary>
        /// <remarks>
        /// If the cache already contains zero element(s), then this method
        /// returns <see langword="true" /> without modifying the cache.
        /// <para />
        /// If the cache cannot be cleared, then this method returns
        /// <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the cache already contains zero element(s)
        /// or is cleared successfully; otherwise, <see langword="false" />.
        /// </returns>
        bool Clear();

        /// <summary>
        /// Attempts to add the specified <paramref name="logger" /> to the cache
        /// by using the specified <paramref name="cacheKey" />.
        /// </summary>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that uniquely identifies the logger within a particular log4net
        /// repository.
        /// </param>
        /// <param name="logger">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that is to be stored in
        /// the cache.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="cacheKey" /> or <paramref name="logger" /> parameter, then this
        /// method returns <see langword="false" />.
        /// <para />
        /// If a non-<see langword="null" /> logger is already cached for the specified
        /// <paramref name="cacheKey" />, then this method leaves the existing logger
        /// unchanged and returns <see langword="true" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the logger is already cached or is added
        /// successfully; otherwise, <see langword="false" />.
        /// </returns>
        bool TryAdd([NotLogged] ILoggingClientLoggerCacheKey cacheKey, [NotLogged] ILog logger);

        /// <summary>
        /// Attempts to obtain the logger associated with the specified
        /// <paramref name="cacheKey" />.
        /// </summary>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that uniquely identifies the logger within a particular log4net
        /// repository.
        /// </param>
        /// <param name="logger">
        /// (Output.) If successful, receives a reference to an
        /// instance of an object that implements the <see cref="T:log4net.ILog" />
        /// interface that is associated with the specified <paramref name="cacheKey" />;
        /// otherwise, receives a <see langword="null" /> reference.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="cacheKey" /> parameter, no matching cache entry exists, or the
        /// matching cache entry contains a <see langword="null" /> reference, then this
        /// method assigns a <see langword="null" /> reference to the
        /// <paramref name="logger" /> parameter and returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if a non-<see langword="null" /> logger is
        /// obtained from the cache; otherwise, <see langword="false" />.
        /// </returns>
        bool TryGet([NotLogged] ILoggingClientLoggerCacheKey cacheKey, [NotLogged] out ILog logger);
    }
}