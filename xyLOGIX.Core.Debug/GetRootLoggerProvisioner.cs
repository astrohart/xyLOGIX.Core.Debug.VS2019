using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Obtains references to instances of objects that implement the
    /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface that
    /// change depending on the strategy desired.
    /// </summary>
    public static class GetRootLoggerProvisioner
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetRootLoggerProvisioner" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetRootLoggerProvisioner() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator" />
        /// interface.
        /// </summary>
        private static IRootLoggerProvisioningStrategyValidator
            RootLoggerProvisioningStrategyValidator
        {
            [DebuggerStepThrough]
            get;
        } =
            GetRootLoggerProvisioningStrategyValidator.SoleInstance();

        /// <summary>
        /// Obtains a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface which
        /// corresponds to the specified meeting <paramref name="strategy" />.
        /// </summary>
        /// <param name="strategy">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy" /> enumeration
        /// values that describes the root-logger provisioning strategy.
        /// </param>
        /// <returns>
        /// Reference to the instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface which
        /// corresponds to the specific enumeration value that is specified for the
        /// argument of the <paramref name="strategy" /> parameter.
        /// </returns>
        /// <remarks>
        /// This method will throw an exception if there are no types implemented
        /// that correspond to the enumeration value passed for the argument of the
        /// <paramref name="strategy" /> parameter.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if there is no
        /// corresponding concrete type defined that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioner" /> interface and which
        /// corresponds to the specific enumeration value that was passed for the argument
        /// of the <paramref name="strategy" /> parameter, if it is not supported.
        /// </exception>
        [DebuggerStepThrough]
        [return: NotLogged]
        public static IRootLoggerProvisioner For(
            RootLoggerProvisioningStrategy strategy
        )
        {
            IRootLoggerProvisioner result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** GetRootLoggerProvisioner.OfType: Checking whether the provided Root Logger Provisioning Strategy is within the defined value set..."
                );

                // Check to see whether the provided Root Logger Provisioning Strategy is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!RootLoggerProvisioningStrategyValidator.IsValid(strategy))
                {
                    // The provided Root Logger Provisioning Strategy is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The provided Root Logger Provisioning Strategy is NOT within the defined value set.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "GetRootLoggerProvisioner.OfType: *** SUCCESS *** The provided Root Logger Provisioning Strategy is within the defined value set.  Proceeding..."
                );

                switch (strategy)
                {
                    case RootLoggerProvisioningStrategy
                        .FromProvidedLoggingRepository:
                        result =
                            GetFromProvidedLoggingRepositoryRootLoggerProvisioner
                                .SoleInstance();
                        break;

                    case RootLoggerProvisioningStrategy.FromLogManager:
                        result = GetFromLogManagerRootLoggerProvisioner
                            .SoleInstance();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(strategy), strategy,
                            $"The specified Root Logger Provisioning Strategy, '{strategy}', is not supported.  Write a Root Logger Provisioner component that supports it.  Stopping..."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to the Root Logger Provisioner for the '{strategy}' strategy.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to the Root Logger Provisioner for the '{strategy}' strategy.  Stopping..."
            );

            return result;
        }
    }
}