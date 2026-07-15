using log4net;
using log4net.Core;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Manages the process-wide PostSharp logging backend that routes logging
    /// record(s) to specialized logging-client repository(ies).
    /// </summary>
    /// <remarks>
    /// The routing backend is installed only when explicitly requested by the
    /// session-aware logging path.
    /// <para />
    /// Until that occurs, ordinary consumers of
    /// <see cref="T:xyLOGIX.Core.Debug.LoggingSubsystemManager" /> retain the existing
    /// PostSharp backend behavior.
    /// </remarks>
    [Log(AttributeExclude = true)]
    internal sealed class PostSharpLoggingBackendRouter : IPostSharpLoggingBackendRouter
    {
        /// <summary>
        /// A <see cref="T:System.String" /> containing the unique name assigned
        /// to the process-wide PostSharp routing repository.
        /// </summary>
        private const string RoutingRepositoryName = "xyLOGIX.Core.Debug.PostSharp.Routing";

        /// <summary>
        /// Reference to the routing appender installed in the dedicated PostSharp
        /// routing repository.
        /// </summary>
        private LoggingClientRoutingAppender _routingAppender;

        /// <summary>
        /// Reference to the PostSharp backend bound to the dedicated routing
        /// repository.
        /// </summary>
        private Log4NetLoggingBackend _routingBackend;

        /// <summary>
        /// Reference to the dedicated log4net repository used by the process-wide
        /// PostSharp routing backend.
        /// </summary>
        private ILoggerRepository _routingRepository;

        /// <summary>
        /// Reference to an object used to synchronize installation and update
        /// operation(s).
        /// </summary>
        private readonly object _syncRoot = new object();

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static PostSharpLoggingBackendRouter() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// This is an empty, <see langword="private" /> constructor to prohibit
        /// direct allocation of this class, as it is a <c>Singleton</c> object accessible
        /// via the
        /// <see cref="P:xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.Instance" />
        /// property.
        /// </remarks>
        [Log(AttributeExclude = true)]
        private PostSharpLoggingBackendRouter()
        { }

        /// <summary>
        /// Gets a reference to the log4net repository that receives logging
        /// record(s) when no specialized logging-client session is active.
        /// </summary>
        public ILoggerRepository FallbackRepository
        {
            [DebuggerStepThrough]
            get
            {
                ILoggerRepository result = default;

                try
                {
                    if (_routingAppender == null) return result;

                    result = _routingAppender.FallbackRepository;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = default;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter" /> interface.
        /// </summary>
        internal static IPostSharpLoggingBackendRouter Instance { [DebuggerStepThrough] get; } =
            new PostSharpLoggingBackendRouter();

        /// <summary>
        /// Gets a value indicating whether the process-wide PostSharp logging
        /// router has been installed.
        /// </summary>
        public bool IsInstalled
        {
            [DebuggerStepThrough]
            get
            {
                var result = false;

                try
                {
                    if (_routingRepository == null) return result;
                    if (_routingAppender == null) return result;
                    if (_routingBackend == null) return result;

                    result = true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = false;
                }

                return result;
            }
        }

        /// <summary>
        /// Installs the process-wide PostSharp logging router, or updates its
        /// fallback repository if the router has already been installed.
        /// </summary>
        /// <param name="fallbackRepository">
        /// (Optional.) Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> that is to receive
        /// logging record(s) when no specialized logging-client session is active.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the router was successfully installed or
        /// updated; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// A <see langword="null" /> fallback repository is permitted.
        /// <para />
        /// If the router is already installed, this method updates its fallback repository
        /// and restores the routing backend as
        /// <see cref="P:PostSharp.Patterns.Diagnostics.LoggingServices.DefaultBackend" />.
        /// </remarks>
        public bool InstallOrUpdate([NotLogged] ILoggerRepository fallbackRepository)
        {
            var result = false;

            try
            {
                lock (_syncRoot)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "PostSharpLoggingBackendRouter.InstallOrUpdate: Checking whether the PostSharp routing backend has already been installed..."
                    );

                    if (IsInstalled)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            "PostSharpLoggingBackendRouter.InstallOrUpdate: *** SUCCESS *** The PostSharp routing backend has already been installed.  Updating its fallback repository..."
                        );

                        if (fallbackRepository != null)
                        {
                            if (!ReferenceEquals(fallbackRepository, _routingRepository))
                            {
                                _routingAppender.FallbackRepository = fallbackRepository;
                            }
                        }

                        LoggingServices.DefaultBackend = _routingBackend;

                        result = ReferenceEquals(LoggingServices.DefaultBackend, _routingBackend);

                        return result;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "PostSharpLoggingBackendRouter.InstallOrUpdate: The PostSharp routing backend has not yet been installed.  Creating it..."
                    );

                    _routingRepository = GetOrCreateRoutingRepository();

                    if (_routingRepository == null) return result;

                    if (!ConfigureRoutingRepository(_routingRepository, fallbackRepository))
                        return result;

                    _routingBackend = new Log4NetLoggingBackend(_routingRepository);

                    if (_routingBackend == null) return result;

                    LoggingServices.DefaultBackend = _routingBackend;

                    result = ReferenceEquals(LoggingServices.DefaultBackend, _routingBackend);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Configures the specified repository as the dedicated PostSharp routing
        /// repository.
        /// </summary>
        /// <param name="repository">
        /// (Required.) Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> to configure.
        /// </param>
        /// <param name="fallbackRepository">
        /// (Optional.) Reference to an instance of
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> that is to receive
        /// logging record(s) when no specialized session is active.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the repository was successfully configured;
        /// otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="repository" /> is <see langword="null" />, or is
        /// not a <see cref="T:log4net.Repository.Hierarchy.Hierarchy" />, this method
        /// returns <see langword="false" />.
        /// </remarks>
        private bool ConfigureRoutingRepository(
            [NotLogged] ILoggerRepository repository,
            [NotLogged] ILoggerRepository fallbackRepository
        )
        {
            var result = false;

            try
            {
                if (repository == null) return result;

                var hierarchy = repository as Hierarchy;

                if (hierarchy == null) return result;

                _routingAppender =
                    new LoggingClientRoutingAppender(repository, fallbackRepository)
                    {
                        Name = nameof(LoggingClientRoutingAppender)
                    };

                _routingAppender.ActivateOptions();

                hierarchy.Root.RemoveAllAppenders();
                hierarchy.Root.Level = Level.All;
                hierarchy.Root.AddAppender(_routingAppender);
                hierarchy.Configured = true;

                result = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            return result;
        }

        /// <summary>Finds the log4net repository having the specified name.</summary>
        /// <param name="repositoryName">
        /// (Required.) A <see cref="T:System.String" />
        /// containing the repository name to find.
        /// </param>
        /// <returns>
        /// Reference to the matching repository; otherwise,
        /// <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If <paramref name="repositoryName" /> is blank, no repository(ies) are
        /// available, or no matching repository exists, this method returns
        /// <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        private static ILoggerRepository FindRepository([NotLogged] string repositoryName)
        {
            ILoggerRepository result = default;

            try
            {
                if (string.IsNullOrWhiteSpace(repositoryName)) return result;

                var repositories = LogManager.GetAllRepositories();

                if (repositories == null) return result;
                if (repositories.Length <= 0) return result;

                foreach (var repository in repositories)
                {
                    if (repository == null) continue;
                    if (string.IsNullOrWhiteSpace(repository.Name)) continue;

                    if (!string.Equals(repository.Name, repositoryName, StringComparison.Ordinal))
                        continue;

                    result = repository;
                    break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }

        /// <summary>Gets or creates the dedicated PostSharp routing repository.</summary>
        /// <returns>
        /// Reference to the dedicated routing repository; otherwise,
        /// <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If the repository already exists, the existing reference is returned.
        /// <para />
        /// If repository creation fails, the repository collection is examined again in
        /// case another caller created it concurrently.
        /// </remarks>
        [return: NotLogged]
        private static ILoggerRepository GetOrCreateRoutingRepository()
        {
            ILoggerRepository result = default;

            try
            {
                result = FindRepository(RoutingRepositoryName);

                if (result != null) return result;

                try
                {
                    result = LogManager.CreateRepository(RoutingRepositoryName);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = FindRepository(RoutingRepositoryName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}