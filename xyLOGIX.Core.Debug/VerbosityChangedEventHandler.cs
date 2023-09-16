namespace xyLOGIX.Core.Debug
{
    /// <summary> Represents a handler for a <c>VerbosityChanged</c> event. </summary>
    /// <param name="e" >
    /// A
    /// <see cref="T:xyLOGIX.Core.Debug.VerbosityChangedEventArgs" /> that contains the
    /// event data.
    /// </param>
    /// <remarks>
    /// This delegate merely specifies the signature of all methods that
    /// handle the <c>VerbosityChanged</c> event.
    /// </remarks>
    public delegate void VerbosityChangedEventHandler(
        VerbosityChangedEventArgs e
    );
}