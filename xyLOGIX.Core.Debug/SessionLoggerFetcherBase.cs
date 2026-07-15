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
        protected IDictionary<string, ILog> _sourceTypeFQNToLogMap { [DebuggerStepThrough] get; } =
            new AdvisableDictionary<string, ILog>();

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
        protected static object SyncRoot { [DebuggerStepThrough] get; } = new object();

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

                System.Diagnostics.Debug.WriteLine(
                    "*** SessionLoggerFetcherBase.ClearInternalCache: Checking whether the '_sourceTypeFQNToLogMap' collection contains greater than zero elements..."
                );

                // Check to see whether the '_sourceTypeFQNToLogMap' collection contains greater
                // than zero elements.  Otherwise, write an error message to the Debug output,
                // return the default return value, and then terminate the execution of this method.
                if (_sourceTypeFQNToLogMap.Count <= 0)
                {
                    // The '_sourceTypeFQNToLogMap' collection contains zero elements.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The '_sourceTypeFQNToLogMap' collection contains zero elements.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetcherBase.ClearInternalCache: *** SUCCESS *** {_sourceTypeFQNToLogMap.Count} element(s) were found in the '_sourceTypeFQNToLogMap' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.ClearInternalCache: *** FYI *** Clearing the internal cache..."
                );

                _sourceTypeFQNToLogMap.Clear();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Ascertains whether a reference to an instance of an object that
        /// implements the <see cref="T:log4net.ILog" /> interface is available for the
        /// specified <paramref name="sourceType" /> in the internal cache.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that reflects the type for which to obtain the
        /// logger.
        /// </param>
        /// <remarks>
        /// This method searches the internal cache for a key that matches the value of the
        /// <see cref="P:System.Type.FullName" /> property of the specified
        /// <paramref name="sourceType" />.
        /// <para />
        /// If such a match is found, then this method returns <see langword="true" />;
        /// otherwise, it returns <see langword="false" />.
        /// <para />
        /// If the <paramref name="sourceType" /> parameter is passed a
        /// <see langword="null" /> reference, then this method returns
        /// <see langword="false" />.
        /// <para />
        /// This method also returns <see langword="false" /> if the
        /// <see
        ///     cref="F:xyLOGIX.Core.Debug.SessionLoggerFetcherBase._sourceTypeFQNToLogMap" />
        /// collection is set to a <see langword="null" /> reference, or if it contains
        /// zero element(s).
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if a key exists in the internal cache that
        /// matches the value of the <see cref="P:System.Type.FullName" /> property;
        /// <see langword="false" /> otherwise.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        protected bool IsLogAvailableForType([NotLogged] Type sourceType)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetcherBase.IsLogAvailableForType: *** FYI *** Determining whether a logger is available for the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.IsLogAvailableForType: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the log file and then terminate the execution of this
                // method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.IsLogAvailableForType: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** SessionLoggerFetcherBase.IsLogAvailableForType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.IsLogAvailableForType: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                // Dump the value of the property, sourceType.FullName, to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"sourceType.FullName = '{sourceType.FullName}'"
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
                        $"SessionLoggerFetcherBase.IsLogAvailableForType: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'sourceType.FullName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.IsLogAvailableForType: Checking whether the field, '_sourceTypeFQNToLogMap', does NOT have a null reference for a value..."
                );

                // Check to see if the field, _sourceTypeFQNToLogMap, is NOT null.  If this is the
                // case,  then write an FYI message to the Debug output and then terminate the
                // execution of this method, and then return the default value of the 'result'
                // variable.  We need the field to currently be set to a NULL reference in order to
                // be able to proceed.
                if (_sourceTypeFQNToLogMap != null)
                {
                    // The field, _sourceTypeFQNToLogMap, must be set to a NULL reference for this
                    // method to work. Since this is not the case, then we can't do anything more
                    // here.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.IsLogAvailableForType: *** FYI *** The field, '_sourceTypeFQNToLogMap', does NOT have a null reference.  Nothing to do."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** SessionLoggerFetcherBase.IsLogAvailableForType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.IsLogAvailableForType: *** SUCCESS *** The field, '_sourceTypeFQNToLogMap', has a NULL reference for its current value, which is what we are looking for.  Proceeding..."
                );

                lock (SyncRoot)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** SessionLoggerFetcherBase.IsLogAvailableForType: Checking whether the '_sourceTypeFQNToLogMap' collection contains greater than zero elements..."
                    );

                    // Check to see whether the '_sourceTypeFQNToLogMap' collection contains greater
                    // than zero elements.  Otherwise, write an error message to the Debug output,
                    // return the default return value, and then terminate the execution of this
                    // method.
                    if (_sourceTypeFQNToLogMap.Count <= 0)
                    {
                        // The '_sourceTypeFQNToLogMap' collection contains zero elements.  This is
                        // not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR *** The '_sourceTypeFQNToLogMap' collection contains zero elements.  Stopping..."
                        );

                        System.Diagnostics.Debug.WriteLine(
                            $"SessionLoggerFetcherBase.IsLogAvailableForType: Result = {result}"
                        );

                        // stop.
                        return result;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetcherBase.IsLogAvailableForType: *** SUCCESS *** {_sourceTypeFQNToLogMap.Count} element(s) were found in the '_sourceTypeFQNToLogMap' collection.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetcherBase.IsLogAvailableForType: Checking whether the internal cache contains the key, '{sourceType.FullName}'..."
                    );

                    // Check to see whether the internal cache contains the key,
                    // '{sourceType.FullName}'. If this is not the case, then write an error message
                    // to the log file, and then terminate the execution of this method.
                    if (!_sourceTypeFQNToLogMap.ContainsKey(sourceType.FullName))
                    {
                        // The internal cache does NOT appear to contain the desired key.  This is
                        // not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            $"SessionLoggerFetcherBase.IsLogAvailableForType: *** ERROR *** The internal cache does NOT appear to contain the key, '{sourceType.FullName}'.  Stopping..."
                        );

                        System.Diagnostics.Debug.WriteLine(
                            $"*** SessionLoggerFetcherBase.IsLogAvailableForType: Result = {result}"
                        );

                        // stop.
                        return result;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetcherBase.IsLogAvailableForType: *** SUCCESS *** The internal cache contains the key, '{sourceType.FullName}'.  Proceeding..."
                    );

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
                $"SessionLoggerFetcherBase.IsLogAvailableForType: Result = {result}"
            );

            return result;
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
                    // The field, '_sourceTypeFQNToLogMap' is required to be set to a valid object
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

                _sourceTypeFQNToLogMap[sourceType.FullName] = logger;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                DebugLevel.Debug,
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
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface from the ordinary log4net repository.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Type" /> that identifies the source of the logging
        /// record(s).
        /// </param>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="sourceType" /> is <see langword="null" />, or
        /// log4net cannot supply the logger, then this method returns
        /// <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        protected static ILog TryGetLegacyLogger([NotLogged] Type sourceType)
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"SessionLoggerFetcherBase.TryGetLegacyLogger: *** FYI *** Attempting to get a reference to an instance of the legacy logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryGetLegacyLogger: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "SessionLoggerFetcherBase.TryGetLegacyLogger: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryGetLegacyLogger: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Getting the legacy logger for the source type, '{sourceType.FullName}'..."
                );

                result = LogManager.GetLogger(sourceType);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null

                    // ReSharper disable once ConstantConditionalAccessQualifier
                    ? $"*** SUCCESS *** Obtained a reference to an instance of the legacy logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to an instance of the legacy logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'.  Stopping..."
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
                    // There is nothing to do.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'sourceType.FullName', appears to have a null or blank value.  Nothing to do..."
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
                    $"SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: Checking whether the specified source type, '{sourceType.FullName}', has a logger available..."
                );

                // Check to see whether the specified source type has a logger available. If this is
                // not the case, then write an error message to the log file, and then terminate the
                // execution of this method.
                if (!IsLogAvailableForType(sourceType))
                {
                    // The specified source type does NOT appear to have a logger available.  This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** ERROR *** The specified source type, '{sourceType.FullName}', does NOT appear to have a logger available.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "SessionLoggerFetcherBase.TryGetLoggerFromInternalCache: *** SUCCESS *** The specified source type has a logger available.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to get a reference to an instance of the logger that corresponds to the source type, '{sourceType.FullName}', from the internal cache..."
                );

                result = _sourceTypeFQNToLogMap[sourceType.FullName];
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
                    ? $"*** SUCCESS *** Obtained a reference to a logger that corresponds to the specified source type, '{sourceType?.FullName ?? "<null>"}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to a logger that corresponds to the specified source type, '{sourceType?.FullName ?? "<null>"}'.  Stopping..."
            );

            return result;
        }
    }
}