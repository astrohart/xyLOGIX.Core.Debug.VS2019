namespace xyLOGIX.Core.Debug
{
    /// <summary> Identifies the debug message level for a logging message. </summary>
    public enum DebugLevel
    {
        /// <summary> The logging message is for debugging purposes only. </summary>
        Debug,

        /// <summary> The logging message is for error purposes only. </summary>
        Error,

        /// <summary> The logging message is for informational purposes only. </summary>
        Info,

        /// <summary>
        /// The logging message is intended to show the output of running a child process.
        /// </summary>
        /// <remarks>This debug level is to be reserved.</remarks>
        Output,

        /// <summary> The logging message is for warning purposes only. </summary>
        Warning,

        /// <summary> Unknown logging level.</summary>
        Unknown = -1
    }
}