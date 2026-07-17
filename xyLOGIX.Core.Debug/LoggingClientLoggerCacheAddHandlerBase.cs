using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the events, methods, properties, and shared behavior of all
    /// logging-client logger-cache <c>Add</c> handler strategy object(s).
    /// </summary>
    /// <remarks>
    /// This class validates the handler type and action supplied by each
    /// concrete strategy and ensures that they form a permitted combination.
    /// <para />
    /// Concrete child class(es) specify only the handler type and action that identify
    /// their strategy.
    /// </remarks>
    [ExplicitlySynchronized, Log(AttributeExclude = true)]
    internal abstract class LoggingClientLoggerCacheAddHandlerBase
        : ILoggingClientLoggerCacheAddHandler
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase" />
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
        static LoggingClientLoggerCacheAddHandlerBase() { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase" />
        /// class and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This constructor is marked <see langword="protected" /> because this
        /// class is marked <see langword="abstract" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        protected LoggingClientLoggerCacheAddHandlerBase() { }

        /// <summary>
        /// Gets a
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
        /// enumeration value that identifies the action selected by this handler strategy.
        /// </summary>
        protected abstract LoggingClientLoggerCacheAddAction Action { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator" />
        /// interface.
        /// </summary>
        private static ILoggingClientLoggerCacheAddActionValidator ActionValidator
        {
            [DebuggerStepThrough] get;
        } = GetLoggingClientLoggerCacheAddActionValidator.SoleInstance();

        /// <summary>
        /// Gets a
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType" />
        /// enumeration value that identifies the cache-add handler strategy implemented by
        /// this object.
        /// </summary>
        public abstract LoggingClientLoggerCacheAddHandlerType HandlerType
        {
            [DebuggerStepThrough] get;
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingClientLoggerCacheAddHandlerTypeValidator HandlerTypeValidator
        {
            [DebuggerStepThrough] get;
        } = GetLoggingClientLoggerCacheAddHandlerTypeValidator.SoleInstance();

        /// <summary>
        /// Selects the logging-client logger-cache <c>Add</c> action that
        /// corresponds to the scenario represented by this handler strategy.
        /// </summary>
        /// <remarks>
        /// This method validates the handler type and action supplied by the
        /// concrete strategy and verifies that they form a permitted combination.
        /// <para />
        /// This method does not access or mutate the logging-client logger cache.
        /// <para />
        /// If either value is invalid, the combination is not permitted, a required
        /// validator is unavailable, or an error occurs, then this method returns
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />.
        /// </remarks>
        /// <returns>
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
        /// enumeration value(s) that identifies the action to perform; otherwise,
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />
        /// is returned.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public LoggingClientLoggerCacheAddAction Handle()
        {
            var result = LoggingClientLoggerCacheAddAction.Unknown;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddHandlerBase.Handle: Checking whether the property, 'ActionValidator', has a null reference for a value..."
                );

                // Check to see if the required property, 'ActionValidator', is null. If it
                // is, then write an error message to the Debug output and terminate the
                // execution of this method.
                if (ActionValidator == null)
                {
                    // The property, 'ActionValidator', is required to have a valid object
                    // reference for a value. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCacheAddHandlerBase.Handle: *** ERROR *** The property, 'ActionValidator', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine($"LoggingClientLoggerCacheAddHandlerBase.Handle: Result = '{result}'");

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddHandlerBase.Handle: *** SUCCESS *** The property, 'ActionValidator', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddHandlerBase.Handle: Checking whether the property, 'HandlerTypeValidator', has a null reference for a value..."
                );

                // Check to see if the required property, 'HandlerTypeValidator', is null.
                // If it is, then write an error message to the Debug output and terminate
                // the execution of this method.
                if (HandlerTypeValidator == null)
                {
                    // The property, 'HandlerTypeValidator', is required to have a valid
                    // object reference for a value. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCacheAddHandlerBase.Handle: *** ERROR *** The property, 'HandlerTypeValidator', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine($"LoggingClientLoggerCacheAddHandlerBase.Handle: Result = '{result}'");

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddHandlerBase.Handle: *** SUCCESS *** The property, 'HandlerTypeValidator', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddHandlerBase.Handle: Checking whether the handler strategy type, '{HandlerType}', is within the defined value set..."
                );

                // Check whether the handler strategy type, 'HandlerType', is within the defined value set.  If this is not the case, then write an error message to the Debug output, and then terminate the execution of this method, while returning the default return value.
                if (!HandlerTypeValidator.IsValid(HandlerType))
                {
                    // The handler strategy type, 'HandlerType', is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddHandlerBase.Handle: *** ERROR *** The handler strategy type, '{HandlerType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine($"LoggingClientLoggerCacheAddHandlerBase.Handle: Result = '{result}'");

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddHandlerBase.Handle: *** SUCCESS *** The handler strategy type, '{HandlerType}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddHandlerBase.Handle: Checking whether the cache-add action, '{Action}', is within the defined value set..."
                );

                // Check whether the cache-add action, 'Action', is within the defined
                // value set.  If this is not the case, then write an error message
                // to the log file, and then terminate the execution of this method,
                // while returning the default return value.
                if (!ActionValidator.IsValid(Action))
                {
                    // The cache-add action, 'Action', is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddHandlerBase.Handle: *** ERROR *** The cache-add action, '{Action}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine($"LoggingClientLoggerCacheAddHandlerBase.Handle: Result = '{result}'");

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddHandlerBase.Handle: *** SUCCESS *** The cache-add action, '{Action}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddHandlerBase.Handle: Checking whether the handler strategy type, '{HandlerType}', and action, '{Action}', form a valid combination..."
                );

                // Check whether the handler strategy type and action form a valid
                // combination. If this is not the case, then write an error message to the
                // Debug output and terminate the execution of this method.
                if (!Determine.WhetherAddHandlerTypeAndActionComboIsValid(HandlerType, Action))
                {
                    // The handler strategy type and action do not form a valid
                    // combination. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddHandlerBase.Handle: *** ERROR *** The handler strategy type, '{HandlerType}', and action, '{Action}', do not form a valid combination.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddHandlerBase.Handle: *** SUCCESS *** The handler strategy type, '{HandlerType}', and action, '{Action}', form a valid combination.  Proceeding..."
                );

                result = Action;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = LoggingClientLoggerCacheAddAction.Unknown;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientLoggerCacheAddHandlerBase.Handle: Result = '{result}'"
            );

            return result;
        }
    }
}