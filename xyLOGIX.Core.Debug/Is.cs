using Microsoft.Win32;
using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static method(s) that return <c>bool</c> values indicating whether a
    /// given data element is of a certain type or has a certain value
    /// </summary>
    internal static class Is
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Is" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Is() { }

        /// <summary>Determines whether the Long Path Support is enabled in the system.</summary>
        /// <returns>
        /// <see langword="true" /> if Long Path Support is enabled; otherwise,
        /// <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method checks the Windows Registry to determine if the Long Path
        /// Support is enabled. If the registry check fails, it assumes the legacy behavior
        /// and returns <see langword="false" />.
        /// </remarks>
        internal static bool LongPathSupportEnabled()
        {
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(
                           @"SYSTEM\CurrentControlSet\Control\FileSystem"
                       ))
                {
                    return key?.GetValue("LongPathsEnabled")
                              ?.Equals(1) == true;
                }
            }
            catch
            {
                return false; // Assume legacy behavior if registry check fails
            }
        }
    }
}