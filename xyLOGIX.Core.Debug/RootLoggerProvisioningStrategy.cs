namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) that determine what approach is used for provisioning access to the
    /// <c>Root Logger</c> component.
    /// </summary>
    public enum RootLoggerProvisioningStrategy
    {
        /// <summary>
        /// A <c>loggerRepository</c> parameter is being provided to the method that needs
        /// to provision the <c>Root Logger</c> component; use its value.
        /// </summary>
        FromProvidedLoggingRepository,

        /// <summary>
        /// Call LogManager.GetRepository() to get the root logger.
        /// </summary>
        FromLogManager,

        /// <summary>
        /// Unknown root-logger provisioning strategy.
        /// </summary>
        Unknown = -1
    }
}