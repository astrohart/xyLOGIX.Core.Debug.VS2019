using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// component that completes the construction of a logging-client logger-cache key.
    /// </summary>
    internal interface ILoggingClientLoggerCacheKeyBuilder
    {
        /// <summary>
        /// Creates a new logging-client logger-cache key for the repository
        /// previously supplied to the builder and the specified
        /// <paramref name="loggerName" />.
        /// </summary>
        /// <param name="loggerName">
        /// (Required.) A <see cref="T:System.String" /> value
        /// containing the name of the logger within the repository previously supplied to
        /// the builder.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value is passed for the
        /// <paramref name="loggerName" /> parameter, then this method returns a
        /// <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" /> interface;
        /// otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        ILoggingClientLoggerCacheKey AndLoggerNamed([NotLogged] string loggerName);
    }
}