using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="F:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager" />
    /// root-logger provisioning strategy.
    /// </summary>
    public static class GetFromLogManagerRootLoggerProvisioner
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed
        /// once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetFromLogManagerRootLoggerProvisioner" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetFromLogManagerRootLoggerProvisioner() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface, and
        /// returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="F:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager" />
        /// root-logger provisioning strategy.
        /// </returns>
        [DebuggerStepThrough]
        public static IRootLoggerProvisioner SoleInstance()
        {
            IRootLoggerProvisioner result;

            try
            {
                result = FromLogManagerRootLoggerProvisioner.Instance;
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