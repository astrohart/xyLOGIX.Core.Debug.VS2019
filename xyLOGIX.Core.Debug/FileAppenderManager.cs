using log4net.Appender;
using log4net.Repository;
using System;
using System.Linq;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    ///     Provides methods to access instances of objects of type
    ///     <see cref="T:log4net.Appender.FileAppender" />.
    /// </summary>
    public static class FileAppenderManager
    {
        public static FileAppender GetAppenderByName(string name)
        {
            // Check to see if the required parameter, name, is blank,
            // whitespace, or null. If it is any of these, throw an
            // ArgumentNullException.

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var root = LoggerManager.GetRootLogger();
            if (root == null)
                return null;

            return root.Appenders.Count == 0
                ? null
                : root.Appenders.OfType<FileAppender>()
                    .First(fa => fa.Name == name);
        }

        /// <summary>
        ///     If the root logger's appenders list contains appenders, returns a reference
        ///     to the first one in the list.
        /// </summary>
        /// <param name="loggerRepository"></param>
        /// <returns>
        ///     Reference to an instance of
        ///     <see cref="T:log4net.Appender.FileAppender" />, or null if not found.
        /// </returns>
        public static FileAppender GetFirstAppender(
            ILoggerRepository loggerRepository = null)
        {
            var root = LoggerManager.GetRootLogger(loggerRepository);
            if (root == null)
                return null;

            return root.Appenders.Count == 0
                ? null
                : root.Appenders.OfType<FileAppender>().First();
        }
    }
}