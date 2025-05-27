namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods and properties to determine whether
    /// facts
    /// about logs or logging are true.
    /// </summary>
    internal static class IsLog
    {
        /// <summary>
        /// Gets a value that determines whether the logging system has been
        /// initialized.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the logging system has been initialized;
        /// <see langword="false" /> otherwise.
        /// </returns>
        internal static bool Initialized
            => !string.IsNullOrWhiteSpace(SetLog.ApplicationName);
    }
}