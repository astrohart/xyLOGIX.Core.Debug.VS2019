namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Values to indicate the level of logging message to be utilized for the
    /// debugging log.
    /// </summary>
    public enum DebugLevel
    {
        /// <summary>
        /// Informational message to be displayed even in Release mode.
        /// </summary>
        Info,

        /// <summary>
        /// Warning that indicates a potential risk that has not yet become an issue.
        /// </summary>
        Warning,

        /// <summary>
        /// Error that indicates an issue that has led to the stoppage of an
        /// operation or the software as a whole.
        /// </summary>
        Error,

        /// <summary>
        /// Informational message that may only be visible from a Debug mode executable.
        /// </summary>
        Debug
    }
}