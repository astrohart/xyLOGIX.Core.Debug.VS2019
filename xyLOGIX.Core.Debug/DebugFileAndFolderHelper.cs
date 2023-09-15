using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using Console = xyLOGIX.Core.Debug.OutputMultiplexer;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Methods to work with files and folders in a robust way. </summary>
    /// <remarks>
    /// These methods are here in order to assist applications in working
    /// with log files and prepping for application startup and first-time use.
    /// </remarks>
    public static class DebugFileAndFolderHelper
    {
        /// <summary>
        /// Gets a reference to an instance of an object that is to be used for
        /// thread synchronization purposes.
        /// </summary>
        private static object SyncRoot { get; } = new object();

        /// <summary>
        /// Attempts to clear the files and folders from the user's temporary
        /// files folder.
        /// </summary>
        public static void ClearTempFileDir()
        {
            Console.WriteLine("Clearing the temp folder...");

            var psi = new ProcessStartInfo
            {
                FileName =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.Windows
                        ), @"System32\cmd.exe"
                    ),
                Arguments =
                    "/C rd /S /Q \"" +
                    Environment.ExpandEnvironmentVariables("%TEMP%") + "\"",
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            try
            {
                lock
                    (SyncRoot) // only one thread at a time to clear the temp folder please!
                {
                    using (var processTemp = new Process())
                    {
                        processTemp.StartInfo = psi;
                        processTemp.Start();
                        processTemp.WaitForExit();
                    }
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }

        /// <summary> Creates a folder if the folder does not already exist. </summary>
        /// <param name="directoryPath">
        /// (Required.) Path to the folder that you want to
        /// create.
        /// </param>
        /// <remarks>
        /// If the folder specified by the <paramref name="directoryPath" />
        /// parameter already exists on the disk, then this method does nothing.
        /// </remarks>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if the required parameter,
        /// <paramref name="directoryPath" />, is passed a blank or <see langword="null" />
        /// value.
        /// </exception>
        public static void CreateDirectoryIfNotExists(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentException(
                    "Value cannot be null or whitespace.", nameof(directoryPath)
                );

            // write the name of the current class and method we are now
            if (Directory.Exists(directoryPath))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: The folder '{0}' exists.  Nothing to do.",
                    directoryPath
                );
                return;
            }

            try
            {
                lock
                    (SyncRoot) // only one thread at a time to create folders on the disk
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (Directory.Exists(directoryPath))
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: We successfully created the new folder '{0}'.",
                        directoryPath
                    );
                else
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Failed to create the folder '{0}'.",
                        directoryPath
                    );
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);
            }
        }

        /// <summary>
        /// Gets a collection of strings, each of which contains the pathname of
        /// a file is present in the specified <paramref name="folder" />.
        /// </summary>
        /// <param name="folder">
        /// (Required.) String containing the full pathname of the
        /// folder whose files are to be listed.
        /// </param>
        /// <returns>
        /// Collection of strings, each element of which contains the pathname of
        /// a file located in the specified <paramref name="folder" />.
        /// </returns>
        public static List<string> GetFilesInFolder(string folder)
        {
            // write the name of the current class and method we are now
            var result = new List<string>();

            // Check to see if the required parameter, folder, is blank,
            // whitespace, or null. If it is any of these, send an error to the
            if (string.IsNullOrWhiteSpace(folder))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DebugFileAndFolderHelper.GetFilesInFolder: Blank value passed for the 'folder' parameter. This parameter is required."
                );

                // stop.
                return result;
            }

            if (!Directory.Exists(folder))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    $"*** ERROR *** The system could not locate the folder having the path '{folder}' on the disk.  This folder is required to exist in order for us to proceed."
                );
                return result;
            }

            try
            {
                result = Directory.GetFiles(
                                      folder, "*.*", SearchOption.AllDirectories
                                  )
                                  .Where(File.Exists)
                                  .ToList();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = new List<string>();
            }

            return result;
        }

        /// <summary>
        /// Checks to see if the specified file exists. If not, emits a "stop"
        /// error message and returns false; otherwise, returns true.
        /// </summary>
        /// <returns>
        /// This method returns <see langword="true" /> if the file with path
        /// specified by the <paramref name="fileName" /> parameter exists on the disk in
        /// the specified location or <see langword="false" /> if either the file is not
        /// found or if it does exist but an operating system error occurs (such as
        /// insufficient permissions) during the search.
        /// </returns>
        public static bool InsistPathExists(string fileName)
        {
            // write the name of the current class and method we are now
            bool result;
            try
            {
                if (!string.IsNullOrWhiteSpace(fileName) &&
                    File.Exists(fileName))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "DebugFileAndFolderHelper.InsistPathExists: The file '{0}' was found.",
                        fileName
                    );

                    result = true;
                    return result;
                }

                result = false;
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);

                result = false;
            }

            return result;
        }

        /// <summary> Checks for write access for the given file. </summary>
        /// <param name="path">
        /// (Required.) String containing the full pathname for which
        /// write permissions should be checked.
        /// </param>
        /// <returns>
        /// This method returns <see langword="true" /> if write access is
        /// allowed to the file with the specified <paramref name="path" />, otherwise
        /// <see langword="false" />.
        /// <para />
        /// The value <see langword="false" /> is also returned in the event that the
        /// <paramref name="path" /> parameter is a <see langword="null" /> value or blank.
        /// <para />
        /// The value <see langword="false" /> is also returned if an operating system
        /// error or exception occurs while trying to look up the file's permissions.
        /// </returns>
        public static bool IsFileWriteable(string path)
        {
            // write the name of the current class and method we are now
            var result = false;

            try
            {
                // Check whether the file has the read-only attribute set.
                if ((File.GetAttributes(path) & FileAttributes.ReadOnly) != 0)
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "DebugFileAndFolderHelper.IsFileWriteable: The file '{0}' is not writeable.",
                        path
                    );
                    return result;
                }

                AuthorizationRuleCollection rules;

                // Get the access rules of the specified files (user groups and
                // user names that have access to the file)
                lock (SyncRoot)
                {
                    rules = File.GetAccessControl(path)
                                .GetAccessRules(
                                    true, true, typeof(SecurityIdentifier)
                                );
                }

                // Get the identity of the current user and the groups that the
                // user is in.
                IdentityReferenceCollection groups;
                lock (SyncRoot)
                {
                    groups = WindowsIdentity.GetCurrent()
                                            .Groups;
                }

                string sidCurrentUser;

                lock (SyncRoot)
                {
                    sidCurrentUser = WindowsIdentity.GetCurrent()
                                                    .User.Value;
                }

                // Check if writing to the file is explicitly denied for this
                // user or a group the user is in.
                if (rules.OfType<FileSystemAccessRule>()
                         .Any(
                             r => (groups.Contains(r.IdentityReference) ||
                                   r.IdentityReference.Value ==
                                   sidCurrentUser) &&
                                  r.AccessControlType ==
                                  AccessControlType.Deny &&
                                  (r.FileSystemRights &
                                   FileSystemRights.WriteData) ==
                                  FileSystemRights.WriteData
                         ))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "DebugFileAndFolderHelper.IsFileWriteable: The file '{0}' is not writeable due to security settings.",
                        path
                    );
                    return result;
                }

                // Check if writing is allowed
                result = rules.OfType<FileSystemAccessRule>()
                              .Any(
                                  r => (groups.Contains(r.IdentityReference) ||
                                        r.IdentityReference.Value ==
                                        sidCurrentUser) &&
                                       r.AccessControlType ==
                                       AccessControlType.Allow &&
                                       (r.FileSystemRights &
                                        FileSystemRights.WriteData) ==
                                       FileSystemRights.WriteData
                              );
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);

                result = false;
            }

            return result;
        }

        /// <summary> Checks for write access for the given folder. </summary>
        /// <param name="pathname">
        /// (Required.) String containing the full pathname of the
        /// folder whose permissions are to be checked.
        /// </param>
        /// <returns>
        /// This method returns <see langword="true" /> if write access is
        /// allowed to the folder with the specified <paramref name="pathname" />,
        /// otherwise <see langword="false" />.
        /// <para />
        /// The value <see langword="false" /> is also returned in the event that the
        /// <paramref name="pathname" /> parameter is a <see langword="null" /> value or
        /// blank.
        /// <para />
        /// The value <see langword="false" /> is also returned if an operating system
        /// error or exception occurs while trying to look up the folder's permissions.
        /// </returns>
        public static bool IsFolderWriteable(string pathname)
        {
            // write the name of the current class and method we are now
            var result = false;
            if (string.IsNullOrWhiteSpace(pathname))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Blank value passed for path parameter. This parameter is required."
                );
                return result;
            }

            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the folder '{pathname}' is writeable..."
                );

                if (!Directory.Exists(pathname))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        $"*** ERROR *** The system could not locate the folder having the path '{pathname}' on the disk.  This folder is required to exist in order for us to proceed."
                    );
                    return result;
                }

                // Get the access rules of the specified files (user groups and
                // user names that have access to the folder)
                var rules = Directory.GetAccessControl(pathname)
                                     .GetAccessRules(
                                         true, true, typeof(SecurityIdentifier)
                                     );

                // Get the identity of the current user and the groups that the
                // user is in.
                var groups = WindowsIdentity.GetCurrent()
                                            .Groups;
                if (!groups.Any())
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** The current user is not a member of any groups."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** INFO: {groups.Count} group(s) found of which the current user is a member."
                );

                var sidCurrentUser = WindowsIdentity.GetCurrent()
                                                    .User.Value;

                if (string.IsNullOrWhiteSpace(sidCurrentUser))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** Could not find the Security ID (SID) of the current user."
                    );

                    return result;
                }

                // Dump the current user's SID to the log
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** INFO: Current User's SID = '{sidCurrentUser}'"
                );

                // Check if writing to the folder is explicitly denied for this
                // user or a group the user is in.
                if (rules.OfType<FileSystemAccessRule>()
                         .Any(
                             r => (groups.Contains(r.IdentityReference) ||
                                   r.IdentityReference.Value ==
                                   sidCurrentUser) &&
                                  r.AccessControlType ==
                                  AccessControlType.Deny &&
                                  (r.FileSystemRights &
                                   FileSystemRights.WriteData) ==
                                  FileSystemRights.WriteData
                         ))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "DebugFileAndFolderHelper.IsFolderWriteable: The folder '{0}' is not writeable due to security settings.",
                        pathname
                    );
                    return result;
                }

                // Check if writing is allowed
                result = rules.OfType<FileSystemAccessRule>()
                              .Any(
                                  r => (groups.Contains(r.IdentityReference) ||
                                        r.IdentityReference.Value ==
                                        sidCurrentUser) &&
                                       r.AccessControlType ==
                                       AccessControlType.Allow &&
                                       (r.FileSystemRights &
                                        FileSystemRights.WriteData) ==
                                       FileSystemRights.WriteData
                              );
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Gets a value indicating whether the
        /// <paramref name="fullyQualifiedPath" /> is actually a valid path on the system,
        /// according to operating-system-specific rules.
        /// </summary>
        /// <param name="fullyQualifiedPath">
        /// (Required.) String containing the path that
        /// is to be validated.
        /// </param>
        /// <returns>
        /// If the path provided in <paramref name="fullyQualifiedPath" /> is a
        /// valid path according to operating-system-specified rules, then this method
        /// returns <see langword="true" />. Otherwise, the return value is
        /// <see langword="false" />.
        /// </returns>
        public static bool IsValidPath(string fullyQualifiedPath)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(fullyQualifiedPath))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DebugFileAndFolderHelper.IsValidPath: Blank value passed for the 'fullyQualifiedPath' parameter. This parameter is required."
                );
                return result;
            }

            try
            {
                _ = Path.GetFullPath(fullyQualifiedPath);

                result = true;
            }
            catch (Exception)
            {
                // Do not care what exception got thrown here. It's enough, for
                // now, to know that if that is the case, then the path
                // specified is not valid.

                result = false;
            }

            return result;
        }
    }
}