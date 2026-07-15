using PostSharp.Patterns.Diagnostics;
using System;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// object that manages registered logging-client session object(s).
    /// </summary>
    internal interface ILoggingClientSessionRegistry
    {
        /// <summary>Gets the logging-client session associated with the specified ticket.</summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// identifies a registered logging-client session.
        /// </param>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSession" /> interface; otherwise,
        /// <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="ticket" /> equals
        /// <see cref="F:System.Guid.Empty" />, or no corresponding session exists, this
        /// method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        ILoggingClientSession Get([NotLogged] Guid ticket);

        /// <summary>
        /// Gets or creates the logging-client session associated with the
        /// specified ticket and assembly.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// identifies the registered logging-client assembly.
        /// </param>
        /// <param name="clientAssembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that requested logging services.
        /// </param>
        /// <returns>
        /// Reference to the existing or newly created instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSession" />
        /// interface; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If either argument is invalid, or session creation fails, this method
        /// returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        ILoggingClientSession GetOrCreate(
            [NotLogged] Guid ticket,
            [NotLogged] Assembly clientAssembly
        );
    }
}