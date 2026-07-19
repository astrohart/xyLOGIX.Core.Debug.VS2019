using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> method(s) that derive a value from
    /// one or more related input value(s).
    /// </summary>
    /// <remarks>
    /// It is imperative that the methods of this class only be called from
    /// the code of either the <see cref="T:xyLOGIX.Core.Debug.Determine" /> or
    /// <see cref="T:xyLOGIX.Core.Debug.Ascertain" /> classes.
    /// </remarks>
    [Log(AttributeExclude = true)]
    internal static class Derive
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.Derive" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Derive() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingClientLoggerCacheAddHandlerTypeValidator
            LoggingClientLoggerCacheAddHandlerTypeValidator
        { [DebuggerStepThrough] get; } =
            GetLoggingClientLoggerCacheAddHandlerTypeValidator.SoleInstance();

        /// <summary>
        /// Derives the logging-client logger-cache <c>Add</c> operation outcome
        /// that corresponds to the specified <paramref name="handlerType" /> and
        /// <paramref name="addOperationSucceeded" /> state.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// value(s) that identifies the handler strategy whose corresponding outcome is to
        /// be derived.
        /// </param>
        /// <param name="addOperationSucceeded">
        /// (Required.) A
        /// <see cref="T:System.Boolean" /> value indicating whether the logging-client
        /// logger-cache <c>Add</c> operation succeeded.
        /// </param>
        /// <remarks>
        /// The
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger" />
        /// handler type has no failure outcome because it preserves an existing logger and
        /// performs no cache mutation.
        /// <para />
        /// The
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger" />
        /// and
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger" />
        /// handler types derive the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed" />
        /// outcome when <paramref name="addOperationSucceeded" /> is
        /// <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// If successful, one of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" /> value(s)
        /// corresponding to the specified handler type and operation-success state;
        /// otherwise,
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown" />
        /// is returned.
        /// </returns>
        [DebuggerStepThrough]
        internal static LoggingClientLoggerCacheAddOutcome LoggingClientLoggerCacheAddOutcomeFrom(
            LoggingClientLoggerCacheAddHandlerType handlerType,
            bool addOperationSucceeded
        )
        {
            var result = LoggingClientLoggerCacheAddOutcome.Unknown;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Derive.LoggingClientLoggerCacheAddOutcomeFrom: *** FYI *** Deriving the logging-client logger cache 'Add' outcome for the specified handler type, '{handlerType}', with addOperationSucceeded = {addOperationSucceeded}..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Derive.LoggingClientLoggerCacheAddOutcomeFrom: *** FYI *** Deriving the logging-client logger cache 'Add' outcome for the specified handler type, '{handlerType}', with addOperationSucceeded = {addOperationSucceeded}..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Derive.LoggingClientLoggerCacheAddOutcomeFrom: Checking whether the property, 'LoggingClientLoggerCacheAddHandlerTypeValidator', has a null reference for a value..."
                );

                // Check whether the required handler-type validator is available. If this is not
                // the case, then write an error message to the Debug output and terminate the
                // execution of this method.
                if (LoggingClientLoggerCacheAddHandlerTypeValidator == null)
                {
                    // The required handler-type validator is unavailable. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Derive.LoggingClientLoggerCacheAddOutcomeFrom: *** ERROR *** The property, 'LoggingClientLoggerCacheAddHandlerTypeValidator', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Derive.LoggingClientLoggerCacheAddOutcomeFrom: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Derive.LoggingClientLoggerCacheAddOutcomeFrom: *** SUCCESS *** The property, 'LoggingClientLoggerCacheAddHandlerTypeValidator', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Derive.LoggingClientLoggerCacheAddOutcomeFrom: Checking whether the specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is within the defined value set..."
                );

                // Check whether the specified logging-client logger-cache Add handler type is
                // within the defined value set. If this is not the case, then write an error
                // message to the Debug output and terminate the execution of this method.
                if (!LoggingClientLoggerCacheAddHandlerTypeValidator.IsValid(handlerType))
                {
                    // The specified logging-client logger-cache Add handler type is not within the
                    // defined value set. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"Derive.LoggingClientLoggerCacheAddOutcomeFrom: *** ERROR *** The specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Derive.LoggingClientLoggerCacheAddOutcomeFrom: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Derive.LoggingClientLoggerCacheAddOutcomeFrom: *** SUCCESS *** The specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Checking whether there is a matching logging-client logger cache 'Add' operation outcome for the specified handler type, '{handlerType}', with addOperationSucceeded = {addOperationSucceeded}..."
                );

                switch (handlerType)
                {
                    case LoggingClientLoggerCacheAddHandlerType.ExistingLogger:
                        result = addOperationSucceeded
                            ? LoggingClientLoggerCacheAddOutcome.ExistingLoggerPreserved
                            : LoggingClientLoggerCacheAddOutcome.Unknown;
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.MissingLogger:
                        result = addOperationSucceeded
                            ? LoggingClientLoggerCacheAddOutcome.LoggerAdded
                            : LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed;
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.NullLogger:
                        result = addOperationSucceeded
                            ? LoggingClientLoggerCacheAddOutcome.NullLoggerReplaced
                            : LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed;
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.Unknown:
                        System.Diagnostics.Debug.WriteLine(
                            $"*** ERROR *** The specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is not supported.  Stopping..."
                        );
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(handlerType), handlerType,
                            $"The logging-client logger-cache Add handler type, '{handlerType}', is not supported."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Setting the result to '{LoggingClientLoggerCacheAddOutcome.Unknown}'..."
                );

                result = LoggingClientLoggerCacheAddOutcome.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Derive.LoggingClientLoggerCacheAddOutcomeFrom: Result = '{result}'"
            );

            return result;
        }
    }
}