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
    /// specified <paramref name="sourceType" /> and optional
    /// <paramref name="repositoryName" />, if specified, per the
    /// <see cref="F:xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger" />
    /// approach.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal class FetchLegacyLoggerSessionLoggerFetcher : SessionLoggerFetcherBase
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher" />
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
        static FetchLegacyLoggerSessionLoggerFetcher() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher" /> and
        /// returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the
        /// <see cref="P:xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private FetchLegacyLoggerSessionLoggerFetcher()
        { }

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration
        /// value that identifies the particular approach that is to be utilized to fetch a
        /// logger for a client session, or to use the legacy logger if no other approach
        /// is available.
        /// </summary>
        public override SessionLoggerFetchApproach Approach { [DebuggerStepThrough] get; } =
            SessionLoggerFetchApproach.FetchLegacyLogger;

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" />
        /// interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger" />
        /// approach.
        /// </summary>
        internal static ISessionLoggerFetcher Instance { [DebuggerStepThrough] get; } =
            new FetchLegacyLoggerSessionLoggerFetcher();

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
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public override ILog FetchLogger(
            [NotLogged] Type sourceType,
            [NotLogged] string repositoryName = ""
        )
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"FetchLegacyLoggerSessionLoggerFetcher.FetchLogger: *** FYI *** Attempting to fetch the legacy logger for the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "FetchLegacyLoggerSessionLoggerFetcher.FetchLogger: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "FetchLegacyLoggerSessionLoggerFetcher.FetchLogger: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "FetchLegacyLoggerSessionLoggerFetcher.FetchLogger: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'sourceType.FullName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'sourceType.FullName', appears to have a
                // null  or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(sourceType.FullName))
                {
                    // The property, 'sourceType.FullName', appears to have a null or blank value.
                    // This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'sourceType.FullName', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"FetchLegacyLoggerSessionLoggerFetcher.FetchLogger: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'sourceType.FullName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    string.IsNullOrWhiteSpace(repositoryName)
                        ? "FetchLegacyLoggerSessionLoggerFetcher.FetchLogger: *** FYI *** No repository name was supplied.  The legacy logger-fetching approach does not require one."
                        : $"FetchLegacyLoggerSessionLoggerFetcher.FetchLogger: *** FYI *** The repository name, '{repositoryName}', was supplied but is intentionally ignored by the legacy logger-fetching approach."
                );

                result = TryGetLegacyLogger(sourceType);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** The legacy logger was fetched successfully.  Proceeding..."
                    : "*** ERROR *** The legacy logger could not be fetched.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface from the ordinary log4net repository.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that identifies the source of the logging
        /// record(s).
        /// </param>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="sourceType" /> is <see langword="null" />, or
        /// log4net cannot supply the logger, then this method returns
        /// <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        private static ILog TryGetLegacyLogger([NotLogged] Type sourceType)
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"FetchLegacyLoggerSessionLoggerFetcher.TryGetLegacyLogger: *** FYI *** Attempting to get a reference to an instance of the legacy logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "FetchLegacyLoggerSessionLoggerFetcher.TryGetLegacyLogger: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "FetchLegacyLoggerSessionLoggerFetcher.TryGetLegacyLogger: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "FetchLegacyLoggerSessionLoggerFetcher.TryGetLegacyLogger: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Getting the legacy logger for the source type, '{sourceType.FullName}'..."
                );

                result = LogManager.GetLogger(sourceType);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null

                    // ReSharper disable once ConstantConditionalAccessQualifier
                    ? $"*** SUCCESS *** Obtained a reference to an instance of the legacy logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to an instance of the legacy logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'.  Stopping..."
            );

            return result;
        }
    }
}