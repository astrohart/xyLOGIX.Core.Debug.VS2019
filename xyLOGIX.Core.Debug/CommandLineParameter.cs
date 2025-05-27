using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Values for command-line parameters.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class CommandLineParameter
    {
        /// <summary>
        /// A <see cref="T:System.String" /> that contains the text of the
        /// <c>Halt On Exception</c> command-line flag, which, if present, will force us to
        /// call the <see cref="M:xyLOGIX.Core.Debug.ProgramFlowHelper.StartDebugger" />
        /// method when an exception is thrown.
        /// </summary>
        public const string HaltOnException = "--hoe";
    }
}