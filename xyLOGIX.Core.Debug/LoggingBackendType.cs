namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Enumerated values that allow us to select from among the supported
    /// logging backends.
    /// </summary>
    /// <remarks>
    /// THis enumeration is only to be used when PostSharp is selected as the
    /// logging infrastructure.
    /// </remarks>
    public enum LoggingBackendType
    {
        /// <summary>
        /// The log messages are to be routed to the console.
        /// </summary>
        Console,

        /// <summary>
        /// The log messages are to be sent to <c>log4net</c>.
        /// </summary>
        Log4Net,

        /// <summary>
        /// Unknown logging backend.
        /// </summary>
        Unknown = -1
    }
}