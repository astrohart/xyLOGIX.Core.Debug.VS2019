using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Helpers for VSIX hosting (Visual Studio runs inside devenv.exe).
    /// Ensures dependent assemblies (e.g., log4net, PostSharp runtime) are
    /// found in the VSIX folder even if the host didn't add a binding path.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class VsixHosting
    {
        /// <summary>
        /// Value that indicates whether the assembly resolver has been installed.
        /// </summary>
        private static int _resolverInstalled;

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.VsixHosting" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static VsixHosting() { }

        /// <summary>
        /// Installs a conservative <c>AppDomain.AssemblyResolve</c> handler that
        /// probes the folder of this assembly.
        /// <para />
        /// This complements Visual Studio's probing rules.
        /// </summary>
        internal static void EnsureAssemblyResolver()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** VsixHosting.EnsureAssemblyResolver: Checking whether the assembly resolver has already been installed..."
                );

                // Check to see whether the assembly resolver has already been installed.
                // Otherwise, write an error message to the log file,
                // and then terminate the execution of this method.
                if (System.Threading.Interlocked.CompareExchange(ref _resolverInstalled, 0, 0) != 0)
                {
                    // The assembly resolver has already been installed.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The assembly resolver has already been installed.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.EnsureAssemblyResolver: *** WARNING *** The assembly resolver has NOT already been installed.  Proceeding..."
                );

                var baseDir = GetContainingBaseDir();

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.EnsureAssemblyResolver: Checking whether the variable, 'baseDir', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'baseDir', is null or blank. If it is,
                // then send an  error to the log file and then terminate the execution of this
                // method.
                if (string.IsNullOrWhiteSpace(baseDir))
                {
                    // The variable, baseDir, has a null reference for its value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.EnsureAssemblyResolver: *** ERROR *** The variable, 'baseDir', has a null reference for its value, or it is blank.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.EnsureAssemblyResolver: *** SUCCESS *** {baseDir.Length} B of data appear to be present in the variable, 'baseDir'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** VsixHosting.EnsureAssemblyResolver: Checking whether the folder, '{baseDir}', exists on the file system..."
                );

                // Check to see whether the folder, 'baseDir', exists on the file system.
                // If this is not the case, then write an error message to the log file
                // and then terminate the execution of this method.
                if (!Directory.Exists(baseDir))
                {
                    // The folder, 'baseDir', does NOT exist on the file system.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR: The folder, '{baseDir}', does NOT exist on the file system.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.EnsureAssemblyResolver: *** SUCCESS *** The folder, '{baseDir}', exists on the file system.  Proceeding..."
                );

                InitializeCurrentAppDomain();

                System.Threading.Interlocked.Exchange(ref _resolverInstalled, 1);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Attempts to obtain the fully-qualified pathname of the folder that contains
        /// whatever assembly this code is running in.
        /// </summary>
        /// <returns>
        /// If successful, a <see cref="T:System.String" /> containing the
        /// fully-qualified pathname of the folder that contains whatever assembly this
        /// code is running in; otherwise, the method returns the
        /// <see cref="F:System.String.Empty" /> value.
        /// </returns>
        private static string GetContainingBaseDir()
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.GetContainingBaseDir: *** FYI *** Attempting to obtain the pathname where this assembly is located (assuming the VSIX file is in the same folder)..."
                );

                result = Path.GetDirectoryName(
                    typeof(VsixHosting).Assembly.Location
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"VsixHosting.GetContainingBaseDir: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Returns a sensible log file path under <c>%PROGRAMDATA%</c> for a VSIX.
        /// </summary>
        /// <param name="assemblyTitle">
        /// (Required.) A <see cref="T:System.String" /> containing the title of the
        /// assembly that is to be logged.
        /// <para />
        /// The value of this parameter must not be blank.
        /// <para />
        /// Furthermore, it cannot contain any whitespace.
        /// </param>
        /// <param name="productName">
        /// (Required.) A <see cref="T:System.String" /> containing the name of the
        /// product.
        /// <para />
        /// The value of this parameter cannot be blank.
        /// <para />
        /// It can contain whitespace.
        /// </param>
        /// <remarks>
        /// If <see langword="null" />, a blank <see cref="T:System.String" />, or the
        /// <see cref="F:System.String.Empty" /> value is passed as the argument of either
        /// of the <paramref name="assemblyTitle" /> or <paramref name="productName" />
        /// parameters, then this method returns the <see cref="F:System.String.Empty" />
        /// value.
        /// </remarks>
        /// <returns>
        /// If successful, a <see cref="T:System.String" /> containing the
        /// fully-qualified pathname of the log file to use for the target VSIX extension;
        /// otherwise, the method returns the <see cref="F:System.String.Empty" /> value.
        /// </returns>
        [return: NotLogged]
        internal static string GetDefaultVsixLogPath(
            [NotLogged] string assemblyTitle,
            [NotLogged] string productName
        )
        {
            var result = string.Empty;
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.GetDefaultVsixLogPath *** INFO: Checking whether the value of the parameter, 'productName', is blank..."
                );

                // Check whether the value of the parameter, 'productName', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(productName))
                {
                    // The parameter, 'productName' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.GetDefaultVsixLogPath: The parameter, 'productName' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.GetDefaultVsixLogPath: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'productName' is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.GetDefaultVsixLogPath: *** FYI *** Formulating the base log folder path for the product, '{productName}'..."
                );

                var baseFolder = Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData
                );

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.GetDefaultVsixLogPath: Checking whether the variable, 'baseFolder', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'baseFolder', is null or blank. If it is,
                // then send an  error to the log file and quit, returning the default value
                // of the result variable.
                if (string.IsNullOrWhiteSpace(baseFolder))
                {
                    // The variable, 'baseFolder', has a null reference for a value, or is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.GetDefaultVsixLogPath: *** ERROR *** The variable, 'baseFolder', has a null reference for a value, or is blank.  Stopping..."
                    );

                    // log the result
                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.GetDefaultVsixLogPath: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.GetDefaultVsixLogPath: *** SUCCESS *** {baseFolder.Length} B of data appear to be present in the variable, 'baseFolder'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** VsixHosting.GetDefaultVsixLogPath: Checking whether the folder, '{baseFolder}', exists on the file system..."
                );

                // Check to see whether the folder, 'baseFolder', exists on the file system.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!Directory.Exists(baseFolder))
                {
                    // The folder, 'baseFolder', does NOT exist on the file system.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The folder, '{baseFolder}', does NOT exist on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** VsixHosting.GetDefaultVsixLogPath: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.GetDefaultVsixLogPath: *** SUCCESS *** The folder, '{baseFolder}', exists on the file system.  Proceeding..."
                );

                var folder = Path.Combine(
                    baseFolder, $@"xyLOGIX, LLC\{productName}\Logs"
                );

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.GetDefaultVsixLogPath: *** FYI *** Attempting to create the folder, '{folder}', on the file system if it does not already exist..."
                );

                DebugFileAndFolderHelper.CreateDirectoryIfNotExists(folder);

                result = Path.Combine(folder, productName + ".log");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                result = string.Empty;
            }

            return result;
        }

        private static void InitializeCurrentAppDomain()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.InitializeCurrentAppDomain: *** FYI *** Attempting to subscribe the 'AssemblyResolve' event of the current AppDomain..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.InitializeCurrentAppDomain: Checking whether the property, 'AppDomain.CurrentDomain', has a null reference for a value..."
                );

                // Check to see if the required property, 'AppDomain.CurrentDomain', has a null reference for a
                // value. If that is the case, then we will write an error message to the Debug
                // output, and then terminate the execution of this method.
                if (AppDomain.CurrentDomain == null)
                {
                    // The property, 'AppDomain.CurrentDomain', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.InitializeCurrentAppDomain: *** ERROR *** The property, 'AppDomain.CurrentDomain', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.InitializeCurrentAppDomain: *** SUCCESS *** The property, 'AppDomain.CurrentDomain', has a valid object reference for its value.  Proceeding..."
                );

                AppDomain.CurrentDomain.AssemblyResolve -= OnAssemblyResolve;
                AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }

        /// <summary>
        /// Determines whether this code is running inside Visual Studio (i.e., the host
        /// process' name is <c>devenv.exe</c>) or not.
        /// <para />
        /// If so, then it's highly likely that this code is being called from a VSIX
        /// extension or a template wizard.
        /// </summary>
        /// <remarks>
        /// If this method cannot make the determination due to an error, then
        /// this method returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the current process is <c>devenv.exe</c>;
        /// otherwise, <see langword="false" />.
        /// </returns>
        internal static bool IsVsixHost()
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.IsVsixHost: *** FYI *** Attempting to get a reference to the current process..."
                );

                var proc = Process.GetCurrentProcess();

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.IsVsixHost: Checking whether the variable, 'proc', has a null reference for a value..."
                );

                // Check to see if the variable, 'proc', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (proc == null)
                {
                    // The variable, 'proc', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.IsVsixHost: *** ERROR ***  The variable, 'proc', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** VsixHosting.IsVsixHost: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'proc', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.IsVsixHost: *** SUCCESS *** The variable, 'proc', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'proc.ProcessName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'proc.ProcessName', appears to have a null 
                // or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(proc.ProcessName))
                {
                    // The property, 'proc.ProcessName', appears to have a null or blank value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'proc.ProcessName', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.IsVsixHost: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'proc.ProcessName', seems to have a non-blank value.  Proceeding to check whether it is equal to 'devenv' (case-insensitive)..."
                );

                result = string.Equals(
                    proc.ProcessName, "devenv",
                    StringComparison.OrdinalIgnoreCase
                );
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
        /// Handles the <see cref="E:System.AppDomain.AssemblyResolve" /> event raised by
        /// the current <c>AppDomain</c> when it fails to resolve an assembly.
        /// </summary>
        /// <param name="sender">
        /// Reference to an instance of the object that raised the
        /// event.
        /// </param>
        /// <param name="e">
        /// A <see cref="T:System.ResolveEventArgs" /> that contains the
        /// event data.
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that resolves the type, assembly,
        /// or resource; or a <see langword="null" /> reference if the assembly cannot be
        /// resolved.
        /// </returns>
        private static Assembly OnAssemblyResolve(
            [NotLogged] object sender,
            [NotLogged] ResolveEventArgs e
        )
        {
            Assembly result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.OnAssemblyResolve: Checking whether the method parameter, 'e', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'e', is null. If it is,
                // then write an error message to the log file and then terminate the
                // execution of this method, returning the default return value.
                if (e == null)
                {
                    // The method parameter, 'e', is required and is not supposed
                    // to have a NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.OnAssemblyResolve: *** ERROR *** A null reference was passed for the method parameter, 'e'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** VsixHosting.OnAssemblyResolve: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.OnAssemblyResolve: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'e'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.OnAssemblyResolve: *** FYI *** Attempting to get the name of the target assembly from the 'e.Name' property..."
                );

                var targetAssemblyName = new AssemblyName(e.Name);

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.OnAssemblyResolve: Checking whether the variable, 'targetAssemblyName', has a null reference for a value..."
                );

                // Check to see if the variable, 'targetAssemblyName', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (targetAssemblyName == null)
                {
                    // The variable, 'targetAssemblyName', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.OnAssemblyResolve: *** ERROR ***  The variable, 'targetAssemblyName', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** VsixHosting.OnAssemblyResolve: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'targetAssemblyName', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.OnAssemblyResolve: *** SUCCESS *** The variable, 'targetAssemblyName', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'targetAssemblyName.Name', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'targetAssemblyName.Name', appears to have a null
                // or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(targetAssemblyName.Name))
                {
                    // The property, 'targetAssemblyName.Name', appears to have a null or blank value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'targetAssemblyName.Name', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.OnAssemblyResolve: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'targetAssemblyName.Name', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.OnAssemblyResolve: *** FYI *** Attempting to get the fully-qualified pathname of the folder in which this code is running..."
                );

                var baseDir = GetContainingBaseDir();

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.OnAssemblyResolve: Checking whether the variable, 'baseDir', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'baseDir', is null or blank. If it is,
                // then send an  error to the log file and quit, returning the default value
                // of the result variable.
                if (string.IsNullOrWhiteSpace(baseDir))
                {
                    // The variable, 'baseDir', has a null reference for a value, or is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.OnAssemblyResolve: *** ERROR *** The variable, 'baseDir', has a null reference for a value, or is blank.  Stopping..."
                    );

                    // log the result
                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.OnAssemblyResolve: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.OnAssemblyResolve: *** SUCCESS *** {baseDir.Length} B of data appear to be present in the variable, 'baseDir'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.OnAssemblyResolve: Checking whether the folder, '{baseDir}', exists on the file system..."
                );

                // Check to see whether the folder, 'baseDir', exists on the file system.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!Directory.Exists(baseDir))
                {
                    // The folder, 'baseDir', could not be located on the file system.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.OnAssemblyResolve: *** ERROR *** The folder, '{baseDir}', could not be located on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** VsixHosting.OnAssemblyResolve: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.OnAssemblyResolve: *** SUCCESS *** The folder, '{baseDir}', exists on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.OnAssemblyResolve: *** FYI *** Formulating the full path to the target assembly, '{targetAssemblyName.Name}.dll'..."
                );

                var path = Path.Combine(
                    GetContainingBaseDir(), targetAssemblyName.Name + ".dll"
                );

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.OnAssemblyResolve: Checking whether the variable, 'path', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'path', is null or blank. If it is,
                // then send an  error to the log file and quit, returning the default value
                // of the result variable.
                if (string.IsNullOrWhiteSpace(path))
                {
                    // The variable, 'path', has a null reference for a value, or is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.OnAssemblyResolve: *** ERROR *** The variable, 'path', has a null reference for a value, or is blank.  Stopping..."
                    );

                    // log the result
                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.OnAssemblyResolve: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.OnAssemblyResolve: *** SUCCESS *** {path.Length} B of data appear to be present in the variable, 'path'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.OnAssemblyResolve: Checking whether the file, '{path}', could be located on the file system..."
                );

                // Check to see whether the target assembly .dll file could be located on the file system.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!File.Exists(path))
                {
                    // The target assembly .dll file could NOT be located on the file system.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.OnAssemblyResolve: *** ERROR *** The file, '{path}', could NOT be located on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** VsixHosting.OnAssemblyResolve: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.OnAssemblyResolve: *** SUCCESS *** The file, '{path}', was found on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to load the assembly from the file, '{path}'..."
                );

                result = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to the resolved assembly.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to the resolved assembly.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Gets the fully-qualified pathname of the VSIX-local log4net config file, e.g.,
        /// <c>log4net.vsix.config</c>, or <c>log4net.config</c>, if present in the same
        /// folder as which the <c>*.dll</c> file containing this code also lives.
        /// </summary>
        /// <remarks>
        /// If the method fails, then the <see cref="F:System.String.Empty" />
        /// value is returned.
        /// </remarks>
        /// <returns>
        /// If successful, a <see cref="T:System.String" /> containing the
        /// fully-qualified pathname of the VSIX-local log4net config file, e.g.,
        /// <c>log4net.vsix.config</c>, or <c>log4net.config</c>, if present in the same
        /// folder as which the <c>*.dll</c> file containing this code also lives;
        /// otherwise, the method returns the <see cref="F:System.String.Empty" /> value.
        /// </returns>
        [DebuggerStepThrough]
        internal static string TryGetLog4NetConfigPath()
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.TryGetLog4NetConfigPath: *** FYI *** Attempting to find the log4net config file in the same folder as which this assembly lives..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to get the fully-qualified pathname of the folder in which this code is running..."
                );

                var folder = GetContainingBaseDir();

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.TryGetLog4NetConfigPath: Checking whether the variable, 'folder', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'folder', is null or blank. If it is, 
                // then send an  error to the log file and quit, returning the default value 
                // of the result variable.
                if (string.IsNullOrWhiteSpace(folder))
                {
                    // The variable, 'folder', has a null reference for a value, or is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.TryGetLog4NetConfigPath: *** ERROR *** The variable, 'folder', has a null reference for a value, or is blank.  Stopping..."
                    );

                    // log the result
                    System.Diagnostics.Debug.WriteLine(
                        $"VsixHosting.TryGetLog4NetConfigPath: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.TryGetLog4NetConfigPath: *** SUCCESS *** {folder.Length} B of data appear to be present in the variable, 'folder'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** VsixHosting.TryGetLog4NetConfigPath: Checking whether the folder, '{folder}', exists on the file system..."
                );

                // Check to see whether the folder, 'folder', exists on the file system.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!Directory.Exists(folder))
                {
                    // The folder, 'folder', could NOT be located on the file system.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The folder, '{folder}', could NOT be located on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** VsixHosting.TryGetLog4NetConfigPath: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"VsixHosting.TryGetLog4NetConfigPath: *** SUCCESS *** The folder, '{folder}', exists on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Formulating candidate file name(s)..."
                );

                var candidates = new[]
                {
                    Path.Combine(folder, "log4net.vsix.config"),
                    Path.Combine(folder, "log4net.config"),
                    Path.Combine(folder, "Log4Net.config")
                };

                System.Diagnostics.Debug.WriteLine(
                    "VsixHosting.TryGetLog4NetConfigPath: *** FYI *** Checking each candidate..."
                );

                foreach (var candidate in candidates)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.TryGetLog4NetConfigPath: *** FYI *** Checking whether the variable, 'candidate', appears to have a null or blank value..."
                    );

                    // Check to see if the required variable, 'candidate', appears to have a null 
                    // or blank value. If it does, then send an error to the log file and then 
                    // skip to the next loop iteration.
                    if (string.IsNullOrWhiteSpace(candidate))
                    {
                        // The variable, 'candidate', appears to have a null or blank value.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "VsixHosting.TryGetLog4NetConfigPath: *** ERROR: The variable, 'candidate', appears to have a null or blank value.  Skipping to the next candidate file name..."
                        );

                        // skip to the next iteration of this loop.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.TryGetLog4NetConfigPath: *** SUCCESS *** The variable, 'candidate', seems to have a non-blank value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** VsixHosting.TryGetLog4NetConfigPath: Checking whether the file, 'file', exists on the file system..."
                    );

                    // Check to see whether the file, 'file', exists on the file system.
                    // If this is not the case, then write an error message to the Debug output,
                    // and then skip to the next loop iteration.
                    if (!File.Exists(candidate))
                    {
                        // The file, 'file', could NOT be located on the file system.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The file, 'file', could NOT be located on the file system.  Skipping to the next candidate..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "VsixHosting.TryGetLog4NetConfigPath: *** SUCCESS *** The file, 'file', exists on the file system.  Proceeding..."
                    );

                    result = candidate;
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"VsixHosting.TryGetLog4NetConfigPath: Result = '{result}'"
            );

            return result;
        }
    }
}