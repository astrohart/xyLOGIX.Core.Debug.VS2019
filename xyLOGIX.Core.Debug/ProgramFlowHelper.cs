using System;
using System.Diagnostics;
using xyLOGIX.Beacons.Interfaces;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines methods and properties to aid in controlling the flow of the program.
    /// </summary>
    public static class ProgramFlowHelper
    {
        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Beacons.Interfaces.IBeacon" /> interface that represents
        /// an object that sends out a flash to the entire software system if "the cord"
        /// got pulled.
        /// </summary>
        private static IBeacon EmergencyBeacon { get; } =
            GetEmergencyBeacon.SoleInstance();

        /// <summary>
        /// Brings the application to an immediate halt.
        /// </summary>
        public static void EmergencyStop()
        {
            EmergencyBeacon.Trigger(); // pull the cord, I wanna get off

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
    }
}