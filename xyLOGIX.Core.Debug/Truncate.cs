using System.Diagnostics;
using PostSharp.Patterns.Diagnostics;
using System;
using System.IO;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static method(s) that truncate an existing file(s) to zero bytes.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class Truncate
    {
        /// <summary>
        /// Truncates the file identified by <paramref name="pathname" /> so its length
        /// becomes zero bytes while leaving the file entry itself on the file system.
        /// If the file does not exist, the method returns <see langword="true" /> because
        /// there is nothing to do.
        /// If <paramref name="pathname" /> is <see langword="null" />, empty, or contains
        /// only whitespace, the method returns <see langword="false" />.
        /// </summary>
        /// <param name="pathname">
        /// (Required.) The fully-qualified path of the file to truncate.
        /// </param>
        /// <returns>
        /// <see langword="true" /> when the operation succeeds or when the target file
        /// is absent; <see langword="false" /> when the path is invalid or an error
        /// occurs while truncating.
        /// </returns>
        internal static bool FileHavingPath([NotLogged] string pathname)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "Truncate.FileHavingPath *** INFO: Checking whether the value of the parameter, 'pathname', is blank..."
                );

                // Check whether the value of the parameter, 'pathname', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(pathname))
                {
                    // The parameter, 'pathname' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Truncate.FileHavingPath: The parameter, 'pathname', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Truncate.FileHavingPath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'pathname', is not blank.  Proceeding..."
                );

                // Nothing to do if the file is not present.
                System.Diagnostics.Debug.WriteLine(
                    $"Truncate.FileHavingPath *** INFO: Checking whether the file having pathname, '{pathname}', exists on the file system..."
                );

                // Check whether a file having pathname, 'pathname', exists on the file system.
                // If it does not, then write an FYI message to the log file, and then terminate
                // the execution of this method, returning true.
                if (!File.Exists(pathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"Truncate.FileHavingPath: *** FYI *** The system could not locate the file having pathname, '{pathname}', on the file system.  There is nothing to do.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Truncate.FileHavingPath: Result = {true}"
                    );

                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Truncate.FileHavingPath: *** SUCCESS *** The file having pathname, '{pathname}', was found on the file system.  Proceeding to truncate the file..."
                );

                // Opening with FileMode.Truncate sets the length to zero immediately.
                using (var fs = new FileStream(
                           pathname, FileMode.Truncate, FileAccess.Write,
                           FileShare.Read
                       ))
                {
                    // No additional work required.
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
                $"Truncate.FileHavingPath: Result = {result}"
            );

            return result;
        }
    }
}