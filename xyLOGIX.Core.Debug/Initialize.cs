using Alphaleonis.Win32.Filesystem;
using System;
using System.Text.RegularExpressions;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Exposes <see langword="static" /> methods to initialize data. </summary>
    public static class Initialize
    {
        /// <summary> Called once per application to initialize the logging subsystem. </summary>
        /// <param name="applicationName">
        /// (Required.) String containing the name to be
        /// used for the application in the log file's pathname.
        /// <para />
        /// All whitespace will be removed.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the initialization was successful;
        /// <see langword="false" /> otherwise.
        /// </returns>
        /// <remarks>
        /// This method is to be utilized if you aren't utilizing a logging
        /// framework, such as <c>log4net</c> or <c>PostSharp</c> etc.
        /// </remarks>
        public static bool Logging(string applicationName)
        {
            var success = true; // successful unless found otherwise

            if (string.IsNullOrWhiteSpace(applicationName))
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(applicationName)
                );

            SetLog.ApplicationName = string.Empty;

            try
            {
                /*
                 * The value of the SetLog.ApplicationName property
                 * should be whatever is passed to the applicationName
                 * parameter of this method, without a company name and
                 * without spaces.
                 */

                SetLog.ApplicationName = Regex.Replace(
                    applicationName, @"\s+", ""
                );

                if (!Directory.Exists(GetLog.FileFolder))
                    Directory.CreateDirectory(GetLog.FileFolder);
            }
            catch (Exception ex)
            {
                success = false;

                SetLog.ApplicationName = string.Empty;

                // dump all the exception info to the log
                Console.WriteLine(ex);
            }

            return success;
        }
    }
}