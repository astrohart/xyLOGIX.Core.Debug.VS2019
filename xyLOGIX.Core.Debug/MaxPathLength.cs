namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) for the length(s) of pathname(s) that are considered to be the maximum
    /// length(s).
    /// </summary>
    internal static class MaxPathLength
    {
        /// <summary>
        /// Maximum length of a pathname in the Windows operating system according to the
        /// legacy value of <c>MAX_PATH</c>.
        /// </summary>
        internal const int Legacy = 260;

        /// <summary>
        /// Maximum length of a pathname in the Windows operating system according to the
        /// NTFS value.
        /// </summary>
        internal const int NTFS = 32767;
    }
}