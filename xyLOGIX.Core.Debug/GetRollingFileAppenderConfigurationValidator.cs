using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains references to instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator" />
    /// interface that change depending on the strategy desired.
    /// </summary>
    public static class GetRollingFileAppenderConfigurationValidator
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetRollingFileAppenderConfigurationValidator" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetRollingFileAppenderConfigurationValidator() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderRetrievalModeValidator" /> interface.
        /// </summary>
        private static IAppenderRetrievalModeValidator
            AppenderRetrievalModeValidator { [DebuggerStepThrough] get; } =
            GetAppenderRetrievalModeValidator.SoleInstance();

        /// <summary>
        /// Obtains a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator" />
        /// interface which corresponds to the specified meeting <paramref name="mode" />.
        /// </summary>
        /// <param name="mode">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration values
        /// that describes the particular appender-retrieval mode to use.
        /// </param>
        /// <returns>
        /// Reference to the instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator" />
        /// interface which corresponds to the specific enumeration value that is specified
        /// for the argument of the <paramref name="mode" /> parameter.
        /// </returns>
        /// <remarks>
        /// This method will throw an exception if there are no types implemented
        /// that correspond to the enumeration value passed for the argument of the
        /// <paramref name="mode" /> parameter.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if there is no
        /// corresponding concrete type defined that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator" />
        /// interface and which corresponds to the specific enumeration value that was
        /// passed for the argument of the <paramref name="mode" /> parameter, if it is not
        /// supported.
        /// </exception>
        public static IRollingFileAppenderConfigurationValidator For(
            AppenderRetrievalMode mode
        )
        {
            IRollingFileAppenderConfigurationValidator result = default;

            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** GetRollingFileAppenderConfigurationValidator.For: Checking whether the specified Appender Retrieval Mode is within the defined value set..."
                );

                // Check to see whether the specified Appender Retrieval Mode is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!AppenderRetrievalModeValidator.IsValid(mode))
                {
                    // The specified Appender Retrieval Mode is NOT within the defined value set.  This is not desirable.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** The specified Appender Retrieval Mode is NOT within the defined value set.  Stopping..."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"*** GetRollingFileAppenderConfigurationValidator.For: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "GetRollingFileAppenderConfigurationValidator.For: *** SUCCESS *** The specified Appender Retrieval Mode is within the defined value set.  Proceeding..."
                );

                switch (mode)
                {
                    case AppenderRetrievalMode.CreateNew:
                        result = CreateNewAppenderConfigurationValidator
                            .Instance;
                        break;

                    case AppenderRetrievalMode.ObtainExisting:
                        result = ObtainExistingAppenderConfigurationValidator
                            .Instance;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(mode), mode,
                            $"The specified Appender Retrieval Mode, '{mode}', is not supported."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
        }
    }
}