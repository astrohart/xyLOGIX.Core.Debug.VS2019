using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using Logger = log4net.Repository.Hierarchy.Logger;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides methods to access objects of type
    /// <see cref="T:log4net.Hierarchy.Repository.Logger" /> from log4net.
    /// </summary>
    public static class LoggerManager
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.LoggerManager" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggerManager() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator" />
        /// interface.
        /// </summary>
        private static IRootLoggerProvisioningStrategyValidator
            RootLoggerProvisioningStrategyValidator
        {
            [DebuggerStepThrough] get;
        } =
            GetRootLoggerProvisioningStrategyValidator.SoleInstance();

        /// <summary>
        /// Gets a reference to the default logger repository's root instance of
        /// <see cref="T:log4net.Hierarchy.Repository.Logger" />.
        /// </summary>
        /// <param name="loggerRepository"> </param>
        /// <returns>
        /// Reference to an instance of
        /// <see cref="T:log4net.Repository.Hierarchy.Logger" /> that refers to the
        /// <c>Root Logger</c> component that is to be used, if found; a
        /// <see langword="null" /> reference is returned otherwise.
        /// </returns>
        public static Logger GetRootLogger(
            [NotLogged] ILoggerRepository loggerRepository = null
        )
        {
            Logger result = default;

            try
            {
                var strategy =
                    Determine.TheRootLoggerProvisioningStrategyToUse(
                        loggerRepository
                    );

                System.Diagnostics.Debug.WriteLine(
                    $"*** LoggerManager.GetRootLogger: Checking whether the Root Logger Provisioning Strategy, '{strategy}', is within the defined value set..."
                );

                // Check to see whether the Root Logger Provisioning Strategy is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!RootLoggerProvisioningStrategyValidator.IsValid(strategy))
                {
                    // The Root Logger Provisioning Strategy is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The Root Logger Provisioning Strategy, '{strategy}', is NOT within the defined value set.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggerManager.GetRootLogger: *** SUCCESS *** The Root Logger Provisioning Strategy, '{strategy}', is within the defined value set.  Proceeding..."
                );

                // Get a reference to the appropriate Root Logger Provisioner.

                System.Diagnostics.Debug.WriteLine(
                    $"LoggerManager.GetRootLogger: Obtaining a reference to the Root Logger Provisioner for the Root Logger Provisioning Strategy, '{strategy}'..."
                );

                var rootLoggerProvisioner =
                    GetRootLoggerProvisioner.For(strategy);

                System.Diagnostics.Debug.WriteLine(
                    "LoggerManager.GetRootLogger: Checking whether the variable, 'rootLoggerProvisioner', has a null reference for a value..."
                );

                // Check to see if the variable, rootLoggerProvisioner, is null.  If it is, send an error
                // to the log file, and then terminate the execution of this method,
                // returning the default return value.
                if (rootLoggerProvisioner == null)
                {
                    // the variable rootLoggerProvisioner is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggerManager.GetRootLogger: *** ERROR ***  The variable, 'rootLoggerProvisioner', has a null reference.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, rootLoggerProvisioner, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "LoggerManager.GetRootLogger: *** SUCCESS *** The variable, 'rootLoggerProvisioner', has a valid object reference for its value.  Proceeding..."
                );

                result = rootLoggerProvisioner.Provision(loggerRepository);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to the root Logger Repository.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to the root Logger Repository.  Stopping..."
            );

            return result;
        }
    }
}