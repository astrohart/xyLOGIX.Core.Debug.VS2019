using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using Logger = log4net.Repository.Hierarchy.Logger;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all
    /// <c>Root Logger Provisioner</c> object(s).
    /// </summary>
    public abstract class RootLoggerProvisionerBase : IRootLoggerProvisioner
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisionerBase" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static RootLoggerProvisionerBase() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisionerBase" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// <strong>NOTE:</strong> This constructor is marked <see langword="protected" />
        /// due to the fact that this class is marked <see langword="abstract" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        protected RootLoggerProvisionerBase()
        { }

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" />
        /// enumeration value that indicates the strategy used to provision the
        /// <c>Root Logger</c>.
        /// </summary>
        public abstract RootLoggerProvisioningStrategy Strategy
        {
            [DebuggerStepThrough]
            get;
        }

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
        [return: NotLogged]
        public abstract Logger Provision(
            [NotLogged] ILoggerRepository loggerRepository = null
        );

        /// <summary>
        /// Executes the fallback provisioning strategy for the <c>Root Logger</c>.
        /// </summary>
        /// <returns>
        /// If successful, a reference to an instance of
        /// <see cref="T:log4net.Repository.Hierarchy.Logger" /> that represents the
        /// <c>Root Logger</c> that is to be utilized; otherwise, a <see langword="null" />
        /// reference is returned.
        /// </returns>
        protected Logger ExecuteFallbackProvisioning()
        {
            Logger result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "RootLoggerProvisionerBase.ExecuteFallbackProvisioning: *** FYI *** Attempting to execute the default fallback provisioning strategy..."
                );

                // Attempt to get the default appender configuration and return a reference to that
                // configuration's RootLogger.
                var hierarchyRepository =
                    LoggerRepositoryManager.GetHierarchyRepository();

                System.Diagnostics.Debug.WriteLine(
                    $"*** INFO: The variable, 'hierarchyRepository', has a value of {hierarchyRepository}."
                );

                // Check whether the variable, 'hierarchyRepository', is NOT set to a null reference for a value.
                // If it is set to a null reference, then echo an error message to the Debug output, and then stop,
                // returning the default return value of this method.
                if (hierarchyRepository != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** INFO: The variable, 'hierarchyRepository', has a valid object reference for its value.  Proceeding..."
                    );

                    result = hierarchyRepository.Root;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** ERROR: The variable, 'hierarchyRepository', has a null reference.  Stopping..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to the Root Logger using the Fallback Provisioning Strategy.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to the Root Logger using the Fallback Provisioning Strategy.  Stopping..."
            );

            return result;
        }
    }
}