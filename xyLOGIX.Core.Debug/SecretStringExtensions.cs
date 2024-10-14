using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes "secret" <see cref="T:System.String" /> extension methods to help the methods in this library only.
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
        internal static string CollapseNewlinesToSpaces(this string value)
        {
            var result = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(value)) return value;

                result = value.Trim()
                              .Replace("\r\n", "\n")
                              .Replace("\n\n", "\n")
                              .Replace("\n", " ");
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = string.Empty;
            }

            return result;
        }
    }
}