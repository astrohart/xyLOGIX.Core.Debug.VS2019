using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    internal class LoggingClientLoggerCacheAddHandlerTypeValidator
        : ILoggingClientLoggerCacheAddHandlerTypeValidator
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that need to be
        /// performed once only for the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCacheAddHandlerTypeValidator() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator" />
        /// and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit direct
        /// allocation of this class, as it is a <c>Singleton</c> object accessible via the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLoggerCacheAddHandlerTypeValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLoggerCacheAddHandlerTypeValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new LoggingClientLoggerCacheAddHandlerTypeValidator();

        /// <summary>
        /// Determines whether the logging-client logger cache <c>Add</c> handler
        /// <paramref name="type" /> value passed is within the value set that is defined
        /// by the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// values that is to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the logging-client logger cache <c>Add</c>
        /// handler <paramref name="type" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public bool IsValid(LoggingClientLoggerCacheAddHandlerType type)
            => false;
    }
}