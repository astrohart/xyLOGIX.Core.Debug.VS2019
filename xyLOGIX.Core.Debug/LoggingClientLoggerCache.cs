using log4net;
using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides a singleton cache for logger instances used by logging
    /// clients.
    /// </summary>
    /// <remarks>
    /// Access is restricted to the Instance property to enforce the singleton
    /// pattern and prevent direct instantiation.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLoggerCache : ILoggingClientLoggerCache
    {
        /// <summary>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> interface that maps
        /// logging-client logger-cache key(s) to their corresponding logger object(s).
        /// </summary>
        private readonly IDictionary<ILoggingClientLoggerCacheKey, ILog> _loggerMap =
            new AdvisableDictionary<ILoggingClientLoggerCacheKey, ILog>();

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCache" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLoggerCache() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCache" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCache.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLoggerCache() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator" />
        /// interface that validates logging-client logger-cache key object(s).
        /// </summary>
        private ILoggingClientLoggerCacheKeyValidator CacheKeyValidator
        {
            [DebuggerStepThrough] get;
        } = GetLoggingClientLoggerCacheKeyValidator.SoleInstance();

        /// <summary>
        /// Gets an <see cref="T:System.Int32" /> value that indicates the number
        /// of logger object(s) currently stored in the cache.
        /// </summary>
        /// <remarks>
        /// The value returned by this property is an atomic, point-in-time
        /// snapshot of the cache element count.
        /// <para />
        /// Callers must not assume that the count remains unchanged after the property
        /// getter returns.
        /// </remarks>
        public int Count
        {
            [DebuggerStepThrough]
            get
            {
                var result = 0;

                try
                {
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.Count: Checking whether the field, '_loggerMap', has a null reference for a value..."
                    );

                    // Check to see if the required field, '_loggerMap', is null. If it is, then
                    // write an error message to the Debug output and return the default property
                    // value.
                    if (_loggerMap == null)
                    {
                        // The field, '_loggerMap', is required to be set to a valid object
                        // reference, but it is not.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.Count: *** ERROR *** The field, '_loggerMap', has a null reference for a value.  Stopping..."
                        );

                        return result;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.Count: *** SUCCESS *** The field, '_loggerMap', has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.Count: Checking whether the field, 'SyncRoot', has a null reference for a value..."
                    );

                    // Check to see if the required field, 'SyncRoot', is null. If it is, then write
                    // an error message to the Debug output and return the default property value.
                    if (SyncRoot == null)
                    {
                        // The field, 'SyncRoot', is required to be set to a valid object reference,
                        // but it is not.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.Count: *** ERROR *** The field, 'SyncRoot', has a null reference for a value.  Stopping..."
                        );

                        return result;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.Count: *** SUCCESS *** The field, 'SyncRoot', has a valid object reference for its value.  Proceeding..."
                    );

                    lock (SyncRoot)
                    {
                        result = _loggerMap.Count;
                    }
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = 0;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCache.Count: Result = {result}"
                );

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCache" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLoggerCache Instance { [DebuggerStepThrough] get; } =
            new LoggingClientLoggerCache();

        /// <summary>
        /// Reference to an instance of <see cref="T:System.Object" /> that is
        /// utilized to synchronize access to the logging-client logger cache.
        /// </summary>
        private object SyncRoot { [DebuggerStepThrough] get; } = new object();

        /// <summary>Removes all logger object(s) from the cache.</summary>
        /// <remarks>
        /// If the cache already contains zero element(s), then this method
        /// returns <see langword="true" /> without modifying the cache.
        /// <para />
        /// If the cache cannot be cleared, then this method returns
        /// <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the cache already contains zero element(s)
        /// or is cleared successfully; otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public bool Clear()
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.Clear: Checking whether the field, '_loggerMap', has a null reference for a value..."
                );

                // Check to see if the required field, '_loggerMap', is null. If it is, then write
                // an error message to the Debug output and then terminate the execution of this
                // method.
                if (_loggerMap == null)
                {
                    // The field, '_loggerMap', is required to be set to a valid object reference,
                    // but it is not.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.Clear: *** ERROR *** The field, '_loggerMap', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.Clear: *** SUCCESS *** The field, '_loggerMap', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.Clear: Checking whether the field, 'SyncRoot', has a null reference for a value..."
                );

                // Check to see if the required field, 'SyncRoot', is null. If it is, then write an
                // error message to the Debug output and then terminate the execution of this
                // method.
                if (SyncRoot == null)
                {
                    // The field, 'SyncRoot', is required to be set to a valid object reference, but
                    // it is not.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.Clear: *** ERROR *** The field, 'SyncRoot', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.Clear: *** SUCCESS *** The field, 'SyncRoot', has a valid object reference for its value.  Proceeding..."
                );

                var originalCacheElementCount = 0;
                var remainingCacheElementCount = 0;

                /* Determine the original cache-element count, clear the cache if necessary, and
                 verify the remaining count under one uninterrupted synchronization lock. */

                lock (SyncRoot)
                {
                    originalCacheElementCount = _loggerMap.Count;

                    if (originalCacheElementCount > 0)
                        _loggerMap.Clear();

                    remainingCacheElementCount = _loggerMap.Count;

                    // The cache still contains one or more element(s).  This is not desirable.
                    if (remainingCacheElementCount > 0)
                        return result;

                    /* If we made it this far with no Exception(s) getting caught, then assume that
                     the operation(s) succeeded. */

                    result = true;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCache.Clear: *** FYI *** The cache contained {originalCacheElementCount} element(s) when the synchronization lock was acquired."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCache.Clear: *** SUCCESS *** The cache now contains {remainingCacheElementCount} element(s).  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientLoggerCache.Clear: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Attempts to add the specified <paramref name="logger" /> to the cache
        /// by using the specified <paramref name="cacheKey" />.
        /// </summary>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that uniquely identifies the logger within a particular log4net
        /// repository.
        /// </param>
        /// <param name="logger">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that is to be stored in
        /// the cache.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="cacheKey" /> or <paramref name="logger" /> parameter, then this
        /// method returns <see langword="false" />.
        /// <para />
        /// If a non-<see langword="null" /> logger is already cached for the specified
        /// <paramref name="cacheKey" />, then this method leaves the existing logger
        /// unchanged and returns <see langword="true" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the logger is already cached or is added
        /// successfully; otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public bool TryAdd(
            [NotLogged] ILoggingClientLoggerCacheKey cacheKey,
            [NotLogged] ILog logger
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryAdd: Checking whether the specified cache key has valid setting(s)..."
                );

                // Check to see whether the specified cache key has valid setting(s). If this is not
                // the case, then write an error message to the log file, and then terminate the
                // execution of this method.
                if (!CacheKeyValidator.IsValid(cacheKey))
                {
                    // The specified cache key does NOT appear to have valid setting(s).  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.TryAdd: *** ERROR *** The specified cache key does NOT appear to have valid setting(s).  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientLoggerCache.TryAdd: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryAdd: *** SUCCESS *** The specified cache key has valid setting(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryAdd: Checking whether the method parameter, 'logger', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'logger', is null. If it is, then write
                // an error message to the Debug output and terminate the execution of this method.
                if (logger == null)
                {
                    // The method parameter, 'logger', is required and is not supposed to have a
                    // null reference for a value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.TryAdd: *** ERROR *** A null reference was passed for the method parameter, 'logger'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryAdd: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'logger'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryAdd: Checking whether the field, '_loggerMap', has a null reference for a value..."
                );

                // Check to see if the required field, '_loggerMap', is null.  If it is, then send
                // an error to the log file and then quit, returning the default value of the result
                // variable.
                if (_loggerMap == null)
                {
                    // The field, '_loggerMap' is required to be set to a valid object reference,
                    // but it's not.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.TryAdd: *** ERROR *** The field, '_loggerMap', has a null reference.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryAdd: *** SUCCESS *** The field, '_loggerMap', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Adding the logger to the cache with the corresponding cache key."
                );

                lock (SyncRoot)
                {
                    _loggerMap[cacheKey] = logger;
                }

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

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientLoggerCache.TryAdd: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Attempts to obtain the logger associated with the specified
        /// <paramref name="cacheKey" />.
        /// </summary>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that uniquely identifies the logger within a particular log4net
        /// repository.
        /// </param>
        /// <param name="logger">
        /// (Output.) If successful, receives a reference to an
        /// instance of an object that implements the <see cref="T:log4net.ILog" />
        /// interface that is associated with the specified <paramref name="cacheKey" />;
        /// otherwise, receives a <see langword="null" /> reference.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the
        /// <paramref name="cacheKey" /> parameter, no matching cache entry exists, or the
        /// matching cache entry contains a <see langword="null" /> reference, then this
        /// method assigns a <see langword="null" /> reference to the
        /// <paramref name="logger" /> parameter and returns <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if a non-<see langword="null" /> logger is
        /// obtained from the cache; otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public bool TryGet(
            [NotLogged] ILoggingClientLoggerCacheKey cacheKey,
            [NotLogged] out ILog logger
        )
        {
            var result = false;
            logger = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryGet: Checking whether the specified cache key has valid setting(s)..."
                );

                // Check to see whether the specified cache key has valid setting(s). If this is not
                // the case, then write an error message to the log file, and then terminate the
                // execution of this method.
                if (!CacheKeyValidator.IsValid(cacheKey))
                {
                    // The specified cache key does NOT appear to have valid setting(s).  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.TryGet: *** ERROR *** The specified cache key does NOT appear to have valid setting(s).  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientLoggerCache.TryGet: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryGet: *** SUCCESS *** The specified cache key has valid setting(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryGet: Checking whether the field, '_loggerMap', has a null reference for a value..."
                );

                // Check to see if the required field, '_loggerMap', is null.  If it is, then send
                // an error to the log file and then quit, returning the default value of the result
                // variable.
                if (_loggerMap == null)
                {
                    // The field, '_loggerMap' is required to be set to a valid object reference,
                    // but it's not.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.TryGet: *** ERROR *** The field, '_loggerMap', has a null reference.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLoggerCache.TryGet: *** SUCCESS *** The field, '_loggerMap', has a valid object reference for its value.  Proceeding..."
                );

                lock (SyncRoot)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Getting the logger from the cache with the corresponding cache key..."
                    );

                    result = _loggerMap.TryGetValue(cacheKey, out logger);

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.TryGet: Checking whether the variable, 'logger', has a null reference for a value..."
                    );

                    // Check to see if the variable, 'logger', has a null reference for a value. If
                    // it does, then emit an error to the Debug output, and terminate the execution
                    // of this method, returning the default return value.
                    if (logger == null)
                    {
                        // The variable, 'logger', has a null reference for a value.  This is not
                        // desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.TryGet: *** ERROR ***  The variable, 'logger', has a null reference for a value.  Stopping..."
                        );

                        logger = default;

                        System.Diagnostics.Debug.WriteLine(
                            $"*** LoggingClientLoggerCache.TryGet: Result = {false}"
                        );

                        // stop.
                        return false;
                    }

                    // We can use the variable, 'logger', because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLoggerCache.TryGet: *** SUCCESS *** The variable, 'logger', has a valid object reference for its value.  Proceeding..."
                    );

                    /* If we made it this far with no Exception(s) getting caught, then assume that
                     the operation(s) succeeded. */

                    return true;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
                logger = default;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientLoggerCache.TryGet: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Attempts to apply the specified logging-client logger-cache <c>Add</c>
        /// <paramref name="action" />.
        /// </summary>
        /// <param name="action">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction" /> value(s)
        /// that identifies the action to be applied.
        /// </param>
        /// <param name="cacheKey">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey" />
        /// interface that identifies the cache entry to be updated.
        /// </param>
        /// <param name="logger">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that is to be stored
        /// when the specified <paramref name="action" /> requires a cache update.
        /// </param>
        /// <remarks>
        /// The caller must own the synchronization lock represented by the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientLoggerCache.SyncRoot" /> property
        /// before invoking this method.
        /// <para />
        /// The
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.PreserveExistingLogger" />
        /// action performs no cache mutation and is treated as successful.
        /// <para />
        /// The
        /// <see cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.AddLogger" />
        /// and
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.ReplaceNullLogger" />
        /// action(s) update the cache and then verify that it contains the same logger
        /// object reference that was supplied.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the specified action is applied
        /// successfully; otherwise, <see langword="false" />.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        private bool TryApplyCacheAddAction(
            LoggingClientLoggerCacheAddAction action,
            [NotLogged] ILoggingClientLoggerCacheKey cacheKey,
            [NotLogged] ILog logger
        )
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, 'action', to the Debug output.
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLoggerCache.TryApplyCacheAddAction: action = '{action}'"
                );

                switch (action)
                {
                    case LoggingClientLoggerCacheAddAction.AddLogger:
                    case LoggingClientLoggerCacheAddAction.ReplaceNullLogger:
                        // ReSharper disable once InconsistentlySynchronizedField
                        _loggerMap[cacheKey] = logger;

                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.TryApplyCacheAddAction: Checking whether the cache entry can be obtained after the update..."
                        );

                        // Check whether the cache entry can be obtained after the update. If this
                        // is not the case, then write an error message to the Debug output and
                        // terminate the execution of this method.
                        // ReSharper disable once InconsistentlySynchronizedField
                        if (!_loggerMap.TryGetValue(cacheKey, out var cachedLogger))
                        {
                            // The cache entry could not be obtained after the update. This is not
                            // desirable.
                            System.Diagnostics.Debug.WriteLine(
                                "LoggingClientLoggerCache.TryApplyCacheAddAction: *** ERROR *** The cache entry could not be obtained after the update.  Stopping..."
                            );

                            // stop.
                            return result;
                        }

                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.TryApplyCacheAddAction: *** SUCCESS *** The cache entry was obtained after the update.  Proceeding..."
                        );

                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.TryApplyCacheAddAction: Checking whether the cached logger has a null reference for a value..."
                        );

                        // Check whether the cached logger has a null reference for a value. If this
                        // is the case, then write an error message to the Debug output and
                        // terminate the execution of this method.
                        if (cachedLogger == null)
                        {
                            // The cached logger has a null reference for a value. This is not
                            // desirable.
                            System.Diagnostics.Debug.WriteLine(
                                "LoggingClientLoggerCache.TryApplyCacheAddAction: *** ERROR *** The cached logger has a null reference for a value.  Stopping..."
                            );

                            // stop.
                            return result;
                        }

                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.TryApplyCacheAddAction: *** SUCCESS *** The cached logger has a valid object reference for its value.  Proceeding..."
                        );

                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.TryApplyCacheAddAction: Checking whether the cached logger is the same object reference as the specified logger..."
                        );

                        // Check whether the cached logger is the same object reference as the
                        // specified logger. If this is not the case, then write an error message to
                        // the Debug output and terminate the execution of this method.
                        if (!ReferenceEquals(logger, cachedLogger))
                        {
                            // The cached logger is not the same object reference as the specified
                            // logger. This is not desirable.
                            System.Diagnostics.Debug.WriteLine(
                                "LoggingClientLoggerCache.TryApplyCacheAddAction: *** ERROR *** The cached logger is not the same object reference as the specified logger.  Stopping..."
                            );

                            // stop.
                            return result;
                        }

                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.TryApplyCacheAddAction: *** SUCCESS *** The cached logger is the same object reference as the specified logger.  Proceeding..."
                        );

                        /* If we made it this far with no Exception(s) getting caught, then assume
                         that the operation(s) succeeded. */

                        result = true;
                        break;

                    case LoggingClientLoggerCacheAddAction.PreserveExistingLogger:
                        /* If we made it this far with no Exception(s) getting caught, then assume
                         that the operation(s) succeeded. */

                        result = true;
                        break;

                    case LoggingClientLoggerCacheAddAction.Unknown:
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientLoggerCache.TryApplyCacheAddAction: *** ERROR *** The 'Unknown' logging-client logger-cache Add action was specified.  Stopping..."
                        );
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(action), action,
                            $"The logging-client logger-cache Add action, '{action}', is not supported."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientLoggerCache.TryApplyCacheAddAction: Result = {result}"
            );

            return result;
        }
    }
}