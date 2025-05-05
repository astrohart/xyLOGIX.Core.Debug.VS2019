using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfigurator" /> interface for the
    /// <see cref="F:xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile" />
    /// <c>Logging Configurator Type</c>.
    /// </summary>
    public static class GetFromConfigFileLoggingConfigurator
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed
        /// once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetFromConfigFileLoggingConfigurator" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetFromConfigFileLoggingConfigurator() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfigurator" /> interface, and returns
        /// a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfigurator" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile" />
        /// <c>Logging Configurator Type</c>.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        public static ILoggingConfigurator SoleInstance()
        {
            ILoggingConfigurator result;

            try
            {
                result = FromConfigFileLoggingConfigurator.Instance;
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