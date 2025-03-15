using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides information for <c>ExceptionLogged</c> event handlers. </summary>
    [ExplicitlySynchronized]
    public class ExceptionLoggedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.ExceptionLoggedEventArgs" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static ExceptionLoggedEventArgs() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.ExceptionLoggedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="exception">
        /// (Required.) Reference to an instance of the
        /// <see cref="T:System.Exception" /> that was logged.
        /// </param>
        [Log(AttributeExclude = true)]
        public ExceptionLoggedEventArgs([NotLogged] Exception exception)
            => Exception = exception;

        /// <summary>
        /// Gets or sets a reference to an instance of the
        /// <see cref="T:System.Exception" /> that was logged.
        /// </summary>
        public Exception Exception { [DebuggerStepThrough] get; }
    }
}