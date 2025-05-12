using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static method(s) that create and initialize new instances of the
    /// <see
    ///     cref="T:PostSharp.Patterns.Diagnostics.Backends.Console.ConsoleLoggingBackend" />
    /// class, and return references to them.
    /// </summary>
    public static class MakeNewConsoleLoggingBackend
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.MakeNewConsoleLoggingBackend" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MakeNewConsoleLoggingBackend() { }

        /// <summary>
        /// Creates a new instance of
        /// <see
        ///     cref="T:PostSharp.Patterns.Diagnostics.Backends.Console.ConsoleLoggingBackend" />
        /// and returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to a newly-created instance of
        /// <see
        ///     cref="T:PostSharp.Patterns.Diagnostics.Backends.Console.ConsoleLoggingBackend" />
        /// .
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        public static ConsoleLoggingBackend FromScratch()
        {
            PostSharp.Patterns.Diagnostics.Backends.Console.ConsoleLoggingBackend result = default;

            try
            {
                result = new ConsoleLoggingBackend();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}