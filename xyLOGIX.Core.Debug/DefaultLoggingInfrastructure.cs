using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using System;
using System.IO;
using Directory = Alphaleonis.Win32.Filesystem.Directory;
using DirectoryInfo = Alphaleonis.Win32.Filesystem.DirectoryInfo;
using File = Alphaleonis.Win32.Filesystem.File;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Default implementation details for the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" />.
    /// </summary>
    [Log(AttributeExclude = true)]
    public class DefaultLoggingInfrastructure : ILoggingInfrastructure
    {
        /// <summary> Gets the full path and filename to the log file for this application. </summary>
        public virtual string LogFilePath
            => GetRootFileAppenderFileName();

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> value
        /// that corresponds to the type of infrastructure that is being utilized.
        /// </summary>
        public virtual LoggingInfrastructureType Type { get; } =
            LoggingInfrastructureType.Default;

        /// <summary> Deletes the log file, if it exists. </summary>
        public virtual void DeleteLogIfExists()
        {
            // write the name of the current class and method we are now
            if (!File.Exists(LogFilePath))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DefaultLoggingInfrastructure.DeleteLogIfExists: The log file '{0}' does not exist.  Nothing to do.",
                    LogFilePath
                );

                return;
            }

            if (!DebugFileAndFolderHelper.IsFolderWriteable(
                    Path.GetDirectoryName(LogFilePath)
                ))

                // deleted sits in, then Heaven help us! However the software
                // should try to work at all costs, so this method should just
                // silently fail in this case.
                return;
            File.Delete(LogFilePath);
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
        /// <see cref="P:Core.Debug.ILoggingInfrastructure.LogFilePath" /> property.
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
        /// <param name="configurationFilePathname">
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
            string configurationFilePathname = "",
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
                // arguments. On the other hand, if the configurationFilePathname
                // parameter is not blank, and it specifies a file that actually
                // does exist at the specified path, then pass that path to the
                // XmlConfigurator.Configure method.
                if (string.IsNullOrWhiteSpace(configurationFilePathname) ||
                    !File.Exists(configurationFilePathname))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        $"DefaultLoggingInfrastructure.InitializeLogging: Could not locate the file having the path '{configurationFilePathname}'.  Setting up log4net with the default settings..."
                    );

                    // If the file specified by the configurationFilePathname does
                    // not actually exist, the author of this software needs to know
                    // about it, so throw a FileNotFoundException
                    if (!string.IsNullOrWhiteSpace(
                            configurationFilePathname
                        ) // only do this check for a non-blank file name.
                        && !File.Exists(configurationFilePathname))
                        throw new FileNotFoundException(
                            $"The file '{configurationFilePathname}' was not found.\n\nThe application needs this file in order to continue."
                        );

                    /*
                     * If we have no configuration file to work with, try to
                     * setup logging with the passed ILoggerRepository.
                     */

                    if (repository == null)
                        XmlConfigurator.Configure();
                    else
                        XmlConfigurator.Configure(repository);
                }
                else if (!string.IsNullOrWhiteSpace(
                             configurationFilePathname
                         ) && File.Exists(configurationFilePathname))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "*** INFO: Not only is the 'configurationFilePathname' parameter's argument not the blank string, but the file that it references has been found on the disk."
                    );

                    /*
                     * Initialize log4net and use both the configuration
                     * file pathname passed, and, if it's not null, the ILoggerRepository
                     * reference that was passed to this method, too.
                     */

                    if (repository == null)
                        XmlConfigurator.Configure(
                            new FileInfo(configurationFilePathname)
                        );
                    else
                        XmlConfigurator.Configure(
                            repository, new FileInfo(configurationFilePathname)
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
                if (!Activate.LoggingForLogFileName(
                        logFileName, repository ?? new Hierarchy()
                    ))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        $"*** ERROR *** Failed to set up logging for the log file name '{logFileName}'."
                    );
                    return;
                }
            }

            SetUpDebugUtils(
                muteDebugLevelIfReleaseMode, true, false, verbosity, muteConsole
            );

            if (Type != LoggingInfrastructureType.PostSharp)
                PrepareLogFile(overwrite, repository);
        }

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
            DebugUtils.LogFilePath = LogFilePath;

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

            // Dump the variable DebugUtils.LogFilePath to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.LogFilePath = '{DebugUtils.LogFilePath}'"
            );

            // Dump the variable DebugUtils.Verbosity to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.Verbosity = {DebugUtils.Verbosity}"
            );
        }

        /// <summary>
        /// Prepares the log file by ensuring that the containing folder is
        /// writeable by the current user and by then, if specified to overwrite, deleting
        /// the current log file.
        /// </summary>
        /// <param name="overwrite">
        /// Overwrites any existing logs for the application with
        /// the latest logging sent out by this instance.
        /// </param>
        /// <param name="repository">
        /// (Optional.) Reference to an instance of an object
        /// that implements the <see cref="T:log4net.Repository.ILoggerRepository" />
        /// interface. Supply a value for this parameter if your infrastructure is not
        /// utilizing the default HierarchicalRepository.
        /// </param>
        protected virtual void PrepareLogFile(
            bool overwrite,
            ILoggerRepository repository
        )
        {
            if (LoggingServices.DefaultBackend is ConsoleLoggingBackend)
                return;

            var logFileDirectoryPath = Path.GetDirectoryName(LogFilePath);
            if (string.IsNullOrWhiteSpace(logFileDirectoryPath))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DefaultLoggingInfrastructure.PrepareLogFile: Unable to determine the path to the log file's containing folder."
                );
                return;
            }

            var logFileDirectoryParent = new DirectoryInfo(logFileDirectoryPath)
                                         .Parent?.FullName;

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

            if (overwrite)
                DeleteLogIfExists();

            WriteTimestamp();
        }

        /// <summary> Writes a date and time stamp to the top of the log file. </summary>
        protected virtual void WriteTimestamp()
            => DebugUtils.WriteLine(
                DebugLevel.Info,
                $"*** LOG STARTED ON {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToLongTimeString()}"
            );
    }
}