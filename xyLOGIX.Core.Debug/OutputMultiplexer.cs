namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods to multiplex debugging output; i.e., write it to
    /// multiple locations at the same time.
    /// </summary>
    public static class OutputMultiplexer
    {
        /// <summary>
        /// Gets or sets a value indicating whether the console multiplexer is turned on or
        /// off.
        /// </summary>
        public static bool MuteConsole
            => OutputLocationProvider.MuteConsole;

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" /> interface.
        /// </summary>
        private static IOutputLocationProvider OutputLocationProvider { get; } =
            GetOutputLocationProvider.SoleInstance();

        /// <summary>
        /// Writes the text representation of the specified array of objects to
        /// the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">
        /// An array of objects to write using <paramref name="format" />
        /// .
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or <paramref name="arg" /> is
        /// <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.FormatException">
        /// The format specification in
        /// <paramref name="format" /> is invalid.
        /// </exception>
        public static void Write(string format, params object[] arg)
        {
            if (string.IsNullOrWhiteSpace(format) &
                ((arg == null) | (arg.Length == 0)))
                return;

            OutputLocationProvider.Write(format, arg);
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects,
        /// followed by the current line terminator, to the standard output stream using
        /// the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">
        /// An array of objects to write using <paramref name="format" />
        /// .
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or <paramref name="arg" /> is
        /// <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.FormatException">
        /// The format specification in
        /// <paramref name="format" /> is invalid.
        /// </exception>
        public static void WriteLine(string format, params object[] arg)
        {
            if (string.IsNullOrWhiteSpace(format) &
                ((arg == null) | (arg.Length == 0)))
                return;

            OutputLocationProvider.WriteLine(format, arg);
        }

        /// <summary>Writes the current line terminator to the standard output stream.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public static void WriteLine()
            => OutputLocationProvider.WriteLine();

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        public static void WriteLine(object value)
            => OutputLocationProvider.WriteLine(value);
    }
}