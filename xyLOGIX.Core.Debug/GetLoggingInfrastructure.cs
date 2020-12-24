using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    ///     Creates instances of objects that implement the
    ///     <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface.
    /// </summary>
    public static class GetLoggingInfrastructure
    {
        /// <summary>
        ///     Creates an instance of an object implementing the
        ///     <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface which
        ///     corresponds to the value specified in <paramref name="type" />, and returns
        ///     a reference to it.
        /// </summary>
        /// <param name="type">
        ///     One of the
        ///     <see cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType" /> values that
        ///     describes what type of object you want.
        /// </param>
        /// <returns>
        ///     A reference to the instance of the object that implements the
        ///     <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface which
        ///     corresponds to the value specified in <paramref name="type" />.
        /// </returns>
        /// <remarks>
        ///     This method will throw an exception if there are no types implemented
        ///     that correspond to the value of <paramref name="type" />.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown if there is no
        ///     corresponding concrete type defined that implements the
        ///     <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface and
        ///     which
        ///     corresponds to the value passed in the <paramref name="type" /> parameter.
        /// </exception>
        public static ILoggingInfrastructure For(LoggingInfrastructureType type)
        {
            ILoggingInfrastructure result;

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
                        nameof(type), type, null
                    );
            }

            return result;
        }
    }
}