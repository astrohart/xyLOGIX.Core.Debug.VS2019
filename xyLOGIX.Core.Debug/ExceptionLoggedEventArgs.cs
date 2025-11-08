using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides information for <c>ExceptionLogged</c> event handlers. </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public class ExceptionLoggedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.ExceptionLoggedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="exception">
        /// (Required.) Reference to an instance of the
        /// <see cref="T:System.Exception" /> that was logged.
        /// </param>
        public ExceptionLoggedEventArgs([NotLogged] Exception exception)
            => Exception = exception;

        /// <summary>
        /// Gets or sets a reference to an instance of the
        /// <see cref="T:System.Exception" /> that was logged.
        /// </summary>
        public Exception Exception { [DebuggerStepThrough] get; }
    }
}