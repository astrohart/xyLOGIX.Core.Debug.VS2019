using log4net;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// object that is responsible for fetching loggers for client session(s).
    /// </summary>
    internal interface ISessionLoggerFetcher
    {
        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration
        /// value that identifies the particular approach that is to be utilized to fetch a
        /// logger for a client session, or to use the legacy logger if no other approach
        /// is available.
        /// </summary>
        SessionLoggerFetchApproach Approach { [DebuggerStepThrough] get; }

        /// <summary>
        /// Attempts to fetch a logger for a client session by using specified
        /// <paramref name="sourceType" /> and optional <paramref name="repositoryName" />,
        /// if specified, per the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration
        /// value that is specified by the
        /// <see cref="P:xyLOGIX.Core.Debug.ISessionLoggerFetcher.Approach" /> property.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that is utilized to identify the logger that is to
        /// be fetched for a client session.
        /// <para />
        /// Perhaps this value might come from an internal cache.
        /// </param>
        /// <param name="repositoryName">
        /// (Optional.) A <see cref="T:System.String" /> that
        /// is set to the name of the repository that is associated with the logger that is
        /// to be fetched for a client session.
        /// <para />
        /// If this value is not specified, then the default repository name will be used.
        /// <para />
        /// The default value of this parameter is the <see cref="F:System.String.Empty" />
        /// value.
        /// <para />
        /// The repository name is only to be provided when a more refined search is to be
        /// employed.
        /// <para />
        /// In such a case where we are searching on the repository name, then the value of
        /// the <paramref name="repositoryName" /> parameter must be specified, and it must
        /// not be <see cref="F:System.String.Empty" />.
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:log4net.ILog" /> interface; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        ILog FetchLogger([NotLogged] Type sourceType, [NotLogged] string repositoryName = "");
    }
}