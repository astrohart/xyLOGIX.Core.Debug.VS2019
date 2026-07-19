using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Creates new logging-client logger-cache <c>Add</c> result object(s) by
    /// using a fluent builder.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal static class MakeNewLoggingClientLoggerCacheAddResult
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheAddResult" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically before any
        /// <see langword="static" /> member is referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MakeNewLoggingClientLoggerCacheAddResult() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingClientLoggerCacheAddHandlerTypeValidator HandlerTypeValidator
        {
            [DebuggerStepThrough]
            get;
        } = GetLoggingClientLoggerCacheAddHandlerTypeValidator.SoleInstance();

        /// <summary>
        /// Begins creating a new logging-client logger-cache <c>Add</c> result
        /// for the specified handler strategy type.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the handler strategy responsible for the
        /// cache-add operation.
        /// </param>
        /// <remarks>
        /// The specified <paramref name="handlerType" /> must be within the
        /// defined value set of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration and must not be equal to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown" />
        /// .
        /// <para />
        /// If the handler-type validator is unavailable, the specified value is invalid,
        /// or an error occurs, then this method returns a <see langword="null" />
        /// reference.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResultBuilder" />
        /// interface; otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        internal static ILoggingClientLoggerCacheAddResultBuilder ForHandlerType(
            LoggingClientLoggerCacheAddHandlerType handlerType
        )
        {
            ILoggingClientLoggerCacheAddResultBuilder result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientLoggerCacheAddResult.ForHandlerType: Checking whether the property, 'HandlerTypeValidator', has a null reference for a value..."
                );

                // Check to see if the required property, 'HandlerTypeValidator', is null. If it is,
                // then write an error message to the Debug output and terminate the execution of
                // this method.
                if (HandlerTypeValidator == null)
                {
                    // The property, 'HandlerTypeValidator', is required to have a valid object
                    // reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientLoggerCacheAddResult.ForHandlerType: *** ERROR *** The property, 'HandlerTypeValidator', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientLoggerCacheAddResult.ForHandlerType: *** SUCCESS *** The property, 'HandlerTypeValidator', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientLoggerCacheAddResult.ForHandlerType: Checking whether the specified handler strategy type, '{handlerType}', is valid..."
                );

                // Check whether the specified handler strategy type is valid. If this is not the
                // case, then write an error message to the Debug output and terminate the execution
                // of this method.
                if (!HandlerTypeValidator.IsValid(handlerType))
                {
                    // The specified handler strategy type is not valid.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"MakeNewLoggingClientLoggerCacheAddResult.ForHandlerType: *** ERROR *** The specified handler strategy type, '{handlerType}', is not valid.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientLoggerCacheAddResult.ForHandlerType: *** SUCCESS *** The specified handler strategy type, '{handlerType}', is valid.  Proceeding..."
                );

                result = new LoggingClientLoggerCacheAddResultBuilder(handlerType);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Created a logging-client logger-cache Add result builder for the handler strategy type, '{handlerType}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to create a logging-client logger-cache Add result builder for the handler strategy type, '{handlerType}'.  Stopping..."
            );

            return result;
        }
    }
}