using System;
using System.IO;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Methods to delete files and folders.
    /// </summary>
    public static class Delete
    {
        /// <summary>
        /// Deletes a log file having the specified <paramref name="path" />.
        /// </summary>
        /// <param name="path">
        /// (Required.) String containing the fully-qualified pathname
        /// of the file that is to be deleted.
        /// </param>
        /// <remarks>
        /// If the <paramref name="path" /> parameter is blank or
        /// <see langword="null" />, then this method does nothing.
        /// <para />
        /// This method also takes no action if the file having the specified
        /// <paramref name="path" /> does not already exist on the disk.
        /// </remarks>
        public static void LogFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;

            try
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }
    }
}
