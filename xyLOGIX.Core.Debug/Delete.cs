using PostSharp.Patterns.Diagnostics;
using System;
using System.IO;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Methods to delete files and folders. </summary>
    [Log(AttributeExclude = true)]
    internal static class Delete
    {
        /// <summary>
        /// Deletes the file having the specified <paramref name="pathname" />, if
        /// it exists.
        /// </summary>
        /// <param name="pathname">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the fully-qualified pathname of the file that is to be deleted.
        /// </param>
        /// <remarks>
        /// If the <paramref name="pathname" /> parameter is blank, the
        /// <see cref="F:System.String.Empty" /> value, or <see langword="null" />, then
        /// this method returns <see langword="false" />.
        /// <para />
        /// This method also returns <see langword="false" /> if the file having the
        /// specified
        /// <paramref name="pathname" /> does not already exist on the file system.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the file having the specified
        /// <paramref name="pathname" /> was found on the file system and successfully
        /// deleted; <see langword="false" /> otherwise.
        /// </returns>
        internal static bool FileIfExists([NotLogged] string pathname)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine($"*** FYI *** Attempting to delete the file having the pathname, '{pathname}'...");

                System.Diagnostics.Debug.WriteLine(
                    "Delete.FileIfExists *** INFO: Checking whether the value of the parameter, 'pathname', is blank..."
                );

                // Check whether the value of the parameter, 'pathname', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(pathname))
                {
                    // The parameter, 'pathname', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Delete.FileIfExists: *** ERROR *** The parameter, 'pathname', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Delete.FileIfExists: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'pathname', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Delete.FileIfExists *** INFO: Checking whether the file having pathname, '{pathname}', exists on the file system..."
                );

                // Check whether a file having pathname, 'pathname', exists on the file system.
                // If it does not, then write an FYI message to the Debug output, and then
                // terminate the execution of this method, but return TRUE.
                if (!File.Exists(pathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** The system could not locate the file having pathname, '{pathname}', on the file system.  There is nothing to do. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Delete.FileIfExists: Result = {true}"
                    );

                    // stop.
                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Delete.FileIfExists *** SUCCESS *** The file having pathname, '{pathname}', was found on the file system.  Attempting to delete it..."
                );

                File.Delete(pathname);

                /*
                 * Base whether this method succeeded or failed on whether the file
                 * was successfully deleted.
                 */

                result = !File.Exists(pathname);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            return result;
        }

        /// <summary> Deletes a log file having the specified <paramref name="pathname" />. </summary>
        /// <param name="pathname">
        /// (Required.) String containing the fully-qualified pathname
        /// of the file that is to be deleted.
        /// </param>
        /// <remarks>
        /// If the <paramref name="pathname" /> parameter is blank or
        /// <see langword="null" />, then this method does nothing.
        /// <para />
        /// This method also takes no action if the file having the specified
        /// <paramref name="pathname" /> does not already exist on the file system.
        /// </remarks>
        internal static void LogFile([NotLogged] string pathname)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"*** FYI *** Attempting to delete the file having the pathname, '{pathname}'...");

                System.Diagnostics.Debug.WriteLine(
                    "Delete.LogFile: Checking whether the value of the required method parameter, 'pathname' parameter is null or consists solely of whitespace..."
                );

                if (string.IsNullOrWhiteSpace(pathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Delete.LogFile: *** ERROR *** Null or blank value passed for the parameter, 'pathname'.  Stopping..."
                    );

                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Delete.LogFile: *** SUCCESS *** The value of the required parameter, 'pathname', is not blank.  Continuing..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Delete.LogFile *** INFO: Checking whether the file having pathname, '{pathname}', exists on the file system..."
                );

                // Check whether a file having pathname, 'pathname', exists on the file system.
                // If it does not, then write an FYI message to the Debug output, and then
                // terminate the execution of this method.
                if (!File.Exists(pathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** The system could not locate the file having pathname, '{pathname}', on the file system.  There is nothing to do.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Delete.LogFile *** SUCCESS *** The file having pathname, '{pathname}', was found on the file system.  Attempting to delete it..."
                );

                File.Delete(pathname);

                System.Diagnostics.Debug.WriteLine(
                    !File.Exists(pathname)
                        ? $"*** SUCCESS *** Deleted the file having the pathname, '{pathname}', from the file system.  Proceeding..."
                        : $"*** ERROR *** FAILED to delete the file having the pathname, '{pathname}', from the file system.  Stopping..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}