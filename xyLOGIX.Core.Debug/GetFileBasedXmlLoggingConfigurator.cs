using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="F:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased" />
    /// <c>XML Logging Configurator Type</c>.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetFileBasedXmlLoggingConfigurator
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfigurator" /> interface, and
        /// returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="F:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased" />
        /// <c>XML Logging Configurator Type</c>.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static IXmlLoggingConfigurator SoleInstance()
        {
            IXmlLoggingConfigurator result;

            try
            {
                result = FileBasedXmlLoggingConfigurator.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}