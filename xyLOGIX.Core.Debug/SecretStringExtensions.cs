using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes "secret" <see cref="T:System.String" /> extension methods to help the
    /// methods in this library only.
    /// </summary>
    internal static class SecretStringExtensions
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.SecretStringExtensions" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static SecretStringExtensions() { }

        /// <summary>
        /// "Collapses" or "folds" the specified <paramref name="value" /> so that all
        /// newlines are transformed to single whitespace characters.
        /// </summary>
        /// <param name="value">
        /// (Required.) A <see cref="T:System.String" /> containing the
        /// value that is to be collapsed.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.String" /> containing the value passed, but with
        /// all newlines transformed to single whitespace characters.
        /// <para />
        /// Multiple newlines are removed.
        /// </returns>
        [Log(AttributeExclude = true)]
        [return: NotLogged]
        internal static string CollapseNewlinesToSpaces(
            [NotLogged] this string value
        )
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "SecretStringExtensions.CollapseNewlinesToSpaces *** INFO: Checking whether the value of the parameter, 'value', is blank..."
                );

                // Check whether the value of the parameter, 'value', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(value))
                {
                    // The parameter, 'value' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "SecretStringExtensions.CollapseNewlinesToSpaces: The parameter, 'value' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"SecretStringExtensions.CollapseNewlinesToSpaces: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'value' is not blank.  Proceeding..."
                );

                result = value.Trim()
                              .Replace("\r\n", "\n")
                              .Replace("\n\n", "\n")
                              .Replace("\n", " ");
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            return result;
        }
    }
}