using log4net;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Provides log4net logger object(s) for the current logging-client session.</summary>
    /// <remarks>This class dynamically selects the appropriate repository whenever a logger is requested. <para /> Logger object(s) are not cached globally because the current logging-client session may vary between logical execution flow(s).</remarks>
    [Log(AttributeExclude = true)]
    internal sealed class LoggingClientLogProvider
        : ILoggingClientLogProvider
    {
        /// <summary>Reference to the sole instance of an object that implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLogProvider" /> interface.</summary>
        /// <remarks><b>NOTE:</b> The purpose of this field is to cache the value of the <see cref="P:xyLOGIX.Core.Debug.LoggingClientLogProvider.Instance" /> property.</remarks>
        private static readonly ILoggingClientLogProvider _instance =
            new LoggingClientLogProvider();

        /// <summary>Initializes <see langword="static" /> data or performs actions that need to be performed once only for the <see cref="T:xyLOGIX.Core.Debug.LoggingClientLogProvider" /> class.</summary>
        /// <remarks>This constructor is called automatically prior to the first instance being created or before any <see langword="static" /> member is referenced. <para /> We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c> attribute in order to simplify the logging output.</remarks>
        [Log(AttributeExclude = true)]
        static LoggingClientLogProvider() { }

        /// <summary>Initializes a new instance of the <see cref="T:xyLOGIX.Core.Debug.LoggingClientLogProvider" /> class and returns a reference to it.</summary>
        /// <remarks>This empty, <see langword="private" /> constructor prohibits callers from directly allocating instance(s) of this Singleton class. <para /> Callers obtain its sole instance through the <see cref="P:xyLOGIX.Core.Debug.LoggingClientLogProvider.Instance" /> property.</remarks>
        [Log(AttributeExclude = true)]
        private LoggingClientLogProvider()
        { }

        /// <summary>Gets a reference to the sole instance of an object that implements the <see cref="T:xyLOGIX.Core.Debug.ILoggingClientLogProvider" /> interface.</summary>
        internal static ILoggingClientLogProvider Instance
        {
            [DebuggerStepThrough]
            get
            {
                return _instance;
            }
        }

        /// <summary>Gets a reference to an instance of an object that implements the <see cref="T:log4net.ILog" /> interface for the specified source type.</summary>
        /// <param name="sourceType">(Required.) Reference to an instance of <see cref="T:System.Type" /> that identifies the source of the logging record(s).</param>
        /// <returns>Reference to an instance of an object that implements the <see cref="T:log4net.ILog" /> interface; otherwise, <see langword="null" />.</returns>
        /// <remarks>If <paramref name="sourceType" /> is <see langword="null" />, then this method returns <see langword="null" />. <para /> If no valid specialized logging-client session is active, then the ordinary log4net repository is utilized. <para /> If a valid specialized session is active but a logger cannot be obtained from its repository, then this method returns <see langword="null" />.</remarks>
        [return: NotLogged]
        public ILog Get([NotLogged] Type sourceType)
        {
            ILog result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.Get: Checking whether the method parameter, 'sourceType', has a null reference for a value..."
                );

                // Check whether the method parameter, 'sourceType', has a null reference for a value.  If this is the case, then write an error message to the Debug output, and then terminate the execution of this method, returning the default return value.
                if (sourceType == null)
                {
                    // The method parameter, 'sourceType', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.Get: *** ERROR *** A null reference was passed for the method parameter, 'sourceType'.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.Get: *** SUCCESS *** The method parameter, 'sourceType', refers to a valid object.  Proceeding..."
                );

                ILoggingClientSession session =
                    LoggingSubsystemManager.CurrentClientSession;

                // Check whether a specialized logging-client session is active.  If this is not the case, then obtain the logger from the ordinary log4net repository and return it.
                if (session == null)
                {
                    result = GetLegacyLogger(sourceType);

                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.Get: Checking whether the current logging-client session has valid setting(s)..."
                );

                // Check whether the current logging-client session has valid setting(s). If this is not the case, then use the ordinary legacy repository.
                if (!session.IsValid())
                {
                    // The current logging-client session does NOT have valid setting(s). There is no usable specialized session.
                    result = GetLegacyLogger(sourceType);

                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.Get: *** SUCCESS *** The current logging-client session has valid setting(s).  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "LoggingClientLogProvider.Get: Checking whether the current logging-client session repository name is blank..."
                );

                // Check whether the current logging-client session repository name is blank.  If this is the case, then terminate the execution of this method without falling back to another component's repository.
                if (string.IsNullOrWhiteSpace(session.RepositoryName))
                {
                    // The current logging-client session repository name is blank. This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "LoggingClientLogProvider.Get: *** ERROR *** The current logging-client session repository name is blank.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"LoggingClientLogProvider.Get: *** SUCCESS *** The repository name, '{session.RepositoryName}', is not blank.  Proceeding..."
                );

                result = GetSessionLogger(
                    session.RepositoryName,
                    sourceType
                );
            }
            catch (Exception ex)
            {
                /* Do not call DebugUtils.LogException from this class. This class is utilized by DebugUtils and doing so could recursively re-enter the logger-resolution path. */

                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }

        /// <summary>Gets a reference to an instance of an object that implements the <see cref="T:log4net.ILog" /> interface from the ordinary log4net repository.</summary>
        /// <param name="sourceType">(Required.) Reference to an instance of <see cref="T:System.Type" /> that identifies the source of the logging record(s).</param>
        /// <returns>Reference to an instance of an object that implements the <see cref="T:log4net.ILog" /> interface; otherwise, <see langword="null" />.</returns>
        /// <remarks>If <paramref name="sourceType" /> is <see langword="null" />, or log4net cannot supply the logger, then this method returns <see langword="null" />.</remarks>
        [return: NotLogged]
        private static ILog GetLegacyLogger(
            [NotLogged] Type sourceType
        )
        {
            ILog result = default;

            try
            {
                if (sourceType == null) return result;

                result = LogManager.GetLogger(sourceType);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }

        /// <summary>Gets a reference to an instance of an object that implements the <see cref="T:log4net.ILog" /> interface from the specified named repository.</summary>
        /// <param name="repositoryName">(Required.) A <see cref="T:System.String" /> containing the name of the repository from which the logger is to be obtained.</param>
        /// <param name="sourceType">(Required.) Reference to an instance of <see cref="T:System.Type" /> that identifies the source of the logging record(s).</param>
        /// <returns>Reference to an instance of an object that implements the <see cref="T:log4net.ILog" /> interface; otherwise, <see langword="null" />.</returns>
        /// <remarks>If <paramref name="repositoryName" /> is blank, or <paramref name="sourceType" /> is <see langword="null" />, then this method returns <see langword="null" />. <para /> This method does not fall back to the ordinary repository because doing so could cause logging record(s) from one in-process component to be written to another component's log file.</remarks>
        [return: NotLogged]
        private static ILog GetSessionLogger(
            [NotLogged] string repositoryName,
            [NotLogged] Type sourceType
        )
        {
            ILog result = default;

            try
            {
                if (string.IsNullOrWhiteSpace(repositoryName)) return result;
                if (sourceType == null) return result;

                result = LogManager.GetLogger(
                    repositoryName,
                    sourceType
                );
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