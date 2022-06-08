using log4net.Config;
using log4net.Repository;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using DirectoryInfo = Alphaleonis.Win32.Filesystem.DirectoryInfo;
using File = Alphaleonis.Win32.Filesystem.File;
using Path = Alphaleonis.Win32.Filesystem.Path;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Default implementation details for the
    /// <see cref="T:xyLOGIX.Core.Debug.LogFileManager" />.
    /// </summary>
    public class DefaultLoggingInfrastructure : ILoggingInfrastructure
    {
        /// <summary>
        /// Gets the full path and filename to the log file for this application.
        /// </summary>
        public virtual string LogFilePath
            => GetRootFileAppenderFileName();

        /// <summary>
        /// Gets the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType" />
        /// value that
        /// corresponds to the type of infrastructure that is being utilized.
        /// </summary>
        public virtual LoggingInfrastructureType Type
            => LoggingInfrastructureType.Default;

        /// <summary>
        /// Deletes the log file, if it exists.
        /// </summary>
        public virtual void DeleteLogIfExists()
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Info,
                "In DefaultLoggingInfrastructure.DeleteLogIfExists"
            );

            // Dump the variable LogFilePath to the log
            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DefaultLoggingInfrastructure.DeleteLogIfExists: LogFilePath = '{0}'",
                LogFilePath
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DefaultLoggingInfrastructure.DeleteLogIfExists: Checking whether the file with path contained in 'LogFilePath' exists..."
            );

            if (!File.Exists(LogFilePath))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DefaultLoggingInfrastructure.DeleteLogIfExists: The log file '{0}' does not exist.  Nothing to do.",
                    LogFilePath
                );

                return;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DefaultLoggingInfrastructure.DeleteLogIfExists: The file with path contained in 'LogFilePath' was found."
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DefaultLoggingInfrastructure.DeleteLogIfExists: Checking whether the folder '{0}' is writeable...",
                Path.GetDirectoryName(LogFilePath)
            );

            if (!DebugFileAndFolderHelper.IsFolderWriteable(
                    Path.GetDirectoryName(LogFilePath)
                ))
            {
                // If we cannot write to the folder where the log file to be
                // deleted sits in, then Heaven help us! However the software
                // should try to work at all costs, so this method should just
                // silently fail in this case.
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DefaultLoggingInfrastructure.DeleteLogIfExists: The folder '{0}' is not writeable, so we can't delete the log file '{1}' as requested.  Nothing to do.",
                    Path.GetDirectoryName(LogFilePath), LogFilePath
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DefaultLoggingInfrastructure.DeleteLogIfExists: Done."
                );

                return;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DefaultLoggingInfrastructure.DeleteLogIfExists: The folder '{0}' is writeable, so therefore we can delete the log file '{1}'.",
                Path.GetDirectoryName(LogFilePath), LogFilePath
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DefaultLoggingInfrastructure.DeleteLogIfExists: Deleting the log file '{0}'...",
                LogFilePath
            );

            File.Delete(LogFilePath);

            // NOTE: We do no logging here since we are dealing with a
            // freshly-emptied log file.
        }

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
        ///     cref="P:xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFilePath" />
        /// property.
        /// </remarks>
        public virtual string GetRootFileAppenderFileName()
            => FileAppenderManager.GetFirstAppender()
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
        /// <param name="repository">
        /// (Optional.) Reference to an instance of an object that implements
        /// the <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// Supply a value for this parameter if your infrastructure is not
        /// utilizing the default HierarchicalRepository.
        /// </param>
        public virtual void InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true, bool overwrite = true,
            string configurationFilePathname = "", bool muteConsole = false,
            ILoggerRepository repository = null)
        {
            var entryAssemblyFileName = Assembly.GetEntryAssembly()
                                                ?.Location;
            if (string.IsNullOrWhiteSpace(entryAssemblyFileName) ||
                !File.Exists(entryAssemblyFileName))
                return;

            DebugUtils.ApplicationName = FileVersionInfo
                                         .GetVersionInfo(entryAssemblyFileName)
                                         .ProductName;

            // If we found a value for the ApplicationName, then initialize the
            // EventLogManager. The EventLogManager is a companion component to
            // DebugUtils which also spits out logging to the System Event Log.
            // This is handy in the case where the user does not have write
            // access to the C:\ProgramData directory, for example.
            if (!string.IsNullOrWhiteSpace(DebugUtils.ApplicationName))
                EventLogManager.Instance.Initialize(
                    DebugUtils.ApplicationName, EventLogType.Application
                );

            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Info,
                "In DefaultLoggingInfrastructure.InitializeLogging"
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

                if (repository == null)
                    XmlConfigurator.Configure();
                else
                    XmlConfigurator.Configure(repository);
            }
            else
            {
                if (repository == null)
                    XmlConfigurator.Configure(
                        new FileInfo(configurationFilePathname)
                    );
                else
                    XmlConfigurator.Configure(
                        repository, new FileInfo(configurationFilePathname)
                    );
            }

            SetUpDebugUtils(
                muteDebugLevelIfReleaseMode, muteConsole: muteConsole
            );

            if (Type != LoggingInfrastructureType.PostSharp)
                PrepareLogFile(overwrite, repository);
        }

        /// <summary>
        /// Sets up the <see cref="T:xyLOGIX.Core.Debug.DebugUtils" /> to
        /// initialize its functionality.
        /// </summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// If set to true, does not echo any logging statements that are set to
        /// the <see cref="T:xyLOGIX.Core.Debug.DebugLevel.Debug" /> level.
        /// </param>
        /// <param name="isLogging">
        /// True to activate the functionality of writing to a log file; false
        /// to suppress. Usually used with the <paramref name="consoleOnly" />
        /// parameter set to true.
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
        public virtual void SetUpDebugUtils(bool muteDebugLevelIfReleaseMode,
            bool isLogging = true, bool consoleOnly = false, int verbosity = 1,
            bool muteConsole = false)
        {
            DebugUtils.IsLogging = isLogging;
            DebugUtils.ConsoleOnly = consoleOnly;
            DebugUtils.Verbosity = verbosity;
            DebugUtils.MuteDebugLevelIfReleaseMode =
                muteDebugLevelIfReleaseMode;
            DebugUtils.MuteConsole = muteConsole;
            DebugUtils.InfrastructureType = Type;
            DebugUtils.LogFilePath = LogFilePath;

            // do not print anything in this method if verbosity is set to
            // anything less than 2
            if (DebugUtils.Verbosity < 2)
                return;

            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "In DefaultLoggingInfrastructure.SetUpDebugUtils"
            );

            // Dump the variable DebugUtils.IsLogging to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.IsLogging = {0}",
                DebugUtils.IsLogging
            );

            // Dump the variable DebugUtils.ConsoleOnly to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.ConsoleOnly = {0}",
                DebugUtils.ConsoleOnly
            );

            // Dump the variable DebugUtils.Verbosity to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.Verbosity = {0}",
                DebugUtils.Verbosity
            );

            // Dump the variable DebugUtils.MuteDebugLevelIfReleaseMode to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.MuteDebugLevelIfReleaseMode = {0}",
                DebugUtils.MuteDebugLevelIfReleaseMode
            );

            // Dump the variable DebugUtils.MuteConsole to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"DefaultLoggingInfrastructure.SetUpDebugUtils: DebugUtils.MuteConsole = {DebugUtils.MuteConsole}"
            );

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DefaultLoggingInfrastructure.SetUpDebugUtils: Done."
            );
        }

        /// <summary>
        /// Prepares the log file by ensuring that the containing folder is
        /// writeable by the current user and by then, if specified to
        /// overwrite, deleting the current log file.
        /// </summary>
        /// <param name="overwrite">
        /// Overwrites any existing logs for the application with the latest
        /// logging sent out by this instance.
        /// </param>
        /// <param name="repository">
        /// (Optional.) Reference to an instance of an object that implements
        /// the <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// Supply a value for this parameter if your infrastructure is not
        /// utilizing the default HierarchicalRepository.
        /// </param>
        protected virtual void PrepareLogFile(bool overwrite,
            ILoggerRepository repository)
        {
            var logFileDirectoryPath = Path.GetDirectoryName(LogFilePath);
            if (string.IsNullOrWhiteSpace(logFileDirectoryPath))
                throw new InvalidOperationException(
                    "Unable to determine the path to the log file's containing folder.  Please ensure that the necessary entries for log4net are included in your App.config file."
                );
            var logFileDirectoryParent = new DirectoryInfo(logFileDirectoryPath)
                                         .Parent?.FullName;

            // Dump the variable logFileDirectoryParent to the log
            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DefaultLoggingInfrastructure.InitializeLogging: logFileDirectoryParent = '{0}'",
                logFileDirectoryParent
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DefaultLoggingInfrastructure.InitializeLogging: Checking whether the user has write-level access to the folder '{0}'...",
                logFileDirectoryParent
            );

            // Check if the user has write access to the parent directory of the
            // log file.
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

            DebugFileAndFolderHelper.CreateDirectoryIfNotExists(
                logFileDirectoryPath
            );

            // We have to insist that the directory that the log file is in is
            // writeable. If we can't get write access to the log file
            // directory, then throw an exception.
            if (!DebugFileAndFolderHelper.IsFolderWriteable(
                    logFileDirectoryPath
                ))
                throw new UnauthorizedAccessException(
                    $"We don't have write permissions to the directory '{logFileDirectoryPath}'."
                );

            // Set options on the file appender of the logging system to
            // minimize locking issues
            FileAppenderConfigurator.SetMinimalLock(
                FileAppenderManager.GetFirstAppender(repository)
            );

            if (overwrite)
                DeleteLogIfExists();

            WriteTimestamp();
        }

        /// <summary>
        /// Writes a date and time stamp to the top of the log file.
        /// </summary>
        protected virtual void WriteTimestamp()
            => DebugUtils.WriteLine(
                DebugLevel.Info,
                $"*** LOG STARTED ON {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToLongTimeString()}"
            );
    }
}