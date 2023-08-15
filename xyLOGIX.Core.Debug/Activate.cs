using log4net.Appender;
using log4net.Core;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods to activate functionality, such as logging.
    /// </summary>
    public static class Activate
    {
        /// <summary>
        /// Gets a reference to an instance of an object that is to be used for thread synchronization purposes.
        /// </summary>
        private static object SyncRoot { get; } = new object();

        /// <summary>
        /// Sets up logging programmatically (as opposed to using an <c>app.config</c>
        /// file), using the specified <paramref name="logFileName" /> for the log and
        /// perhaps the provided log file <paramref name="repository" /> (say, serving as a
        /// relay to PostSharp).
        /// </summary>
        /// <param name="logFileName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the fully-qualified pathname of the log file that is to be written.
        /// </param>
        /// <param name="repository">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Repository.ILoggerRepository" /> interface
        /// that plays the role of the <c>Hierarchy</c> object that is configured for
        /// logging.
        /// </param>
        /// <returns></returns>
        public static bool LoggingForLogFileName(string logFileName,
            ILoggerRepository repository)
        {
            var result = false;

            try
            {
                if (string.IsNullOrWhiteSpace(logFileName)) return result;

                if (!(repository is Hierarchy hierarchy)) return result;

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

                if (result = hierarchy.Configured) return result;

                /*
                 * If we are here, then the logging infrastructure has not
                 * yet been configured, so we do so now.
                 */

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

                lock (SyncRoot)
                {
                    roller.ActivateOptions();
                    hierarchy.Root.AddAppender(roller);
                }

                hierarchy.Root.Level = Level.All;
                hierarchy.Configured = true;

                result = hierarchy.Configured;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }

            return result;
        }
    }
}