using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator" />
    /// interface.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetLoggingClientLoggerCacheAddOutcomeValidator
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddOutcomeValidator" />
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
        static GetLoggingClientLoggerCacheAddOutcomeValidator() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator" />
        /// interface, and returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements
        /// the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator" />
        /// interface.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static ILoggingClientLoggerCacheAddOutcomeValidator SoleInstance()
        {
            ILoggingClientLoggerCacheAddOutcomeValidator result;

            try
            {
                result = LoggingClientLoggerCacheAddOutcomeValidator.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}