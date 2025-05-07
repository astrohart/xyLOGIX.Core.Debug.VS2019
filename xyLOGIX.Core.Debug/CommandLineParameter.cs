using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Values for command-line parameters.
    /// </summary>
    public static class CommandLineParameter
    {
        /// <summary>
        /// A <see cref="T:System.String" /> that contains the text of the
        /// <c>Halt On Exception</c> command-line flag, which, if present, will force us to
        /// call the <see cref="M:xyLOGIX.Core.Debug.ProgramFlowHelper.StartDebugger" />
        /// method when an exception is thrown.
        /// </summary>
        public const string HaltOnException = "--hoe";

        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.CommandLineParameter" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static CommandLineParameter() { }
    }
}