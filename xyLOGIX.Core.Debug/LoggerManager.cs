using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
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
                /*
                 * If loggerRepository is not null, then we can use it to get the root logger.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "LoggerManager.GetRootLogger: *** INFO *** Attempting to get the default logger repository's root instance of log4net.Hierarchy.Repository.Logger... "
                );

                var hierarchyRepository =
                    LoggerRepositoryManager.GetHierarchyRepository();

                System.Diagnostics.Debug.WriteLine(
                    "LoggerManager.GetRootLogger: Checking whether the variable, 'hierarchyRepository', has a null reference for a value..."
                );

                // Check to see if the variable, hierarchyRepository, is null.  If it is, send an error
                // to the log file, and then terminate the execution of this method,
                // returning the default return value.
                if (hierarchyRepository == null)
                {
                    // the variable hierarchyRepository is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggerManager.GetRootLogger: *** ERROR ***  The variable, 'hierarchyRepository', has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggerManager.GetRootLogger: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, hierarchyRepository, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "LoggerManager.GetRootLogger: *** SUCCESS *** The variable, 'hierarchyRepository', has a valid object reference for its value.  Proceeding..."
                );

                result = hierarchyRepository.Root;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

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