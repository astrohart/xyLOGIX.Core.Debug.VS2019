using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Creates instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface.
    /// </summary>
    internal static class GetLoggingInfrastructure
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
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static ILoggingInfrastructure OfType(
            LoggingInfrastructureType type
        )
        {
            ILoggingInfrastructure result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** GetLoggingInfrastructure.OfType: Checking whether the Logging Infrastructure Type value specified is valid..."
                );

                // Check to see whether the Logging Infrastructure Type value specified is valid.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (!Validate.LoggingInfrastructureType(type))
                {
                    // The Logging Infrastructure Type value specified is NOT valid.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The Logging Infrastructure Type value specified is NOT valid.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** GetLoggingInfrastructure.OfType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "GetLoggingInfrastructure.OfType: *** SUCCESS *** The Logging Infrastructure Type value specified is valid.  Proceeding..."
                );

                switch (type)
                {
                    case LoggingInfrastructureType.Default:
                        result = GetDefaultLoggingInfrastructure.SoleInstance();
                        break;

                    case LoggingInfrastructureType.PostSharp:
                        result =
                            GetPostSharpLoggingInfrastructure.SoleInstance();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(type), type,
                            $"GetLoggingInfrastructure.OfType: A Logging Infrastructure object is not implemented for the infrastructure type, '{type}'."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"GetLoggingInfrastructure.OfType: *** SUCCESS *** Obtained a reference to the logging infrastructure object of type, '{type}'..  Proceeding..."
                    : $"GetLoggingInfrastructure.OfType: *** ERROR *** FAILED to obtain a reference to the logging infrastructure object of type, '{type}'..  Stopping..."
            );

            return result;
        }
    }
}