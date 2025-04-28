namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) that indicate which type of <c>Logging Configurator</c> is being used
    /// to configure the logging of the application.
    /// </summary>
    public enum LoggingConfiguratorType
    {
        /// <summary>
        /// A <c>Logging Configurator</c> that configures logging using the
        /// <c>app.config</c> or <c>web.config</c> file settings.
        /// </summary>
        FromConfigFile,

        /// <summary>
        /// A <c>Logging Configurator</c> that programmatically configures logging.
        /// </summary>
        Programmatic,

        /// <summary>
        /// Unknown type of <c>Logging Configurator</c>.
        /// </summary>
        Unknown = -1
    }
}