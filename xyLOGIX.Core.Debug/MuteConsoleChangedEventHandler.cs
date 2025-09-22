using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Represents a handler for a <c>MuteConsoleChanged</c> event. </summary>
    /// <param name="sender">
    /// Reference to the instance of the object that raised the
    /// event.
    /// </param>
    /// <param name="e">
    /// A
    /// <see cref="T:xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs" /> that contains
    /// the event data.
    /// </param>
    /// <remarks>
    /// This delegate merely specifies the signature of all methods that
    /// handle the <c>MuteConsoleChanged</c> event.
    /// </remarks>
    public delegate void MuteConsoleChangedEventHandler(
        [NotLogged] object sender,
        [NotLogged] MuteConsoleChanged[NotLogged] EventArgs e
    );
}