using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator" />
    /// interface.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetLoggingClientLoggerCacheAddActionValidator
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddActionValidator" />
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
        static GetLoggingClientLoggerCacheAddActionValidator() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator" />
        /// interface and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// If the singleton instance cannot be obtained, then this method returns
        /// a <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// Reference to the one and only instance of the object that implements
        /// the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator" />
        /// interface; otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        [DebuggerStepThrough, Log(AttributeExclude = true)]
        [return: NotLogged]
        internal static ILoggingClientLoggerCacheAddActionValidator SoleInstance()
        {
            ILoggingClientLoggerCacheAddActionValidator result = default;

            try
            {
                result = LoggingClientLoggerCacheAddActionValidator.Instance;
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