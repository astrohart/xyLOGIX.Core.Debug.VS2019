using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static method(s) for writing to the log file.
    /// </summary>
    public static class Write
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Write" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Write() { }

        /// <summary>
        /// Emits a timestamp to the log file. This is useful for debugging purposes.
        /// </summary>
        public static void LogFileTimestamp()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "Write.LogFileTimestamp: *** FYI *** Writing the timestamp to the log file..."
                );

                /*
                 * NOTE: For the vast majority of this file, we are using
                 * System.Diagnostics.Debug.WriteLine to send logging messages.
                 *
                 * However, this method is supposed to touch the log file (except
                 * for when an exception is caught), so we are supposed to call
                 * DebugUtils.WriteLine here.
                 */

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** LOG STARTED ON {DateTime.Now.ToLongDateString()} at {DateTime.Now.ToLongTimeString()}"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Write.LogFileTimestamp: *** SUCCESS *** The timestamp has been written to the log file."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}