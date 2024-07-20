namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Values describing the type of logging infrastructure you want to
    /// utilize.
    /// </summary>
    public enum LoggingInfrastructureType
    {
        /// <summary> Default logging for legacy code. </summary>
        Default,

        /// <summary> PostSharp-compatible logging infrastructure initialization. </summary>
        PostSharp,

        /// <summary> Unknown strategy type. </summary>
        Unknown = -1
    }
}