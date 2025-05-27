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
                System.Diagnostics.Debug.WriteLine(
                    "Split.CommandLine *** INFO: Checking whether the value of the parameter, 'commandLine', is blank..."
                );

                // Check whether the value of the parameter, 'commandLine', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(commandLine))
                {
                    // The parameter, 'commandLine' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Split.CommandLine: The parameter, 'commandLine' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Split.CommandLine: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'commandLine' is not blank.  Proceeding..."
                );

                var args = new AdvisableCollection<string>();

                System.Diagnostics.Debug.WriteLine(
                    "Split.CommandLine *** INFO: Splitting the command line into arguments..."
                );

                foreach (Match match in CommandLineRegex.Matches(commandLine))
                {
                    var arg = match.Groups[1].Success
                        ? match.Groups[1].Value
                        : match.Groups[2].Value;
                    args.Add(arg);
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** Split.CommandLine: Checking whether the 'args' collection contains greater than zero elements..."
                );

                // Check to see whether the 'args' collection contains greater than
                // zero elements.  Otherwise, write an error message to the Debug output, return
                // the default return value, and then terminate the execution of this method.
                if (args.Count <= 0)
                {
                    // The 'args' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'args' collection contains zero elements.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Split.CommandLine: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Split.CommandLine: *** SUCCESS *** {args.Count} element(s) were found in the 'args' collection.  Proceeding..."
                );

                result = args.ToArray();
            }
            catch
            {
                result = Array.Empty<string>();
            }

            System.Diagnostics.Debug.WriteLine(
                $"Split.CommandLine: Result = '{result}'"
            );

            return result;
        }
    }
}