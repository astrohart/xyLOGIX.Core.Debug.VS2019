using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Methods to work with files and folders in a robust way.
    /// </summary>
    /// <remarks>
    /// These methods are here in order to assist applications in working with
    /// log files and prepping for application startup and first-time use.
    /// </remarks>
    public static class DebugFileAndFolderHelper
    {
        /// <summary>
        /// Attempts to clear the files and folders from the user's temporary
        /// files folder.
        /// </summary>
        public static void ClearTempFileDir()
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In DebugFileAndFolderHelper.ClearTempFileDir"
            );

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = @"C:\Windows\system32\cmd.exe",
                    Arguments =
                        "/C rd /S /Q \"" + Path.GetTempPath() + "\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                var proc = Process.Start(psi);
                proc.WaitForExit();
            }
            catch
            {
                // nothing
            }
        }

        /// <summary>
        /// Creates a folder if the folder does not already exist.
        /// </summary>
        /// <param name="directoryPath">
        /// (Required.) Path to the folder that you want to create.
        /// </param>
        /// <remarks>
        /// If the folder specified by the <paramref name="directoryPath" />
        /// parameter already exists on the disk, then this method does nothing.
        /// </remarks>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if the required parameter, <paramref name="directoryPath" />,
        /// is passed a blank or <c>null</c> value.
        /// </exception>
        public static void CreateDirectoryIfNotExists(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentException(
                    "Value cannot be null or whitespace.", nameof(directoryPath)
                );

            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "In DebugFileAndFolderHelper.CreateDirectoryIfNotExists"
            );

            // Dump the variable directoryPath to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: directoryPath = '{0}'",
                directoryPath
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Checking whether the folder '{0}' exists...",
                directoryPath
            );

            if (Directory.Exists(directoryPath))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: The folder '{0}' exists.  Nothing to do.",
                    directoryPath
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Done."
                );

                return;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Now attempting to create the folder '{0}'...",
                directoryPath
            );

            try
            {
                Directory.CreateDirectory(directoryPath);

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Checking whether we were successful..."
                );

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

                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Failed to create folder '{0}'.",
                    directoryPath
                );
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Done."
            );
        }

        /// <summary>
        /// Gets a collection of strings, each of which contains the pathname of
        /// a file is present in the specified <paramref name="folder" />..
        /// </summary>
        /// <param name="folder">
        /// (Required.) String containing the full pathname of the folder whose files are to be listed.
        /// </param>
        /// <returns>
        /// Collection of strings, each element of which contains the pathname
        /// of a file located in the specified <paramref name="folder" />.
        /// </returns>
        public static List<string> GetFilesInFolder(string folder)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In DebugFileAndFolderHelper.GetFilesInFolder"
            );

            var result = new List<string>();

            // Check to see if the required parameter, folder, is blank,
            // whitespace, or null. If it is any of these, send an error to the
            // log file and quit.

            // Dump the parameter folder to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DebugFileAndFolderHelper.GetFilesInFolder: folder = '{0}'",
                folder
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.GetFilesInFolder: Checking whether the required parameter, 'folder', is blank or not..."
            );

            if (string.IsNullOrWhiteSpace(folder))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DebugFileAndFolderHelper.GetFilesInFolder: Blank value passed for the 'folder' parameter. This parameter is required."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.GetFilesInFolder: {0} files found.",
                    result.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.GetFilesInFolder: Done."
                );

                // stop.
                return result;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.GetFilesInFolder: The parameter, 'folder', is not blank."
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                $"*** INFO: Checking whether the folder with path '{folder}' exists on the disk..."
            );

            if (!Directory.Exists(folder))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    $"*** ERROR *** The system could not locate the folder having the path '{folder}' on the disk.  This folder is required to exist in order for us to proceed."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    $"DebugFileAndFolderHelper.GetFilesInFolder: Result = {result}"
                );

                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    "DebugFileAndFolderHelper.GetFilesInFolder: Done."
                );

                return result;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                $"*** SUCCESS *** The folder with path '{folder}' was found on the disk.  Proceeding..."
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.GetFilesInFolder: Attempting to recursively get a list of all the files in the folder '{0}'...",
                folder
            );

            try
            {
                result = Directory
                    .GetFiles(folder, "*.*", SearchOption.AllDirectories)
                    .Where(File.Exists).ToList();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = new List<string>();
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.GetFilesInFolder: {0} files found.",
                result.Count
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.GetFilesInFolder: Done."
            );

            return result;
        }

        /// <summary>
        /// Checks to see if the specified file exists. If not, emits a "stop"
        /// error message and returns false; otherwise, returns true.
        /// </summary>
        /// <returns>
        /// This method returns <c>true</c> if the file with path specified by
        /// the <paramref name="fileName" /> parameter exists on the disk in the
        /// specified location or <c>false</c> if either the file is not found
        /// or if it does exist but an operating system error occurs (such as
        /// insufficient permissions) during the search.
        /// </returns>
        public static bool InsistPathExists(string fileName)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In DebugFileAndFolderHelper.InsistPathExists"
            );

            var result = false;

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DebugFileAndFolderHelper.InsistPathExists: Checking to make sure the file '{0}' actually exists...",
                fileName
            );

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

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "DebugFileAndFolderHelper.InsistPathExists: Result = {0}",
                        result
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "DebugFileAndFolderHelper.InsistPathExists: Done."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    $"*** ERROR *** The file with path '{fileName}' was not found."
                );

                result = false;
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);

                result = false;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DebugFileAndFolderHelper.InsistPathExists: The file '{0}' was not found.",
                fileName
            );

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DebugFileAndFolderHelper.InsistPathExists: Result = {0}",
                result
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.InsistPathExists: Done."
            );

            return result;
        }

        /// <summary>
        /// Checks for write access for the given file.
        /// </summary>
        /// <param name="path">
        /// (Required.) String containing the full pathname for which write
        /// permissions should be checked.
        /// </param>
        /// <returns>
        /// This method returns <c>true</c> if write access is allowed to the
        /// file with the specified <paramref name="path" />, otherwise <c>false</c>.
        /// <para />
        /// The value <c>false</c> is also returned in the event that the
        /// <paramref name="path" /> parameter is a <c>null</c> value or blank.
        /// <para />
        /// The value <c>false</c> is also returned if an operating system error
        /// or exception occurs while trying to look up the file's permissions.
        /// </returns>
        public static bool IsFileWriteable(string path)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In DebugFileAndFolderHelper.IsFileWriteable"
            );

            var result = false;

            try
            {
                // Check whether the file has the read-only attribute set.

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the file '{0}' has the read only attribute set...",
                    path
                );

                if ((File.GetAttributes(path) & FileAttributes.ReadOnly) != 0)
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "DebugFileAndFolderHelper.IsFileWriteable: The file '{0}' is not writeable.",
                        path
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "DebugFileAndFolderHelper.IsFileWriteable: Result = {0}",
                        result
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "DebugFileAndFolderHelper.IsFileWriteable: Done."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: Getting the access rules for the file '{0}' and current user...",
                    path
                );

                // Get the access rules of the specified files (user groups and
                // user names that have access to the file)
                var rules = File.GetAccessControl(path).GetAccessRules(
                    true, true, typeof(SecurityIdentifier)
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: Found {0} rules.",
                    rules.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: Accessing the groups that the current user is a member of..."
                );

                // Get the identity of the current user and the groups that the
                // user is in.
                var groups = WindowsIdentity.GetCurrent().Groups;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: The current user is a member of {0} groups.",
                    groups.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: Getting the Security Identifier (SID) for the current user..."
                );

                var sidCurrentUser = WindowsIdentity.GetCurrent().User.Value;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: The SID has been obtained."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the file '{0}' has Deny permissions to Write Data...",
                    path
                );

                // Check if writing to the file is explicitly denied for this
                // user or a group the user is in.
                if (rules.OfType<FileSystemAccessRule>().Any(
                    r => (groups.Contains(r.IdentityReference) ||
                          r.IdentityReference.Value == sidCurrentUser) &&
                         r.AccessControlType == AccessControlType.Deny &&
                         (r.FileSystemRights & FileSystemRights.WriteData) ==
                         FileSystemRights.WriteData
                ))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "DebugFileAndFolderHelper.IsFileWriteable: The file '{0}' is not writeable due to security settings.",
                        path
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "DebugFileAndFolderHelper.IsFileWriteable: Result = {0}",
                        result
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "DebugFileAndFolderHelper.IsFileWriteable: Done."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking if writing is allowed..."
                );

                // Check if writing is allowed
                result = rules.OfType<FileSystemAccessRule>().Any(
                    r => (groups.Contains(r.IdentityReference) ||
                          r.IdentityReference.Value == sidCurrentUser) &&
                         r.AccessControlType == AccessControlType.Allow &&
                         (r.FileSystemRights & FileSystemRights.WriteData) ==
                         FileSystemRights.WriteData
                );
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);

                result = false;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DebugFileAndFolderHelper.IsFileWriteable: Result = {0}", result
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.IsFileWriteable: Done."
            );

            return result;
        }

        /// <summary>
        /// Checks for write access for the given folder.
        /// </summary>
        /// <param name="path">
        /// (Required.) String containing the full pathname of the folder whose permissions are to be checked.
        /// </param>
        /// <returns>
        /// This method returns <c>true</c> if write access is allowed to the
        /// folder with the specified <paramref name="path" />, otherwise <c>false</c>.
        /// <para />
        /// The value <c>false</c> is also returned in the event that the
        /// <paramref name="path" /> parameter is a <c>null</c> value or blank.
        /// <para />
        /// The value <c>false</c> is also returned if an operating system error
        /// or exception occurs while trying to look up the folder's permissions.
        /// </returns>
        public static bool IsFolderWriteable(string path)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "In DebugFileAndFolderHelper.IsFolderWriteable"
            );

            var result = false;

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "*** INFO: Checking whether the 'path' parameter is not blank..."
            );

            if (string.IsNullOrWhiteSpace(path))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Blank value passed for path parameter. This parameter is required."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Result = {0}",
                    result
                );

                return result;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "*** SUCCESS *** The 'path' parameter is not blank.  We can proceed."
            );

            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** INFO: Checking whether the folder with path '{path}' exists on the disk..."
                );

                if (!Directory.Exists(path))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        $"*** ERROR *** The system could not locate the folder having the path '{path}' on the disk.  This folder is required to exist in order for us to proceed."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "DebugFileAndFolderHelper.IsFolderWriteable: Done."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** SUCCESS *** The folder with path '{path}' was found on the disk.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Getting the access rules for the folder '{0}' and current user...",
                    path
                );

                // Get the access rules of the specified files (user groups and
                // user names that have access to the folder)
                var rules = Directory.GetAccessControl(path).GetAccessRules(
                    true, true, typeof(SecurityIdentifier)
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Found {0} rules.",
                    rules.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Accessing the groups that the current user is a member of..."
                );

                // Get the identity of the current user and the groups that the
                // user is in.
                var groups = WindowsIdentity.GetCurrent().Groups;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFolderWriteable: The current user is a member of {0} groups.",
                    groups.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Getting the Security Identifier (SID) for the current user..."
                );

                var sidCurrentUser = WindowsIdentity.GetCurrent().User.Value;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFolderWriteable: The SID has been obtained."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the folder '{0}' has Deny permissions to Write Data...",
                    path
                );

                // Check if writing to the folder is explicitly denied for this
                // user or a group the user is in.
                if (rules.OfType<FileSystemAccessRule>().Any(
                    r => (groups.Contains(r.IdentityReference) ||
                          r.IdentityReference.Value == sidCurrentUser) &&
                         r.AccessControlType == AccessControlType.Deny &&
                         (r.FileSystemRights & FileSystemRights.WriteData) ==
                         FileSystemRights.WriteData
                ))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "DebugFileAndFolderHelper.IsFolderWriteable: The folder '{0}' is not writeable due to security settings.",
                        path
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "DebugFileAndFolderHelper.IsFolderWriteable: Result = {0}",
                        result
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "DebugFileAndFolderHelper.IsFolderWriteable: Done."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "DebugFileAndFolderHelper.IsFolderWriteable: Checking if writing to this folder is allowed..."
                );

                // Check if writing is allowed
                result = rules.OfType<FileSystemAccessRule>().Any(
                    r => (groups.Contains(r.IdentityReference) ||
                          r.IdentityReference.Value == sidCurrentUser) &&
                         r.AccessControlType == AccessControlType.Allow &&
                         (r.FileSystemRights & FileSystemRights.WriteData) ==
                         FileSystemRights.WriteData
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    result
                        ? "DebugFileAndFolderHelper.IsFolderWriteable: Writing to the folder '{0}' is allowed."
                        : "DebugFileAndFolderHelper.IsFolderWriteable: Writing to the folder '{0}' is not allowed.",
                    path
                );
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);

                result = false;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "DebugFileAndFolderHelper.IsFolderWriteable: Result = {0}",
                result
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "DebugFileAndFolderHelper.IsFolderWriteable: Done."
            );

            return result;
        }

        /// <summary>
        /// Gets a value indicating whether the
        /// <paramref
        ///     name="fullyQualifiedPath" />
        /// is actually a valid path on the system,
        /// according to operating-system-specific rules.
        /// </summary>
        /// <param name="fullyQualifiedPath">
        /// (Required.) String containing the path that is to be validated.
        /// </param>
        /// <returns>
        /// If the path provided in <paramref name="fullyQualifiedPath" /> is a
        /// valid path according to operating-system-specified rules, then this
        /// method returns <c>true</c>. Otherwise, the return value is <c>false</c>.
        /// </returns>
        public static bool IsValidPath(string fullyQualifiedPath)
        {
            var result = false;

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "*** INFO: Checking whether the value of the 'fullyQualifiedPath' parameter is blank..."
            );

            if (string.IsNullOrWhiteSpace(fullyQualifiedPath))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "DebugFileAndFolderHelper.IsValidPath: Blank value passed for the 'fullyQualifiedPath' parameter. This parameter is required."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Debug, $"DebugFileAndFolderHelper.IsValidPath: Result = {result}"
                );

                DebugUtils.WriteLine(DebugLevel.Debug, "DebugFileAndFolderHelper.IsValidPath: Done.");

                return result;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "*** SUCCESS *** The parameter 'fullyQualifiedPath' is not blank.  Continuing..."
            );

            try
            {
                _ = Path.GetFullPath(fullyQualifiedPath);

                result = true;
            }
            catch (Exception)
            {
                // Do not care what exception got thrown here.  It's enough, for 
                // now, to know that if that is the case, then the path specified
                // is not valid.

                result = false;
            }

            return result;
        }
    }
}