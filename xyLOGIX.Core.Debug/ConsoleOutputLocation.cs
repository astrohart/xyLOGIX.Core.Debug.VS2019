using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Writes debugging output to the standard output of the application
    /// and/or a console window, if present.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal class ConsoleOutputLocation : OutputLocationBase
    {
        /// <summary>
        /// Empty, <see langword="static" /> constructor to prohibit direct allocation of
        /// <see cref="T:xyLOGIX.Core.Debug.ConsoleOutputLocation" /> class.
        /// </summary>
        static ConsoleOutputLocation() { }

        /// <summary>
        /// Empty, <see langword="private" /> constructor to prohibit direct allocation of
        /// the
        /// <see cref="T:xyLOGIX.Core.Debug.ConsoleOutputLocation" /> class.
        /// </summary>
        [Log(AttributeExclude = true)]
        private ConsoleOutputLocation() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface
        /// that directs debugging output to the standard output of the application and/or
        /// a console window, if present.
        /// </summary>
        internal static IOutputLocation
            Instance { [DebuggerStepThrough] get; } =
            new ConsoleOutputLocation();

        /// <summary>
        /// Gets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.OutputLocationType" /> enumeration
        /// values
        /// that indicates the final base of text strings that are fed to this
        /// location.
        /// </summary>
        public override OutputLocationType Type { [DebuggerStepThrough] get; } =
            OutputLocationType.Console;

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// output location.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <remarks>
        /// <b>NOTE:</b> It is allowable for the argument of the <paramref name="value" />
        /// parameter to be a <see langword="null" /> reference.
        /// <para />
        /// This method does nothing if the value of the
        /// <see cref="P:MuteConsole" /> property is set to <see langword="true" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        public override void Write([NotLogged] object value)
        {
            try
            {
                if (MuteConsole) return;

                Console.Write(value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

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
        public override void Write(
            [NotLogged] string format,
            [NotLogged] params object[] arg
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(format)) return;

                if (MuteConsole) return;

                Console.Write(format, arg);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the console
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the output location.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <remarks>
        /// <b>NOTE:</b> It is allowable for the argument of the <paramref name="value" />
        /// parameter to be a <see langword="null" /> reference.
        /// <para />
        /// This method takes no action if the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole" /> property is
        /// set to <see langword="true" />.
        /// </remarks>
        public override void WriteLine([NotLogged] object value)
        {
            try
            {
                if (MuteConsole) return;

                Console.WriteLine(value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

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
        /// <para />
        /// This method will not execute if the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole" /> property is
        /// set to <see langword="true" />.
        /// </remarks>
        public override void WriteLine(
            [NotLogged] string format,
            [NotLogged] params object[] arg
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(format)) return;

                if (MuteConsole) return;

                Console.WriteLine(format, arg);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>Writes the current line terminator to the output location.</summary>
        /// <remarks>
        /// This method will not execute if the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole" /> property is
        /// set to <see langword="true" />.
        /// </remarks>
        public override void WriteLine()
        {
            try
            {
                if (MuteConsole) return;

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}