using PostSharp.Patterns.Threading;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of an object that
    /// writes output logging lines to multiple destinations at the same time..
    /// </summary>
    [Actor]
    public interface IOutputLocationProvider
    {
        /// <summary>
        /// Gets or sets a value indicating whether the console multiplexer is
        /// turned on or off.
        /// </summary>
        /// <remarks>
        /// This property raises the
        /// <see cref="E:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsoleChanged" />
        /// event
        /// when its value is updated.
        /// </remarks>
        bool MuteConsole { get; set; }

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole" />
        /// property is
        /// updated.
        /// </summary>
        event MuteConsoleChangedEventHandler MuteConsoleChanged;

        /// <summary>
        /// Adds the specified output <paramref name="location" /> to the
        /// internal list maintained by this object.
        /// </summary>
        /// <param name="location">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface.
        /// </param>
        /// <remarks>
        /// If the specified <paramref name="location" /> has already been added,
        /// then this method does nothing.
        /// </remarks>
        void AddLocation(IOutputLocation location);

        /// <summary> Clears the internal list of output locations. </summary>
        void Clear();

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// standard output stream.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        void Write(object value);

        /// <summary>
        /// Writes the text representation of the specified array of objects to
        /// the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">
        /// An array of objects to write using
        /// <paramref name="format" /> .
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or
        /// <paramref name="arg" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.FormatException">
        /// The format specification in
        /// <paramref name="format" /> is invalid.
        /// </exception>
        void Write(string format, params object[] arg);

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        void WriteLine(object value);

        /// <summary>
        /// Writes the text representation of the specified array of objects,
        /// followed by the current line terminator, to the standard output stream using
        /// the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">
        /// An array of objects to write using
        /// <paramref name="format" /> .
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or
        /// <paramref name="arg" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.FormatException">
        /// The format specification in
        /// <paramref name="format" /> is invalid.
        /// </exception>
        void WriteLine(string format, params object[] arg);

        /// <summary>Writes the current line terminator to the standard output stream.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        void WriteLine();
    }
}