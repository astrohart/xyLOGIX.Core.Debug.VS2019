using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
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
        /// Gets an <see cref="T:System.Int32" /> value that indicates the number
        /// of logger object(s) currently stored in the cache.
        /// </summary>
        /// <remarks>
        /// The value returned by this property is an atomic, point-in-time
        /// snapshot of the cache element count.
        /// <para />
        /// Callers must not assume that the count remains unchanged after the property
        /// getter returns.
        /// </remarks>
        public int Count
        {
            [DebuggerStepThrough]
            get
            {
                var result = 0;

                try
                {
                    lock (SyncRoot)
                    {
                        result = LoggerMap.Count;
                    }
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = 0;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCache" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLoggerCache Instance { [DebuggerStepThrough] get; } =
            new LoggingClientLoggerCache();

        /// <summary>
        /// Gets a reference to an instance of an object that is to be used for thread
        /// synchronization purposes.
        /// </summary>
        private static object SyncRoot { [DebuggerStepThrough] get; } = new object();
    }
}