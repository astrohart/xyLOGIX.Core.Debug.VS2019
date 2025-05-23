using log4net.Appender;
using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Interface for factories that create or retrieve <c>Appender</c> objects.
    /// </summary>
    /// <remarks>
    /// This interface is used to define the contract for any class that is responsible
    /// for creating or retrieving <c>Appender</c>(s) for the purpose of routing log
    /// messages to a specific destination(s).
    /// </remarks>
    public interface IAppenderRetriever
    {
        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration
        /// value that identifies how this <c>Appender Factory</c> operates.
        /// </summary>
        AppenderRetrievalMode Mode { [DebuggerStepThrough] get; }

        /// <summary>
        /// Given the specified <paramref name="config" />, creates or retrieves an
        /// <c>Appender</c> associated with the specified settings.
        /// </summary>
        /// <param name="config">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" />
        /// interface.
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:log4net.Appender.IAppender" /> interface; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        IAppender GetAppender(
            [NotLogged] IRollingFileAppenderConfiguration config
        );
    }
}