using log4net.Config;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// A <c>XML Logging Configurator</c> that relies on a particular <c>.config</c>
    /// file to contain the logging setting(s).
    /// </summary>
    internal class NoFileXmlLoggingConfigurator : XmlLoggingConfiguratorBase
    {
        /// <summary>
        /// Empty, <see langword="static" /> constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static NoFileXmlLoggingConfigurator() { }

        /// <summary>
        /// Empty, <see langword="private" /> constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        private NoFileXmlLoggingConfigurator()
        { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfigurator" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile" />
        /// <c>XML Logging Configurator Type</c>.
        /// </summary>
        internal static IXmlLoggingConfigurator Instance
        {
            [DebuggerStepThrough]
            get;
        } = new NoFileXmlLoggingConfigurator();

        /// <summary>
        /// Gets or sets one of the
        /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> enumeration
        /// values that specifies how the logging subsystem is to be configured.
        /// </summary>
        public override XmlLoggingConfiguratorType Type
        {
            [DebuggerStepThrough]
            get;
        } = XmlLoggingConfiguratorType.NoFile;

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
                System.Diagnostics.Debug.WriteLine(
                    $"NoFileXmlLoggingConfigurator.Configure: Checking whether the configuration file, '{configurationFileName}', is, indeed, non-existent..."
                );

                // Check to see whether the configuration file is, indeed, non-existent.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!string.IsNullOrEmpty(configurationFileName) &&
                    File.Exists(configurationFileName))
                {
                    // The configuration file exists on the file system.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The configuration file, '{configurationFileName}', exists on the file system.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"NoFileXmlLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"NoFileXmlLoggingConfigurator.Configure: *** SUCCESS *** The configuration file, '{configurationFileName}', is, indeed, non-existent.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"NoFileXmlLoggingConfigurator.Configure: Checking whether the file having the path, '{configurationFileName}', cannot be found on the file system..."
                );

                // If the file specified by the configurationFileName does
                // not actually exist, the author of this software needs to know
                // about it, so throw a FileNotFoundException
                if (!string.IsNullOrWhiteSpace(
                        configurationFileName
                    ) // only do this check for a non-blank file name.
                    && !File.Exists(configurationFileName))
                    throw new FileNotFoundException(
                        $"NoFileXmlLoggingConfigurator.Configure: *** ERROR *** The file '{configurationFileName}' was not found.\n\nThe application needs this file in order to continue."
                    );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Either the path, '{configurationFileName}', does not exist, or the path is blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    repository != null
                        ? "*** FYI *** The Logger Repository parameter has been passed a valid object reference for its value.  Proceeding..."
                        : "*** FYI *** The Logger Repository parameter has NOT been passed a valid object reference for its value.  Proceeding..."
                );

                /*
                 * If we have no configuration file to work with, try to
                 * set up logging with the passed ILoggerRepository.
                 */

                ICollection loggers = default;

                if (repository == null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** The Logger Repository parameter is null.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Attempting to call XmlConfigurator.Configure() with no parameters..."
                    );

                    loggers = XmlConfigurator.Configure();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** The Logger Repository parameter is NOT null.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Attempting to call XmlConfigurator.Configure() with the passed ILoggerRepository parameter..."
                    );

                    loggers = XmlConfigurator.Configure(repository);
                }

                System.Diagnostics.Debug.WriteLine(
                    "NoFileXmlLoggingConfigurator.Configure: Checking whether the variable, 'loggers', has a null reference for a value..."
                );

                // Check to see if the variable, 'loggers', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (loggers == null)
                {
                    // The variable, 'loggers', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "NoFileXmlLoggingConfigurator.Configure: *** ERROR ***  The variable, 'loggers', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** NoFileXmlLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'loggers', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "NoFileXmlLoggingConfigurator.Configure: *** SUCCESS *** The variable, 'loggers', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** NoFileXmlLoggingConfigurator.Configure: Checking whether the 'loggers' collection contains greater than zero elements..."
                );

                // Check to see whether the 'loggers' collection contains greater than
                // zero elements.  Otherwise, write an error message to the Debug output, return
                // the default return value, and then terminate the execution of this method.
                if (loggers.Count <= 0)
                {
                    // The 'loggers' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'loggers' collection contains zero elements.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"NoFileXmlLoggingConfigurator.Configure: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"NoFileXmlLoggingConfigurator.Configure: *** SUCCESS *** {loggers.Count} element(s) were found in the 'loggers' collection.  Proceeding..."
                );

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
                $"NoFileXmlLoggingConfigurator.Configure: Result = {result}"
            );

            return result;
        }
    }
}