﻿using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;
using System.Linq;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Writes debugging output to the <b>Output</b> window in Visual Studio
    /// or whichever other debugger can listen to the output of the
    /// <see cref="T:System.Diagnostics.Debug" /> class' methods.
    /// </summary>
    [Log(AttributeExclude = true)]
    public class DebugOutputLocation : OutputLocationBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        static DebugOutputLocation() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        protected DebugOutputLocation() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface
        /// that directs debugging output to the <b>Output</b> window in Visual Studio or
        /// whichever other debugger can listen to the output of the
        /// <see cref="T:System.Diagnostics.Debug" /> class' methods.
        /// </summary>
        public static IOutputLocation Instance { get; } =
            new DebugOutputLocation();

        /// <summary>
        /// Gets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.OutputLocationType" /> enumeration values that
        /// indicates the final destination of text strings that are fed to this location.
        /// </summary>
        public override OutputLocationType Type { get; } =
            OutputLocationType.Debug;

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// standard output stream.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public override void Write(object value)
        {
            if (value == null) return;

            if (Debugger.IsAttached || Debugger.IsLogging()) return;

            System.Diagnostics.Debug.Write(value);
        }

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
        public override void Write(string format, params object[] arg)
        {
            if (Debugger.IsAttached || Debugger.IsLogging()) return;

            if (string.IsNullOrWhiteSpace(format) &
                ((arg == null) | (arg.Length == 0)))
                return;

            System.Diagnostics.Debug.Write(
                !arg.Any() ? format : string.Format(format, arg)
            );
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public override void WriteLine(object value)
        {
            if (value == null) return;

            if (Debugger.IsAttached || Debugger.IsLogging()) return;

            System.Diagnostics.Debug.WriteLine(value);
        }

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
        public override void WriteLine(string format, params object[] arg)
        {
            if (Debugger.IsAttached || Debugger.IsLogging()) return;

            if (string.IsNullOrWhiteSpace(format) &
                ((arg == null) | (arg.Length == 0)))
                return;

            if (!arg.Any())
                System.Diagnostics.Debug.WriteLine(format);
            else
                System.Diagnostics.Debug.WriteLine(format, arg);
        }

        /// <summary>Writes the current line terminator to the standard output stream.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public override void WriteLine()
        {
            if (Debugger.IsAttached || Debugger.IsLogging()) return;

            System.Diagnostics.Debug.WriteLine(string.Empty);
        }
    }
}