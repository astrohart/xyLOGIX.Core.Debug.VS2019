using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains references to instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface that change
    /// depending
    /// on the strategy desired.
    /// </summary>
    public static class GetOutputLocation
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetOutputLocation" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetOutputLocation() { }

        /// <summary>
        /// Obtains a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface which corresponds
        /// to
        /// the specified meeting <paramref name="type" />.
        /// </summary>
        /// <param name="type">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.OutputLocationType" /> enumeration
        /// values
        /// that describes the type of output location to be created.
        /// </param>
        /// <returns>
        /// Reference to the instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface which corresponds
        /// to
        /// the specific enumeration value that is specified for the argument of the
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
        /// corresponds
        /// to the specific enumeration value that was passed for the argument of the
        /// <paramref name="type" /> parameter, if it is not supported.
        /// </exception>
        [DebuggerStepThrough]
        public static IOutputLocation OfType(OutputLocationType type)
        {
            IOutputLocation result = default;

            if (!Enum.IsDefined(typeof(OutputLocationType), type))
                return result;
            if (OutputLocationType.Unknown.Equals(type)) return result;

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