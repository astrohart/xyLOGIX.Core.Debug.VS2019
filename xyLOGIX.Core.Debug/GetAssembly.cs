using System;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods to get information on .NET assemblies.
    /// </summary>
    public static class GetAssembly
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
        public static string Pathname(Assembly assembly)
        {
            var result = string.Empty;

            try
            {
                if (assembly == null) return result;
                if (string.IsNullOrWhiteSpace(assembly.Location)) return result;

                result = assembly.Location;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Attempts to obtain a reference to an instance of the
        /// <see cref="T:System.Reflection.Assembly" /> that should be used for the
        /// application event logging source.
        /// </summary>
        /// <returns>
        /// If successful, a reference to an instance of the
        /// <see cref="T:System.Reflection.Assembly" /> that should be used for the
        /// application event logging source; <see langword="null" /> otherwise.
        /// </returns>
        /// <remarks>
        /// To find the assembly to use as a source for event logging, this method first
        /// attempts to locate the assembly containing the application's entry-point, and
        /// use that.
        /// <para />
        /// Failing that, the assembly that is currently executing is tried.
        /// <para />
        /// Failing that, then the assembly that called this method is used.
        /// </remarks>
        public static Assembly ToUseForEventLogging(Assembly assembly)
        {
            Assembly result = default;

            try
            {
                if (assembly != null)
                {
                    result = assembly;
                    return result;
                }

                result = Assembly.GetEntryAssembly();
                if (result != null) return result;

                result = Assembly.GetExecutingAssembly();
                if (result != null) return result;

                result = Assembly.GetCallingAssembly();
                if (result != null) return result;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
        }
    }
}