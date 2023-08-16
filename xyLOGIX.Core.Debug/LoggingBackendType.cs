namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Enumerated values that allow us to select from among the supported logging
    /// backends.
    /// </summary>
    /// <remarks>
    /// THis enumeration is only to be used when PostSharp is selected as the logging
    /// infrastructure.
    /// </remarks>
    public enum LoggingBackendType
    {
        Console,
        Log4Net,
        Unknown = -1
    }
}