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
    /// Defines the events, methods, properties, and behaviors for all
    /// <c>Session Logger Fetcher</c> component(s).
    /// </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal abstract class SessionLoggerFetcherBase : ISessionLoggerFetcher
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetcherBase" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static SessionLoggerFetcherBase() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetcherBase" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// <strong>NOTE:</strong> This constructor is marked
        /// <see langword="protected" /> due to the fact that this class is marked
        /// <see langword="abstract" />.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        protected SessionLoggerFetcherBase()
        { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:System.Collections.Generic.IDictionary`2" /> that maps
        /// <see cref="T:System.String" /> value(s), consisting of the fully-qualified
        /// name(s) of source type(s), to reference(s) to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that is a logger of that
        /// type.
        /// </summary>
        private static IDictionary<string, ILog> _sourceTypeFQNToLogMap
        {
            [DebuggerStepThrough]
            get;
        } = new AdvisableDictionary<string, ILog>();

        /// <summary>
        /// Gets the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration
        /// value that identifies the particular approach that is to be utilized to fetch a
        /// logger for a client session, or to use the legacy logger if no other approach
        /// is available.
        /// </summary>
        public abstract SessionLoggerFetchApproach Approach { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to an instance of an object that is to be used for
        /// thread synchronization purposes.
        /// </summary>
        private static object SyncRoot { [DebuggerStepThrough] get; } = new object();

        /// <summary>
        /// Attempts to fetch a logger for a client session by using specified
        /// <paramref name="sourceType" /> and optional <paramref name="repositoryName" />,
        /// if specified, per the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration
        /// value that is specified by the
        /// <see cref="P:xyLOGIX.Core.Debug.ISessionLoggerFetcher.Approach" /> property.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that is utilized to identify the logger that is to
        /// be fetched for a client session.
        /// <para />
        /// Perhaps this value might come from an internal cache.
        /// </param>
        /// <param name="repositoryName">
        /// (Optional.) A <see cref="T:System.String" /> that
        /// is set to the name of the repository that is associated with the logger that is
        /// to be fetched for a client session.
        /// <para />
        /// If this value is not specified, then the default repository name will be used.
        /// <para />
        /// The default value of this parameter is the <see cref="F:System.String.Empty" />
        /// value.
        /// <para />
        /// The repository name is only to be provided when a more refined search is to be
        /// employed.
        /// <para />
        /// In such a case where we are searching on the repository name, then the value of
        /// the <paramref name="repositoryName" /> parameter must be specified, and it must
        /// not be <see cref="F:System.String.Empty" />.
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:log4net.ILog" /> interface; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        public abstract ILog FetchLogger(Type sourceType, string repositoryName = "");

        /// <summary>Clears the internal logging-client session logger cache.</summary>
        /// <remarks>
        /// If the cache already has zero elements, then this method takes no
        /// action.
        /// </remarks>
        protected void ClearInternalCache()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.ClearInternalCache: Checking whether the field, '_sourceTypeFQNToLogMap', has a null reference for a value..."
                );

                // Check to see if the required field, '_sourceTypeFQNToLogMap', is null. If it is,
                // then send an error to the log file and then quit, returning the default value of
                // the result variable.
                if (_sourceTypeFQNToLogMap == null)
                {
                    // The field, '_sourceTypeFQNToLogMap' is required to be set to a valid object
                    // reference, but it's not.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.ClearInternalCache: *** ERROR *** The field, '_sourceTypeFQNToLogMap', has a null reference.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.ClearInternalCache: *** SUCCESS *** The field, '_sourceTypeFQNToLogMap', has a valid object reference for its value.  Proceeding..."
                );

                /* Obviously, if the internal cache already has zero element(s), then there is
                 nothing else that needs to be done. */

                var originalCacheElementCount = int.MinValue;
                var remainingElementCount = int.MinValue;

                /* Determine the original element count, conditionally clear the cache, and
                 determine the remaining element count under one uninterrupted lock. */

                lock (SyncRoot)
                {
                    originalCacheElementCount = _sourceTypeFQNToLogMap.Count;

                    if (originalCacheElementCount > 0)
                        _sourceTypeFQNToLogMap.Clear();

                    remainingElementCount = _sourceTypeFQNToLogMap.Count;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.ClearInternalCache: Checking whether the count of internal cache element(s) is greater than zero..."
                );

                // Check whether the count of internal cache element(s) is greater than zero.  If it
                // is not, then write an error message to the log file, and then terminate the
                // execution of this method.
                if (originalCacheElementCount <= 0)
                {
                    // The count of internal cache element(s) is less than, or equal to, zero.  This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The count of internal cache element(s) is zero.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetcherBase.ClearInternalCache: *** SUCCESS *** {originalCacheElementCount} internal cache element(s) were found.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** SessionLoggerFetcherBase.ClearInternalCache: Checking whether the internal cache does NOT still one or more element(s)..."
                );

                // Check to see whether the internal cache does NOT still contain one or more
                // element(s).  Otherwise, write an error message to the log file, and then
                // terminate the execution of this method.
                if (remainingElementCount > 0)
                {
                    // The internal cache appears to still contain one or more element(s).  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The internal cache appears to still contain one or more element(s).  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.ClearInternalCache: *** SUCCESS *** The internal cache was cleared successfully.  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Attempts to add the specified <paramref name="logger" /> to the
        /// internal cache, keyed by the fully-qualified name of the specified
        /// <paramref name="sourceType" />.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that identifies the type for which to cache the
        /// logger.
        /// </param>
        /// <param name="logger">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that identifies the
        /// logger that corresponds to the specified <paramref name="sourceType" /> for
        /// which to cache the logger.
        /// </param>
        /// <remarks></remarks>
        /// <returns>
        /// <see langword="true" /> if the specified operation(s) have completed
        /// successfully; <see langword="false" /> otherwise.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        protected bool TryAddLoggerToInternalCache(
            [NotLogged] Type sourceType,
            [NotLogged] ILog logger
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetcherBase.TryAddLoggerToInternalCache: *** FYI *** Adding the logger for the source type, '{sourceType?.FullName ?? "<null>"}', to the internal cache..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: Checking whether the field, '_sourceTypeFQNToLogMap', has a null reference for a value..."
                );

                // Check to see if the required field, '_sourceTypeFQNToLogMap', is null. If it is,
                // then send an error to the log file and then quit, returning the default value of
                // the result variable.
                if (_sourceTypeFQNToLogMap == null)
                {
                    // The field, '_sourceTypeFQNToLogMap', is required to be set to a valid object
                    // reference, but it's not.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: *** ERROR *** The field, '_sourceTypeFQNToLogMap', has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** SessionLoggerFetcherBase.TryAddLoggerToInternalCache: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: *** SUCCESS *** The field, '_sourceTypeFQNToLogMap', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'sourceType.FullName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'sourceType.FullName', appears to have a
                // null  or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(sourceType.FullName))
                {
                    // The property, 'sourceType.FullName', appears to have a null or blank value.
                    // This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'sourceType.FullName', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetcherBase.TryAddLoggerToInternalCache: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'sourceType.FullName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: Checking whether the method parameter, 'logger', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'logger', is null. If it is, then write
                // an error message to the Debug output and then terminate the execution of this
                // method, returning the default return value.
                if (logger == null)
                {
                    // The method parameter, 'logger', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: *** ERROR *** A null reference was passed for the method parameter, 'logger'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryAddLoggerToInternalCache: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'logger'.  Proceeding..."
                );

                lock (SyncRoot)
                {
                    _sourceTypeFQNToLogMap[sourceType.FullName] = logger;

                    /* If we made it this far with no Exception(s) getting caught, then assume that
                     the operation(s) succeeded. */

                    result = true;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"SessionLoggerFetcherBase.TryAddLoggerToInternalCache: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Given a specified <paramref name="sourceType" /> and
        /// <paramref name="repositoryName" />, attempts to create a reference to an
        /// instance of an object that implements the <see cref="T:log4net.ILog" />
        /// interface that allows access to the corresponding logger.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that identifies the source of the logging
        /// record(s).
        /// </param>
        /// <param name="repositoryName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the name of the repository that is associated with the logger that
        /// is to be fetched for a client session.
        /// </param>
        /// <param name="log">
        /// (Output.) If successful, receives a reference to an instance
        /// of an object that implements the <see cref="T:log4net.ILog" /> interface that
        /// allows access to the corresponding logger; otherwise, receives a
        /// <see langword="null" /> reference.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for the value of the
        /// <paramref name="sourceType" /> parameter, then the <paramref name="log" />
        /// parameter is set to a <see langword="null" /> reference, and this method
        /// returns <see langword="false" />
        /// <para />
        /// This method also returns <see langword="false" /> if a
        /// <see langword="null" /, blank, or the <see cref="F:System.String.Empty" />
        /// value is passed for the value of the <paramref name="repositoryName" />
        /// parameter; and the value of the <paramref name="log" /> parameter is also
        /// assigned a <see langword="null" /> reference.
        /// <para />
        /// The method also returns <see langword="false" /> if the logger could not be
        /// created for any reason, and the value of the <paramref name="log" /> parameter
        /// is also assigned a <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the specified operation(s) have completed
        /// successfully; <see langword="false" /> otherwise.
        /// </returns>
        protected bool TryCreateLoggerForSourceTypeAndRepoName(
            [NotLogged] Type sourceType,
            [NotLogged] string repositoryName,
            [NotLogged] out ILog log
        )
        {
            var result = false;
            log = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryCreateLoggerForSourceTypeAndRepoName: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.TryCreateLoggerForSourceTypeAndRepoName: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    log = default;

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryCreateLoggerForSourceTypeAndRepoName: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'sourceType.FullName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'sourceType.FullName', appears to have a
                // null  or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(sourceType.FullName))
                {
                    // The property, 'sourceType.FullName', appears to have a null or blank value.
                    // This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'sourceType.FullName', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetcherBase.TryCreateLoggerForSourceTypeAndRepoName: Result = {result}"
                    );

                    log = default;

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'sourceType.FullName', seems to have a non-blank value.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "SessionLoggerFetcherBase.TryCreateLoggerForSourceTypeAndRepoName *** INFO: Checking whether the value of the parameter, 'repositoryName', is blank..."
                );

                // Check whether the value of the parameter, 'repositoryName', is blank. If this is
                // so, then emit an error message to the log file, and then terminate the execution
                // of this method.
                if (string.IsNullOrWhiteSpace(repositoryName))
                {
                    // The parameter, 'repositoryName' was either passed a null value, or it is
                    // blank.  There is nothing to do.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.TryCreateLoggerForSourceTypeAndRepoName: The parameter, 'repositoryName' was either passed a null value, or it is blank. Nothing to do..."
                    );

                    log = default;

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'repositoryName', is not blank.  Proceeding..."
                );

                log = LogManager.GetLogger(repositoryName, sourceType);

                /* If we made it this far with no Exception(s) getting caught, then assume that the
                 operation(s) succeeded. */

                result = log != null && repositoryName.Equals(log.Logger.Repository.Name);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
                log = default;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"SessionLoggerFetcherBase.TryCreateLoggerForSourceTypeAndRepoName: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Looks up the specified <paramref name="sourceType" /> in the internal
        /// cache; if found, returns a reference to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface that can be utilized for
        /// logging.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that identifies the source of the logging
        /// record(s).
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:log4net.ILog" /> interface; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        protected ILog TryGetLoggerFromInternalCache([NotLogged] Type sourceType)
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** FYI *** Getting a logger from the internal cache that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'sourceType.FullName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'sourceType.FullName', appears to have a
                // null  or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(sourceType.FullName))
                {
                    // The property, 'sourceType.FullName', appears to have a null or blank value.
                    // This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'sourceType.FullName', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'sourceType.FullName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: Checking whether the field, '_sourceTypeFQNToLogMap', has a null reference for a value..."
                );

                // Check to see if the required field, '_sourceTypeFQNToLogMap', is null.  If it is,
                // then send an error to the log file and then quit, returning the default value of
                // the result variable.
                if (_sourceTypeFQNToLogMap == null)
                {
                    // The field, '_sourceTypeFQNToLogMap' is required to be set to a valid object
                    // reference, but it's not.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** ERROR *** The field, '_sourceTypeFQNToLogMap', has a null reference.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** SUCCESS *** The field, '_sourceTypeFQNToLogMap', has a valid object reference for its value.  Proceeding..."
                );

                /* Determine whether the current source is mapped to a logger, AND retrieve the
                 logger as well, all under the same lock. */

                bool loggerWasFound;

                lock (SyncRoot)
                {
                    loggerWasFound = _sourceTypeFQNToLogMap.TryGetValue(
                        sourceType.FullName, out result
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: Checking whether a logger corresponding to the source type, '{sourceType.FullName}', was found in the internal cache..."
                );

                // Check to see whether a logger corresponding to the source type,
                // '{sourceType.FullName}', was found in the internal cache.  If this is not the
                // case, then write an error message to the log file, and then terminate the
                // execution of this method.
                if (!loggerWasFound)
                {
                    // The logger corresponding to the specified source type was NOT found in the
                    // internal cache.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** ERROR *** A logger corresponding to the source type, '{sourceType.FullName}', was NOT found in the internal cache.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** SUCCESS *** A logger corresponding to the source type, '{sourceType.FullName}', was found in the internal cache.  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null

                    // ReSharper disable once ConstantConditionalAccessQualifier
                    ? $"*** SUCCESS *** A logger corresponding to the source type, '{sourceType?.FullName ?? "<null>"}', was fetched successfully from the internal cache.  Proceeding..."
                    : $"*** ERROR *** A logger corresponding to the source type, '{sourceType?.FullName ?? "<null>"} could not be fetched from the internal cache.  Stopping..."
            );

            return result;
        }
    }
}