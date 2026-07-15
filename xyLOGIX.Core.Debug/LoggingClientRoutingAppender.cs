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
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.Append: Checking whether the method parameter, 'loggingEvent', has a null reference for a value..."
                );

                // Check to see if the required parameter, loggingEvent, is null. If it is, then
                // write an error message to the log file and then terminate the execution of this
                // method.
                if (loggingEvent == null)
                {
                    // The method parameter, 'loggingEvent', is required and is not supposed to have
                    // a NULL value.  It does, and this is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.Append: *** ERROR *** A null reference was passed for the method parameter, 'loggingEvent'.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.Append: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'loggingEvent.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** LoggingClientRoutingAppender.Append: Checking whether the appender is already set to the 'Routing' state..."
                );

                // Check to see whether the appender is already set to the 'Routing' state.
                // Otherwise, write a FYI message to the Debug output, and then terminate the
                // execution of this method.
                if (_isRouting)
                {
                    // The appender is already set to the 'Routing' state.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** FYI *** The appender is already set to the 'Routing' state.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.Append: *** SUCCESS *** The appender is NOT already set to the 'Routing' state.  Setting it to that state..."
                );

                _isRouting = true;

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientRoutingAppender.Append: *** FYI *** Getting a reference to the target instance of an object implementing '{nameof(ILoggerRepository)}' that is to receive the logging event..."
                );

                var targetRepository = GetTargetRepository();

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.Append: Checking whether the variable 'targetRepository' has a null reference for a value..."
                );

                // Check to see if the variable, targetRepository, is null. If it is, send an error
                // to the Debug output and quit, returning from the method.
                if (targetRepository == null)
                {
                    // the variable targetRepository is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.Append: *** ERROR *** No target logging repository could be resolved.  The logging event will not be forwarded."
                    );

                    // stop.
                    return;
                }

                // We can use the variable, targetRepository, because it's not set to a null
                // reference.
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.Append: *** SUCCESS *** The 'targetRepository' variable has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.Append: Checking whether the property, 'RoutingRepository', has a null reference for a value..."
                );

                // Check to see if the required property, 'RoutingRepository', has a null reference
                // for a value. If that is the case, then we will write an error message to the
                // Debug output, and then terminate the execution of this method.
                if (RoutingRepository == null)
                {
                    // The property, 'RoutingRepository', has a null reference for a value.  This is
                    // not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.Append: *** ERROR *** The 'RoutingRepository' property has a null reference for a value.  The logging event will not be forwarded."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientRoutingAppender.Append: *** SUCCESS *** The property, 'RoutingRepository', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientRoutingAppender.Append: *** FYI *** Making sure that the target repository is NOT the same as the routing repository, which is '{RoutingRepository?.Name ?? "<null>"}'..."
                );

                // Make sure that the target repository is NOT the same as the routing repository.
                // If it is, then write an error message to the Debug output and then terminate the
                // execution of this method.
                if (ReferenceEquals(targetRepository, RoutingRepository))
                {
                    // The target repository is the same as the routing repository.  This is not
                    // desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientRoutingAppender.Append: *** ERROR *** The target repository is the routing repository itself.  Recursive routing has been prevented."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Forwarding the logging event to the target repository, which is '{targetRepository.Name ?? "<null>"}'..."
                );

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
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Moving this object out of the 'Routing' state..."
                );

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
                /* Do not call DebugUtils.LogException here. Doing so could recursively re-enter
                 this appender. */

                System.Diagnostics.Debug.WriteLine(ex);

                result = FallbackRepository;
            }

            return result;
        }
    }
}