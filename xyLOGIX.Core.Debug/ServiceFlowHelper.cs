using System;
using System.ComponentModel;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods and properties to assist with the operational
    /// flow of a Windows service.
    /// </summary>
    public static class ServiceFlowHelper
    {
        /// <summary> Raised when a start of the debugger is about to occur. </summary>
        public static event Action DebuggerStartPending;

        /// <summary>
        /// Raised when the
        /// <see cref="M:xyLOGIX.Core.Debug.ServiceFlowHelper.EmergencyStop" /> method is
        /// called.
        /// </summary>
        /// <remarks>
        /// Handlers of the event can cancel the operation before it is
        /// undertaken.
        /// </remarks>
        public static event EmergencyStopPendingEventHandler
            EmergencyStopPending;

        /// <summary> Brings the Windows Service screeching suddenly to a halt. </summary>
        /// <remarks>
        /// Before calling this method, services should de-configure themselves
        /// to be automatically re-started by the operating system.
        /// </remarks>
        public static void EmergencyStop()
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In ServiceFlowHelper.EmergencyStop"
            );

            var cea = new CancelEventArgs();
            OnEmergencyStopPending(cea);
            if (cea.Cancel) return;

            DebugUtils.WriteLine(
                DebugLevel.Debug, "ServiceFlowHelper.EmergencyStop: Done."
            );

            DebugUtils.WriteLine(DebugLevel.Error, "*** EMERGENCY STOP ***");

            Environment.Exit(-1);
        }

        /// <summary> Call this method to invoke the just-in-time debugger. </summary>
        /// <remarks>
        /// Raises the
        /// <see cref="E:xyLOGIX.Core.Debug.ServiceFlowHelper.DebuggerStartPending" />
        /// event prior to actually breaking into the debugger. This is helpful to run,
        /// e.g., service configuration code, prior to the operation.
        /// </remarks>
        [DebuggerStepThrough]
        public static void StartDebugger()
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In ServiceFlowHelper.StartDebugger"
            );

            OnDebuggerStartPending();

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "ServiceFlowHelper.StartDebugger: Invoking debugger..."
            );

            Debugger.Launch();
            Debugger.Break();

            DebugUtils.WriteLine(
                DebugLevel.Debug, "ServiceFlowHelper.StartDebugger: Done."
            );
        }

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.Core.Debug.ServiceFlowHelper.DebuggerStartPending" />
        /// event.
        /// </summary>
        private static void OnDebuggerStartPending()
            => DebuggerStartPending?.Invoke();

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.Core.Debug.ProgramFlowHelper.EmergencyStopPending" />
        /// event.
        /// </summary>
        private static void OnEmergencyStopPending(CancelEventArgs e)
            => EmergencyStopPending?.Invoke(e);
    }
}