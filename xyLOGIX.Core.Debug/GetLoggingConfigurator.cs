using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains references to instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfigurator" /> interface that change
    /// depending on the strategy desired.
    /// </summary>
    public static class GetLoggingConfigurator
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetLoggingConfigurator" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLoggingConfigurator() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingConfiguratorTypeValidator
            LoggingConfiguratorTypeValidator
        { [DebuggerStepThrough] get; } =
            GetLoggingConfiguratorTypeValidator.SoleInstance();

        /// <summary>
        /// Obtains a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfigurator" /> interface which
        /// corresponds to the specified meeting <paramref name="type" />.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingConfiguratorType" /> enumeration values
        /// that describes the type of <c>Logging Configurator</c> that is to be used.
        /// </param>
        /// <returns>
        /// Reference to the instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingConfigurator" /> interface which
        /// corresponds to the specific enumeration value that is specified for the
        /// argument of the <paramref name="type" /> parameter.
        /// </returns>
        /// <remarks>
        /// If the specified <c>Logging Configurator</c> <paramref name="type" />
        /// is not supported, then this method returns a <see langword="null" /> reference.
        /// </remarks>
        [return: NotLogged]
        [DebuggerStepThrough]
        public static ILoggingConfigurator For(LoggingConfiguratorType type)
        {
            ILoggingConfigurator result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"*** GetLoggingConfigurator.OfType: Checking whether the specified Logging Configurator Type, '{type}', is within the defined value set..."
                );

                // Check to see whether the specified Logging Configurator Type is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!LoggingConfiguratorTypeValidator.IsValid(type))
                {
                    // The specified Logging Configurator Type is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The specified Logging Configurator Type, '{type}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetLoggingConfigurator.OfType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"GetLoggingConfigurator.OfType: *** SUCCESS *** The specified Logging Configurator Type, '{type}', is within the defined value set.  Proceeding..."
                );

                switch (type)
                {
                    case LoggingConfiguratorType.FromConfigFile:
                        System.Diagnostics.Debug.WriteLine(
                            "*** FYI *** Attempting to create a new instance of the 'FromConfigFile' Logging Configurator..."
                        );

                        result = GetFromConfigFileLoggingConfigurator
                            .SoleInstance();
                        break;

                    case LoggingConfiguratorType.Programmatic:
                        System.Diagnostics.Debug.WriteLine(
                            "*** FYI *** Attempting to create a new instance of the 'Programmatic' Logging Configurator..."
                        );

                        result =
                            GetProgrammaticLoggingConfigurator.SoleInstance();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(type), type,
                            $"The specified Logging Configurator Type, '{type}', is not supported."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to the Logging Configurator of type, '{type}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to the Logging Configurator of type, '{type}'.  Stopping..."
            );

            return result;
        }
    }
}