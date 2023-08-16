using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;

#if DEBUG

#else
using System;
#endif

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Implements log-file management for the case when we are utilizing
    /// PostSharp aspects to handle the bulk of logging for us.
    /// </summary>
    public class PostSharpLoggingInfrastructure : DefaultLoggingInfrastructure
    {
        /// <summary>
        /// Reference to the object that relays all logging to PostSharp.
        /// </summary>
        /// <remarks>
        /// This field can only be set to a reference to an instance of an
        /// object that implements the
        /// <see
        ///     cref="T:log4net.Repository.ILoggerRepository" />
        /// interface.
        /// </remarks>
        private ILoggerRepository _relay;

        /// <summary>
        /// Gets the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType" />
        /// value that
        /// corresponds to the type of infrastructure that is being utilized.
        /// </summary>
        public override LoggingInfrastructureType Type
            => LoggingInfrastructureType.PostSharp;

        /// <summary>
        /// Gets the value of the
        /// <see
        ///     cref="P:log4net.Appender.FileAppender.File" />
        /// property from the
        /// first appender in the list of appenders that is of type
        /// <see cref="T:log4net.Appender.FileAppender" />.
        /// </summary>
        /// <returns>
        /// String containing the full path and file name of the file the
        /// appender is writing to.
        /// </returns>
        /// <remarks>
        /// This method is solely utilized in order to implement the
        /// <see
        ///     cref="P:Core.Debug.ILoggingInfrastructure.LogFilePath" />
        /// property.
        /// </remarks>
        public override string GetRootFileAppenderFileName()
            => FileAppenderManager.GetFirstAppender(_relay)
                                  ?.File;

        /// <summary>
        /// Initializes the application's logging subsystem.
        /// </summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// Set to true if we should not write out "DEBUG" messages to the log
        /// file when in the Release mode. Set to false if all messages should
        /// always be logged.
        /// </param>
        /// <param name="overwrite">
        /// Overwrites any existing logs for the application with the latest
        /// logging sent out by this instance.
        /// </param>
        /// <param name="configurationFilePathname">
        /// Specifies the path to the configuration file to be utilized for
        /// initializing log4net. If blank, the system attempts to utilize the
        /// default App.config file.
        /// </param>
        /// <param name="muteConsole">
        /// Set to <see langword="true" /> to suppress the display of logging messages to
        /// the console if a log file is being used. If a log file is not used,
        /// then no logging at all will occur if this parameter is set to
        /// <see langword="true" />.
        /// </param>
        /// <param name="logFileName">
        /// (Optional.) If blank, then the <c>XMLConfigurator</c>
        /// object is used to configure logging.
        /// <para />
        /// Else, specify here the path to the log file to be created.
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
        /// (Required.) A <see cref="T:System.String" /> containing a user-friendly display
        /// name of the application that is using this logging library.
        /// <para />
        /// Leave blank to use the default value.
        /// </param>
        /// <param name="repository">
        /// (Optional.) Reference to an instance of an object that implements
        /// the <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// Supply a value for this parameter if your infrastructure is not
        /// utilizing the default HierarchicalRepository.
        /// </param>
        public override void InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true, bool overwrite = true,
            string configurationFilePathname = "", bool muteConsole = false,
            string logFileName = "", int verbosity = 1,
            string applicationName = "", ILoggerRepository repository = null)
        {
            if (_relay != null)

                // logging is already configured
                return;

            _relay = _relay ?? Log4NetCollectingRepositorySelector
                .RedirectLoggingToPostSharp();

            base.InitializeLogging(
                muteDebugLevelIfReleaseMode, overwrite,
                configurationFilePathname, muteConsole, logFileName, verbosity,
                applicationName, _relay
            );

            // set it as the default backend:
            var backend = GetLoggingBackend.For(
                LoggingBackendType.Log4Net, _relay
            );
            LoggingServices.DefaultBackend = backend;
            LoggingServices.Roles[LoggingRoles.Meta]
                           .Backend = backend;

            PrepareLogFile(overwrite, _relay);
        }
    }
}