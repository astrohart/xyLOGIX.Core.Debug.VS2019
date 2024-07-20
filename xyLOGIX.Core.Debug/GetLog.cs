using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Gets data used for logging. </summary>
    public static class GetLog
    {
        /// <summary> String containing the pattern to use for the name of the log file. </summary>
        public static readonly string FileName =
            $"dd_{SetLog.ApplicationName}_Run_{Guid.NewGuid():N}_{DateTime.Now:yyyyMMMddHHmmss}_log.txt";

        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetLog" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLog() { }

        /// <summary>
        /// Gets a string that contains the fully-qualified pathname of the
        /// current user's temporary files folder.
        /// </summary>
        public static string FileFolder
            => Path.GetTempPath();

        /// <summary>
        /// Gets a string containing the fully-qualified pathname to use for the
        /// current log file.
        /// </summary>
        public static string FilePath
            => Path.Combine(FileFolder, FileName);
    }
}