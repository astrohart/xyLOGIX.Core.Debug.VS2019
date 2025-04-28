namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) that specify the manner in which the logging subsystem is configured.
    /// </summary>
    public enum XmlLoggingConfiguratorType
    {
        /// <summary>
        /// An XML-formatted <c>app.config</c> or <c>web.config</c> file is available for
        /// configuration of the logging subsystem.
        /// </summary>
        FileBased,

        /// <summary>
        /// No XML-formatted <c>app.config</c> or <c>web.config</c> file is available for
        /// configuration of the logging subsystem.
        /// </summary>
        NoFile,

        /// <summary>
        /// Unknown XML logging configurator type.
        /// </summary>
        Unknown = -1
    }
}