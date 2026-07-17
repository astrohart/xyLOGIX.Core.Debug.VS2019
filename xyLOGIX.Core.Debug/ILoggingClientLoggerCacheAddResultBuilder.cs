using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of a builder that
    /// completes the construction of a logging-client logger-cache <c>Add</c> result.
    /// </summary>
    /// <remarks>
    /// An object that implements this interface retains a previously
    /// validated
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
    /// value and completes construction when supplied with a valid, compatible
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" /> value.
    /// </remarks>
    internal interface ILoggingClientLoggerCacheAddResultBuilder
    {
        /// <summary>
        /// Completes the construction of a logging-client logger-cache <c>Add</c>
        /// result having the specified <paramref name="outcome" />.
        /// </summary>
        /// <param name="outcome">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
        /// enumeration value that describes the final outcome of the cache-add operation.
        /// </param>
        /// <remarks>
        /// The specified <paramref name="outcome" /> must be valid and compatible
        /// with the Handler Chain link type previously supplied to the builder.
        /// <para />
        /// If the specified value is invalid, is incompatible with the retained Handler
        /// Chain link type, or an error occurs, then this method returns a
        /// <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to a new instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult" />
        /// interface; otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        ILoggingClientLoggerCacheAddResult AndOutcome(LoggingClientLoggerCacheAddOutcome outcome);
    }
}