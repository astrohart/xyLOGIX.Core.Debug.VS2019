using log4net.Layout;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static method(s) to create instances of
    /// <see cref="T:log4net.Layout.PatternLayout" /> that are initialized properly,
    /// and return a reference to them.
    /// </summary>
    internal static class MakeNewPatternLayout
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.MakeNewPatternLayout" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MakeNewPatternLayout() { }

        /// <summary>
        /// Creates a new instance of <see cref="T:log4net.Layout.PatternLayout" /> that is
        /// initialized with the specified <paramref name="conversionPattern" />, and
        /// returns a reference to it.
        /// </summary>
        /// <param name="conversionPattern">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the conversion pattern that is to be assigned.
        /// </param>
        /// <remarks>
        /// If the value of the <paramref name="conversionPattern" /> parameter is
        /// a <see langword="null" />, blank, or <see cref="F:System.String.Empty" />
        /// value, then this method returns a <see langword="null" /> reference.
        /// <para />
        /// A <see langword="null" /> reference is also returned if an
        /// <see cref="T:System.Exception" /> is caught during the execution of this
        /// method.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of
        /// <see cref="T:log4net.Layout.PatternLayout" /> that has been initialized with
        /// the specified <paramref name="conversionPattern" />; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        internal static PatternLayout HavingConversionPattern(
            string conversionPattern
        )
        {
            PatternLayout result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "MakeNewPatternLayout.HavingConversionPattern *** INFO: Checking whether the value of the parameter, 'conversionPattern', is blank..."
                );

                // Check whether the value of the parameter, 'conversionPattern', is blank.
                // If this is so, then emit an error message to the Debug output, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(conversionPattern))
                {
                    // The parameter, 'conversionPattern' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewPatternLayout.HavingConversionPattern: *** ERROR *** The parameter, 'conversionPattern' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"MakeNewPatternLayout.HavingConversionPattern: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'conversionPattern' is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine($"*** FYI *** Making a new Pattern Layout having the conversion pattern, '{conversionPattern}'...");

                result = new PatternLayout
                {
                    ConversionPattern = conversionPattern
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to a new Pattern Layout having the conversion pattern, '{conversionPattern}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to a new Pattern Layout having the conversion pattern, '{conversionPattern}'.  Stopping..."
            );

            return result;
        }
    }
}