using PostSharp.Patterns.Diagnostics;
using System;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to get information on .NET
    /// assemblies.
    /// </summary>
    public static class GetAssembly
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetAssembly" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetAssembly() { }

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
        public static Assembly ToUseForEventLogging(Assembly assembly)
        {
            Assembly result;

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