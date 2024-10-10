using log4net.Appender;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides methods for configurating log4net's FileAppender </summary>
    public static class FileAppenderConfigurator
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.FileAppenderConfigurator" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static FileAppenderConfigurator() { }

        /// <summary>
        /// Sets the option to get the minimal locking option set on the
        /// specified <paramref name="appender" />.
        /// </summary>
        /// <param name="appender">
        /// Reference to an instance of an object of type
        /// <see cref="T:log4net.Appender.FileAppender" />.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the instance of the object
        /// referenced by <paramref name="appender" /> is <see langword="null" />.
        /// </exception>
        public static void SetMinimalLock(FileAppender appender)
        {
            if (appender == null)
                throw new ArgumentNullException(nameof(appender));

            appender.ImmediateFlush = true;
            appender.LockingModel = new FileAppender.MinimalLock();
            appender.ActivateOptions();
        }
    }
}