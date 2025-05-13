using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Directory = Alphaleonis.Win32.Filesystem.Directory;
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

            System.Diagnostics.Debug.WriteLine(
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
        /// (Optional.) Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// <para />
        /// Supply a value for this parameter if your infrastructure is not utilizing the
        /// default <c>HierarchyRepository</c>.
        /// <para />
        /// The default value of this parameter is a <see langword="null" /> reference.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the logging subsystem initialization
        /// process completed successfully; <see langword="false" /> otherwise.
        /// </returns>
        public virtual bool InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            [NotLogged] string configurationFileName = "",
            bool muteConsole = false,
            [NotLogged] string logFilePathnameToUse = "",
            int verbosity = 1,
            [NotLogged] string applicationName = "",
            [NotLogged] ILoggerRepository repository = null
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.InitializeLogging: *** FYI *** Setting up an Event Source of the name '{applicationName}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: Checking whether the event log was configured properly..."
                );

                // Check to see whether the event log was configured properly.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!Setup.EventLogging(applicationName))
                {
                    // The event log could NOT be configured properly.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The event log could NOT be configured properly.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DefaultLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The event log was configured properly.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Determining the type of Logging Configurator that is to be utilized..."
                );

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

                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The configurator type, '{configuratorType}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to get a reference to the logging configurator of type '{configuratorType}'..."
                );

                var configurator = GetLoggingConfigurator.For(configuratorType);

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: Checking whether the variable, 'configurator', has a null reference for a value..."
                );

                // Check to see if the variable, 'configurator', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (configurator == null)
                {
                    // The variable, 'configurator', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.InitializeLogging: *** ERROR ***  The variable, 'configurator', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DefaultLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'configurator', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The variable, 'configurator', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: Checking whether the logging subsystem was configured properly..."
                );

                // Check to see whether the logging subsystem was configured properly.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!configurator.Configure(
                        muteDebugLevelIfReleaseMode, overwrite,
                        configurationFileName, muteConsole,
                        logFilePathnameToUse, verbosity, applicationName,
                        repository
                    ))
                {
                    // The logging subsystem could NOT be configured properly.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The logging subsystem could NOT be configured properly.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DefaultLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The logging subsystem was configured properly.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Initializing the settings of the DebugUtils class..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: Checking whether the debug utilities object could be properly configured..."
                );

                // Check to see whether the debug utilities object could be properly configured.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!SetUpDebugUtils(
                        muteDebugLevelIfReleaseMode, true, false, verbosity,
                        muteConsole
                    ))
                {
                    // The debug utilities object was NOT properly configured.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The debug utilities object was NOT properly configured.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DefaultLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The debug utilities object was properly configured.  Proceeding..."
                );

                /*
                 * NOTE: DO NOT call OnLoggingInitializationFinished from here.  ALWAYS
                 * call such a method in the OVERRIDES of this method, ONLY.
                 */

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DefaultLoggingInfrastructure.InitializeLogging: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileName" />
        /// property has been updated.
        /// </summary>
        public event EventHandler LogFileNameChanged;

        /// <summary>
        /// Occurs when the initialization of the logging subsystem has been completed.
        /// </summary>
        public event EventHandler LoggingInitializationFinished;

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
        /// <returns>
        /// <see langword="true" /> if the
        /// <see cref="T:xyLOGIX.Core.Debug.DebugUtils" /> class could be configured
        /// properly; <see langword="false" /> otherwise.
        /// </returns>
        public virtual bool SetUpDebugUtils(
            bool muteDebugLevelIfReleaseMode,
            bool isLogging = true,
            bool consoleOnly = false,
            int verbosity = 1,
            bool muteConsole = false
        )
        {
            var result = false;

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

                // do not print anything in this method if verbosity is set to
                // anything less than 2
                if (DebugUtils.Verbosity < 2)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Stopping now because DebugUtils.Verbosity is set to {DebugUtils.Verbosity}."
                    );

                    return true;
                }

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

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: Result = {result}"
            );

            return result;
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
        /// Raises the
        /// <see
        ///     cref="E:xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LoggingInitializationFinished" />
        /// event.
        /// </summary>
        /// <param name="repository">
        /// (Optional.) Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// <para />
        /// Supply a value for this parameter if your infrastructure is not utilizing the
        /// default <c>HierarchyRepository</c>.
        /// <para />
        /// The default value of this parameter is a <see langword="null" /> reference.
        /// </param>
        protected virtual bool OnLoggingInitializationFinished(
            bool overwrite = true,
            [NotLogged] ILoggerRepository repository = null
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** The main portion of the logging-subsystem initialization process has been completed.  Proceeding to run some final steps..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Checking whether we're using PostSharp..."
                );

                // Check whether we're using PostSharp.  If this is NOT the case, then prepare the 
                // log file, raise the LoggingInitializationFinished event, and then stop.
                if (!Type.Equals(LoggingInfrastructureType.PostSharp))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** We're not using PostSharp.  Preparing the log file..."
                    );

                    result = PrepareLogFile(repository);

                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Raising the 'LoggingInitializationFinished' event..."
                    );

                    LoggingInitializationFinished?.Invoke(
                        this, EventArgs.Empty
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.OnLoggingInitializationFinished: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                /*
                 * If we are here, then we've detected that PostSharp is being used.
                 *
                 * Override(s) of this method should take it from here.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** We're using PostSharp.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Raising the 'LoggingInitializationFinished' event..."
                );

                LoggingInitializationFinished?.Invoke(this, EventArgs.Empty);

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DefaultLoggingInfrastructure.OnLoggingInitializationFinished: Result = {result}"
            );

            return result;
        }

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
        /// <returns>
        /// <see langword="true" /> if the log file has been prepared
        /// successfully; <see langword="false" /> otherwise.
        /// </returns>
        protected virtual bool PrepareLogFile(
            [NotLogged] ILoggerRepository repository
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.PrepareLogFile: *** FYI *** Preparing to write the log file to the file system..."
                );

                /*
                 * This method is primarily concerned with deleting the previous log file and
                 * then starting a new one (for a subsequent execution, or user interaction
                 * session, with the same app.
                 *
                 * Therefore, if we are logging to the console only, then there is nothing for
                 * us to do here -- but return TRUE all the same, to indicate success.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.PrepareLogFile: Checking whether the logging backend is NOT the console..."
                );

                // Check to see whether the logging backend is NOT the console.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (LoggingServices.DefaultBackend is ConsoleLoggingBackend)
                {
                    // The logging backend is the console.  There is nothing to do.
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** The logging backend is the console.  There is nothing to do.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DefaultLoggingInfrastructure.PrepareLogFile: Result = {true}"
                    );

                    // stop.
                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.PrepareLogFile: *** SUCCESS *** The logging backend is NOT the console.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'LogFileName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'LogFileName', appears to have a null 
                // or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(LogFileName))
                {
                    // The property, 'LogFileName', appears to have a null or blank value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'LogFileName', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.PrepareLogFile: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'LogFileName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to obtain the fully-qualified pathname of the folder that is meant to hold the log file(s)..."
                );

                var logFileDirectoryPath = Path.GetDirectoryName(LogFileName);

                // Dump the value of the variable, logFileDirectoryPath, to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: logFileDirectoryPath = '{logFileDirectoryPath}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.PrepareLogFile: Checking whether the variable, 'logFileDirectoryPath', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'logFileDirectoryPath', is null or blank. If it is, 
                // then send an  error to the log file and quit, returning the default value 
                // of the result variable.
                if (string.IsNullOrWhiteSpace(logFileDirectoryPath))
                {
                    // The variable, 'logFileDirectoryPath', has a null reference for a value, or is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.PrepareLogFile: *** ERROR *** The variable, 'logFileDirectoryPath', has a null reference for a value, or is blank.  Stopping..."
                    );

                    // log the result
                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.PrepareLogFile: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: *** SUCCESS *** {logFileDirectoryPath.Length} B of data appear to be present in the variable, 'logFileDirectoryPath'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Determining the fully-qualified pathname of the parent folder of that which is destined to hold the log file..."
                );

                var logFileDirectoryParent =
                    Path.GetDirectoryName(logFileDirectoryPath);

                // Dump the variable logFileDirectoryParent to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: logFileDirectoryParent = '{logFileDirectoryParent}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.PrepareLogFile: Checking whether the variable, 'logFileDirectoryParent', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'logFileDirectoryParent', is null or blank. If it is, 
                // then send an  error to the log file and quit, returning the default value 
                // of the result variable.
                if (string.IsNullOrWhiteSpace(logFileDirectoryParent))
                {
                    // The variable, 'logFileDirectoryParent', has a null reference for a value, or is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.PrepareLogFile: *** ERROR *** The variable, 'logFileDirectoryParent', has a null reference for a value, or is blank.  Stopping..."
                    );

                    // log the result
                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.PrepareLogFile: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: *** SUCCESS *** {logFileDirectoryParent.Length} B of data appear to be present in the variable, 'logFileDirectoryParent'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: Checking whether the folder '{logFileDirectoryParent}' exists..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile *** INFO: Checking whether the folder having pathname, '{logFileDirectoryParent}', exists on the file system..."
                );

                // Check whether a folder having pathname, 'logFileDirectoryParent', exists on the file system.
                // If it does not, then write an error message to the log file, and then terminate
                // the execution of this method, returning the default return value.
                if (!Directory.Exists(logFileDirectoryParent))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.PrepareLogFile: The folder, '{logFileDirectoryParent}', does not exist.  Attempting to create it..."
                    );

                    Directory.CreateDirectory(logFileDirectoryParent);

                    System.Diagnostics.Debug.WriteLine(
                        Directory.Exists(logFileDirectoryParent)
                            ? $"*** SUCCESS *** Created the folder, '{logFileDirectoryParent}', on the file system.  Proceeding..."
                            : $"*** ERROR *** FAILED to create the folder, '{logFileDirectoryParent}', on the file system.  Stopping..."
                    );

                    // Check whether a folder having pathname, 'logFileDirectoryParent', exists on the file system.
                    // If it does not, then terminate the execution of this method, returning the default return
                    // value.
                    if (!Directory.Exists(logFileDirectoryParent))
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"*** DefaultLoggingInfrastructure.PrepareLogFile: Result = {result}"
                        );

                        // stop.
                        return result;
                    }
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: *** SUCCESS *** The folder having pathname, '{logFileDirectoryParent}', was found on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $@"*** FYI *** Checking whether the current user, '{Environment.UserDomainName}\{Environment.UserName}', has write privileges to the folder, '{logFileDirectoryParent}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $@"DefaultLoggingInfrastructure.PrepareLogFile: Checking whether the user, '{Environment.UserDomainName}\{Environment.UserName}', has write privileges to the folder, '{logFileDirectoryParent}'..."
                );

                // Check to see whether the user has write access to the folder,
                // 'logFileDirectoryParent'.  If this is not the case, then write
                // an error message to the Debug output, and then throw
                // UnauthorizedAccessException.
                if (!DebugFileAndFolderHelper.IsFolderWriteable(
                        logFileDirectoryParent
                    ))
                {
                    // The current user does NOT have write access to the folder.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $@"*** ERROR *** The user, '{Environment.UserDomainName}\{Environment.UserName}', does NOT have write privileges to the folder, '{logFileDirectoryParent}'.  Stopping..."
                    );

                    throw new UnauthorizedAccessException(
                        $@"The user, '{Environment.UserDomainName}\{Environment.UserName}', does NOT have write privileges to the folder, '{logFileDirectoryParent}'."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $@"DefaultLoggingInfrastructure.PrepareLogFile: *** SUCCESS *** The user, '{Environment.UserDomainName}\{Environment.UserName}' has write access to the folder.  Proceeding..."
                );


                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile *** INFO: Checking whether the folder having pathname, '{logFileDirectoryPath}', exists on the file system..."
                );

                // Check whether a folder having pathname, 'logFileDirectoryPath', exists on the file system.
                // If it does not, then write an error message to the log file, and then attempt to create it.
                // After we attempt to create it, we will check again whether it exists.
                if (!Directory.Exists(logFileDirectoryPath))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"DefaultLoggingInfrastructure.PrepareLogFile: *** ERROR *** The system could not locate the folder having pathname, '{logFileDirectoryPath}', on the file system.  Creating it..."
                    );

                    Directory.CreateDirectory(logFileDirectoryPath);

                    System.Diagnostics.Debug.WriteLine(
                        Directory.Exists(logFileDirectoryPath)
                            ? $"*** SUCCESS *** Created the folder, '{logFileDirectoryPath}', on the file system.  Proceeding..."
                            : $"*** ERROR *** FAILED to create the folder, '{logFileDirectoryPath}', on the file system.  Stopping..."
                    );

                    // Check whether a folder having pathname, 'logFileDirectoryPath', exists on the file system.
                    // If it does not, then terminate the execution of this method, returning the default return
                    // value.
                    if (!Directory.Exists(logFileDirectoryPath))
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"*** DefaultLoggingInfrastructure.PrepareLogFile: Result = {result}"
                        );

                        // stop.
                        return result;
                    }
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DefaultLoggingInfrastructure.PrepareLogFile: *** SUCCESS *** The folder having pathname, '{logFileDirectoryPath}', was found on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to get a reference to the first FileAppender configured..."
                );

                var firstAppender =
                    FileAppenderManager.GetFirstAppender(repository);

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.PrepareLogFile: Checking whether the variable, 'firstAppender', has a null reference for a value..."
                );

                // Check to see if the variable, 'firstAppender', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (firstAppender == null)
                {
                    // The variable, 'firstAppender', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DefaultLoggingInfrastructure.PrepareLogFile: *** ERROR ***  The variable, 'firstAppender', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DefaultLoggingInfrastructure.PrepareLogFile: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'firstAppender', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.PrepareLogFile: *** SUCCESS *** The variable, 'firstAppender', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to set minimal locking for the FileAppender corresponding to the file, '{firstAppender.File}'..."
                );

                // minimize locking issues
                result = FileAppenderConfigurator.SetMinimalLock(firstAppender);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DefaultLoggingInfrastructure.PrepareLogFile: Result = {result}"
            );

            return result;
        }

        /// <summary> Writes a date and time stamp to the top of the log file. </summary>
        protected virtual void WriteTimestamp()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.WriteTimestamp: *** FYI *** Writing the timestamp to the log file..."
                );

                /*
                 * NOTE: For the vast majority of this file, we are using
                 * System.Diagnostics.Debug.WriteLine to send logging messages.
                 *
                 * However, this method is supposed to touch the log file (except
                 * for when an exception is caught), so we are supposed to call
                 * DebugUtils.WriteLine here.
                 */

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** LOG STARTED ON {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToLongTimeString()}"
                );

                System.Diagnostics.Debug.WriteLine(
                    "DefaultLoggingInfrastructure.WriteTimestamp: *** SUCCESS *** The timestamp has been written to the log file."
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