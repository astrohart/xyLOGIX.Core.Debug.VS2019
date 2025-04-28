using log4net.Repository;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all
    /// <c>XML Logging Configurator</c>s.
    /// </summary>
    public abstract class XmlLoggingConfiguratorBase : IXmlLoggingConfigurator
    {
        /// <summary>
        /// Gets or sets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> enumeration
        /// values that specifies how the logging subsystem is to be configured.
        /// </summary>
        public abstract XmlLoggingConfiguratorType Type
        {
            [DebuggerStepThrough] get;
        }

        /// <summary>
        /// Attempts to configure the logging subsystem, optionally with the settings that
        /// are present in the configuration file having the specified
        /// <paramref name="configurationFileName" />.
        /// </summary>
        /// <param name="repository">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// </param>
        /// <param name="configurationFileName">
        /// (Optional.) A <see cref="T:System.String" /> containing
        /// the fully-qualified configurationFileName of the XML-formatted configuration
        /// file containing
        /// the necessary logging setting(s).
        /// <para />
        /// The default value of this parameter is the <see cref="F:System.String.Empty" />
        /// value.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the configuration operation(s) succeeded;
        /// <see langword="false" /> otherwise.
        /// </returns>
        /// <remarks>
        /// The value of the <paramref name="configurationFileName" /> parameter is ignored
        /// if
        /// this is a <c>XML Logging Configurator</c> object of type
        /// <see cref="F:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile" />.
        /// <para />
        /// Otherwise, if this <c>XML Logging Configurator</c> is of type,
        /// <see cref="F:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased" />, then
        /// the <paramref name="configurationFileName" /> had better contain the
        /// fully-qualified
        /// configurationFileName of a <c>.config</c> file containing the logging settings,
        /// or else this
        /// method will fail.
        /// </remarks>
        public abstract bool Configure(
            ILoggerRepository repository,
            string configurationFileName = ""
        );
    }
}