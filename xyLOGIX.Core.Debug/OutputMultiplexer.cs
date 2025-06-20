using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to multiplex debugging output; i.e.,
    /// write it
    /// to multiple locations at the same time.
    /// </summary>
    [Log(AttributeExclude = true)]
    public static class OutputMultiplexer
    {
        /// <summary>
        /// Gets or sets a value indicating whether the console multiplexer is
        /// turned on or off.
        /// </summary>
        public static bool MuteConsole
            => OutputLocationProvider.MuteConsole;

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" /> interface.
        /// </summary>
        private static IOutputLocationProvider OutputLocationProvider
        {
            [DebuggerStepThrough]
            get;
        } = GetOutputLocationProvider.SoleInstance();

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
        /// If the value of the <paramref name="format" /> parameter is blank,
        /// <see langword="null" />, or the <see cref="F:System.String.Empty" /> value,
        /// then this method does nothing.
        /// <para />
        /// This method also takes no action if there are zero <c>Output Location</c>(s)
        /// defined.
        /// </remarks>
        public static void Write([NotLogged] string format, params object[] arg)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(format)) return;
                if (!OutputLocationProvider.HasLocations) return;

                OutputLocationProvider.Write(format, arg);
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
        /// If the value of the <paramref name="format" /> parameter is blank,
        /// <see langword="null" />, or the <see cref="F:System.String.Empty" /> value,
        /// then this method does nothing.
        /// <para />
        /// This method also takes no action if there are zero <c>Output Location</c>(s)
        /// defined.
        /// </remarks>
        public static void WriteLine(
            [NotLogged] string format,
            params object[] arg
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(format)) return;
                if (!OutputLocationProvider.HasLocations) return;

                OutputLocationProvider.WriteLine(format, arg);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>Writes the current line terminator to the output location.</summary>
        /// <remarks>
        /// This method takes no action if there are zero <c>Output Location</c>
        /// (s) currently defined.
        /// </remarks>
        public static void WriteLine()
        {
            try
            {
                if (!OutputLocationProvider.HasLocations) return;

                OutputLocationProvider.WriteLine();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the output location.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed as the argument of
        /// the <paramref name="value" /> parameter, then this method takes no action.
        /// <para />
        /// This method also will not work if there are zero <c>Output Location</c>(s)
        /// defined.
        /// </remarks>
        public static void WriteLine([NotLogged] object value)
        {
            try
            {
                if (value == null) return;
                if (!OutputLocationProvider.HasLocations) return;

                OutputLocationProvider.WriteLine(value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}