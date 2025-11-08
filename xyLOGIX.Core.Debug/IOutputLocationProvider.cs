using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of an object that
    /// writes output logging lines to multiple destinations at the same time..
    /// </summary>
    public interface IOutputLocationProvider
    {
        /// <summary>
        /// Gets a value indicating whether greater than zero output location(s) are
        /// currently configured.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if greater than zero output location(s) are
        /// currently configured; <see langword="false" /> otherwise.
        /// </returns>
        bool HasLocations { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets the count of <c>Output Location</c>(s) that are currently defined.
        /// </summary>
        /// <remarks>
        /// If an exception is caught during the execution of the getter of this
        /// property, then the property evaluates to zero.
        /// </remarks>
        /// <returns>
        /// An <see cref="T:System.Int32" /> value that is set to the count of
        /// <c>Output Location</c>(s) that are currently defined.
        /// </returns>
        int LocationCount { [DebuggerStepThrough] get; }

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
        bool MuteConsole
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Adds the specified output <paramref name="location" /> to the
        /// public list maintained by this object.
        /// </summary>
        /// <param name="location">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface.
        /// </param>
        /// <remarks>
        /// If the specified <paramref name="location" /> has already been added,
        /// then this method does nothing.
        /// </remarks>
        void AddOutputLocation([NotLogged] IOutputLocation location);

        /// <summary> Clears the public list of output locations. </summary>
        void Clear();

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole" />
        /// property is
        /// updated.
        /// </summary>
        event MuteConsoleChangedEventHandler MuteConsoleChanged;

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// output location.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        void Write([NotLogged] object value);

        /// <summary>
        /// Writes the text representation of the specified array of objects to
        /// the output location using the specified format information.
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
        void Write([NotLogged] string format, [NotLogged] params object[] arg);

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the output location.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        void WriteLine([NotLogged] object value);

        /// <summary>
        /// Writes the text representation of the specified array of objects,
        /// followed by the current line terminator, to the output location using
        /// the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">
        /// An array of objects to write using
        /// <paramref name="format" /> .
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or
        /// <paramref name="args" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.FormatException">
        /// The format specification in
        /// <paramref name="format" /> is invalid.
        /// </exception>
        void WriteLine([NotLogged] string format, params object[] args);

        /// <summary>Writes the current line terminator to the output location.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        void WriteLine();
    }
}