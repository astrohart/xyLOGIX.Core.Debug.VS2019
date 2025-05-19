using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

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
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static PostSharpLoggingInfrastructure() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected PostSharpLoggingInfrastructure() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingInfrastructureType.PostSharp" /> logging
        /// infrastructure type value.
        /// </summary>
        public static ILoggingInfrastructure Instance
        {
            [DebuggerStepThrough] get;
        } = new PostSharpLoggingInfrastructure();

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> value
        /// that
        /// corresponds to the type of infrastructure that is being utilized.
        /// </summary>
        public override LoggingInfrastructureType Type
        {
            [DebuggerStepThrough] get;
        } = LoggingInfrastructureType.PostSharp;

        /// <summary>
        /// Attempts to fetch the <c>log4net</c> relay for PostSharp by calling the
        /// <see
        ///     cref="PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetCollectingRepositorySelector.RedirectLoggingToPostSharp" />
        /// method.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if no Exception(s) were caught during the
        /// execution of this method, and if the
        /// <see cref="F:xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure._relay" /> field
        /// ends up not being set to a <see langword="null" /> reference; otherwise,
        /// <see langword="false" />.
        /// </returns>
        private bool FetchRelay()
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.FetchRelay: *** FYI *** Attempting to fetch the PostSharp log4net relay..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.FetchRelay: Attempting to obtain the log relay for PostSharp..."
                );

                _relay = Log4NetCollectingRepositorySelector
                    .RedirectLoggingToPostSharp();

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.FetchRelay: *** SUCCESS *** Retrieved the relay from PostSharp.  Analyzing it..."
                );

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded, PROVIDED the '_relay' field
                 * is NOT set to a NULL reference.
                 */

                result = _relay != null;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);


                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"PostSharpLoggingInfrastructure.FetchRelay: Result = {result}"
            );

            return result;
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
        public override string GetRootFileAppenderFileName()
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: Checking whether the '_relay' field has a null reference for a value..."
                );

                // Check to see if the required field, _relay, is null. If it is, then send an
                // error to the Debug output and then quit, returning the default value of the result
                // variable.
                if (_relay == null)
                {
                    // the field _relay is required.
                    System.Diagnostics.Debug.WriteLine(
                        "PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: *** ERROR *** The '_relay' field has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: *** SUCCESS *** The '_relay' field has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** The '_relay' field is of type '{_relay.GetType()}'."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: Attempting to get the first File Appender from the relay..."
                );

                var firstAppender =
                    FileAppenderManager.GetFirstAppender(_relay);

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: Checking whether the variable, 'firstAppender', has a null reference for a value..."
                );

                // Check to see if the variable, firstAppender, is null.  If it is, send an error
                // to the Debug output and terminate the execution of this method, returning
                // the default return value.
                if (firstAppender == null)
                {
                    // the variable firstAppender is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: *** ERROR ***  The variable, 'firstAppender', has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, firstAppender, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: *** SUCCESS *** The variable, 'firstAppender', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: Attempting to get the value of the File property from the first File Appender in the collection of configured Appender(s)..."
                );

                result = firstAppender.File;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"PostSharpLoggingInfrastructure.GetRootFileAppenderFileName: Result = '{result}'"
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
        public override bool InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            [NotLogged] string configurationFileNamename = "",
            bool muteConsole = false,
            [NotLogged] string logFileName = "",
            int verbosity = 1,
            [NotLogged] string applicationName = "",
            [NotLogged] ILoggerRepository repository = null
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** FYI *** Attempting to configure the logging subsystem for use with PostSharp..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: Checking whether the logging subsystem has NOT been configured yet..."
                );

                // Check to see whether the logging subsystem has NOT been configured yet.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (Has.LoggingBeenSetUp())
                {
                    // The logging subsystem has been configured.  There is nothing left to do.
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** The logging subsystem has already been configured.  There is nothing left to do.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.InitializeLogging: Result = {true}"
                    );

                    // stop.
                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The logging subsystem has NOT been configured yet.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** FYI *** Attempting to get the log4net relay for PostSharp..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: Checking whether the relay was fetched successfully..."
                );

                // Check to see whether the relay was fetched successfully.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!FetchRelay())
                {
                    // The relay was NOT fetched successfully.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The relay was NOT fetched successfully.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The relay was fetched successfully.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: Checking whether the '_relay' field has a null reference for a value..."
                );

                // Check to see if the required field, _relay, is null. If it is, then send an 
                // error to the log file and then quit, returning the default value of the result
                // variable.
                if (_relay == null)
                {
                    // the field _relay is required.
                    System.Diagnostics.Debug.WriteLine(
                        "PostSharpLoggingInfrastructure.InitializeLogging: *** ERROR *** The '_relay' field has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The '_relay' field has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: Checking whether the relay is convertible to Hierarchy..."
                );

                // Check to see whether the relay is convertible to Hierarchy.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!(_relay is Hierarchy))
                {
                    // The relay obtained is NOT convertible to Hierarchy.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The relay obtained is NOT convertible to Hierarchy.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The relay is convertible to Hierarchy.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Calling the base-class DefaultLoggingInfrastructure.InitializeLogging method..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: Checking whether the base-class version of this method succeeded..."
                );

                // Check to see whether the base-class version of this method succeeded.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!base.InitializeLogging(
                        muteDebugLevelIfReleaseMode, overwrite,
                        configurationFileNamename, muteConsole, logFileName,
                        verbosity, applicationName, _relay
                    ))
                {
                    // The base-class version of this method failed to execute.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The base-class version of this method failed to execute.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The base-class version of this method succeeded.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The base-class DefaultLoggingInfrastructure.InitializeLogging method appears to have succeeded.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: Configuring log4net logging backend..."
                );

                // set it as the default backend:
                var backend = GetLoggingBackend.For(
                    LoggingBackendType.Log4Net, _relay
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: Checking whether the variable, 'backend', has a null reference for a value..."
                );

                // Check to see if the variable, 'backend', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (backend == null)
                {
                    // The variable, 'backend', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "PostSharpLoggingInfrastructure.InitializeLogging: *** ERROR ***  The variable, 'backend', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'backend', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The variable, 'backend', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"PostSharpLoggingInfrastructure.InitializeLogging: Type of LoggingServices.DefaultBackend = {backend.GetType()}.."
                );

                LoggingServices.DefaultBackend = backend;

                System.Diagnostics.Debug.WriteLine(
                    $"PostSharpLoggingInfrastructure.InitializeLogging: *** SUCCESS *** The backend of type, '{backend.GetType()}', has been set as the default backend.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.InitializeLogging: *** FYI *** Forcing the initialization of the logging subsystem..."
                );

                LoggingServices.Initialize();

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Letting interested party(ies) know that the initialization of the logging subsystem has completed..."
                );

                result = OnLoggingInitializationFinished(overwrite, repository);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"PostSharpLoggingInfrastructure.InitializeLogging: Result = {result}"
            );

            return result;
        }

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
        protected override bool OnLoggingInitializationFinished(
            bool overwrite = true,
            ILoggerRepository repository = null
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Preparing the log file..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: Checking whether the '_relay' field has a null reference for a value..."
                );

                // Check to see if the required field, _relay, is null. If it is, then send an 
                // error to the log file and then quit, returning the default value of the result
                // variable.
                if (_relay == null)
                {
                    // the field _relay is required.
                    System.Diagnostics.Debug.WriteLine(
                        "PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: *** ERROR *** The '_relay' field has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: *** SUCCESS *** The '_relay' field has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: Checking whether the log file was prepared properly..."
                );

                // Check to see whether the log file was prepared properly.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!PrepareLogFile(_relay))
                {
                    // The log file was prepared properly.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The log file was prepared properly.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: *** SUCCESS *** The log file was prepared properly.  Proceeding..."
                );

                // Dump the variable overwrite to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: overwrite = {overwrite}"
                );

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: Checking whether the existing log file is to be appended..."
                );

                // Check to see whether the existing log file is to be appended.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (overwrite)
                {
                    // The existing log file is to be overwritten.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** The existing log file is to be overwritten.  Attempting to delete it, if it exists..."
                    );

                    Delete.LogFile(LogFileName);

                    /*
                     * Be sure to write the timestamp to a new log file before we finish.
                     */

                    Write.LogFileTimestamp();

                    System.Diagnostics.Debug.WriteLine(
                        $"*** PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: Result = {true}"
                    );

                    // stop.
                    return true;
                }

                /*
                 * If we are still here, then the caller wishes us to append to
                 * an existing log file, not delete the existing one and start
                 * anew.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: *** FYI *** The existing log file is to be appended.  Proceeding..."
                );

                /*
                 * Write a line with the current date and time, to the log file.
                 *
                 * This will begin a new section.
                 */

                Write.LogFileTimestamp();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"PostSharpLoggingInfrastructure.OnLoggingInitializationFinished: Result = {result}"
            );

            return result;
        }
    }
}