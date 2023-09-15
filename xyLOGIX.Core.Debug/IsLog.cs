namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods and properties to determine whether facts
    /// about logs or logging are true.
    /// </summary>
    public static class IsLog
    {
        /// <summary>
        /// Gets a value that determines whether the logging system has been
        /// initialized.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the logging system has been initialized;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public static bool Initialized
            => !string.IsNullOrWhiteSpace(SetLog.ApplicationName);
    }
}