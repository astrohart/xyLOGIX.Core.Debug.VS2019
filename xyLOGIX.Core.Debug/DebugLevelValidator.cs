using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates whether certain value(s) are within the defined value set of the
    /// <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> enumeration.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal class DebugLevelValidator : IDebugLevelValidator
    {
        /// <summary>Empty, static constructor to prohibit direct allocation of this class.</summary>
        static DebugLevelValidator() { }

        /// <summary>
        /// Empty, <see langword="private" /> constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        private DebugLevelValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.Interfaces.IDebugLevelValidator" /> interface.
        /// </summary>
        internal static IDebugLevelValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new DebugLevelValidator();

        /// <summary>
        /// Determines whether the debug <paramref name="level" /> value passed is
        /// within the value set that is defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> enumeration.
        /// </summary>
        /// <param name="level">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values that is to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the debug <paramref name="level" /> falls
        /// within the defined value set; <see langword="false" /> otherwise.
        /// </returns>
        public bool IsValid(DebugLevel level)
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'level', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"DebugLevelValidator.IsValid: level = '{level}'"
                );

                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering,
                 * check the value of the 'level' parameter to ensure that it
                 * is not set to a value outside the set of valid values defined
                 * by the xyLOGIX.Core.Debug.DebugLevel
                 * enumeration.
                 *
                 * In principle, since all C# enums devolve to integer values, a
                 * hacker could insert a different value into the CPU register that the
                 * 'level' parameter is read from and thereby make this application
                 * do something it's not intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"DebugLevelValidator.IsValid: Checking whether the value of the 'level' parameter, i.e., '{level}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'level' parameter is within the defined value set of its 
                // enumeration data type.  If this is not the case, then write an error message to the log
                // file, and then terminate the execution of this method while returning the default return
                // value.
                if (!Enum.IsDefined(typeof(DebugLevel), level))
                {
                    // The value of the 'level' parameter is NOT within the defined value set for its enumerated data type.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'level' parameter, i.e., '{level}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugLevelValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DebugLevelValidator.IsValid: *** SUCCESS *** The value of the 'level' parameter, i.e., '{level}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DebugLevelValidator.IsValid: Checking whether the 'Unknown' value has NOT been specified for the 'level' parameter..."
                );

                // Check whether the 'Unknown' value has been specified for the 'level' parameter.  If this is the case, then
                // write an error message to the log file, and then terminate the execution of this method, returning the default
                // return value in order to indicate that this method failed.
                if (DebugLevel.Unknown.Equals(level))
                {
                    // The 'Unknown' value has been specified for the 'level' parameter.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' value has been specified for the 'level' parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DebugLevelValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DebugLevelValidator.IsValid: *** SUCCESS *** The 'Unknown' value has NOT been specified for the 'level' parameter.  Proceeding..."
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
                $"DebugLevelValidator.IsValid: Result = {result}"
            );

            return result;
        }
    }
}
