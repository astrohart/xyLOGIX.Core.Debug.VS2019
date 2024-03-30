using PostSharp.Patterns.Model;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods and properties to assist with the
    /// operational
    /// flow of a Windows service.
    /// </summary>
    public static class ServiceFlowHelper
    {
        /// <summary> Raised when a start of the debugger is about to occur. </summary>
        [WeakEvent]
        public static event Action DebuggerStartPending;

        /// <summary> Brings the Windows Service screeching suddenly to a halt. </summary>
        /// <param name="notificationAction">
        /// (Optional.) Code to be called immediately
        /// prior to the emergency stop.
        /// <para />
        /// If this parameter is passed a <see langword="null" /> reference as its
        /// argument, then nothing will be called.
        /// </param>
        /// <remarks>
        /// Before calling this method, services should de-configure themselves
        /// to be automatically re-started by the operating system.
        /// </remarks>
        [Yielder]
        public static void EmergencyStop(Action notificationAction = null)
        {
            // write the name of the current class and method we are now
            // entering, into the log
            DebugUtils.WriteLine(
                DebugLevel.Debug, "In ServiceFlowHelper.EmergencyStop"
            );

            notificationAction?.Invoke();

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
        /// event
        /// prior to actually breaking into the debugger. This is helpful to run, e.g.,
        /// service configuration code, prior to the operation.
        /// </remarks>
        [DebuggerStepThrough]
        public static void StartDebugger()
        {
            /*
             * Detect whether the software is launched interactively by the
             * user.  If so, then the ProgramFlowHelper class' version of
             * this method should be called instead.
             */

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "*** ServiceFlowHelper.StartDebugger: Checking whether the 'Environment.UserInteractive' Boolean expression evaluates to FALSE..."
            );

            // Check to see whether the Boolean expression, Environment.UserInteractive, evaluates to FALSE.  If it does not, log an error message to the log file and then terminate the execution of this method.
            if (Environment.UserInteractive)
            {
                // the Boolean expression, Environment.UserInteractive, evaluated to TRUE.  This is not desirable.
                DebugUtils.WriteLine(
                    DebugLevel.Error,
                    "*** ERROR: The Boolean expression, 'Environment.UserInteractive, evaluated to TRUE.  Calling the ProgramFlowHelper class' equivalent of this method..."
                );

                ProgramFlowHelper.StartDebugger();

                // stop.
                return;
            }

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "ServiceFlowHelper.StartDebugger: *** SUCCESS *** The Boolean expression, 'Environment.UserInteractive', evaluated to FALSE.  Proceeding..."
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
        [Yielder]
        private static void OnDebuggerStartPending()
            => DebuggerStartPending?.Invoke();
    }
}