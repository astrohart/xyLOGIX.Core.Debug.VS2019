using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates whether certain value(s) are within the defined value set of
    /// the <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
    /// enumeration.
    /// </summary>
    [ExplicitlySynchronized, Log(AttributeExclude = true)]
    internal class LoggingClientLoggerCacheAddActionValidator
        : ILoggingClientLoggerCacheAddActionValidator
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator" />
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
        static LoggingClientLoggerCacheAddActionValidator() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator" />
        /// and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit direct
        /// allocation of this class, as it is a <c>Singleton</c> object accessible via the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLoggerCacheAddActionValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLoggerCacheAddActionValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new LoggingClientLoggerCacheAddActionValidator();

        /// <summary>
        /// Determines whether the logging-client logger-cache <c>Add</c>
        /// <paramref name="action" /> value passed is within the value set defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" />
        /// enumeration.
        /// </summary>
        /// <param name="action">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" /> value(s)
        /// that is to be examined.
        /// </param>
        /// <remarks>
        /// If the value of the <paramref name="action" /> parameter is outside
        /// the defined value set, or is equal to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />,
        /// then this method returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the logging-client logger-cache <c>Add</c>
        /// <paramref name="action" /> falls within the defined value set and is not equal
        /// to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public bool IsValid(LoggingClientLoggerCacheAddAction action)
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'action', to the Debug output.
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddActionValidator.IsValid: action = '{action}'"
                );

                /* For cybersecurity reasons, and to defeat reverse-engineering, check the value of
                 the 'action' parameter to ensure that it is not set to a value outside the set of
                 valid values defined by the xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction
                 enumeration. In principle, since all C# enums devolve to integer values, a hacker
                 could insert a different value into the CPU register that the 'action' parameter is
                 read from and thereby make this application do something it is not intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddActionValidator.IsValid: Checking whether the value of the 'action' parameter, i.e., '{action}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'action' parameter is within the defined value set
                // of its enumeration data type. If this is not the case, then write an error
                // message to the Debug output and terminate the execution of this method while
                // returning the default return value.
                if (!Enum.IsDefined(typeof(LoggingClientLoggerCacheAddAction), action))
                {
                    // The value of the 'action' parameter is NOT within the defined value set for
                    // its enumerated data type. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'action' parameter, i.e., '{action}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddActionValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddActionValidator.IsValid: *** SUCCESS *** The value of the 'action' parameter, i.e., '{action}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddActionValidator.IsValid: Checking whether the 'Unknown' value has NOT been specified for the 'action' parameter..."
                );

                // Check whether the 'Unknown' value has been specified for the 'action' parameter.
                // If this is the case, then write an error message to the Debug output and
                // terminate the execution of this method, returning the default return value.
                if (LoggingClientLoggerCacheAddAction.Unknown.Equals(action))
                {
                    // The 'Unknown' value has been specified for the 'action' parameter. This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' value has been specified for the 'action' parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddActionValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddActionValidator.IsValid: *** SUCCESS *** The 'Unknown' value has NOT been specified for the 'action' parameter.  Proceeding..."
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
                $"LoggingClientLoggerCacheAddActionValidator.IsValid: Result = {result}"
            );

            return result;
        }
    }
}