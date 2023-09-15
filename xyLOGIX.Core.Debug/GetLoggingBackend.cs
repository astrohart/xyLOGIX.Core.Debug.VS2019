using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains a reference to a new instance of the
    /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" /> that corresponds
    /// to the specified <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" />
    /// enumeration value.
    /// </summary>
    public static class GetLoggingBackend
    {
        /// <summary>
        /// Obtains a reference to a new instance of the
        /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" /> that corresponds
        /// to the specified logging backend <paramref name="type" /> and, if necessary,
        /// <paramref name="relay" />.
        /// </summary>
        /// <param name="type">
        /// (Required.) The
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingBackendType" /> enumeration value that
        /// explains which type of backend to get.
        /// </param>
        /// <param name="relay">
        /// (Optional.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// </param>
        /// <returns>
        /// Reference to a new instance of
        /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" /> that corresponds
        /// to the provided <paramref name="type" /> and/or <paramref name="relay" />
        /// values.
        /// </returns>
        public static LoggingBackend For(
            LoggingBackendType type,
            ILoggerRepository relay = null
        )
        {
            LoggingBackend result = default;

            if (type == LoggingBackendType.Log4Net && relay == null)
                throw new InvalidOperationException(
                    "A value must be passed for the 'relay' parameter when using the LoggingBackendType.Log4Net backend."
                );

            switch (type)
            {
                case LoggingBackendType.Console:
                    result = new ConsoleLoggingBackend();
                    break;

                case LoggingBackendType.Log4Net:
                    result = new Log4NetLoggingBackend(relay);
                    break;
            }

            return result;
        }
    }
}