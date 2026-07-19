using Alphaleonis.Win32.Filesystem;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Methods to be used to manage the application log.</summary>
    [Log(AttributeExclude = true)]
    public static class LoggingSubsystemManager
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingSubsystemManager" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingSubsystemManager()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Initializing the LoggingSubsystemManager class..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Checking whether we're being hosted inside a VSIX..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** LoggingSubsystemManager.LoggingSubsystemManager: Checking whether the code is being hosted inside a VSIX..."
                );

                // Check to see whether the code is being hosted inside a VSIX. If this is not the
                // case, then write an FYI message to the log file and then terminate the execution
                // of this method.
                if (!VsixHosting.IsVsixHost())
                {
                    // The code is NOT being hosted inside a VSIX.  Just a FYI.
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI ***  The code is NOT being hosted inside a VSIX.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.LoggingSubsystemManager: *** SUCCESS *** The code is being hosted inside a VSIX.  Ensuring that this code is resolved correctly..."
                );

                VsixHosting.EnsureAssemblyResolver();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderManager" /> interface.
        /// </summary>
        private static IAppenderManager AppenderManager { [DebuggerStepThrough] get; } =
            GetAppenderManager.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientAssemblyContext" /> interface.
        /// </summary>
        private static ILoggingClientAssemblyContext ClientAssemblyContext
        {
            [DebuggerStepThrough]
            get => GetLoggingClientAssemblyContext.SoleInstance();
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry" /> interface.
        /// </summary>
        private static ILoggingClientAssemblyRegistry ClientAssemblyRegistry
        {
            [DebuggerStepThrough]
            get;
        } = GetLoggingClientAssemblyRegistry.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSessionRegistry" /> interface.
        /// </summary>
        private static ILoggingClientSessionRegistry ClientSessionRegistry
        {
            [DebuggerStepThrough]
            get;
        } = GetLoggingClientSessionRegistry.SoleInstance();

        /// <summary>
        /// Gets the logging-client assembly associated with the current logical
        /// execution flow.
        /// </summary>
        /// <remarks>
        /// If no logging-client assembly is currently selected, the corresponding
        /// registration cannot be found, or the operation fails, then this property
        /// returns <see langword="null" />.
        /// </remarks>
        internal static Assembly CurrentClientAssembly
        {
            [DebuggerStepThrough]
            get
            {
                var result = default(Assembly);

                try
                {
                    var ticket = CurrentClientAssemblyTicket;

                    if (Guid.Empty.Equals(ticket)) return result;
                    if (ClientAssemblyRegistry == null) return result;

                    result = ClientAssemblyRegistry.GetAssembly(ticket);
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = default;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the ticket that identifies the logging-client assembly associated
        /// with the current logical execution flow.
        /// </summary>
        /// <remarks>
        /// If no logging-client assembly is currently selected, the
        /// client-assembly context is unavailable, or the property cannot be evaluated,
        /// then this property returns <see cref="F:System.Guid.Empty" />.
        /// </remarks>
        internal static Guid CurrentClientAssemblyTicket
        {
            [DebuggerStepThrough]
            get
            {
                var result = Guid.Empty;

                try
                {
                    if (ClientAssemblyContext == null) return result;

                    result = ClientAssemblyContext.CurrentTicket;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = Guid.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to the PostSharp logging backend assigned to the
        /// current logging-client session.
        /// </summary>
        /// <remarks>
        /// If no current logging-client session exists, this property returns
        /// <see langword="null" />.
        /// </remarks>
        internal static LoggingBackend CurrentClientBackend
        {
            [DebuggerStepThrough]
            get
            {
                var result = default(LoggingBackend);

                try
                {
                    var session = CurrentClientSession;

                    if (session == null) return result;

                    result = session.Backend;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = default;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to the log4net repository assigned to the current
        /// logging-client session.
        /// </summary>
        /// <remarks>
        /// If no current logging-client session exists, this property returns
        /// <see langword="null" />.
        /// </remarks>
        internal static ILoggerRepository CurrentClientRepository
        {
            [DebuggerStepThrough]
            get
            {
                ILoggerRepository result = default;

                try
                {
                    var session = CurrentClientSession;

                    if (session == null) return result;

                    result = session.Repository;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = null;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the logging-client session associated with the current logical
        /// execution flow.
        /// </summary>
        /// <remarks>
        /// If no logging-client assembly is currently selected, or no session has
        /// been created for the selected ticket, this property returns
        /// <see langword="null" />.
        /// </remarks>
        internal static ILoggingClientSession CurrentClientSession
        {
            [DebuggerStepThrough]
            get
            {
                ILoggingClientSession result = default;

                try
                {
                    if (Guid.Empty.Equals(CurrentClientAssemblyTicket)) return result;
                    if (ClientSessionRegistry == null) return result;

                    result = ClientSessionRegistry.Get(CurrentClientAssemblyTicket);
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = default;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:LoggingInfrastructureType" /> value that
        /// represents the type of infrastructure currently in use by this
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingSubsystemManager" />.
        /// </summary>
        public static LoggingInfrastructureType InfrastructureType
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>Gets the full path and filename to the log file for this application.</summary>
        /// <remarks>
        /// This property should only be called after the
        /// <see cref="M:xyLOGIX.Core.Debug.LoggingSubsystemManager.InitializeLogging" />
        /// method has been called.
        /// </remarks>
        public static string LogFileName
        {
            [DebuggerStepThrough]
            get
            {
                var result = string.Empty;

                try
                {
                    if (LoggingInfrastructure == null) return result;

                    result = LoggingInfrastructure.GetRootFileAppenderFileName();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = string.Empty;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructure" /> interface that
        /// corresponds to the value of the <see cref="P:Type" /> property.
        /// </summary>
        private static ILoggingInfrastructure LoggingInfrastructure
        {
            [DebuggerStepThrough]
            get => GetLoggingInfrastructure.OfType(InfrastructureType);
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingInfrastructureTypeValidator LoggingInfrastructureTypeValidator
        {
            [DebuggerStepThrough]
            get;
        } = GetLoggingInfrastructureTypeValidator.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter" /> interface.
        /// </summary>
        private static IPostSharpLoggingBackendRouter PostSharpBackendRouter
        {
            [DebuggerStepThrough]
            get;
        } = GetPostSharpLoggingBackendRouter.SoleInstance();

        /// <summary>
        /// Ensures that a logging-client session exists when a logging-client
        /// assembly has been selected.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if no specialized logging client is selected,
        /// or a valid logging-client session exists; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// Applications that do not register a specialized in-process logging
        /// client continue through the legacy initialization path.
        /// <para />
        /// If a specialized logging client has been selected but its session cannot be
        /// created, this method returns <see langword="false" /> so initialization does
        /// not silently fall back to another component's repository.
        /// </remarks>
        private static bool EnsureCurrentClientSession()
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.EnsureCurrentClientSession: *** FYI *** Ensuring that a logging-client session exists for the currently selected logging-client assembly..."
                );

                result = true;

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.EnsureCurrentClientSession: *** INFO *** Checking whether the Current Client Assembly Ticket property, 'CurrentClientAssemblyTicket', is set to the Zero GUID..."
                );

                // Check whether the value of the Current Client Assembly Ticket property,
                // 'CurrentClientAssemblyTicket', is set to the Zero GUID.  If this is the case,
                // then write an error message to the Debug output, and then terminate the execution
                // of this method, returning the default return value.
                if (Guid.Empty.Equals(CurrentClientAssemblyTicket))
                {
                    // The value of the Current Client Assembly Ticket property,
                    // 'CurrentClientAssemblyTicket', is set to the Zero GUID.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The value of the Current Client Assembly Ticket property, 'CurrentClientAssemblyTicket', is set to the Zero GUID.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.EnsureCurrentClientSession: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.EnsureCurrentClientSession: *** SUCCESS *** The value of the Current Client Assembly Ticket property, 'CurrentClientAssemblyTicket', is NOT set to the Zero GUID; in fact, it is set to '{CurrentClientAssemblyTicket}'.  Proceeding..."
                );

                result = false;

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to get or create the logging-client session for the ticket, '{CurrentClientAssemblyTicket}'..."
                );

                var session = GetOrCreateCurrentClientSession();

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.EnsureCurrentClientSession: Checking whether the variable, 'session', has a null reference for a value..."
                );

                // Check to see if the variable, 'session', has a null reference for a value. If it
                // does, then emit an error to the Debug output, and terminate the execution of this
                // method, returning the default return value.
                if (session == null)
                {
                    // The variable, 'session', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.EnsureCurrentClientSession: *** ERROR ***  The variable, 'session', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.EnsureCurrentClientSession: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'session', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.EnsureCurrentClientSession: *** SUCCESS *** The variable, 'session', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Checking whether the logging-client session for the current client assembly ticket, '{CurrentClientAssemblyTicket}', is valid..."
                );

                result = session.IsValid();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                result
                    ? "*** SUCCESS *** Ensured that a current logging-client session is in place.  Proceeding..."
                    : "*** ERROR *** FAILED to ensure that a current logging-client session is in place.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Gets the log4net repository associated with the current process-wide
        /// PostSharp default backend.
        /// </summary>
        /// <returns>
        /// Reference to the repository associated with the current
        /// <see
        ///     cref="T:PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend" />
        /// ; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If the current PostSharp default backend is not a
        /// <see
        ///     cref="T:PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend" />
        /// , this method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        private static ILoggerRepository GetDefaultBackendRepository()
        {
            ILoggerRepository result = default;

            try
            {
                if (!(LoggingServices.DefaultBackend is Log4NetLoggingBackend backend))
                    return result;
                if (backend.Repository == null) return result;

                result = backend.Repository;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
        }

        /// <summary>
        /// Gets the ordinary log4net repository that should be retained while a
        /// specialized logging-client session is initialized.
        /// </summary>
        /// <returns>
        /// Reference to the ordinary fallback repository; otherwise,
        /// <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If the PostSharp routing backend is already installed, its existing
        /// fallback repository is returned.
        /// <para />
        /// Otherwise, the repository associated with the current PostSharp default backend
        /// is returned.
        /// </remarks>
        [return: NotLogged]
        private static ILoggerRepository GetLegacyRepositoryBeforeInitialization()
        {
            ILoggerRepository result;

            try
            {
                if (PostSharpBackendRouter != null)
                {
                    if (PostSharpBackendRouter.IsInstalled)
                    {
                        result = PostSharpBackendRouter.FallbackRepository;

                        return result;
                    }
                }

                result = GetDefaultBackendRepository();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
        }

        /// <summary>
        /// Gets or creates the logging-client session associated with the
        /// currently selected logging-client assembly.
        /// </summary>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSession" /> interface; otherwise,
        /// <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If no logging-client assembly is currently selected, its registration
        /// cannot be resolved, or session creation fails, this method returns
        /// <see langword="null" />.
        /// <para />
        /// This method does not assign the session backend to
        /// <see cref="P:PostSharp.Patterns.Diagnostics.LoggingServices.DefaultBackend" />.
        /// </remarks>
        [return: NotLogged]
        private static ILoggingClientSession GetOrCreateCurrentClientSession()
        {
            ILoggingClientSession result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** FYI *** Attempting to get or create the logging-client session for the " +
                    $"ticket, '{CurrentClientAssemblyTicket}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** INFO *** Checking whether the current client assembly ticket property, 'CurrentClientAssemblyTicket', is set to the Zero GUID..."
                );

                // Check whether the value of the current client assembly ticket property,
                // 'CurrentClientAssemblyTicket', is set to the Zero GUID.  If this is the case,
                // then write an error message to the Debug output, and then terminate the execution
                // of this method, returning the default return value.
                if (Guid.Empty.Equals(CurrentClientAssemblyTicket))
                {
                    // The value of the current client assembly ticket property,
                    // 'CurrentClientAssemblyTicket', is set to the Zero GUID.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The value of the current client assembly ticket property, 'CurrentClientAssemblyTicket', is set to the Zero GUID.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** SUCCESS *** The value of the current client assembly ticket property, 'CurrentClientAssemblyTicket', is NOT set to the Zero GUID; in fact, it is set to '{CurrentClientAssemblyTicket}'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetOrCreateCurrentClientSession: Checking whether the property, 'CurrentClientAssembly', has a null reference for a value..."
                );

                // Check to see if the required property, 'CurrentClientAssembly', has a null
                // reference for a value.  If that is the case, then we will write an error message
                // to the Debug output, and then terminate the execution of this method, while
                // returning the default return value.
                if (CurrentClientAssembly == null)
                {
                    // The property, 'CurrentClientAssembly', has a null reference for a value. This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** ERROR *** The property, 'CurrentClientAssembly', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** SUCCESS *** The property, 'CurrentClientAssembly', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetOrCreateCurrentClientSession: Checking whether the property, 'ClientSessionRegistry', has a null reference for a value..."
                );

                // Check to see if the required property, 'ClientSessionRegistry', has a null
                // reference for a value.  If that is the case, then we will write an error message
                // to the Debug output, and then terminate the execution of this method, while
                // returning the default return value.
                if (ClientSessionRegistry == null)
                {
                    // The property, 'ClientSessionRegistry', has a null reference for a value. This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** ERROR *** The property, 'ClientSessionRegistry', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.GetOrCreateCurrentClientSession: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** SUCCESS *** The property, 'ClientSessionRegistry', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Getting or creating the logging-client session for the current client assembly ticket, '{CurrentClientAssemblyTicket}'..."
                );

                result = ClientSessionRegistry.GetOrCreate(
                    CurrentClientAssemblyTicket, CurrentClientAssembly
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetOrCreateCurrentClientSession: Checking whether the variable, 'result', has a null reference for a value..."
                );

                // Check to see if the variable, 'result', has a null reference for a value. If it
                // does, then emit an error to the Debug output, and terminate the execution of this
                // method, returning the default return value.
                if (result == null)
                {
                    // The variable, 'result', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** ERROR ***  The variable, 'result', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'result', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** SUCCESS *** The variable, 'result', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Checking whether the logging-client session for the current client assembly ticket, '{CurrentClientAssemblyTicket}', is valid..."
                );

                // Check to see whether the logging-client session for the current client assembly
                // ticket is valid. If it is not, then write an error message to the Debug output,
                // and then terminate the execution of this method, returning the default return
                // value.
                if (!result.IsValid())
                {
                    // The logging-client session for the current client assembly ticket is NOT
                    // valid.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.GetOrCreateCurrentClientSession: *** ERROR *** The logging-client session for the current client assembly ticket, '{CurrentClientAssemblyTicket}', is NOT valid.  Stopping..."
                    );

                    // set the return value of this method to a null reference.
                    result = default;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to the logging-client session that corresponds to the specified assembly ticket, '{CurrentClientAssemblyTicket}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to the logging-client session that corresponds to the specified assembly ticket, '{CurrentClientAssemblyTicket}'.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Gets a reference to the log4net repository that should be configured
        /// for the current logging operation.
        /// </summary>
        /// <returns>
        /// Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> associated with the
        /// current specialized logging-client session; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If no specialized logging-client session is active, this method
        /// returns <see langword="null" />.
        /// <para />
        /// A <see langword="null" /> return value instructs the existing logging
        /// infrastructure to utilize its legacy repository-selection behavior.
        /// <para />
        /// If the current session is invalid or the operation fails, this method returns
        /// <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        private static ILoggerRepository GetRepositoryToConfigure()
        {
            ILoggerRepository result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetRepositoryToConfigure: Checking whether the property, 'CurrentClientSession', has a null reference for a value..."
                );

                // Check to see if the required property, 'CurrentClientSession', has a null
                // reference for a value.  If that is the case, then we will write an error message
                // to the Debug output, and then terminate the execution of this method, while
                // returning the default return value.
                if (CurrentClientSession == null)
                {
                    // The property, 'CurrentClientSession', has a null reference for a value.  This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.GetRepositoryToConfigure: *** ERROR *** The property, 'CurrentClientSession', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetRepositoryToConfigure: *** SUCCESS *** The property, 'CurrentClientSession', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetRepositoryToConfigure: Checking whether the current logging-client session has valid setting(s)..."
                );

                // Check to see whether the current logging-client session has valid setting(s).  If
                // this is not the case, then write an error message to the log file, and then
                // terminate the execution of this method.
                if (!CurrentClientSession.IsValid())
                {
                    // The current logging-client session does NOT appear to have valid setting(s).
                    // There is nothing to do.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.GetRepositoryToConfigure: *** ERROR *** The current logging-client session does NOT appear to have valid setting(s).  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.GetRepositoryToConfigure: *** SUCCESS *** The current logging-client session has valid setting(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Getting a reference to an instance of the log4net repository that should be configured for the current logging operation..."
                );

                result = CurrentClientSession.Repository;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to an instance of the log4net repository that should be configured for the current logging session.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to an instance of the log4net repository that should be configured for the current logging session.  Stopping..."
            );

            return result;
        }

        /// <summary>Initializes the application's logging subsystem.</summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// Set to true if we should not write
        /// out "DEBUG" messages to the log file when in the Release mode. Set to false if
        /// all messages should always be logged.
        /// </param>
        /// <param name="overwrite">
        /// Overwrites any existing logs for the application with
        /// the latest logging sent out by this instance.
        /// </param>
        /// <param name="configurationFileName">
        /// Specifies the path to the configuration
        /// file to be utilized for initializing log4net. If blank, the system attempts to
        /// utilize the default App.config file.
        /// </param>
        /// <param name="muteConsole">
        /// Set to <see langword="true" /> to suppress the
        /// display of logging messages to the console if a log file is being used. If a
        /// log file is not used, then no logging at all will occur if this parameter is
        /// set to <see langword="true" />.
        /// </param>
        /// <param name="logFileName">
        /// (Optional.) If blank, then the <c>XMLConfigurator</c>
        /// object is used to configure logging.
        /// <para />
        /// Else, specify here the path to the log file to be created.
        /// </param>
        /// <param name="verbosity">
        /// (Optional.) An <see cref="T:System.Int32" /> whose
        /// value must be <c>0</c> or greater.
        /// <para />
        /// Indicates the verbosity level.
        /// <para />
        /// Higher values mean more verbose.
        /// <para />
        /// if the <paramref name="verbosity" /> parameter is negative, it will be ignored.
        /// <para />
        /// The default value of this parameter is <c>1</c>.
        /// </param>
        /// <param name="applicationName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing a user-friendly display name of the application that is using this
        /// logging library.
        /// <para />
        /// Leave blank to use the default value.
        /// </param>
        /// <param name="infrastructureType">
        /// (Optional.) One of the
        /// <see cref="T:LoggingInfrastructureType" /> value(s) that indicates what type of
        /// logging infrastructure is to be utilized (default or PostSharp, for example).
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the logging subsystem has been initialized
        /// successfully; <see langword="false" /> otherwise.
        /// </returns>
        public static bool InitializeLogging(
            bool muteDebugLevelIfReleaseMode = true,
            bool overwrite = true,
            [NotLogged] string configurationFileName = "",
            bool muteConsole = false,
            [NotLogged] string logFileName = "",
            int verbosity = 1,
            [NotLogged] string applicationName = "",
            LoggingInfrastructureType infrastructureType = LoggingInfrastructureType.Default
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: *** FYI *** Received a request to initialize the logging subsystem..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: Checking whether the current logging-client session is available..."
                );

                // Check to see whether the current logging-client session is available. If it is
                // not, then write an error message to the Debug output, and then terminate the
                // execution of this method, returning the default return value.
                if (!EnsureCurrentClientSession())
                {
                    // The current logging-client session is NOT available.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.InitializeLogging: *** ERROR *** A specialized logging client is selected, but its logging session could NOT be created.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: *** SUCCESS *** Either no specialized logging client is selected, or its logging session is available.  Proceeding..."
                );

                var selectedSession = CurrentClientSession;

                var specializedSessionWasActive = false;

                if (selectedSession != null)
                {
                    specializedSessionWasActive = selectedSession.IsValid();
                }

                var legacyRepositoryBeforeInitialization =
                    GetLegacyRepositoryBeforeInitialization();

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.InitializeLogging: *** FYI *** Attempting to delete the file, '{DebugUtils.ExceptionLogPathname}', if it exists..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** LoggingSubsystemManager.InitializeLogging: Checking whether the file, '{DebugUtils.ExceptionLogPathname}', either could be successfully deleted, or it never existed in the first place..."
                );

                // Check to see whether the file, 'DebugUtils.ExceptionLogPathname', could be
                // successfully deleted. If this is not the case, then write an error message to the
                // Debug output, and then terminate the execution of this method.
                if (File.Exists(DebugUtils.ExceptionLogPathname) &&
                    !DebugUtils.ClearTempExceptionLog())
                {
                    // The file, 'DebugUtils.ExceptionLogPathname', could NOT be successfully
                    // deleted.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.InitializeLogging: *** ERROR *** The file, '{DebugUtils.ExceptionLogPathname}', could NOT be successfully deleted.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.InitializeLogging: *** SUCCESS *** Either the file, '{DebugUtils.ExceptionLogPathname}', could be successfully deleted, or it never existed in the first place.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** LoggingSubsystemManager.InitializeLogging: Checking whether the specified Logging Infrastructure Type value, '{infrastructureType}', is valid..."
                );

                // Check to see whether the specified Logging Infrastructure Type is valid. If this
                // is not the case, then write an error message to the Debug output, and then
                // terminate the execution of this method.
                if (!Validate.LoggingInfrastructureType(infrastructureType))
                {
                    // The specified Logging Infrastructure Type value is NOT valid.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.InitializeLogging: *** ERROR *** The specified Logging Infrastructure Type value, '{infrastructureType}', is NOT valid.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.InitializeLogging: *** SUCCESS *** The specified Logging Infrastructure Type value, '{infrastructureType}', is valid.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.InitializeLogging: Setting the infrastructure type to '{infrastructureType}'..."
                );

                InfrastructureType = infrastructureType;

                /* We now 'outsource' the functionality of this method (and all the other methods of
                 this class) to an 'infrastructure' object that follows (loosely) the Abstract
                 Factory pattern. Either we use the Default way of initializing logging or we do
                 things the way PostSharp needs us to. */

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: Checking whether the property, 'LoggingInfrastructure', has a null reference for a value..."
                );

                // Check to see if the required property, 'LoggingInfrastructure', has a null
                // reference for a value. If that is the case, then we will write an error message
                // to the Debug output, and then terminate the execution of this method, while
                // returning the default return value.
                if (LoggingInfrastructure == null)
                {
                    // The property, 'LoggingInfrastructure', has a null reference for a value. This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.InitializeLogging: *** ERROR *** The property, 'LoggingInfrastructure', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.InitializeLogging: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: *** SUCCESS *** The property, 'LoggingInfrastructure', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: Proceeding to task the logging infrastructure to initialize itself..."
                );

                result = LoggingInfrastructure.InitializeLogging(
                    muteDebugLevelIfReleaseMode, overwrite, configurationFileName, muteConsole,
                    logFileName, verbosity, applicationName
                );

                if (!result) return result;

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: Reconciling the process-wide PostSharp logging-backend routing state..."
                );

                if (!ReconcilePostSharpBackendRouting(
                        specializedSessionWasActive, legacyRepositoryBeforeInitialization
                    ))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.InitializeLogging: *** ERROR *** The process-wide PostSharp logging-backend routing state could NOT be reconciled.  Stopping..."
                    );

                    result = false;

                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.InitializeLogging: *** SUCCESS *** The process-wide PostSharp logging-backend routing state was successfully reconciled.  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingSubsystemManager.InitializeLogging: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Reconciles the process-wide PostSharp backend after logging
        /// initialization completes.
        /// </summary>
        /// <param name="specializedSessionWasActive">
        /// (Required.) A
        /// <see cref="T:System.Boolean" /> value indicating whether a valid specialized
        /// logging-client session was active when initialization began.
        /// </param>
        /// <param name="legacyRepositoryBeforeInitialization">
        /// (Optional.) Reference to the
        /// ordinary log4net repository that was active before initialization began.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if no routing work was required, or the
        /// PostSharp routing backend was successfully installed or updated; otherwise,
        /// <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// If no specialized session has ever been selected and the router has
        /// not been installed, this method returns <see langword="true" /> without
        /// changing
        /// <see cref="P:PostSharp.Patterns.Diagnostics.LoggingServices.DefaultBackend" />.
        /// <para />
        /// Once the router has been installed, ordinary initialization updates its
        /// fallback repository and restores the routing backend if another initializer
        /// replaced it.
        /// </remarks>
        private static bool ReconcilePostSharpBackendRouting(
            bool specializedSessionWasActive,
            [NotLogged] ILoggerRepository legacyRepositoryBeforeInitialization
        )
        {
            var result = false;

            try
            {
                if (PostSharpBackendRouter == null)
                {
                    if (!specializedSessionWasActive)
                    {
                        result = true;
                    }

                    return result;
                }

                if (!specializedSessionWasActive)
                {
                    if (!PostSharpBackendRouter.IsInstalled)
                    {
                        result = true;

                        return result;
                    }

                    result = PostSharpBackendRouter.InstallOrUpdate(GetDefaultBackendRepository());

                    return result;
                }

                if (CurrentClientSession == null) return result;
                if (!CurrentClientSession.IsValid()) return result;

                if (legacyRepositoryBeforeInitialization != null)
                {
                    if (ReferenceEquals(
                            legacyRepositoryBeforeInitialization, CurrentClientSession.Repository
                        ))
                    {
                        legacyRepositoryBeforeInitialization = default;
                    }
                }

                result = PostSharpBackendRouter.InstallOrUpdate(
                    legacyRepositoryBeforeInitialization
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Registers the specified assembly as a logging client and selects it
        /// for the current logical execution flow.
        /// </summary>
        /// <param name="assembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that is requesting logging
        /// services.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Guid" /> value that identifies the registered
        /// and selected logging-client assembly; otherwise,
        /// <see cref="F:System.Guid.Empty" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="assembly" /> is <see langword="null" />, the
        /// assembly cannot be registered, or its ticket cannot be selected for the current
        /// logical execution flow, then this method returns
        /// <see cref="F:System.Guid.Empty" />.
        /// <para />
        /// Registering an assembly that has already been registered reuses its existing
        /// ticket.
        /// <para />
        /// Because this method may execute before the logging subsystem has been
        /// initialized, exception information is written directly to the Debug output.
        /// </remarks>
        [return: NotLogged]
        public static Guid RegisterAndSelectClientAssembly([NotLogged] Assembly assembly)
        {
            var result = Guid.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterAndSelectClientAssembly: Checking whether the method parameter, 'assembly', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'assembly', is null. If it is, then write
                // an error message to the log file and then terminate the execution of this method,
                // returning the default return value.
                if (assembly == null)
                {
                    // The method parameter, 'assembly', is required and is not supposed to have a
                    // NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.RegisterAndSelectClientAssembly: *** ERROR *** A null reference was passed for the method parameter, 'assembly'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.RegisterAndSelectClientAssembly: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterAndSelectClientAssembly: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'assembly'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to register the assembly, '{assembly.FullName}', as a logging-client assembly..."
                );

                result = RegisterClientAssembly(assembly);

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterAndSelectClientAssembly: Checking whether the specified assembly was successfully registered..."
                );

                // Check whether the specified assembly was successfully registered.  If this is not
                // the case, then write an error message to the Debug output, and then terminate the
                // execution of this method, returning the default return value.
                if (Guid.Empty.Equals(result))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.RegisterAndSelectClientAssembly: *** ERROR *** The assembly, '{assembly.FullName}', could NOT be successfully registered.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.RegisterAndSelectClientAssembly: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.RegisterAndSelectClientAssembly: *** SUCCESS *** The assembly, '{assembly.FullName}', was successfully registered with the ticket, '{result}'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterAndSelectClientAssembly: Checking whether the property, 'ClientAssemblyContext', has a null reference for a value..."
                );

                // Check to see if the required property, 'ClientAssemblyContext', has a null
                // reference for a value.  If that is the case, then we will write an error message
                // to the Debug output, and then terminate the execution of this method, while
                // returning the default return value.
                if (ClientAssemblyContext == null)
                {
                    // The property, 'ClientAssemblyContext', has a null reference for a value. This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.RegisterAndSelectClientAssembly: *** ERROR *** The property, 'ClientAssemblyContext', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.RegisterAndSelectClientAssembly: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterAndSelectClientAssembly: *** SUCCESS *** The property, 'ClientAssemblyContext', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.RegisterAndSelectClientAssembly: Attempting to select the logging-client assembly ticket, '{result}', for the current logical execution flow..."
                );

                // Attempt to select the logging-client assembly ticket for the current logical
                // execution flow.  If this is not successful, then write an error message to the
                // Debug output, and then terminate the execution of this method, returning the
                // default return value.
                if (!ClientAssemblyContext.Select(result))
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.RegisterAndSelectClientAssembly: *** ERROR *** The logging-client assembly ticket, '{result}', could NOT be selected for the current logical execution flow.  Stopping..."
                    );

                    result = Guid.Empty;

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.RegisterAndSelectClientAssembly: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.RegisterAndSelectClientAssembly: *** SUCCESS *** The logging-client assembly ticket, '{result}', was selected for the current logical execution flow.  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = Guid.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingSubsystemManager.RegisterAndSelectClientAssembly: Result = '{result}'"
            );

            return result;
        }

        /// <summary>Registers an assembly that is requesting logging services.</summary>
        /// <param name="assembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that is requesting logging
        /// services.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Guid" /> value that uniquely identifies the
        /// registered assembly; otherwise, <see cref="F:System.Guid.Empty" />.
        /// </returns>
        /// <remarks>
        /// This method is primarily intended for logging-subsystem adapter(s),
        /// such as <c>WizardLoggingSubsystemManager</c>.
        /// <para />
        /// If <paramref name="assembly" /> is <see langword="null" />, the registry is
        /// unavailable, or registration fails, then this method returns
        /// <see cref="F:System.Guid.Empty" />.
        /// <para />
        /// Because this method may execute before the logging subsystem has been
        /// initialized, exception information is written directly to the Debug output.
        /// </remarks>
        [return: NotLogged]
        public static Guid RegisterClientAssembly([NotLogged] Assembly assembly)
        {
            var result = Guid.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterClientAssembly: Checking whether the method parameter, 'assembly', has a null reference for a value..."
                );

                // Check whether the method parameter, 'assembly', has a null reference for a value.
                // If this is the case, then write an error message to the Debug output, and then
                // terminate the execution of this method, returning the default return value.
                if (assembly == null)
                {
                    // The method parameter, 'assembly', has a null reference for a value.  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.RegisterClientAssembly: *** ERROR *** A null reference was passed for the method parameter, 'assembly'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.RegisterClientAssembly: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterClientAssembly: *** SUCCESS *** The method parameter, 'assembly', refers to a valid object.  Proceeding..."
                );

                /* Reject assembly(ies) whose names are 'xyLOGIX.Core.TemplateWizard.Logging'. */

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterClientAssembly: Checking whether the name of the assembly that is to be registered is in the list of invalid value(s)..."
                );

                // Check to see whether the name of the assembly that is to be registered is in the
                // list of invalid value(s).  If this is not the case, then write an error message
                // to the Debug output, and then terminate the execution of this method.
                if (InvalidClientAssemblyNames.All.Contains(
                        assembly.GetName()
                                .Name, StringComparer.OrdinalIgnoreCase
                    ))
                {
                    // The name of the assembly that is to be registered appears to be an element of
                    // the list of invalid value(s).  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The name of the assembly that is to be registered appears to be an element of the list of invalid value(s).  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.RegisterClientAssembly: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterClientAssembly: *** SUCCESS *** The name of the assembly that is to be registered is in the list of invalid value(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterClientAssembly: Checking whether the 'ClientAssemblyRegistry' property has a null reference for a value..."
                );

                // Check whether the 'ClientAssemblyRegistry' property has a null reference for a
                // value.  If this is the case, then write an error message to the Debug output, and
                // then terminate the execution of this method, returning the default return value.
                if (ClientAssemblyRegistry == null)
                {
                    // The 'ClientAssemblyRegistry' property has a null reference for a value.  This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.RegisterClientAssembly: *** ERROR *** The 'ClientAssemblyRegistry' property has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.RegisterClientAssembly: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterClientAssembly: *** SUCCESS *** The 'ClientAssemblyRegistry' property refers to a valid object.  Proceeding..."
                );

                result = ClientAssemblyRegistry.Register(assembly);

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.RegisterClientAssembly: Checking whether the logging-client assembly was successfully registered..."
                );

                // Check whether the logging-client assembly was successfully registered.  If this
                // is not the case, then write an error message to the Debug output, and then
                // terminate the execution of this method, returning the default return value.
                if (Guid.Empty.Equals(result))
                {
                    // The logging-client assembly could NOT be successfully registered.  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingSubsystemManager.RegisterClientAssembly: *** ERROR *** The logging-client assembly, '{assembly.FullName}', could NOT be successfully registered.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.RegisterClientAssembly: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.RegisterClientAssembly: *** SUCCESS *** The logging-client assembly, '{assembly.FullName}', was successfully registered with the ticket, '{result}'.  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = Guid.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingSubsystemManager.RegisterClientAssembly: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Sets up the <see cref="T:xyLOGIX.Core.Debug.DebugUtils" /> to
        /// initialize its functionality.
        /// </summary>
        /// <param name="muteDebugLevelIfReleaseMode">
        /// If set to true, does not echo any
        /// logging statements that are set to <see cref="F:DebugLevel.Debug" />.
        /// </param>
        /// <param name="isLogging">
        /// True to activate the functionality of writing to a log
        /// file; false to suppress. Usually used with the <paramref name="consoleOnly" />
        /// parameter set to <see langword="true" />.
        /// </param>
        /// <param name="consoleOnly">
        /// True to only write messages to the console; false to
        /// write them both to the console and to the log.
        /// </param>
        /// <param name="verbosity">
        /// (Optional.) An <see cref="T:System.Int32" /> whose
        /// value must be <c>0</c> or greater.
        /// <para />
        /// Indicates the verbosity level.
        /// <para />
        /// Higher values mean more verbose.
        /// <para />
        /// if the <paramref name="verbosity" /> parameter is negative, it will be ignored.
        /// <para />
        /// The default value of this parameter is <c>1</c>.
        /// </param>
        /// <param name="muteConsole">
        /// If set to <see langword="true" />, suppresses all
        /// console output.
        /// </param>
        /// <param name="infrastructureType">
        /// (Optional.) One of the
        /// <see cref="T:LoggingInfrastructureType" /> value(s) that indicates what type of
        /// logging infrastructure is to be utilized (default or PostSharp).
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the operation(s) completed successfully;
        /// <see langword="false" /> otherwise.
        /// </returns>
        [DebuggerStepThrough]
        public static bool SetUpDebugUtils(
            bool muteDebugLevelIfReleaseMode,
            bool isLogging = true,
            bool consoleOnly = false,
            int verbosity = 1,
            bool muteConsole = false,
            LoggingInfrastructureType infrastructureType = LoggingInfrastructureType.Default
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.SetUpDebugUtils: Checking whether the Logging Infrastructure Type, '{infrastructureType}', is within the defined value set..."
                );

                // Check to see whether the specified Logging Infrastructure Type is within the
                // defined value set. If this is not the case, then write an error message to the
                // log file, and then terminate the execution of this method.
                if (!LoggingInfrastructureTypeValidator.IsValid(infrastructureType))
                {
                    // The specified Logging Infrastructure Type is NOT within the defined value
                    // set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The Logging Infrastructure Type, '{infrastructureType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.SetUpDebugUtils: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingSubsystemManager.SetUpDebugUtils: *** SUCCESS *** The Logging Infrastructure Type, '{infrastructureType}', is within the defined value set.  Proceeding..."
                );

                InfrastructureType = infrastructureType;

                System.Diagnostics.Debug.WriteLine(
                    "*** LoggingSubsystemManager.SetUpDebugUtils: Checking whether the 'LoggingInfrastructure' property has a null reference for a value..."
                );

                // Check to see if the required property, LoggingInfrastructure, is null. If it is,
                // send an error to the log file and quit, returning from the method.
                if (LoggingInfrastructure == null)
                {
                    // the property LoggingInfrastructure is required.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingSubsystemManager.SetUpDebugUtils: *** ERROR *** The 'LoggingInfrastructure' property has a null reference.  Stopping."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingSubsystemManager.SetUpDebugUtils: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingSubsystemManager.SetUpDebugUtils: *** SUCCESS *** The 'LoggingInfrastructure' property has a valid object reference for its value."
                );

                result = LoggingInfrastructure.SetUpDebugUtils(
                    muteDebugLevelIfReleaseMode, isLogging, consoleOnly, verbosity, muteConsole
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingSubsystemManager.SetUpDebugUtils: Result = {result}"
            );

            return result;
        }
    }
}