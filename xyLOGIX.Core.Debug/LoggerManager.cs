using log4net.Repository;
using log4net.Repository.Hierarchy;
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
        /// Initializes static data or performs actions that need to be performed once only for the <see cref="T:xyLOGIX.Core.Debug.LoggerManager"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being created or before any static members are referenced.
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
        [DebuggerStepThrough]
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