using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Manages registered logging-client session object(s).</summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientSessionRegistry : ILoggingClientSessionRegistry
    {
        /// <summary>
        /// Reference to a collection that associates each logging-client ticket
        /// with its corresponding logging-client session.
        /// </summary>
        private readonly IDictionary<Guid, ILoggingClientSession> _sessions =
            new Dictionary<Guid, ILoggingClientSession>();

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientSessionRegistry" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientSessionRegistry() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientSessionRegistry" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientSessionRegistry.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientSessionRegistry() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSessionRegistry" /> interface.
        /// </summary>
        internal static ILoggingClientSessionRegistry Instance { [DebuggerStepThrough] get; } =
            new LoggingClientSessionRegistry();

        /// <summary>
        /// Gets a reference to an instance of an object that is to be used for
        /// thread synchronization purposes.
        /// </summary>
        private static object SyncRoot { [DebuggerStepThrough] get; } = new object();

        /// <summary>Gets the logging-client session associated with the specified ticket.</summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// identifies a registered logging-client session.
        /// </param>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSession" /> interface; otherwise,
        /// <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="ticket" /> equals
        /// <see cref="F:System.Guid.Empty" />, or no corresponding session exists, this
        /// method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        public ILoggingClientSession Get([NotLogged] Guid ticket)
        {
            ILoggingClientSession result = default;

            try
            {
                // Dump the argument of the parameter, ticket, to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientSessionRegistry.GetLogForType: ticket = '{ticket}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientSessionRegistry.GetLogForType: *** INFO *** Checking whether the specified logging-client session ticket, '{ticket}', is set to the Zero GUID..."
                );

                // Check whether the value of the specified logging-client session ticket  is set to
                // the Zero GUID.  If this is the case, then write an error message to the Debug
                // output, and then terminate the execution of this method, returning the default
                // return value.
                if (Guid.Empty.Equals(ticket))
                {
                    // The value of the specified logging-client session ticket is set to the Zero
                    // GUID.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the specified logging-client session ticket, '{ticket}', is set to the Zero GUID.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientSessionRegistry.GetLogForType: *** SUCCESS *** The value of the specified logging-client session ticket, '{ticket}', is NOT set to the Zero GUID.  Proceeding..."
                );

                lock (SyncRoot)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Trying to locate the logging-client session associated with the specified ticket, '{ticket}'..."
                    );

                    _sessions.TryGetValue(ticket, out result);

                    System.Diagnostics.Debug.WriteLine(
                        result != null
                            ? $"*** SUCCESS *** Obtained a reference to the logging-client session having the ticket, '{ticket}'.  Proceeding..."
                            : $"*** ERROR *** FAILED to obtain a reference to the logging-client session having the ticket, '{ticket}'.  Stopping..."
                    );
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

        /// <summary>
        /// Gets or creates the logging-client session associated with the
        /// specified ticket and assembly.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// identifies the registered logging-client assembly.
        /// </param>
        /// <param name="clientAssembly">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Reflection.Assembly" /> that requested logging services.
        /// </param>
        /// <returns>
        /// Reference to the existing or newly created instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientSession" />
        /// interface; otherwise, <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If either argument is invalid, or session creation fails, this method
        /// returns <see langword="null" />.
        /// <para />
        /// If a session already exists for the ticket but belongs to a different assembly
        /// reference, this method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        public ILoggingClientSession GetOrCreate(
            [NotLogged] Guid ticket,
            [NotLogged] Assembly clientAssembly
        )
        {
            ILoggingClientSession result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientSessionRegistry.GetOrCreate: *** FYI *** Getting the logging-client session associated with the specified ticket, '{ticket}', and assembly, '{clientAssembly?.FullName}', or creating one if one does not already exist..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientSessionRegistry.GetOrCreate: *** INFO *** Checking whether the logging-client session ticket, '{ticket}', is set to the Zero GUID..."
                );

                // Check whether the value of the specified logging-client session ticket is set to
                // the Zero GUID.  If this is the case, then write an error message to the Debug
                // output, and then terminate the execution of this method, returning the default
                // return value.
                if (Guid.Empty.Equals(ticket))
                {
                    // The value of the specified logging-client session ticket is set to the Zero
                    // GUID.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the logging-client session ticket, '{ticket}', is set to the Zero GUID.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientSessionRegistry.GetOrCreate: *** SUCCESS *** The value of the logging-client session ticket, '{ticket}', is NOT set to the Zero GUID.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSessionRegistry.GetOrCreate: Checking whether the method parameter, 'clientAssembly', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'clientAssembly', is null.  If it is,
                // then write an error message to the Debug output and then terminate the execution
                // of this method, returning the default return value.
                if (clientAssembly == null)
                {
                    // The method parameter, 'clientAssembly', is required and is not supposed to
                    // have a NULL value.  There is nothing more to be done.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientSessionRegistry.GetOrCreate: *** ERROR *** A null reference was passed for the method parameter, 'clientAssembly'.  Nothing to do..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientSessionRegistry.GetOrCreate: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'clientAssembly'.  Proceeding..."
                );

                lock (SyncRoot)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Attempting to retrieve the logging-client session associated with the specified ticket, '{ticket}'..."
                    );

                    if (_sessions.TryGetValue(ticket, out result))
                    {
                        System.Diagnostics.Debug.WriteLine(
                            $"*** FYI *** Checking whether the logging-client session associated with the specified ticket, '{ticket}', belongs to the same assembly reference as the one passed in via the method parameter, 'clientAssembly'..."
                        );

                        // Check whether the logging-client session associated with the specified
                        // ticket belongs to the same assembly reference as the one passed in via
                        // the method parameter, 'clientAssembly'.  If it does not, then write an
                        // error message to the Debug output and then terminate the execution of
                        // this method, returning the default return value.
                        if (result != null)
                        {
                            System.Diagnostics.Debug.WriteLine(
                                $"*** FYI *** Checking whether the logging-client session associated with the specified ticket, '{ticket}', belongs to the same assembly reference as the one passed in via the method parameter, 'clientAssembly'.  Returning it, if that is the case..."
                            );

                            return !ReferenceEquals(result.ClientAssembly, clientAssembly)
                                ? default
                                : result;
                        }

                        // The logging-client session associated with the specified ticket,
                        // '{ticket}', is null.  There is nothing to do.
                        System.Diagnostics.Debug.WriteLine(
                            $"*** ERROR *** The logging-client session associated with the specified ticket, '{ticket}', is null.  Nothing to do..."
                        );

                        // stop.
                        return result;
                    }

                    /*
                     * If we are here, then there was no corresponding logging-client session found
                     * that corresponds to the specified 'ticket'. Therefore, attempt to create a
                     * new logging-client session and add it to the collection of registered
                     * logging-client sessions.
                     */

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Making a new logging-client session for the specified ticket, '{ticket}', and assembly, '{clientAssembly.FullName}'..."
                    );

                    result = MakeNewLoggingClientSession.From(ticket, clientAssembly);

                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientSessionRegistry.GetOrCreate: Checking whether the variable, 'result', has a null reference for a value..."
                    );

                    // Check to see if the variable, 'result', has a null reference for a value. If
                    // it does, then emit an error to the Debug output, and terminate the execution
                    // of this method, returning the default return value.
                    if (result == null)
                    {
                        // The variable, 'result', has a null reference for a value.  This is not
                        // desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "LoggingClientSessionRegistry.GetOrCreate: *** ERROR ***  The variable, 'result', has a null reference for a value.  Stopping..."
                        );

                        // stop.
                        return result;
                    }

                    // We can use the variable, 'result', because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientSessionRegistry.GetOrCreate: *** SUCCESS *** The variable, 'result', has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Checking whether the logging-client session associated with the specified ticket, '{ticket}', is valid..."
                    );

                    // Check whether the logging-client session associated with the specified ticket
                    // is valid.  If it is not, then emit an error to the Debug output, and
                    // terminate the execution of this method, returning the default return value.
                    if (!result.IsValid())
                    {
                        // The logging-client session associated with the specified ticket,
                        // '{ticket}', is not valid.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            $"*** ERROR *** The logging-client session associated with the specified ticket, '{ticket}', is not valid.  Stopping..."
                        );

                        // stop.
                        return default;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientSessionRegistry.GetOrCreate: *** SUCCESS *** The logging-client session associated with the specified ticket, '{ticket}', is valid.  Proceeding to add it to the internal dictionary..."
                    );

                    _sessions.Add(ticket, result);

                    /*
                     * If we made it here with no Exception getting caught, then declare success.
                     */

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientSessionRegistry.GetOrCreate: *** SUCCESS *** Successfully created a new logging-client session for the specified ticket, '{ticket}', and assembly, '{clientAssembly.FullName}'.  Returning it to the caller..."
                    );
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
    }
}