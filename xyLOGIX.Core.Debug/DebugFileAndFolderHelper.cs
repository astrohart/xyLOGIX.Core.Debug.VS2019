using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

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
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.DebugFileAndFolderHelper" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static DebugFileAndFolderHelper() { }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the fully-qualified
        /// username of the currently-logged-in OS user.
        /// </summary>
        internal static string FullyQualifiedUserName
        {
            [DebuggerStepThrough]
            get
            {
                string result;

                try
                {
                    result =
                        $@"{Environment.UserDomainName}\{Environment.UserName}";
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = string.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Attempts to clear the files and folders from the user's temporary
        /// files folder.
        /// </summary>
        public static void ClearTempFileDir()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "Clearing the temp folder..."
                );

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
                        Environment.ExpandEnvironmentVariables("%TEMP%") +
                        "\"",
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };

                using (var processTemp = new Process())
                {
                    processTemp.StartInfo = psi;
                    processTemp.Start();
                    processTemp.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary> Creates a folder if the folder does not already exist. </summary>
        /// <param name="directoryPath">
        /// (Required.) Path to the folder that you want to
        /// create.
        /// </param>
        /// <remarks>
        /// If the folder specified by the <paramref name="directoryPath" />
        /// parameter already exists on the filesystem, then this method does nothing.
        /// </remarks>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if the required parameter,
        /// <paramref name="directoryPath" />, is passed a blank or <see langword="null" />
        /// value.
        /// </exception>
        public static void CreateDirectoryIfNotExists(
            [NotLogged] string directoryPath
        )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.CreateDirectoryIfNotExists *** INFO: Checking whether the value of the parameter, 'directoryPath', is blank..."
                );

                // Check whether the value of the parameter, 'directoryPath', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(directoryPath))
                {
                    // The parameter, 'directoryPath' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.CreateDirectoryIfNotExists: *** ERROR *** The parameter, 'directoryPath' was either passed a null value, or it is blank. Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'directoryPath' is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Checking whether the folder, '{directoryPath}', already exists..."
                );

                // Check to see whether the folder already exists.
                // Otherwise, write an error message to the log file,
                // and then terminate the execution of this method.
                if (Directory.Exists(directoryPath))
                {
                    // The folder already exists.  There is nothing else to be done.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** The folder, '{directoryPath}', already exists.  There is nothing else to be done.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.CreateDirectoryIfNotExists: *** FYI *** The folder, '{directoryPath}', does NOT already exist.  Attempting to create it..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to create the folder, '{directoryPath}'..."
                );

                Directory.CreateDirectory(directoryPath);

                System.Diagnostics.Debug.WriteLine(
                    Directory.Exists(directoryPath)
                        ? $"DebugFileAndFolderHelper.CreateDirectoryIfNotExists: We successfully created the new folder, '{directoryPath}'."
                        : $"DebugFileAndFolderHelper.CreateDirectoryIfNotExists: Failed to create the folder, '{directoryPath}'."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Checks to see if the specified file exists. If not, emits a "stop"
        /// error message and returns false; otherwise, returns true.
        /// </summary>
        /// <returns>
        /// This method returns <see langword="true" /> if the file with path
        /// specified by the <paramref name="fileName" /> parameter exists on the
        /// filesystem in
        /// the specified location or <see langword="false" /> if either the file is not
        /// found or if it does exist but an operating system error occurs (such as
        /// insufficient permissions) during the search.
        /// </returns>
        public static bool InsistPathExists([NotLogged] string fileName)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.InsistPathExists *** INFO: Checking whether the value of the parameter, 'fileName', is blank..."
                );

                // Check whether the value of the parameter, 'fileName', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    // The parameter, 'fileName' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.InsistPathExists: *** ERROR *** The parameter, 'fileName' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.InsistPathExists: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'fileName' is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.InsistPathExists *** INFO: Checking whether the file having pathname, '{fileName}', exists on the file system..."
                );

                // Check whether a file having pathname, 'fileName', exists on the file system.
                // If it does not, then write an error message to the Debug output, and then
                // terminate the execution of this method.
                if (!File.Exists(fileName))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the file having pathname, '{fileName}', on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.InsistPathExists: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.InsistPathExists *** SUCCESS *** The file having pathname, '{fileName}', was found on the file system.  Proceeding..."
                );

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

            return result;
        }

        /// <summary> Checks for write access for the given file. </summary>
        /// <param name="pathname">
        /// (Required.) String containing the full pathname for which
        /// write permissions should be checked.
        /// </param>
        /// <returns>
        /// This method returns <see langword="true" /> if write access is
        /// allowed to the file with the specified <paramref name="pathname" />, otherwise
        /// <see langword="false" />.
        /// <para />
        /// The value <see langword="false" /> is also returned in the event that the
        /// <paramref name="pathname" /> parameter is a <see langword="null" /> value or
        /// blank.
        /// <para />
        /// The value <see langword="false" /> is also returned if an operating system
        /// error or exception occurs while trying to look up the file's permissions.
        /// </returns>
        public static bool IsFileWriteable([NotLogged] string pathname)
        {
            // write the name of the current class and method we are now
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable *** INFO: Checking whether the value of the parameter, 'pathname', is blank..."
                );

                // Check whether the value of the parameter, 'pathname', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(pathname))
                {
                    // The parameter, 'pathname', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** ERROR *** The parameter, 'pathname', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'pathname', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFileWriteable: Checking whether the file, '{pathname}', does NOT have the 'Read-Only' attribute set..."
                );

                // Check to see whether the file does NOT have the 'Read-Only' attribute set.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if ((File.GetAttributes(pathname) & FileAttributes.ReadOnly) !=
                    0)
                {
                    // The file has the 'Read-Only' attribute set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The file, '{pathname}', has the 'Read-Only' attribute set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The file, '{pathname}', does NOT have the 'Read-Only' attribute set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to retrieve the Access Control List (ACL) for the file, '{pathname}'..."
                );

                var acl = File.GetAccessControl(pathname);

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the variable, 'acl', has a null reference for a value..."
                );

                // Check to see if the variable, 'acl', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (acl == null)
                {
                    // The variable, 'acl', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** ERROR ***  The variable, 'acl', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'acl', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The variable, 'acl', has a valid object reference for its value.  Proceeding..."
                );


                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to retrieve the ACL rule(s) for the file, '{pathname}'..."
                );

                // Get the access rules of the specified files (user groups and
                // usernames that have access to the file)
                var rules = acl.GetAccessRules(
                    true, true, typeof(SecurityIdentifier)
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the variable, 'rules', has a null reference for a value..."
                );

                // Check to see if the variable, 'rules', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (rules == null)
                {
                    // The variable, 'rules', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** ERROR ***  The variable, 'rules', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'rules', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The variable, 'rules', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to retrieve the Windows identity associated with the user, '{FullyQualifiedUserName}'..."
                );

                var windowsIdentity = WindowsIdentity.GetCurrent();

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the variable, 'windowsIdentity', has a null reference for a value..."
                );

                // Check to see if the variable, 'windowsIdentity', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (windowsIdentity == null)
                {
                    // The variable, 'windowsIdentity', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** ERROR ***  The variable, 'windowsIdentity', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'windowsIdentity', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The variable, 'windowsIdentity', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $@"*** FYI *** Attempting to retrieve the group(s) that the user, '{FullyQualifiedUserName}', is a member of..."
                );

                var groups = windowsIdentity.Groups;

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the variable, 'groups', has a null reference for a value..."
                );

                // Check to see if the variable, 'groups', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (groups == null)
                {
                    // The variable, 'groups', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** ERROR ***  The variable, 'groups', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'groups', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The variable, 'groups', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DebugFileAndFolderHelper.IsFileWriteable: Checking whether the 'groups' collection contains greater than zero elements..."
                );

                // Check to see whether the 'groups' collection contains greater than zero 
                // elements.  Otherwise, write an error message to the log file, return the default 
                // return value, and then terminate the execution of this method.
                if (groups.Count <= 0)
                {
                    // The 'groups' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'groups' collection contains zero elements.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** {groups.Count} element(s) were found in the 'groups' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to obtain the SID of the user, '{FullyQualifiedUserName}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the property, 'windowsIdentity.User', has a null reference for a value..."
                );

                // Check to see if the required property, 'windowsIdentity.User', has a null reference for a value. 
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (windowsIdentity.User == null)
                {
                    // The property, 'windowsIdentity.User', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** ERROR *** The property, 'windowsIdentity.User', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The property, 'windowsIdentity.User', has a valid object reference for its value.  Proceeding..."
                );

                var sidCurrentUser = windowsIdentity.User.Value;

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** The SID of the user, '{FullyQualifiedUserName}', is: '{sidCurrentUser}'"
                );

                // Check if writing to the file is explicitly denied for this
                // user or a group the user is in.
                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Going over the access-control list rule(s) for the file, '{pathname}' for the user, '{FullyQualifiedUserName}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Updating the default return value of this method to TRUE unless an ACL rule is found to say otherwise..."
                );

                foreach (var rule in rules)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the variable 'rule' has a null reference for a value..."
                    );

                    // Check to see if the variable, rule, is null. If it is, send an error to the log file and continue to the next loop iteration.
                    if (rule == null)
                    {
                        // the variable rule is required to have a valid object reference.
                        System.Diagnostics.Debug.WriteLine(
                            "DebugFileAndFolderHelper.IsFileWriteable: *** ERROR ***  The 'rule' variable has a null reference.  Skipping to the next loop iteration..."
                        );

                        // continue to the next loop iteration.
                        continue;
                    }

                    // We can use the variable, rule, because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The 'rule' variable has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.IsFileWriteable: Checking whether the current ACL rule is a FileSystemAccessRule (FSAR)..."
                    );

                    // Check to see whether the current ACL rule is a FileSystemAccessRule (FSAR).
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next loop iteration.
                    if (!(rule is FileSystemAccessRule fsar))
                    {
                        // The current ACL rule is NOT a FileSystemAccessRule (FSAR).  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The current ACL rule is NOT a FileSystemAccessRule (FSAR).  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The current ACL rule is a FileSystemAccessRule (FSAR).  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.IsFileWriteable: Checking whether the file has any rule(s) in its ACL that prevent the user being able to write to it..."
                    );

                    // Check to see whether the current FSAR prevents the current user from writing
                    // to the file.  If this is not the case, then skip to the next rule.  Otherwise,
                    // we fall through and set the return value of this method to FALSE.
                    if (!RuleIndicatesFileNotWriteable(
                            fsar, groups, sidCurrentUser
                        ))
                    {
                        // The current file-system access rule does NOT deny the current user 'Write' access to the file.  Keep checking the other rules.
                        System.Diagnostics.Debug.WriteLine(
                            $"*** FYI *** The current file-system access rule does NOT deny the current user 'Write' access to the file, '{pathname}'.  Checking the other rule(s)..."
                        );

                        // skip to the next rule.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.IsFileWriteable: *** ERROR *** The user, '{FullyQualifiedUserName}', is barred from writing to the file, '{pathname}' by the ACL rule, '{rule}'."
                    );

                    result = false;
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            DebugUtils.WriteLine(
                result ? DebugLevel.Info : DebugLevel.Error,
                result
                    ? $"*** SUCCESS *** The file, '{pathname}', is writeable by the user, '{FullyQualifiedUserName}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to verify that the file, '{pathname}', is writeable by the user, '{FullyQualifiedUserName}'.  Stopping..."
            );

            System.Diagnostics.Debug.WriteLine($"DebugFileAndFolderHelper.IsFileWriteable: Result = {result}");

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
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the folder having the path '{pathname}' on the filesystem.  This folder is required to exist in order for us to proceed."
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
                    System.Diagnostics.Debug.WriteLine(
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
                    System.Diagnostics.Debug.WriteLine(
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
                         .Any(r
                             => (groups.Contains(r.IdentityReference) ||
                                 r.IdentityReference.Value == sidCurrentUser) &&
                                r.AccessControlType == AccessControlType.Deny &&
                                (r.FileSystemRights &
                                 FileSystemRights.WriteData) ==
                                FileSystemRights.WriteData
                         ))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: The folder '{0}' is not writeable due to security settings.",
                        pathname
                    );
                    return result;
                }

                // Check if writing is allowed
                result = rules.OfType<FileSystemAccessRule>()
                              .Any(r
                                  => (groups.Contains(r.IdentityReference) ||
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

        private static bool RuleIndicatesFileNotWriteable(
            FileSystemAccessRule r,
            IdentityReferenceCollection groups,
            string sidCurrentUser
        )
        {
            var result = true;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Checking whether the 'r' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, r, is null. If it is, send an 
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (r == null)
                {
                    // The parameter, 'r', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** ERROR *** A null reference was passed for the 'r' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** SUCCESS *** We have been passed a valid object reference for the 'r' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Checking whether the 'groups' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, groups, is null. If it is, send an 
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (groups == null)
                {
                    // The parameter, 'groups', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** ERROR *** A null reference was passed for the 'groups' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** SUCCESS *** We have been passed a valid object reference for the 'groups' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Checking whether the 'groups' collection contains greater than zero elements..."
                );

                // Check to see whether the 'groups' collection contains greater than zero 
                // elements.  Otherwise, write an error message to the log file, return the default 
                // return value, and then terminate the execution of this method.
                if (groups.Count <= 0)
                {
                    // The 'groups' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'groups' collection contains zero elements.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** SUCCESS *** {groups.Count} element(s) were found in the 'groups' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable *** INFO: Checking whether the value of the parameter, 'sidCurrentUser', is blank..."
                );

                // Check whether the value of the parameter, 'sidCurrentUser', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(sidCurrentUser))
                {
                    // The parameter, 'sidCurrentUser', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** ERROR *** The parameter, 'sidCurrentUser', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'sidCurrentUser', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Checking whether the user is a member of any of the group(s)..."
                );

                // Check to see whether the user is a member of any of the group(s).
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (groups.Contains(r.IdentityReference))
                {
                    // The user is a member of one or more of the group(s).  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The user is a member of one or more of the group(s).  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** SUCCESS *** The user is NOT a member of any of the group(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Checking whether the property, 'r.IdentityReference', has a null reference for a value..."
                );

                // Check to see if the required property, 'r.IdentityReference', has a null reference for a value. 
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (r.IdentityReference == null)
                {
                    // The property, 'r.IdentityReference', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** ERROR *** The property, 'r.IdentityReference', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** SUCCESS *** The property, 'r.IdentityReference', has a valid object reference for its value.  Proceeding..."
                );

                /*
                 * Switch the default return value to FALSE from here on out.
                 */

                result = false;

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Checking whether the current user SID is equal to that of the current Windows identity..."
                );

                // Check to see whether the current user SID is equal to that of the current Windows identity.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!sidCurrentUser.Equals(r.IdentityReference.Value))
                {
                    // The current user SID is NOT equal to that of the current Windows identity.  This means the file is writeable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** SUCCESS *** The current user SID is NOT equal to that of the current Windows identity.  This means the file is writeable."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** FYI *** The current user SID is equal to that of the current Windows identity.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Checking whether the file has an Access Control Type of 'Deny'..."
                );

                // Check to see whether the file has an Access Control Type of 'Deny'.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!r.AccessControlType.Equals(AccessControlType.Deny))
                {
                    // The file does NOT have an Access Control Type of 'Deny'.  This means the file is writeable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** SUCCESS *** The file does NOT have an Access Control Type of 'Deny'.  This means the file is writeable."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** SUCCESS *** The file has an Access Control Type of 'Deny'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Checking whether the user has 'Write Data' privileges on the current file..."
                );

                // Check to see whether the user has 'Write Data' privileges on the current file.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!FileSystemRights.WriteData.Equals(
                        r.FileSystemRights & FileSystemRights.WriteData
                    ))
                {
                    // The current user has 'Write Data' privileges on the current file.  This means the file is writeable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** The current user has 'Write Data' privileges on the current file.  This means the file is writeable."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: *** ERROR *** The user does NOT have 'Write Data' privileges on the current file.  The file is NOT writeable."
                );

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * we have discovered a file that is NOT writeable by the current user.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = true;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DebugFileAndFolderHelper.RuleIndicatesFileNotWriteable: Result = {result}"
            );

            return result;
        }
    }
}