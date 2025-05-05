using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains a reference to a new instance of the
    /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" /> that corresponds
    /// to the specified
    /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingBackendType" />
    /// enumeration value.
    /// </summary>
    public static class GetLoggingBackend
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetLoggingBackend" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLoggingBackend() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingBackendTypeValidator" /> interface.
        /// </summary>
        private static ILoggingBackendTypeValidator LoggingBackendTypeValidator
        {
            [DebuggerStepThrough] get;
        } = GetLoggingBackendTypeValidator.SoleInstance();

        /// <summary>
        /// Obtains a reference to a new instance of the
        /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" /> that corresponds
        /// to the specified logging backend <paramref name="type" /> and, if necessary,
        /// <paramref name="relay" />.
        /// </summary>
        /// <param name="type">
        /// (Required.) The
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingBackendType" /> enumeration
        /// value
        /// that explains which type of backend to get.
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
            [NotLogged] ILoggerRepository relay = null
        )
        {
            LoggingBackend result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "GetLoggingBackend.For: Checking whether the type of logging backend requested is within the defined value set..."
                );

                // Check to see whether the type of logging backend requested is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!LoggingBackendTypeValidator.IsValid(type))
                {
                    // The type of logging backend requested is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The type of logging backend requested is NOT within the defined value set.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "GetLoggingBackend.For: *** SUCCESS *** The type of logging backend requested is within the defined value set.  Proceeding..."
                );

                /*
                 * If log4net is the requested backend, the 'relay'
                 * parameter must be non-NULL.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "GetLoggingBackend.For: Checking whether the log4net backend is requested, but a null reference has been passed for the 'relay' parameter..."
                );

                // Check to see whether the log4net backend is requested, but a null reference has been passed for the 'relay' parameter.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (type == LoggingBackendType.Log4Net && relay == null)
                {
                    // The log4net backend is requested, but a  null reference has been passed for the value of the 'relay' parameter.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The log4net backend is requested, but a null reference has been passed for the value of the 'relay' parameter.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "GetLoggingBackend.For: *** SUCCESS *** Either log4net backend is NOT requested, OR it is, AND a valid object reference has been passed for the 'relay' parameter.  Proceeding..."
                );

                switch (type)
                {
                    case LoggingBackendType.Console:
                        result = MakeNewConsoleLoggingBackend.FromScratch();
                        break;
                    case LoggingBackendType.Log4Net:
                        result = MakeNewLog4NetLoggingBackend.ForRelay(relay);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(type), type,
                            $"The requested type of logging backend, '{type}', is not supported at this time."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to the desired logging backend, which is of type, '{type}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to a '{type}' logging backend.  Stopping..."
            );

            return result;
        }
    }
}