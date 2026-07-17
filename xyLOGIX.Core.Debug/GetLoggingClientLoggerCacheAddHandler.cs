using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Gets a reference to an instance of an object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler" />
    /// interface for a specified
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
    /// enumeration value, if one is implemented for the value specified.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetLoggingClientLoggerCacheAddHandler
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandler" />
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
        static GetLoggingClientLoggerCacheAddHandler() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingClientLoggerCacheAddHandlerTypeValidator
            LoggingClientLoggerCacheAddHandlerTypeValidator { [DebuggerStepThrough] get; } =
            GetLoggingClientLoggerCacheAddHandlerTypeValidator.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler" />
        /// interface for the specified <paramref name="handlerType" />.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// value(s) that identifies the logging-client logger-cache <c>Add</c> handler
        /// strategy that is to be obtained.
        /// </param>
        /// <remarks>
        /// If the specified <paramref name="handlerType" /> is outside the
        /// defined value set of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration, is equal to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown" />
        /// , or no corresponding handler strategy can be obtained, then this method
        /// returns a <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler" />
        /// interface for the specified <paramref name="handlerType" />; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        [DebuggerStepThrough, Log(AttributeExclude = true)]
        [return: NotLogged]
        internal static ILoggingClientLoggerCacheAddHandler ForHandlerType(
            LoggingClientLoggerCacheAddHandlerType handlerType
        )
        {
            ILoggingClientLoggerCacheAddHandler result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "GetLoggingClientLoggerCacheAddHandler.ForHandlerType: Checking whether the property, 'LoggingClientLoggerCacheAddHandlerTypeValidator', has a null reference for a value..."
                );

                // Check whether the required handler-type validator is available. If it is not,
                // then write an error message to the Debug output and terminate the execution of
                // this method.
                if (LoggingClientLoggerCacheAddHandlerTypeValidator == null)
                {
                    // The required handler-type validator is unavailable. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "GetLoggingClientLoggerCacheAddHandler.ForHandlerType: *** ERROR *** The property, 'LoggingClientLoggerCacheAddHandlerTypeValidator', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"GetLoggingClientLoggerCacheAddHandler.ForHandlerType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "GetLoggingClientLoggerCacheAddHandler.ForHandlerType: *** SUCCESS *** The property, 'LoggingClientLoggerCacheAddHandlerTypeValidator', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"GetLoggingClientLoggerCacheAddHandler.ForHandlerType: Checking whether the logging-client logger-cache Add handler type, '{handlerType}', is within the defined value set..."
                );

                // Check whether the specified logging-client logger-cache Add handler type is
                // within the defined value set. If this is not the case, then write an error
                // message to the Debug output and terminate the execution of this method.
                if (!LoggingClientLoggerCacheAddHandlerTypeValidator.IsValid(handlerType))
                {
                    // The specified logging-client logger-cache Add handler type is not within the
                    // defined value set. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"GetLoggingClientLoggerCacheAddHandler.ForHandlerType: *** ERROR *** The logging-client logger-cache Add handler type, '{handlerType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"GetLoggingClientLoggerCacheAddHandler.ForHandlerType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"GetLoggingClientLoggerCacheAddHandler.ForHandlerType: *** SUCCESS *** The logging-client logger-cache Add handler type, '{handlerType}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"GetLoggingClientLoggerCacheAddHandler.ForHandlerType: *** FYI *** Getting the handler strategy for the logging-client logger-cache Add handler type, '{handlerType}'..."
                );

                switch (handlerType)
                {
                    case LoggingClientLoggerCacheAddHandlerType.ExistingLogger:
                        result = GetExistingLoggerLoggingClientLoggerCacheAddHandler.SoleInstance();
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.MissingLogger:
                        result = GetMissingLoggerLoggingClientLoggerCacheAddHandler.SoleInstance();
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.NullLogger:
                        result = GetNullLoggerLoggingClientLoggerCacheAddHandler.SoleInstance();
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.Unknown:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(handlerType), handlerType,
                            $"There does not appear to be a logging-client logger-cache Add handler strategy available for the specified handler type, '{handlerType}'."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained the logging-client logger-cache Add handler strategy for the handler type, '{handlerType}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain the logging-client logger-cache Add handler strategy for the handler type, '{handlerType}'.  Stopping..."
            );

            return result;
        }
    }
}