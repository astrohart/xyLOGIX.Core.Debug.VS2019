using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// object that manages the logging-client assembly ticket that is associated with
    /// the current logical execution flow.
    /// </summary>
    /// <remarks>
    /// Implementers maintain the current logging-client ticket independently
    /// for each logical execution flow.
    /// <para />
    /// A ticket value of <see cref="F:System.Guid.Empty" /> indicates that no
    /// logging-client assembly is currently selected.
    /// </remarks>
    internal interface ILoggingClientAssemblyContext
    {
        /// <summary>
        /// Gets the ticket that identifies the logging-client assembly associated
        /// with the current logical execution flow.
        /// </summary>
        /// <remarks>
        /// If no logging-client assembly is currently selected, then this
        /// property returns <see cref="F:System.Guid.Empty" />.
        /// </remarks>
        Guid CurrentTicket { [DebuggerStepThrough] get; }

        /// <summary>
        /// Clears the logging-client assembly ticket associated with the current
        /// logical execution flow.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the current ticket was successfully
        /// cleared; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method assigns <see cref="F:System.Guid.Empty" /> to the current
        /// ticket.
        /// <para />
        /// If the operation fails, then the exception information is written to the Debug
        /// output and this method returns <see langword="false" />.
        /// </remarks>
        bool Clear();

        /// <summary>
        /// Selects the logging-client assembly associated with the specified
        /// ticket for the current logical execution flow.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// identifies a registered logging-client assembly.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the specified ticket was successfully
        /// selected; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="ticket" /> is equal to
        /// <see cref="F:System.Guid.Empty" />, then this method returns
        /// <see langword="false" /> without changing the current ticket.
        /// <para />
        /// If the operation fails, then the exception information is written to the Debug
        /// output and this method returns <see langword="false" />.
        /// </remarks>
        bool Select([NotLogged] Guid ticket);
    }
}