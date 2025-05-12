using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.IO;
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
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IDirectoryWriteabilityStatusValidator" />
        /// interface.
        /// </summary>
        private static IDirectoryWriteabilityStatusValidator
            DirectoryWriteabilityStatusValidator
        {
            [DebuggerStepThrough] get;
        } =
            GetDirectoryWriteabilityStatusValidator.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IFileWriteabilityStatusValidator" /> interface.
        /// </summary>
        private static IFileWriteabilityStatusValidator
            FileWriteabilityStatusValidator { [DebuggerStepThrough] get; } =
            GetFileWriteabilityStatusValidator.SoleInstance();

        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the fully-qualified
        /// username of the currently-logged-in OS user.
        /// </summary>
        public static string FullyQualifiedUserName
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
        /// Determines whether a folder having the <c>FileSystemAccessRule</c>,
        /// <paramref name="r" />, is NOT writeable by the user having the SID specified in
        /// <paramref name="sidCurrentUser" />, who is a member of the specified
        /// <paramref name="groups" />.
        /// </summary>
        /// <param name="r">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Security.AccessControl.FileSystemAccessRule" /> that is a
        /// rule that is to be checked.
        /// </param>
        /// <param name="groups">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Security.Principal.IdentityReferenceCollection" /> that
        /// identifies the group(s) of which the user is a member.
        /// </param>
        /// <param name="sidCurrentUser">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the SID of the currently-logged-in user.
        /// </param>
        /// <returns>
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus" /> enumeration
        /// value(s) that indicates the results of the determination, or
        /// <see cref="F:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus.NoDetermination" />
        /// if the <c>Directory Writeability Status</c> value could not be ascertained from
        /// the information available.
        /// </returns>
        private static DirectoryWriteabilityStatus
            DetermineDirectoryWriteabilityStatus(
                FileSystemAccessRule r,
                IdentityReferenceCollection groups,
                string sidCurrentUser
            )
        {
            var result = DirectoryWriteabilityStatus.NoDetermination;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Checking whether the 'r' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, r, is null. If it is, send an
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (r == null)
                {
                    // The parameter, 'r', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** ERROR *** A null reference was passed for the 'r' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** SUCCESS *** We have been passed a valid object reference for the 'r' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Checking whether the 'groups' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, groups, is null. If it is, send an
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (groups == null)
                {
                    // The parameter, 'groups', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** ERROR *** A null reference was passed for the 'groups' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** SUCCESS *** We have been passed a valid object reference for the 'groups' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Checking whether the 'groups' collection contains greater than zero elements..."
                );

                // Check to see whether the 'groups' collection contains greater than zero
                // elements.  Otherwise, write an error message to the log system, return the default
                // return value, and then terminate the execution of this method.
                if (groups.Count <= 0)
                {
                    // The 'groups' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'groups' collection contains zero elements.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** SUCCESS *** {groups.Count} element(s) were found in the 'groups' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus *** INFO: Checking whether the value of the parameter, 'sidCurrentUser', is blank..."
                );

                // Check whether the value of the parameter, 'sidCurrentUser', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(sidCurrentUser))
                {
                    // The parameter, 'sidCurrentUser', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** ERROR *** The parameter, 'sidCurrentUser', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'sidCurrentUser', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Checking whether the property, 'r.IdentityReference', has a null reference for a value..."
                );

                // Check to see if the required property, 'r.IdentityReference', has a null reference for a value.
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (r.IdentityReference == null)
                {
                    // The property, 'r.IdentityReference', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** ERROR *** The property, 'r.IdentityReference', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** SUCCESS *** The property, 'r.IdentityReference', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Checking whether the current user is a member of any of the group(s)..."
                );

                // Check to see whether the current user is a member of any of the group(s).
                // If this is not the case, then write an error message to the log system,
                // and then terminate the execution of this method.
                if (!groups.Contains(r.IdentityReference))
                {
                    // The current user is NOT a member of ANY of the group(s).  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The current user is NOT a member of ANY of the group(s).  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** SUCCESS *** The current user is a member of any of the group(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Checking whether the current user SID, '{sidCurrentUser}', is equal to that of the current Windows identity..."
                );

                // Check to see whether the current user SID is equal to that of the current Windows identity.
                // If this is not the case, then write an error message to the log system,
                // and then terminate the execution of this method.
                if (!sidCurrentUser.Equals(r.IdentityReference.Value))
                {
                    // The current user SID is NOT equal to that of the current Windows identity.  This means the system is writeable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** SUCCESS *** The current user SID, '{sidCurrentUser}', is NOT equal to that of the current Windows identity.  This means the system is writeable."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: *** FYI *** The current user SID, '{sidCurrentUser}', is equal to that of the current Windows identity.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Determining whether the user has 'Write Data' privileges on the current system..."
                );

                result =
                    AccessControlType.Allow.Equals(r.AccessControlType) &
                    ((r.FileSystemRights & FileSystemRights.WriteData) != 0)
                        ? DirectoryWriteabilityStatus.Writeable
                        : DirectoryWriteabilityStatus.NotWriteable;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = DirectoryWriteabilityStatus.NoDetermination;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Determines whether a file system entry having the <c>FileSystemAccessRule</c>,
        /// <paramref name="r" />, is NOT writeable by the user having the SID specified in
        /// <paramref name="sidCurrentUser" />, who is a member of the specified
        /// <paramref name="groups" />.
        /// </summary>
        /// <param name="r">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Security.AccessControl.FileSystemAccessRule" /> that is a
        /// rule that is to be checked.
        /// </param>
        /// <param name="groups">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Security.Principal.IdentityReferenceCollection" /> that
        /// identifies the group(s) of which the user is a member.
        /// </param>
        /// <param name="sidCurrentUser">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the SID of the currently-logged-in user.
        /// </param>
        /// <returns>
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.FileWriteabilityStatus" /> enumeration
        /// value(s) that indicates the results of the determination, or
        /// <see cref="F:xyLOGIX.Core.Debug.FileWriteabilityStatus.NoDetermination" />
        /// if the <c>File Writeability Status</c> value could not be ascertained from
        /// the information available.
        /// </returns>
        private static FileWriteabilityStatus DetermineFileWriteabilityStatus(
            FileSystemAccessRule r,
            IdentityReferenceCollection groups,
            string sidCurrentUser
        )
        {
            var result = FileWriteabilityStatus.NoDetermination;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Checking whether the 'r' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, r, is null. If it is, send an
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (r == null)
                {
                    // The parameter, 'r', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** ERROR *** A null reference was passed for the 'r' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** SUCCESS *** We have been passed a valid object reference for the 'r' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Checking whether the 'groups' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, groups, is null. If it is, send an
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (groups == null)
                {
                    // The parameter, 'groups', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** ERROR *** A null reference was passed for the 'groups' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** SUCCESS *** We have been passed a valid object reference for the 'groups' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Checking whether the 'groups' collection contains greater than zero elements..."
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
                        $"DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** SUCCESS *** {groups.Count} element(s) were found in the 'groups' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus *** INFO: Checking whether the value of the parameter, 'sidCurrentUser', is blank..."
                );

                // Check whether the value of the parameter, 'sidCurrentUser', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(sidCurrentUser))
                {
                    // The parameter, 'sidCurrentUser', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** ERROR *** The parameter, 'sidCurrentUser', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'sidCurrentUser', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Checking whether the property, 'r.IdentityReference', has a null reference for a value..."
                );

                // Check to see if the required property, 'r.IdentityReference', has a null reference for a value.
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (r.IdentityReference == null)
                {
                    // The property, 'r.IdentityReference', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** ERROR *** The property, 'r.IdentityReference', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** SUCCESS *** The property, 'r.IdentityReference', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Checking whether the current user is a member of any of the group(s)..."
                );

                // Check to see whether the current user is a member of any of the group(s).
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!groups.Contains(r.IdentityReference))
                {
                    // The current user is NOT a member of ANY of the group(s).  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The current user is NOT a member of ANY of the group(s).  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** SUCCESS *** The current user is a member of any of the group(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Checking whether the current user SID, '{sidCurrentUser}', is equal to that of the current Windows identity..."
                );

                // Check to see whether the current user SID is equal to that of the current Windows identity.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!sidCurrentUser.Equals(r.IdentityReference.Value))
                {
                    // The current user SID is NOT equal to that of the current Windows identity.  This means the file is writeable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** SUCCESS *** The current user SID, '{sidCurrentUser}', is NOT equal to that of the current Windows identity.  This means the file is writeable."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: *** FYI *** The current user SID, '{sidCurrentUser}', is equal to that of the current Windows identity.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Determining whether the user has 'Write Data' privileges on the current file..."
                );

                result =
                    AccessControlType.Allow.Equals(r.AccessControlType) &
                    ((r.FileSystemRights & FileSystemRights.WriteData) != 0)
                        ? FileWriteabilityStatus.Writeable
                        : FileWriteabilityStatus.NotWriteable;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = FileWriteabilityStatus.NoDetermination;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DebugFileAndFolderHelper.DetermineFileWriteabilityStatus: Result = '{result}'"
            );

            return result;
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

        /// <summary>
        /// Determines whether the file having the <paramref name="pathname" /> is marked
        /// with the 'Read-Only' attribute.
        /// </summary>
        /// <param name="pathname">
        /// (Required.) A <see cref="T:System.String" /> containing
        /// the fully-qualified pathname of the file whose 'Read-Only' attribute is to be
        /// checked.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the file having the <paramref name="pathname" /> is
        /// marked with the 'Read-Only' attribute; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsFileReadOnly([NotLogged] string pathname)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileReadOnly *** INFO: Checking whether the value of the parameter, 'pathname', is blank..."
                );

                // Check whether the value of the parameter, 'pathname', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(pathname))
                {
                    // The parameter, 'pathname', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileReadOnly: *** ERROR *** The parameter, 'pathname', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.IsFileReadOnly: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'pathname', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFileReadOnly *** INFO: Checking whether the file having pathname, '{pathname}', exists on the file system..."
                );

                // Check whether a file having pathname, 'pathname', exists on the file system.
                // If it does not, then write an error message to the Debug output, and then
                // terminate the execution of this method.
                if (!File.Exists(pathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the file having pathname, '{pathname}', on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileReadOnly: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFileReadOnly *** SUCCESS *** The file having pathname, '{pathname}', was found on the file system.  Proceeding..."
                );

                result =
                    (File.GetAttributes(pathname) & FileAttributes.ReadOnly) ==
                    FileAttributes.ReadOnly;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DebugFileAndFolderHelper.IsFileReadOnly: Result = {result}"
            );

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
                    $"DebugFileAndFolderHelper.IsFileWriteable *** INFO: Checking whether the file having pathname, '{pathname}', exists on the file system..."
                );

                // Check whether a file having pathname, 'pathname', exists on the file system.
                // If it does not, then write an error message to the Debug output, and then
                // terminate the execution of this method.
                if (!File.Exists(pathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the file having pathname, '{pathname}', on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFileWriteable *** SUCCESS *** The file having pathname, '{pathname}', was found on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFileWriteable: Checking whether the file, '{pathname}', does NOT have the 'Read-Only' attribute set..."
                );

                // Check to see whether the file does NOT have the 'Read-Only' attribute set.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (IsFileReadOnly(pathname))
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

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: Checking whether the ACL contains at least one rule that pertains to the current user..."
                );

                // Check to see whether the ACL contains at least one rule that pertains to the current user.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method, and ASSUME that the file is writeable.
                if (!RulesFoundForUser(rules, sidCurrentUser))
                {
                    // The ACL contains NO rule(s) that pertain to the current user.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The ACL contains NO rule(s) that pertain to the current user.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFileWriteable: Result = {true}"
                    );

                    // stop.
                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The ACL contains at least one rule that pertains to the current user.  Proceeding..."
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
                    if (!(rule is FileSystemAccessRule r))
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
                        "*** DebugFileAndFolderHelper.IsFileWriteable: Checking whether the writeability status of the file could be determined..."
                    );

                    // Check to see whether the writeability status of the file could be determined.
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next iteration of the loop.
                    var writeabilityStatus = DetermineFileWriteabilityStatus(
                        r, groups, sidCurrentUser
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.IsFileWriteable: Checking whether the writeability status is within the defined value set..."
                    );

                    // Check to see whether the writeability status is within the defined value set.
                    // If this is not the case, then write an error message to the Debug output,
                    // and then skip to the next loop iteration.
                    if (!FileWriteabilityStatusValidator.IsValid(
                            writeabilityStatus
                        ))
                    {
                        // The writeability status is NOT within the defined value set.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The writeability status is NOT within the defined value set.  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The writeability status is within the defined value set.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.IsFileWriteable: Checking whether the writeability status of the file could be determined..."
                    );

                    // Check to see whether the writeability status of the file could be determined.
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next iteration of the loop.
                    if (FileWriteabilityStatus.NoDetermination.Equals(
                            writeabilityStatus
                        ))
                    {
                        // The writeability status of the file could NOT be determined from the current rule.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR *** The writeability status of the file could NOT be determined from the current rule.  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The writeability status of the file could be determined.  Proceeding..."
                    );

                    if (FileWriteabilityStatus.NoDetermination.Equals(
                            writeabilityStatus
                        ))
                    {
                        // The writeability status of the file could NOT be determined from the current rule.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR *** The writeability status of the file could NOT be determined from the current rule.  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFileWriteable: *** SUCCESS *** The writeability status of the file could be determined.  Proceeding..."
                    );

                    result =
                        FileWriteabilityStatusValidator.IsValid(
                            writeabilityStatus
                        ) && FileWriteabilityStatus.Writeable.Equals(
                            writeabilityStatus
                        );
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                result
                    ? $"*** SUCCESS *** The file, '{pathname}', is writeable by the user, '{FullyQualifiedUserName}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to verify that the file, '{pathname}', is writeable by the user, '{FullyQualifiedUserName}'.  Stopping..."
            );

            System.Diagnostics.Debug.WriteLine(
                $"DebugFileAndFolderHelper.IsFileWriteable: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Determines whether the folder having the <paramref name="pathname" /> is marked
        /// with the 'Read-Only' attribute.
        /// </summary>
        /// <param name="pathname">
        /// (Required.) A <see cref="T:System.String" /> containing
        /// the fully-qualified pathname of the folder whose 'Read-Only' attribute is to be
        /// checked.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the folder having the <paramref name="pathname" />
        /// is marked with the 'Read-Only' attribute; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsFolderReadOnly([NotLogged] string pathname)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugDirectoryAndFolderHelper.IsFolderReadOnly *** INFO: Checking whether the value of the parameter, 'pathname', is blank..."
                );

                // Check whether the value of the parameter, 'pathname', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(pathname))
                {
                    // The parameter, 'pathname', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugDirectoryAndFolderHelper.IsFolderReadOnly: *** ERROR *** The parameter, 'pathname', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugDirectoryAndFolderHelper.IsFolderReadOnly: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'pathname', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugDirectoryAndFolderHelper.IsFolderReadOnly *** INFO: Checking whether the folder having pathname, '{pathname}', exists on the folder system..."
                );

                // Check whether a folder having pathname, 'pathname', exists on the folder system.
                // If it does not, then write an error message to the Debug output, and then
                // terminate the execution of this method.
                if (!Directory.Exists(pathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the folder having pathname, '{pathname}', on the folder system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugDirectoryAndFolderHelper.IsFolderReadOnly: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugDirectoryAndFolderHelper.IsFolderReadOnly *** SUCCESS *** The folder having pathname, '{pathname}', was found on the folder system.  Proceeding..."
                );

                result =
                    (File.GetAttributes(pathname) & FileAttributes.ReadOnly) ==
                    FileAttributes.ReadOnly;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DebugDirectoryAndFolderHelper.IsFolderReadOnly: Result = {result}"
            );

            return result;
        }

        /// <summary> Checks for write access for the given folder. </summary>
        /// <param name="pathname">
        /// (Required.) String containing the full pathname for which
        /// write permissions should be checked.
        /// </param>
        /// <returns>
        /// This method returns <see langword="true" /> if write access is
        /// allowed to the folder with the specified <paramref name="pathname" />,
        /// otherwise
        /// <see langword="false" />.
        /// <para />
        /// The value <see langword="false" /> is also returned in the event that the
        /// <paramref name="pathname" /> parameter is a <see langword="null" /> value or
        /// blank.
        /// <para />
        /// The value <see langword="false" /> is also returned if an operating system
        /// error or exception occurs while trying to look up the folder's permissions.
        /// </returns>
        public static bool IsFolderWriteable([NotLogged] string pathname)
        {
            // write the name of the current class and method we are now
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable *** INFO: Checking whether the value of the parameter, 'pathname', is blank..."
                );

                // Check whether the value of the parameter, 'pathname', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(pathname))
                {
                    // The parameter, 'pathname', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** ERROR *** The parameter, 'pathname', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'pathname', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFolderWriteable *** INFO: Checking whether the folder having pathname, '{pathname}', exists on the file system..."
                );

                // Check whether a folder having pathname, 'pathname', exists on the file system.
                // If it does not, then write an error message to the Debug output, and then
                // terminate the execution of this method.
                if (!Directory.Exists(pathname))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the folder having pathname, '{pathname}', on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFolderWriteable *** SUCCESS *** The folder having pathname, '{pathname}', was found on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the folder, '{pathname}', does NOT have the 'Read-Only' attribute set..."
                );

                // Check to see whether the folder does NOT have the 'Read-Only' attribute set.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (IsFolderReadOnly(pathname))
                {
                    // The folder has the 'Read-Only' attribute set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The folder, '{pathname}', has the 'Read-Only' attribute set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The folder, '{pathname}', does NOT have the 'Read-Only' attribute set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to retrieve the Access Control List (ACL) for the folder, '{pathname}'..."
                );

                var acl = Directory.GetAccessControl(pathname);

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the variable, 'acl', has a null reference for a value..."
                );

                // Check to see if the variable, 'acl', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (acl == null)
                {
                    // The variable, 'acl', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** ERROR ***  The variable, 'acl', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'acl', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The variable, 'acl', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to retrieve the ACL rule(s) for the folder, '{pathname}'..."
                );

                // Get the access rules of the specified folders (user groups and
                // usernames that have access to the folder)
                var rules = acl.GetAccessRules(
                    true, true, typeof(SecurityIdentifier)
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the variable, 'rules', has a null reference for a value..."
                );

                // Check to see if the variable, 'rules', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (rules == null)
                {
                    // The variable, 'rules', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** ERROR ***  The variable, 'rules', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'rules', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The variable, 'rules', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to retrieve the Windows identity associated with the user, '{FullyQualifiedUserName}'..."
                );

                var windowsIdentity = WindowsIdentity.GetCurrent();

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the variable, 'windowsIdentity', has a null reference for a value..."
                );

                // Check to see if the variable, 'windowsIdentity', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (windowsIdentity == null)
                {
                    // The variable, 'windowsIdentity', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** ERROR ***  The variable, 'windowsIdentity', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'windowsIdentity', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The variable, 'windowsIdentity', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $@"*** FYI *** Attempting to retrieve the group(s) that the user, '{FullyQualifiedUserName}', is a member of..."
                );

                var groups = windowsIdentity.Groups;

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the variable, 'groups', has a null reference for a value..."
                );

                // Check to see if the variable, 'groups', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (groups == null)
                {
                    // The variable, 'groups', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** ERROR ***  The variable, 'groups', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'groups', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The variable, 'groups', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the 'groups' collection contains greater than zero elements..."
                );

                // Check to see whether the 'groups' collection contains greater than zero
                // elements.  Otherwise, write an error message to the log folder, return the default
                // return value, and then terminate the execution of this method.
                if (groups.Count <= 0)
                {
                    // The 'groups' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'groups' collection contains zero elements.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** {groups.Count} element(s) were found in the 'groups' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to obtain the SID of the user, '{FullyQualifiedUserName}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the property, 'windowsIdentity.User', has a null reference for a value..."
                );

                // Check to see if the required property, 'windowsIdentity.User', has a null reference for a value.
                // If that is the case, then we will write an error message to the Debug output, and then
                // terminate the execution of this method, while returning the default return value.
                if (windowsIdentity.User == null)
                {
                    // The property, 'windowsIdentity.User', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** ERROR *** The property, 'windowsIdentity.User', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The property, 'windowsIdentity.User', has a valid object reference for its value.  Proceeding..."
                );

                var sidCurrentUser = windowsIdentity.User.Value;

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** The SID of the user, '{FullyQualifiedUserName}', is: '{sidCurrentUser}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the ACL contains at least one rule that pertains to the current user..."
                );

                // Check to see whether the ACL contains at least one rule that pertains to the current user.
                // If this is not the case, then write an error message to the log folder,
                // and then terminate the execution of this method --- and ASSUME that the folder is writeable.
                if (!RulesFoundForUser(rules, sidCurrentUser))
                {
                    // The ACL contains NO rule(s) that pertain to the current user.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The ACL contains NO rule(s) that pertain to the current user.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.IsFolderWriteable: Result = {true}"
                    );

                    // stop.
                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The ACL contains at least one rule that pertains to the current user.  Proceeding..."
                );

                // Check if writing to the folder is explicitly denied for this
                // user or a group the user is in.
                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Going over the access-control list rule(s) for the folder, '{pathname}' for the user, '{FullyQualifiedUserName}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Updating the default return value of this method to TRUE unless an ACL rule is found to say otherwise..."
                );

                foreach (var rule in rules)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the variable 'rule' has a null reference for a value..."
                    );

                    // Check to see if the variable, rule, is null. If it is, send an error to the log folder and continue to the next loop iteration.
                    if (rule == null)
                    {
                        // the variable rule is required to have a valid object reference.
                        System.Diagnostics.Debug.WriteLine(
                            "DebugFileAndFolderHelper.IsFolderWriteable: *** ERROR ***  The 'rule' variable has a null reference.  Skipping to the next loop iteration..."
                        );

                        // continue to the next loop iteration.
                        continue;
                    }

                    // We can use the variable, rule, because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The 'rule' variable has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the current ACL rule is a FileSystemAccessRule (FSAR)..."
                    );

                    // Check to see whether the current ACL rule is a FileSystemAccessRule (FSAR).
                    // If this is not the case, then write an error message to the log folder,
                    // and then skip to the next loop iteration.
                    if (!(rule is FileSystemAccessRule r))
                    {
                        // The current ACL rule is NOT a FileSystemAccessRule (FSAR).  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The current ACL rule is NOT a FileSystemAccessRule (FSAR).  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The current ACL rule is a FileSystemAccessRule (FSAR).  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the writeability status of the folder could be determined..."
                    );

                    // Check to see whether the writeability status of the folder could be determined.
                    // If this is not the case, then write an error message to the log folder,
                    // and then skip to the next iteration of the loop.
                    var writeabilityStatus =
                        DetermineDirectoryWriteabilityStatus(
                            r, groups, sidCurrentUser
                        );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the writeability status is within the defined value set..."
                    );

                    // Check to see whether the writeability status is within the defined value set.
                    // If this is not the case, then write an error message to the Debug output,
                    // and then skip to the next loop iteration.
                    if (!DirectoryWriteabilityStatusValidator.IsValid(
                            writeabilityStatus
                        ))
                    {
                        // The writeability status is NOT within the defined value set.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The writeability status is NOT within the defined value set.  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The writeability status is within the defined value set.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.IsFolderWriteable: Checking whether the writeability status of the folder could be determined..."
                    );

                    // Check to see whether the writeability status of the folder could be determined.
                    // If this is not the case, then write an error message to the log folder,
                    // and then skip to the next iteration of the loop.
                    if (DirectoryWriteabilityStatus.NoDetermination.Equals(
                            writeabilityStatus
                        ))
                    {
                        // The writeability status of the folder could NOT be determined from the current rule.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR *** The writeability status of the folder could NOT be determined from the current rule.  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The writeability status of the folder could be determined.  Proceeding..."
                    );

                    if (DirectoryWriteabilityStatus.NoDetermination.Equals(
                            writeabilityStatus
                        ))
                    {
                        // The writeability status of the folder could NOT be determined from the current rule.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR *** The writeability status of the folder could NOT be determined from the current rule.  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsFolderWriteable: *** SUCCESS *** The writeability status of the folder could be determined.  Proceeding..."
                    );

                    result =
                        DirectoryWriteabilityStatusValidator.IsValid(
                            writeabilityStatus
                        ) && DirectoryWriteabilityStatus.Writeable.Equals(
                            writeabilityStatus
                        );
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                result
                    ? $"*** SUCCESS *** The folder, '{pathname}', is writeable by the user, '{FullyQualifiedUserName}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to verify that the folder, '{pathname}', is writeable by the user, '{FullyQualifiedUserName}'.  Stopping..."
            );

            System.Diagnostics.Debug.WriteLine(
                $"DebugFileAndFolderHelper.IsFolderWriteable: Result = {result}"
            );

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

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.IsValidPath *** INFO: Checking whether the value of the parameter, 'fullyQualifiedPath', is blank..."
                );

                // Check whether the value of the parameter, 'fullyQualifiedPath', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(fullyQualifiedPath))
                {
                    // The parameter, 'fullyQualifiedPath', was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.IsValidPath: *** ERROR *** The parameter, 'fullyQualifiedPath', was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.IsValidPath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'fullyQualifiedPath', is not blank.  Proceeding..."
                );

                /*
                 * Attempt to call the Path.GetFullPath method on the input.  If no
                 * Exception(s) are caught, then we can return TRUE (for success) meaning
                 * that the path provided is a valid one.
                 */

                _ = Path.GetFullPath(fullyQualifiedPath);

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
                $"DebugFileAndFolderHelper.IsValidPath: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Determines whether at least element of the specified collection of ACL
        /// <paramref name="rules" /> pertains to the currently-logged-in user.
        /// </summary>
        /// <param name="rules">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Security.AccessControl.AuthorizationRuleCollection" /> that
        /// contains the rule(s) that are to be checked.
        /// </param>
        /// <param name="sidCurrentUser">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains the SID of the currently-logged-in user.
        /// </param>
        /// <remarks>
        /// This method returns <see langword="false" /> if a
        /// <see langword="null" /> reference is passed as the argument of the
        /// <paramref name="rules" /> parameter, or if it contains zero element(s), or if
        /// the <paramref name="sidCurrentUser" /> parameter is passed a
        /// <see langword="null" />, blank, or <see cref="F:System.String.Empty" /> value.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the specified <paramref name="rules" />
        /// collection contains at least one rule that pertains to the currently-logged-in
        /// user; <see langword="false" /> otherwise.
        /// </returns>
        private static bool RulesFoundForUser(
            AuthorizationRuleCollection rules,
            string sidCurrentUser
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RulesFoundForUser: Checking whether the 'rules' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, rules, is null. If it is, send an
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (rules == null)
                {
                    // The parameter, 'rules', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RulesFoundForUser: *** ERROR *** A null reference was passed for the 'rules' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** DebugFileAndFolderHelper.RulesFoundForUser: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugFileAndFolderHelper.RulesFoundForUser: *** SUCCESS *** We have been passed a valid object reference for the 'rules' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** DebugFileAndFolderHelper.RulesFoundForUser: Checking whether the 'rules' collection contains greater than zero elements..."
                );

                // Check to see whether the 'rules' collection contains greater than zero
                // elements.  Otherwise, write an error message to the Debug output, return the default
                // return value, and then terminate the execution of this method.
                if (rules.Count <= 0)
                {
                    // The 'rules' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'rules' collection contains zero elements.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugFileAndFolderHelper.RulesFoundForUser: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugFileAndFolderHelper.RulesFoundForUser: *** SUCCESS *** {rules.Count} element(s) were found in the 'rules' collection.  Proceeding..."
                );

                /*
                 * This method is to return TRUE if at least ONE ACL rule for a
                 * given file applies to the currently-logged-in user.
                 */

                foreach (var rule in rules)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RulesFoundForUser: Checking whether the variable 'rule' has a null reference for a value..."
                    );

                    // Check to see if the variable, 'rule', is null. If it is, send an error to
                    // the Debug output and continue to the next loop iteration.
                    if (rule == null)
                    {
                        // the variable rule is required to have a valid object reference.
                        System.Diagnostics.Debug.WriteLine(
                            "DebugFileAndFolderHelper.RulesFoundForUser: *** ERROR ***  The 'rule' variable has a null reference.  Skipping to the next loop iteration..."
                        );

                        // continue to the next loop iteration.
                        continue;
                    }

                    // We can use the variable, rule, because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RulesFoundForUser: *** SUCCESS *** The 'rule' variable has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.RulesFoundForUser: Checking whether the current ACL rule is a FileSystemAccessRule (FSAR)..."
                    );

                    // Check to see whether the current ACL rule is a FileSystemAccessRule (FSAR).
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next loop iteration.
                    if (!(rule is FileSystemAccessRule r))
                    {
                        // The current ACL rule is NOT a FileSystemAccessRule (FSAR).  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The current ACL rule is NOT a FileSystemAccessRule (FSAR).  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RulesFoundForUser: *** SUCCESS *** The current ACL rule is a FileSystemAccessRule (FSAR).  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RulesFoundForUser: Checking whether the property, 'r.IdentityReference', has a null reference for a value..."
                    );

                    // Check to see if the required property, 'r.IdentityReference', has a null reference for a value.
                    // If that is the case, then we will write an error message to the Debug output, and then
                    // terminate the execution of this method, while returning the default return value.
                    if (r.IdentityReference == null)
                    {
                        // The property, 'r.IdentityReference', has a null reference for a value.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "DebugFileAndFolderHelper.RulesFoundForUser: *** ERROR *** The property, 'r.IdentityReference', has a null reference for a value.  Stopping..."
                        );

                        System.Diagnostics.Debug.WriteLine(
                            $"*** DebugFileAndFolderHelper.RulesFoundForUser: Result = {result}"
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RulesFoundForUser: *** SUCCESS *** The property, 'r.IdentityReference', has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** DebugFileAndFolderHelper.RulesFoundForUser: Checking whether the current rule applies to the current user..."
                    );

                    // Check to see whether the current rule applies to the current user.
                    // If this is not the case, then write an error message to the Debug output,
                    // and then skip to the next loop iteration.
                    if (!sidCurrentUser.Equals(r.IdentityReference.Value))
                    {
                        // The current rule does NOT apply to the current user.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The current rule does NOT apply to the current user.  Skipping to the next rule..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "DebugFileAndFolderHelper.RulesFoundForUser: *** SUCCESS *** The current rule applies to the current user.  Proceeding..."
                    );

                    result = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"DebugFileAndFolderHelper.RulesFoundForUser: Result = {result}"
            );

            return result;
        }
    }
}