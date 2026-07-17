using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Represents the identity of a logger that is stored in the
    /// logging-client logger cache.
    /// </summary>
    /// <remarks>
    /// A logger is uniquely identified by the object identity of its log4net
    /// repository and its ordinal logger name.
    /// <para />
    /// Repository object identity is utilized instead of repository-name equality so
    /// that separate repository instance(s) having the same name remain distinct.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLoggerCacheKey : ILoggingClientLoggerCacheKey
    {
        /// <summary>
        /// An <see cref="T:System.Int32" /> value by which the
        /// repository-identity hash code is multiplied when computing the combined hash
        /// code for this key.
        /// </summary>
        private const int HashCodeMultiplier = 397;

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCacheKey() { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey" /> class and
        /// returns a reference to it.
        /// </summary>
        /// <param name="repository">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Repository.ILoggerRepository" /> interface
        /// that contains the logger.
        /// </param>
        /// <param name="loggerName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the name of the logger within the specified
        /// <paramref name="repository" />.
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
        /// Thrown if a
        /// <see langword="null" /> reference is passed for the
        /// <paramref name="repository" /> parameter.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if a
        /// <see langword="null" /> reference, blank value, or
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
                throw new ArgumentException("The logger name cannot be blank.", nameof(loggerName));

            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            LoggerName = loggerName;
        }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the name of the
        /// logger within the repository identified by the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Repository" />
        /// property.
        /// </summary>
        public string LoggerName { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface that contains
        /// the logger identified by the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.LoggerName" />
        /// property.
        /// </summary>
        public ILoggerRepository Repository { [DebuggerStepThrough] get; }

        /// <summary>
        /// Determines whether this cache key and the specified
        /// <paramref name="other" /> cache key identify the same logger.
        /// </summary>
        /// <param name="other">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface to compare with this cache key.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="other" /> parameter, then this method returns
        /// <see langword="false" />.
        /// <para />
        /// This method returns <see langword="false" /> if the repository properties do
        /// not refer to the same object instance or the logger name(s) are not ordinally
        /// equal.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if both cache key(s) identify the same logger;
        /// otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public bool Equals([NotLogged] ILoggingClientLoggerCacheKey other)
        {
            var result = false;

            try
            {
                if (other == null)
                    return result;

                if (!ReferenceEquals(Repository, other.Repository))
                    return result;

                if (!StringComparer.Ordinal.Equals(LoggerName, other.LoggerName))
                    return result;

                /* If we made it this far with no Exception(s) getting caught, then assume that the
                 operation(s) succeeded. */

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
        /// Determines whether this cache key and the specified
        /// <paramref name="obj" /> identify the same logger.
        /// </summary>
        /// <param name="obj">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Object" /> to compare with this cache key.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="obj" /> parameter, or the supplied object does not implement
        /// the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" /> interface,
        /// then this method returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the supplied object identifies the same
        /// logger; otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public override bool Equals([NotLogged] object obj)
        {
            var result = false;

            try
            {
                if (!(obj is ILoggingClientLoggerCacheKey other))
                    return result;

                if (!Equals(other))
                    return result;

                /* If we made it this far with no Exception(s) getting caught, then assume that the
                 operation(s) succeeded. */

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

        /// <summary>Returns the hash code for this logger-cache key.</summary>
        /// <remarks>
        /// The repository portion of the hash code is based upon object identity
        /// rather than an overridden repository equality implementation.
        /// <para />
        /// The logger-name portion is computed by using ordinal string-comparison
        /// semantics.
        /// </remarks>
        /// <returns>
        /// An <see cref="T:System.Int32" /> value containing the hash code for
        /// this logger-cache key.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public override int GetHashCode()
        {
            var result = 0;

            try
            {
                if (Repository == null)
                    return result;

                if (string.IsNullOrWhiteSpace(LoggerName))
                    return result;

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

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents this
        /// logging-client logger-cache key.
        /// </summary>
        /// <remarks>
        /// The returned string includes the repository name, the repository
        /// object-identity hash code, and the logger name.
        /// <para />
        /// The repository object-identity hash code is included because separate
        /// repository instance(s) having the same name represent distinct cache-key
        /// identities.
        /// </remarks>
        /// <returns>
        /// A <see cref="T:System.String" /> containing a diagnostic
        /// representation of this logging-client logger-cache key.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public override string ToString()
        {
            var result =
                "{ Logging Client Logger Cache Key: Repository = { Name = '<null>', IdentityHashCode = 0x00000000 }, LoggerName = '<null>' }";

            try
            {
                result =
                    $"{{ Logging Client Logger Cache Key: Repository = {{ Name = '{TryFormulateRepositoryStringRepresentation()}', IdentityHashCode = 0x{TryGetRepositoryHashCode():X8} }}, LoggerName = '{TryFormulateLoggerNameStringRepresentation()}' }}";
            }
            catch
            {
                result = "<unable to determine string representation>";
            }

            return result;
        }

        /// <summary>
        /// Determines the correct <see cref="T:System.String" /> representation
        /// of the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.LoggerName" />
        /// property for the current cache key.
        /// </summary>
        /// <returns>
        /// If successful, a <see cref="T:System.String" /> containing the string
        /// representation of the current value of the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.LoggerName" />
        /// property; otherwise, the method returns the value, <c>&lt;blank&gt;</c>.
        /// </returns>
        [DebuggerStepThrough, Log(AttributeExclude = true)]
        [return: NotLogged]
        private string TryFormulateLoggerNameStringRepresentation()
        {
            var result = "<blank>";

            try
            {
                if (string.IsNullOrWhiteSpace(LoggerName)) return result;

                result = LoggerName;
            }
            catch
            {
                result = "<blank>";
            }

            return result;
        }

        /// <summary>
        /// Determines the correct <see cref="T:System.String" /> representation
        /// of the value of the <see cref="P:log4net.Repository.ILoggerRepository.Name" />
        /// property for the current cache key.
        /// </summary>
        /// <remarks>
        /// If the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Repository" />
        /// property is currently set to a <see langword="null" /> reference, then this
        /// method returns the text, <c>&lt;null&gt;</c>.
        /// </remarks>
        /// <returns>
        /// If successful, a <see cref="T:System.String" /> containing the string
        /// representation of the current value of the
        /// <see cref="P:log4net.Repository.ILoggerRepository.Name" /> property; otherwise,
        /// the method returns the value, <c>&lt;blank&gt;</c>.
        /// </returns>
        [DebuggerStepThrough, Log(AttributeExclude = true)]
        [return: NotLogged]
        private string TryFormulateRepositoryStringRepresentation()
        {
            var result = "<blank>";

            try
            {
                if (Repository == null) return "<null>";

                if (string.IsNullOrWhiteSpace(Repository.Name)) return result;

                result = Repository.Name;
            }
            catch
            {
                result = "<blank>";
            }

            return result;
        }

        /// <summary>
        /// Retrieves, if possible, the object-identity hash code of the
        /// repository instance that is referenced by the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Repository" />
        /// property.
        /// </summary>
        /// <returns>
        /// If successful, a <see cref="T:System.Int32" /> value that is set to
        /// the hash code of the repository instance that is referenced by the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Repository" />
        /// property; otherwise, this method returns zero.
        /// </returns>
        [DebuggerStepThrough, Log(AttributeExclude = true)]
        [return: NotLogged]
        private int TryGetRepositoryHashCode()
        {
            var result = 0;

            try
            {
                if (Repository == null) return result;

                result = RuntimeHelpers.GetHashCode(Repository);
            }
            catch
            {
                result = 0;
            }

            return result;
        }
    }
}