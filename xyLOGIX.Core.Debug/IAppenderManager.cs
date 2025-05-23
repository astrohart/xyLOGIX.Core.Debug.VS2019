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

        /// <summary>
        /// Attempts to look up the <c>Appender</c> whose <c>File</c> property matches the
        /// specified <paramref name="logFilePath" /> (ignoring case).
        /// </summary>
        /// <param name="logFilePath">
        /// (Required.) A <see cref="T:System.String" /> that contains the fully-qualified
        /// pathname of a file that is to be used to log messages.
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:log4net.Appender.IAppender" /> interface; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        IAppender GetFileAppenderByPath([NotLogged] string logFilePath);

        /// <summary>
        /// Determines whether an <c>Appender</c> is present that corresponds to the
        /// specified <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath">
        /// (Required.) A <see cref="T:System.String" /> that contains the fully-qualified
        /// pathname of a file for which to search.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value is passed as the argument of the
        /// <paramref name="filePath" /> parameter, then the method returns
        /// <see langword="false" />.
        /// <para />
        /// The method also returns <see langword="false" /> if the internal collection is
        /// currently empty.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if an  <c>Appender</c> is present that
        /// corresponds to the specified <paramref name="filePath" />;
        /// <see langword="false" /> otherwise.
        /// </returns>
        bool HasAppenderWithFilePath([NotLogged] string filePath);
    }
}