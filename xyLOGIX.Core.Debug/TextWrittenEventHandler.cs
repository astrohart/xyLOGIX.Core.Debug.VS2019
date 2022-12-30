namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Represents a handler for a TextWritten event.
    /// </summary>
    /// <param name="sender">
    /// Reference to the instance of the object that raised the event.
    /// </param>
    /// <param name="e">
    /// A <see cref="T:Core.Logging.Events.TextWrittenEventArgs" /> that contains the
    /// event data.
    /// </param>
    /// <remarks>
    /// This delegate merely specifies the signature of all methods that handle the
    /// TextWritten event.
    /// <para />
    /// The TextWritten event is raised when text has been output to a console, text
    /// file, or other destination, as a means of allowing more than one part of a
    /// software system to participate in the output of text.
    /// </remarks>
    public delegate void TextWrittenEventHandler(object sender,
        TextWrittenEventArgs e);
}