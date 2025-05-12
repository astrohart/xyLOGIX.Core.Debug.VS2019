using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using Logger = log4net.Repository.Hierarchy.Logger;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Attempts to provision the root logger from an existing <c>Logger Repository</c>
    /// component that has been determined, in advance, to be convertible to a
    /// reference to an instance of
    /// <see cref="T:log4net.Repository.Hierarchy.Hierarchy" />.
    /// </summary>
    public class
        FromProvidedLoggingRepositoryRootLoggerProvisioner :
        RootLoggerProvisionerBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static FromProvidedLoggingRepositoryRootLoggerProvisioner() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected FromProvidedLoggingRepositoryRootLoggerProvisioner() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface for the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromProvidedLoggingRepository" />
        /// root-logger provisioning strategy.
        /// </summary>
        public static IRootLoggerProvisioner Instance
        {
            [DebuggerStepThrough] get;
        } = new FromProvidedLoggingRepositoryRootLoggerProvisioner();

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" />
        /// enumeration value that indicates the strategy used to provision the
        /// <c>Root Logger</c>.
        /// </summary>
        public override RootLoggerProvisioningStrategy Strategy
        {
            [DebuggerStepThrough] get;
        } = RootLoggerProvisioningStrategy.FromProvidedLoggingRepository;

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
                /*
                 * If we are here, then it has been determined that the specified value
                 * of the loggerRepository parameter is castable to Hierarchy.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: Checking whether the 'loggerRepository' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, loggerRepository, is null. If it is, send an
                // error to the log file and quit, returning the default return value of this
                // method.
                if (loggerRepository == null)
                {
                    // The parameter, 'loggerRepository', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: *** ERROR *** A null reference was passed for the 'loggerRepository' method parameter.  Attempting to get a reference to the default Hierarchy repository..."
                    );

                    // Execute the fallback provisioning strategy, just in case.
                    return ExecuteFallbackProvisioning();
                }

                System.Diagnostics.Debug.WriteLine(
                    "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: *** SUCCESS *** We have been passed a valid object reference for the 'loggerRepository' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: Checking whether the provided Logger Repository is convertible to 'Hierarchy'..."
                );

                // Check to see whether the provided Logger Repository is convertible to 'Hierarchy'.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!(loggerRepository is Hierarchy hierarchyRepository))
                {
                    // The provided Logger Repository is NOT convertible to 'Hierarchy'.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The provided Logger Repository is NOT convertible to 'Hierarchy'.  Executing the Fallback Provisioning Strategy..."
                    );

                    // Execute the fallback provisioning strategy, just in case.
                    return ExecuteFallbackProvisioning();
                }

                System.Diagnostics.Debug.WriteLine(
                    "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: *** SUCCESS *** The provided Logger Repository is convertible to 'Hierarchy'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: Checking whether the variable, 'hierarchyRepository', has a null reference for a value..."
                );

                // Check to see if the variable, hierarchyRepository, is null.  If it is, send an error
                // to the log file, and then terminate the execution of this method,
                // returning the default return value.
                if (hierarchyRepository == null)
                {
                    // the variable hierarchyRepository is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: *** ERROR ***  The variable, 'hierarchyRepository', has a null reference.  Executing the Fallback Provisioning Strategy..."
                    );

                    // Execute the fallback provisioning strategy, just in case.
                    return ExecuteFallbackProvisioning();
                }

                // We can use the variable, hierarchyRepository, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: *** SUCCESS *** The variable, 'hierarchyRepository', has a valid object reference for its value.  Proceeding..."
                );

                // Return a reference to the Root Logger.
                System.Diagnostics.Debug.WriteLine(
                    "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: Returning a reference to the Root Logger..."
                );

                result = hierarchyRepository.Root;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: *** SUCCESS *** Obtained a reference to the Root Logger.  Proceeding..."
                    : "FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision: *** ERROR *** FAILED to obtain a reference to the Root Logger.  Stopping..."
            );

            return result;
        }
    }
}