using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler" />
    /// interface for the
    /// <see
    ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger" />
    /// logging-client logger cache add handler strategy.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetMissingLoggerLoggingClientLoggerCacheAddHandler
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:GetMissingLoggerLoggingClientLoggerCacheAddHandler" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetMissingLoggerLoggingClientLoggerCacheAddHandler() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler" />
        /// interface for the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger" />
        /// logging-client logger cache add handler strategy, and returns a reference to
        /// it.
        /// </summary>
        /// <remarks>
        /// If the singleton instance cannot be obtained, then this method returns
        /// a <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler" />
        /// interface for the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger" />
        /// logging-client logger cache add handler strategy.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static ILoggingClientLoggerCacheAddHandler SoleInstance()
        {
            ILoggingClientLoggerCacheAddHandler result;

            try
            {
                result = MissingLoggerLoggingClientLoggerCacheAddHandler.Instance;
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