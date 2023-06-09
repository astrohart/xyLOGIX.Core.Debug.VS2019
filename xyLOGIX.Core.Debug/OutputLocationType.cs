namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Values that indicate the type of output location, such as the console window,
    /// debug output pane in Visual Studio, trace listeners, etc.
    /// </summary>
    public enum OutputLocationType
    {
        /// <summary>
        /// Output is directed to the standard output of this application, and a console
        /// window, if present.
        /// </summary>
        Console,

        /// <summary>
        /// Output is directed to the Output window in Visual Studio.
        /// </summary>
        /// <remarks>
        /// This location works even in Release mode.
        /// </remarks>
        Debug,

        /// <summary>
        /// Output is directed to trace listeners.
        /// </summary>
        /// <remarks>This output location does not work in Release mode.</remarks>
        Trace,

        /// <summary>
        /// Unknown output location.
        /// </summary>
        Unknown = -1
    }
}