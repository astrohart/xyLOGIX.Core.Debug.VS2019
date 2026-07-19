using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates whether certain value(s) are within the defined value set of
    /// the <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration.
    /// </summary>
    internal class SessionLoggerFetchApproachValidator : ISessionLoggerFetchApproachValidator
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static SessionLoggerFetchApproachValidator() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator" /> and
        /// returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the
        /// <see cref="P:xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private SessionLoggerFetchApproachValidator()
        { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator" />
        /// interface.
        /// </summary>
        internal static ISessionLoggerFetchApproachValidator
            Instance
        { [DebuggerStepThrough] get; } = new SessionLoggerFetchApproachValidator();

        /// <summary>
        /// Determines whether the session-logger fetching
        /// <paramref name="approach" /> value passed is within the value set that is
        /// defined by the <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" />
        /// enumeration.
        /// </summary>
        /// <param name="approach">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> values that is
        /// to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the session-logger fetching
        /// <paramref name="approach" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public bool IsValid(SessionLoggerFetchApproach approach)
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'approach', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetchApproachValidator.IsValid: approach = '{approach}'"
                );

                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering, check the value of
                 * the 'approach' parameter to ensure that it is not set to a value outside the set
                 * of valid values defined by the xyLOGIX.Core.Debug.SessionLoggerFetchApproach
                 * enumeration. In principle, since all C# enums devolve to integer values, a hacker
                 * could insert a different value into the CPU register that the 'approach'
                 * parameter is read from and thereby make this application do something it's not
                 * intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetchApproachValidator.IsValid: Checking whether the value of the 'approach' parameter, i.e., '{approach}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'approach' parameter is within the defined value
                // set of its  enumeration data type.  If this is not the case, then write an error
                // message to the log file, and then terminate the execution of this method while
                // returning the default return value.
                if (!Enum.IsDefined(typeof(SessionLoggerFetchApproach), approach))
                {
                    // The value of the 'approach' parameter is NOT within the defined value set for
                    // its enumerated data type.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'approach' parameter, i.e., '{approach}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetchApproachValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetchApproachValidator.IsValid: *** SUCCESS *** The value of the 'approach' parameter, i.e., '{approach}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetchApproachValidator.IsValid: Checking whether the 'Unknown' value has NOT been specified for the 'approach' parameter..."
                );

                // Check whether the 'Unknown' value has been specified for the 'approach'
                // parameter.  If this is the case, then write an error message to the log file, and
                // then terminate the execution of this method, returning the default return value
                // in order to indicate that this method failed.
                if (SessionLoggerFetchApproach.Unknown.Equals(approach))
                {
                    // The 'Unknown' value has been specified for the 'approach' parameter.  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' value has been specified for the 'approach' parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetchApproachValidator.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetchApproachValidator.IsValid: *** SUCCESS *** The 'Unknown' value has NOT been specified for the 'approach' parameter.  Proceeding..."
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
                $"SessionLoggerFetchApproachValidator.IsValid: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Determines whether the session-logger fetching
        /// <paramref name="approach" /> value passed is within the value set that is
        /// defined by the <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" />
        /// enumeration.
        /// </summary>
        /// <param name="approach">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> values that is
        /// to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the session-logger fetching
        /// <paramref name="approach" /> falls within the defined value set;
        /// <see langword="false" /> otherwise.
        /// </returns>
        [Log(AttributeExclude = true)]
        public bool IsValidSilent(SessionLoggerFetchApproach approach)
        {
            var result = false;

            try
            {
                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering, check the value of
                 * the 'approach' parameter to ensure that it is not set to a value outside the set
                 * of valid values defined by the xyLOGIX.Core.Debug.SessionLoggerFetchApproach
                 * enumeration. In principle, since all C# enums devolve to integer values, a hacker
                 * could insert a different value into the CPU register that the 'approach'
                 * parameter is read from and thereby make this application do something it's not
                 * intended to do.
                 */

                if (!Enum.IsDefined(typeof(SessionLoggerFetchApproach), approach)) return result;
                if (SessionLoggerFetchApproach.Unknown.Equals(approach)) return result;

                // TODO: Add any additional validation logic here

                /*
                 * If we made it here, then assume that the input data is valid.
                 */

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}