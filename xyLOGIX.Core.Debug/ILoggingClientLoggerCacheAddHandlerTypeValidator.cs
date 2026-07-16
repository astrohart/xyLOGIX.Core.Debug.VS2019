namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the internally-exposed events, methods and properties of a validator of
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
    /// enumeration values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
    /// enumeration.
    /// </remarks>
    internal interface ILoggingClientLoggerCacheAddHandlerTypeValidator
    {
        /// <summary>
        /// Determines whether the logging-client logger cache <c>Add</c> handler
        /// <paramref name="type" /> value passed is within the value set that is defined
        /// by the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// values that is to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the logging-client logger cache <c>Add</c>
        /// handler <paramref name="type" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(LoggingClientLoggerCacheAddHandlerType type);
    }
}