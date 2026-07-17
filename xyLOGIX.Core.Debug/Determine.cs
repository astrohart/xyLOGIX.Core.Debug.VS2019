using Alphaleonis.Win32.Filesystem;
using log4net;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static method(s) to determine whether program flow is to
    /// follow a given path based on data, or other value(s) that are dependent on yet
    /// other data.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class Determine
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.Determine" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Determine() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderManager" /> interface.
        /// </summary>
        private static IAppenderManager AppenderManager { [DebuggerStepThrough] get; } =
            GetAppenderManager.SoleInstance();

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
        /// Determines whether the application is to use a programmatic logging
        /// configurator or configure logging from either the <c>app.config</c> or
        /// <c>web.config</c> file(s).
        /// <para />
        /// It all hinges on whether a <paramref name="logFileName" /> is already known at
        /// this juncture or not.
        /// </summary>
        /// <param name="logFileName">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the programmatically-configured, fully-qualified pathname of the file
        /// to which logging is to be written.
        /// </param>
        /// <returns>
        /// If the value of the <paramref name="logFileName" /> parameter is not
        /// blank, then the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingConfiguratorType.Programmatic" /> value
        /// is returned; otherwise, the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile" />
        /// value is returned.
        /// </returns>
        internal static LoggingConfiguratorType LoggingConfiguratorTypeToUse(string logFileName)
        {
            var result = LoggingConfiguratorType.Unknown;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "Determine.LoggingConfiguratorTypeToUse: *** FYI *** Attempting to determine which type of Logging Configurator to use..."
                );

                // Dump the value of the variable, logFileName, to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"Determine.LoggingConfiguratorTypeToUse: logFileName = '{logFileName}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Determine.LoggingConfiguratorTypeToUse *** INFO: Checking whether the value of the parameter, 'logFileName', is blank..."
                );

                // Check whether the value of the parameter, 'logFileName', is blank. If this is so,
                // then emit an error message to the log file, and then terminate the execution of
                // this method.
                if (string.IsNullOrWhiteSpace(logFileName))
                {
                    // The parameter, 'logFileName' was either passed a null value, or it is blank.
                    // This means that the output of this method is to be set to
                    // 'LoggingConfiguratorType.FromConfigFile'.
                    System.Diagnostics.Debug.WriteLine(
                        "Determine.LoggingConfiguratorTypeToUse: The parameter, 'logFileName' was either passed a null value, or it is blank. Setting the result to 'LoggingConfiguratorType.FromConfigFile'..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.LoggingConfiguratorTypeToUse: Result = '{LoggingConfiguratorType.FromConfigFile}'"
                    );

                    // stop.
                    return LoggingConfiguratorType.FromConfigFile;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'logFileName' is not blank.  Setting the result to 'LoggingConfiguratorType.Programmatic'..."
                );

                result = LoggingConfiguratorType.Programmatic;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = LoggingConfiguratorType.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Determine.LoggingConfiguratorTypeToUse: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Determines the correct
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the handler strategy to be utilized for the
        /// current state of a logging-client logger-cache entry.
        /// </summary>
        /// <param name="loggerWasFound">
        /// (Required.) A <see cref="T:System.Boolean" />
        /// value that indicates whether an entry corresponding to the specified cache key
        /// was found.
        /// </param>
        /// <param name="cachedLogger">
        /// (Optional.) Reference to an instance of an object
        /// that implements the <see cref="T:log4net.ILog" /> interface that was obtained
        /// from the cache.
        /// </param>
        /// <remarks>
        /// If <paramref name="loggerWasFound" /> is <see langword="false" />, then this
        /// method returns
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger" />
        /// .
        /// <para />
        /// If <paramref name="loggerWasFound" /> is <see langword="true" /> and
        /// <paramref name="cachedLogger" /> has a <see langword="null" /> reference for a
        /// value, then this method returns
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger" />
        /// .
        /// <para />
        /// If <paramref name="loggerWasFound" /> is <see langword="true" /> and
        /// <paramref name="cachedLogger" /> has a valid object reference for a value, then
        /// this method returns
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger" />
        /// .
        /// <para />
        /// If the correct handler strategy cannot be determined, or an error occurs, then
        /// this method returns
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown" />
        /// .
        /// </remarks>
        /// <returns>
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value(s) that identifies the correct handler strategy to utilize;
        /// otherwise,
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown" />
        /// is returned.
        /// </returns>
        [DebuggerStepThrough]
        internal static LoggingClientLoggerCacheAddHandlerType
            TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse(
                bool loggerWasFound,
                [NotLogged] ILog cachedLogger
            )
        {
            var result = LoggingClientLoggerCacheAddHandlerType.Unknown;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: loggerWasFound = {loggerWasFound}"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: Checking whether a logger corresponding to the specified cache key was found..."
                );

                // Check whether a logger corresponding to the specified cache key was found. If
                // this is not the case, then the MissingLogger handler strategy is the correct
                // strategy to utilize.
                if (!loggerWasFound)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: *** INFO *** A logger corresponding to the specified cache key was not found.  Selecting the MissingLogger handler strategy..."
                    );

                    result = LoggingClientLoggerCacheAddHandlerType.MissingLogger;

                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: *** SUCCESS *** A cache entry corresponding to the specified cache key was found.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: Checking whether the cached logger has a null reference for a value..."
                );

                // Check whether the cached logger has a null reference for a value. If this is the
                // case, then the NullLogger handler strategy is the correct strategy to utilize.
                if (cachedLogger == null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: *** WARNING *** The cache entry contains a null logger reference.  Selecting the NullLogger handler strategy..."
                    );

                    result = LoggingClientLoggerCacheAddHandlerType.NullLogger;

                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: *** SUCCESS *** The cached logger has a valid object reference for its value.  Selecting the ExistingLogger handler strategy..."
                );

                result = LoggingClientLoggerCacheAddHandlerType.ExistingLogger;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = LoggingClientLoggerCacheAddHandlerType.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Determines the correct
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration
        /// value that is to be returned, that corresponds to the correct approach that is
        /// to be utilized in getting a logger for the specified
        /// <paramref name="sourceType" />.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) A <see cref="T:System.Type" /> that
        /// contains the type of the object for which a logger is to be fetched.
        /// </param>
        /// <returns>
        /// If successful, returns one of the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> value(s) that
        /// indicates the correct approach for fetching a logger that is to be used for the
        /// specified <paramref name="sourceType" />; otherwise, the
        /// <see cref="F:xyLOGIX.Core.Debug.SessionLoggerFetchApproach.Unknown" /> value is
        /// returned if such an approach cannot be determined otherwise.
        /// </returns>
        public static SessionLoggerFetchApproach TheCorrectSessionLoggerFetchApproachToUse(
            [NotLogged] Type sourceType
        )
        {
            var result = SessionLoggerFetchApproach.Unknown;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Determine.TheCorrectSessionLoggerFetchApproachToUse: *** FYI *** Determining the correct session logger fetch approach to use for the specified sourceType, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectSessionLoggerFetchApproachToUse: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "Determine.TheCorrectSessionLoggerFetchApproachToUse: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    result = SessionLoggerFetchApproach.Unknown;

                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.TheCorrectSessionLoggerFetchApproachToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectSessionLoggerFetchApproachToUse: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'sourceType.FullName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'sourceType.FullName', appears to have a
                // null or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(sourceType.FullName))
                {
                    // The property, 'sourceType.FullName', appears to have a null or blank value.
                    // This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'sourceType.FullName', appears to have a null or blank value.  Stopping..."
                    );

                    result = SessionLoggerFetchApproach.Unknown;

                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.TheCorrectSessionLoggerFetchApproachToUse: Result = '{result}'"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'sourceType.FullName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectSessionLoggerFetchApproachToUse: Checking whether the property, 'CurrentClientSession', has a null reference for a value..."
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
                        "Determine.TheCorrectSessionLoggerFetchApproachToUse: *** WARNING *** The property, 'CurrentClientSession', has a null reference for a value.  Using the legacy logging infrastructure..."
                    );

                    /* When there is no active client session, the default behavior of this library
                     must prevail; therefore, get the legacy logger. */

                    result = SessionLoggerFetchApproach.FetchLegacyLogger;

                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.TheCorrectSessionLoggerFetchApproachToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectSessionLoggerFetchApproachToUse: *** SUCCESS *** The property, 'CurrentClientSession', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectSessionLoggerFetchApproachToUse: Checking whether the current logging-client session has valid setting(s)..."
                );

                // Check to see whether the current logging-client session has valid setting(s). If
                // this is not the case, then write an error message to the log file, and then
                // terminate the execution of this method.
                if (!CurrentClientSession.IsValid())
                {
                    // The current logging-client session does NOT appear to have valid setting(s).
                    // Using the legacy logging infrastructure.
                    System.Diagnostics.Debug.WriteLine(
                        "Determine.TheCorrectSessionLoggerFetchApproachToUse: *** ERROR *** The current logging-client session does NOT appear to have valid setting(s).  Using the legacy logging infrastructure..."
                    );

                    result = SessionLoggerFetchApproach.FetchLegacyLogger;

                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.TheCorrectSessionLoggerFetchApproachToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectSessionLoggerFetchApproachToUse: *** SUCCESS *** The current logging-client session has valid setting(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'CurrentClientSession.RepositoryName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'CurrentClientSession.RepositoryName',
                // appears to have a null or blank value. If it does, then send an error to the log
                // file and quit, returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(CurrentClientSession.RepositoryName))
                {
                    // The property, 'CurrentClientSession.RepositoryName', appears to have a null
                    // or blank value.  Using the legacy logging infrastructure.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR: The property, 'CurrentClientSession.RepositoryName', appears to have a null or blank value.  Using the cached logger for the current type, '{sourceType.FullName}', if available..."
                    );

                    result = SessionLoggerFetchApproach.FetchFromCache;

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.TheCorrectSessionLoggerFetchApproachToUse: Result = '{result}'"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'CurrentClientSession.RepositoryName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Determining that the correct logger should be fetched by the repository name, '{CurrentClientSession.RepositoryName}', and source type, '{sourceType.FullName}..."
                );

                result = SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = SessionLoggerFetchApproach.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Determine.TheCorrectSessionLoggerFetchApproachToUse: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Determines the proper
        /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> enumeration
        /// value that is to be used to choose the XML-based logging subsystem
        /// configuration strategy, given the presence (or lack thereof) of an
        /// <c>app.config</c> or <c>web.config</c> file having the specified
        /// <paramref name="configurationFileName" />.
        /// </summary>
        /// <param name="configurationFileName">
        /// (Required.) A
        /// <see cref="T:System.String" /> containing the fully-qualified pathname of the
        /// <c>app.config</c> or <c>web.config</c> that has logging-subsystem configuration
        /// setting(s) in it.
        /// </param>
        /// <returns>
        /// If successful, one of the
        /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> enumeration
        /// value(s) that is to be used to choose the XML-based logging subsystem
        /// configuration strategy, given the presence (or lack thereof) of an
        /// <c>app.config</c> or <c>web.config</c> file having the specified
        /// <paramref name="configurationFileName" />; if we cannot make this determination
        /// with the information provided, then the
        /// <see cref="F:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.Unknown" /> value is
        /// returned.
        /// </returns>
        [DebuggerStepThrough]
        internal static XmlLoggingConfiguratorType TheCorrectXmlLoggingConfiguratorTypeToUse(
            [NotLogged] string configurationFileName
        )
        {
            var result = XmlLoggingConfiguratorType.Unknown;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Determine.TheCorrectXmlLoggingConfiguratorTypeToUse: *** FYI *** Determining the correct XmlLoggingConfiguratorType to use for the specified configuration file, '{configurationFileName}'..."
                );

                // Check whether the path to the configuration file is blank; or, if it's not blank,
                // whether the specified file actually exists at the path indicated. If the
                // configuration file pathname is blank and/or it does not exist at the path
                // indicated, then call the version of XmlConfigurator.Configure that does not take
                // any arguments. On the other hand, if the configurationFileName parameter is not
                // blank, and it specifies a file that actually does exist at the specified path,
                // then pass that path to the XmlConfigurator.Configure method.

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Checking whether the configuration file, '{configurationFileName}', exists at the specified path..."
                );

                if (string.IsNullOrWhiteSpace(configurationFileName) ||
                    !File.Exists(configurationFileName))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Either the configuration file pathname, '{configurationFileName}', is blank, or it does not refer to a file that can be located on the file system at the specified path.  Returning 'XmlLoggingConfiguratorType.NoFile'..."
                    );

                    result = XmlLoggingConfiguratorType.NoFile;
                }
                else if (!string.IsNullOrWhiteSpace(configurationFileName) &&
                         File.Exists(configurationFileName))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** We have been passed a non-blank configuration file pathname, '{configurationFileName}', and the file exists on the file system at the specified path.  Returning 'XmlLoggingConfiguratorType.FileBased'..."
                    );

                    result = XmlLoggingConfiguratorType.FileBased;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = XmlLoggingConfiguratorType.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Determine.TheCorrectXmlLoggingConfiguratorTypeToUse: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Attempts to determine which of the
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration
        /// value(s) most likely pertain to the situation at hand.
        /// </summary>
        /// <param name="loggerRepository">
        /// (Optional.) Reference to an instance of an
        /// object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// <para />
        /// Can be set to a <see langword="null" /> reference.
        /// <para />
        /// The default value of this parameter is a <see langword="null" /> reference.
        /// </param>
        /// <returns>
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration
        /// value(s) that most likely pertains to the situation at hand, or the
        /// <see cref="F:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.Unknown" /> if
        /// such a value cannot be ascertained.
        /// </returns>
        internal static RootLoggerProvisioningStrategy TheCorrectRootLoggerProvisioningStrategyToUse(
            ILoggerRepository loggerRepository = null
        )
        {
            var result = RootLoggerProvisioningStrategy.FromLogManager;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to determine which Root Logger Provisioning Strategy to use..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectRootLoggerProvisioningStrategyToUse: Checking whether the required method parameter, 'loggerRepository', has a null reference for a value..."
                );

                // Check to see if the required method parameter, loggerRepository, is null. If it
                // is, send an error to the log file and quit, returning the default return value of
                // this method.
                if (loggerRepository == null)
                {
                    // The parameter, 'loggerRepository', is required and is not supposed to have a
                    // NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "Determine.TheCorrectRootLoggerProvisioningStrategyToUse: *** ERROR *** A null reference was passed for the required method parameter, 'loggerRepository'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Determine.TheCorrectRootLoggerProvisioningStrategyToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectRootLoggerProvisioningStrategyToUse: *** SUCCESS *** We have been passed a valid object reference for the required method parameter, 'loggerRepository'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** Determine.TheCorrectRootLoggerProvisioningStrategyToUse: Checking whether the provided Logger Repository is a Hierarchy..."
                );

                // Check to see whether the provided Logger Repository is a Hierarchy. If this is
                // not the case, then write an error message to the log file, and then terminate the
                // execution of this method.
                if (!(loggerRepository is Hierarchy))
                {
                    // The provided Logger Repository is NOT a Hierarchy.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The provided Logger Repository is NOT a Hierarchy.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Determine.TheCorrectRootLoggerProvisioningStrategyToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheCorrectRootLoggerProvisioningStrategyToUse: *** SUCCESS *** The provided Logger Repository is a Hierarchy.  Proceeding..."
                );

                result = RootLoggerProvisioningStrategy.FromProvidedLoggingRepository;
            }
            catch (Exception ex)
            {
                // dump all exception info to the log.
                System.Diagnostics.Debug.WriteLine(ex);

                result = RootLoggerProvisioningStrategy.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Determine.TheCorrectRootLoggerProvisioningStrategyToUse: Result = '{result}'"
            );

            return result;
        }
    }
}