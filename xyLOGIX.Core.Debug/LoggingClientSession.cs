using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Represents the logging services assigned to a registered
    /// logging-client assembly.
    /// </summary>
    /// <remarks>
    /// Each instance associates one registered assembly ticket with one
    /// dedicated log4net repository and one PostSharp logging backend.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientSession : ILoggingClientSession
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientSession" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientSession() { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientSession" /> class and returns a
        /// reference to it.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// uniquely identifies this logging-client session.
        /// </param>
        /// <param name="clientAssembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that requested this logging
        /// session.
        /// </param>
        /// <param name="repositoryName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the unique name of the log4net repository assigned to this session.
        /// </param>
        /// <param name="repository">
        /// (Required.) Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> assigned to this session.
        /// </param>
        /// <param name="backend">
        /// (Required.) Reference to an instance of
        /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" /> that writes
        /// PostSharp logging record(s) to the assigned repository.
        /// </param>
        /// <remarks>
        /// Invalid argument value(s) leave the corresponding property initialized
        /// to its default value.
        /// <para />
        /// Call <see cref="M:xyLOGIX.Core.Debug.LoggingClientSession.IsValid" /> after
        /// construction to verify that initialization succeeded.
        /// </remarks>
        internal LoggingClientSession(
            [NotLogged] Guid ticket,
            [NotLogged] Assembly clientAssembly,
            [NotLogged] string repositoryName,
            [NotLogged] ILoggerRepository repository,
            [NotLogged] LoggingBackend backend
        )
        {
            Ticket = ticket;
            ClientAssembly = clientAssembly;
            RepositoryName = repositoryName;
            Repository = repository;
            Backend = backend;
        }

        /// <summary>
        /// Gets a reference to an instance of
        /// <see cref="T:PostSharp.Patterns.Diagnostics.LoggingBackend" /> that writes
        /// PostSharp logging record(s) to the repository assigned to this session.
        /// </summary>
        public LoggingBackend Backend
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            private set;
        }

        /// <summary>
        /// Gets a reference to the <see cref="T:System.Reflection.Assembly" />
        /// that requested this logging session.
        /// </summary>
        public Assembly ClientAssembly
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            private set;
        }

        /// <summary>
        /// Gets a reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> that is dedicated to this
        /// logging-client session.
        /// </summary>
        public ILoggerRepository Repository
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            private set;
        }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the unique name
        /// assigned to the log4net repository for this logging-client session.
        /// </summary>
        public string RepositoryName
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            private set;
        }

        /// <summary>
        /// Gets a <see cref="T:System.Guid" /> value that uniquely identifies
        /// this logging-client session.
        /// </summary>
        public Guid Ticket { [DebuggerStepThrough] get; [DebuggerStepThrough] private set; }

        /// <summary>Resets the property(ies) of this session to their default value(s).</summary>
        public void Clear()
        {
            Ticket = Guid.Empty;
            ClientAssembly = default;
            RepositoryName = string.Empty;
            Repository = default;
            Backend = default;
        }

        /// <summary>
        /// Determines whether this logging-client session contains all required
        /// information and service reference(s).
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if this logging-client session is valid;
        /// otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method returns <see langword="false" /> if the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientSession.Ticket" /> property is
        /// equal to <see cref="F:System.Guid.Empty" />, any required reference is
        /// <see langword="null" />, or the repository name is blank.
        /// </remarks>
        public bool IsValid()
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSession.IsValid: *** INFO *** Checking whether the assembly-ticket property, 'Ticket', is set to the Zero GUID..."
                );

                // Check whether the value of the assembly-ticket property, 'Ticket', is set to the
                // Zero GUID.  If this is the case, then write an error message to the Debug output,
                // and then terminate the execution of this method, returning the default return
                // value.
                if (Guid.Empty.Equals(Ticket))
                {
                    // The value of the assembly-ticket property, 'Ticket', is set to the Zero GUID.
                    // This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The value of the assembly-ticket property, 'Ticket', is set to the Zero GUID.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientSession.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientSession.IsValid: *** SUCCESS *** The value of the assembly-ticket property, 'Ticket', is NOT set to the Zero GUID; in fact, it is set to '{Ticket}'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSession.IsValid: Checking whether the property, 'ClientAssembly', has a null reference for a value..."
                );

                // Check to see if the required property, 'ClientAssembly', has a null reference for
                // a value. If that is the case, then we will write an error message to the Debug
                // output, and then terminate the execution of this method, while returning the
                // default return value.
                if (ClientAssembly == null)
                {
                    // The property, 'ClientAssembly', has a null reference for a value.  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientSession.IsValid: *** ERROR *** The property, 'ClientAssembly', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientSession.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSession.IsValid: *** SUCCESS *** The property, 'ClientAssembly', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'RepositoryName', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'RepositoryName', appears to have a null
                // or blank value. If it does, then send an error to the log file and quit,
                // returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(RepositoryName))
                {
                    // The property, 'RepositoryName', appears to have a null or blank value.  This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'RepositoryName', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientSession.IsValid: Result = {result}"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'RepositoryName', seems to have a non-blank value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSession.IsValid: Checking whether the property, 'Repository', has a null reference for a value..."
                );

                // Check to see if the required property, 'Repository', has a null reference for a
                // value. If that is the case, then we will write an error message to the Debug
                // output, and then terminate the execution of this method, while returning the
                // default return value.
                if (Repository == null)
                {
                    // The property, 'Repository', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientSession.IsValid: *** ERROR *** The property, 'Repository', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientSession.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSession.IsValid: *** SUCCESS *** The property, 'Repository', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSession.IsValid: Checking whether the property, 'Backend', has a null reference for a value..."
                );

                // Check to see if the required property, 'Backend', has a null reference for a
                // value. If that is the case, then we will write an error message to the Debug
                // output, and then terminate the execution of this method, while returning the
                // default return value.
                if (Backend == null)
                {
                    // The property, 'Backend', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientSession.IsValid: *** ERROR *** The property, 'Backend', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientSession.IsValid: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSession.IsValid: *** SUCCESS *** The property, 'Backend', has a valid object reference for its value.  Proceeding..."
                );

                /* If we made it this far with no Exception(s) getting caught, then assume that the
                 data has been validated successfully. */

                result = true;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine($"LoggingClientSession.IsValid: Result = {result}");

            return result;
        }
    }
}