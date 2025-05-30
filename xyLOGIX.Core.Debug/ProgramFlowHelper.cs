﻿using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines methods and properties to aid in controlling the flow of the
    /// program.
    /// </summary>
    [ExplicitlySynchronized, Log(AttributeExclude = true)]
    public static class ProgramFlowHelper
    {
        /// <summary> Brings the application to an immediate halt. </summary>
        [DebuggerStepThrough]
        public static void EmergencyStop()
            => Environment.Exit(-1);

        /// <summary> Launches the Visual Studio Debugger. </summary>
        /// <remarks>
        /// This method should be called only as necessary to automatically
        /// launch the Visual Studio Debugger, attached to the currently-running process
        /// instance.
        /// <para />
        /// Such calls should be commented out or deleted when no longer needed.
        /// </remarks>
        [DebuggerStepThrough, Log(AttributeExclude = true)]
        public static void StartDebugger()
        {
            Debugger.Launch();
            Debugger.Break();
        }
    }
}