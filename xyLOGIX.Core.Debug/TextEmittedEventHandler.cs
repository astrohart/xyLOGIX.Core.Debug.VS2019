namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Represents a handler for a <c>TextEmitted</c> event.
    /// </summary>
    /// <param name="e">
    /// A <see cref="T:xyLOGIX.Core.Debug.TextEmittedEventArgs" /> that contains the
    /// event data.
    /// </param>
    /// <remarks>
    /// This delegate merely specifies the signature of all methods that handle the
    /// <c>TextEmitted</c> event.
    /// </remarks>
    public delegate void TextEmittedEventHandler(TextEmittedEventArgs e);
}