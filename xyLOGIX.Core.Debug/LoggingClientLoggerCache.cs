using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides a singleton cache for logger instances used by logging clients.
    /// </summary>
    /// <remarks>
    /// Access is restricted to the Instance property to enforce the singleton pattern
    /// and prevent
    /// direct instantiation.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal class LoggingClientLoggerCache : ILoggingClientLoggerCache
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCache" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCache() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCache" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit direct
        /// allocation of this class, as it is a <c>Singleton</c> object accessible via the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCache.Instance" /> property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLoggerCache() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCache" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLoggerCache Instance { [DebuggerStepThrough] get; } =
            new LoggingClientLoggerCache();
    }
}