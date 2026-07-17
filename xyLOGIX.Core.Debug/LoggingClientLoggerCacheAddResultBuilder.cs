using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Completes the construction of a logging-client logger-cache <c>Add</c>
    /// result for a previously specified Handler Chain link type.
    /// </summary>
    /// <remarks>
    /// This builder retains a previously validated
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
    /// value and completes construction when supplied with a valid, compatible
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" /> value.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLoggerCacheAddResultBuilder
        : ILoggingClientLoggerCacheAddResultBuilder
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> member(s) are referenced.
        /// <para />
        /// We've decorated this constructor with the
        /// <c>[Log(AttributeExclude = true)]</c> attribute in order to simplify the
        /// logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCacheAddResultBuilder() { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder" />
        /// class and returns a reference to it.
        /// </summary>
        /// <param name="handlerType">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the Handler Chain link that accepted
        /// responsibility for the cache-add operation.
        /// </param>
        /// <remarks>
        /// The specified <paramref name="handlerType" /> is retained without
        /// modification.
        /// <para />
        /// The caller is responsible for validating the value prior to constructing this
        /// builder.
        /// </remarks>
        [Log(AttributeExclude = true)]
        internal LoggingClientLoggerCacheAddResultBuilder(
            [NotLogged] LoggingClientLoggerCacheAddHandlerType handlerType
        )
            => HandlerType = handlerType;

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the Handler Chain link for which the result
        /// is being constructed.
        /// </summary>
        private LoggingClientLoggerCacheAddHandlerType HandlerType { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingClientLoggerCacheAddOutcomeValidator OutcomeValidator
        {
            [DebuggerStepThrough] get;
        } = GetLoggingClientLoggerCacheAddOutcomeValidator.SoleInstance();

        /// <summary>
        /// Completes the construction of a logging-client logger-cache <c>Add</c>
        /// result having the specified <paramref name="outcome" />.
        /// </summary>
        /// <param name="outcome">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
        /// enumeration value that describes the final outcome of the cache-add operation.
        /// </param>
        /// <remarks>
        /// The specified <paramref name="outcome" /> must be valid and compatible
        /// with the Handler Chain link type previously supplied to the builder.
        /// <para />
        /// If the specified value is invalid, is incompatible with the retained Handler
        /// Chain link type, or an error occurs, then this method returns a
        /// <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to a new instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult" />
        /// interface; otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public ILoggingClientLoggerCacheAddResult AndOutcome(
            LoggingClientLoggerCacheAddOutcome outcome
        )
        {
            ILoggingClientLoggerCacheAddResult result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddResultBuilder.AndOutcome: Checking whether the property, 'OutcomeValidator', has a null reference for a value..."
                );

                // Check to see if the required property, 'OutcomeValidator', is null. If it
                // is, then write an error message to the Debug output and terminate the
                // execution of this method.
                if (OutcomeValidator == null)
                {
                    // The property, 'OutcomeValidator', is required to have a valid object
                    // reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCacheAddResultBuilder.AndOutcome: *** ERROR *** The property, 'OutcomeValidator', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddResultBuilder.AndOutcome: *** SUCCESS *** The property, 'OutcomeValidator', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddResultBuilder.AndOutcome: Checking whether the specified logging-client logger cache Add operation outcome, '{outcome}', is within the defined value set..."
                );

                // Check whether the specified logging-client logger cache Add operation outcome,
                // 'outcome', is within the defined value set.  If this is not the case, then write
                // an error message to the Debug output, and then terminate the execution of this
                // method, while returning the default return value.
                if (!OutcomeValidator.IsValid(outcome))
                {
                    // The specified logging-client logger cache Add operation outcome, 'outcome',
                    // is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddResultBuilder.AndOutcome: *** ERROR *** The specified logging-client logger cache Add operation outcome, '{outcome}', is NOT within the defined value set.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddResultBuilder.AndOutcome: *** SUCCESS *** The specified logging-client logger cache Add operation outcome, '{outcome}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddResultBuilder.AndOutcome: Checking whether the Handler Chain link type, '{HandlerType}', is compatible with the cache-add outcome, '{outcome}'..."
                );

                var combinationIsValid = false;

                switch (HandlerType)
                {
                    case LoggingClientLoggerCacheAddHandlerType.ExistingLogger:
                        if (!LoggingClientLoggerCacheAddOutcome.ExistingLoggerPreserved.Equals(
                                outcome
                            ))
                            break;

                        combinationIsValid = true;
                        break;

                    case LoggingClientLoggerCacheAddHandlerType.MissingLogger:
                        if (LoggingClientLoggerCacheAddOutcome.LoggerAdded.Equals(outcome))
                            combinationIsValid = true;

                        if (LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed.Equals(outcome))
                            combinationIsValid = true;

                        break;

                    case LoggingClientLoggerCacheAddHandlerType.NullLogger:
                        if (LoggingClientLoggerCacheAddOutcome.NullLoggerReplaced.Equals(outcome))
                            combinationIsValid = true;

                        if (LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed.Equals(outcome))
                            combinationIsValid = true;

                        break;

                    case LoggingClientLoggerCacheAddHandlerType.Unknown:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(HandlerType), HandlerType,
                            $"The Handler Chain link type, '{HandlerType}', is not supported."
                        );
                }

                // Check whether the retained Handler Chain link type and specified
                // cache-add outcome form a permitted combination. If this is not the
                // case, then write an error message to the Debug output and terminate
                // the execution of this method.
                if (!combinationIsValid)
                {
                    // The retained Handler Chain link type and specified cache-add outcome
                    // do not form a permitted combination.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddResultBuilder.AndOutcome: *** ERROR *** The Handler Chain link type, '{HandlerType}', is not compatible with the cache-add outcome, '{outcome}'.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddResultBuilder.AndOutcome: *** SUCCESS *** The Handler Chain link type, '{HandlerType}', is compatible with the cache-add outcome, '{outcome}'.  Proceeding..."
                );

                result = new LoggingClientLoggerCacheAddResult(HandlerType, outcome);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Created a logging-client logger-cache Add result for the Handler Chain link type, '{HandlerType}', and outcome, '{outcome}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to create a logging-client logger-cache Add result for the Handler Chain link type, '{HandlerType}', and outcome, '{outcome}'.  Stopping..."
            );

            return result;
        }
    }
}