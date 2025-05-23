namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a validator of
    /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration.
    /// </remarks>
    public interface IAppenderRetrievalModeValidator
    {
        /// <summary>
        /// Determines whether the appender-retrieval <paramref name="mode" />
        /// value passed is within the value set that is defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration.
        /// </summary>
        /// <param name="mode">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> values that is to be
        /// examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the appender-retrieval
        /// <paramref name="mode" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(AppenderRetrievalMode mode);
    }
}