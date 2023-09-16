namespace xyLOGIX.Core.Debug
{
    /// <summary> Represents a handler for a <c>ExceptionLogged</c> event. </summary>
    /// <param name="e" >
    /// A <see cref="T:xyLOGIX.Core.Debug.ExceptionLoggedEventArgs" />
    /// that contains the event data.
    /// </param>
    /// <remarks>
    /// This delegate merely specifies the signature of all methods that
    /// handle the <c>ExceptionLogged</c> event.
    /// </remarks>
    public delegate void ExceptionLoggedEventHandler(
        ExceptionLoggedEventArgs e
    );
}