using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Obtains references to instances of objects that implement the <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface that change depending on the strategy desired.</summary>
    public static class GetAppenderRetriever
    {

        /// <summary>Obtains a reference to an instance of an object that implements the <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface which corresponds to the specified meeting <paramref name="mode" />.</summary>
        /// <param name="mode"> (Required.) One of the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration values that describes the desired appender retrieval mode.</param>
        /// <returns>Reference to the instance of the object that implements the <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface which corresponds to the specific enumeration value that is specified for the argument of the <paramref name="mode" /> parameter.</returns>
        /// <remarks>This method will throw an exception if there are no types implemented that correspond to the enumeration value passed for the argument of the <paramref name="mode" /> parameter.</remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if there is no corresponding concrete type defined that implements the <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface and which corresponds to the specific enumeration value that was passed for the argument of the <paramref name="mode" /> parameter, if it is not supported.</exception>
        public static xyLOGIX.Core.Debug.IAppenderRetriever For(xyLOGIX.Core.Debug.AppenderRetrievalMode mode)
        {
            xyLOGIX.Core.Debug.IAppenderRetriever result;

            switch (mode)
            {
                case AppenderRetrievalMode.CreateNew:
                    result = GetCreateNewAppenderRetriever.SoleInstance();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(mode), mode, $"The specified Appender Retrieval Mode, '{mode}', is not supported."
                    );
            }

            return result;
        }
    }
}