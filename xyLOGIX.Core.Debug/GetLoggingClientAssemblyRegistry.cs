using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the sole instance of the logging-client assembly
    /// registry.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetLoggingClientAssemblyRegistry
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetLoggingClientAssemblyRegistry" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLoggingClientAssemblyRegistry() { }

        /// <summary>
        /// Gets a reference to the sole instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry" /> interface.
        /// </summary>
        /// <returns>
        /// Reference to the sole instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry" /> interface;
        /// otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If the registry cannot be obtained, then the exception information is
        /// written to the Debug output and <see langword="null" /> is returned.
        /// </remarks>
        [return: NotLogged]
        internal static ILoggingClientAssemblyRegistry SoleInstance()
        {
            ILoggingClientAssemblyRegistry result;

            try
            {
                result = LoggingClientAssemblyRegistry.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}