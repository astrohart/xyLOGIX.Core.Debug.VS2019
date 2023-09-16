using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Writes debugging output to the standard output of the application
    /// and/or a console window, if present.
    /// </summary>
    [Log(AttributeExclude = true)]
    public class ConsoleOutputLocation : OutputLocationBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of
        /// <see cref="T:xyLOGIX.Core.Debug.ConsoleOutputLocation" /> class.
        /// </summary>
        static ConsoleOutputLocation() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of the
        /// <see cref="T:xyLOGIX.Core.Debug.ConsoleOutputLocation" /> class.
        /// </summary>
        protected ConsoleOutputLocation() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface that
        /// directs debugging output to the standard output of the application and/or a
        /// console window, if present.
        /// </summary>
        public static IOutputLocation Instance { get; } =
            new ConsoleOutputLocation();

        /// <summary>
        /// Gets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.OutputLocationType" /> enumeration values
        /// that indicates the final destination of text strings that are fed to this
        /// location.
        /// </summary>
        public override OutputLocationType Type { get; } =
            OutputLocationType.Console;

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// standard output stream.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public override void Write(object value)
        {
            if (value == null) return;

            if (MuteConsole) return;

            Console.Write(value);
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
            if (string.IsNullOrWhiteSpace(format) &
                ((arg == null) | (arg.Length == 0)))
                return;

            if (MuteConsole) return;

            Console.Write(format, arg);
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

            if (MuteConsole) return;

            Console.WriteLine(value);
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
            if (string.IsNullOrWhiteSpace(format) &
                ((arg == null) | (arg.Length == 0)))
                return;

            if (MuteConsole) return;

            Console.WriteLine(format, arg);
        }

        /// <summary>Writes the current line terminator to the standard output stream.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public override void WriteLine()
        {
            if (MuteConsole) return;

            Console.WriteLine();
        }
    }
}