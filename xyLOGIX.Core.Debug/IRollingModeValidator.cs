using log4net.Appender;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of a validator of
    /// <see cref="T:log4net.Appender.RollingFileAppender.RollingMode" /> enumeration
    /// values.
    /// </summary>
    /// <remarks>
    /// Specifically, objects that implement this interface ascertain whether
    /// the values of variables fall within the value set that is defined by the
    /// <see cref="T:log4net.Appender.RollingFileAppender.RollingMode" /> enumeration.
    /// </remarks>
    public interface IRollingModeValidator
    {
        /// <summary>
        /// Determines whether the rolling <paramref name="mode" /> value passed
        /// is within the value set that is defined by the
        /// <see cref="T:log4net.Appender.RollingFileAppender.RollingMode" /> enumeration.
        /// </summary>
        /// <param name="mode">
        /// (Required.) One of the
        /// <see cref="T:log4net.Appender.RollingFileAppender.RollingMode" /> value(s) that
        /// is to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the rolling <paramref name="mode" /> falls
        /// within the defined value set; <see langword="false" /> otherwise.
        /// </returns>
        bool IsValid(RollingFileAppender.RollingMode mode);
    }
}