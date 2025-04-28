using PostSharp.Patterns.Diagnostics;
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
        /// Attempts to determine the proper value for the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.ApplicationName" /> property, given
        /// the specified <paramref name="applicationName" />.
        /// </summary>
        /// <param name="applicationName">
        /// (Optional.) A <see cref="T:System.String" /> that contains the application name
        /// that is to be used; if this value is blank, <see langword="null" />, or the
        /// <see cref="F:System.String.Empty" /> value, then the result of attempting to
        /// get the assembly <c>ProductName</c> value is used instead.
        /// <para />
        /// The default value of this parameter is the <see cref="F:System.String.Empty" />
        /// value.
        /// </param>
        /// <returns>
        /// If successful, a <see cref="T:System.String" /> that contains the
        /// value that is to be used for the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.ApplicationName" /> property;
        /// otherwise, the <see cref="F:System.String.Empty" /> value is returned.
        /// </returns>
        private static string DetermineEventSourceName(
            string applicationName = ""
        )
        {
            var result = GetEvent.SourceName();

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "Setup.DetermineEventSourceName *** INFO: Checking whether the value of the parameter, 'applicationName', is blank..."
                );

                // Check whether the value of the parameter, 'applicationName', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(applicationName))
                {
                    // The parameter, 'applicationName' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "Setup.DetermineEventSourceName: The parameter, 'applicationName' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"Setup.DetermineEventSourceName: Result = '{result}'"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'applicationName' is not blank.  Proceeding..."
                );

                result = applicationName;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output window
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            System.Diagnostics.Debug.WriteLine(
                $"Setup.DetermineEventSourceName: Result = '{result}'"
            );

            return result;
        }

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
                System.Diagnostics.Debug.WriteLine(
                    "Setup.EventLogging: *** FYI *** Attempting to determine the value that is to be assigned to the 'DebugUtils.ApplicationName' parameter..."
                );

                DebugUtils.ApplicationName =
                    DetermineEventSourceName(applicationName);

                System.Diagnostics.Debug.WriteLine(
                    $"Setup.EventLogging: *** FYI *** Set the value of the DebugUtils.ApplicationName property to '{DebugUtils.ApplicationName}'."
                );

                // Dump the variable DebugUtils.ApplicationName to the log
                System.Diagnostics.Debug.WriteLine(
                    $"Setup.EventLogging: DebugUtils.ApplicationName = '{DebugUtils.ApplicationName}'"
                );

                // If we found a value for the ApplicationName, then initialize
                // the name of the event source as such.  This is handy in the
                // case where the user does not have write access to the
                // C:\ProgramData directory, say.

                System.Diagnostics.Debug.WriteLine(
                    "Setup.EventLogging: Checking whether the value of the 'DebugUtils.ApplicationName' property is blank..."
                );

                // Check whether the value of the DebugUtils.ApplicationName property is blank or null.  If this is the
                // case, then write an error message to the log file, and then terminate the execution of this
                // method.
                if (string.IsNullOrWhiteSpace(DebugUtils.ApplicationName))
                {
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** A blank value seems to have been passed for the 'DebugUtils.ApplicationName' property. This property is required to have a non-blank value.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "Setup.EventLogging: *** SUCCESS *** The property 'DebugUtils.ApplicationName' is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "Setup.EventLogging: The 'DebugUtils.ApplicationName' property has a value.  Using it as the name of the Event Source for this application."
                );

                EventLogManager.Initialize(
                    DebugUtils.ApplicationName, EventLogType.Application
                );

                System.Diagnostics.Debug.WriteLine(
                    $"Setup.EventLogging: *** SUCCESS *** The Event Log has been initialized with the name '{DebugUtils.ApplicationName}'."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output window
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}