using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates whether certain value(s) are within the defined value set of the
    /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration.
    /// </summary>
    public class
        AppenderRetrievalModeValidator : IAppenderRetrievalModeValidator
    {
        /// <summary>Empty, static constructor to prohibit direct allocation of this class.</summary>
        [Log(AttributeExclude = true)]
        static AppenderRetrievalModeValidator() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected AppenderRetrievalModeValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.Interfaces.IAppenderRetrievalModeValidator" />
        /// interface.
        /// </summary>
        public static IAppenderRetrievalModeValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new AppenderRetrievalModeValidator();

        /// <summary>
        /// Determines whether the appender-retrieval <paramref name="mode" />
        /// value passed is within the value set that is defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration.
        /// </summary>
        /// <param name="mode">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> values that is to be
        /// examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the appender-retrieval
        /// <paramref name="mode" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public bool IsValid(AppenderRetrievalMode mode)
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'mode', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"AppenderRetrievalModeValidator.IsValid: mode = '{mode}'"
                );

                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering,
                 * check the value of the 'mode' parameter to ensure that it
                 * is not set to a value outside the set of valid values defined
                 * by the xyLOGIX.Core.Debug.AppenderRetrievalMode
                 * enumeration.
                 *
                 * In principle, since all C# enums devolve to integer values, a
                 * hacker could insert a different value into the CPU register that the
                 * 'mode' parameter is read from and thereby make this application
                 * do something it's not intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"AppenderRetrievalModeValidator.IsValid: Checking whether the value of the 'mode' parameter, i.e., '{mode}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'mode' parameter is within the defined value set of its 
                // enumeration data type.  If this is not the case, then write an error message to the log
                // file, and then terminate the execution of this method while returning the default return
                // value.
                if (!Enum.IsDefined(typeof(AppenderRetrievalMode), mode))
                {
                    // The value of the 'mode' parameter is NOT within the defined value set for its enumerated data type.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'mode' parameter, i.e., '{mode}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"AppenderRetrievalModeValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"AppenderRetrievalModeValidator.IsValid: *** SUCCESS *** The value of the 'mode' parameter, i.e., '{mode}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "AppenderRetrievalModeValidator.IsValid: Checking whether the 'Unknown' value has NOT been specified for the 'mode' parameter..."
                );

                // Check whether the 'Unknown' value has been specified for the 'mode' parameter.  If this is the case, then
                // write an error message to the log file, and then terminate the execution of this method, returning the default
                // return value in order to indicate that this method failed.
                if (AppenderRetrievalMode.Unknown.Equals(mode))
                {
                    // The 'Unknown' value has been specified for the 'mode' parameter.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' value has been specified for the 'mode' parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"AppenderRetrievalModeValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "AppenderRetrievalModeValidator.IsValid: *** SUCCESS *** The 'Unknown' value has NOT been specified for the 'mode' parameter.  Proceeding..."
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
                $"AppenderRetrievalModeValidator.IsValid: Result = {result}"
            );

            return result;
        }
    }
}