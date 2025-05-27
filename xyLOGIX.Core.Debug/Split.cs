using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides methods for splitting <see cref="T:System.String" /> value(s) into
    /// array(s) of argument(s)
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class Split
    {
        /// <summary>
        /// Gets a reference to an instance of
        /// <see cref="T:System.Text.RegularExpressions.Regex" /> that is a regular
        /// expression used to split command-line arguments into individual parts.
        /// </summary>
        private static Regex CommandLineRegex { [DebuggerStepThrough] get; } =
            new Regex(
                @"(?<quoted>\""(\""\""|[^\""])*\"")|(?<unquoted>[^ ]+)",
                RegexOptions.Compiled | RegexOptions.ExplicitCapture
            );

        /// <summary>
        /// Splits the specified command-line string into an array of arguments,
        /// respecting quoted segments and spaces.
        /// </summary>
        /// <param name="commandLine">
        /// (Required.) A <see cref="T:System.String" /> containing the full command-line
        /// input
        /// to be split into arguments. If <see langword="null" /> or blank, an empty array
        /// is returned.
        /// </param>
        /// <returns>
        /// An enumerable collection of <see cref="T:System.String" /> values,
        /// each representing an argument parsed from the command line.
        /// The empty collection is returned if the <paramref name="commandLine" /> is
        /// <see langword="null" />, blank, or if a parsing error occurs.
        /// </returns>
        /// <remarks>
        /// This method uses a regular expression to identify arguments based on quoted and
        /// unquoted segments.
        /// Quoted arguments retain their content without the surrounding quotes.
        /// Unquoted arguments are split on spaces.
        /// </remarks>
        [return: NotLogged]
        internal static string[] CommandLine([NotLogged] string commandLine)
        {
            var result = Array.Empty<string>();

            try
            {
                if (string.IsNullOrWhiteSpace(commandLine))
                    return result;

                var args = new AdvisableCollection<string>();

                foreach (Match match in CommandLineRegex.Matches(commandLine))
                {
                    var arg = match.Groups[1].Success
                        ? match.Groups[1].Value
                        : match.Groups[2].Value;
                    args.Add(arg);
                }

                if (args.Count <= 0) return result;

                result = args.ToArray();
            }
            catch
            {
                result = Array.Empty<string>();
            }

            return result;
        }
    }
}