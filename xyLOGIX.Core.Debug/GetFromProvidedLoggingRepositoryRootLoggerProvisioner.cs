using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface for the
    /// <see
    ///     cref="F:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromProvidedLoggingRepository" />
    /// root-logger provisioning strategy.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetFromProvidedLoggingRepositoryRootLoggerProvisioner
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface, and
        /// returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface for the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromProvidedLoggingRepository" />
        /// root-logger provisioning strategy.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static IRootLoggerProvisioner SoleInstance()
        {
            IRootLoggerProvisioner result;

            try
            {
                result = FromProvidedLoggingRepositoryRootLoggerProvisioner.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}