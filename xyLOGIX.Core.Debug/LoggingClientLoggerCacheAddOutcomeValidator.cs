using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates whether certain value(s) are within the defined value set of
    /// the <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
    /// enumeration.
    /// </summary>
    [ExplicitlySynchronized, Log(AttributeExclude = true)]
    internal class LoggingClientLoggerCacheAddOutcomeValidator
        : ILoggingClientLoggerCacheAddOutcomeValidator
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator" />
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
        static LoggingClientLoggerCacheAddOutcomeValidator() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator" />
        /// and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit direct
        /// allocation of this class, as it is a <c>Singleton</c> object accessible via the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLoggerCacheAddOutcomeValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLoggerCacheAddOutcomeValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new LoggingClientLoggerCacheAddOutcomeValidator();

        /// <summary>
        /// Determines whether the logging-client logger-cache <c>Add</c>
        /// <paramref name="outcome" /> value passed is within the value set that is
        /// defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" />
        /// enumeration.
        /// </summary>
        /// <param name="outcome">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome" /> values
        /// that is to be examined.
        /// </param>
        /// <remarks>
        /// If the value of the <paramref name="outcome" /> parameter is outside
        /// the defined value set, or is equal to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown" />,
        /// then this method returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the logging-client logger-cache <c>Add</c>
        /// <paramref name="outcome" /> falls within the defined value set and is not equal
        /// to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public bool IsValid(LoggingClientLoggerCacheAddOutcome outcome)
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'outcome', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddOutcomeValidator.IsValid: outcome = '{outcome}'"
                );

                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering,
                 * check the value of the 'outcome' parameter to ensure that it
                 * is not set to a value outside the set of valid values defined
                 * by the xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome
                 * enumeration.
                 *
                 * In principle, since all C# enums devolve to integer values, a
                 * hacker could insert a different value into the CPU register that the
                 * 'outcome' parameter is read from and thereby make this application
                 * do something it's not intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddOutcomeValidator.IsValid: Checking whether the value of the 'outcome' parameter, i.e., '{outcome}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'outcome' parameter is within the defined value
                // set of its enumeration data type.  If this is not the case, then write an error
                // message to the Debug output, and then terminate the execution of this method
                // while returning the default return value.
                if (!Enum.IsDefined(typeof(LoggingClientLoggerCacheAddOutcome), outcome))
                {
                    // The value of the 'outcome' parameter is NOT within the defined value set for
                    // its enumerated data type.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'outcome' parameter, i.e., '{outcome}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddOutcomeValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCacheAddOutcomeValidator.IsValid: *** SUCCESS *** The value of the 'outcome' parameter, i.e., '{outcome}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddOutcomeValidator.IsValid: Checking whether the 'Unknown' value has NOT been specified for the 'outcome' parameter..."
                );

                // Check whether the 'Unknown' value has been specified for the 'outcome' parameter.
                // If this is the case, then write an error message to the Debug output, and then
                // terminate the execution of this method, returning the default return value.
                if (LoggingClientLoggerCacheAddOutcome.Unknown.Equals(outcome))
                {
                    // The 'Unknown' value has been specified for the 'outcome' parameter.  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' value has been specified for the 'outcome' parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLoggerCacheAddOutcomeValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheAddOutcomeValidator.IsValid: *** SUCCESS *** The 'Unknown' value has NOT been specified for the 'outcome' parameter.  Proceeding..."
                );

                /*
                 * If we made it here, then assume that the input data is valid.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientLoggerCacheAddOutcomeValidator.IsValid: Result = {result}"
            );

            return result;
        }
    }
}