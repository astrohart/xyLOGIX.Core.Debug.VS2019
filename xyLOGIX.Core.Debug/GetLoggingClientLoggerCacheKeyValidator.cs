using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator" />
    /// interface.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetLoggingClientLoggerCacheKeyValidator
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheKeyValidator" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> member(s) are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLoggingClientLoggerCacheKeyValidator() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator" />
        /// interface and returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one and only instance of the object that implements
        /// the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator" />
        /// interface.
        /// </returns>
        [DebuggerStepThrough, Log(AttributeExclude = true)]
        [return: NotLogged]
        internal static ILoggingClientLoggerCacheKeyValidator SoleInstance()
        {
            ILoggingClientLoggerCacheKeyValidator result = default;

            try
            {
                result = LoggingClientLoggerCacheKeyValidator.Instance;

                if (result == null)
                    return result;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}