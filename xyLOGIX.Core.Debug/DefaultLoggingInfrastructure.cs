using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Directory = Alphaleonis.Win32.Filesystem.Directory;
using File = Alphaleonis.Win32.Filesystem.File;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Default implementation details for the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" />.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public class DefaultLoggingInfrastructure : ILoggingInfrastructure
    {
        /// <summary>
        /// A <see cref="T:System.String" /> that contains the fully-qualified pathname of
        /// the log file.
        /// </summary>
        private string _logFilePathnameToUse = "";

        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static DefaultLoggingInfrastructure() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected DefaultLoggingInfrastructure() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingInfrastructureType.Default" /> logging
        /// infrastructure type value.
        /// </summary>
        public static ILoggingInfrastructure Instance
        {
            [DebuggerStepThrough] get;
        } = new DefaultLoggingInfrastructure();

        /// <summary>
        /// Gets a value indicating whether the current application is a console
        /// application.
        /// </summary>
        /// <remarks>
        /// This property determines if the application has an associated console window by
        /// invoking the <see cref="GetConsoleWindow" /> method. If the method returns a
        /// non-zero
        /// pointer, the application is considered a console application. If an exception
        /// occurs
        /// during this process, the exception is logged, and the property returns
        /// <see langword="false" />.
        /// </remarks>
        /// <value>
        /// <see langword="true" /> if the application is a console application; otherwise,
        /// <see langword="false" />.
        /// </value>
        private bool IsConsoleApp
        {
            [DebuggerStepThrough]
            get
            {
                bool result;

                try
                {
                    result = GetConsoleWindow() != IntPtr.Zero;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = false;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the fully-qualified pathname
        /// of the log file of this application.
        /// </summary>
        public virtual string LogFileName
        {
            get
            {
                string result;

                try
                {
                    return !string.IsNullOrWhiteSpace(_logFilePathnameToUse)
                        ? _logFilePathnameToUse
                        : _logFilePathnameToUse = GetRootFileAppenderFileName();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = string.Empty;
                }

                return result;
            }
            protected set
            {
                var changed = !string.IsNullOrWhiteSpace(value) &&
                              !value.Equals(_logFilePathnameToUse);
                _logFilePathnameToUse = value;
                if (changed) OnLogFileNameChanged();
            }
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingConfiguratorTypeValidator
            LoggingConfiguratorTypeValidator { [DebuggerStepThrough] get; } =
            GetLoggingConfiguratorTypeValidator.SoleInstance();

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> value
        /// that corresponds to the type of infrastructure that is being utilized.
        /// </summary>
        public virtual LoggingInfrastructureType Type
        {
            [DebuggerStepThrough] get;
        } = LoggingInfrastructureType.Default;

        /// <summary> Deletes the log file, if it exists. </summary>
        /// <param name="logFileName">
        /// (Required.) A <see cref="T:System.String" /> that contains the fully-qualified
        /// pathname of a file to which the log is being written.
        /// </param>
        public virtual void DeleteLogIfExists(
            [NotLogged] string logFileName = ""
        )
        {
            try
            {
                var logFilePathnameToUse = string.Empty;

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.DeleteLogIfExists: *** FYI *** Attempting to delete the log file, '{logFilePathnameToUse}', if it exists..."
                );

                /*
                 * Determine the fully-qualified pathname of the log file that is to be deleted.
                 *
                 * If we are unable to do that, then simply give up.
                 */

                if (!string.IsNullOrWhiteSpace(logFileName) &&
                    File.Exists(logFileName))
                    logFilePathnameToUse = LogFileName = logFileName;
                else if (!string.IsNullOrWhiteSpace(LogFileName) &&
                         File.Exists(LogFileName))
                    logFilePathnameToUse = LogFileName;
                else
                    return;

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.DeleteLogIfExists: Checking whether the value of the required method parameter, 'logFilePathnameToUse' parameter is null or consists solely of whitespace..."
                );

                if (string.IsNullOrWhiteSpace(logFilePathnameToUse))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.DeleteLogIfExists: *** ERROR *** Null or blank value passed for the parameter, 'logFilePathnameToUse'.  Stopping..."
                    );

                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.DeleteLogIfExists: *** SUCCESS *** The value of the required parameter, 'logFilePathnameToUse', is not blank.  Continuing..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.DeleteLogIfExists *** INFO: Checking whether the file having pathname, '{logFilePathnameToUse}', exists on the file system..."
                );

                // Check whether a file having pathname, 'logFilePathnameToUse', exists on the file system.
                // If it does not, then write an error message to the Debug output, and then terminate
                // the execution of this method.
                if (!File.Exists(logFilePathnameToUse))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the file having pathname, '{logFilePathnameToUse}', on the file system.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.DeleteLogIfExists *** SUCCESS *** The file having pathname, '{logFilePathnameToUse}', was found on the file system.  Proceeding..."
                );

                var logFileDirectoryPath =
                    Path.GetDirectoryName(logFilePathnameToUse);

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.DeleteLogIfExists: Checking whether the variable, 'logFileDirectoryPath', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'logFileDirectoryPath', is null or blank. If it is, 
                // then send an  error to the Debug output and then terminate the execution of this
                // method.
                if (string.IsNullOrWhiteSpace(logFileDirectoryPath))
                {
                    // the variable logFileDirectoryPath is required.
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.DeleteLogIfExists: *** ERROR *** The variable, 'logFileDirectoryPath', has a null reference or is blank.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.DeleteLogIfExists: *** SUCCESS *** {logFileDirectoryPath.Length} B of data appear to be present in the variable, 'logFileDirectoryPath'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.DeleteLogIfExists *** INFO: Checking whether the folder with path, '{logFileDirectoryPath}', exists on the file system..."
                );

                // Check whether a folder having the path, 'logFileDirectoryPath', exists on the file system.
                // If it does not, then write an error message to the Debug output, and then terminate
                // the execution of this method.
                if (!Directory.Exists(logFileDirectoryPath))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.DeleteLogIfExists: *** ERROR *** The system could not locate the folder having the path, '{logFileDirectoryPath}', on the file system.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.DeleteLogIfExists: *** SUCCESS *** The folder with path, '{logFileDirectoryPath}', was found on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** DefaultLoggingInfrastructure.DeleteLogIfExists: Checking whether the folder, '{logFileDirectoryPath}', is writeable..."
                );

                // Check to see whether the folder having the pathname, 'logFileDirectoryPath', is writeable.
                // If this is not the case, then write an error message to the Debug output
                // and then terminate the execution of this method.
                if (!DebugFileAndFolderHelper.IsFolderWriteable(
                        logFileDirectoryPath
                    ))
                {
                    // The folder having the pathname, 'logFileDirectoryPath', is NOT writeable.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR: The folder, '{logFileDirectoryPath}', is NOT writeable.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.DeleteLogIfExists: *** SUCCESS *** The folder, '{logFileDirectoryPath}', is writeable.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** DELETING the file, '{logFilePathnameToUse}'..."
                );

                File.Delete(logFilePathnameToUse);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);
            }

            // Dump the value of the property, LogFileName, to the Debug output
            System.Diagnostics.Debug.WriteLine(
                $"DefaultLoggingInfrastructure.DeleteLogIfExists: LogFileName = '{LogFileName}'"
            );
        }

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
        public virtual string GetRootFileAppenderFileName()
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to get the pathname of the file that logging is to be written to..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to get a reference to the first FileAppender in the list of Appender(s)..."
                );

                var fileAppender = FileAppenderManager.GetFirstAppender();

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.GetRootFileAppenderFileName: Checking whether the variable, 'fileAppender', has a null reference for a value..."
                );

                // Check to see if the variable, fileAppender, is null.  If it is, send an error
                // to the Debug output and terminate the execution of this method, returning
                // the default return value.
                if (fileAppender == null)
                {
                    // the variable fileAppender is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.GetRootFileAppenderFileName: *** ERROR ***  The variable, 'fileAppender', has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DefaultLoggingInfrastructure.GetRootFileAppenderFileName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, fileAppender, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.GetRootFileAppenderFileName: *** SUCCESS *** The variable, 'fileAppender', has a valid object reference for its value.  Proceeding..."
                );

                result = fileAppender.File;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.GetRootFileAppenderFileName: Result = '{result}'"
            );

            return result;
        }

        /// <summary> Initializes the application's logging subsystem. </summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// Set to true if we should not write
        /// out "DEBUG" messages to the Debug output when in the Release mode. Set to false
        /// if
        /// all messages should always be logged.
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
        /// <param name="logFilePathnameToUse">
        /// (Optional.) If blank, then the
        /// <c>XMLConfigurator</c> object is used to configure logging.
        /// <para />
        /// Else, specify here the path to the Debug output to be created.
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
        public virtual bool InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            string configurationFileName = "",
            bool muteConsole = false,
            string logFilePathnameToUse = "",
            int verbosity = 1,
            string applicationName = "",
            ILoggerRepository repository = null
        )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.InitializeLogging: *** FYI *** Setting up an Event Source of the name '{applicationName}'..."
                );

                Setup.EventLogging(applicationName);

                var configuratorType =
                    Determine.LoggingConfiguratorTypeToUse(
                        logFilePathnameToUse
                    );

                // Dump the variable type to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.InitializeLogging: configuratorType = '{configuratorType}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** DefaultLoggingInfrastructure.InitializeLogging: Checking whether the configurator type, '{configuratorType}', is within the defined value set..."
                );

                // Check to see whether the configurator type is within the defined value set.
                // If this is not the case, then write an error message to the Debug output
                // and then terminate the execution of this method.
                if (!LoggingConfiguratorTypeValidator.IsValid(configuratorType))
                {
                    // The configurator type is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR: The configurator type, '{configuratorType}', is NOT within the defined value set.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The configurator type, '{configuratorType}', is within the defined value set.  Proceeding..."
                );

                var configurator = GetLoggingConfigurator.For(configuratorType);

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: Checking whether the variable 'configurator' has a null reference for a value..."
                );

                // Check to see if the variable, configurator, is null. If it is,
                // send an error to the Debug output and quit, returning from the method.
                if (configurator == null)
                {
                    // the variable configurator is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.InitializeLogging: *** ERROR ***  The 'configurator' variable has a null reference.  Stopping..."
                    );

                    // stop.
                    return;
                }

                // We can use the variable, configurator, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The 'configurator' variable has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DefaultLoggingInfrastructure.InitializeLogging: Checking whether the logging subsystem got configured successfully..."
                );

                // Check to see whether the logging subsystem got configured successfully.
                // If this is not the case, then write an error message to the Debug output
                // and then terminate the execution of this method.
                if (!configurator.Configure(
                        muteDebugLevelIfReleaseMode, overwrite,
                        configurationFileName, muteConsole,
                        logFilePathnameToUse, verbosity, applicationName,
                        repository
                    ))
                {
                    // The logging subsystem could NOT be properly configured.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The logging subsystem could NOT be properly configured.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The logging subsystem got configured successfully.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Initializing the settings of the DebugUtils class..."
                );

                SetUpDebugUtils(
                    muteDebugLevelIfReleaseMode, true, false, verbosity,
                    muteConsole
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Checking whether we're using PostSharp..."
                );

                if (Type != LoggingInfrastructureType.PostSharp)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** We're not using PostSharp.  Preparing the log file..."
                    );

                    PrepareLogFile(repository);

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** We're using PostSharp.  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileName" />
        /// property has been updated.
        /// </summary>
        public event EventHandler LogFileNameChanged;

        /// <summary>
        /// Sets up the <see cref="T:xyLOGIX.Core.Debug.DebugUtils" /> class to
        /// initialize its functionality.
        /// </summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// If set to true, does not echo any
        /// logging statements that are set to the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel.Debug" /> level.
        /// </param>
        /// <param name="isLogging">
        /// True to activate the functionality of writing to a log
        /// file; false to suppress. Usually used with the <paramref name="consoleOnly" />
        /// parameter set to true.
        /// </param>
        /// <param name="consoleOnly">
        /// True to only write messages to the console; false to
        /// write them both to the console and to the Debug output.
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
        public virtual void SetUpDebugUtils(
            bool muteDebugLevelIfReleaseMode,
            bool isLogging = true,
            bool consoleOnly = false,
            int verbosity = 1,
            bool muteConsole = false
        )
        {
            try
            {
                DebugUtils.IsLogging = isLogging;
                DebugUtils.ConsoleOnly = consoleOnly;
                DebugUtils.Verbosity = Compute.ZeroFloor(verbosity);
                DebugUtils.MuteDebugLevelIfReleaseMode =
                    muteDebugLevelIfReleaseMode;
                DebugUtils.MuteConsole = muteConsole;
                DebugUtils.InfrastructureType = Type;
                DebugUtils.LogFileName = LogFileName;

                if (!AppDomain.CurrentDomain.FriendlyName
                              .Contains("LINQPad")) { }

                // do not print anything in this method if verbosity is set to
                // anything less than 2
                if (DebugUtils.Verbosity < 2)
                    return;

                // dump the properties of DebugUtils to the Debug output

                // Dump the variable DebugUtils.IsLogging to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.IsLogging = {DebugUtils.IsLogging}"
                );

                // Dump the variable DebugUtils.ConsoleOnly to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.ConsoleOnly = {DebugUtils.ConsoleOnly}"
                );

                // Dump the variable DebugUtils.MuteDebugLevelIfReleaseMode to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.MuteDebugLevelIfReleaseMode = {DebugUtils.MuteDebugLevelIfReleaseMode}"
                );

                // Dump the variable DebugUtils.MuteConsole to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.MuteConsole = {DebugUtils.MuteConsole}"
                );

                // Dump the variable DebugUtils.Type to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.Type = '{DebugUtils.InfrastructureType}'"
                );

                // Dump the variable DebugUtils.LogFileName to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.LogFileName = '{DebugUtils.LogFileName}'"
                );

                // Dump the variable DebugUtils.Verbosity to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.Verbosity = {DebugUtils.Verbosity}"
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Retrieves the handle to the console window used by the calling
        /// process.
        /// </summary>
        /// <remarks>
        /// If the calling process is not attached to a console, the return value
        /// is <see cref="F:System.IntPtr.Zero" />.  This function is useful for
        /// determining whether the current application is a console application and for
        /// interacting with the console window, such as resizing or hiding it.
        /// </remarks>
        /// <returns>
        /// A handle to the console window associated with the calling process, or
        /// <see cref="F:System.IntPtr.Zero" /> if the process does not have a console
        /// window.
        /// </returns>
        /// <seealso
        ///     href="https://learn.microsoft.com/en-us/windows/console/getconsolewindow">
        /// MSDN
        /// Documentation for GetConsoleWindow
        /// </seealso>
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileNameChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// This method is called when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileName" />
        /// property is updated.
        /// </remarks>
        protected virtual void OnLogFileNameChanged()
            => LogFileNameChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Prepares the log file by ensuring that the containing folder is
        /// writeable by the current user and by then, if specified to overwrite, deleting
        /// the current log file.
        /// </summary>
        /// <param name="repository">
        /// (Optional.) Reference to an instance of an object
        /// that implements the <see cref="T:log4net.Repository.ILoggerRepository" />
        /// interface. Supply a value for this parameter if your infrastructure is not
        /// utilizing the default HierarchicalRepository.
        /// </param>
        protected virtual void PrepareLogFile(
            [NotLogged] ILoggerRepository repository
        )
        {
            try
            {
                /*
                 * This method is primarily concerned with deleting the previous log file and
                 * then starting a new one (for a subsequent execution, or user interaction
                 * session, with the same app.
                 *
                 * Therefore, if we are logging to the console only, then there is nothing for
                 * us to do here.
                 */

                if (LoggingServices.DefaultBackend is ConsoleLoggingBackend)
                    return;

                var logFileDirectoryPath = Path.GetDirectoryName(LogFileName);
                if (string.IsNullOrWhiteSpace(logFileDirectoryPath))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.PrepareLogFile: Unable to determine the path to the log file's containing folder."
                    );
                    return;
                }


                var logFileDirectoryParent =
                    Path.GetDirectoryName(logFileDirectoryPath);

                // Dump the variable logFileDirectoryParent to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: logFileDirectoryParent = '{logFileDirectoryParent}'"
                );

                if (string.IsNullOrWhiteSpace(logFileDirectoryParent))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.PrepareLogFile: The 'logFileDirectoryParent' variable is blank."
                    );
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: Checking whether the folder '{logFileDirectoryParent}' exists..."
                );

                if (!Directory.Exists(logFileDirectoryParent))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.PrepareLogFile: The folder, '{logFileDirectoryParent}', does not exist.  Attempting to create it..."
                    );

                    Directory.CreateDirectory(logFileDirectoryParent);

                    DebugUtils.WriteLine(
                        Directory.Exists(logFileDirectoryParent)
                            ? DebugLevel.Info
                            : DebugLevel.Error,
                        Directory.Exists(logFileDirectoryParent)
                            ? $"*** SUCCESS *** Created the folder, '{logFileDirectoryParent}', on the file system.  Proceeding..."
                            : $"*** ERROR *** FAILED to create the folder, '{logFileDirectoryParent}', on the file system.  Stopping..."
                    );

                    if (!Directory.Exists(logFileDirectoryParent)) return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"*** SUCCESS *** The folder, '{logFileDirectoryParent}', exists."
                );

                // Check if the user has write access to the parent folder of the
                // log file; if not, then throw UnauthorizedAccessException
                if (!DebugFileAndFolderHelper.IsFolderWriteable(
                        logFileDirectoryParent
                    ))
                {
                    throw new UnauthorizedAccessException(
                        $@"DefaultLoggingInfrastructure.InitializeLogging: The user, '{Environment.UserDomainName}\{Environment.UserName}', does not have write-level access to the folder, '{logFileDirectoryParent}'."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: Ensuring that the folder '{logFileDirectoryPath}' exists..."
                );

                // minimize locking issues
                FileAppenderConfigurator.SetMinimalLock(
                    FileAppenderManager.GetFirstAppender(repository)
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary> Writes a date and time stamp to the top of the log file. </summary>
        protected virtual void WriteTimestamp()
        {
            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** LOG STARTED ON {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToLongTimeString()}"
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}