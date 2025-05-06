namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) that indicate whether a file is writeable or not, or whether it cannot
    /// be determined from the information available.
    /// </summary>
    public enum FileWriteabilityStatus
    {
        /// <summary>
        /// No determination could be made as to whether the file is writeable or not.
        /// </summary>
        NoDetermination,

        /// <summary>
        /// The file is not writeable by the currently-logged-in user.
        /// </summary>
        NotWriteable,

        /// <summary>
        /// The file is writeable by the currently-logged-in user.
        /// </summary>
        Writeable,

        /// <summary>
        /// Unknown writeability status.
        /// </summary>
        Unknown = -1
    }
}