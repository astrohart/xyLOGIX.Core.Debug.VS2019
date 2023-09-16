using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all output
    /// location objects.
    /// </summary>
    [Log(AttributeExclude = true)]
    public abstract class OutputLocationBase : IOutputLocation
    {
        /// <summary>
        /// Gets or sets a value indicating whether the console multiplexer is
        /// turned on or off.
        /// </summary>
        public bool MuteConsole { get; set; }

        /// <summary>
        /// Gets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.OutputLocationType" /> enumeration values
        /// that indicates the final destination of text strings that are fed to this
        /// location.
        /// </summary>
        public abstract OutputLocationType Type { get; }

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// standard output stream.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public abstract void Write(object value);

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
        public abstract void Write(string format, params object[] arg);

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public abstract void WriteLine(object value);

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
        public abstract void WriteLine(string format, params object[] arg);

        /// <summary>Writes the current line terminator to the standard output stream.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public abstract void WriteLine();
    }
}