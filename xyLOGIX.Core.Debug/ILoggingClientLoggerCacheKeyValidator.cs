using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// component that validates logging-client logger-cache key object(s).
    /// </summary>
    internal interface ILoggingClientLoggerCacheKeyValidator
    {
        /// <summary>
        /// Determines whether the specified <paramref name="cacheKey" /> contains
        /// all the information required to identify a logger within a particular log4net
        /// repository.
        /// </summary>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that is to be validated.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="cacheKey" /> parameter, then this method returns
        /// <see langword="false" />.
        /// <para />
        /// This method also returns <see langword="false" /> if the
        /// <see cref="P:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.Repository" />
        /// property has a <see langword="null" /> reference for a value or the
        /// <see cref="P:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.LoggerName" />
        /// property is blank.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the specified cache key is valid;
        /// otherwise, <see langword="false" />.
        /// </returns>
        bool IsValid([NotLogged] ILoggingClientLoggerCacheKey cacheKey);
    }
}