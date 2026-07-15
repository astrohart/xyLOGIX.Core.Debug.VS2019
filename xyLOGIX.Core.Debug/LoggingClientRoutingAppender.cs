using log4net.Appender;
using log4net.Core;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
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
    [Log(AttributeExclude = true)]
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
            try
            {
                RoutingRepository = routingRepository ??
                                    throw new ArgumentNullException(nameof(routingRepository));
                FallbackRepository = fallbackRepository ??
                                     throw new ArgumentNullException(nameof(fallbackRepository));
            }
            catch (Exception ex)
            {
                /* Do not call DebugUtils.LogException here. Doing so could re-enter this appender
                 while it is being constructed. */

                System.Diagnostics.Debug.WriteLine(ex);

                RoutingRepository = default;
                FallbackRepository = default;
            }
        }

        /// <summary>
        /// Gets or sets a reference to the log4net repository that receives
        /// logging event(s) when no specialized logging-client session is active.
        /// </summary>
        internal ILoggerRepository FallbackRepository
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets a reference to the log4net repository that contains this
        /// appender.
        /// </summary>
        private ILoggerRepository RoutingRepository
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
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
                if (loggingEvent == null) return;
                if (_isRouting) return;

                _isRouting = true;

                var targetRepository = GetTargetRepository();

                if (targetRepository == null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.Append: *** WARNING *** No target logging repository could be resolved.  The logging event will not be forwarded."
                    );

                    return;
                }

                if (RoutingRepository == null)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.Append: *** ERROR *** The 'RoutingRepository' property has a null reference for a value.  The logging event will not be forwarded."
                    );

                    return;
                }

                if (ReferenceEquals(targetRepository, RoutingRepository))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.Append: *** ERROR *** The target repository is the routing repository itself.  Recursive routing has been prevented."
                    );

                    return;
                }

                targetRepository.Log(loggingEvent);
            }
            catch (Exception ex)
            {
                /* Do not call DebugUtils.LogException here. Doing so could recursively re-enter
                 this appender. */

                System.Diagnostics.Debug.WriteLine(ex);
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
                var session = LoggingSubsystemManager.CurrentClientSession;

                if (session == null)
                {
                    result = FallbackRepository;

                    return result;
                }

                if (!session.IsValid())
                {
                    result = FallbackRepository;

                    return result;
                }

                if (session.Repository == null)
                {
                    result = FallbackRepository;

                    return result;
                }

                result = session.Repository;
            }
            catch (Exception ex)
            {
                /* Do not call DebugUtils.LogException here. Doing so could recursively re-enter
                 this appender. */

                System.Diagnostics.Debug.WriteLine(ex);

                result = FallbackRepository;
            }

            return result;
        }
    }
}