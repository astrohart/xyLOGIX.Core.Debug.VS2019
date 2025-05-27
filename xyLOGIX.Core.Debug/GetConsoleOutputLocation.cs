using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface
    /// that
    /// directs debugging output to the standard output of the application and/or a
    /// console window, if present.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetConsoleOutputLocation
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface, and returns a
        /// reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface
        /// that
        /// directs debugging output to the standard output of the application and/or a
        /// console window, if present.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static IOutputLocation SoleInstance()
        {
            IOutputLocation result;

            try
            {
                result = ConsoleOutputLocation.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}