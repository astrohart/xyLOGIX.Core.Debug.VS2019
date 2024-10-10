namespace xyLOGIX.Core.Debug
{
    /// <summary> Identifies the debug message level for a logging message. </summary>
    public enum DebugLevel
    {
        /// <summary> The logging message is for debugging purposes only. </summary>
        Debug,

        /// <summary> The logging message is for warning purposes only. </summary>
        Warning,

        /// <summary> The logging message is for error purposes only. </summary>
        Error,

        /// <summary> The logging message is for informational purposes only. </summary>
        Info,

        /// <summary> Unknown logging level.</summary>
        Unknown = -1
    }
}