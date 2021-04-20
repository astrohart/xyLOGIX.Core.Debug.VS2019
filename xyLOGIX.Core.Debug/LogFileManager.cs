namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Methods to be used to manage the application log.
    /// </summary>
    public static class LogFileManager
    {
        /// <summary>
        /// Reference to an instance of the object that implements the <see
        /// cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure"/> interface for
        /// the logging infrastructure type chosen.
        /// </summary>
        /// <remarks>
        /// This is the object that will provide the behind-the-scenes
        /// implementation for this object from now on.
        /// </remarks>
        private static ILoggingInfrastructure _infrastructure;

        /// <summary>
        /// Gets the <see
        /// cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType"/> value that
        /// represents the type of infrastructure currently in use by this <see cref="T:xyLOGIX.Core.Debug.LogFileManager"/>.
        /// </summary>
        public static LoggingInfrastructureType InfrastructureType
            => _infrastructure?.Type ?? LoggingInfrastructureType.Unknown;

        /// <summary>
        /// Gets the full path and filename to the log file for this application.
        /// </summary>
        /// <remarks>
        /// This property should only be called after the <see
        /// cref="M:xyLOGIX.Core.Debug.LogFileManager.InitializeLogging"/>
        /// method has been called.
        /// </remarks>
        public static string LogFilePath
            => _infrastructure?.GetRootFileAppenderFileName();

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
        /// <param name="infrastructureType">
        /// (Optional.) One of the <see
        /// cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType"/> values that
        /// indicates what type of logging infrastructure is to be utilized
        /// (default or PostSharp, for example).
        /// </param>
        public static void InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true, bool overwrite = true,
            string configurationFilePathname = "", bool muteConsole = false,
            LoggingInfrastructureType infrastructureType =
                LoggingInfrastructureType.Default)
        {
            /* We now 'outsource' the functionality of this method (and all the
              other methods of this class) to an 'infrastructure' object that follows (loosely)
             the Abstract Factory pattern.  Either we use the Default way of initializing logging
             or we do things the way PostSharp needs us to.*/
            _infrastructure = _infrastructure ??
                              GetLoggingInfrastructure.For(infrastructureType);

            _infrastructure.InitializeLogging(
                muteDebugLevelIfReleaseMode, overwrite,
                configurationFilePathname, muteConsole
            );
        }

        /// <summary>
        /// Sets up the <see cref="T:xyLOGIX.Core.Debug.DebugUtils"/> to
        /// initialize its functionality.
        /// </summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// If set to true, does not echo any logging statements that are set to
        /// <see cref="DebugLevel.Debug"/>.
        /// </param>
        /// <param name="isLogging">
        /// True to activate the functionality of writing to a log file; false
        /// to suppress. Usually used with the <paramref name="consoleOnly"/>
        /// parameter set to <see langword="true" />.
        /// </param>
        /// <param name="consoleOnly">
        /// True to only write messages to the console; false to write them both
        /// to the console and to the log.
        /// </param>
        /// <param name="verbosity">
        /// Zero to suppress every message; greater than zero to echo every message.
        /// </param>
        /// <param name="muteConsole">
        /// If set to <see langword="true" />, suppresses all console output.
        /// </param>
        /// <param name="infrastructureType">
        /// (Optional.) One of the <see
        /// cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType"/> values that
        /// indicates what type of logging infrastructure is to be utilized
        /// (default or PostSharp).
        /// </param>
        public static void SetUpDebugUtils(bool muteDebugLevelIfReleaseMode,
            bool isLogging = true, bool consoleOnly = false, int verbosity = 1,
            bool muteConsole = false,
            LoggingInfrastructureType infrastructureType =
                LoggingInfrastructureType.Default)
        {
            _infrastructure = _infrastructure ??
                              GetLoggingInfrastructure.For(infrastructureType);

            _infrastructure.SetUpDebugUtils(
                muteDebugLevelIfReleaseMode, isLogging, consoleOnly, verbosity,
                muteConsole
            );
        }
    }
}