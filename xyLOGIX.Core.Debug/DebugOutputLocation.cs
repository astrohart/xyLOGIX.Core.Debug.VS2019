using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Writes debugging output to the <b>Output</b> window in Visual Studio
    /// or whichever other debugger can listen to the output of the
    /// <see cref="T:System.Diagnostics.Debug" /> class' methods.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal class DebugOutputLocation : OutputLocationBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static DebugOutputLocation() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected DebugOutputLocation() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface
        /// that
        /// directs debugging output to the <b>Output</b> window in Visual Studio or
        /// whichever other debugger can listen to the output of the
        /// <see cref="T:System.Diagnostics.Debug" /> class' methods.
        /// </summary>
        internal static IOutputLocation Instance { [DebuggerStepThrough] get; } =
            new DebugOutputLocation();

        /// <summary>
        /// Gets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.OutputLocationType" /> enumeration
        /// values
        /// that indicates the final base of text strings that are fed to this
        /// location.
        /// </summary>
        public override OutputLocationType Type { [DebuggerStepThrough] get; } =
            OutputLocationType.Debug;

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// output location.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <remarks>
        /// <b>NOTE:</b> It is allowable for the argument of the <paramref name="value" />
        /// parameter to be a <see langword="null" /> reference.
        /// <para/>
        /// If a debugger is not attached, or if logging is not enabled on the
        /// attached debugger, then this method does nothing.
        /// </remarks>
        public override void Write([NotLogged] object value)
        {
            try
            {
                if (!Debugger.IsAttached) return;
                if (!Debugger.IsLogging()) return;

                /*
                 * The 'value' parameter is allowed to be set to a null reference, FYI.
                 */

                System.Diagnostics.Debug.Write(value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the debug output window
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
        /// If <paramref name="format" /> is blank, or if a debugger is not
        /// attached and is not configured for logging, then this method does nothing.
        /// </remarks>
        public override void Write(
            [NotLogged] string format,
            [NotLogged] params object[] arg
        )
        {
            try
            {
                if (!Debugger.IsAttached) return;
                if (!Debugger.IsLogging()) return;

                if (string.IsNullOrWhiteSpace(format)) return;

                System.Diagnostics.Debug.Write(string.Format(format, arg));
            }
            catch (Exception ex)
            {
                // dump all the exception info to the debug output window
                System.Diagnostics.Debug.WriteLine(ex);
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
        /// <para/>
        /// If a debugger is not attached, or if logging is not enabled on the
        /// attached debugger, then this method does nothing.
        /// </remarks>
        public override void WriteLine([NotLogged] object value)
        {
            try
            {
                if (!Debugger.IsAttached) return;
                if (!Debugger.IsLogging()) return;

                /*
                 * The 'value' parameter is allowed to be set to a null reference, FYI.
                 */

                System.Diagnostics.Debug.WriteLine(value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the debug output window
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
        /// If <paramref name="format" /> is blank, or if a debugger is not
        /// attached and is not configured for logging, then this method does nothing.
        /// </remarks>
        public override void WriteLine(
            [NotLogged] string format,
            [NotLogged] params object[] arg
        )
        {
            try
            {
                if (!Debugger.IsAttached) return;
                if (!Debugger.IsLogging()) return;

                if (string.IsNullOrWhiteSpace(format)) return;

                System.Diagnostics.Debug.WriteLine(format, arg);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the debug output window
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>Writes the current line terminator to the output location.</summary>
        /// <remarks>
        /// If a debugger is not attached, or if logging is not enabled on the
        /// attached debugger, then this method does nothing.
        /// </remarks>
        public override void WriteLine()
        {
            try
            {
                if (!Debugger.IsAttached) return;
                if (!Debugger.IsLogging()) return;

                System.Diagnostics.Debug.WriteLine(string.Empty);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the debug output window
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}