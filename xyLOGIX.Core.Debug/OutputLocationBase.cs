using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all output
    /// location objects.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public abstract class OutputLocationBase : IOutputLocation
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.OutputLocationBase" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static OutputLocationBase() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.OutputLocationBase" /> and returns a reference
        /// to it.
        /// </summary>
        /// <remarks>
        /// <strong>NOTE:</strong> This constructor is marked <see langword="protected" />
        /// due to the fact that this class is marked <see langword="abstract" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        protected OutputLocationBase() { }

        /// <summary>
        /// Gets or sets a value indicating whether the console multiplexer is
        /// turned on or off.
        /// </summary>
        public bool MuteConsole
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
        public abstract OutputLocationType Type { [DebuggerStepThrough] get; }

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
        public abstract void Write([NotLogged] object value);

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
        public abstract void Write(
            [NotLogged] string format,
            [NotLogged] params object[] arg
        );

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
        public abstract void WriteLine([NotLogged] object value);

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
        public abstract void WriteLine(
            [NotLogged] string format,
            [NotLogged] params object[] arg
        );

        /// <summary>Writes the current line terminator to the output location.</summary>
        /// <remarks>
        /// This method takes no action if the
        /// <see cref="P:xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole" /> property is
        /// set to <see langword="true" />.
        /// </remarks>
        public abstract void WriteLine();
    }
}