using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains references to instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface that change
    /// depending on the strategy desired.
    /// </summary>
    [Log(AttributeExclude = true)]
    public static class GetOutputLocation
    {
        /// <summary>
        /// Obtains a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface which corresponds
        /// to the specified meeting <paramref name="type" />.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.OutputLocationType" /> enumeration values that
        /// describes the type of output location to be created.
        /// </param>
        /// <returns>
        /// Reference to the instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface which corresponds
        /// to the specific enumeration value that is specified for the argument of the
        /// <paramref name="type" /> parameter.
        /// </returns>
        /// <remarks>
        /// This method will throw an exception if there are no types implemented
        /// that correspond to the enumeration value passed for the argument of the
        /// <paramref name="type" /> parameter.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if there is no
        /// corresponding concrete type defined that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface and which
        /// corresponds to the specific enumeration value that was passed for the argument
        /// of the <paramref name="type" /> parameter, if it is not supported.
        /// </exception>
        public static IOutputLocation OfType(OutputLocationType type)
        {
            IOutputLocation result;

            switch (type)
            {
                case OutputLocationType.Console:
                    result = GetConsoleOutputLocation.SoleInstance();
                    break;

                case OutputLocationType.Debug:
                    result = GetDebugOutputLocation.SoleInstance();
                    break;

                case OutputLocationType.Trace:
                    result = GetTraceOutputLocation.SoleInstance();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(type), type,
                        $"The output location, '{type}', is not supported."
                    );
            }

            return result;
        }
    }
}