using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Provides access to the sole logging-client log-provider object.</summary>
    [Log(AttributeExclude = true)]
    internal static class GetLoggingClientLogProvider
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetLoggingClientLogProvider" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically before any
        /// <see langword="static" /> member is referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLoggingClientLogProvider() { }

        /// <summary>
        /// Gets a reference to the sole instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLogProvider" /> interface.
        /// </summary>
        /// <returns>
        /// Reference to the sole instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLogProvider" /> interface;
        /// otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If the provider cannot be obtained, then the exception information is
        /// written to the Debug output and this method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        internal static ILoggingClientLogProvider SoleInstance()
        {
            ILoggingClientLogProvider result;

            try
            {
                result = LoggingClientLogProvider.Instance;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}