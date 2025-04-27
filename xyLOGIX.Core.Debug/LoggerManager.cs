using log4net.Repository;
using log4net.Repository.Hierarchy;
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
        /// Reference to the default logger repository's root instance of
        /// <see cref="T:log4net.Hierarchy.Repository.Logger" /> , or null if not found.
        /// </returns>
        public static Logger GetRootLogger(
            [NotLogged] ILoggerRepository loggerRepository = null
        )
        {
            var result = LoggerRepositoryManager.GetHierarchyRepository()
                                                .Root;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggerManager.GetRootLogger: Checking whether the 'loggerRepository' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, loggerRepository, is null. If it is, send an
                // error to the log file and quit, returning the default return value of this
                // method.
                if (loggerRepository == null)
                {
                    // The parameter, 'loggerRepository', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggerManager.GetRootLogger: *** ERROR *** A null reference was passed for the 'loggerRepository' method parameter.  Returning the Default Root Logger instead..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggerManager.GetRootLogger: *** SUCCESS *** We have been passed a valid object reference for the 'loggerRepository' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** LoggerManager.GetRootLogger: Checking whether the provided Logger Repository is of type Hierarchy..."
                );

                // Check to see whether the Logger Repository is of type Hierarchy.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!(loggerRepository is Hierarchy hierarchy))
                {
                    // The Logger Repository is NOT of type Hierarchy.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The Logger Repository is NOT of type Hierarchy.  Returning the Default Root Logger instead..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggerManager.GetRootLogger: *** SUCCESS *** The Logger Repository is of type Hierarchy.  Proceeding..."
                );

                result = hierarchy.Root;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = LoggerRepositoryManager.GetHierarchyRepository()
                                                .Root;
            }

            System.Diagnostics.Debug.WriteLine(
                $"*** FYI *** Type of returned object is: '{result.GetType()}'."
            );

            return result;
        }
    }
}