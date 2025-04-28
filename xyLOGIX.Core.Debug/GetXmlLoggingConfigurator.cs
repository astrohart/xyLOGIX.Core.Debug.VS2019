using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains references to instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfigurator" /> interface that
    /// change depending on the strategy desired.
    /// </summary>
    public static class GetXmlLoggingConfigurator
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetXmlLoggingConfigurator" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetXmlLoggingConfigurator() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator" />
        /// interface.
        /// </summary>
        private static IXmlLoggingConfiguratorTypeValidator
            XmlLoggingConfiguratorTypeValidator { [DebuggerStepThrough] get; } =
            GetXmlLoggingConfiguratorTypeValidator.SoleInstance();

        /// <summary>
        /// Obtains a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfigurator" /> interface which
        /// corresponds to the specified meeting <paramref name="type" />.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.XmlLoggingConfiguratorType" /> enumeration
        /// values that describes the type of <c>XML Logging Configurator</c> object that
        /// is to be utilized to configure the logging subsystem.
        /// </param>
        /// <returns>
        /// Reference to the instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfigurator" /> interface which
        /// corresponds to the specific enumeration value that is specified for the
        /// argument of the <paramref name="type" /> parameter.
        /// </returns>
        /// <remarks>
        /// This method will throw an exception if there are no types implemented
        /// that correspond to the enumeration value passed for the argument of the
        /// <paramref name="type" /> parameter.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if there is no
        /// corresponding concrete type defined that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IXmlLoggingConfigurator" /> interface and which
        /// corresponds to the specific enumeration value that was passed for the argument
        /// of the <paramref name="type" /> parameter, if it is not supported.
        /// </exception>
        [return: NotLogged]
        [DebuggerStepThrough]
        public static IXmlLoggingConfigurator For(
            XmlLoggingConfiguratorType type
        )
        {
            IXmlLoggingConfigurator result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"GetXmlLoggingConfigurator.For: Checking whether the XML Configurator Type, '{type}', is within the defined value set..."
                );

                // Check to see whether the XML Configurator Type is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (XmlLoggingConfiguratorTypeValidator.IsValid(type))
                {
                    // The XML Configurator Type is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The XML Configurator Type, '{type}', is NOT within the defined value set.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"GetXmlLoggingConfigurator.For: *** SUCCESS *** The XML Configurator Type, '{type}', is within the defined value set.  Proceeding..."
                );

                switch (type)
                {
                    case XmlLoggingConfiguratorType.FileBased:
                        result =
                            GetFileBasedXmlLoggingConfigurator.SoleInstance();
                        break;
                    case XmlLoggingConfiguratorType.NoFile:
                        result = GetNoFileXmlLoggingConfigurator.SoleInstance();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(type), type,
                            $"*** ERROR *** The specified XML Logging Configurator Type, '{type}', is not supported.  Stopping..."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}