using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates whether certain value(s) are within the defined value set of the
    /// <see cref="T:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus" /> enumeration.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal class
        DirectoryWriteabilityStatusValidator :
        IDirectoryWriteabilityStatusValidator
    {
        /// <summary>Empty, static constructor to prohibit direct allocation of this class.</summary>
        static DirectoryWriteabilityStatusValidator() { }

        /// <summary>
        /// Empty, <see langword="private" /> constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        private DirectoryWriteabilityStatusValidator()
        { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.Interfaces.IDirectoryWriteabilityStatusValidator" />
        /// interface.
        /// </summary>
        internal static IDirectoryWriteabilityStatusValidator Instance
        {
            [DebuggerStepThrough]
            get;
        } = new DirectoryWriteabilityStatusValidator();

        /// <summary>
        /// Determines whether the directory writeability
        /// <paramref name="status" /> value passed is within the value set that is defined
        /// by the <see cref="T:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus" />
        /// enumeration.
        /// </summary>
        /// <param name="status">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.DirectoryWriteabilityStatus" /> values that is
        /// to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the directory writeability
        /// <paramref name="status" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public bool IsValid(DirectoryWriteabilityStatus status)
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'status', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"DirectoryWriteabilityStatusValidator.IsValid: status = '{status}'"
                );

                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering,
                 * check the value of the 'status' parameter to ensure that it
                 * is not set to a value outside the set of valid values defined
                 * by the xyLOGIX.Core.Debug.DirectoryWriteabilityStatus
                 * enumeration.
                 *
                 * In principle, since all C# enums devolve to integer values, a
                 * hacker could insert a different value into the CPU register that the
                 * 'status' parameter is read from and thereby make this application
                 * do something it's not intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"DirectoryWriteabilityStatusValidator.IsValid: Checking whether the value of the 'status' parameter, i.e., '{status}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'status' parameter is within the defined value set of its
                // enumeration data type.  If this is not the case, then write an error message to the log
                // file, and then terminate the execution of this method while returning the default return
                // value.
                if (!Enum.IsDefined(
                        typeof(DirectoryWriteabilityStatus), status
                    ))
                {
                    // The value of the 'status' parameter is NOT within the defined value set for its enumerated data type.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'status' parameter, i.e., '{status}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DirectoryWriteabilityStatusValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"DirectoryWriteabilityStatusValidator.IsValid: *** SUCCESS *** The value of the 'status' parameter, i.e., '{status}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "DirectoryWriteabilityStatusValidator.IsValid: Checking whether the 'Unknown' value has NOT been specified for the 'status' parameter..."
                );

                // Check whether the 'Unknown' value has been specified for the 'status' parameter.  If this is the case, then
                // write an error message to the log file, and then terminate the execution of this method, returning the default
                // return value in order to indicate that this method failed.
                if (DirectoryWriteabilityStatus.Unknown.Equals(status))
                {
                    // The 'Unknown' value has been specified for the 'status' parameter.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' value has been specified for the 'status' parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"DirectoryWriteabilityStatusValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "DirectoryWriteabilityStatusValidator.IsValid: *** SUCCESS *** The 'Unknown' value has NOT been specified for the 'status' parameter.  Proceeding..."
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

            return result;
        }
    }
}
