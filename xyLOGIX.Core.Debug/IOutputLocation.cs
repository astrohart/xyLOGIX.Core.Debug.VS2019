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
        /// output location.
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
        /// the output location using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">
        /// An array of objects to write using
        /// <paramref name="format" /> .
        /// </param>
        /// <remarks>
        /// This method takes no action if a <see langword="null" />, blank, or empty
        /// <see cref="T:System.String" /> is supplied as the argument of the
        /// <paramref name="format" /> parameter.
        /// <para />
        /// This method will not work if the <paramref name="format" /> parameter has
        /// format argument(s) in it, but the <paramref name="arg" /> array is a
        /// <see langword="null" /> reference, contains a mismatching number of element(s),
        /// or if it contains element(s) whose value(s) do not match the format
        /// specifier(s) in the <paramref name="format" /> parameter.
        /// </remarks>
        void Write([NotLogged] string format, [NotLogged] params object[] arg);

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the output location.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <remarks>
        /// This method does nothing if the specified <paramref name="value" /> is
        /// a <see langword="null" /> reference, or if the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole" /> property is
        /// set to <see langword="true" />.
        /// </remarks>
        void WriteLine([NotLogged] object value);

        /// <summary>
        /// Writes the text representation of the specified array of objects,
        /// followed by the current line terminator, to the output location using
        /// the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">
        /// An array of objects to write using
        /// <paramref name="format" /> .
        /// </param>
        /// <remarks>
        /// This method takes no action if a <see langword="null" />, blank, or empty
        /// <see cref="T:System.String" /> is supplied as the argument of the
        /// <paramref name="format" /> parameter.
        /// <para />
        /// This method will not work if the <paramref name="format" /> parameter has
        /// format argument(s) in it, but the <paramref name="arg" /> array is a
        /// <see langword="null" /> reference, contains a mismatching number of element(s),
        /// or if it contains element(s) whose value(s) do not match the format
        /// specifier(s) in the <paramref name="format" /> parameter.
        /// </remarks>
        void WriteLine([NotLogged] string format, [NotLogged] params object[] arg);

        /// <summary>Writes the current line terminator to the output location.</summary>
        /// <remarks>
        /// This method takes no action if the
        /// <see cref="P:xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole" /> property is
        /// set to <see langword="true" />.
        /// </remarks>
        void WriteLine();
    }
}