﻿using log4net.Config;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;
using System.IO;
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
        private string _logFileName = "";

        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.DefaultLoggingInfrastructure" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static DefaultLoggingInfrastructure() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.DefaultLoggingInfrastructure" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// <strong>NOTE:</strong> This constructor is marked <see langword="protected" />
        /// due to the fact that this class is marked <see langword="abstract" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        public DefaultLoggingInfrastructure() { }

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
                    return !string.IsNullOrWhiteSpace(_logFileName)
                        ? _logFileName
                        : _logFileName = GetRootFileAppenderFileName();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = string.Empty;
                }

                return result;
            }
            protected set
            {
                var changed = !string.IsNullOrWhiteSpace(value) &&
                              !value.Equals(_logFileName);
                _logFileName = value;
                if (changed) OnLogFileNameChanged();
            }
        }

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
        public virtual void DeleteLogIfExists(string logFileName = "")
        {
            // Dump the value of the property, LogFileName, to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.DeleteLogIfExists: LogFileName = '{LogFileName}'"
            );

            if (!string.IsNullOrWhiteSpace(logFileName) &&
                File.Exists(logFileName))
                LogFileName = logFileName;

            // write the name of the current class and method we are now
            if (!File.Exists(LogFileName))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DefaultLoggingInfrastructure.DeleteLogIfExists: The log file '{0}' does not exist.  Nothing to do.",
                    LogFileName
                );

                return;
            }

            if (!DebugFileAndFolderHelper.IsFolderWriteable(
                    Path.GetDirectoryName(LogFileName)
                ))

                // deleted sits in, then Heaven help us! However, the software
                // should try to work at all costs, so this method should just
                // silently fail in this case.
                return;
            File.Delete(LogFileName);
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
            => FileAppenderManager.GetFirstAppender()
                                  ?.File;

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
        public virtual void InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            string configurationFileNamename = "",
            bool muteConsole = false,
            string logFileName = "",
            int verbosity = 1,
            string applicationName = "",
            ILoggerRepository repository = null
        )
        {
            Setup.EventLogging(applicationName);

            if (string.IsNullOrWhiteSpace(logFileName))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** INFO: The 'logFileName' parameter's argument is the blank string.  Configuring the logging using app.config..."
                );

                // Check whether the path to the configuration file is blank; or, if
                // it's not blank, whether the specified file actually exists at the
                // path indicated. If the configuration file pathname is blank
                // and/or it does not exist at the path indicated, then call the
                // version of XmlConfigurator.Configure that does not take any
                // arguments. On the other hand, if the configurationFileNamename
                // parameter is not blank, and it specifies a file that actually
                // does exist at the specified path, then pass that path to the
                // XmlConfigurator.Configure method.
                if (string.IsNullOrWhiteSpace(configurationFileNamename) ||
                    !File.Exists(configurationFileNamename))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        $"DefaultLoggingInfrastructure.InitializeLogging: Could not locate the file having the path '{configurationFileNamename}'.  Setting up log4net with the default settings..."
                    );

                    // If the file specified by the configurationFileNamename does
                    // not actually exist, the author of this software needs to know
                    // about it, so throw a FileNotFoundException
                    if (!string.IsNullOrWhiteSpace(
                            configurationFileNamename
                        ) // only do this check for a non-blank file name.
                        && !File.Exists(configurationFileNamename))
                        throw new FileNotFoundException(
                            $"The file '{configurationFileNamename}' was not found.\n\nThe application needs this file in order to continue."
                        );

                    /*
                     * If we have no configuration file to work with, try to
                     * set up logging with the passed ILoggerRepository.
                     */

                    if (repository == null)
                        XmlConfigurator.Configure();
                    else
                        XmlConfigurator.Configure(repository);
                }
                else if (!string.IsNullOrWhiteSpace(
                             configurationFileNamename
                         ) && File.Exists(configurationFileNamename))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "*** INFO: Not only is the 'configurationFileNamename' parameter's argument not the blank string, but the file that it references has been found on the filesystem."
                    );

                    /*
                     * Initialize log4net and use both the configuration
                     * file pathname passed, and, if it's not null, the ILoggerRepository
                     * reference that was passed to this method, too.
                     */

                    if (repository == null)
                        XmlConfigurator.Configure(
                            new FileInfo(configurationFileNamename)
                        );
                    else
                        XmlConfigurator.Configure(
                            repository, new FileInfo(configurationFileNamename)
                        );
                }
            }
            else
            {
                /*
                 * If we are here, then the caller of this method told us what pathname
                 * to utilize for the logfile.
                 */

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** INFO: The 'logFileName' parameter was initialized."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DefaultLoggingInfrastructure.InitializeLogging: Attempting to activate logging..."
                );

                if (!Activate.LoggingForLogFileName(logFileName, repository))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        $"*** ERROR *** Failed to set up logging for the log file name '{logFileName}'."
                    );

                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DefaultLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The logging infrastructure has been configured."
                );
            }

            SetUpDebugUtils(
                muteDebugLevelIfReleaseMode, true, false, verbosity, muteConsole
            );

            if (Type != LoggingInfrastructureType.PostSharp)
                PrepareLogFile(repository);
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
        public virtual void SetUpDebugUtils(
            bool muteDebugLevelIfReleaseMode,
            bool isLogging = true,
            bool consoleOnly = false,
            int verbosity = 1,
            bool muteConsole = false
        )
        {
            DebugUtils.IsLogging = isLogging;
            DebugUtils.ConsoleOnly = consoleOnly;
            DebugUtils.Verbosity = Compute.ZeroFloor(verbosity);
            DebugUtils.MuteDebugLevelIfReleaseMode =
                muteDebugLevelIfReleaseMode;
            DebugUtils.MuteConsole = muteConsole;
            DebugUtils.InfrastructureType = Type;
            DebugUtils.LogFileName = LogFileName;

            if (!AppDomain.CurrentDomain.FriendlyName.Contains("LINQPad"))
            { }

            // do not print anything in this method if verbosity is set to
            // anything less than 2
            if (DebugUtils.Verbosity < 2)
                return;

            // dump the properties of DebugUtils to the logfile

            // Dump the variable DebugUtils.IsLogging to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.IsLogging = {DebugUtils.IsLogging}"
            );

            // Dump the variable DebugUtils.ConsoleOnly to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.ConsoleOnly = {DebugUtils.ConsoleOnly}"
            );

            // Dump the variable DebugUtils.MuteDebugLevelIfReleaseMode to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.MuteDebugLevelIfReleaseMode = {DebugUtils.MuteDebugLevelIfReleaseMode}"
            );

            // Dump the variable DebugUtils.MuteConsole to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.MuteConsole = {DebugUtils.MuteConsole}"
            );

            // Dump the variable DebugUtils.InfrastructureType to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.InfrastructureType = '{DebugUtils.InfrastructureType}'"
            );

            // Dump the variable DebugUtils.LogFileName to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.LogFileName = '{DebugUtils.LogFileName}'"
            );

            // Dump the variable DebugUtils.Verbosity to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.Verbosity = {DebugUtils.Verbosity}"
            );
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
        protected virtual void PrepareLogFile(ILoggerRepository repository)
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
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DefaultLoggingInfrastructure.PrepareLogFile: Unable to determine the path to the log file's containing folder."
                );
                return;
            }


            var logFileDirectoryParent =
                Path.GetDirectoryName(logFileDirectoryPath);

            // Dump the variable logFileDirectoryParent to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.PrepareLogFile: logFileDirectoryParent = '{logFileDirectoryParent}'"
            );

            if (string.IsNullOrWhiteSpace(logFileDirectoryParent))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DefaultLoggingInfrastructure.PrepareLogFile: The 'logFileDirectoryParent' variable is blank."
                );
                return;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                $"DefaultLoggingInfrastructure.PrepareLogFile: Checking whether the folder '{logFileDirectoryParent}' exists..."
            );

            if (!Directory.Exists(logFileDirectoryParent))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    $"DefaultLoggingInfrastructure.PrepareLogFile: The folder '{logFileDirectoryParent}' does not exist."
                );
                return;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                $"*** SUCCESS *** The folder '{logFileDirectoryParent}' exists."
            );

            // Check if the user has write access to the parent directory of the
            if (!DebugFileAndFolderHelper.IsFolderWriteable(
                    logFileDirectoryParent
                ))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    @"DefaultLoggingInfrastructure.InitializeLogging: The user '{0}\{1}' does not have write-level access to the folder '{2}'.",
                    Environment.UserDomainName, Environment.UserName,
                    logFileDirectoryParent
                );

                throw new UnauthorizedAccessException(
                    $"We don't have write permissions to the directory '{logFileDirectoryParent}'."
                );
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                $"DefaultLoggingInfrastructure.PrepareLogFile: Ensuring that the directory '{logFileDirectoryPath}' exists..."
            );

            DebugFileAndFolderHelper.CreateDirectoryIfNotExists(
                logFileDirectoryPath
            );

            // directory, then throw an exception.
            if (!DebugFileAndFolderHelper.IsFolderWriteable(
                    logFileDirectoryPath
                ))
                throw new UnauthorizedAccessException(
                    $"We don't have write permissions to the directory '{logFileDirectoryPath}'."
                );

            // minimize locking issues
            FileAppenderConfigurator.SetMinimalLock(
                FileAppenderManager.GetFirstAppender(repository)
            );
        }

        /// <summary> Writes a date and time stamp to the top of the log file. </summary>
        protected virtual void WriteTimestamp()
            => DebugUtils.WriteLine(
                DebugLevel.Info,
                $"*** LOG STARTED ON {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToLongTimeString()}"
            );
    }
}