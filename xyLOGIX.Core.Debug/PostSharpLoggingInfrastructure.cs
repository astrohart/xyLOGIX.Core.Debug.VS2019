using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;

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
        /// object that implements the <see
        /// cref="T:log4net.Repository.ILoggerRepository"/> interface.
        /// </remarks>
        private ILoggerRepository _relay;

        /// <summary>
        /// Gets the <see
        /// cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType"/> value that
        /// corresponds to the type of infrastructure that is being utilized.
        /// </summary>
        public override LoggingInfrastructureType Type =>
            LoggingInfrastructureType.PostSharp;

        /// <summary>
        /// Gets the value of the <see
        /// cref="P:log4net.Appender.FileAppender.File"/> property from the
        /// first appender in the list of appenders that is of type <see cref="T:log4net.Appender.FileAppender"/>.
        /// </summary>
        /// <returns>
        /// String containing the full path and file name of the file the
        /// appender is writing to.
        /// </returns>
        /// <remarks>
        /// This method is solely utilized in order to implement the <see
        /// cref="P:xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFilePath"/> property.
        /// </remarks>
        public override string GetRootFileAppenderFileName() =>
            FileAppenderManager.GetFirstAppender(_relay)?.File;

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
        /// then no logging at all will occur if this parameter is set to <see langword="true" />.
        /// </param>
        /// <param name="repository">
        /// (Optional.) Reference to an instance of an object that implements
        /// the <see cref="T:log4net.Repository.ILoggerRepository"/> interface.
        /// Supply a value for this parameter if your infrastructure is not
        /// utilizing the default HierarchicalRepository.
        /// </param>
        /// <remarks>
        /// This override bolts the PostSharp aspect-oriented-programming
        /// infrastructure up into our already well-crafted logging
        /// infrastructure by switching out the <see cref="T:log4net.Repository.ILoggerRepository"/>
        /// -implementing object that will tie our logging framework to PostSharp.
        /// </remarks>
        public override void InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true, bool overwrite = true,
            string configurationFilePathname = "", bool muteConsole = false,
            ILoggerRepository repository = null)
        {
            // This sets the PostSharp repository selector as the active log4net
            // repository selector. All loggers created from log4net static
            // methods, and all logger repositories created from now on will
            // come from this repository selector.
            //
            // This repository selector creates loggers that send all logging
            // events to PostSharp Logging.
            //
            // The relay repository returned by the RedirectLoggingToPostSharp
            // method creates loggers that are *not* redirected to PostSharp
            // Logging and it serves as the repository for your final output loggers.
            _relay = Log4NetCollectingRepositorySelector
                .RedirectLoggingToPostSharp();

            base.InitializeLogging(
                muteDebugLevelIfReleaseMode, overwrite,
                configurationFilePathname, muteConsole, _relay
            );

            // Use the relay repository to create a Log4NetLoggingBackend and
            // set it as the default backend:
            LoggingServices.DefaultBackend = new Log4NetLoggingBackend(_relay);

            PrepareLogFile(overwrite, _relay);
        }
    }
}