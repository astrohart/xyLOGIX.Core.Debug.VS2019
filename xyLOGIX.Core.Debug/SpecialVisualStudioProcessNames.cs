using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) that represent the names of special Visual Studio
    /// process(es).
    /// </summary>
    internal static class SpecialVisualStudioProcessNames
    {
        /// <summary>
        /// A <see cref="T:System.String" /> that contains the value,
        /// <c>devenv</c>, which is the name of the <c>DevEnv</c> process of Visual Studio.
        /// </summary>
        internal const string DevEnv = "devenv";

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.SpecialVisualStudioProcessNames" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static SpecialVisualStudioProcessNames() { }
    }
}