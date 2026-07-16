using log4net;
using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides log4net logger object(s) for the current logging-client
    /// session.
    /// </summary>
    /// <remarks>
    /// This class dynamically selects the appropriate repository whenever a
    /// logger is requested.
    /// <para />
    /// Logger object(s) are not cached globally because the current logging-client
    /// session may vary between logical execution flow(s).
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLogProvider : ILoggingClientLogProvider
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLogProvider" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLogProvider() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLogProvider" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the <see cref="P:xyLOGIX.Core.Debug.LoggingClientLogProvider.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLogProvider() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> that maps
        /// <see cref="T:System.String" /> value(s), consisting of the fully-qualified
        /// name(s) of source type(s), to reference(s) to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that is a logger of that
        /// type.
        /// </summary>
        private IDictionary<string, ILog> _sourceTypeFQNToLogMap { [DebuggerStepThrough] get; } =
            new AdvisableDictionary<string, ILog>();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientAssemblyContext" /> interface.
        /// </summary>
        private static ILoggingClientAssemblyContext ClientAssemblyContext
        {
            [DebuggerStepThrough] get;
        } = GetLoggingClientAssemblyContext.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSessionRegistry" /> interface.
        /// </summary>
        private static ILoggingClientSessionRegistry ClientSessionRegistry
        {
            [DebuggerStepThrough] get;
        } = GetLoggingClientSessionRegistry.SoleInstance();

        /// <summary>
        /// Gets the ticket that identifies the logging-client assembly associated
        /// with the current logical execution flow.
        /// </summary>
        /// <remarks>
        /// If no logging-client assembly is currently selected, the
        /// client-assembly context is unavailable, or the property cannot be evaluated,
        /// then this property returns <see cref="F:System.Guid.Empty" />.
        /// </remarks>
        internal static Guid CurrentClientAssemblyTicket
        {
            [DebuggerStepThrough]
            get
            {
                var result = Guid.Empty;

                try
                {
                    if (ClientAssemblyContext == null) return result;

                    result = ClientAssemblyContext.CurrentTicket;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = Guid.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the logging-client session associated with the current logical
        /// execution flow.
        /// </summary>
        /// <remarks>
        /// If no logging-client assembly is currently selected, or no session has
        /// been created for the selected ticket, this property returns
        /// <see langword="null" />.
        /// </remarks>
        internal static ILoggingClientSession CurrentClientSession
        {
            [DebuggerStepThrough]
            get
            {
                ILoggingClientSession result = default;

                try
                {
                    if (Guid.Empty.Equals(CurrentClientAssemblyTicket)) return result;
                    if (ClientSessionRegistry == null) return result;

                    result = ClientSessionRegistry.Get(CurrentClientAssemblyTicket);
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = default;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLogProvider" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLogProvider Instance { [DebuggerStepThrough] get; } =
            new LoggingClientLogProvider();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator" />
        /// interface.
        /// </summary>
        private static ISessionLoggerFetchApproachValidator SessionLoggerFetchApproachValidator
        {
            [DebuggerStepThrough] get;
        } = GetSessionLoggerFetchApproachValidator.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface for the specified source type.
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
        /// If <paramref name="sourceType" /> is <see langword="null" />, then
        /// this method returns <see langword="null" />.
        /// <para />
        /// If no valid specialized logging-client session is active, then the ordinary
        /// log4net repository is utilized.
        /// <para />
        /// If a valid specialized session is active but a logger cannot be obtained from
        /// its repository, then this method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public ILog GetLogForType([NotLogged] Type sourceType)
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.GetLogForType: *** FYI *** Getting a logger for the source type, '{sourceType?.FullName ?? "<null>"}' and for the current client session (if any)..."
                );

                var approach = Determine.TheCorrectSessionLoggerFetchApproachToUse(sourceType);

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.GetLogForType: Checking whether the session-logger fetching approach, '{approach}', is within the defined value set..."
                );

                // Check whether the session-logger fetching approach, 'approach', is within the
                // defined value set.  If this is not the case, then write an error message to the
                // Debug output, and then terminate the execution of this method, while returning
                // the default return value.
                if (!SessionLoggerFetchApproachValidator.IsValid(approach))
                {
                    // The session-logger fetching approach, 'approach', is NOT within the defined
                    // value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLogProvider.GetLogForType: *** ERROR *** The session-logger fetching approach, '{approach}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLogProvider.GetLogForType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.GetLogForType: *** SUCCESS *** The session-logger fetching approach, '{approach}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to get a reference to an instance of an object that implements the 'ISessionLoggerFetcher' interface for the session-logger fetching approach, '{approach}'..."
                );

                var fetcher = GetSessionLoggerFetcher.ForApproach(approach);

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetLogForType: Checking whether the variable, 'fetcher', has a null reference for a value..."
                );

                // Check to see if the variable, 'fetcher', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (fetcher == null)
                {
                    // The variable, 'fetcher', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.GetLogForType: *** ERROR ***  The variable, 'fetcher', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientLogProvider.GetLogForType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'fetcher', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetLogForType: *** SUCCESS *** The variable, 'fetcher', has a valid object reference for its value.  Proceeding..."
                );

                result = fetcher.FetchLogger(sourceType, GetCurrentClientSessionRepositoryName());
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to the session-logger fetcher for the specified type, '{sourceType?.FullName ?? "<null>"}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to the session-logger fetcher for the specified type, '{sourceType?.FullName ?? "<null>"}'.  Stopping..."
            );

            return result;
        }

        private string GetCurrentClientSessionRepositoryName()
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetCurrentClientSessionRepositoryName: *** FYI *** Getting the repository name to use for the current client session (if any)..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetCurrentClientSessionRepositoryName: Checking whether the property, 'CurrentClientSession', has a null reference for a value..."
                );

                // Check to see if the required property, 'CurrentClientSession', has a null
                // reference for a value.  If that is the case, then we will write an error message
                // to the Debug output, and then terminate the execution of this method, while
                // returning the default return value.
                if (CurrentClientSession == null)
                {
                    // The property, 'CurrentClientSession', has a null reference for a value.  This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.GetCurrentClientSessionRepositoryName: *** ERROR *** The property, 'CurrentClientSession', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientLogProvider.GetCurrentClientSessionRepositoryName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetCurrentClientSessionRepositoryName: *** SUCCESS *** The property, 'CurrentClientSession', has a valid object reference for its value.  Proceeding..."
                );

                result = CurrentClientSession.RepositoryName;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            return result;
        }
    }
}