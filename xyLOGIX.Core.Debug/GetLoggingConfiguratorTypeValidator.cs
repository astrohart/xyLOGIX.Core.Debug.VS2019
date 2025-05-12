using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator" />
    /// interface.
    /// </summary>
    public static class GetLoggingConfiguratorTypeValidator
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed
        /// once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetLoggingConfiguratorTypeValidator" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLoggingConfiguratorTypeValidator() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator" />
        /// interface, and returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator" />
        /// interface.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        public static ILoggingConfiguratorTypeValidator SoleInstance()
        {
            ILoggingConfiguratorTypeValidator result;

            try
            {
                result = LoggingConfiguratorTypeValidator.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}