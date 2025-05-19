using log4net.Appender;
using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an
    /// <c>Appender Manager</c> object, that allows application-wide access to
    /// configured appender(s).
    /// </summary>
    public interface IAppenderManager
    {
        /// <summary>
        /// Gets the count of appenders in the internal collection.
        /// </summary>
        int AppenderCount { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to an instance of to an array of instances of objects that
        /// implement the <see cref="T:log4net.Appender.IAppender" /> interface, that are
        /// configured for use by the application.
        /// </summary>
        IAppender[] Appenders { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a value indicating whether the internal collection has more than zero
        /// element(s).
        /// </summary>
        bool HasAppenders { [DebuggerStepThrough] get; }

        /// <summary>
        /// Adds a reference to an instance of an object that implements the
        /// <see cref="T:log4net.Appender.IAppender" /> interface to the list of configured
        /// appenders.
        /// </summary>
        /// <param name="appender">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Appender.IAppender" /> interface that is to be added to
        /// the internal collection.
        /// </param>
        void AddAppender([NotLogged] IAppender appender);
    }
}