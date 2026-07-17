using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> method(s) that can be used to
    /// ascertain the state of an object or a value using business logic.
    /// </summary>
    internal static class Ascertain
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.Ascertain" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Ascertain() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator" />
        /// interface.
        /// </summary>
        private static ILoggingClientLoggerCacheAddActionValidator
            LoggingClientLoggerCacheAddActionValidator
        { [DebuggerStepThrough] get; } =
            GetLoggingClientLoggerCacheAddActionValidator.SoleInstance();

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
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingClientLoggerCacheAddOutcomeValidator
            LoggingClientLoggerCacheAddOutcomeValidator
        { [DebuggerStepThrough] get; } =
            GetLoggingClientLoggerCacheAddOutcomeValidator.SoleInstance();

        /// <summary>
        /// For a given logging-client logger cache <c>Add</c> handler type,
        /// <paramref name="handlerType" />, attempts to determine the corresponding
        /// logging-client logger cache <c>Add</c> action, which is represented as one of
        /// the value(s) of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
        /// enumeration.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// value(s) that identifies the logging-client logger cache <c>Add</c> handler
        /// type whose corresponding action is to be determined.
        /// </param>
        /// <returns>
        /// If successful, returns one of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" /> value(s)
        /// that indicates the corresponding logging-client logger cache <c>Add</c> action
        /// that we expect; otherwise, the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />
        /// value is returned.
        /// </returns>
        private static LoggingClientLoggerCacheAddAction TryMapLoggingClientLoggerCacheAddAction(
            LoggingClientLoggerCacheAddHandlerType handlerType
        )
        {
            var result = LoggingClientLoggerCacheAddAction.Unknown;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.TryMapLoggingClientLoggerCacheAddAction: *** FYI *** Getting the expected logging-client logger cache 'Add' action for the specified handler type, '{handlerType}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.TryMapLoggingClientLoggerCacheAddAction: Checking whether the specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is within the defined value set..."
                );

                // Check whether the specified logging-client logger cache 'Add' operation handler
                // type, 'handlerType', is within the defined value set.  If this is not the case,
                // then write an error message to the log file, and then terminate the execution of
                // this method, while returning the default return value.
                if (!LoggingClientLoggerCacheAddHandlerTypeValidator.IsValid(handlerType))
                {
                    // The specified logging-client logger cache 'Add' operation handler type,
                    // 'handlerType', is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.TryMapLoggingClientLoggerCacheAddAction: *** ERROR *** The specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.TryMapLoggingClientLoggerCacheAddAction: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.TryMapLoggingClientLoggerCacheAddAction: *** SUCCESS *** The specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is within the defined value set.  Proceeding..."
                );

                switch (handlerType)
                {
                    case LoggingClientLoggerCacheAddHandlerType.ExistingLogger:
                        result = LoggingClientLoggerCacheAddAction.PreserveExistingLogger;
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.MissingLogger:
                        result = LoggingClientLoggerCacheAddAction.AddLogger;
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.NullLogger:
                        result = LoggingClientLoggerCacheAddAction.ReplaceNullLogger;
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.Unknown:
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

                result = LoggingClientLoggerCacheAddAction.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Ascertain.TryMapLoggingClientLoggerCacheAddAction: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// For a given logging-client logger-cache <c>Add</c> handler type and
        /// operation-success state, attempts to determine the corresponding logging-client
        /// logger-cache <c>Add</c> outcome.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// value(s) that identifies the handler strategy whose corresponding outcome is to
        /// be determined.
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
        /// handler types map to
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed" />
        /// when <paramref name="addOperationSucceeded" /> is <see langword="false" />.
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
        private static LoggingClientLoggerCacheAddOutcome TryMapLoggingClientLoggerCacheAddOutcome(
            LoggingClientLoggerCacheAddHandlerType handlerType,
            bool addOperationSucceeded
        )
        {
            var result = LoggingClientLoggerCacheAddOutcome.Unknown;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.TryMapLoggingClientLoggerCacheAddOutcome: *** FYI *** Getting the expected logging-client logger cache 'Add' outcome for the specified handler type, '{handlerType}', with addOperationSucceeded = {addOperationSucceeded}..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.TryMapLoggingClientLoggerCacheAddOutcome: Checking whether the specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is within the defined value set..."
                );

                // Check whether the specified logging-client logger cache Add operation handler
                // type is within the defined value set. If this is not the case, then write an
                // error message to the Debug output and terminate the execution of this method.
                if (!LoggingClientLoggerCacheAddHandlerTypeValidator.IsValid(handlerType))
                {
                    // The specified logging-client logger cache Add operation handler type is not
                    // within the defined value set. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.TryMapLoggingClientLoggerCacheAddOutcome: *** ERROR *** The specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.TryMapLoggingClientLoggerCacheAddOutcome: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.TryMapLoggingClientLoggerCacheAddOutcome: *** SUCCESS *** The specified logging-client logger cache 'Add' operation handler type, '{handlerType}', is within the defined value set.  Proceeding..."
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

                result = LoggingClientLoggerCacheAddOutcome.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Ascertain.TryMapLoggingClientLoggerCacheAddOutcome: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Determines whether the particular combination of
        /// <paramref name="handlerType" /> and <paramref name="action" /> is valid for a
        /// logging-client logger-cache <c>Add</c> handler strategy.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// value(s) that identifies the handler strategy whose action is being examined.
        /// </param>
        /// <param name="action">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" /> value(s)
        /// that identifies the action selected by the handler strategy.
        /// </param>
        /// <remarks>
        /// The
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger" />
        /// handler type is compatible only with the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.PreserveExistingLogger" />
        /// action.
        /// <para />
        /// The
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger" />
        /// handler type is compatible only with the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.AddLogger" />
        /// action.
        /// <para />
        /// The
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger" />
        /// handler type is compatible only with the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.ReplaceNullLogger" />
        /// action.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the combination of
        /// <paramref name="handlerType" /> and <paramref name="action" /> is valid;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool WhetherAddHandlerTypeAndActionComboIsValid(
            LoggingClientLoggerCacheAddHandlerType handlerType,
            LoggingClientLoggerCacheAddAction action
        )
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'handlerType', to the Debug output.
                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: handlerType = '{handlerType}'"
                );

                // Dump the argument of the parameter, 'action', to the Debug output.
                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: action = '{action}'"
                );

                var expectedAction = TryMapLoggingClientLoggerCacheAddAction(handlerType);

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: Checking whether the logging-client logger cache 'Add' action, '{expectedAction}', is within the defined value set..."
                );

                // Check whether the logging-client logger cache 'Add' action, 'expectedAction', is
                // within the defined value set.  If this is not the case, then write an error
                // message to the Debug output, and then terminate the execution of this method,
                // while returning the default return value.
                if (!LoggingClientLoggerCacheAddActionValidator.IsValid(expectedAction))
                {
                    // The logging-client logger cache 'Add' action, 'expectedAction', is NOT within
                    // the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: *** ERROR *** The logging-client logger cache 'Add' action, '{expectedAction}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: *** SUCCESS *** The logging-client logger cache 'Add' action, '{expectedAction}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: Checking whether the specified action, '{action}', matches the expected action, '{expectedAction}'..."
                );

                // Check whether the specified action matches the expected action. If this is not
                // the case, then write an error message to the Debug output and terminate the
                // execution of this method.
                if (!expectedAction.Equals(action))
                {
                    // The specified action does not match the expected action. This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: *** ERROR *** The specified action, '{action}', does not match the expected action, '{expectedAction}', for the handler type, '{handlerType}'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: *** SUCCESS *** The handler type, '{handlerType}', and action, '{action}', form a valid combination.  Proceeding..."
                );

                /* If we made it this far with no Exception(s) getting caught, then assume that the
                 operation(s) succeeded. */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Ascertain.WhetherAddHandlerTypeAndActionComboIsValid: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Determines whether the particular combination of
        /// <paramref name="handlerType" /> and <paramref name="outcome" /> is valid, given
        /// the current state of the logging-client logger cache.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// value(s) that identifies the handler strategy used for the cache-add operation.
        /// </param>
        /// <param name="outcome">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" /> value(s)
        /// that describes the outcome of the cache-add operation.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the combination of
        /// <paramref name="handlerType" /> and <paramref name="outcome" /> is valid;
        /// otherwise, <see langword="false" />.
        /// </returns>
        [DebuggerStepThrough]
        public static bool WhetherAddHandlerTypeAndOutcomeComboIsValid(
            LoggingClientLoggerCacheAddHandlerType handlerType,
            LoggingClientLoggerCacheAddOutcome outcome
        )
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'handlerType', to the Debug output.
                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: handlerType = '{handlerType}'"
                );

                // Dump the argument of the parameter, 'outcome', to the Debug output.
                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: outcome = '{outcome}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Checking whether the property, 'LoggingClientLoggerCacheAddOutcomeValidator', has a null reference for a value..."
                );

                // Check whether the required outcome validator is available. If this is not the
                // case, then write an error message to the Debug output and terminate the execution
                // of this method.
                if (LoggingClientLoggerCacheAddOutcomeValidator == null)
                {
                    // The required outcome validator is unavailable. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: *** ERROR *** The property, 'LoggingClientLoggerCacheAddOutcomeValidator', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: *** SUCCESS *** The property, 'LoggingClientLoggerCacheAddOutcomeValidator', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Checking whether the specified logging-client logger cache 'Add' outcome, '{outcome}', is within the defined value set..."
                );

                // Check whether the specified outcome is within the defined value set. If this is
                // not the case, then write an error message to the Debug output and terminate the
                // execution of this method.
                if (!LoggingClientLoggerCacheAddOutcomeValidator.IsValid(outcome))
                {
                    // The specified outcome is not within the defined value set. This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: *** ERROR *** The specified logging-client logger cache 'Add' outcome, '{outcome}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: *** SUCCESS *** The specified logging-client logger cache 'Add' outcome, '{outcome}', is within the defined value set.  Proceeding..."
                );

                var expectedOutcome = TryMapLoggingClientLoggerCacheAddOutcome(
                    handlerType,
                    !LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed.Equals(outcome)
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Checking whether the expected logging-client logger cache 'Add' outcome, '{expectedOutcome}', is within the defined value set..."
                );

                // Check whether the expected outcome is within the defined value set. If this is
                // not the case, then write an error message to the Debug output and terminate the
                // execution of this method.
                if (!LoggingClientLoggerCacheAddOutcomeValidator.IsValid(expectedOutcome))
                {
                    // The expected outcome is not within the defined value set. This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: *** ERROR *** The expected logging-client logger cache 'Add' outcome, '{expectedOutcome}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: *** SUCCESS *** The expected logging-client logger cache 'Add' outcome, '{expectedOutcome}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Checking whether the specified outcome, '{outcome}', matches the expected outcome, '{expectedOutcome}'..."
                );

                // Check whether the specified outcome matches the expected outcome. If this is not
                // the case, then write an error message to the Debug output and terminate the
                // execution of this method.
                if (!expectedOutcome.Equals(outcome))
                {
                    // The specified outcome does not match the expected outcome. This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: *** ERROR *** The specified outcome, '{outcome}', does not match the expected outcome, '{expectedOutcome}', for the handler type, '{handlerType}'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: *** SUCCESS *** The handler type, '{handlerType}', and outcome, '{outcome}', form a valid combination.  Proceeding..."
                );

                /* If we made it this far with no Exception(s) getting caught, then assume that the
                 operation(s) succeeded. */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid: Result = {result}"
            );

            return result;
        }
    }
}