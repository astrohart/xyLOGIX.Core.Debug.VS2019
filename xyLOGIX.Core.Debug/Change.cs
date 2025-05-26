using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods for changing the value(s) of data element(s).
    /// </summary>
    internal static class Change
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Change" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Change() { }

        /// <summary>
        /// Changes the pathname of the log file to the specified
        /// <paramref name="newLogFilePath" />.
        /// </summary>
        /// <param name="newLogFilePath">
        /// (Required.) A <see cref="T:System.String" /> that contains the fully-qualified
        /// pathname of the new log file.
        /// </param>
        /// <param name="overwrite">
        /// (Optional.) A <see cref="T:System.Boolean" /> value that indicates whether the
        /// file having the specified <paramref name="newLogFilePath" /> is to be truncated
        /// and overwritten with the latest logging information.
        /// <para />
        /// The default value of this parameter is <see langword="true" />.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the operation(s) were successful;
        /// <see langword="false" /> otherwise.
        /// </returns>
        internal static bool LogFilePathname(
            [NotLogged] string newLogFilePath,
            bool overwrite = true
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "Change.LogFilePathname *** INFO: Checking whether the value of the parameter, 'newLogFilePath', is blank..."
                );

                // Check whether the value of the parameter, 'newLogFilePath', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(newLogFilePath))
                {
                    // The parameter, 'newLogFilePath' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Change.LogFilePathname: The parameter, 'newLogFilePath', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Change.LogFilePathname: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Change.LogFilePathname: *** SUCCESS *** The parameter 'newLogFilePath', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Change.LogFilePathname: *** FYI *** Attempting to get a reference to the Hierarchy repository..."
                );

                var hierarchy =
                    LoggerRepositoryManager.GetHierarchyRepository() ??
                    LoggerRepositoryManager.InitialRepository;

                System.Diagnostics.Debug.WriteLine(
                    "Change.LogFilePathname: Checking whether the variable, 'hierarchy', has a null reference for a value..."
                );

                // Check to see if the variable, 'hierarchy', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (hierarchy == null)
                {
                    // The variable, 'hierarchy', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Change.LogFilePathname: *** ERROR ***  The variable, 'hierarchy', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Change.LogFilePathname: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'hierarchy', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "Change.LogFilePathname: *** SUCCESS *** The variable, 'hierarchy', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Change.LogFilePathname: *** FYI *** Attempting to activate logging for the new log file path, '{newLogFilePath}'..."
                );

                // Activate logging for the new log file path.
                Switch.LoggingForLogFileName(newLogFilePath, hierarchy);

                if (overwrite)
                    System.Diagnostics.Debug.WriteLine(
                        $"Change.LogFilePathname: *** FYI *** Attempting to truncate the log file, '{newLogFilePath}'..."
                    );

                // Check to see whether the truncation operation was successful.
                // If this is not the case, then write an error message to the log file,
                // and then skip to the next loop iteration.
                if (overwrite && !Truncate.FileHavingPath(newLogFilePath))
                {
                    // The truncation operation was NOT successful.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Change.LogFilePathname: *** ERROR: The truncation operation was NOT successful.  Stopping..."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"Change.LogFilePathname: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                if (overwrite)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Change.LogFilePathname: *** SUCCESS *** The truncation operation was successful.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "Change.LogFilePathname: *** FYI *** Writing the current timestamp to the first line of the new log file..."
                    );

                    Write.LogFileTimestamp();
                }

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Change.LogFilePathname: Result = {result}"
            );

            return result;
        }
    }
}