namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the internally-exposed events, methods and properties of a
    /// validator of <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" />
    /// enumeration values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration.
    /// </remarks>
    internal interface ISessionLoggerFetchApproachValidator
    {
        /// <summary>
        /// Determines whether the session logger fetching
        /// <paramref name="approach" /> value passed is within the value set that is
        /// defined by the <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" />
        /// enumeration.
        /// </summary>
        /// <param name="approach">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> values that is
        /// to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the session logger fetching
        /// <paramref name="approach" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(SessionLoggerFetchApproach approach);

        /// <summary>
        /// Determines whether the session logger fetching
        /// <paramref name="approach" /> value passed is within the value set that is
        /// defined by the <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" />
        /// enumeration.
        /// </summary>
        /// <param name="approach">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> values that is
        /// to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the session logger fetching
        /// <paramref name="approach" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool IsValidSilent(SessionLoggerFetchApproach approach);
    }
}