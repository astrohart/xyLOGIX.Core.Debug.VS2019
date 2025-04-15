using log4net;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

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
        [DebuggerStepThrough]
        public static Hierarchy GetHierarchyRepository()
        {
            Hierarchy result = default;

            try
            {
                var targetType = typeof(LogFileManager);
                if (targetType == null) return result;

                var targetAssembly = targetType.Assembly;
                if (targetAssembly == null) return result;

                // Get the log4net repository
                var repository = LogManager.GetRepository(targetAssembly);
                if (repository == null) return result;

                // Cast the repository to a Hierarchy object
                result = repository as Hierarchy;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
        }

        /// <summary> Wraps the <see cref="M:log4net.LogManager.GetRepository" /> method. </summary>
        /// <returns>
        /// Reference to an instance of an object that implements
        /// <see cref="ILoggerRepository" /> , or null if such an object cannot be found.
        /// </returns>
        [DebuggerStepThrough]
        public static ILoggerRepository GetLoggerRepository()
            => LogManager.GetRepository();
    }
}