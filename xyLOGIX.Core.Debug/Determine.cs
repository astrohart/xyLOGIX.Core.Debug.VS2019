using Alphaleonis.Win32.Filesystem;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods to determine whether program flow is to follow a given
    /// path based on data, or other value(s) that are dependent on yet other data.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class Determine
    {
        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderManager" /> interface.
        /// </summary>
        private static IAppenderManager AppenderManager
        {
            [DebuggerStepThrough] get;
        } = GetAppenderManager.SoleInstance();

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
        internal static LoggingConfiguratorType LoggingConfiguratorTypeToUse(
            string logFileName
        )
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

                // Check whether the value of the parameter, 'logFileName', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(logFileName))
                {
                    // The parameter, 'logFileName' was either passed a null value, or it is blank.  This means that
                    // the output of this method is to be set to 'LoggingConfiguratorType.FromConfigFile'.
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
        /// Attempts to determine which of the
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration
        /// value(s) most likely pertain to the situation at hand.
        /// </summary>
        /// <param name="loggerRepository">
        /// (Optional.) Reference to an instance of an object that implements the
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
        internal static RootLoggerProvisioningStrategy
            TheRootLoggerProvisioningStrategyToUse(
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
                    "Determine.TheRootLoggerProvisioningStrategyToUse: Checking whether the required method parameter, 'loggerRepository', has a null reference for a value..."
                );

                // Check to see if the required method parameter, loggerRepository, is null. If it is, send an
                // error to the log file and quit, returning the default return value of this
                // method.
                if (loggerRepository == null)
                {
                    // The parameter, 'loggerRepository', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "Determine.TheRootLoggerProvisioningStrategyToUse: *** ERROR *** A null reference was passed for the required method parameter, 'loggerRepository'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Determine.TheRootLoggerProvisioningStrategyToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheRootLoggerProvisioningStrategyToUse: *** SUCCESS *** We have been passed a valid object reference for the required method parameter, 'loggerRepository'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** Determine.TheRootLoggerProvisioningStrategyToUse: Checking whether the provided Logger Repository is a Hierarchy..."
                );

                // Check to see whether the provided Logger Repository is a Hierarchy.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!(loggerRepository is Hierarchy))
                {
                    // The provided Logger Repository is NOT a Hierarchy.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The provided Logger Repository is NOT a Hierarchy.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Determine.TheRootLoggerProvisioningStrategyToUse: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Determine.TheRootLoggerProvisioningStrategyToUse: *** SUCCESS *** The provided Logger Repository is a Hierarchy.  Proceeding..."
                );

                result = RootLoggerProvisioningStrategy
                    .FromProvidedLoggingRepository;
            }
            catch (Exception ex)
            {
                // dump all exception info to the log.
                System.Diagnostics.Debug.WriteLine(ex);

                result = RootLoggerProvisioningStrategy.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Determine.TheRootLoggerProvisioningStrategyToUse: Result = '{result}'"
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
        internal static XmlLoggingConfiguratorType
            XmlLoggingConfiguratorTypeToUse(
                [NotLogged] string configurationFileName
            )
        {
            var result = XmlLoggingConfiguratorType.Unknown;

            try
            {
                // Check whether the path to the configuration file is blank; or, if
                // it's not blank, whether the specified file actually exists at the
                // path indicated. If the configuration file pathname is blank
                // and/or it does not exist at the path indicated, then call the
                // version of XmlConfigurator.Configure that does not take any
                // arguments. On the other hand, if the configurationFileName
                // parameter is not blank, and it specifies a file that actually
                // does exist at the specified path, then pass that path to the
                // XmlConfigurator.Configure method.
                if (string.IsNullOrWhiteSpace(configurationFileName) ||
                    !File.Exists(configurationFileName))
                {
                    result = XmlLoggingConfiguratorType.NoFile;
                }
                else if (!string.IsNullOrWhiteSpace(configurationFileName) &&
                         File.Exists(configurationFileName))
                {
                    result = XmlLoggingConfiguratorType.FileBased;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = XmlLoggingConfiguratorType.Unknown;
            }

            return result;
        }
    }
}