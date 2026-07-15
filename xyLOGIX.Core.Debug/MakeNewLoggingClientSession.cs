using log4net;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using PostSharp.Patterns.Threading;
using System;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Creates logging-client session object(s).</summary>
    /// <remarks>
    /// Logging-client object(s) are created for a specific assembly and ticket.
    /// <para />
    /// A named log4net repository and a corresponding
    /// <see
    ///     cref="T:PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend" />
    /// are created for the session.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal static class MakeNewLoggingClientSession
    {
        /// <summary>
        /// A <see cref="T:System.String" /> containing the prefix assigned to
        /// every logging-client repository name.
        /// </summary>
        private const string RepositoryNamePrefix = "xyLOGIX.Core.Debug.LoggingClient.";

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.MakeNewLoggingClientSession" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically before any
        /// <see langword="static" /> member is referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MakeNewLoggingClientSession() { }

        /// <summary>Finds the log4net repository having the specified name.</summary>
        /// <param name="repositoryName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the name of the repository to find.
        /// </param>
        /// <returns>
        /// Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> having the specified
        /// name; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="repositoryName" /> is blank, no repository(ies) are
        /// available, or no matching repository exists, this method returns
        /// <see langword="null" />.
        /// <para />
        /// Repository-name comparison is performed without regard to character casing.
        /// </remarks>
        [return: NotLogged]
        private static ILoggerRepository FindRepository([NotLogged] string repositoryName)
        {
            ILoggerRepository result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.FindRepository: *** FYI *** Attempting to find the repository named: '{repositoryName}'..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "MakeNewLoggingClientSession.FindRepository *** INFO: Checking whether the value of the parameter, 'repositoryName', is blank..."
                );

                // Check whether the value of the parameter, 'repositoryName', is blank. If this is
                // so, then emit an error message to the Debug output, and then terminate the
                // execution of this method.
                if (string.IsNullOrWhiteSpace(repositoryName))
                {
                    // The parameter, 'repositoryName' was either passed a null value, or it is
                    // blank.  There is nothing to do.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "MakeNewLoggingClientSession.FindRepository: The parameter, 'repositoryName' was either passed a null value, or it is blank. Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** SUCCESS *** The parameter, 'repositoryName', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Fetching the collection of all log4net repositories in the current AppDomain..."
                );

                var repositories = LogManager.GetAllRepositories();

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.FindRepository: Checking whether the variable, 'repositories', has a null reference for a value..."
                );

                // Check to see if the variable, 'repositories', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (repositories == null)
                {
                    // The variable, 'repositories', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.FindRepository: *** ERROR ***  The variable, 'repositories', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'repositories', because it's not set to a null
                // reference.
                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.FindRepository: *** SUCCESS *** The variable, 'repositories', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.FindRepository *** INFO: Checking whether the array, 'repositories', has greater than zero elements..."
                );

                // Check whether the array, 'repositories', has greater than zero elements.  If it
                // is empty, then write an error message to the Debug output, and then terminate the
                // execution of this method.  It is ideal for the array to have greater than zero
                // elements.
                if (repositories.Length <= 0)
                {
                    // The array, 'repositories', has zero elements, and we can't proceed if this is
                    // so.  There is nothing more to do.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.FindRepository *** ERROR *** The array, 'repositories', has zero elements.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.FindRepository *** SUCCESS *** {repositories.Length} element(s) were found in the 'repositories' array.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Searching for the repository named: '{repositoryName}'..."
                );

                foreach (var repository in repositories)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.FindRepository: Checking whether the variable 'repository' has a null reference for a value..."
                    );

                    // Check to see if the variable, 'repository', is null. If it is, send an error
                    // to the Debug output and continue to the next loop iteration.
                    if (repository == null)
                    {
                        // the variable repository is required to have a valid object reference.
                        System.Diagnostics.Debug.WriteLine(
                            "MakeNewLoggingClientSession.FindRepository: *** ERROR ***  The 'repository' variable has a null reference.  Skipping to the next loop iteration..."
                        );

                        // continue to the next loop iteration.
                        continue;
                    }

                    // We can use the variable, repository, because it's not set to a null
                    // reference.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.FindRepository: *** SUCCESS *** The 'repository' variable has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.FindRepository: Checking whether the property, 'repository.Name', has a null reference for a value, or is blank..."
                    );

                    // Check to see if the required property, repository.Name, is null or blank. If
                    // it is, send an error to the Debug output and then stop the execution of this
                    // method.
                    if (string.IsNullOrWhiteSpace(repository.Name))
                    {
                        // The property, 'repository.Name', is a blank string or has a null value.
                        // This is not desirable.  Skip to the next iteration of this loop.
                        System.Diagnostics.Debug.WriteLine(
                            "MakeNewLoggingClientSession.FindRepository: *** ERROR *** The property, 'repository.Name', has a null reference or is blank.  Skipping to the next repository..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.FindRepository: *** SUCCESS *** The property, 'repository.Name', is set to a non-blank string.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** MakeNewLoggingClientSession.FindRepository: Checking whether the name of the current repository, '{repository.Name}', matches that which we are searching for; i.e., '{repositoryName}'..."
                    );

                    // Check to see whether the name of the current repository matches that which we
                    // are searching for. If this is not the case, then write an error message to
                    // the Debug output, and then skip to the next loop iteration.
                    if (!repositoryName.Trim()
                                       .Equals(
                                           repository.Name.Trim(),
                                           StringComparison.OrdinalIgnoreCase
                                       ))
                    {
                        // The name of the current repository does NOT appear to match that which we
                        // are searching for.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            $"*** ERROR: The name of the current repository, '{repository.Name}', does NOT appear to match that which we are searching for; i.e., '{repositoryName}'.  Skipping to the next repository..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"MakeNewLoggingClientSession.FindRepository: *** SUCCESS *** The name of the current repository, '{repository.Name}', matches that which we are searching for; i.e., '{repositoryName}'.  Proceeding..."
                    );

                    result = repository;
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to the log4net repository having the name, '{repositoryName}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to find the log4net repository having the name, '{repositoryName}'.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Gets the unique log4net repository name for the specified
        /// logging-client assembly and ticket.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A nonempty <see cref="T:System.Guid" /> value
        /// that identifies the registered logging-client assembly.
        /// </param>
        /// <param name="clientAssembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> for which a repository name is
        /// being generated.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.String" /> containing the unique repository
        /// name; otherwise, <see cref="F:System.String.Empty" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="ticket" /> equals
        /// <see cref="F:System.Guid.Empty" />, or <paramref name="clientAssembly" /> is
        /// <see langword="null" />, this method returns
        /// <see cref="F:System.String.Empty" />.
        /// </remarks>
        [return: NotLogged]
        private static string FormulateRepositoryName(
            [NotLogged] Guid ticket,
            [NotLogged] Assembly clientAssembly
        )
        {
            var result = string.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.FormulateRepositoryName: *** FYI *** Formulating the repository name for ticket, '{ticket:N}', and assembly, '{clientAssembly?.FullName ?? "<null>"}'."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.FormulateRepositoryName: *** INFO *** Checking whether the assembly ticket, '{ticket}', is set to the Zero GUID..."
                );

                // Check whether the value of the specified assembly ticket  is set to the Zero
                // GUID.  If this is the case, then write an error message to the Debug output, and
                // then terminate the execution of this method, returning the default return value.
                if (Guid.Empty.Equals(ticket))
                {
                    // The value of the specified assembly ticket is set to the Zero GUID.  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the assembly ticket, '{ticket}', is set to the Zero GUID.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"MakeNewLoggingClientSession.FormulateRepositoryName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.FormulateRepositoryName: *** SUCCESS *** The value of the assembly ticket, '{ticket}', is NOT set to the Zero GUID.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.FormulateRepositoryName: Checking whether the method parameter, 'clientAssembly', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'clientAssembly', is null. If it is, then
                // write an error message to the Debug output and then terminate the execution of
                // this method, returning the default return value.
                if (clientAssembly == null)
                {
                    // The method parameter, 'clientAssembly', is required and is not supposed to
                    // have a NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.FormulateRepositoryName: *** ERROR *** A null reference was passed for the method parameter, 'clientAssembly'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** MakeNewLoggingClientSession.FormulateRepositoryName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.FormulateRepositoryName: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'clientAssembly'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Getting the AssemblyName for the assembly '{clientAssembly.FullName}'..."
                );

                var assemblyName = clientAssembly.GetName();

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.FormulateRepositoryName: Checking whether the variable, 'assemblyName', has a null reference for a value..."
                );

                // Check to see if the variable, assemblyName, is null.  If it is, send an error to
                // the Debug output and terminate the execution of this method, returning the
                // default return value.
                if (assemblyName == null)
                {
                    // the variable assemblyName is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.FormulateRepositoryName: *** ERROR ***  The variable, 'assemblyName', has a null reference.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** MakeNewLoggingClientSession.FormulateRepositoryName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, assemblyName, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.FormulateRepositoryName: *** SUCCESS *** The variable, 'assemblyName', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** INFO: Checking whether the property, 'assemblyName.Name', appears to have a null or blank value..."
                );

                // Check to see if the required property, 'assemblyName.Name', appears to have a
                // null  or blank value. If it does, then send an error to the Debug output and
                // quit, returning the default value of the result variable.
                if (string.IsNullOrWhiteSpace(assemblyName.Name))
                {
                    // The property, 'assemblyName.Name', appears to have a null or blank value.
                    // This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR: The property, 'assemblyName.Name', appears to have a null or blank value.  Stopping..."
                    );

                    // Emit the result to the Debug output.
                    System.Diagnostics.Debug.WriteLine(
                        $"MakeNewLoggingClientSession.FormulateRepositoryName: Result = '{result}'"
                    );

                    // Stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The property, 'assemblyName.Name', seems to have a non-blank value."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Proceeding to formulate the repository name for the assembly, '{clientAssembly.FullName}', and ticket, '{ticket:N}'..."
                );

                result = $"{RepositoryNamePrefix}{assemblyName.Name}.{ticket:N}";
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"MakeNewLoggingClientSession.FormulateRepositoryName: Result = '{result}'"
            );

            return result;
        }

        /// <summary>
        /// Creates a new logging-client session for the specified assembly and
        /// ticket.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A nonempty <see cref="T:System.Guid" /> value
        /// that identifies the registered logging-client assembly.
        /// </param>
        /// <param name="clientAssembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that requested logging services.
        /// </param>
        /// <returns>
        /// Reference to a new instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSession" /> interface; otherwise,
        /// <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="ticket" /> equals <see cref="F:System.Guid.Empty" />, or
        /// <paramref name="clientAssembly" /> is <see langword="null" />, this method
        /// returns <see langword="null" />.
        /// <para />
        /// A named log4net repository and a corresponding
        /// <see
        ///     cref="T:PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend" />
        /// are created for the session.
        /// </remarks>
        [return: NotLogged]
        internal static ILoggingClientSession From(
            [NotLogged] Guid ticket,
            [NotLogged] Assembly clientAssembly
        )
        {
            ILoggingClientSession result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.From: *** FYI *** Creating a new logging-client session for ticket, '{ticket:N}', and assembly, '{clientAssembly?.FullName ?? "<null>"}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.From: *** INFO *** Checking whether the specified client-assembly ticket, '{ticket}', is set to the Zero GUID..."
                );

                // Check whether the value of the specified client-assembly ticket  is set to the
                // Zero GUID.  If this is the case, then write an error message to the Debug output,
                // and then terminate the execution of this method, returning the default return
                // value.
                if (Guid.Empty.Equals(ticket))
                {
                    // The value of the specified client-assembly ticket is set to the Zero GUID.
                    // This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the specified client-assembly ticket, '{ticket}', is set to the Zero GUID.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** NOT creating a new logging-client session for ticket, '{ticket:N}', and assembly, '{clientAssembly?.FullName ?? "<null>"}'..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.From: *** SUCCESS *** The value of the specified client-assembly ticket, '{ticket}', is NOT set to the Zero GUID.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.From: Checking whether the method parameter, 'clientAssembly', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'clientAssembly', is null. If it is, then
                // write an error message to the log file and then terminate the execution of this
                // method, returning the default return value.
                if (clientAssembly == null)
                {
                    // The method parameter, 'clientAssembly', is required and is not supposed to
                    // have a NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.From: *** ERROR *** A null reference was passed for the method parameter, 'clientAssembly'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** NOT creating a new logging-client session for ticket, '{ticket:N}', and assembly, '<null>'..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.From: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'clientAssembly'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.From: *** FYI *** Formulating the repository name for ticket, '{ticket:N}', and assembly, '{clientAssembly.FullName}'..."
                );

                var repositoryName = FormulateRepositoryName(ticket, clientAssembly);

                // Dump the value of the variable, repositoryName, to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.From: repositoryName = '{repositoryName}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.From: Checking whether the variable, 'repositoryName', has a null reference for a value, or is blank..."
                );

                // Check to see if the required variable, 'repositoryName', is null or blank. If it
                // is,  then send an  error to the log file and quit, returning the default value of
                // the result variable.
                if (string.IsNullOrWhiteSpace(repositoryName))
                {
                    // The variable, 'repositoryName', has a null reference for a value, or is
                    // blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.From: *** ERROR *** The variable, 'repositoryName', has a null reference for a value, or is blank.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** NOT creating a new logging-client session for ticket, '{ticket:N}', and assembly, '{clientAssembly.FullName}'..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.From: *** SUCCESS *** {repositoryName.Length} B of data appear to be present in the variable, 'repositoryName'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.From: *** FYI *** Getting or creating the log4net repository named: '{repositoryName}'..."
                );

                var repository = GetOrCreateRepository(repositoryName);

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.From: Checking whether the variable, 'repository', has a null reference for a value..."
                );

                // Check to see if the variable, 'repository', has a null reference for a value. If
                // it does, then emit an error to the Debug output, and terminate the execution of
                // this method, returning the default return value.
                if (repository == null)
                {
                    // The variable, 'repository', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.From: *** ERROR ***  The variable, 'repository', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** NOT creating a new logging-client session for ticket, '{ticket:N}', and assembly, '{clientAssembly.FullName}'..."
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'repository', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.From: *** SUCCESS *** The variable, 'repository', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.From: *** FYI *** Attempting to get a reference to an instance of a PostSharp log4net logging backend for the repository named: '{repositoryName}'..."
                );

                var backend = new Log4NetLoggingBackend(repository);

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.From: Checking whether the variable, 'backend', has a null reference for a value..."
                );

                // Check to see if the variable, 'backend', has a null reference for a value. If it
                // does, then emit an error to the Debug output, and terminate the execution of this
                // method, returning the default return value.
                if (backend == null)
                {
                    // The variable, 'backend', has a null reference for a value.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.From: *** ERROR ***  The variable, 'backend', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** MakeNewLoggingClientSession.From: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'backend', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.From: *** SUCCESS *** The variable, 'backend', has a valid object reference for its value.  Proceeding..."
                );

                result = new LoggingClientSession(
                    ticket, clientAssembly, repositoryName, repository, backend
                );

                // Coerce the value of the 'result' variable to the default value if it is not found
                // to have valid setting(s).  This is a safety measure to ensure that we don't
                // return a reference to an invalid logging-client session.
                if (!result.IsValid())
                {
                    // The newly-created logging-client session does not have valid setting(s). This
                    // is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The newly-created logging-client session does not have valid setting(s).  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** Coercing the value of the 'result' variable to the default value, which is a null reference for an object that implements the ILoggingClientSession interface..."
                    );

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
                result != null && result.IsValid()
                    ? "*** SUCCESS *** Obtained a reference to a newly-created logging-client session that has valid setting(s).  Proceeding..."
                    : "*** ERROR *** We were unable to create a new logging-client session that has valid setting(s).  Stopping..."
            );

            return result;
        }

        /// <summary>Gets or creates the log4net repository having the specified name.</summary>
        /// <param name="repositoryName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the unique repository name.
        /// </param>
        /// <returns>
        /// Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> having the specified
        /// name; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="repositoryName" /> is blank, this method returns
        /// <see langword="null" />.
        /// <para />
        /// Existing repository(ies) are examined before a new repository is created.
        /// <para />
        /// If another caller creates the repository after the initial examination but
        /// before this method attempts to create it, the repository collection is examined
        /// again after the exception is caught.
        /// </remarks>
        [return: NotLogged]
        private static ILoggerRepository GetOrCreateRepository([NotLogged] string repositoryName)
        {
            ILoggerRepository result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.GetOrCreateRepository: *** FYI *** Attempting to get or create the log4net repository named: '{repositoryName}'..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "MakeNewLoggingClientSession.GetOrCreateRepository *** INFO: Checking whether the value of the parameter, 'repositoryName', is blank..."
                );

                // Check whether the value of the parameter, 'repositoryName', is blank. If this is
                // so, then emit an error message to the Debug output, and then terminate the
                // execution of this method.
                if (string.IsNullOrWhiteSpace(repositoryName))
                {
                    // The parameter, 'repositoryName' was either passed a null value, or it is
                    // blank.  There is nothing to do.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "MakeNewLoggingClientSession.GetOrCreateRepository: The parameter, 'repositoryName' was either passed a null value, or it is blank. Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** SUCCESS *** The parameter, 'repositoryName', is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.GetOrCreateRepository: *** FYI *** Attempting to discover whether the log4net repository, '{repositoryName}', already exists..."
                );

                result = FindRepository(repositoryName);

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.GetOrCreateRepository: *** INFO: Checking whether an existing log4net repository named, '{repositoryName}', was found..."
                );

                // Check whether an existing log4net repository having the specified name was found.
                // If it was, then return a reference to it.  Otherwise, keep going and attempt to
                // create a new repository having the specified name.
                if (result != null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"MakeNewLoggingClientSession.GetOrCreateRepository: *** SUCCESS *** A log4net repository named, '{repositoryName}', was found.  Returning a reference to it..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.GetOrCreateRepository: *** WARNING *** No log4net repository named, '{repositoryName}', was found.  Attempting to create a new repository having that name..."
                );

                TryCreateLoggerRepositoryNamed(repositoryName, out result);
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
        /// Attempts to create a new instance of a log4net repository that
        /// implements the <see cref="T:log4net.Repository.ILoggerRepository" /> interface,
        /// that has the name, <paramref name="repositoryName" />.
        /// </summary>
        /// <param name="repositoryName">
        /// (Required.) A <see cref="T:System.String" /> that
        /// is set to the name to use for the new log4net repository.
        /// <para />
        /// <b>NOTE:</b> The value of this parameter may not be <see langword="null" />,
        /// blank, nor the <see cref="F:System.String.Empty" /> value.
        /// <para />
        /// If it is, then this method will not attempt to create a new log4net repository.
        /// </param>
        /// <param name="repository">
        /// (Output.) If successful, receives a reference to an
        /// instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface; otherwise, a
        /// <see langword="null" /> reference is placed in the argument of this parameter.
        /// </param>
        /// <remarks>
        /// This method attempts to create a new log4net repository having the
        /// name specified in the <paramref name="repositoryName" /> parameter.
        /// <para />
        /// If the repository is successfully created, then a reference to it is placed in
        /// the argument of the <paramref name="repository" /> parameter.
        /// <para />
        /// If a <see langword="null" />, blank <see cref="T:System.String" />, or the
        /// <see cref="F:System.String.Empty" /> value is passed for the argument of the
        /// <paramref name="repositoryName" /> parameter, then this method does nothing.
        /// <para />
        /// The <paramref name="repository" /> parameter receives a <see langword="null" />
        /// reference if an error was encountered during the process of attempting to
        /// create the new repository.
        /// </remarks>
        private static void TryCreateLoggerRepositoryNamed(
            string repositoryName,
            out ILoggerRepository repository
        )
        {
            repository = default;

            try
            {
                // Dump the argument of the parameter, repositoryName, to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.TryCreateLoggerRepositoryNamed: repositoryName = '{repositoryName}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewLoggingClientSession.TryCreateLoggerRepositoryNamed: *** FYI *** Attempting to create a new log4net repository named: '{repositoryName}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLoggingClientSession.TryCreateLoggerRepositoryNamed *** INFO: Checking whether the value of the parameter, 'repositoryName', is blank..."
                );

                // Check whether the value of the parameter, 'repositoryName', is blank. If this is
                // so, then emit an error message to the Debug output, and then terminate the
                // execution of this method.
                if (string.IsNullOrWhiteSpace(repositoryName))
                {
                    // The parameter, 'repositoryName' was either passed a null value, or it is
                    // blank.  There is nothing to do.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLoggingClientSession.TryCreateLoggerRepositoryNamed: The parameter, 'repositoryName' was either passed a null value, or it is blank. Nothing to do..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter, 'repositoryName', is not blank.  Creating a new one with that name..."
                );

                repository = LogManager.CreateRepository(repositoryName);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                repository = default;
            }

            System.Diagnostics.Debug.WriteLine(
                repository != null
                    ? $"*** SUCCESS *** Obtained a reference to a new ILoggerRepository named, '{repositoryName}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to a new ILoggerRepository named, '{repositoryName}'.  Stopping..."
            );
        }
    }
}