using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Describes the result of an attempt to add a logger to the
    /// logging-client logger cache.
    /// </summary>
    /// <remarks>
    /// This object is immutable after construction and can therefore be
    /// safely shared among multiple thread(s).
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLoggerCacheAddResult : ILoggingClientLoggerCacheAddResult
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> member(s) are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCacheAddResult() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult" /> and
        /// returns a reference to it.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the Handler Chain link that accepted
        /// responsibility for the cache-add operation.
        /// </param>
        /// <param name="outcome">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
        /// enumeration value that describes the final outcome of the cache-add operation.
        /// </param>
        /// <remarks>
        /// The supplied value(s) are retained without modification.
        /// <para />
        /// Validation that the handler type and outcome form a permitted combination is
        /// the responsibility of the factory that constructs this object.
        /// </remarks>
        [Log(AttributeExclude = true)]
        internal LoggingClientLoggerCacheAddResult(
            [NotLogged] LoggingClientLoggerCacheAddHandlerType handlerType,
            [NotLogged] LoggingClientLoggerCacheAddOutcome outcome
        )
        {
            HandlerType = handlerType;
            Outcome = outcome;
        }

        /// <summary>
        /// Gets a
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the Handler Chain link that accepted
        /// responsibility for the cache-add operation.
        /// </summary>
        public LoggingClientLoggerCacheAddHandlerType HandlerType { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
        /// enumeration value that describes the final outcome of the cache-add operation.
        /// </summary>
        public LoggingClientLoggerCacheAddOutcome Outcome { [DebuggerStepThrough] get; }
    }
}