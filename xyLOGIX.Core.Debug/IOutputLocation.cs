using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of an object that
    /// writes output logging lines to multiple destinations at the same time..
    /// </summary>
    public interface IOutputLocation
    {
        /// <summary>
        /// Gets or sets a value indicating whether the console multiplexer is
        /// turned on or off.
        /// </summary>
        bool MuteConsole
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.OutputLocationType" /> enumeration
        /// values
        /// that indicates the final base of text strings that are fed to this
        /// location.
        /// </summary>
        OutputLocationType Type { [DebuggerStepThrough] get; }

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// standard output stream.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <remarks>
        /// This method does nothing if the specified <paramref name="value" /> is
        /// a <see langword="null" /> reference, or if the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole" /> property is
        /// set to <see langword="true" />.
        /// </remarks>
        void Write([NotLogged] object value);

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
        /// <remarks>
        /// This method does nothing if the specified <paramref name="value" /> is
        /// a <see langword="null" /> reference, or if the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole" /> property is
        /// set to <see langword="true" />.
        /// </remarks>
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