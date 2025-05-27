using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static extension methods in order to facilitate handling
    /// exceptions.
    /// </summary>
    /// <remarks>This class is part of the publicly-exposed API of this library.</remarks>
    [Log(AttributeExclude = true)]
    [ExplicitlySynchronized]
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Determines whether the <see cref="T:System.Type" /> of the specified
        /// <paramref name="exception" /> matches any of the specified
        /// <paramref name="types" />.
        /// </summary>
        /// <param name="exception">
        /// (Required.) Reference to an instance of <see cref="T:System.Exception" /> that
        /// is the exception whose type is to be checked.
        /// </param>
        /// <param name="types">
        /// (Required.) One or more <see cref="T:System.Type" />
        /// value(s) that are to be compared.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if at least one of the entry(ies) in the
        /// <paramref name="types" /> array matches the type of the specified
        /// <paramref name="exception" />; <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsAnyOf(
            this Exception exception,
            params Type[] types
        )
        {
            var result = false;

            try
            {
                if (exception == null) return result;
                if (types == null) return result;
                if (types.Length <= 0) return result;

                foreach (var type in types)
                {
                    if (type == null) continue;
                    if (exception.GetType() != type) continue;

                    result = true;
                    break;
                }
            }
            catch
            {
                //Ignored.

                result = false;
            }

            return result;
        }

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