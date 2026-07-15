using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.Threading;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Manages the logging-client assembly ticket associated with the current
    /// logical execution flow.
    /// </summary>
    /// <remarks>
    /// This class utilizes <see cref="T:System.Threading.AsyncLocal`1" /> so
    /// that the selected logging-client assembly follows the current logical execution
    /// flow, including continuations that occur after an <see langword="await" />
    /// operation.
    /// <para />
    /// This class does not utilize any attribute(s) from
    /// <c>PostSharp.Patterns.Threading</c>.
    /// </remarks>
    [Log(AttributeExclude = true)]
    internal sealed class LoggingClientAssemblyContext : ILoggingClientAssemblyContext
    {
        /// <summary>
        /// Reference to an instance of
        /// <see cref="T:System.Threading.AsyncLocal`1" /> that stores the logging-client
        /// assembly ticket associated with the current logical execution flow.
        /// </summary>
        private readonly AsyncLocal<Guid> _currentTicket = new AsyncLocal<Guid>();

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientAssemblyContext" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientAssemblyContext() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientAssemblyContext" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the
        /// <see cref="P:xyLOGIX.Core.Debug.LoggingClientAssemblyContext.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientAssemblyContext() { }

        /// <summary>
        /// Gets the ticket that identifies the logging-client assembly associated
        /// with the current logical execution flow.
        /// </summary>
        /// <remarks>
        /// If no logging-client assembly is currently selected, then this
        /// property returns <see cref="F:System.Guid.Empty" />.
        /// </remarks>
        public Guid CurrentTicket
        {
            [DebuggerStepThrough]
            get
            {
                var result = Guid.Empty;

                try
                {
                    result = _currentTicket.Value;
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
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingClientAssemblyContext" /> interface.
        /// </summary>
        internal static ILoggingClientAssemblyContext Instance { [DebuggerStepThrough] get; } =
            new LoggingClientAssemblyContext();

        /// <summary>
        /// Clears the logging-client assembly ticket associated with the current
        /// logical execution flow.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if the current ticket was successfully
        /// cleared; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method assigns <see cref="F:System.Guid.Empty" /> to the current
        /// ticket.
        /// <para />
        /// If the operation fails, then the exception information is written to the Debug
        /// output and this method returns <see langword="false" />.
        /// </remarks>
        public bool Clear()
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientAssemblyContext.Clear: *** FYI *** Clearing the current ticket by setting it to the Zero GUID..."
                );

                _currentTicket.Value = Guid.Empty;

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Verifying that the current ticket was successfully cleared by checking whether it is set to the Zero GUID..."
                );

                result = Guid.Empty.Equals(_currentTicket.Value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientAssemblyContext.Clear: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Selects the logging-client assembly associated with the specified
        /// ticket for the current logical execution flow.
        /// </summary>
        /// <param name="ticket">
        /// (Required.) A <see cref="T:System.Guid" /> value that
        /// identifies a registered logging-client assembly.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the specified ticket was successfully
        /// selected; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="ticket" /> is equal to
        /// <see cref="F:System.Guid.Empty" />, then this method returns
        /// <see langword="false" /> without changing the current ticket.
        /// <para />
        /// If the operation fails, then the exception information is written to the Debug
        /// output and this method returns <see langword="false" />.
        /// </remarks>
        public bool Select([NotLogged] Guid ticket)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientAssemblyContext.Select: *** INFO *** Checking whether the assembly ticket, '{ticket}', is set to the Zero GUID..."
                );

                // Check whether the value of the specified assembly ticket  is set to the Zero
                // GUID. If this is the case, then write an error message to the Debug output, and
                // then terminate the execution of this method, returning the default return value.
                if (Guid.Empty.Equals(ticket))
                {
                    // The value of the specified assembly ticket is set to the Zero GUID.  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the assembly ticket, '{ticket}', is set to the Zero GUID.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"LoggingClientAssemblyContext.Select: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientAssemblyContext.Select: *** SUCCESS *** The value of the assembly ticket, '{ticket}', is NOT set to the Zero GUID.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Setting the current ticket to the specified assembly ticket, '{ticket}'..."
                );

                _currentTicket.Value = ticket;

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Verifying that the current ticket was successfully set to the specified assembly ticket, '{ticket}'..."
                );

                result = ticket.Equals(_currentTicket.Value);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"LoggingClientAssemblyContext.Select: Result = {result}"
            );

            return result;
        }
    }
}