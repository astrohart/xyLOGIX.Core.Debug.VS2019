using System;
using System.ComponentModel;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines methods and properties to aid in controlling the flow of the program.
    /// </summary>
    public static class ProgramFlowHelper
    {
        /// <summary>
        /// Raised when the
        /// <see cref="M:xyLOGIX.Core.Debug.ProgramFlowHelper.EmergencyStop" /> method is
        /// called.
        /// </summary>
        /// <remarks>
        /// Handlers of the event can cancel the operation before it is undertaken.
        /// </remarks>
        public static event EmergencyStopPendingEventHandler
            EmergencyStopPending;

        /// <summary>
        /// Brings the application to an immediate halt.
        /// </summary>
        /// <remarks>
        /// This method raises the
        /// <see cref="E:xyLOGIX.Core.Debug.ProgramFlowHelper.EmergencyStopPending" />
        /// event just before bringing the application to a halt.
        /// <para />
        /// Handlers of the event can cancel the operation before it is undertaken.
        /// </remarks>
        public static void EmergencyStop()
        {
            var cea = new CancelEventArgs();
            OnEmergencyStopPending(cea);
            if (cea.Cancel) return;

            Environment.Exit(-1);
        }

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

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.Core.Debug.ProgramFlowHelper.EmergencyStopPending" />
        /// event.
        /// </summary>
        private static void OnEmergencyStopPending(CancelEventArgs e)
            => EmergencyStopPending?.Invoke(e);
    }
}