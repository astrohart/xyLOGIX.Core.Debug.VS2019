using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an object that
    /// validates the value(s) of the property(ies) of an instance of an object that
    /// implements the
    /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface
    /// for a specified <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" />.
    /// </summary>
    public interface IRollingFileAppenderConfigurationValidator
    {
        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" />
        /// enumeration value that identifies how this
        /// <c>Rolling File Appender Configuration Validator</c> operates.
        /// </summary>
        AppenderRetrievalMode Mode { [DebuggerStepThrough] get; }

        /// <summary>
        /// Validates the value(s) of the property(ies) of the specified
        /// <paramref name="config" />, given the current value of the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator.Mode" />
        /// property.
        /// </summary>
        /// <param name="config">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface
        /// that is to be validated.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the property(ies) of the particular
        /// <paramref name="config" /> instance have valid value(s).
        /// </returns>
        bool IsValid([NotLogged] IRollingFileAppenderConfiguration config);
    }
}