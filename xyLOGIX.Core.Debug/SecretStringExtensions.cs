using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes "secret" <see cref="T:System.String" /> extension methods to help the
    /// methods in this library only.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class SecretStringExtensions
    {
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

        /// <summary>
        /// Determines whether the specified <paramref name="value" /> is equal to,
        /// regardless of case, any of the item(s) in the specified
        /// <paramref name="list" />.
        /// </summary>
        /// <param name="value">
        /// (Required.) A <see cref="T:System.String" /> containing the
        /// value that is to be examined.
        /// </param>
        /// <param name="list">
        /// (Required.) One or more <see cref="T:System.String" />
        /// value(s) that are to be checked for equality without regard to case.
        /// </param>
        /// <remarks>
        /// If nothing is passed for the <paramref name="list" /> parameter, then
        /// the method returns <see langword="false" />.
        /// <para />
        /// If the value is the <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value, and one of the element(s) of the
        /// <paramref name="list" /> is also, then this method returns
        /// <see langword="true" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if one of the element(s) of the specified
        /// <paramref name="list" /> matches the value, regardless of case; otherwise,
        /// <see langword="false" />.
        /// </returns>
        internal static bool EqualsAnyOfNoCase(
            [NotLogged] this string value,
            [NotLogged] params string[] list
        )
        {
            var result = false;

            try
            {
                if (list == null) return result;
                if (list.Length <= 0) return result;

                foreach (var item in list)
                {
                    /* special case: if the current item is null or
                     blank, and so is the value, then return true
                     immediately */
                    if (string.IsNullOrWhiteSpace(item) &&
                        string.IsNullOrWhiteSpace(value)) return true;

                    /*
                     * otherwise, skip the current item if it isn't equal
                     * to the value, regardless of case.
                     */
                    if (!item.Equals(
                            value, StringComparison.OrdinalIgnoreCase
                        )) continue;

                    result = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified <paramref name="path" /> is a
        /// fully-qualified, absolute path or not.
        /// </summary>
        /// <param name="path"> (Required.) String containing the path to be checked. </param>
        /// <returns>
        /// <see langword="true" /> if the <paramref name="path" /> specified is
        /// a fully-qualified, absolute path; <see langword="false" /> otherwise.
        /// </returns>
        internal static bool IsAbsolutePath(this string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false; // obviously not the case

            bool result;

            try
            {
                result = Path.IsPathRooted(path) && !Path.GetPathRoot(path)
                    .Equals(
                        Path.DirectorySeparatorChar.ToString(),
                        StringComparison.Ordinal
                    );
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}