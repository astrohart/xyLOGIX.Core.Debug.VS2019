using log4net.Appender;
using log4net.Core;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods(s) to configure the logging subsystem for the
    /// xyLOGIX.Core.Debug namespace and to switch from one log file to another.
    /// </summary>
    public static class Switch
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Switch" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Switch() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderManager" /> interface.
        /// </summary>
        private static IAppenderManager AppenderManager
        {
            [DebuggerStepThrough] get;
        } = GetAppenderManager.SoleInstance();

        /// <summary>
        /// Sets up logging programmatically (as opposed to using a
        /// <c>app.config</c> file), using the specified <paramref name="logFileName" />
        /// for the log and perhaps the provided log file <paramref name="repository" />
        /// (say, serving as a relay to PostSharp).
        /// </summary>
        /// <param name="logFileName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the fully-qualified pathname of the log file that is to be written.
        /// </param>
        /// <param name="repository">
        /// (Required.) Reference to an instance of an object
        /// that implements the <see cref="T:log4net.Repository.ILoggerRepository" />
        /// interface that plays the role of the <c>Hierarchy</c> object that is configured
        /// for logging.
        /// </param>
        /// <param name="overrideExistingConfig">
        /// (Optional.) A <see cref="T:System.Boolean" /> value that indicates whether to
        /// override the existing configuration.
        /// <para />
        /// The default value of this parameter is <see langword="false" />.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the operation(s) completed successfully;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public static bool LoggingForLogFileName(
            string logFileName,
            ILoggerRepository repository
        )
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, logFileName, to the log
                System.Diagnostics.Debug.WriteLine(
                    $"Switch.LoggingForLogFileName: logFileName = '{logFileName}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName *** INFO: Checking whether the value of the parameter, 'logFileName', is blank..."
                );

                // Check whether the value of the parameter, 'logFileName', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(logFileName))
                {
                    // The parameter, 'logFileName' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Switch.LoggingForLogFileName: *** ERROR *** The parameter, 'logFileName' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'logFileName' is not blank.  Proceeding..."
                );

                // Dump the parameter, 'repository', to the log.
                System.Diagnostics.Debug.WriteLine(
                    $"Switch.LoggingForLogFileName: repository = {repository}"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Checking whether the 'repository' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, repository, is null. If it is, send an 
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (repository == null)
                {
                    // The parameter, 'repository', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "Switch.LoggingForLogFileName: *** ERROR *** A null reference was passed for the 'repository' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** We have been passed a valid object reference for the 'repository' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Checking whether the 'repository' parameter is convertible to the type, 'log4net.Repository.Hierarchy.Hierarchy'..."
                );

                if (!(repository is Hierarchy hierarchy))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'repository' parameter is not convertible to the type, 'log4net.Repository.Hierarchy.Hierarchy'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Switch.LoggingForLogFileName: Actual type of the 'repository' object is: '{repository.GetType()}'."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Switch.LoggingForLogFileName: Result = {result}"
                    );

                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The 'repository' parameter is convertible to the type, 'log4net.Repository.Hierarchy.Hierarchy'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Checking whether the variable, 'hierarchy', has a null reference for a value..."
                );

                // Check to see if the variable, 'hierarchy', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (hierarchy == null)
                {
                    // The variable, 'hierarchy', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Switch.LoggingForLogFileName: *** ERROR ***  The variable, 'hierarchy', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'hierarchy', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The variable, 'hierarchy', has a valid object reference for its value.  Proceeding..."
                );

                /*
                 * NOTE: We ignore whether the 'hierarchy' variable is in the 'Configured'
                 * state or not.  This is because we want to be able to reconfigure the
                 * logging subsystem, if necessary, in order to, e.g, swap out a log file.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Configuring the logging infrastructure..."
                );

                var patternLayout =
                    GetPatternLayout.ForConversionPattern(
                        "%date %-5level - %message%newline"
                    );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Checking whether the variable, 'patternLayout', has a null reference for a value..."
                );

                // Check to see if the variable, 'patternLayout', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (patternLayout == null)
                {
                    // The variable, 'patternLayout', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Switch.LoggingForLogFileName: *** ERROR ***  The variable, 'patternLayout', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'patternLayout', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The variable, 'patternLayout', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Setting up a new RollingFileAppender..."
                );

                var roller =
                    MakeNewRollingFileAppender.ForRollingStyle(
                        RollingFileAppender.RollingMode.Size
                    );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Checking whether the variable, 'roller', has a null reference for a value..."
                );

                // Check to see if the variable, 'roller', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (roller == null)
                {
                    // The variable, 'roller', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Switch.LoggingForLogFileName: *** ERROR ***  The variable, 'roller', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'roller', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The variable, 'roller', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Continuing to set up the RollingFileAppender..."
                );

                roller = roller.SetLogFileNameTo(logFileName)
                               .WithPatternLayout(patternLayout)
                               .AndMaximumNumberOfRollingBackups(10)
                               .WithMaximumFileSizeOf("1GB")
                               .ThatShouldAppendToFile(true)
                               .AndThatHasAStaticLogFileName(true);

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Checking whether the variable, 'roller', has a null reference for a value..."
                );

                // Check to see if the variable, 'roller', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (roller == null)
                {
                    // The variable, 'roller', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Switch.LoggingForLogFileName: *** ERROR ***  The variable, 'roller', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'roller', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The variable, 'roller', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Activating the RollingFileAppender..."
                );

                roller.ActivateOptions();

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Checking whether the property, 'hierarchy.Root', has a null reference for a value..."
                );

                // Check to see if the required property, 'hierarchy.Root', has a null reference for a value. 
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (hierarchy.Root == null)
                {
                    // The property, 'hierarchy.Root', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Switch.LoggingForLogFileName: *** ERROR *** The property, 'hierarchy.Root', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The property, 'hierarchy.Root', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Attempting to close all the existing Appender(s)..."
                );

                // Check to see whether the existing Appender(s) could be closed successfully.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!hierarchy.CloseAllAppenders())
                {
                    // The existing Appender(s) could NOT be closed.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Switch.LoggingForLogFileName: *** ERROR *** The existing Appender(s) could NOT be closed.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The existing Appender(s) have been closed successfully.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** FYI *** Attempting to remove all the existing Appender(s) from the Logger..."
                );

                hierarchy.Root.RemoveAllAppenders();

                DebugUtils.WriteLine(
                    hierarchy.Root.Appenders.Count <= 0
                        ? DebugLevel.Info
                        : DebugLevel.Error,
                    hierarchy.Root.Appenders.Count <= 0
                        ? "*** SUCCESS *** All the existing Appender(s) have been removed from the Logger.  Proceeding..."
                        : $"*** ERROR *** FAILED to remove all existing Appender(s) from the Logger; it still has {hierarchy.Root.Appenders.Count} appender(s) configured.  Stopping..."
                );

                /*
                 * Double-check that the Logger currently has ZERO Appender(s) configured.
                 * This is necessary, otherwise, logging may be multiplexed to more than one
                 * destination(s).
                 *
                 * That would not be desirable, since here, we're just switching out one log
                 * file for another.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: Checking whether the Logger has any Appender(s) configured..."
                );

                // Check to see whether the Logger has any Appender(s) configured.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (hierarchy.Root.Appenders.Count > 0)
                {
                    // The Logger has greater than zero appender(s) currently configured.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The Logger has {hierarchy.Root.Appenders.Count} appender(s) currently configured.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Switch.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The Logger has zero Appender(s) configured (as should be the case at this time).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** All the existing Appender(s) have been removed from the Logger.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Adding the new RollingFileAppender to the Logger..."
                );

                hierarchy.Root.AddAppender(roller);

                System.Diagnostics.Debug.WriteLine(
                    "Switch.LoggingForLogFileName: *** SUCCESS *** The new RollingFileAppender has been added to the Logger.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Setting the level of the RootLogger to 'ALL'..."
                );

                hierarchy.Root.Level = Level.All;

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Marking the Hierarchy as configured..."
                );

                result = hierarchy.Configured = true;

                System.Diagnostics.Debug.WriteLine(
                    result
                        ? "*** SUCCESS *** The logging subsystem has been configured.  Proceeding..."
                        : "*** ERROR *** FAILED to configure the logging subsystem.  Stopping..."
                );

                // Store the Appender in the AppenderManager, if the configuration was successful.
                if (result) AppenderManager.AddAppender(roller);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Switch.LoggingForLogFileName: Result = {result}"
            );

            return result;
        }
    }
}