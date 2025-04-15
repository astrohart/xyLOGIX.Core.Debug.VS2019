using System.Diagnostics;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Methods to be used to manage the application log. </summary>
    [Log(AttributeExclude = true)]
    public static class LogFileManager
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.LogFileManager" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LogFileManager() { }

        /// <summary>
        /// Gets or sets the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> value
        /// that
        /// represents the type of infrastructure currently in use by this
        /// <see cref="T:xyLOGIX.Core.Debug.LogFileManager" />.
        /// </summary>
        public static LoggingInfrastructureType InfrastructureType { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary> Gets the full path and filename to the log file for this application. </summary>
        /// <remarks>
        /// This property should only be called after the
        /// <see cref="M:xyLOGIX.Core.Debug.LogFileManager.InitializeLogging" /> method has
        /// been
        /// called.
        /// </remarks>
        public static string LogFileName
        {
            [DebuggerStepThrough]
            get
            {
                var result = string.Empty;

                try
                {
                    if (LoggingInfrastructure == null) return result;

                    result = LoggingInfrastructure
                        .GetRootFileAppenderFileName();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = string.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface that
        /// corresponds to the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.LogFileManager.InfrastructureType" /> property.
        /// </summary>
        private static ILoggingInfrastructure LoggingInfrastructure
        {
            [DebuggerStepThrough] get { return GetLoggingInfrastructure.For(InfrastructureType); }
        }

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
        /// <param name="infrastructureType">
        /// (Optional.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> values
        /// that
        /// indicates what type of logging infrastructure is to be utilized (default or
        /// PostSharp, for example).
        /// </param>
        public static void InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            string configurationFileNamename = "",
            bool muteConsole = false,
            string logFileName = "",
            int verbosity = 1,
            string applicationName = "",
            LoggingInfrastructureType infrastructureType =
                LoggingInfrastructureType.Default
        )
        {
            try
            {
                DebugUtils.ClearTempExceptionLog();
                
                if (!Validate.LoggingInfrastructureType(infrastructureType))
                    return;

                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    $"LogFileManager.InitializeLogging: Setting infrastructure type to '{infrastructureType}'..."
                );

                InfrastructureType = infrastructureType;

                /* We now 'outsource' the functionality of this method (and all the
                  other methods of this class) to an 'infrastructure' object that follows (loosely)
                 the Abstract Factory pattern.  Either we use the Default way of initializing logging
                 or we do things the way PostSharp needs us to.*/

                if (LoggingInfrastructure == null)
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"LogFileManager.InitializeLogging: *** ERROR *** Unable to initializing the logging subsystem for the '{InfrastructureType}' logging infrastructure."
                    );
                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    "LogFileManager.InitializeLogging: Proceeding to task the logging infrastructure to initialize itself..."
                );

                LoggingInfrastructure.InitializeLogging(
                    muteDebugLevelIfReleaseMode, overwrite,
                    configurationFileNamename, muteConsole, logFileName,
                    verbosity, applicationName
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

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
        /// <param name="muteConsole">
        /// If set to <see langword="true" />, suppresses all
        /// console output.
        /// </param>
        /// <param name="infrastructureType">
        /// (Optional.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> values
        /// that
        /// indicates what type of logging infrastructure is to be utilized (default or
        /// PostSharp).
        /// </param>
        [DebuggerStepThrough]
        public static void SetUpDebugUtils(
            bool muteDebugLevelIfReleaseMode,
            bool isLogging = true,
            bool consoleOnly = false,
            int verbosity = 1,
            bool muteConsole = false,
            LoggingInfrastructureType infrastructureType =
                LoggingInfrastructureType.Default
        )
        {
            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "LogFileManager.SetUpDebugUtils: Validating infrastructure type..."
                );

                if (LoggingInfrastructureType.Unknown.Equals(
                        infrastructureType
                    )) return;
                if (!Enum.IsDefined(
                        typeof(LoggingInfrastructureType), infrastructureType
                    )) return;

                InfrastructureType = infrastructureType;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** LogFileManager.SetUpDebugUtils: Checking whether the 'LoggingInfrastructure' property has a null reference for a value..."
                );

                // Check to see if the required property, LoggingInfrastructure, is null. If it is, send an
                // error to the log file and quit, returning from the method.
                if (LoggingInfrastructure == null)
                {
                    // the property LoggingInfrastructure is required.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "LogFileManager.SetUpDebugUtils: *** ERROR *** The 'LoggingInfrastructure' property has a null reference.  Stopping."
                    );

                    // stop.
                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "LogFileManager.SetUpDebugUtils: *** SUCCESS *** The 'LoggingInfrastructure' property has a valid object reference for its value."
                );

                LoggingInfrastructure.SetUpDebugUtils(
                    muteDebugLevelIfReleaseMode, isLogging, consoleOnly,
                    verbosity, muteConsole
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }
    }
}