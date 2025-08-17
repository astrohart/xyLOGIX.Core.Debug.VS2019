using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// <c>Logging Configurator</c> file that sets up logging based on setting(s) that
    /// are found in an <c>app.config</c> or a <c>web.config</c> file.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal class FromConfigFileLoggingConfigurator : LoggingConfiguratorBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static FromConfigFileLoggingConfigurator() { }

        /// <summary>
        /// Empty, <see langword="private" /> constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        private FromConfigFileLoggingConfigurator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfigurator" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile" />
        /// <c>Logging Configurator Type</c>.
        /// </summary>
        internal static ILoggingConfigurator Instance
        {
            [DebuggerStepThrough] get;
        } = new FromConfigFileLoggingConfigurator();

        /// <summary>
        /// Gets or sets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingConfiguratorType" /> enumeration
        /// value(s) that indicates which type of configuration this
        /// <c>Logging Configurator</c> does.
        /// </summary>
        public override LoggingConfiguratorType Type
        {
            [DebuggerStepThrough] get;
        } = LoggingConfiguratorType.FromConfigFile;

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator" />
        /// interface.
        /// </summary>
        private static IXmlLoggingConfiguratorTypeValidator
            XmlLoggingConfiguratorTypeValidator { [DebuggerStepThrough] get; } =
            GetXmlLoggingConfiguratorTypeValidator.SoleInstance();

        /// <summary> Initializes the application's logging subsystem.</summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// Set to <see langword="true" /> if we
        /// should not write out <c>DEBUG</c> messages to the <c>Debug</c> output when in
        /// the
        /// <c>Release</c> mode. Set to <see langword="false" /> if all messages should
        /// always be logged.
        /// </param>
        /// <param name="overwrite">
        /// Overwrites any existing logs for the application with
        /// the latest logging sent out by this instance.
        /// </param>
        /// <param name="configurationFileName">
        /// Specifies the path to the
        /// configuration file to be utilized for initializing log4net. If blank, the
        /// system attempts to utilize the default App.config file.
        /// </param>
        /// <param name="muteConsole">
        /// Set to <see langword="true" /> to suppress the
        /// display of logging messages to the console if a log file is being used. If a
        /// log file is not used, then no logging at all will occur if this parameter is
        /// set to <see langword="true" />.
        /// </param>
        /// <param name="logFileName">
        /// (Optional.) If blank, then the
        /// <c>XMLConfigurator</c> object is used to configure logging.
        /// <para />
        /// Else, specify here the path to the <c>Debug</c> output to be created.
        /// </param>
        /// <param name="verbosity">
        /// (Optional.) An <see cref="T:System.Int32" /> whose
        /// value must be <c>0</c> or greater.
        /// <para />
        /// Indicates the verbosity level.
        /// <para />
        /// Higher values mean more verbose.
        /// <para />
        /// if the <paramref name="verbosity" /> parameter is negative, it will be ignored.
        /// <para />
        /// The default value of this parameter is <c>1</c>.
        /// </param>
        /// <param name="applicationName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing a user-friendly display name of the application that is using this
        /// logging library.
        /// <para />
        /// Leave blank to use the default value.
        /// </param>
        /// <param name="repository">
        /// (Optional.) Reference to an instance of an object
        /// that implements the <see cref="T:log4net.Repository.ILoggerRepository" />
        /// interface. Supply a value for this parameter if your infrastructure is not
        /// utilizing the default HierarchicalRepository.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the configuration operation(s) succeeded;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public override bool Configure(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            string configurationFileName = "",
            bool muteConsole = false,
            string logFileName = "",
            int verbosity = 1,
            string applicationName = "",
            ILoggerRepository repository = null
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "FromConfigFileLoggingConfigurator.Configure: *** FYI *** Configuring the logging using app.config..."
                );

                var xmlLoggingConfiguratorType =
                    Determine.XmlLoggingConfiguratorTypeToUse(
                        configurationFileName
                    );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FromConfigFileLoggingConfigurator.Configure: Checking whether the particular XML Logging Configurator Type value, '{xmlLoggingConfiguratorType}', is within the defined value set..."
                );

                // Check to see whether the particular XML Logging Configurator Type value
                // is within the defined value set.  If this is not the case, then write an
                // error message to the Debug output and then terminate the execution of this method.
                if (!XmlLoggingConfiguratorTypeValidator.IsValid(
                        xmlLoggingConfiguratorType
                    ))
                {
                    // The particular XML Logging Configurator Type value is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR: The particular XML Logging Configurator Type value, '{xmlLoggingConfiguratorType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"FromConfigFileLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"FromConfigFileLoggingConfigurator.Configure: *** SUCCESS *** The particular XML Logging Configurator Type value, '{xmlLoggingConfiguratorType}', is within the defined value set.  Proceeding..."
                );

                var xmlLoggingConfigurator =
                    GetXmlLoggingConfigurator.For(xmlLoggingConfiguratorType);

                System.Diagnostics.Debug.WriteLine(
                    "FromConfigFileLoggingConfigurator.Configure: Checking whether the variable 'xmlLoggingConfigurator' has a null reference for a value..."
                );

                // Check to see if the variable, xmlLoggingConfigurator, is null. If it is,
                // send an error to the log file and quit, returning from the method.
                if (xmlLoggingConfigurator == null)
                {
                    // the variable xmlLoggingConfigurator is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "FromConfigFileLoggingConfigurator.Configure: *** ERROR ***  The 'xmlLoggingConfigurator' variable has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"FromConfigFileLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, xmlLoggingConfigurator, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "FromConfigFileLoggingConfigurator.Configure: *** SUCCESS *** The 'xmlLoggingConfigurator' variable has a valid object reference for its value.  Proceeding..."
                );

                result = xmlLoggingConfigurator.Configure(
                    repository, configurationFileName
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"FromConfigFileLoggingConfigurator.Configure: Result = {result}"
            );

            return result;
        }
    }
}
