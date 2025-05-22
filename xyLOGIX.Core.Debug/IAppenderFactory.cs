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
    public interface IAppenderFactory
    {
        /// <summary>
        /// Gets or sets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration values.
        /// </summary>
        AppenderRetrievalMode Mode { [DebuggerStepThrough] get; }
    }
}