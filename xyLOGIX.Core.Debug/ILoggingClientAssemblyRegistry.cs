using PostSharp.Patterns.Diagnostics;
using System;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// object that manages the registration of logging-client assembly(ies).
    /// </summary>
    /// <remarks>
    /// Implementers associate each registered
    /// <see cref="T:System.Reflection.Assembly" /> with a unique
    /// <see cref="T:System.Guid" /> ticket.
    /// <para />
    /// Re-registering the same <see cref="T:System.Reflection.Assembly" /> returns the
    /// ticket that was assigned during its original registration.
    /// </remarks>
    internal interface ILoggingClientAssemblyRegistry
    {
        /// <summary>
        /// Gets the assembly that is associated with the specified logging-client
        /// ticket.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// identifies a registered logging-client assembly.
        /// </param>
        /// <returns>
        /// Reference to the registered
        /// <see cref="T:System.Reflection.Assembly" /> associated with the specified
        /// ticket; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="ticket" /> is equal to
        /// <see cref="F:System.Guid.Empty" />, or no assembly is associated with it, then
        /// this method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        Assembly GetAssembly([NotLogged] Guid ticket);

        /// <summary>Gets the logging-client ticket associated with the specified assembly.</summary>
        /// <param name="assembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> whose ticket is to be obtained.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Guid" /> value that identifies the specified
        /// assembly; otherwise, <see cref="F:System.Guid.Empty" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="assembly" /> is <see langword="null" />, or has not
        /// been registered, then this method returns <see cref="F:System.Guid.Empty" />.
        /// </remarks>
        [return: NotLogged]
        Guid GetTicket([NotLogged] Assembly assembly);

        /// <summary>Registers the specified logging-client assembly.</summary>
        /// <param name="assembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that is requesting logging
        /// services.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Guid" /> value that uniquely identifies the
        /// registered assembly; otherwise, <see cref="F:System.Guid.Empty" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="assembly" /> is <see langword="null" />, then this
        /// method returns <see cref="F:System.Guid.Empty" />.
        /// <para />
        /// If the assembly has already been registered, then its existing ticket is
        /// returned.
        /// </remarks>
        [return: NotLogged]
        Guid Register([NotLogged] Assembly assembly);
    }
}