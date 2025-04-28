using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a
    /// <c>Logging Configurator</c> file that sets up logging purely programmatically.
    /// </summary>
    public class ProgrammaticLoggingConfigurator : LoggingConfiguratorBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static ProgrammaticLoggingConfigurator() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected ProgrammaticLoggingConfigurator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfigurator" /> interface.
        /// </summary>
        public static ILoggingConfigurator Instance
        {
            [DebuggerStepThrough] get;
        } = new ProgrammaticLoggingConfigurator();

        /// <summary>
        /// Gets or sets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingConfiguratorType" /> enumeration
        /// value(s) that indicates which type of configuration this
        /// <c>Logging Configurator</c> does.
        /// </summary>
        public override LoggingConfiguratorType Type
        {
            [DebuggerStepThrough] get;
        } = LoggingConfiguratorType.Programmatic;

        /// <summary> Initializes the application's logging subsystem.</summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// Set to <see langword="true" /> if we
        /// should not write out <c>DEBUG</c> messages to the <c>Debug</c> output when in
        /// the
        /// <c>Release</c> mode. Set to <see langword="false" /> if all messages should
        /// always be logged.
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
        /// <param name="logFileName">
        /// (Optional.) If blank, then the
        /// <c>XMLConfigurator</c> object is used to configure logging.
        /// <para />
        /// Else, specify here the path to the <c>Debug</c> output to be created.
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
        /// <see langword="true" /> if the configuration operation(s) succeeded;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public override bool Configure(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            string configurationFileName = "",
            bool muteConsole = false,
            string logFileName = "",
            int verbosity = 1,
            string applicationName = "",
            ILoggerRepository repository = null
        )
        {
            var result = false;

            try
            {
                /*
                 * In principle, the logFileName may be marked, syntactically, as optional,
                 * but for this particular approach to work, it must have a value; we're simply
                 * following convention(s) used elsewhere in this software system.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "ProgrammaticLoggingConfigurator.Configure: Checking whether the value of the required method parameter, 'logFileName' parameter is null or consists solely of whitespace..."
                );

                if (string.IsNullOrWhiteSpace(logFileName))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "ProgrammaticLoggingConfigurator.Configure: *** ERROR *** Null or blank value passed for the parameter, 'logFileName'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"ProgrammaticLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "ProgrammaticLoggingConfigurator.Configure: *** SUCCESS *** The value of the required parameter, 'logFileName', is not blank.  Continuing..."
                );

                /*
                 * Likewise, the value of the parameter, 'repository', is marked as optional;
                 * but, in reality, it's required to have a non-NULL value by THIS method.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "ProgrammaticLoggingConfigurator.Configure: Checking whether the 'repository' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, repository, is null. If it is, send an 
                // error to the log file and quit, returning from this method.
                if (repository == null)
                {
                    // The parameter, 'repository', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "ProgrammaticLoggingConfigurator.Configure: *** *ERROR *** A null reference was passed for the 'repository' method parameter.  Stopping."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"ProgrammaticLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "ProgrammaticLoggingConfigurator.Configure: *** SUCCESS *** We have been passed a valid object reference for the 'repository' method parameter."
                );

                /*
                 * If we are here, then the caller of this method told us what pathname
                 * to utilize for the logfile.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: The 'logFileName' parameter was initialized."
                );

                System.Diagnostics.Debug.WriteLine(
                    "ProgrammaticLoggingConfigurator.Configure: Attempting to activate logging..."
                );

                if (!Activate.LoggingForLogFileName(logFileName, repository))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** Failed to set up logging for the log file name '{logFileName}'."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"ProgrammaticLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "ProgrammaticLoggingConfigurator.Configure: *** SUCCESS *** The logging infrastructure has been configured."
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
                $"ProgrammaticLoggingConfigurator.Configure: Result = {result}"
            );

            return result;
        }
    }
}