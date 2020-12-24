namespace xyLOGIX.Core.Debug
{
    /// <summary>
    ///     Implements log-file management for the case when we are utilizing PostSharp
    ///     aspects to handle the bulk of logging for us.
    /// </summary>
    public class PostSharpLoggingInfrastructure : DefaultLoggingInfrastructure
    {
        /// <summary>
        ///     Gets the <see cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType" />
        ///     value that corresponds to the type of infrastructure that is being
        ///     utilized.
        /// </summary>
        public override LoggingInfrastructureType Type =>
            LoggingInfrastructureType.PostSharp;
    }
}