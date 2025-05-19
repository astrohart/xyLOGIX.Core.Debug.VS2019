using Alphaleonis.Win32.Filesystem;
using log4net.Appender;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Methods to be used to manage the application log. </summary>
    [Log(AttributeExclude = true)]
    public static class LoggingSubsystemManager
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.LoggingSubsystemManager" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingSubsystemManager() { }

        /// <summary>
        /// Gets or sets the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> value
        /// that
        /// represents the type of infrastructure currently in use by this
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingSubsystemManager" />.
        /// </summary>
        public static LoggingInfrastructureType InfrastructureType
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary> Gets the full path and filename to the log file for this application. </summary>
        /// <remarks>
        /// This property should only be called after the
        /// <see cref="M:xyLOGIX.Core.Debug.LoggingSubsystemManager.InitializeLogging" />
        /// method has
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
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = string.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderManager" /> interface.
        /// </summary>
        private static IAppenderManager AppenderManager
        {
            [DebuggerStepThrough]
            get;
        } = GetAppenderManager.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface that
        /// corresponds to the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingSubsystemManager.Type" /> property.
        /// </summary>
        private static ILoggingInfrastructure LoggingInfrastructure
        {
            [DebuggerStepThrough]
            get => GetLoggingInfrastructure.OfType(InfrastructureType);
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingInfrastructureTypeValidator
            LoggingInfrastructureTypeValidator
        { [DebuggerStepThrough] get; } =
            GetLoggingInfrastructureTypeValidator.SoleInstance();

        /// <summary>
        /// Changes the pathname of the log file to the specified
        /// <paramref name="newLogFilePath" />.
        /// </summary>
        /// <param name="newLogFilePath">
        /// (Required.) A <see cref="T:System.String" /> that contains the fully-qualified
        /// pathname of the new log file.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the operation(s) were successful;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public static bool ChangeLogFilePathname(
            [NotLogged] string newLogFilePath
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.ChangeLogFilePathname *** INFO: Checking whether the value of the parameter, 'newLogFilePath', is blank..."
                );

                // Check whether the value of the parameter, 'newLogFilePath', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(newLogFilePath))
                {
                    // The parameter, 'newLogFilePath' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: The parameter, 'newLogFilePath', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.ChangeLogFilePathname: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.ChangeLogFilePathname: *** SUCCESS *** The parameter 'newLogFilePath', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.ChangeLogFilePathname: Checking whether the property, 'AppenderManager', has a null reference for a value..."
                );

                // Check to see if the required property, 'AppenderManager', has a null reference for a value.
                // If that is the case, then we will write an error message to the log file, and then
                // terminate the execution of this method, while returning the default return value.
                if (AppenderManager == null)
                {
                    // The property, 'AppenderManager', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: *** ERROR *** The property, 'AppenderManager', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.ChangeLogFilePathname: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.ChangeLogFilePathname: *** SUCCESS *** The property, 'AppenderManager', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** LoggingSubsystemManager.ChangeLogFilePathname: Checking whether the Appender Manager has greater than zero element(s) in its internal collection..."
                );

                // Check to see whether the Appender Manager has greater than zero element(s)
                // in its internal collection.  If this is not the case, then write an error
                // message to the log file, and then terminate the execution of this method.
                if (!AppenderManager.HasAppenders)
                {
                    // The Appender Manager has zero element(s) in its internal collection.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: *** ERROR *** The Appender Manager has zero element(s) in its internal collection.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.ChangeLogFilePathname: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.ChangeLogFilePathname: *** SUCCESS *** The Appender Manager has greater than zero element(s) in its internal collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.ChangeLogFilePathname: *** FYI *** Searching for the first RollingFileAppender in the collection..."
                );

                foreach (var appender in AppenderManager.Appenders)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: Checking whether the variable 'appender' has a null reference for a value..."
                    );

                    // Check to see if the variable, appender, is null. If it is, send an error to the log file and continue to the next loop iteration.
                    if (appender == null)
                    {
                        // the variable appender is required to have a valid object reference.
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingSubsystemManager.ChangeLogFilePathname: *** ERROR ***  The 'appender' variable has a null reference.  Skipping to the next loop iteration..."
                        );

                        // continue to the next loop iteration.
                        continue;
                    }

                    // We can use the variable, appender, because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: *** SUCCESS *** The 'appender' variable has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: *** LoggingSubsystemManager.ChangeLogFilePathname: Checking whether the current Appender is a FileAppender..."
                    );

                    // Check to see whether the current Appender is a FileAppender.
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next loop iteration.
                    if (!(appender is FileAppender fileAppender))
                    {
                        // The current Appender is NOT a FileAppender.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingSubsystemManager.ChangeLogFilePathname: *** ERROR: The current Appender is NOT a FileAppender.  Skipping to the next Appender..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "*** LoggingSubsystemManager.ChangeLogFilePathname: Checking whether the new log file pathname is the same as the existing one..."
                    );

                    // Check to see whether the new log file pathname is the same as the existing one.
                    // If this is not the case, then write an error message to the log file,
                    // and then terminate the execution of the containing loop.
                    if (newLogFilePath.Equals(
                            fileAppender.File,
                            StringComparison.OrdinalIgnoreCase
                        ))
                    {
                        // The new log file pathname is the same as the existing value.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingSubsystemManager.ChangeLogFilePathname: *** FYI *** The new log file pathname is the same as the existing value.  There is nothing more to be done.  Stopping this loop..."
                        );

                        /*
                         * Set the return value of this method to TRUE so that the caller
                         * does not fall over.
                         */

                        result = true;

                        // stop the loop.
                        break;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: *** SUCCESS *** The new log file pathname is the same as the existing one.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: *** SUCCESS *** The current Appender is a FileAppender.  Proceeding..."
                    );

                    fileAppender.File = newLogFilePath;

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.ChangeLogFilePathname: *** FYI *** The current Appender has been successfully updated to use the new log file path, '{newLogFilePath}'."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.ChangeLogFilePathname: *** FYI *** Deleting the file, '{newLogFilePath}', if it exists..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** LoggingSubsystemManager.ChangeLogFilePathname: Checking whether the deletion operation was successful..."
                    );

                    // Check to see whether the deletion operation was successful.
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next loop iteration.
                    if (!Delete.FileIfExists(newLogFilePath))
                    {
                        // The deletion operation was NOT successful.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingSubsystemManager.ChangeLogFilePathname: *** ERROR: The deletion operation was NOT successful.  Skipping to the next appender..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: *** SUCCESS *** The deletion operation was successful.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.ChangeLogFilePathname: *** FYI *** Writing the current timestamp to the first line of the new log file..."
                    );

                    Write.LogFileTimestamp();

                    /*
                     * If we made it this far with no Exception(s) getting caught, then
                     * assume that the operation(s) succeeded.
                     */

                    result = true;

                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingSubsystemManager.ChangeLogFilePathname: Result = {result}"
            );

            return result;
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
        /// <returns>
        /// <see langword="true" /> if the logging subsystem has been initialized
        /// successfully; <see langword="false" /> otherwise.
        /// </returns>
        public static bool InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            [NotLogged] string configurationFileNamename = "",
            bool muteConsole = false,
            [NotLogged] string logFileName = "",
            int verbosity = 1,
            [NotLogged] string applicationName = "",
            LoggingInfrastructureType infrastructureType =
                LoggingInfrastructureType.Default
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: *** FYI *** Received a request to initialize the logging subsystem..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.InitializeLogging: *** FYI *** Attempting to delete the file, '{DebugUtils.ExceptionLogPathname}', if it exists..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** LoggingSubsystemManager.InitializeLogging: Checking whether the file, '{DebugUtils.ExceptionLogPathname}', either could be successfully deleted, or it never existed in the first place..."
                );

                // Check to see whether the file, 'DebugUtils.ExceptionLogPathname', could be successfully deleted.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (File.Exists(DebugUtils.ExceptionLogPathname) &&
                    !DebugUtils.ClearTempExceptionLog())
                {
                    // The file, 'DebugUtils.ExceptionLogPathname', could NOT be successfully deleted.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.InitializeLogging: *** ERROR *** The file, '{DebugUtils.ExceptionLogPathname}', could NOT be successfully deleted.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.InitializeLogging: *** SUCCESS *** Either the file, '{DebugUtils.ExceptionLogPathname}', could be successfully deleted, or it never existed in the first place.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** LoggingSubsystemManager.InitializeLogging: Checking whether the specified Logging Infrastructure Type value, '{infrastructureType}', is valid..."
                );

                // Check to see whether the specified Logging Infrastructure Type is valid.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (!Validate.LoggingInfrastructureType(infrastructureType))
                {
                    // The specified Logging Infrastructure Type value is NOT valid.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.InitializeLogging: *** ERROR *** The specified Logging Infrastructure Type value, '{infrastructureType}', is NOT valid.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.InitializeLogging: *** SUCCESS *** The specified Logging Infrastructure Type value, '{infrastructureType}', is valid.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.InitializeLogging: Setting the infrastructure type to '{infrastructureType}'..."
                );

                InfrastructureType = infrastructureType;

                /* We now 'outsource' the functionality of this method (and all the
                  other methods of this class) to an 'infrastructure' object that follows (loosely)
                 the Abstract Factory pattern.  Either we use the Default way of initializing logging
                 or we do things the way PostSharp needs us to.*/

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: Checking whether the property, 'LoggingInfrastructure', has a null reference for a value..."
                );

                // Check to see if the required property, 'LoggingInfrastructure', has a null reference for a value.
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (LoggingInfrastructure == null)
                {
                    // The property, 'LoggingInfrastructure', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.InitializeLogging: *** ERROR *** The property, 'LoggingInfrastructure', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: *** SUCCESS *** The property, 'LoggingInfrastructure', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: Proceeding to task the logging infrastructure to initialize itself..."
                );

                result = LoggingInfrastructure.InitializeLogging(
                    muteDebugLevelIfReleaseMode, overwrite,
                    configurationFileNamename, muteConsole, logFileName,
                    verbosity, applicationName
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingSubsystemManager.InitializeLogging: Result = {result}"
            );

            return result;
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
        /// <returns>
        /// <see langword="true" /> if the operation(s) completed successfully;
        /// <see langword="false" /> otherwise.
        /// </returns>
        [DebuggerStepThrough]
        public static bool SetUpDebugUtils(
            bool muteDebugLevelIfReleaseMode,
            bool isLogging = true,
            bool consoleOnly = false,
            int verbosity = 1,
            bool muteConsole = false,
            LoggingInfrastructureType infrastructureType =
                LoggingInfrastructureType.Default
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.SetUpDebugUtils: Checking whether the Logging Infrastructure Type, '{infrastructureType}', is within the defined value set..."
                );

                // Check to see whether the specified Logging Infrastructure Type is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!LoggingInfrastructureTypeValidator.IsValid(
                        infrastructureType
                    ))
                {
                    // The specified Logging Infrastructure Type is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The Logging Infrastructure Type, '{infrastructureType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.SetUpDebugUtils: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.SetUpDebugUtils: *** SUCCESS *** The Logging Infrastructure Type, '{infrastructureType}', is within the defined value set.  Proceeding..."
                );

                InfrastructureType = infrastructureType;

                System.Diagnostics.Debug.WriteLine(
                    "*** LoggingSubsystemManager.SetUpDebugUtils: Checking whether the 'LoggingInfrastructure' property has a null reference for a value..."
                );

                // Check to see if the required property, LoggingInfrastructure, is null. If it is, send an
                // error to the log file and quit, returning from the method.
                if (LoggingInfrastructure == null)
                {
                    // the property LoggingInfrastructure is required.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.SetUpDebugUtils: *** ERROR *** The 'LoggingInfrastructure' property has a null reference.  Stopping."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.SetUpDebugUtils: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.SetUpDebugUtils: *** SUCCESS *** The 'LoggingInfrastructure' property has a valid object reference for its value."
                );

                result = LoggingInfrastructure.SetUpDebugUtils(
                    muteDebugLevelIfReleaseMode, isLogging, consoleOnly,
                    verbosity, muteConsole
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingSubsystemManager.SetUpDebugUtils: Result = {result}"
            );

            return result;
        }
    }
}