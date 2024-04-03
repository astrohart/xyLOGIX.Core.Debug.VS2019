using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Creates instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface.
    /// </summary>
    public static class GetLoggingInfrastructure
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetLoggingInfrastructure" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetLoggingInfrastructure() { }

        /// <summary>
        /// Creates an instance of an object implementing the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface which
        /// corresponds to the value specified in <paramref name="type" />, and returns a
        /// reference to it.
        /// </summary>
        /// <param name="type">
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> values
        /// that
        /// describes what type of object you want.
        /// </param>
        /// <returns>
        /// A reference to the instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface which
        /// corresponds to the value specified in <paramref name="type" />.
        /// </returns>
        /// <remarks>
        /// This method will throw an exception if there are no types implemented
        /// that correspond to the value of <paramref name="type" />.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if there is no
        /// corresponding concrete type defined that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface and which
        /// corresponds to the value passed in the <paramref name="type" /> parameter.
        /// </exception>
        public static ILoggingInfrastructure For(LoggingInfrastructureType type)
        {
            ILoggingInfrastructure result = default;

            try
            {
                if (!Validate.LoggingInfrastructureType(type))
                    return result;

                switch (type)
                {
                    case LoggingInfrastructureType.Default:
                        result = new DefaultLoggingInfrastructure();
                        break;

                    case LoggingInfrastructureType.PostSharp:
                        result = new PostSharpLoggingInfrastructure();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(type), type,
                            $"A Logging Infrastructure object is not implemented for the infrastructure type, '{type}'."
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