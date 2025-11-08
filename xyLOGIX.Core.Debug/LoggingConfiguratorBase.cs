using log4net.Repository;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all
    /// <c>Logging Configurator</c> object(s).
    /// </summary>
    internal abstract class LoggingConfiguratorBase : ILoggingConfigurator
    {
        /// <summary>
        /// Gets or sets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingConfiguratorType" /> enumeration
        /// value(s) that indicates which type of configuration this
        /// <c>Logging Configurator</c> does.
        /// </summary>
        public abstract LoggingConfiguratorType Type
        {
            [DebuggerStepThrough] get;
        }

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
        public abstract bool Configure(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            string configurationFileName = "",
            bool muteConsole = false,
            string logFileName = "",
            int verbosity = 1,
            string applicationName = "",
            ILoggerRepository repository = null
        );
    }
}