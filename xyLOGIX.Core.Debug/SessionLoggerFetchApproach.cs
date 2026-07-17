namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) that identify the particular approach that is to be utilized
    /// to fetch a logger for a client session, or to use the legacy logger if no other
    /// approach is available.
    /// </summary>
    internal enum SessionLoggerFetchApproach
    {
        /// <summary>
        /// Attempt to fetch the logger from an internal cache that maps source
        /// type(s) to previously-retrieved logger(s).
        /// </summary>
        FetchFromCache,

        /// <summary>
        /// Attempt to fetch the logger for a particular client session by using
        /// the name of the repository that is associated with the logger and the type of
        /// the source that is requesting the logger.
        /// </summary>
        FetchByRepositoryNameAndSourceType,

        /// <summary>Attempt to fetch the logger by the legacy method.</summary>
        FetchLegacyLogger,

        /// <summary>Unknown session-logger fetching approach.</summary>
        /// <remarks>
        /// This value is used to indicate that the session-logger fetching
        /// approach is unknown or has not been specified.
        /// <para />
        /// It can be used as a default value or to handle cases where the fetching
        /// approach cannot be determined.
        /// </remarks>
        Unknown = -1
    }
}