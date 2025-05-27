using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Sets elements of the log. </summary>
    [Log(AttributeExclude = true)]
    internal static class SetLog
    {
        /// <summary>
        /// Gets or sets a string that provides the name to use for the
        /// application's log file.
        /// </summary>
        internal static string ApplicationName
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }
    }
}