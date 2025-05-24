using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains references to instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface that change
    /// depending on the strategy desired.
    /// </summary>
    public static class GetAppenderRetriever
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetAppenderRetriever" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetAppenderRetriever() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderRetrievalModeValidator" /> interface.
        /// </summary>
        private static IAppenderRetrievalModeValidator
            AppenderRetrievalModeValidator
        { [DebuggerStepThrough] get; } =
            GetAppenderRetrievalModeValidator.SoleInstance();

        /// <summary>
        /// Obtains a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface which
        /// corresponds to the specified meeting <paramref name="mode" />.
        /// </summary>
        /// <param name="mode">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration values
        /// that describes the desired appender retrieval mode.
        /// </param>
        /// <returns>
        /// Reference to the instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface which
        /// corresponds to the specific enumeration value that is specified for the
        /// argument of the <paramref name="mode" /> parameter.
        /// </returns>
        /// <remarks>
        /// This method will throw an exception if there are no types implemented
        /// that correspond to the enumeration value passed for the argument of the
        /// <paramref name="mode" /> parameter.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if there is no
        /// corresponding concrete type defined that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface and which
        /// corresponds to the specific enumeration value that was passed for the argument
        /// of the <paramref name="mode" /> parameter, if it is not supported.
        /// </exception>
        [DebuggerStepThrough]
        [return: NotLogged]
        public static IAppenderRetriever For(AppenderRetrievalMode mode)
        {
            IAppenderRetriever result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"GetAppenderRetriever.For: Checking whether the Appender Retrieval Mode, '{mode}', is within the defined value set..."
                );

                // Check to see whether the specified Appender Retrieval Mode is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!AppenderRetrievalModeValidator.IsValid(mode))
                {
                    // The specified Appender Retrieval Mode is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"GetAppenderRetriever.For: *** ERROR *** The Appender Retrieval Mode, '{mode}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetAppenderRetriever.For: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"GetAppenderRetriever.For: *** SUCCESS *** The Appender Retrieval Mode, '{mode}', is within the defined value set.  Proceeding..."
                );

                switch (mode)
                {
                    case AppenderRetrievalMode.CreateNew:
                        result = GetCreateNewAppenderRetriever.SoleInstance();
                        break;

                    case AppenderRetrievalMode.ObtainExisting:
                        result =
                            GetObtainExistingAppenderRetriever.SoleInstance();
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