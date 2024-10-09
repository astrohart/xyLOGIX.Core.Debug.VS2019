using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static extension methods in order to facilitate handling
    /// exceptions.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.ExceptionExtensions" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static ExceptionExtensions() { }

        /// <summary>
        /// Iterates through the specified collection of
        /// <paramref name="exceptions" /> and logs each one, including its inner
        /// exception, if any, by calling the
        /// <see cref="M:xyLOGIX.Core.Debug.DebugUtils.LogException" /> method.
        /// </summary>
        /// <param name="exceptions">
        /// (Required.) A collection of references to instances
        /// of <see cref="T:System.Exception" /> that represents the exception(s) to be
        /// logged.
        /// </param>
        /// <remarks>
        /// If the <paramref name="exceptions" /> parameter is passed a
        /// <see langword="null" /> reference, or is the empty set, then the method does
        /// nothing.
        /// <para />
        /// If any element of the <paramref name="exceptions" /> collection is
        /// <see langword="null" />, then it is skipped.
        /// </remarks>
        public static void LogAllExceptions(
            this IEnumerable<Exception> exceptions
        )
        {
            /*
             * Nothing to do if there are no exceptions to be logged.
             */

            if (exceptions == null || exceptions.Any()) return;

            /*
             * Iterate through the collection of Exception objects passed,
             * skipping over any elements which are null.
             *
             * If the InnerException property of a particular member of the
             * collection is itself non-null, log that exception first.
             */

            foreach (var exception in exceptions.Where(e => e != null))
                DebugUtils.LogException(exception);
        }
    }
}