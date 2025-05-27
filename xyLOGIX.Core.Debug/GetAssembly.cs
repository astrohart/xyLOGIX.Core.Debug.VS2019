using PostSharp.Patterns.Diagnostics;
using System;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to get information on .NET
    /// assemblies.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetAssembly
    {
        /// <summary>
        /// Obtains the fully-qualified pathname of the specified
        /// <paramref name="assembly" />.
        /// </summary>
        /// <param name="assembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> for which to obtain the
        /// fully-qualified pathname.
        /// </param>
        /// <returns>
        /// If successful, the fully-qualified pathname of the specified
        /// <paramref name="assembly" />; the <see cref="F:System.String.Empty" /> value if
        /// it could not be obtained, or if the argument of the
        /// <paramref name="assembly" /> parameter is a <see langword="null" /> reference.
        /// </returns>
        internal static string Pathname([NotLogged] Assembly assembly)
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.Pathname: *** FYI *** Attempting to get the pathname of the specified assembly..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.Pathname: Checking whether the required method parameter, 'assembly', has a null reference for a value..."
                );

                // Check to see if the required method parameter, assembly, is null. If it is, send an 
                // error to the log file and quit, returning the default return value of this
                // method.
                if (assembly == null)
                {
                    // The parameter, 'assembly', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "GetAssembly.Pathname: *** ERROR *** A null reference was passed for the required method parameter, 'assembly'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetAssembly.Pathname: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.Pathname: *** SUCCESS *** We have been passed a valid object reference for the required method parameter, 'assembly'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'assembly.Location', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'assembly.Location', appears to have a null 
                // or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(assembly.Location))
                {
                    // The property, 'assembly.Location', appears to have a null or blank value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'assembly.Location', appears to have a null or blank value.  Stopping..."
                    );

                    // log the result
                    System.Diagnostics.Debug.WriteLine(
                        $"GetAssembly.Pathname: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'assembly.Location', seems to have a non-blank value.  Proceeding..."
                );

                result = assembly.Location;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"GetAssembly.Pathname: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Attempts to obtain a reference to an instance of the
        /// <see cref="T:System.Reflection.Assembly" /> that should be used for the
        /// application event logging quote.
        /// </summary>
        /// <returns>
        /// If successful, a reference to an instance of the
        /// <see cref="T:System.Reflection.Assembly" /> that should be used for the
        /// application event logging quote; <see langword="null" /> otherwise.
        /// </returns>
        /// <remarks>
        /// To find the assembly to use as a quote for event logging, this
        /// method first attempts to locate the assembly containing the application's
        /// entry-point, and use that.
        /// <para />
        /// Failing that, the assembly that is currently executing is tried.
        /// <para />
        /// Failing that, then the assembly that called this method is used.
        /// </remarks>
        internal static Assembly ToUseForEventLogging(Assembly assembly)
        {
            var result = assembly;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: Checking whether the variable, 'assembly', does NOT have a null reference for a value..."
                );

                // Check to see if the variable, assembly, is NOT null.  If this is the case, then
                // simply make this method idempotent by returning the value of the variable, assembly.
                if (assembly != null)
                {
                    // The variable, 'assembly', does NOT have a null reference, so return it.
                    System.Diagnostics.Debug.WriteLine(
                        "GetAssembly.ToUseForEventLogging: *** FYI ***  The variable, 'assembly', does NOT have a null reference.  Returning it..."
                    );

                    // stop.
                    return result;
                }

                // We have to come up with another return value, since the parameter,
                // 'assembly', is set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: *** ERROR *** The variable, 'assembly', has a NULL object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Seeing if we can get a reference to the assembly containing the program entry point..."
                );

                var assemblyToUse = result = Assembly.GetEntryAssembly();

                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: Checking whether the variable, 'assemblyToUse', does NOT have a null reference for a value..."
                );

                // Check to see if the variable, assemblyToUse, is NOT null.  If this is the case, then
                // simply make this method idempotent by returning the value of the variable, result.
                if (assemblyToUse != null)
                {
                    // The variable, 'assemblyToUse', does NOT have a null reference, so return it.
                    System.Diagnostics.Debug.WriteLine(
                        "GetAssembly.ToUseForEventLogging: *** FYI ***  The variable, 'assemblyToUse', does NOT have a null reference.  Returning it..."
                    );

                    // stop.
                    return assemblyToUse;
                }

                // We have to come up with another return value, since the parameter,
                // 'result', is set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: *** ERROR *** The variable, 'assemblyToUse', has a NULL object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Seeing if we can get a reference to the currently-executing assembly..."
                );

                result = assemblyToUse = Assembly.GetExecutingAssembly();

                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: Checking whether the variable, 'assemblyToUse', does NOT have a null reference for a value..."
                );

                // Check to see if the variable, assemblyToUse, is NOT null.  If this is the case, then
                // simply make this method idempotent by returning the value of the variable, result.
                if (assemblyToUse != null)
                {
                    // The variable, 'assemblyToUse', does NOT have a null reference, so return it.
                    System.Diagnostics.Debug.WriteLine(
                        "GetAssembly.ToUseForEventLogging: *** FYI ***  The variable, 'assemblyToUse', does NOT have a null reference.  Returning it..."
                    );

                    // stop.
                    return assemblyToUse;
                }

                // We have to come up with another return value, since the parameter,
                // 'result', is set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: *** ERROR *** The variable, 'assemblyToUse', has a NULL object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: *** FYI *** Seeing if we can get a reference to the .NET assembly that called this method..."
                );

                result = assemblyToUse = Assembly.GetCallingAssembly();

                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: Checking whether the variable, 'assemblyToUse', does NOT have a null reference for a value..."
                );

                // Check to see if the variable, assemblyToUse, is NOT null.  If this is the case, then
                // simply make this method idempotent by returning the value of the variable, result.
                if (assemblyToUse != null)
                {
                    // The variable, 'assemblyToUse', does NOT have a null reference, so return it.
                    System.Diagnostics.Debug.WriteLine(
                        "GetAssembly.ToUseForEventLogging: *** FYI ***  The variable, 'assemblyToUse', does NOT have a null reference.  Returning it..."
                    );

                    // stop.
                    return assemblyToUse;
                }

                // We have to come up with another return value, since the parameter,
                // 'result', is set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "GetAssembly.ToUseForEventLogging: *** ERROR *** The variable, 'assemblyToUse', has a NULL object reference for its value.  Giving up..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = assembly;
            }

            return result;
        }
    }
}