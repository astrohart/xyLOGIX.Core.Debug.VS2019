using log4net.Layout;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Creates instances of <see cref="T:log4net.Layout.PatternLayout" />
    /// that are initialized properly.
    /// </summary>
    public static class GetPatternLayout
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetPatternLayout" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetPatternLayout() { }

        /// <summary>
        /// Creates a new instance of
        /// <see cref="T:log4net.Layout.PatternLayout" /> and initializes the
        /// <see cref="P:log4net.Layout.PatternLayout.ConversionPattern" /> property with
        /// the specified <paramref name="conversionPattern" /> string.
        /// </summary>
        /// <param name="conversionPattern">
        /// (Required.) String containing the conversion
        /// pattern to utilize.
        /// </param>
        /// <returns>
        /// An activated <see cref="T:log4net.Layout.PatternLayout" /> instance
        /// that is initialized with the specified <paramref name="conversionPattern" />,
        /// or <see langword="null" /> if an error occurred or if blank input was supplied
        /// for the <paramref name="conversionPattern" /> parameter.
        /// </returns>
        [DebuggerStepThrough]
        public static PatternLayout ForConversionPattern(
            string conversionPattern
        )
        {
            PatternLayout result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to create a new PatternLayout instance with the conversion pattern, '{conversionPattern}'..."
                );

                var newPatternLayout =
                    MakeNewPatternLayout.HavingConversionPattern(
                        conversionPattern
                    );

                System.Diagnostics.Debug.WriteLine(
                    "GetPatternLayout.ForConversionPattern: Checking whether the variable, 'newPatternLayout', has a null reference for a value..."
                );

                // Check to see if the variable, 'newPatternLayout', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (newPatternLayout == null)
                {
                    // The variable, 'newPatternLayout', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "GetPatternLayout.ForConversionPattern: *** ERROR ***  The variable, 'newPatternLayout', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetPatternLayout.ForConversionPattern: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'newPatternLayout', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "GetPatternLayout.ForConversionPattern: *** SUCCESS *** The variable, 'newPatternLayout', has a valid object reference for its value.  Proceeding..."
                );

                newPatternLayout.ActivateOptions();

                System.Diagnostics.Debug.WriteLine(
                    "GetPatternLayout.ForConversionPattern: *** SUCCESS *** The options for the new PatternLayout instance have been activated.  Proceeding..."
                );

                result = newPatternLayout;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to a newly-activated PatternLayout having the conversion pattern, '{conversionPattern}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to a newly-activated PatternLayout having the conversion pattern, '{conversionPattern}'.  Stopping..."
            );

            return result;
        }
    }
}