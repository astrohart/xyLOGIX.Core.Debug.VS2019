using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides methods to access objects of type
    /// <see cref="T:log4net.Hierarchy.Repository.Logger" /> from log4net.
    /// </summary>
    public static class LoggerManager
    {
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
            ILoggerRepository loggerRepository = null
        )
        {
            Logger result = default;

            try
            {
                if (!(loggerRepository is Hierarchy hierarchy))
                    return result;

                result = (loggerRepository != null
                    ? hierarchy
                    : LoggerRepositoryManager.GetHierarchyRepository()).Root;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
        }
    }
}