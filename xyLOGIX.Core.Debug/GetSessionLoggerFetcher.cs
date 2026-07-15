using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Gets a reference to an instance of an object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" /> interface for a
    /// specified <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" />
    /// enumeration value, if one is implemented for the value specified.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal class GetSessionLoggerFetcher
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetSessionLoggerFetcher" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetSessionLoggerFetcher() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator" />
        /// interface.
        /// </summary>
        private static ISessionLoggerFetchApproachValidator SessionLoggerFetchApproachValidator
        {
            [DebuggerStepThrough]
            get;
        } = GetSessionLoggerFetchApproachValidator.SoleInstance();

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" /> interface for the
        /// specified <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" />
        /// enumeration value, if one is implemented for the value specified.
        /// </summary>
        /// <param name="approach">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> value(s) that
        /// identifies the session-logger fetching approach that is to be utilized for the
        /// purposes of getting a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" /> interface is to be
        /// obtained.
        /// </param>
        /// <remarks>
        /// If the specified <paramref name="approach" /> is outside of the
        /// defined value set of the
        /// <see cref="T:xyLOGIX.Core.Debug.SessionLoggerFetchApproach" /> enumeration,
        /// then the method returns a <see langword="null" /> reference.
        /// <para />
        /// A <see langword="null" /> reference is also returned if an error occurs while
        /// attempting to obtain a reference to an instance of an object that implements
        /// the <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" /> interface for the
        /// specified <paramref name="approach" />.
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:xyLOGIX.Core.Debug.ISessionLoggerFetcher" /> interface, if one
        /// is available that corresponds to the specified <paramref name="approach" />;
        /// otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        public static ISessionLoggerFetcher ForApproach(SessionLoggerFetchApproach approach)
        {
            ISessionLoggerFetcher result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"GetSessionLoggerFetcher.ForApproach: Checking whether the session-logger fetching approach, '{approach}', is within the defined value set..."
                );

                // Check whether the session-logger fetching approach, 'approach', is within the
                // defined value set.  If this is not the case, then write an error message to the
                // Debug output, and then terminate the execution of this method, while returning
                // the default return value.
                if (!SessionLoggerFetchApproachValidator.IsValid(approach))
                {
                    // The session-logger fetching approach, 'approach', is NOT within the defined
                    // value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"GetSessionLoggerFetcher.ForApproach: *** ERROR *** The session-logger fetching approach, '{approach}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"GetSessionLoggerFetcher.ForApproach: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"GetSessionLoggerFetcher.ForApproach: *** SUCCESS *** The session-logger fetching approach, '{approach}', is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"GetSessionLoggerFetcher.ForApproach: *** FYI *** Getting a reference to an instance of an object that implements the 'ISessionLoggerFetcher' interface for the session-logger fetching approach, '{approach}'..."
                );

                switch (approach)
                {
                    case SessionLoggerFetchApproach.FetchFromCache:
                        result = GetFetchFromCacheSessionLoggerFetcher.SoleInstance();
                        break;

                    case SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType:
                        result = GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher
                            .SoleInstance();
                        break;

                    case SessionLoggerFetchApproach.FetchLegacyLogger:
                        result = GetFetchLegacyLoggerSessionLoggerFetcher.SoleInstance();
                        break;

                    case SessionLoggerFetchApproach.Unknown:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(approach), approach,
                            $"There does not appear to be a Session-Logger Fetcher available for the specified approach, '{approach}'."
                        );
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to the Session-Logger Fetcher for the approach, '{approach}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to the Session-Logger Fetcher for the approach, '{approach}'.  Stopping..."
            );

            return result;
        }
    }
}