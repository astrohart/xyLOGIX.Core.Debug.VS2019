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
        /// files directory.
        /// </summary>
        public static void ClearTempFileDir()
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In FileAndFolderHelpers.ClearTempFileDir"
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
                "In FileAndFolderHelpers.CreateDirectoryIfNotExists"
            );

            // Dump the variable directoryPath to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "FileAndFolderHelpers.CreateDirectoryIfNotExists: directoryPath = '{0}'",
                directoryPath
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "FileAndFolderHelpers.CreateDirectoryIfNotExists: Checking whether the directory '{0}' exists...",
                directoryPath
            );

            if (Directory.Exists(directoryPath))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.CreateDirectoryIfNotExists: The directory '{0}' exists.  Nothing to do.",
                    directoryPath
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.CreateDirectoryIfNotExists: Done."
                );

                return;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "FileAndFolderHelpers.CreateDirectoryIfNotExists: Now attempting to create the directory '{0}'...",
                directoryPath
            );

            try
            {
                Directory.CreateDirectory(directoryPath);

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.CreateDirectoryIfNotExists: Checking whether we were successful..."
                );

                if (Directory.Exists(directoryPath))
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "FileAndFolderHelpers.CreateDirectoryIfNotExists: We successfully created the new directory '{0}'.",
                        directoryPath
                    );
                else
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "FileAndFolderHelpers.CreateDirectoryIfNotExists: Failed to create the directory '{0}'.",
                        directoryPath
                    );
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);

                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "FileAndFolderHelpers.CreateDirectoryIfNotExists: Failed to create directory '{0}'.",
                    directoryPath
                );
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "FileAndFolderHelpers.CreateDirectoryIfNotExists: Done."
            );
        }

        public static List<string> GetFilesInFolder(string folder)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In MainWindowPresenter.GetFilesInFolder"
            );

            var result = new List<string>();

            // Check to see if the required parameter, folder, is blank,
            // whitespace, or null. If it is any of these, send an error to the
            // log file and quit.

            // Dump the parameter folder to the log
            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "MainWindowPresenter.GetFilesInFolder: folder = '{0}'", folder
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "MainWindowPresenter.GetFilesInFolder: Checking whether the required parameter, 'folder', is blank or not..."
            );

            if (string.IsNullOrWhiteSpace(folder))
            {
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "MainWindowPresenter.GetFilesInFolder: Blank value passed for the 'folder' parameter. This parameter is required."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "MainWindowPresenter.GetFilesInFolder: {0} files found.",
                    result.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "MainWindowPresenter.GetFilesInFolder: Done."
                );

                // stop.
                return result;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "MainWindowPresenter.GetFilesInFolder: The parameter, 'folder', is not blank."
            );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "MainWindowPresenter.GetFilesInFolder: Attempting to recursively get a list of all the files in the folder '{0}'...",
                folder
            );

            try
            {
                result = Directory
                    .GetFiles(folder, "*.*", SearchOption.AllDirectories)
                    .Where(File.Exists).ToList();
            }
            catch (Exception)
            {
                result = new List<string>();
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "MainWindowPresenter.GetFilesInFolder: {0} files found.",
                result.Count
            );

            DebugUtils.WriteLine(
                DebugLevel.Info, "MainWindowPresenter.GetFilesInFolder: Done."
            );

            return result;
        }

        /// <summary>
        /// Checks to see if the specified file exists. If not, emits a "stop"
        /// error message and returns false; otherwise, returns true.
        /// </summary>
        public static bool InsistPathExists(string fileName)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In FileAndFolderHelpers.InsistPathExists"
            );

            var result = false;

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "FileAndFolderHelpers.InsistPathExists: Checking to make sure the file '{0}' actually exists...",
                fileName
            );

            try
            {
                if (!string.IsNullOrWhiteSpace(fileName) &&
                    File.Exists(fileName))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "FileAndFolderHelpers.InsistPathExists: The file '{0}' was found.",
                        fileName
                    );

                    result = true;

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "FileAndFolderHelpers.InsistPathExists: Result = {0}",
                        result
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "FileAndFolderHelpers.InsistPathExists: Done."
                    );

                    return result;
                }
            }
            catch (Exception e)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(e);

                result = false;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "FileAndFolderHelpers.InsistPathExists: The file '{0}' was not found.",
                fileName
            );

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                "FileAndFolderHelpers.InsistPathExists: Result = {0}", result
            );

            DebugUtils.WriteLine(
                DebugLevel.Info, "FileAndFolderHelpers.InsistPathExists: Done."
            );

            return result;
        }

        /// <summary>
        /// Checks for write access for the given file.
        /// </summary>
        /// <param name="path">
        /// The filename.
        /// </param>
        /// <returns>
        /// true, if write access is allowed, otherwise false
        /// </returns>
        public static bool IsFileWriteable(string path)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In FileAndFolderHelpers.IsFileWriteable"
            );

            var result = false;

            try
            {
                // Check whether the file has the read-only attribute set.

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: Checking whether the file '{0}' has the read only attribute set...",
                    path
                );

                if ((File.GetAttributes(path) & FileAttributes.ReadOnly) != 0)
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "FileAndFolderHelpers.IsFileWriteable: The file '{0}' is not writeable.",
                        path
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "FileAndFolderHelpers.IsFileWriteable: Result = {0}",
                        result
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "FileAndFolderHelpers.IsFileWriteable: Done."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: Getting the access rules for the file '{0}' and current user...",
                    path
                );

                // Get the access rules of the specified files (user groups and
                // user names that have access to the file)
                var rules = File.GetAccessControl(path).GetAccessRules(
                    true, true, typeof(SecurityIdentifier)
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: Found {0} rules.",
                    rules.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: Accessing the groups that the current user is a member of..."
                );

                // Get the identity of the current user and the groups that the
                // user is in.
                var groups = WindowsIdentity.GetCurrent().Groups;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: The current user is a member of {0} groups.",
                    groups.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: Getting the Security Identifier (SID) for the current user..."
                );

                var sidCurrentUser = WindowsIdentity.GetCurrent().User.Value;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: The SID has been obtained."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: Checking whether the file '{0}' has Deny permissions to Write Data...",
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
                        "FileAndFolderHelpers.IsFileWriteable: The file '{0}' is not writeable due to security settings.",
                        path
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "FileAndFolderHelpers.IsFileWriteable: Result = {0}",
                        result
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "FileAndFolderHelpers.IsFileWriteable: Done."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFileWriteable: Checking if writing is allowed..."
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
                "FileAndFolderHelpers.IsFileWriteable: Result = {0}", result
            );

            DebugUtils.WriteLine(
                DebugLevel.Info, "FileAndFolderHelpers.IsFileWriteable: Done."
            );

            return result;
        }

        /// <summary>
        /// Checks for write access for the given directory.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to check.
        /// </param>
        /// <returns>
        /// true, if write access is allowed, otherwise false
        /// </returns>
        public static bool IsFolderWriteable(string path)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In FileAndFolderHelpers.IsFolderWriteable"
            );

            var result = false;

            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFolderWriteable: Getting the access rules for the folder '{0}' and current user...",
                    path
                );

                // Get the access rules of the specified files (user groups and
                // user names that have access to the folder)
                var rules = Directory.GetAccessControl(path).GetAccessRules(
                    true, true, typeof(SecurityIdentifier)
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFolderWriteable: Found {0} rules.",
                    rules.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFolderWriteable: Accessing the groups that the current user is a member of..."
                );

                // Get the identity of the current user and the groups that the
                // user is in.
                var groups = WindowsIdentity.GetCurrent().Groups;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFolderWriteable: The current user is a member of {0} groups.",
                    groups.Count
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFolderWriteable: Getting the Security Identifier (SID) for the current user..."
                );

                var sidCurrentUser = WindowsIdentity.GetCurrent().User.Value;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFolderWriteable: The SID has been obtained."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFolderWriteable: Checking whether the folder '{0}' has Deny permissions to Write Data...",
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
                        "FileAndFolderHelpers.IsFolderWriteable: The folder '{0}' is not writeable due to security settings.",
                        path
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        "FileAndFolderHelpers.IsFolderWriteable: Result = {0}",
                        result
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "FileAndFolderHelpers.IsFolderWriteable: Done."
                    );

                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAndFolderHelpers.IsFolderWriteable: Checking if writing to this folder is allowed..."
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
                        ? "FileAndFolderHelpers.IsFolderWriteable: Writing to the folder '{0}' is allowed."
                        : "FileAndFolderHelpers.IsFolderWriteable: Writing to the folder '{0}' is not allowed.",
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
                "FileAndFolderHelpers.IsFolderWriteable: Result = {0}", result
            );

            DebugUtils.WriteLine(
                DebugLevel.Info, "FileAndFolderHelpers.IsFolderWriteable: Done."
            );

            return result;
        }
    }
}