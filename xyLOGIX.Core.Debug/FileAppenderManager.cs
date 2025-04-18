﻿using log4net.Appender;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Linq;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides methods to access instances of objects of type
    /// <see cref="T:log4net.Appender.FileAppender" />.
    /// </summary>
    public static class FileAppenderManager
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.FileAppenderManager" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static FileAppenderManager() { }

        /// <summary>
        /// Attempts to obtain a reference to an instance of
        /// <see cref="T:log4net.Appender.FileAppender" /> that is configured under a
        /// certain name in the application configuration file.
        /// </summary>
        /// <param name="name">
        /// (Required.) String containing the name under which the
        /// appender is configured in the application configuration file.
        /// </param>
        /// <returns>
        /// If a suitable configuration file entry is found, this method returns
        /// a <see cref="T:log4net.Appender.FileAppender" /> instance that corresponds to
        /// the entry; otherwise, <see langword="null" /> is returned.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if the required parameter,
        /// <paramref name="name" />, is passed a blank or <see langword="null" /> string
        /// for a value.
        /// </exception>
        public static FileAppender GetAppenderByName(string name)
        {
            // Check to see if the required parameter, name, is blank,
            // whitespace, or null. If it is any of these, throw an ArgumentNullException.

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var root = LoggerManager.GetRootLogger();
            if (root == null)
                return null;

            return root.Appenders.Count <= 0
                ? null
                : root.Appenders.OfType<FileAppender>()
                      .First(fa => fa.Name == name);
        }

        /// <summary>
        /// If the root logger's appenders list contains appenders, returns a
        /// reference to the first one in the list.
        /// </summary>
        /// <param name="loggerRepository"> </param>
        /// <returns>
        /// Reference to an instance of
        /// <see cref="T:log4net.Appender.FileAppender" /> , or <see langword="null" /> if
        /// not found.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="loggerRepository" /> parameter is passed a
        /// <see langword="null" /> value, then this method attempts to obtain the root
        /// logger object and then obtain the first
        /// <see cref="T:log4net.Appender.FileAppender" /> configured on the root logger
        /// repository. If a suitable appender can still not be located, then the return
        /// value of this method is <see langword="null" />.
        /// </remarks>
        public static FileAppender GetFirstAppender(
            ILoggerRepository loggerRepository = null
        )
        {
            FileAppender result = default;

            try
            {
                var root = LoggerManager.GetRootLogger(loggerRepository);
                if (root == null) return result;

                result = root.Appenders.Count <= 0
                    ? default
                    : root.Appenders.OfType<FileAppender>()
                          .First();
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