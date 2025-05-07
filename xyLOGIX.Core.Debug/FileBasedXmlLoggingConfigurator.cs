using Alphaleonis.Win32.Filesystem;
using log4net.Config;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using FileInfo = System.IO.FileInfo;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// A <c>XML Logging Configurator</c> that relies on a particular <c>.config</c>
    /// file to contain the logging setting(s).
    /// </summary>
    public class FileBasedXmlLoggingConfigurator : XmlLoggingConfiguratorBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static FileBasedXmlLoggingConfigurator() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected FileBasedXmlLoggingConfigurator()
        { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfigurator" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased" />
        /// <c>XML Logging Configurator Type</c>.
        /// </summary>
        public static IXmlLoggingConfigurator Instance
        {
            [DebuggerStepThrough]
            get;
        } = new FileBasedXmlLoggingConfigurator();

        /// <summary>
        /// Gets or sets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> enumeration
        /// values that specifies how the logging subsystem is to be configured.
        /// </summary>
        public override XmlLoggingConfiguratorType Type
        {
            [DebuggerStepThrough]
            get;
        } = XmlLoggingConfiguratorType.FileBased;

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
        public override bool Configure(
            ILoggerRepository repository,
            string configurationFileName = ""
        )
        {
            var result = false;

            try
            {
                /*
                 * This method should only execute if: (a) the value of the
                 * 'configurationFileName' parameter is non-blank, AND, (b)
                 * it contains the fully-qualified pathname of a file that
                 * exists AND (c) has an extension of .config.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "FileBasedXmlLoggingConfigurator.Configure: Checking whether the value of the required method parameter, 'configurationFileName' parameter is null or consists solely of whitespace..."
                );

                // Check whether the value of the parameter, 'configurationFileName', is blank.
                // If this is so, then emit an error message to the Debug output, and then
                // terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(configurationFileName))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "FileBasedXmlLoggingConfigurator.Configure: *** ERROR *** Null or blank value passed for the parameter, 'configurationFileName'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"FileBasedXmlLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "FileBasedXmlLoggingConfigurator.Configure: *** SUCCESS *** The value of the required parameter, 'configurationFileName', is not blank.  Continuing..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"FileBasedXmlLoggingConfigurator.Configure *** INFO: Checking whether the file having pathname, '{configurationFileName}', exists on the file system..."
                );

                // Check whether a file having pathname, 'configurationFileName', exists on the file system.
                // If it does not, then write an error message to the Debug output, and then terminate
                // the execution of this method.
                if (!File.Exists(configurationFileName))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The system could not locate the file having pathname, '{configurationFileName}', on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"FileBasedXmlLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"FileBasedXmlLoggingConfigurator.Configure *** SUCCESS *** The file having pathname, '{configurationFileName}', was found on the file system.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FileBasedXmlLoggingConfigurator.Configure: Checking whether the specified file has an extension of '.config'..."
                );

                // Check to see whether the specified file has an extension of '.config'.
                // If this is not the case, then write an error message to the Debug output
                // and then terminate the execution of this method.
                if (!".config".Equals(
                        Path.GetExtension(configurationFileName),
                        StringComparison.OrdinalIgnoreCase
                    ))
                {
                    // The specified file does NOT have an extension of '.config'.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The specified file does NOT have an extension of '.config'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"FileBasedXmlLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "FileBasedXmlLoggingConfigurator.Configure: *** SUCCESS *** The specified file has an extension of '.config'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Not only is the 'configurationFileName' parameter's argument not the blank string, but the file that it references has been found on the filesystem."
                );

                /*
                 * Initialize log4net and use both the configuration
                 * file pathname passed, and, if it's not null, the ILoggerRepository
                 * reference that was passed to this method, too.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to configure the logging subsystem utilizing the setting(s) present in the '{configurationFileName}' file..."
                );

                var configurationFileInfo = new FileInfo(configurationFileName);

                if (repository == null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Attempting to call XmlConfigurator.Configure() with no Logger Repository..."
                    );

                    XmlConfigurator.Configure(configurationFileInfo);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Attempting to call XmlConfigurator.Configure() with the passed ILoggerRepository parameter..."
                    );

                    XmlConfigurator.Configure(
                        repository, configurationFileInfo
                    );
                }

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"FileBasedXmlLoggingConfigurator.Configure: Result = {result}"
            );

            return result;
        }
    }
}