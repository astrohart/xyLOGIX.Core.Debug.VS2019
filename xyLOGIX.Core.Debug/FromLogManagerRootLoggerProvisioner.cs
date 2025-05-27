using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using Logger = log4net.Repository.Hierarchy.Logger;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// This concrete class simply executes the fallback provisioning strategy and
    /// attempts to return the value of such, ignoring any provided reference to a
    /// <c>Logging Repository</c>.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal class FromLogManagerRootLoggerProvisioner : RootLoggerProvisionerBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static FromLogManagerRootLoggerProvisioner() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected FromLogManagerRootLoggerProvisioner() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager" />
        /// root-logger provisioning strategy.
        /// </summary>
        internal static IRootLoggerProvisioner Instance
        {
            [DebuggerStepThrough] get;
        } = new FromLogManagerRootLoggerProvisioner();

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" />
        /// enumeration value that indicates the strategy used to provision the
        /// <c>Root Logger</c>.
        /// </summary>
        public override RootLoggerProvisioningStrategy Strategy
        {
            [DebuggerStepThrough] get;
        } = RootLoggerProvisioningStrategy.FromLogManager;

        /// <summary>
        /// Provisions the <c>Root Logger</c> for the application depending on the value of
        /// the <paramref name="loggerRepository" /> parameter.
        /// </summary>
        /// <remarks>
        /// If the provided <paramref name="loggerRepository" /> can be directly
        /// cast to <see cref="T:log4net.Repository.Hierarchy.Hierarchy" />, then this
        /// method returns a reference to an instance of
        /// <see cref="T:log4net.Repository.Hierarchy.Logger" /> that is at the root of
        /// such a <see cref="T:log4net.Repository.Hierarchy.Hierarchy" />.
        /// <para />
        /// If a <see langword="null" /> reference is passed for the value of the
        /// <paramref name="loggerRepository" /> parameter, then this method attempts to
        /// find the default appender configuration and attempts to then return a reference
        /// to that configuration's
        /// <see cref="T:log4net.Repository.Hierarchy.Logger" />.
        /// <para />
        /// If the first two attempts fail, then this method returns a
        /// <see langword="null" /> reference.
        /// <para />
        /// If this particular <c>Root Logger Provisioner</c> is configured to use the
        /// <see cref="F:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager" />
        /// strategy, then this method attempts to find the default appender
        /// configuration and attempts to then return a reference to that configuration's
        /// <see cref="T:log4net.Repository.Hierarchy.Logger" />.
        /// <para />
        /// Failing that, a <see langword="null" /> reference is returned.
        /// </remarks>
        /// <param name="loggerRepository"></param>
        /// <returns></returns>
        public override Logger Provision(
            ILoggerRepository loggerRepository = null
        )
        {
            Logger result = default;

            try
            {
                result = ExecuteFallbackProvisioning();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "FromLogManagerRootLoggerProvisioner.Provision: *** SUCCESS *** Obtained a reference to the Root Logger.  Proceeding..."
                    : "FromLogManagerRootLoggerProvisioner.Provision: *** ERROR *** FAILED to obtain a reference to the Root Logger.  Stopping..."
            );

            return result;
        }
    }
}