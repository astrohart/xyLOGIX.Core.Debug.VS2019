using log4net;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// object that provides log4net logger object(s) for the current logging-client
    /// session.
    /// </summary>
    /// <remarks>
    /// Implementers utilize the ordinary log4net repository when no
    /// specialized logging-client session is active.
    /// <para />
    /// If a valid specialized logging-client session is active, then implementers
    /// obtain logger object(s) exclusively from that session's repository.
    /// </remarks>
    internal interface ILoggingClientLogProvider
    {
        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface for the specified source type.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that identifies the source of the logging
        /// record(s).
        /// </param>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="sourceType" /> is <see langword="null" />, then
        /// this method returns <see langword="null" />.
        /// <para />
        /// If no specialized logging-client session is active, then this method obtains
        /// the logger from the ordinary log4net repository.
        /// <para />
        /// If a specialized session is active but its logger cannot be obtained, then this
        /// method returns <see langword="null" /> rather than falling back to a repository
        /// owned by another in-process software component.
        /// </remarks>
        [return: NotLogged]
        ILog Get([NotLogged] Type sourceType);
    }
}