using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface
    /// that
    /// directs debugging output to the <b>Output</b> window in Visual Studio or
    /// whichever other debugger can listen to the output of the
    /// <see cref="T:System.Diagnostics.Trace" /> class' methods.
    /// </summary>
    [Log(AttributeExclude = true)]
    public static class GetTraceOutputLocation
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetTraceOutputLocation" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetTraceOutputLocation() { }

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
        /// <see cref="T:System.Diagnostics.Trace" /> class' methods.
        /// </returns>
        public static IOutputLocation SoleInstance()
            => TraceOutputLocation.Instance;
    }
}