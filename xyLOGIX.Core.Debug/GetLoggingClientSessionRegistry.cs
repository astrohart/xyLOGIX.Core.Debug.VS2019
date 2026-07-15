using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Provides access to the sole logging-client session registry instance.</summary>
    [Log(AttributeExclude = true)]
    internal static class GetLoggingClientSessionRegistry
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetLoggingClientSessionRegistry" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLoggingClientSessionRegistry() { }

        /// <summary>
        /// Gets a reference to the sole instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSessionRegistry" /> interface.
        /// </summary>
        /// <returns>
        /// Reference to the sole logging-client session registry instance;
        /// otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If the registry cannot be obtained, this method writes the exception
        /// information to the Debug output and returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        internal static ILoggingClientSessionRegistry SoleInstance()
        {
            var result = default(ILoggingClientSessionRegistry);

            try
            {
                result = LoggingClientSessionRegistry.Instance;
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