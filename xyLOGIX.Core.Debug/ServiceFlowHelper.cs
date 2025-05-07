using PostSharp.Patterns.Diagnostics;
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
    [ExplicitlySynchronized]
    public static class ServiceFlowHelper
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.ServiceFlowHelper" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static ServiceFlowHelper() { }

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
        [Yielder, DebuggerStepThrough]
        public static void EmergencyStop([NotLogged] Action notificationAction = null)
        {
            try
            {
                // write the name of the current class and method we are now
                // entering, into the log
                System.Diagnostics.Debug.WriteLine(
                    "In ServiceFlowHelper.EmergencyStop"
                );

                notificationAction?.Invoke();

                System.Diagnostics.Debug.WriteLine(
                    "ServiceFlowHelper.EmergencyStop: Done."
                );

                System.Diagnostics.Debug.WriteLine("*** EMERGENCY STOP ***");

                Environment.Exit(-1);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.Core.Debug.ServiceFlowHelper.DebuggerStartPending" />
        /// event.
        /// </summary>
        [Yielder, DebuggerStepThrough]
        private static void OnDebuggerStartPending()
            => DebuggerStartPending?.Invoke();

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

            System.Diagnostics.Debug.WriteLine(
                "*** ServiceFlowHelper.StartDebugger: Checking whether the 'Environment.UserInteractive' Boolean expression evaluates to FALSE..."
            );

            // Check to see whether the Boolean expression, Environment.UserInteractive, evaluates to FALSE.  If it does not, log an error message to the log file and then terminate the execution of this method.
            if (Environment.UserInteractive)
            {
                // the Boolean expression, Environment.UserInteractive, evaluated to TRUE.  This is not desirable.
                System.Diagnostics.Debug.WriteLine(
                    "*** ERROR: The Boolean expression, 'Environment.UserInteractive, evaluated to TRUE.  Calling the ProgramFlowHelper class' equivalent of this method..."
                );

                ProgramFlowHelper.StartDebugger();

                // stop.
                return;
            }

            System.Diagnostics.Debug.WriteLine(
                "ServiceFlowHelper.StartDebugger: *** SUCCESS *** The Boolean expression, 'Environment.UserInteractive', evaluated to FALSE.  Proceeding..."
            );

            OnDebuggerStartPending();

            System.Diagnostics.Debug.WriteLine(
                "ServiceFlowHelper.StartDebugger: Invoking debugger..."
            );

            Debugger.Launch();
            Debugger.Break();

            System.Diagnostics.Debug.WriteLine(
                "ServiceFlowHelper.StartDebugger: Done."
            );
        }
    }
}