using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines methods and properties to aid in controlling the flow of the program.
    /// </summary>
    public static class ProgramFlowHelper
    {
        /// <summary>
        /// Launches the Visual Studio Debugger.
        /// </summary>
        /// <remarks>
        /// This method should be called only as necessary to automatically
        /// launch the Visual Studio Debugger, attached to the currently-running
        /// process instance.
        /// <para />
        /// Such calls should be commented out or deleted when no longer needed.
        /// </remarks>
        public static void StartDebugger()
        {
            Debugger.Launch();
            Debugger.Break();
        }
    }
}
