namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface
    /// that manages our access to the Windows System Event Logs.
    /// </summary>
    public static class GetEventLogManager
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface, and returns a
        /// reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface
        /// that manages our access to the Windows System Event Logs.
        /// </returns>
        public static IEventLogManager SoleInstance()
            => EventLogManager.Instance;
    }
}