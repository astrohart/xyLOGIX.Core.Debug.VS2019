using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Creates new logging-client logger-cache key object(s) by using a
    /// fluent builder.
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal static class MakeNewLoggingClientLoggerCacheKey
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheKey" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically before any
        /// <see langword="static" /> member is referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MakeNewLoggingClientLoggerCacheKey() { }

        /// <summary>
        /// Begins creating a new logging-client logger-cache key for the
        /// specified <paramref name="repository" />.
        /// </summary>
        /// <param name="repository">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Repository.ILoggerRepository" /> interface
        /// that contains the logger to be represented by the completed cache key.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="repository" /> parameter, then this method returns a
        /// <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyBuilder" />
        /// interface; otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        internal static ILoggingClientLoggerCacheKeyBuilder ForRepository(
            [NotLogged] ILoggerRepository repository
        )
        {
            ILoggingClientLoggerCacheKeyBuilder result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientLoggerCacheKey.ForRepository: Checking whether the method parameter, 'repository', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'repository', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (repository == null)
                {
                    // The method parameter, 'repository', is required and is not supposed to have a
                    // null reference for a value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientLoggerCacheKey.ForRepository: *** ERROR *** A null reference was passed for the method parameter, 'repository'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientLoggerCacheKey.ForRepository: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'repository'.  Proceeding..."
                );

                result = new LoggingClientLoggerCacheKeyBuilder(repository);

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientLoggerCacheKey.ForRepository: Checking whether the variable, 'result', has a null reference for a value..."
                );

                // Check to see if the variable, 'result', has a null reference for a value.  If it
                // does, then write an error message to the Debug output and terminate the execution
                // of this method.
                if (result == null)
                {
                    // The variable, 'result', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientLoggerCacheKey.ForRepository: *** ERROR *** The variable, 'result', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientLoggerCacheKey.ForRepository: *** SUCCESS *** The variable, 'result', has a valid object reference for its value.  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}