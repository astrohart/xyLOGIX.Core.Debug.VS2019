using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Completes the construction of a logging-client logger-cache key for a
    /// previously specified log4net repository.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLoggerCacheKeyBuilder : ILoggingClientLoggerCacheKeyBuilder
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCacheKeyBuilder() { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder" /> class
        /// and returns a reference to it.
        /// </summary>
        /// <param name="repository">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Repository.ILoggerRepository" /> interface
        /// that contains the logger to be represented by the completed cache key.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="repository" /> parameter, then an
        /// <see cref="T:System.ArgumentNullException" /> is thrown.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if a
        /// <see langword="null" /> reference is passed for the
        /// <paramref name="repository" /> parameter.
        /// </exception>
        [Log(AttributeExclude = true)]
        internal LoggingClientLoggerCacheKeyBuilder([NotLogged] ILoggerRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            Repository = repository;
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface that contains
        /// the logger to be represented by the completed cache key.
        /// </summary>
        private ILoggerRepository Repository { [DebuggerStepThrough] get; }

        /// <summary>
        /// Creates a new logging-client logger-cache key for the repository
        /// previously supplied to the builder and the specified
        /// <paramref name="loggerName" />.
        /// </summary>
        /// <param name="loggerName">
        /// (Required.) A <see cref="T:System.String" /> value
        /// containing the name of the logger within the repository previously supplied to
        /// the builder.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value is passed for the
        /// <paramref name="loggerName" /> parameter, then this method returns a
        /// <see langword="null" /> reference.
        /// <para />
        /// A <see langword="null" /> reference is also returned if the repository
        /// previously supplied to the builder is unavailable.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" /> interface;
        /// otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public ILoggingClientLoggerCacheKey AndLoggerNamed([NotLogged] string loggerName)
        {
            ILoggingClientLoggerCacheKey result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyBuilder.AndLoggerNamed: Checking whether the property, 'Repository', has a null reference for a value..."
                );

                // Check to see if the required property, 'Repository', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (Repository == null)
                {
                    // The property, 'Repository', is required and is not supposed to have a null
                    // reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCacheKeyBuilder.AndLoggerNamed: *** ERROR *** The property, 'Repository', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyBuilder.AndLoggerNamed: *** SUCCESS *** The property, 'Repository', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyBuilder.AndLoggerNamed *** INFO: Checking whether the value of the parameter, 'loggerName', is blank..."
                );

                // Check whether the value of the parameter, 'loggerName', is blank. If this is so,
                // then emit an error message to the Debug output, and then terminate the execution
                // of this method.
                if (string.IsNullOrWhiteSpace(loggerName))
                {
                    // The parameter, 'loggerName', was either passed a null value, or it is blank.
                    // There is nothing to do.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCacheKeyBuilder.AndLoggerNamed: *** ERROR *** The parameter, 'loggerName', was either passed a null value, or it is blank.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'loggerName', is not blank.  Proceeding..."
                );

                result = new LoggingClientLoggerCacheKey(Repository, loggerName);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to a logging-client logger cache key object for the specified repository (if one was present) and logger name.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to a logging-client logger cache key object for the specified repository (if one was present) and logger name.  Stopping..."
            );

            return result;
        }
    }
}