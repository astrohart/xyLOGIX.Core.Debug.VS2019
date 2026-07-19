using log4net.Appender;
using log4net.Core;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Routes log4net logging event(s) to the repository assigned to the
    /// current specialized logging-client session.
    /// </summary>
    /// <remarks>
    /// If no specialized logging-client session is active, logging event(s) are
    /// forwarded to the repository identified by the
    /// <see
    ///     cref="P:xyLOGIX.Core.Debug.LoggingClientRoutingAppender.FallbackRepository" />
    /// property.
    /// <para />
    /// This appender is installed only in the dedicated PostSharp routing repository.
    /// </remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal sealed class LoggingClientRoutingAppender : AppenderSkeleton
    {
        /// <summary>
        /// A <see cref="T:System.Boolean" /> value indicating whether the current
        /// thread is already routing a logging event.
        /// </summary>
        /// <remarks>
        /// This field prevents recursive routing if a target appender emits
        /// another logging event while processing the original event.
        /// </remarks>
        [ThreadStatic] private static bool _isRouting;

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientRoutingAppender" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically before the first instance is
        /// created or before any <see langword="static" /> member is referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientRoutingAppender() { }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingClientRoutingAppender" /> class and
        /// returns a reference to it.
        /// </summary>
        /// <param name="routingRepository">
        /// (Required.) Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> that contains this
        /// appender.
        /// </param>
        /// <param name="fallbackRepository">
        /// (Optional.) Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> that is to receive
        /// logging event(s) when no specialized logging-client session is active.
        /// </param>
        /// <remarks>
        /// If <paramref name="routingRepository" /> is <see langword="null" />,
        /// this appender cannot route logging event(s).
        /// <para />
        /// A <see langword="null" /> value for <paramref name="fallbackRepository" /> is
        /// permitted.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if any of the required
        /// parameters, <paramref name="routingRepository" /> or
        /// <paramref name="fallbackRepository" />, are passed a <see langword="null" />
        /// reference for a value.
        /// </exception>
        internal LoggingClientRoutingAppender(
            [NotLogged] ILoggerRepository routingRepository,
            [NotLogged] ILoggerRepository fallbackRepository
        )
        {
            RoutingRepository = routingRepository ??
                                throw new ArgumentNullException(nameof(routingRepository));
            FallbackRepository = fallbackRepository ??
                                 throw new ArgumentNullException(nameof(fallbackRepository));
        }

        /// <summary>
        /// Gets or sets a reference to the log4net repository that receives
        /// logging event(s) when no specialized logging-client session is active.
        /// </summary>
        internal ILoggerRepository FallbackRepository
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        /// Gets a reference to the log4net repository that contains this
        /// appender.
        /// </summary>
        private ILoggerRepository RoutingRepository
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        /// Appends the specified logging event to the repository assigned to the
        /// current specialized logging-client session.
        /// </summary>
        /// <param name="loggingEvent">
        /// (Required.) Reference to an instance of
        /// <see cref="T:log4net.Core.LoggingEvent" /> containing the logging event to
        /// route.
        /// </param>
        /// <remarks>
        /// If <paramref name="loggingEvent" /> is <see langword="null" />, the
        /// current thread is already routing another event, or no suitable target
        /// repository can be resolved, this method returns without forwarding the event.
        /// <para />
        /// Exceptions are written directly to the Debug output to avoid recursively
        /// invoking the logging subsystem.
        /// </remarks>
        protected override void Append([NotLogged] LoggingEvent loggingEvent)
        {
            try
            {
                /*
                 * We will refrain from any diagnostics here, as it is expected that this method
                 * will be called quite frequently, and we don't want to flood the Debug output with
                 * messages.
                 */

                if (loggingEvent == null) return;
                if (_isRouting) return;

                _isRouting = true;

                var targetRepository = GetTargetRepository();

                if (targetRepository == null) return;
                if (RoutingRepository == null) return;

                if (ReferenceEquals(targetRepository, RoutingRepository)) return;

                targetRepository.Log(loggingEvent);
            }
            catch
            {
                //Ignored.
            }
            finally
            {
                _isRouting = false;
            }
        }

        /// <summary>
        /// Gets the log4net repository to which the current logging event should
        /// be forwarded.
        /// </summary>
        /// <returns>
        /// Reference to the repository assigned to the current specialized
        /// logging-client session; otherwise, the fallback repository.
        /// </returns>
        /// <remarks>
        /// If no valid specialized logging-client session is active, this method returns
        /// the value of the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.LoggingClientRoutingAppender.FallbackRepository" />
        /// property.
        /// <para />
        /// If no fallback repository is available, this method returns
        /// <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        private ILoggerRepository GetTargetRepository()
        {
            ILoggerRepository result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.GetTargetRepository: Checking whether the property, 'LoggingSubsystemManager.CurrentClientSession', has a null reference for a value..."
                );

                // Check to see if the required property,
                // 'LoggingSubsystemManager.CurrentClientSession', has a null reference for a value.
                // If that is the case, then we will write an error message to the Debug output, and
                // then terminate the execution of this method, while returning the default return
                // value.
                if (LoggingSubsystemManager.CurrentClientSession == null)
                {
                    // The property, 'LoggingSubsystemManager.CurrentClientSession', has a null
                    // reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.GetTargetRepository: *** ERROR *** The property, 'LoggingSubsystemManager.CurrentClientSession', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Setting the return value to the fallback repository, which is '{FallbackRepository?.Name ?? "<null>"}'..."
                    );

                    result = FallbackRepository;

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.GetTargetRepository: *** SUCCESS *** The property, 'LoggingSubsystemManager.CurrentClientSession', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.GetTargetRepository: *** FYI *** Checking whether the current logging-client session has valid setting(s)..."
                );

                // Check to see whether the current logging-client session has valid setting(s).
                // Otherwise, write an error message to the Debug output, and then terminate the
                // execution of this method, while returning the fallback repository.
                if (!LoggingSubsystemManager.CurrentClientSession.IsValid())
                {
                    // The current logging-client session does not have valid setting(s).  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.GetTargetRepository: *** ERROR *** The current logging-client session does not have valid setting(s).  Returning the Fallback Repository (if configured)..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Setting the return value to the fallback repository, which is '{FallbackRepository?.Name ?? "<null>"}'..."
                    );

                    result = FallbackRepository;

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.GetTargetRepository: *** SUCCESS *** The current logging-client session has valid setting(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.GetTargetRepository: Checking whether the property, 'LoggingSubsystemManager.CurrentClientSession.Repository', has a null reference for a value..."
                );

                // Check to see if the required property,
                // 'LoggingSubsystemManager.CurrentClientSession.Repository', has a null reference
                // for a value.  If that is the case, then we will write an error message to the
                // Debug output, and then terminate the execution of this method, while returning
                // the default return value.
                if (LoggingSubsystemManager.CurrentClientSession.Repository == null)
                {
                    // The property, 'LoggingSubsystemManager.CurrentClientSession.Repository', has
                    // a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.GetTargetRepository: *** ERROR *** The property, 'LoggingSubsystemManager.CurrentClientSession.Repository', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FYI *** Setting the return value to the fallback repository, which is '{FallbackRepository?.Name ?? "<null>"}'..."
                    );

                    result = FallbackRepository;

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.GetTargetRepository: *** SUCCESS *** The property, 'LoggingSubsystemManager.CurrentClientSession.Repository', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientRoutingAppender.GetTargetRepository: *** FYI *** Setting the return value to the current logging-client session's repository, which is '{LoggingSubsystemManager.CurrentClientSession.Repository?.Name ?? "<null>"}'..."
                );

                result = LoggingSubsystemManager.CurrentClientSession.Repository;
            }
            catch (Exception ex)
            {
                /*
                 * Do not call DebugUtils.LogException here. Doing so could recursively re-enter
                 * this appender.
                 */

                System.Diagnostics.Debug.WriteLine(ex);

                result = FallbackRepository;
            }

            return result;
        }
    }
}