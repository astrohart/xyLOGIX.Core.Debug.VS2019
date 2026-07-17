using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Selects the
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
    /// enumeration value that preserves an existing, usable logger in the
    /// logging-client logger cache.
    /// </summary>
    [ExplicitlySynchronized, Log(AttributeExclude = true)]
    internal sealed class ExistingLoggerLoggingClientLoggerCacheAddHandler
        : LoggingClientLoggerCacheAddHandlerBase
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that need to be
        /// performed once only for the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler" />
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
        static ExistingLoggerLoggingClientLoggerCacheAddHandler() { }

        /// <summary>
        /// Constructs a new instance of the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler" />
        /// class and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit direct
        /// allocation of this class, as it is a <c>Singleton</c> object accessible via the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private ExistingLoggerLoggingClientLoggerCacheAddHandler()
        { }

        /// <summary>
        /// Gets the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.PreserveExistingLogger" />
        /// value that identifies the action selected by this handler strategy.
        /// </summary>
        protected override LoggingClientLoggerCacheAddAction Action { [DebuggerStepThrough] get; } =
            LoggingClientLoggerCacheAddAction.PreserveExistingLogger;

        /// <summary>
        /// Gets the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger" />
        /// value that identifies the cache-add handler strategy implemented by this
        /// object.
        /// </summary>
        public override LoggingClientLoggerCacheAddHandlerType HandlerType
        {
            [DebuggerStepThrough]
            get;
        } = LoggingClientLoggerCacheAddHandlerType.ExistingLogger;

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler" />
        /// interface for an existing, usable logger for the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger" />
        /// logging-client logger cache add handler strategy.
        /// </summary>
        internal static ILoggingClientLoggerCacheAddHandler
            Instance
        { [DebuggerStepThrough] get; } =
            new ExistingLoggerLoggingClientLoggerCacheAddHandler();
    }
}