using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

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
        {
            [DebuggerStepThrough]
            get
            {
                var result = string.Empty;

                try
                {
                    result = Path.GetTempPath();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = string.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a string containing the fully-qualified pathname to use for the
        /// current log file.
        /// </summary>
        public static string FilePath
        {
            [DebuggerStepThrough]
            get
            {
                var result = string.Empty;

                try
                {
                    if (string.IsNullOrWhiteSpace(FileFolder))
                        return result;
                    if (string.IsNullOrWhiteSpace(FileName))
                        return result;

                    result = Path.Combine(FileFolder, FileName);
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = string.Empty;
                }

                return result;
            }
        }
    }
}