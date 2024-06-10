using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

#if DEBUG
#else
#endif

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Implements log-file management for the case when we are utilizing
    /// PostSharp aspects to handle the bulk of logging for us.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public class PostSharpLoggingInfrastructure : DefaultLoggingInfrastructure
    {
        /// <summary> Reference to the object that relays all logging to PostSharp. </summary>
        /// <remarks>
        /// This field can only be set to a reference to an instance of an object
        /// that implements the <see cref="T:log4net.Repository.ILoggerRepository" />
        /// interface.
        /// </remarks>
        private ILoggerRepository _relay;

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure" /> and returns
        /// a reference to it.
        /// </summary>
        public PostSharpLoggingInfrastructure() { }

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> value
        /// that
        /// corresponds to the type of infrastructure that is being utilized.
        /// </summary>
        public override LoggingInfrastructureType Type { get; } =
            LoggingInfrastructureType.PostSharp;

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
        public override string GetRootFileAppenderFileName()
            => FileAppenderManager.GetFirstAppender(_relay)
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
        public override void InitializeLogging(
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
            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "PostSharpLoggingInfrastructure.InitializeLogging: Checking whether the log relay is configured..."
                );

                if (_relay != null)

                    // logging is already configured
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Warning,
                        "PostSharpLoggingInfrastructure.InitializeLogging: We've detected that logging is, apparently, already configured."
                    );

                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** Apparently, the log relay is NOT configured.  This is good.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "PostSharpLoggingInfrastructure.InitializeLogging: Configuring the log relay for PostSharp..."
                );

                _relay = _relay ?? Log4NetCollectingRepositorySelector
                    .RedirectLoggingToPostSharp();

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** INFO: Checking whether the '_relay' field has a null reference for a value..."
                );

                // Check to see if the required field, '_relay', is null. If it is, send an
                // error to the log file and quit.
                if (_relay == null)
                {
                    // the field '_relay' is required.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR: The '_relay' field has a null reference.  This field is required."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "PostSharpLoggingInfrastructure.InitializeLogging: Done."
                    );

                    // stop.
                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** SUCCESS *** The '_relay' field has a valid object reference for its value."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** INFO: Calling the base-class DefaultLoggingInfrastructure.InitializeLogging method..."
                );

                base.InitializeLogging(
                    muteDebugLevelIfReleaseMode, overwrite,
                    configurationFilePathname, muteConsole, logFileName,
                    verbosity, applicationName, _relay
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The base-class DefaultLoggingInfrastructure.InitializeLogging method appears to have succeeded.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "PostSharpLoggingInfrastructure.InitializeLogging: Configuring log4net logging backend..."
                );

                // set it as the default backend:
                var backend = GetLoggingBackend.For(
                    LoggingBackendType.Log4Net, _relay
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "PostSharpLoggingInfrastructure.InitializeLogging: Checking whether the variable, 'backend', has a null reference for a value..."
                );

                // Check to see if the variable, backend, is null. If it is, send an error to the log file and quit, returning from the method.
                if (backend == null)
                {
                    // the variable backend is required to have a valid object reference.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "PostSharpLoggingInfrastructure.InitializeLogging: *** ERROR ***  The 'backend' variable has a null reference.  Stopping."
                    );

                    // stop.
                    return;
                }

                // We can use the variable, backend, because it's not set to a null reference.
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The 'backend' variable has a valid object reference for its value."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"PostSharpLoggingInfrastructure.InitializeLogging: Setting LoggingServices.DefaultBackend = {backend}..."
                );

                Debugger.Launch();
                Debugger.Break();

                LoggingServices.DefaultBackend = backend;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "PostSharpLoggingInfrastructure.InitializeLogging: Preparing the log file..."
                );

                PrepareLogFile(overwrite, _relay);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }
    }
}