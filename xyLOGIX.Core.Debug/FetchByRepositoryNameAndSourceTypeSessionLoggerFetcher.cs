using log4net;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Gets a reference to an instance of an object that implements the
    /// <see cref="T:log4net.ILog" /> interface for a client session by using the
    /// specified source <see cref="T:System.Type" /> and optional
    /// <see cref="T:System.String" /> that is set to the name of the targeted log4net
    /// repository, if specified, per the
    /// <see
    ///     cref="F:xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType" />
    /// approach.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal class FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher : SessionLoggerFetcherBase
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that need to be
        /// performed once only for the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher" />
        /// and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit direct
        /// allocation of this class, as it is a <c>Singleton</c> object accessible via the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher()
        { }

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration
        /// value that identifies the particular approach that is to be utilized to fetch a
        /// logger for a client session, or to use the legacy logger if no other approach
        /// is available.
        /// </summary>
        public override SessionLoggerFetchApproach Approach { [DebuggerStepThrough] get; } =
            SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType;

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" /> interface for the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType" />
        /// approach.
        /// </summary>
        internal static ISessionLoggerFetcher Instance { [DebuggerStepThrough] get; } =
            new FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher();

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
        public override ILog FetchLogger(Type sourceType, string repositoryName = "")
            => null;
    }
}