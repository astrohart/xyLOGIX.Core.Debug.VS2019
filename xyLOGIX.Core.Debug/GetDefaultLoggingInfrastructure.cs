using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface for the
    /// <see cref="F:xyLOGIX.Core.Debug.LoggingInfrastructureType.Default" /> logging
    /// infrastructure type value.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetDefaultLoggingInfrastructure
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface, and
        /// returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingInfrastructureType.Default" /> logging
        /// infrastructure type value.
        /// </returns>
        [DebuggerStepThrough]
        internal static ILoggingInfrastructure SoleInstance()
        {
            ILoggingInfrastructure result;

            try
            {
                result = DefaultLoggingInfrastructure.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}