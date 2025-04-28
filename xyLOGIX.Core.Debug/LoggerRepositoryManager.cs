using log4net;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides methods to access the log4net Repository. </summary>
    public static class LoggerRepositoryManager
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.LoggerRepositoryManager" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggerRepositoryManager() { }

        /// <summary>
        /// Gets a reference to an instance of the log4net repository as an
        /// reference to an object of type
        /// <see cref="T:log4net.Repository.Hierarchy.Hierarchy" />.
        /// </summary>
        /// <returns>
        /// Reference to an instance of a <see cref="I:ILoggerRepository" /> that
        /// derives from <see cref="T:log4net.Repository.Hierarchy" />, or null if no such
        /// object has been found.
        /// </returns>
        [return: NotLogged]
        public static Hierarchy GetHierarchyRepository()
        {
            Hierarchy result = default;

            try
            {
                ProgramFlowHelper.StartDebugger();

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to obtain the Hierarchy Repository..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to use the Assembly: {typeof(LogFileManager).Assembly}..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Calling LogManager.GetRepository with the Assembly: {Assembly.GetAssembly(typeof(LogFileManager))}..."
                );

                // Get the log4net repository
                var repository = LogManager.GetRepository(
                    Assembly.GetAssembly(typeof(LogFileManager))
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggerRepositoryManager.GetHierarchyRepository: Checking whether the variable, 'repository', has a null reference for a value..."
                );

                // Check to see if the variable, repository, is null.  If it is, send an error
                // to the Debug output, and then terminate the execution of this method,
                // returning the default return value.
                if (repository == null)
                {
                    // the variable repository is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggerRepositoryManager.GetHierarchyRepository: *** ERROR ***  The variable, 'repository', has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggerRepositoryManager.GetHierarchyRepository: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, repository, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "LoggerRepositoryManager.GetHierarchyRepository: *** SUCCESS *** The variable, 'repository', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** LoggerRepositoryManager.GetHierarchyRepository: Checking whether the repository obtained is a Hierarchy..."
                );

                // Check to see whether the repository obtained is a Hierarchy.
                // If this is not the case, then write an error message to the log file
                // and then terminate the execution of this method.
                if (!(repository is Hierarchy hierarchy))
                {
                    // The repository obtained is NOT a Hierarchy.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** WARNING *** The repository obtained from the Target Assembly is NOT a Hierarchy.  Attempting to use the default Logger Repository..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Attempting to cast the default Logger Repository to a Hierarchy object..."
                    );

                    // try to cast the default repository as a Hierarchy object
                    result = GetLoggerRepository() as Hierarchy;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(
                        "LoggerRepositoryManager.GetHierarchyRepository: *** SUCCESS *** The repository obtained is a Hierarchy.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Attempting to cast the repository to a Hierarchy object..."
                    );

                    // Cast the repository to a Hierarchy object
                    result = hierarchy;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to a Hierarchy Repository.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to a Hierarchy Repository.  Stopping..."
            );

            return result;
        }

        /// <summary> Wraps the <see cref="log4net.LogManager.GetRepository" /> method. </summary>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface, or null if
        /// such an object cannot be found.
        /// </returns>
        [return: NotLogged]
        public static ILoggerRepository GetLoggerRepository()
        {
            ILoggerRepository result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggerRepositoryManager.GetLoggerRepository: *** FYI *** Attempting to obtain the default Logger Repository..."
                );

                result = LogManager.GetRepository();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to the default Logger Repository.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to the default Logger Repository.  Stopping..."
            );

            return result;
        }
    }
}