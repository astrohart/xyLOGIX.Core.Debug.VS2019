using log4net.Repository;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// object that uniquely identifies a logger within a particular log4net
    /// repository.
    /// </summary>
    /// <remarks>
    /// Implementers identify a logger by combining the object identity of its
    /// repository with its ordinal logger name.
    /// <para />
    /// Two cache-key object(s) that refer to the same repository instance and contain
    /// the same logger name represent the same logical cache entry.
    /// </remarks>
    internal interface ILoggingClientLoggerCacheKey : IEquatable<ILoggingClientLoggerCacheKey>
    {
        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the name of the
        /// logger within the repository identified by the
        /// <see cref="P:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.Repository" />
        /// property.
        /// </summary>
        string LoggerName { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface that contains
        /// the logger identified by the
        /// <see cref="P:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.LoggerName" />
        /// property.
        /// </summary>
        ILoggerRepository Repository { [DebuggerStepThrough] get; }
    }
}