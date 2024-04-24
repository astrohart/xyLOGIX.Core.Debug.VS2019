using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.Reflection;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods for interacting with the
    /// Windows Event Log.
    /// </summary>
    public static class GetEvent
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetEvent" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetEvent() { }

        /// <summary>
        /// Attempts to obtain a user-friendly display name for the event-logging
        /// quote, based on the name of the application that is calling this debug logging
        /// library.
        /// </summary>
        /// <returns></returns>
        public static string SourceName()
        {
            var result = string.Empty;

            try
            {
                var eventLoggingAssembly =
                    GetAssembly.ToUseForEventLogging(
                        Assembly.GetExecutingAssembly()
                    );
                if (eventLoggingAssembly == null)
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** Could not obtain a reference to the .NET assembly that contains the application entry-point.  Falling back to the calling assembly..."
                    );
                    return result;
                }

                var eventLoggingAssemblyPathname =
                    eventLoggingAssembly.Location;
                if (string.IsNullOrWhiteSpace(eventLoggingAssemblyPathname) ||
                    !File.Exists(eventLoggingAssemblyPathname))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "GetEvent.SourceName: The fully-qualified pathname of the entry-point assembly could not be determined, or a ile having that path could not be located on the filesystem."
                    );
                    return result;
                }

                result = FileVersionInfo
                         .GetVersionInfo(eventLoggingAssemblyPathname)
                         .ProductName;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = string.Empty;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug, $"GetEvent.SourceName: Result = '{result}'"
            );

            return result;
        }
    }
}