using log4net.Appender;
using log4net.Core;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to activate functionality,
    /// such as logging.
    /// </summary>
    public static class Activate
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Activate" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Activate() { }

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
                    $"Activate.LoggingForLogFileName: logFileName = '{logFileName}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName *** INFO: Checking whether the value of the parameter, 'logFileName', is blank..."
                );

                // Check whether the value of the parameter, 'logFileName', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(logFileName))
                {
                    // The parameter, 'logFileName' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Activate.LoggingForLogFileName: *** ERROR *** The parameter, 'logFileName' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Activate.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'logFileName' is not blank.  Proceeding..."
                );

                // Dump the parameter, 'repository', to the log.
                System.Diagnostics.Debug.WriteLine(
                    $"Activate.LoggingForLogFileName: repository = {repository}"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: Checking whether the 'repository' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, repository, is null. If it is, send an 
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (repository == null)
                {
                    // The parameter, 'repository', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "Activate.LoggingForLogFileName: *** ERROR *** A null reference was passed for the 'repository' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Activate.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: *** SUCCESS *** We have been passed a valid object reference for the 'repository' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: Checking whether the 'repository' parameter is convertible to the type, 'log4net.Repository.Hierarchy.Hierarchy'..."
                );

                if (!(repository is Hierarchy hierarchy))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'repository' parameter is not convertible to the type, 'log4net.Repository.Hierarchy.Hierarchy'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Activate.LoggingForLogFileName: Actual type of the 'repository' object is: '{repository.GetType()}'."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Activate.LoggingForLogFileName: Result = {result}"
                    );

                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: *** SUCCESS *** The 'repository' parameter is convertible to the type, 'log4net.Repository.Hierarchy.Hierarchy'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: Checking whether the variable, 'hierarchy', has a null reference for a value..."
                );

                // Check to see if the variable, 'hierarchy', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (hierarchy == null)
                {
                    // The variable, 'hierarchy', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Activate.LoggingForLogFileName: *** ERROR ***  The variable, 'hierarchy', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Activate.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'hierarchy', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: *** SUCCESS *** The variable, 'hierarchy', has a valid object reference for its value.  Proceeding..."
                );

                /*
                 * If we are here, and the Configured property of the
                 * hierarchy variable is already set to true, then it is not
                 * necessary to run the rest of this method; we can
                 * simply return control to the caller with a result of
                 * true, in this event.
                 *
                 * It is an error to call the configuration code below,
                 * if the logger is already set up.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: Checking whether the logger is already configured..."
                );

                // Dump the value of the property, hierarchy.Configured, to the log
                System.Diagnostics.Debug.WriteLine(
                    $"Activate.LoggingForLogFileName: hierarchy.Configured = {hierarchy.Configured}"
                );

                // Check whether the logger is already configured.  If this is not
                // the case, then we can proceed with the configuration code below.
                // Otherwise, inform the developer that logging is currently configured,
                // and then terminate the execution of this method, returning TRUE, which
                // indicates success.
                if (result = hierarchy.Configured)
                {
                    // The logger is already configured.  Therefore, there is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "Activate.LoggingForLogFileName: *** SUCCESS *** The logger is already configured.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Activate.LoggingForLogFileName: Result = {true}"
                    );

                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** WARNING: The logger is not configured yet.  Doing so..."
                );

                /*
                 * If we are here, then the logging infrastructure has not
                 * yet been configured, so we do so now.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: Configuring the logging infrastructure..."
                );

                var patternLayout =
                    GetPatternLayout.ForConversionPattern(
                        "%date %-5level - %message%newline"
                    );

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: Checking whether the variable, 'patternLayout', has a null reference for a value..."
                );

                // Check to see if the variable, 'patternLayout', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (patternLayout == null)
                {
                    // The variable, 'patternLayout', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Activate.LoggingForLogFileName: *** ERROR ***  The variable, 'patternLayout', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Activate.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'patternLayout', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: *** SUCCESS *** The variable, 'patternLayout', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Setting up a new RollingFileAppender..."
                );

                var roller =
                    MakeNewRollingFileAppender.ForRollingStyle(
                        RollingFileAppender.RollingMode.Size
                    );

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: Checking whether the variable, 'roller', has a null reference for a value..."
                );

                // Check to see if the variable, 'roller', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (roller == null)
                {
                    // The variable, 'roller', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Activate.LoggingForLogFileName: *** ERROR ***  The variable, 'roller', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Activate.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'roller', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: *** SUCCESS *** The variable, 'roller', has a valid object reference for its value.  Proceeding..."
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
                    "Activate.LoggingForLogFileName: Checking whether the variable, 'roller', has a null reference for a value..."
                );

                // Check to see if the variable, 'roller', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (roller == null)
                {
                    // The variable, 'roller', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Activate.LoggingForLogFileName: *** ERROR ***  The variable, 'roller', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Activate.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'roller', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: *** SUCCESS *** The variable, 'roller', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Activating the RollingFileAppender..."
                );

                roller.ActivateOptions();

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: Checking whether the property, 'hierarchy.Root', has a null reference for a value..."
                );

                // Check to see if the required property, 'hierarchy.Root', has a null reference for a value. 
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (hierarchy.Root == null)
                {
                    // The property, 'hierarchy.Root', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Activate.LoggingForLogFileName: *** ERROR *** The property, 'hierarchy.Root', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Activate.LoggingForLogFileName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: *** SUCCESS *** The property, 'hierarchy.Root', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Adding the new RollingFileAppender to the hierarchy..."
                );

                hierarchy.Root.AddAppender(roller);

                System.Diagnostics.Debug.WriteLine(
                    "Activate.LoggingForLogFileName: *** SUCCESS *** The new RollingFileAppender has been added to the hierarchy.  Proceeding..."
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
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Activate.LoggingForLogFileName: Result = {result}"
            );

            return result;
        }
    }
}