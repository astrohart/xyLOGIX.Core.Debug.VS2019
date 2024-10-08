﻿using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Exposes <see langword="static" /> methods to perform setup tasks. </summary>
    public static class Setup
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Setup" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Setup() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface.
        /// </summary>
        private static IEventLogManager EventLogManager
        {
            [DebuggerStepThrough] get;
        } = GetEventLogManager.SoleInstance();

        /// <summary>
        /// Sets up the Windows Event Log Application log quote to correspond
        /// either to the specified <paramref name="applicationName" />, or to a event
        /// quote name that we automatically obtain.
        /// </summary>
        /// <param name="applicationName">
        /// (Optional.) A <see cref="T:System.String" />
        /// that provides a user-friendly version of the application's name for viewing in
        /// the Windows Event Log Viewer; leave blank to use the default value.
        /// </param>
        [DebuggerStepThrough]
        public static void EventLogging(string applicationName = "")
        {
            try
            {
                DebugUtils.ApplicationName =
                    !string.IsNullOrWhiteSpace(applicationName)
                        ? applicationName
                        : GetEvent.SourceName();

                // Dump the variable DebugUtils.ApplicationName to the log
                DebugUtils.WriteLine(
                    DebugLevel.Debug,
                    $"Setup.EventLogging: DebugUtils.ApplicationName = '{DebugUtils.ApplicationName}'"
                );

                // If we found a value for the ApplicationName, then initialize the
                // This is handy in the case where the user does not have write
                // access to the C:\ProgramData directory, for example.
                if (string.IsNullOrWhiteSpace(DebugUtils.ApplicationName))
                    return;

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "Setup.EventLogging: The 'DebugUtils.ApplicationName' property has a value.  Using it as the name of the Event Log of this application."
                );

                EventLogManager.Initialize(
                    DebugUtils.ApplicationName, EventLogType.Application
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }
    }
}