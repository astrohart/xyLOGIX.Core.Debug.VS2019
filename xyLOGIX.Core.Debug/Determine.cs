using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods to determine whether program flow is to follow a given
    /// path based on data, or other value(s) that are dependent on yet other data.
    /// </summary>
    public static class Determine
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Determine" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Determine() { }

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
        public static LoggingConfiguratorType LoggingConfiguratorTypeToUse(
            string logFileName
        )
        {
            var result = LoggingConfiguratorType.Unknown;

            try
            {
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
                        "Determine.LoggingConfiguratorTypeToUse: The parameter, 'logFileName' was either passed a null value, or it is blank. Setting the output to 'LoggingConfiguratorType.FromConfigFile'..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Determine.LoggingConfiguratorTypeToUse: Result = '{LoggingConfiguratorType.FromConfigFile}'"
                    );

                    // stop.
                    return LoggingConfiguratorType.FromConfigFile;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'logFileName' is not blank.  Setting the output to 'LoggingConfiguratorType.Programmatic'..."
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
        public static XmlLoggingConfiguratorType
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