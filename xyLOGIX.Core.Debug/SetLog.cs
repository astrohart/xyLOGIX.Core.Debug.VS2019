using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Sets elements of the log. </summary>
    public static class SetLog
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.SetLog" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static SetLog() { }

        /// <summary>
        /// Gets or sets a string that provides the name to use for the
        /// application's log file.
        /// </summary>
        public static string ApplicationName
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }
    }
}