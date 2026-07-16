using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Represents the identity of a logger that is stored in the logging-client logger
    /// cache.
    /// </summary>
    /// <remarks>
    /// A logger is uniquely identified by the object identity of its log4net
    /// repository
    /// and its logger name.
    /// <para />
    /// Repository object identity is utilized instead of merely comparing repository
    /// name(s), so a logger associated with one repository instance can never be
    /// confused
    /// with a logger associated with another repository instance.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLoggerCacheKey : IEquatable<LoggingClientLoggerCacheKey>
    {
        /// <summary>
        /// An <see cref="T:System.Int32" /> value by which the repository identity hash
        /// code is multiplied when computing the combined hash code for this key.
        /// </summary>
        private const int HashCodeMultiplier = 397;

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that need to be
        /// performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the
        /// <c>[Log(AttributeExclude = true)]</c> attribute in order to simplify the
        /// logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCacheKey() { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey" /> class and
        /// returns a reference to it.
        /// </summary>
        /// <param name="repository">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface that contains
        /// the logger.
        /// </param>
        /// <param name="loggerName">
        /// (Required.) A <see cref="T:System.String" /> containing the name of the logger
        /// within the specified <paramref name="repository" />.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="repository" /> parameter, then an
        /// <see cref="T:System.ArgumentNullException" /> is thrown.
        /// <para />
        /// If a <see langword="null" /> reference, blank value, or
        /// <see cref="F:System.String.Empty" /> is passed for the
        /// <paramref name="loggerName" /> parameter, then an
        /// <see cref="T:System.ArgumentException" /> is thrown.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if a <see langword="null" /> reference is passed for the
        /// <paramref name="repository" /> parameter.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if a <see langword="null" /> reference, blank value, or
        /// <see cref="F:System.String.Empty" /> is passed for the
        /// <paramref name="loggerName" /> parameter.
        /// </exception>
        [Log(AttributeExclude = true)]
        internal LoggingClientLoggerCacheKey(
            [NotLogged] ILoggerRepository repository,
            [NotLogged] string loggerName
        )
        {
            if (string.IsNullOrWhiteSpace(loggerName))
                throw new ArgumentException(
                    "Value cannot be null or whitespace.", nameof(loggerName)
                );

            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            LoggerName = loggerName;
        }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the name of the logger within
        /// the repository identified by the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Repository" />
        /// property.
        /// </summary>
        internal string LoggerName { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface that contains
        /// the logger identified by the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.LoggerName" />
        /// property.
        /// </summary>
        internal ILoggerRepository Repository { [DebuggerStepThrough] get; }

        /// <summary>
        /// Determines whether this key and the specified <paramref name="other" /> key
        /// identify the same logger.
        /// </summary>
        /// <param name="other">
        /// (Required.) Reference to an instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey" /> to compare with
        /// this key.
        /// </param>
        /// <remarks>
        /// This method returns <see langword="false" /> if a
        /// <see langword="null" /> reference is passed for the
        /// <paramref name="other" /> parameter, the repositories are not the same object
        /// instance, or the logger name(s) are not ordinally equal.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if both key(s) identify the same logger;
        /// otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public bool Equals([NotLogged] LoggingClientLoggerCacheKey other)
        {
            var result = false;

            try
            {
                if (other == null) return result;

                if (!ReferenceEquals(Repository, other.Repository))
                    return result;

                if (!StringComparer.Ordinal.Equals(LoggerName, other.LoggerName))
                    return result;

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Determines whether this key and the specified <paramref name="obj" /> identify
        /// the same logger.
        /// </summary>
        /// <param name="obj">
        /// (Required.) Reference to an instance of <see cref="T:System.Object" /> to
        /// compare with this key.
        /// </param>
        /// <remarks>
        /// This method returns <see langword="false" /> if a
        /// <see langword="null" /> reference is passed for the
        /// <paramref name="obj" /> parameter or if the supplied object is not an instance
        /// of <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the supplied object identifies the same logger;
        /// otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public override bool Equals([NotLogged] object obj)
        {
            var result = false;

            try
            {
                if (!(obj is LoggingClientLoggerCacheKey other))
                    return result;

                result = Equals(other);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            return result;
        }

        /// <summary>Returns the hash code for this logger-cache key.</summary>
        /// <remarks>
        /// The repository portion of the hash code is based upon object identity rather
        /// than an overridden repository equality implementation.
        /// <para />
        /// The logger-name portion is computed by using ordinal string-comparison
        /// semantics.
        /// </remarks>
        /// <returns>
        /// An <see cref="T:System.Int32" /> value containing the hash code for this
        /// logger-cache key.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public override int GetHashCode()
        {
            var result = 0;

            try
            {
                if (Repository == null) return result;
                if (string.IsNullOrWhiteSpace(LoggerName)) return result;

                var repositoryHashCode = RuntimeHelpers.GetHashCode(Repository);
                var loggerNameHashCode = StringComparer.Ordinal.GetHashCode(LoggerName);

                unchecked
                {
                    result = (repositoryHashCode * HashCodeMultiplier) ^ loggerNameHashCode;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = 0;
            }

            return result;
        }
    }
}