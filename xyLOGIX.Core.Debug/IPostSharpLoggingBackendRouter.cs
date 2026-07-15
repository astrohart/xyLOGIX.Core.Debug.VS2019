using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// object that manages the process-wide PostSharp logging backend used to route
    /// logging record(s) to specialized logging-client repository(ies).
    /// </summary>
    /// <remarks>
    /// Implementers preserve the ordinary logging repository as a fallback
    /// while routing logging record(s) associated with a specialized logging-client
    /// session to that session's dedicated repository.
    /// </remarks>
    internal interface IPostSharpLoggingBackendRouter
    {
        /// <summary>
        /// Gets a reference to the log4net repository that receives logging
        /// record(s) when no specialized logging-client session is active.
        /// </summary>
        ILoggerRepository FallbackRepository { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a value indicating whether the process-wide PostSharp logging
        /// router has been installed.
        /// </summary>
        bool IsInstalled { [DebuggerStepThrough] get; }

        /// <summary>
        /// Installs the process-wide PostSharp logging router, or updates its
        /// fallback repository if the router has already been installed.
        /// </summary>
        /// <param name="fallbackRepository">
        /// (Optional.) Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> that is to receive
        /// logging record(s) when no specialized logging-client session is active.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the router was successfully installed or
        /// updated; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// A <see langword="null" /> value for
        /// <paramref name="fallbackRepository" /> is permitted.
        /// <para />
        /// If no fallback repository is available, logging record(s) emitted outside a
        /// specialized session are not forwarded to another logging repository.
        /// </remarks>
        bool InstallOrUpdate([NotLogged] ILoggerRepository fallbackRepository);
    }
}