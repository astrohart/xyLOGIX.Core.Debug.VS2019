namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) that explain by which mode an <c>Appender</c> is to be retrieved,
    /// whether a new <c>Appender</c> is to be created or whether an existing
    /// <c>Appender</c> is to be obtained from the <c>Appender Manager</c>, for
    /// example.
    /// </summary>
    public enum AppenderRetrievalMode
    {
        /// <summary>
        /// Create a new <c>RollingFileAppender</c>.
        /// </summary>
        CreateNew,

        /// <summary>
        /// Attempt to obtain an <c>Appender</c> from the <c>Appender Manager</c>.
        /// </summary>
        ObtainExisting,

        /// <summary>
        /// Unknown retrieval mode.
        /// </summary>
        Unknown = -1
    }
}