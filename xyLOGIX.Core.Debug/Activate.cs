﻿using log4net.Appender;
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
        /// <returns></returns>
        public static bool LoggingForLogFileName(
            string logFileName,
            ILoggerRepository repository
        )
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, logFileName, to the log
                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    $"Activate.LoggingForLogFileName: logFileName = '{logFileName}'"
                );

                if (string.IsNullOrWhiteSpace(logFileName)) return result;

                // Dump the parameter, 'repository', to the log.
                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    $"Activate.LoggingForLogFileName: repository = {repository}"
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "Activate.LoggingForLogFileName: Checking whether the 'repository' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, repository, is null. If it is, send an
                // error to the log file and quit, returning the default return value of this
                // method.
                if (repository == null)
                {
                    // the parameter repository is required.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "Activate.LoggingForLogFileName: *** ERROR *** A null reference was passed for the 'repository' method parameter.  Stopping."
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "Activate.LoggingForLogFileName: *** SUCCESS *** We have been passed a valid object reference for the 'repository' method parameter."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "Activate.LoggingForLogFileName: Checking whether the 'repository' parameter is of the type 'log4net.Repository.Hierarchy.Hierarchy'..."
                );

                if (!(repository is Hierarchy hierarchy))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** The 'repository' parameter is not of the type 'log4net.Repository.Hierarchy.Hierarchy'.  Stopping..."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        $"Activate.LoggingForLogFileName: Actual type of the 'repository' object is: '{repository.GetType()}'."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"Activate.LoggingForLogFileName: Result = {result}"
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "Activate.LoggingForLogFileName: *** SUCCESS *** The 'repository' parameter is of the type 'log4net.Repository.Hierarchy.Hierarchy'.  Proceeding..."
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

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "Activate.LoggingForLogFileName: Checking whether the logger is already configured..."
                );

                // Dump the value of the property, hierarchy.Configured, to the log
                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    $"Activate.LoggingForLogFileName: hierarchy.Configured = {hierarchy.Configured}"
                );

                if (result = hierarchy.Configured)
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "Activate.LoggingForLogFileName: *** SUCCESS *** The logger is already configured.  Stopping..."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"Activate.LoggingForLogFileName: Result = {result}"
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Warning,
                    "*** WARNING: The logger is not configured yet.  Doing so..."
                );

                /*
                 * If we are here, then the logging infrastructure has not
                 * yet been configured, so we do so now.
                 */

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "Activate.LoggingForLogFileName: Configuring the logging infrastructure..."
                );

                var patternLayout =
                    GetPatternLayout.ForConversionPattern(
                        "%date %-5level - %message%newline"
                    );
                if (patternLayout == null) return result;

                var roller = MakeNewRollingFileAppender
                             .ForRollingStyle(
                                 RollingFileAppender.RollingMode.Size
                             )
                             .AndHavingLogFileName(logFileName)
                             .WithPatternLayout(patternLayout)
                             .AndMaximumNumberOfRollingBackups(10)
                             .WithMaximumFileSizeOf("1GB")
                             .ThatShouldAppendToFile(true)
                             .AndThatHasAStaticLogFileName(true);

                roller.ActivateOptions();
                hierarchy.Root.AddAppender(roller);

                var memory = new MemoryAppender();
                memory.ActivateOptions();
                hierarchy.Root.AddAppender(memory);

                hierarchy.Root.Level = Level.All;
                hierarchy.Configured = true;

                result = hierarchy.Configured;

                if (result)
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "Activate.LoggingForLogFileName: *** SUCCESS *** The logging infrastructure has been configured."
                    );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"Activate.LoggingForLogFileName: Result = {result}"
            );

            return result;
        }
    }
}