using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Writes debugging output to the <b>Output</b> window in Visual Studio
    /// or whichever other debugger can listen to the output of the
    /// <see cref="T:System.Diagnostics.Trace" /> class' methods.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public class TraceOutputLocation : OutputLocationBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static TraceOutputLocation() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected TraceOutputLocation() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface that directs
        /// debugging output to the <b>Output</b> window in Visual Studio when running in
        /// Release mode.
        /// </summary>
        public static IOutputLocation Instance { [DebuggerStepThrough] get; } =
            new TraceOutputLocation();

        /// <summary>
        /// Gets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.OutputLocationType" /> enumeration
        /// values
        /// that indicates the final base of text strings that are fed to this
        /// location.
        /// </summary>
        public override OutputLocationType Type { [DebuggerStepThrough] get; } =
            OutputLocationType.Trace;

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// output location.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <remarks>
        /// If a <see langword="null" /> reference is supplied as the argument of
        /// the <paramref name="value" /> parameter, then this method does nothing.
        /// <para />
        /// This method also takes no action if a debugger is listening or attached.
        /// </remarks>
        public override void Write([NotLogged] object value)
        {
            try
            {
                if (value == null) return;

                /*
                 * This particular Output Listener is designed to output messages
                 * only in Release mode.
                 */

                if (Debugger.IsAttached) return;
                if (Debugger.IsLogging()) return;

                Trace.Write(value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the trace output
                Trace.WriteLine(ex);
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
        /// If a <see langword="null" />, blank, or empty <see cref="T:System.String" /> is
        /// supplied as the argument of the <paramref name="format" /> paramreter, then
        /// this method does nothing.
        /// <para />
        /// This method also takes no action if a debugger is listening or attached.
        /// </remarks>
        public override void Write(
            [NotLogged] string format,
            [NotLogged] params object[] arg
        )
        {
            try
            {
                /*
                 * This particular Output Listener is designed to output messages
                 * only in Release mode.
                 */

                if (Debugger.IsAttached) return;
                if (Debugger.IsLogging()) return;

                if (string.IsNullOrWhiteSpace(format)) return;

                Trace.Write(string.Format(format, arg));
            }
            catch (Exception ex)
            {
                // dump all the exception info to the trace output
                Trace.WriteLine(ex);
            }
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the output location.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <remarks>
        /// If a <see langword="null" /> reference is supplied as the argument of
        /// the <paramref name="value" /> parameter, then this method does nothing.
        /// <para />
        /// This method also takes no action if a debugger is listening or attached.
        /// </remarks>
        public override void WriteLine([NotLogged] object value)
        {
            try
            {
                /*
                 * This particular Output Listener is designed to output messages
                 * only in Release mode.
                 */

                if (Debugger.IsAttached) return;
                if (Debugger.IsLogging()) return;

                if (value == null) return;

                Trace.WriteLine(value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the trace output
                Trace.WriteLine(ex);
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
        /// If a <see langword="null" />, blank, or empty <see cref="T:System.String" /> is
        /// supplied as the argument of the <paramref name="format" /> paramreter, then
        /// this method does nothing.
        /// <para />
        /// This method also takes no action if a debugger is listening or attached.
        /// </remarks>
        public override void WriteLine(
            [NotLogged] string format,
            [NotLogged] params object[] arg
        )
        {
            try
            {
                /*
                 * This particular Output Listener is designed to output messages
                 * only in Release mode.
                 */

                if (Debugger.IsAttached) return;
                if (Debugger.IsLogging()) return;

                if (string.IsNullOrWhiteSpace(format)) return;

                Trace.WriteLine(string.Format(format, arg));
            }
            catch (Exception ex)
            {
                // dump all the exception info to the trace output
                Trace.WriteLine(ex);
            }
        }

        /// <summary>Writes the current line terminator to the output location.</summary>
        /// <remarks>This method takes no action if a debugger is listening or is attached.</remarks>
        public override void WriteLine()
        {
            try
            {
                /*
                 * This particular Output Listener is designed to output messages
                 * only in Release mode.
                 */

                if (Debugger.IsAttached) return;
                if (Debugger.IsLogging()) return;

                Trace.WriteLine(string.Empty);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the trace output
                Trace.WriteLine(ex);
            }
        }
    }
}