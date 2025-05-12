using log4net.Repository;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the methods and properties of a custom object to which the
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingSubsystemManager" /> delegates the
    /// implementation
    /// of its properties and methods.
    /// </summary>
    public interface ILoggingInfrastructure
    {
        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the fully-qualified pathname
        /// of the log file of this application.
        /// </summary>
        string LogFileName { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> value
        /// that
        /// corresponds to the type of infrastructure that is being utilized.
        /// </summary>
        LoggingInfrastructureType Type { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets the value of the
        /// <see cref="P:log4net.Appender.FileAppender.File" /> property from the first
        /// appender in the list of appenders that is of type
        /// <see cref="T:log4net.Appender.FileAppender" />.
        /// </summary>
        /// <returns>
        /// String containing the full path and file name of the file the
        /// appender is writing to.
        /// </returns>
        /// <remarks>
        /// This method is solely utilized in order to implement the
        /// <see cref="P:Core.Debug.ILoggingInfrastructure.LogFileName" /> property.
        /// </remarks>
        string GetRootFileAppenderFileName();

        /// <summary> Initializes the application's logging subsystem. </summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// Set to true if we should not write
        /// out "DEBUG" messages to the log file when in the Release mode. Set to false if
        /// all messages should always be logged.
        /// </param>
        /// <param name="overwrite">
        /// Overwrites any existing logs for the application with
        /// the latest logging sent out by this instance.
        /// </param>
        /// <param name="configurationFileNamename">
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
        /// <see langword="true" /> if the logging subsystem initialization
        /// process completed successfully; <see langword="false" /> otherwise.
        /// </returns>
        bool InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            string configurationFileNamename = "",
            bool muteConsole = false,
            string logFileName = "",
            int verbosity = 1,
            string applicationName = "",
            ILoggerRepository repository = null
        );

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFileName" />
        /// property has been updated.
        /// </summary>
        event EventHandler LogFileNameChanged;

        /// <summary>
        /// Occurs when the initialization of the logging subsystem has been completed.
        /// </summary>
        event EventHandler LoggingInitializationFinished;

        /// <summary>
        /// Sets up the <see cref="T:xyLOGIX.Core.Debug.DebugUtils" /> to initialize
        /// its functionality.
        /// </summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// If set to true, does not echo any
        /// logging statements that are set to <see cref="F:DebugLevel.Debug" />.
        /// </param>
        /// <param name="isLogging">
        /// True to activate the functionality of writing to a log
        /// file; false to suppress. Usually used with the <paramref name="consoleOnly" />
        /// parameter set to <see langword="true" />.
        /// </param>
        /// <param name="consoleOnly">
        /// True to only write messages to the console; false to
        /// write them both to the console and to the log.
        /// </param>
        /// <param name="verbosity">
        /// Zero to suppress every message; greater than zero to
        /// echo every message.
        /// </param>
        /// <param name="muteConsole">
        /// If set to <see langword="true" />, suppresses all
        /// console output.
        /// </param>
        bool SetUpDebugUtils(
            bool muteDebugLevelIfReleaseMode,
            bool isLogging = true,
            bool consoleOnly = false,
            int verbosity = 1,
            bool muteConsole = false
        );
    }
}