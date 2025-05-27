using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface
    /// that
    /// directs debugging output to the <b>Output</b> window in Visual Studio or
    /// whichever other debugger can listen to the output of the
    /// <see cref="T:System.Diagnostics.Debug" /> class' methods.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetDebugOutputLocation
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
        /// directs debugging output to the <b>Output</b> window in Visual Studio or
        /// whichever other debugger can listen to the output of the
        /// <see cref="T:System.Diagnostics.Debug" /> class' methods.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static IOutputLocation SoleInstance()
        {
            IOutputLocation result;

            try
            {
                result = DebugOutputLocation.Instance;
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