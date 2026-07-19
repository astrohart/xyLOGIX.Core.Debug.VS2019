using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Validates logging-client logger-cache key object(s).</summary>
    /// <remarks>
    /// This component is stateless and can therefore be utilized concurrently
    /// by multiple thread(s).
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLoggerCacheKeyValidator
        : ILoggingClientLoggerCacheKeyValidator
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> member(s) are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCacheKeyValidator() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator" /> and
        /// returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLoggerCacheKeyValidator()
        { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLoggerCacheKeyValidator Instance
        {
            [DebuggerStepThrough]
            get;
        } = new LoggingClientLoggerCacheKeyValidator();

        /// <summary>
        /// Determines whether the specified <paramref name="cacheKey" /> contains
        /// all the information required to identify a logger within a particular log4net
        /// repository.
        /// </summary>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that is to be validated.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="cacheKey" /> parameter, then this method returns
        /// <see langword="false" />.
        /// <para />
        /// This method also returns <see langword="false" /> if the
        /// <see cref="P:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.Repository" />
        /// property has a <see langword="null" /> reference for a value or the
        /// <see cref="P:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.LoggerName" />
        /// property is blank.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the specified cache key is valid;
        /// otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public bool IsValid([NotLogged] ILoggingClientLoggerCacheKey cacheKey)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyValidator.IsValid: Checking whether the method parameter, 'cacheKey', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'cacheKey', is null. If it is, then write
                // an error message to the Debug output and terminate the execution of this method.
                if (cacheKey == null)
                {
                    // The method parameter, 'cacheKey', is required and is not supposed to have a
                    // null reference for a value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCacheKeyValidator.IsValid: *** ERROR *** A null reference was passed for the method parameter, 'cacheKey'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyValidator.IsValid: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'cacheKey'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyValidator.IsValid: Checking whether the property, 'cacheKey.Repository', has a null reference for a value..."
                );

                // Check to see if the required property, 'cacheKey.Repository', is null. If it is,
                // then write an error message to the Debug output and terminate the execution of
                // this method.
                if (cacheKey.Repository == null)
                {
                    // The property, 'cacheKey.Repository', is required to have a valid object
                    // reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCacheKeyValidator.IsValid: *** ERROR *** The property, 'cacheKey.Repository', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyValidator.IsValid: *** SUCCESS *** The property, 'cacheKey.Repository', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyValidator.IsValid: Checking whether the value of the property, 'cacheKey.LoggerName', is blank..."
                );

                // Check whether the value of the property, 'cacheKey.LoggerName', is blank. If this
                // is so, then write an error message to the Debug output and terminate the
                // execution of this method.
                if (string.IsNullOrWhiteSpace(cacheKey.LoggerName))
                {
                    // The value of the property, 'cacheKey.LoggerName', is blank.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCacheKeyValidator.IsValid: *** ERROR *** The value of the property, 'cacheKey.LoggerName', is blank.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCacheKeyValidator.IsValid: *** SUCCESS *** The value of the property, 'cacheKey.LoggerName', is not blank.  Proceeding..."
                );

                /*
                 * If we made it this far with no Exception(s) getting caught, then assume that the
                 * data has been validated successfully.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientLoggerCacheKeyValidator.IsValid: Result = {result}"
            );

            return result;
        }
    }
}