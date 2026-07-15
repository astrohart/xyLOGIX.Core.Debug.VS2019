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
    /// Provides log4net logger object(s) for the current logging-client
    /// session.
    /// </summary>
    /// <remarks>
    /// This class dynamically selects the appropriate repository whenever a
    /// logger is requested.
    /// <para />
    /// Logger object(s) are not cached globally because the current logging-client
    /// session may vary between logical execution flow(s).
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientLogProvider : ILoggingClientLogProvider
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLogProvider" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLogProvider() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientLogProvider" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the <see cref="P:xyLOGIX.Core.Debug.LoggingClientLogProvider.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLogProvider() { }

        private IDictionary<string, ILog> _sourceTypeFQNToLogMap { [DebuggerStepThrough] get; } =
            new AdvisableDictionary<string, ILog>();

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLogProvider" />
        /// interface.
        /// </summary>
        internal static ILoggingClientLogProvider Instance { [DebuggerStepThrough] get; } =
            new LoggingClientLogProvider();

        /// <summary>
        /// Gets a reference to an instance of an object that is to be used for thread
        /// synchronization purposes.
        /// </summary>
        private static object SyncRoot { [DebuggerStepThrough] get; } = new object();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface for the specified source type.
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
        /// If <paramref name="sourceType" /> is <see langword="null" />, then
        /// this method returns <see langword="null" />.
        /// <para />
        /// If no valid specialized logging-client session is active, then the ordinary
        /// log4net repository is utilized.
        /// <para />
        /// If a valid specialized session is active but a logger cannot be obtained from
        /// its repository, then this method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        public ILog GetLogForType([NotLogged] Type sourceType)
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.GetLogForType: *** FYI *** Getting an ILog reference that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetLogForType: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check whether the method parameter, 'sourceType', has a null reference for a
                // value.  If this is the case, then write an error message to the Debug output, and
                // then terminate the execution of this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', has a null reference for a value.  This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.GetLogForType: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetLogForType: *** SUCCESS *** The method parameter, 'sourceType', refers to a valid object.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetLogForType: Checking whether the property, 'LoggingSubsystemManager.CurrentClientSession', has a null reference for a value..."
                );

                // Check to see if the required property,
                // 'LoggingSubsystemManager.CurrentClientSession', has a null reference for a value.
                // If that is the case, then we will write an error message to the Debug output, and
                // then terminate the execution of this method, while returning the default return
                // value.
                if (LoggingSubsystemManager.CurrentClientSession == null)
                {
                    // The property, 'LoggingSubsystemManager.CurrentClientSession', has a null
                    // reference for a value.  There is nothing to do.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.GetLogForType: *** ERROR *** The property, 'LoggingSubsystemManager.CurrentClientSession', has a null reference for a value.  Nothing to do..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Getting a reference to an instance of the legacy logger..."
                    );

                    result = TryGetLegacyLogger(sourceType);

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetLogForType: *** SUCCESS *** The property, 'LoggingSubsystemManager.CurrentClientSession', has a valid object reference for its value.  Proceeding..."
                );

                // Check whether a specialized logging-client session is active.  If this is not the
                // case, then obtain the logger from the ordinary log4net repository and return it.
                if (LoggingSubsystemManager.CurrentClientSession == null)
                {
                    result = TryGetLegacyLogger(sourceType);

                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetLogForType: Checking whether the current logging-client session has valid setting(s)..."
                );

                // Check whether the current logging-client session has valid setting(s). If this is
                // not the case, then use the ordinary legacy repository.
                if (!LoggingSubsystemManager.CurrentClientSession.IsValid())
                {
                    // The current logging-client session does NOT have valid setting(s). There is
                    // no usable specialized session.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.GetLogForType: *** WARNING *** The current logging-client session does NOT have valid setting(s).  There is no usable specialized session."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Using the ordinary legacy repository to get a reference to an instance of the logger that corresponds to the source type, '{sourceType.FullName}'..."
                    );

                    result = TryGetLegacyLogger(sourceType);

                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetLogForType: *** SUCCESS *** The current logging-client session has valid setting(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.GetLogForType: Checking whether the current logging-client session repository name, '{LoggingSubsystemManager.CurrentClientSession.RepositoryName}', is blank..."
                );

                // Check whether the current logging-client session repository name is blank.  If
                // this is the case, then terminate the execution of this method without falling
                // back to another component's repository.
                if (string.IsNullOrWhiteSpace(
                        LoggingSubsystemManager.CurrentClientSession.RepositoryName
                    ))
                {
                    // The current logging-client session repository name is blank. This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLogProvider.GetLogForType: *** ERROR *** The current logging-client session repository name, '{LoggingSubsystemManager.CurrentClientSession.RepositoryName}', is blank.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.GetLogForType: *** SUCCESS *** The repository name, '{LoggingSubsystemManager.CurrentClientSession.RepositoryName}', is not blank.  Proceeding..."
                );

                result = GetSessionLogger(
                    LoggingSubsystemManager.CurrentClientSession.RepositoryName, sourceType
                );
            }
            catch (Exception ex)
            {
                /* Do not call DebugUtils.LogException from this class. This class is utilized by
                 DebugUtils and doing so could recursively re-enter the logger-resolution path. */

                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null

                    // ReSharper disable once ConstantConditionalAccessQualifier
                    ? $"*** SUCCESS *** Obtained a reference to a logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to a logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface from the specified named repository.
        /// </summary>
        /// <param name="repositoryName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the name of the repository from which the logger is to be obtained.
        /// </param>
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
        /// If <paramref name="repositoryName" /> is blank, or
        /// <paramref name="sourceType" /> is <see langword="null" />, then this method
        /// returns <see langword="null" />.
        /// <para />
        /// This method does not fall back to the ordinary repository because doing so
        /// could cause logging record(s) from one in-process component to be written to
        /// another component's log file.
        /// </remarks>
        [return: NotLogged]
        [Log(AttributeExclude = true), DebuggerStepThrough]
        private ILog GetSessionLogger(
            [NotLogged] string repositoryName,
            [NotLogged] Type sourceType
        )
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetSessionLogger: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.GetSessionLogger: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetSessionLogger: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine($"LoggingClientLogProvider.GetSessionLogger: *** FYI *** Getting a reference to an instance of the logger that corresponds to the source type, '{sourceType.FullName}' from the internal cache...");

                var logger = TryGetLoggerFromInternalCache(sourceType);

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetSessionLogger: Checking whether the variable, 'logger', has a null reference for a value..."
                );

                // Check to see if the variable, 'logger', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (logger == null)
                {
                    // The variable, 'logger', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.GetSessionLogger: *** ERROR ***  The variable, 'logger', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'logger', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.GetSessionLogger: *** SUCCESS *** The variable, 'logger', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.GetSessionLogger: *** FYI *** Getting a reference to an instance of the logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}' from the repository, '{repositoryName ?? "<null>"}'..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "LoggingClientLogProvider.GetSessionLogger *** INFO: Checking whether the value of the parameter, 'repositoryName', is blank..."
                );

                // Check whether the value of the parameter, 'repositoryName', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(repositoryName))
                {
                    // The parameter, 'repositoryName' was either passed a null value, or it is
                    // blank.  There is nothing to do.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "LoggingClientLogProvider.GetSessionLogger: The parameter, 'repositoryName' was either passed a null value, or it is blank. Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** SUCCESS *** The parameter, 'repositoryName', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to get a reference to an instance of the logger that corresponds to the source type, '{sourceType.FullName}' from the repository, '{repositoryName}'..."
                );

                result = LogManager.GetLogger(repositoryName, sourceType);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null

                    // ReSharper disable once ConstantConditionalAccessQualifier
                    ? $"*** SUCCESS *** Obtained a reference to the logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}' and repository name, '{repositoryName ?? "<null>"}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to the logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}' and repository name, '{repositoryName ?? "<null>"}'.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Ascertains whether a reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface is available for the specified
        /// <paramref name="sourceType" /> in the internal cache.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of <see cref="T:System.Type" /> that
        /// reflects the type for which to obtain the logger.
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
        ///     cref="F:xyLOGIX.Core.Debug.LoggingClientLogProvider._sourceTypeFQNToLogMap" />
        /// collection is set to a <see langword="null" /> reference, or if it contains
        /// zero element(s).
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if a key exists in the internal cache that
        /// matches the value of the <see cref="P:System.Type.FullName" /> property;
        /// <see langword="false" /> otherwise.
        /// </returns>
        [Log(AttributeExclude = true), DebuggerStepThrough]
        private bool IsLogAvailableForType([NotLogged] Type sourceType)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.IsLogAvailableForType: *** FYI *** Determining whether a logger is available for the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.IsLogAvailableForType: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is,
                // then write an error message to the log file and then terminate the
                // execution of this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed
                    // to have a NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.IsLogAvailableForType: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientLogProvider.IsLogAvailableForType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.IsLogAvailableForType: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                // Dump the value of the property, sourceType.FullName, to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"sourceType.FullName = '{sourceType.FullName}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'sourceType.FullName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'sourceType.FullName', appears to have a
                // null 
                // or blank value. If it does, then send an error to the log file and quit,
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
                        $"LoggingClientLogProvider.IsLogAvailableForType: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'sourceType.FullName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.IsLogAvailableForType: Checking whether the field, '_sourceTypeFQNToLogMap', does NOT have a null reference for a value..."
                );

                // Check to see if the field, _sourceTypeFQNToLogMap, is NOT null.  If this is the
                // case, 
                // then write an FYI message to the Debug output and then terminate the
                // execution of this method, and then return the default value of the 'result'
                // variable.  We need the field to currently be set to a NULL reference in order
                // to be able to proceed.
                if (_sourceTypeFQNToLogMap != null)
                {
                    // The field, _sourceTypeFQNToLogMap, must be set to a NULL reference for this
                    // method to work.
                    // Since this is not the case, then we can't do anything more here.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.IsLogAvailableForType: *** FYI *** The field, '_sourceTypeFQNToLogMap', does NOT have a null reference.  Nothing to do."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientLogProvider.IsLogAvailableForType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.IsLogAvailableForType: *** SUCCESS *** The field, '_sourceTypeFQNToLogMap', has a NULL reference for its current value, which is what we are looking for.  Proceeding..."
                );

                lock (SyncRoot)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** LoggingClientLogProvider.IsLogAvailableForType: Checking whether the '_sourceTypeFQNToLogMap' collection contains greater than zero elements..."
                    );

                    // Check to see whether the '_sourceTypeFQNToLogMap' collection contains greater
                    // than
                    // zero elements.  Otherwise, write an error message to the Debug output, return
                    // the default return value, and then terminate the execution of this method.
                    if (_sourceTypeFQNToLogMap.Count <= 0)
                    {
                        // The '_sourceTypeFQNToLogMap' collection contains zero elements.  This is
                        // not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR *** The '_sourceTypeFQNToLogMap' collection contains zero elements.  Stopping..."
                        );

                        System.Diagnostics.Debug.WriteLine(
                            $"LoggingClientLogProvider.IsLogAvailableForType: Result = {result}"
                        );

                        // stop.
                        return result;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLogProvider.IsLogAvailableForType: *** SUCCESS *** {_sourceTypeFQNToLogMap.Count} element(s) were found in the '_sourceTypeFQNToLogMap' collection.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLogProvider.IsLogAvailableForType: Checking whether the internal cache contains the key, '{sourceType.FullName}'..."
                    );

                    // Check to see whether the internal cache contains the key,
                    // '{sourceType.FullName}'.
                    // If this is not the case, then write an error message to the log file,
                    // and then terminate the execution of this method.
                    if (!_sourceTypeFQNToLogMap.ContainsKey(sourceType.FullName))
                    {
                        // The internal cache does NOT appear to contain the desired key.  This is
                        // not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            $"LoggingClientLogProvider.IsLogAvailableForType: *** ERROR *** The internal cache does NOT appear to contain the key, '{sourceType.FullName}'.  Stopping..."
                        );

                        System.Diagnostics.Debug.WriteLine(
                            $"*** LoggingClientLogProvider.IsLogAvailableForType: Result = {result}"
                        );

                        // stop.
                        return result;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLogProvider.IsLogAvailableForType: *** SUCCESS *** The internal cache contains the key, '{sourceType.FullName}'.  Proceeding..."
                    );

                    /*
                     * If we made it this far with no Exception(s) getting caught, then
                     * assume that the operation(s) succeeded.
                     */

                    result = true;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"LoggingClientLogProvider.IsLogAvailableForType: Result = {result}"
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
        private static ILog TryGetLegacyLogger([NotLogged] Type sourceType)
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.TryGetLegacyLogger: *** FYI *** Attempting to get a reference to an instance of the legacy logger that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.TryGetLegacyLogger: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.TryGetLegacyLogger: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.TryGetLegacyLogger: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
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
        /// Looks up the specified <paramref name="sourceType" /> in the internal cache; if
        /// found, returns a reference to an instance of an object that implements the
        /// <see cref="T:log4net.ILog" /> interface that can be utilized for logging.
        /// </summary>
        /// <param name="sourceType">
        /// (Required.) Reference to an instance of <see cref="T:System.Type" /> that
        /// identifies the source of the logging record(s).
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:log4net.ILog" /> interface; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        private ILog TryGetLoggerFromInternalCache([NotLogged] Type sourceType)
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.TryGetLoggerFromInternalCache: *** FYI *** Getting a logger from the internal cache that corresponds to the source type, '{sourceType?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.TryGetLoggerFromInternalCache: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'sourceType', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', is required and is not supposed to have a
                    // NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.TryGetLoggerFromInternalCache: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.TryGetLoggerFromInternalCache: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'sourceType'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'sourceType.FullName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'sourceType.FullName', appears to have a
                // null 
                // or blank value. If it does, then send an error to the log file and quit,
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
                        $"LoggingClientLogProvider.TryGetLoggerFromInternalCache: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'sourceType.FullName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.TryGetLoggerFromInternalCache: Checking whether the specified source type, '{sourceType.FullName}', has a logger available..."
                );

                // Check to see whether the specified source type has a logger available.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!IsLogAvailableForType(sourceType))
                {
                    // The specified source type does NOT appear to have a logger available.  This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientLogProvider.TryGetLoggerFromInternalCache: *** ERROR *** The specified source type, '{sourceType.FullName}', does NOT appear to have a logger available.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.TryGetLoggerFromInternalCache: *** SUCCESS *** The specified source type has a logger available.  Proceeding..."
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
                    ? $"*** SUCCESS *** Obtained a reference to a logger that corresponds to the specified source type, '{sourceType?.FullName ?? "<null>"}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to a logger that corresponds to the specified source type, '{sourceType?.FullName ?? "<null>"}'.  Stopping..."
            );

            return result;
        }
    }
}