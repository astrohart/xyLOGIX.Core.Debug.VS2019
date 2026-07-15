using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" />
    /// interface for the
    /// <see cref="F:xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger" />
    /// approach.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetFetchLegacyLoggerSessionLoggerFetcher
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:GetFetchLegacyLoggerSessionLoggerFetcher" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetFetchLegacyLoggerSessionLoggerFetcher() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger" />
        /// approach, and returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements
        /// the <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" /> interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger" />
        /// approach.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static ISessionLoggerFetcher SoleInstance()
        {
            ISessionLoggerFetcher result;

            try
            {
                result = FetchLegacyLoggerSessionLoggerFetcher.Instance;
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