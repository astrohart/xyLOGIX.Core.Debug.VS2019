using log4net.Repository;
using log4net.Repository.Hierarchy;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provisions the <c>Root Logger</c> for the application depending on the
    /// determined <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" />.
    /// </summary>
    public interface IRootLoggerProvisioner
    {
        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" />
        /// enumeration value that indicates the strategy used to provision the
        /// <c>Root Logger</c>.
        /// </summary>
        RootLoggerProvisioningStrategy Strategy { [DebuggerStepThrough] get; }

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
        Logger Provision(ILoggerRepository loggerRepository = null);
    }
}