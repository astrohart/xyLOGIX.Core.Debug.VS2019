using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Manages the registration of assembly(ies) that request logging
    /// services.
    /// </summary>
    /// <remarks>
    /// This class implements a thread-safe, process-local ticket registry.
    /// <para />
    /// A single instance is shared by all callers through the
    /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.Instance" />
    /// property.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientAssemblyRegistry : ILoggingClientAssemblyRegistry
    {
        /// <summary>
        /// Reference to an object used to synchronize access to the registered
        /// assembly/ticket mapping.
        /// </summary>
        private readonly object _syncRoot = new object();

        /// <summary>
        /// Reference to a collection that associates each registered
        /// <see cref="T:System.Reflection.Assembly" /> with its corresponding
        /// <see cref="T:System.Guid" /> ticket.
        /// </summary>
        private readonly IDictionary<Assembly, Guid> _ticketsByAssembly =
            new Dictionary<Assembly, Guid>();

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientAssemblyRegistry() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientAssemblyRegistry()
        { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry" /> interface.
        /// </summary>
        internal static ILoggingClientAssemblyRegistry Instance { [DebuggerStepThrough] get; } =
            new LoggingClientAssemblyRegistry();

        /// <summary>
        /// Gets the assembly that is associated with the specified logging-client
        /// ticket.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// identifies a registered logging-client assembly.
        /// </param>
        /// <returns>
        /// Reference to the registered
        /// <see cref="T:System.Reflection.Assembly" /> associated with the specified
        /// ticket; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="ticket" /> is equal to
        /// <see cref="F:System.Guid.Empty" />, or no assembly is associated with it, then
        /// this method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        public Assembly GetAssembly([NotLogged] Guid ticket)
        {
            Assembly result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientAssemblyRegistry.GetAssembly: *** INFO *** Checking whether the specified ticket, '{ticket}', is set to the Zero GUID..."
                );

                // Check whether the value of the specified ticket  is set to the Zero GUID.  If
                // this is the case, then write an error message to the Debug output, and then
                // terminate the execution of this method, returning the default return value.
                if (Guid.Empty.Equals(ticket))
                {
                    // The value of the specified ticket is set to the Zero GUID.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the specified ticket, '{ticket}', is set to the Zero GUID.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientAssemblyRegistry.GetAssembly: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientAssemblyRegistry.GetAssembly: *** SUCCESS *** The value of the specified ticket, '{ticket}', is NOT set to the Zero GUID.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to get the assembly associated with the specified ticket, '{ticket}'..."
                );

                lock (_syncRoot)
                {
                    foreach (var entry in _ticketsByAssembly)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"*** LoggingClientAssemblyRegistry.GetAssembly: Checking whether the current entry in the registry corresponds to the specified ticket, '{ticket}'..."
                        );

                        // Check to see whether the current entry in the registry corresponds to the
                        // specified ticket. If this is not the case, then write an error message to
                        // the Debug output, and then skip to the next loop iteration.
                        if (!ticket.Equals(entry.Value))
                        {
                            // The current entry in the registry does NOT appear to correspond to
                            // the specified ticket.  This is not desirable.
                            System.Diagnostics.Debug.WriteLine(
                                $"*** ERROR: The current entry in the registry, '{entry.Key.FullName}', does NOT appear to correspond to the specified ticket, '{ticket}'.  Skipping to the next entry..."
                            );

                            // skip to the next loop iteration.
                            continue;
                        }

                        System.Diagnostics.Debug.WriteLine(
                            $"LoggingClientAssemblyRegistry.GetAssembly: *** SUCCESS *** FOUND the entry in the registry, '{entry.Key.FullName}', that corresponds to the specified ticket, '{ticket}'.  Proceeding..."
                        );

                        result = entry.Key;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }

        /// <summary>Gets the logging-client ticket associated with the specified assembly.</summary>
        /// <param name="assembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> whose ticket is to be obtained.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Guid" /> value that identifies the specified
        /// assembly; otherwise, <see cref="F:System.Guid.Empty" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="assembly" /> is <see langword="null" />, or has not
        /// been registered, then this method returns <see cref="F:System.Guid.Empty" />.
        /// </remarks>
        [return: NotLogged]
        public Guid GetTicket([NotLogged] Assembly assembly)
        {
            var result = Guid.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientAssemblyRegistry.GetTicket: Checking whether the method parameter, 'assembly', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'assembly', is null. If it is, then write
                // an error message to the log file and then terminate the execution of this method,
                // returning the default return value.
                if (assembly == null)
                {
                    // The method parameter, 'assembly', is required and is not supposed to have a
                    // NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientAssemblyRegistry.GetTicket: *** ERROR *** A null reference was passed for the method parameter, 'assembly'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientAssemblyRegistry.GetTicket: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientAssemblyRegistry.GetTicket: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'assembly'.  Proceeding..."
                );

                lock (_syncRoot)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Attempting to get the ticket for the specified .NET assembly, '{assembly.FullName}'..."
                    );

                    _ticketsByAssembly.TryGetValue(assembly, out result);
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = Guid.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientAssemblyRegistry.GetTicket: Result = '{result}'"
            );

            return result;
        }

        /// <summary>Registers the specified logging-client assembly.</summary>
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
        /// If <paramref name="assembly" /> is <see langword="null" />, then this
        /// method returns <see cref="F:System.Guid.Empty" />.
        /// <para />
        /// If the assembly has already been registered, then its existing ticket is
        /// returned.
        /// </remarks>
        [return: NotLogged]
        public Guid Register([NotLogged] Assembly assembly)
        {
            var result = Guid.Empty;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientAssemblyRegistry.Register: Checking whether the method parameter, 'assembly', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'assembly', is null. If it is, then write
                // an error message to the log file and then terminate the execution of this method,
                // returning the default return value.
                if (assembly == null)
                {
                    // The method parameter, 'assembly', is required and is not supposed to have a
                    // NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientAssemblyRegistry.Register: *** ERROR *** A null reference was passed for the method parameter, 'assembly'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** LoggingClientAssemblyRegistry.Register: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientAssemblyRegistry.Register: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'assembly'.  Proceeding..."
                );

                lock (_syncRoot)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientAssemblyRegistry.Register: Checking whether the specified .NET assembly, '{assembly.FullName}', is NOT already registered..."
                    );

                    // Check to see whether the specified .NET assembly is NOT already registered.
                    // If this is the case, then write a FYI message to the Debug output, and then
                    // return its ticket.
                    if (_ticketsByAssembly.TryGetValue(assembly, out result))
                    {
                        // The specified .NET assembly is already registered.  Just return its
                        // ticket.
                        System.Diagnostics.Debug.WriteLine(
                            $"*** FYI *** The specified .NET assembly, '{assembly.FullName}', is already registered.  Stopping..."
                        );

                        System.Diagnostics.Debug.WriteLine(
                            $"*** LoggingClientAssemblyRegistry.Register: Result = '{result}'"
                        );

                        // stop.
                        return result;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientAssemblyRegistry.Register: *** FYI *** The specified .NET assembly, '{assembly.FullName}', is NOT already registered.  Registering it..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Getting a new, unique ticket for the specified .NET assembly, '{assembly.FullName}'..."
                    );

                    result = Guid.NewGuid();

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Assigning the new, unique ticket, '{result}', to the specified .NET assembly, '{assembly.FullName}', and registering it..."
                    );

                    _ticketsByAssembly.Add(assembly, result);
                }
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
}