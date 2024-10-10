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
            PatternLayout layout;

            try
            {
                layout = new PatternLayout
                {
                    ConversionPattern = conversionPattern
                };
                layout.ActivateOptions();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                layout = default;
            }

            return layout;
        }
    }
}