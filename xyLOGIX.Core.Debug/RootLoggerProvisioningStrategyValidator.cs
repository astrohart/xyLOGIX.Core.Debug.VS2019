using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates whether certain value(s) are within the defined value set of the
    /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration.
    /// </summary>
    public class
        RootLoggerProvisioningStrategyValidator :
        IRootLoggerProvisioningStrategyValidator
    {
        /// <summary>Empty, static constructor to prohibit direct allocation of this class.</summary>
        [Log(AttributeExclude = true)]
        static RootLoggerProvisioningStrategyValidator() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected RootLoggerProvisioningStrategyValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.Interfaces.IRootLoggerProvisioningStrategyValidator" />
        /// interface.
        /// </summary>
        public static IRootLoggerProvisioningStrategyValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new RootLoggerProvisioningStrategyValidator();

        /// <summary>
        /// Determines whether the root-logger provisioning
        /// <paramref name="strategy" /> value passed is within the value set that is
        /// defined by the
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration.
        /// </summary>
        /// <param name="strategy">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> values that
        /// is to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the root-logger provisioning
        /// <paramref name="strategy" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public bool IsValid(RootLoggerProvisioningStrategy strategy)
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'strategy', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"RootLoggerProvisioningStrategyValidator.IsValid: strategy = '{strategy}'"
                );

                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering,
                 * check the value of the 'strategy' parameter to ensure that it
                 * is not set to a value outside the set of valid values defined
                 * by the xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy
                 * enumeration.
                 *
                 * In principle, since all C# enums devolve to integer values, a
                 * hacker could insert a different value into the CPU register that the
                 * 'strategy' parameter is read from and thereby make this application
                 * do something it's not intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"RootLoggerProvisioningStrategyValidator.IsValid: Checking whether the value of the 'strategy' parameter, i.e., '{strategy}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'strategy' parameter is within the defined value set of its 
                // enumeration data type.  If this is not the case, then write an error message to the log
                // file, and then terminate the execution of this method while returning the default return
                // value.
                if (!Enum.IsDefined(
                        typeof(RootLoggerProvisioningStrategy), strategy
                    ))
                {
                    // The value of the 'strategy' parameter is NOT within the defined value set for its enumerated data type.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'strategy' parameter, i.e., '{strategy}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"RootLoggerProvisioningStrategyValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"RootLoggerProvisioningStrategyValidator.IsValid: *** SUCCESS *** The value of the 'strategy' parameter, i.e., '{strategy}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "RootLoggerProvisioningStrategyValidator.IsValid: Checking whether the 'Unknown' value has NOT been specified for the 'strategy' parameter..."
                );

                // Check whether the 'Unknown' value has been specified for the 'strategy' parameter.  If this is the case, then
                // write an error message to the log file, and then terminate the execution of this method, returning the default
                // return value in order to indicate that this method failed.
                if (RootLoggerProvisioningStrategy.Unknown.Equals(strategy))
                {
                    // The 'Unknown' value has been specified for the 'strategy' parameter.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' value has been specified for the 'strategy' parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"RootLoggerProvisioningStrategyValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "RootLoggerProvisioningStrategyValidator.IsValid: *** SUCCESS *** The 'Unknown' value has NOT been specified for the 'strategy' parameter.  Proceeding..."
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

            return result;
        }
    }
}