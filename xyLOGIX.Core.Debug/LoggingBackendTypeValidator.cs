using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates whether certain value(s) are within the defined value set of the
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> enumeration.
    /// </summary>
    internal class LoggingBackendTypeValidator : ILoggingBackendTypeValidator
    {
        /// <summary>Empty, static constructor to prohibit direct allocation of this class.</summary>
        [Log(AttributeExclude = true)]
        static LoggingBackendTypeValidator() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected LoggingBackendTypeValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.Interfaces.ILoggingBackendTypeValidator" />
        /// interface.
        /// </summary>
        internal static ILoggingBackendTypeValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new LoggingBackendTypeValidator();

        /// <summary>
        /// Determines whether the logging backend <paramref name="type" /> value
        /// passed is within the value set that is defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> enumeration.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> values that is to be
        /// examined.
        /// </param>
        /// <remarks>
        /// Besides the usual checks to see whether the value of the
        /// <paramref name="type" /> parameter is within the defined value set of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> enumeration, or to make
        /// sure that the value of the <paramref name="type" /> parameter is not set to
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingBackendType.Unknown" />, this method
        /// also ensures that the value of the <paramref name="type" /> parameter can only
        /// ever be set to either
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingBackendType.Console" /> or
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingBackendType.Log4Net" />, which are the
        /// only currently-supported value(s).
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the logging backend
        /// <paramref name="type" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public bool IsValid(LoggingBackendType type)
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'type', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingBackendTypeValidator.IsValid: type = '{type}'"
                );

                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering,
                 * check the value of the 'type' parameter to ensure that it
                 * is not set to a value outside the set of valid values defined
                 * by the xyLOGIX.Core.Debug.LoggingBackendType
                 * enumeration.
                 *
                 * In principle, since all C# enums devolve to integer values, a
                 * hacker could insert a different value into the CPU register that the
                 * 'type' parameter is read from and thereby make this application
                 * do something it's not intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingBackendTypeValidator.IsValid: Checking whether the value of the 'type' parameter, i.e., '{type}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'type' parameter is within the defined value set of its 
                // enumeration data type.  If this is not the case, then write an error message to the log
                // file, and then terminate the execution of this method while returning the default return
                // value.
                if (!Enum.IsDefined(typeof(LoggingBackendType), type))
                {
                    // The value of the 'type' parameter is NOT within the defined value set for its enumerated data type.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'type' parameter, i.e., '{type}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingBackendTypeValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingBackendTypeValidator.IsValid: *** SUCCESS *** The value of the 'type' parameter, i.e., '{type}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingBackendTypeValidator.IsValid: Checking whether the 'Unknown' value has NOT been specified for the 'type' parameter..."
                );

                // Check whether the 'Unknown' value has been specified for the 'type' parameter.  If this is the case, then
                // write an error message to the log file, and then terminate the execution of this method, returning the default
                // return value in order to indicate that this method failed.
                if (LoggingBackendType.Unknown.Equals(type))
                {
                    // The 'Unknown' value has been specified for the 'type' parameter.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' value has been specified for the 'type' parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingBackendTypeValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingBackendTypeValidator.IsValid: *** SUCCESS *** The 'Unknown' value has NOT been specified for the 'type' parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingBackendTypeValidator.IsValid: Checking whether the logging backend type is either 'Console' or 'Log4Net'..."
                );

                // Check to see whether the logging backend type is either 'Console' or 'Log4Net'.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (!LoggingBackendType.Console.Equals(type) &&
                    !LoggingBackendType.Log4Net.Equals(type))
                {
                    // The logging backend type is neither 'Console' NOR 'Log4Net'.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The logging backend type is neither 'Console' NOR 'Log4Net'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingBackendTypeValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingBackendTypeValidator.IsValid: *** SUCCESS *** The logging backend type is either 'Console' or 'Log4Net'.  Proceeding..."
                );

                /*
                 * If we made it here, then assume that the input data is valid.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingBackendTypeValidator.IsValid: Result = {result}"
            );

            return result;
        }
    }
}