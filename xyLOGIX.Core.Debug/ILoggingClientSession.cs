using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an object that
    /// represents the logging services assigned to a registered logging-client
    /// assembly.
    /// </summary>
    /// <remarks>
    /// Each logging-client session owns a dedicated
    /// <see cref="T:log4net.Repository.ILoggerRepository" /> and corresponding
    /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" />.
    /// </remarks>
    internal interface ILoggingClientSession
    {
        /// <summary>
        /// Gets a reference to an instance of
        /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" /> that writes
        /// PostSharp logging record(s) to the repository assigned to this session.
        /// </summary>
        LoggingBackend Backend { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to the
        /// <see cref="T:System.Reflection.Assembly" /> that requested this logging
        /// session.
        /// </summary>
        Assembly ClientAssembly { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> that is dedicated to
        /// this logging-client session.
        /// </summary>
        ILoggerRepository Repository { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the unique name assigned to
        /// the log4net repository for this logging-client session.
        /// </summary>
        string RepositoryName { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a <see cref="T:System.Guid" /> value that uniquely identifies this
        /// logging-client session.
        /// </summary>
        Guid Ticket { [DebuggerStepThrough] get; }

        /// <summary>
        /// Determines whether this logging-client session contains all required
        /// information and service reference(s).
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if this logging-client session is valid;
        /// otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method returns <see langword="false" /> if the
        /// <see cref="P:xyLOGIX.Core.Debug.ILoggingClientSession.Ticket" /> property is
        /// equal to <see cref="F:System.Guid.Empty" />, any required reference is
        /// <see langword="null" />, or the repository name is blank.
        /// </remarks>
        bool IsValid();
    }
}