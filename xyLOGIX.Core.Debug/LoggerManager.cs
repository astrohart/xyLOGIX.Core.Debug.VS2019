using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides methods to access objects of type <see
    /// cref="T:log4net.Hierarchy.Repository.Logger"/> from log4net.
    /// </summary>
    public static class LoggerManager
    {
        /// <summary>
        /// Gets a reference to the default logger repository's root instance of
        /// <see cref="T:log4net.Hierarchy.Repository.Logger"/>.
        /// </summary>
        /// <param name="loggerRepository">
        /// </param>
        /// <returns>
        /// Reference to the default logger repository's root instance of <see
        /// cref="T:log4net.Hierarchy.Repository.Logger"/>, or null if not found.
        /// </returns>
        public static Logger GetRootLogger(
            ILoggerRepository loggerRepository = null)
        {
            return (loggerRepository != null
                ? (Hierarchy)loggerRepository
                : LoggerRepositoryManager.GetHierarchyRepository())?.Root;
        }
    }
}
