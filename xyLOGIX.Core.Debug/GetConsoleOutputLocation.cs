namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface that directs
    /// debugging output to the standard output of the application and/or a console
    /// window, if present.
    /// </summary>
    public static class GetConsoleOutputLocation
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface, and returns a
        /// reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface that directs
        /// debugging output to the standard output of the application and/or a console
        /// window, if present.
        /// </returns>
        public static IOutputLocation SoleInstance()
            => ConsoleOutputLocation.Instance;
    }
}