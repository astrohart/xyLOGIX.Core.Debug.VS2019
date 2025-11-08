using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods for interacting with the
    /// Windows Event Log.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetEvent
    {
        /// <summary>
        /// Attempts to obtain a reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that represents the proper assembly
        /// to use for event logging.
        /// </summary>
        /// <returns>
        /// If successful, a reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that represents the proper assembly
        /// to use for event logging; otherwise, a <see langword="null" /> reference is
        /// returned.
        /// </returns>
        private static Assembly SourceAssembly()
        {
            Assembly result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceAssembly: *** FYI *** Attempting to get a reference to the currently-executing assembly..."
                );

                // Get a reference to the currently-executing assembly.
                var executingAssembly = Assembly.GetExecutingAssembly();

                /*
                 * NOTE: We do not need to check whether 'executingAssembly' is null.
                 * The method we call next does that.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceAssembly: *** FYI *** Attempting to get a reference to the currently-executing assembly..."
                );

                result = GetAssembly.ToUseForEventLogging(executingAssembly);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to the proper assembly to be used for an event source.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to the proper assembly to be used for an event source.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Attempts to obtain a user-friendly display name for the event-logging
        /// quote, based on the name of the application that is calling this debug logging
        /// library.
        /// </summary>
        /// <returns></returns>
        internal static string SourceName()
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceName: *** FYI *** Attempting to get a reference to the proper Assembly that is to be used as an Event Source..."
                );

                var eventLoggingAssembly = SourceAssembly();

                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceName: Checking whether the variable, 'eventLoggingAssembly', has a null reference for a value..."
                );

                // Check to see if the variable, eventLoggingAssembly, is null.  If it is, send an error
                // to the log file and terminate the execution of this method, returning
                // the default return value.
                if (eventLoggingAssembly == null)
                {
                    // the variable eventLoggingAssembly is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** Could not obtain a reference to the .NET assembly that contains the application entry-point.  Falling back to the calling assembly..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetEvent.SourceName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, eventLoggingAssembly, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceName: *** SUCCESS *** The variable, 'eventLoggingAssembly', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceName: *** FYI *** Attempting to obtain the fully-qualified pathname of the event-source assembly..."
                );

                var eventLoggingAssemblyPathname =
                    GetAssembly.Pathname(eventLoggingAssembly);

                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceName: Checking whether the variable, 'eventLoggingAssemblyPathname', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'eventLoggingAssemblyPathname', is null or blank. If it is,
                // then send an  error to the log file and quit, returning the default value
                // of the result variable.
                if (string.IsNullOrWhiteSpace(eventLoggingAssemblyPathname))
                {
                    // the variable eventLoggingAssemblyPathname is required.
                    System.Diagnostics.Debug.WriteLine(
                        "GetEvent.SourceName: *** ERROR *** The fully-qualified pathname of the entry-point assembly could not be determined, or a ile having that path could not be located on the filesystem."
                    );

                    // log the result
                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetEvent.SourceName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"GetEvent.SourceName: *** SUCCESS *** {eventLoggingAssemblyPathname.Length} B of data appear to be present in the variable, 'eventLoggingAssemblyPathname'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** INFO: Checking whether the file with path, '{eventLoggingAssemblyPathname}', exists on the file system..."
                );

                // Check whether a folder having the path, 'eventLoggingAssemblyPathname', exists on the file system.
                // If it does not, then write an error message to the log file, and then terminate
                // the execution of this method, returning the default return value.
                if (!File.Exists(eventLoggingAssemblyPathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the file having the path, '{eventLoggingAssemblyPathname}', on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetEvent.SourceName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"*** SUCCESS *** The file with path, '{eventLoggingAssemblyPathname}', was found on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to get the FileVersionInfo of the assembly, '{eventLoggingAssemblyPathname}'..."
                );

                var fileVersionInfo =
                    FileVersionInfo.GetVersionInfo(
                        eventLoggingAssemblyPathname
                    );

                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceName: Checking whether the variable, 'fileVersionInfo', has a null reference for a value..."
                );

                // Check to see if the variable, fileVersionInfo, is null.  If it is, send an error
                // to the log file and terminate the execution of this method, returning
                // the default return value.
                if (fileVersionInfo == null)
                {
                    // the variable fileVersionInfo is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "GetEvent.SourceName: *** ERROR ***  The variable, 'fileVersionInfo', has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetEvent.SourceName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, fileVersionInfo, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "GetEvent.SourceName: *** SUCCESS *** The variable, 'fileVersionInfo', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to get the ProductName of the file version info for the assembly, '{eventLoggingAssemblyPathname}'..."
                );

                result = fileVersionInfo.ProductName;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"GetEvent.SourceName: Result = '{result}'"
            );

            return result;
        }
    }
}