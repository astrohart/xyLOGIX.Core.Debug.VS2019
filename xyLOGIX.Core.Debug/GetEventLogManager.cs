using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface
    /// that
    /// manages our access to the Windows System Event Logs.
    /// </summary>
    public static class GetEventLogManager
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetEventLogManager" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetEventLogManager() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface, and returns a
        /// reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface
        /// that
        /// manages our access to the Windows System Event Logs.
        /// </returns>
        public static IEventLogManager SoleInstance()
        {
            IEventLogManager result;

            try
            {
                result = EventLogManager.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}