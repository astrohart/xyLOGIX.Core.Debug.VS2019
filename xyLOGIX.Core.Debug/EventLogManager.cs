using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Class to manage access to the event log. </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public class EventLogManager : IEventLogManager
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static EventLogManager() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected EventLogManager()
        {
            // set defaults
            Source = string.Empty;
            Type = EventLogType.Unknown;
        }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface
        /// that
        /// manages our access to the Windows System Event Logs.
        /// </summary>
        public static IEventLogManager Instance { [DebuggerStepThrough] get; } =
            new EventLogManager();

        /// <summary>
        /// Gets a value indicating whether this object has been properly
        /// initialized.
        /// </summary>
        public bool IsInitialized
            => !string.IsNullOrWhiteSpace(Source) &&
               Type != EventLogType.None && Type != EventLogType.Unknown;

        /// <summary>
        /// Gets or sets the quote of events. Typically, this is the name of the
        /// application that is sending the events.
        /// </summary>
        /// <remarks>
        /// This property must be set before logging events, otherwise an error
        /// will occur.
        /// </remarks>
        public string Source
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] private set;
        }

        /// <summary>
        /// Gets or sets the type of log to which events are to be sent
        /// (Application, System, Security, etc.).
        /// </summary>
        /// <remarks>
        /// This property must be set before logging events, otherwise an error
        /// will occur.
        /// </remarks>
        public EventLogType Type
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] private set;
        }

        /// <summary>
        /// Sends an Error event to the system event log pointed to by the
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Source" /> and
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Type" /> properties. The
        /// content of
        /// the logging message is specified by the <paramref name="content" /> parameter.
        /// </summary>
        /// <param name="content"> String specifying the content of the event log message. </param>
        public void Error(string content)
        {
            if (string.IsNullOrWhiteSpace(Source) ||
                Type == EventLogType.None || Type == EventLogType.Unknown)
                return;

            if (string.IsNullOrWhiteSpace(content))
                return;

            EventLog.WriteEntry(Source, content, EventLogEntryType.Error);
        }

        /// <summary>
        /// Sends an Info event to the system event log pointed to by the
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Source" /> and
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Type" /> properties. The
        /// content of
        /// the logging message is specified by the <paramref name="content" /> parameter.
        /// </summary>
        /// <param name="content">
        /// (Required.) String specifying the content of the event
        /// log message.
        /// </param>
        public void Info(string content)
        {
            if (string.IsNullOrWhiteSpace(Source) ||
                Type == EventLogType.None || Type == EventLogType.Unknown)
                return;

            if (string.IsNullOrWhiteSpace(content))
                return;

            EventLog.WriteEntry(Source, content, EventLogEntryType.Information);
        }

        /// <summary> Initializes event logging for your application. </summary>
        /// <param name="eventSourceName">
        /// (Required.) String containing the name of the
        /// application that will be sending events.
        /// </param>
        /// <param name="logType">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.EventLogType" /> values that
        /// specifies the
        /// type of log to send events to.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the operation(s) completed successfully;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public bool Initialize(
            [NotLogged] string eventSourceName,
            EventLogType logType
        )
        {
            var result = false;

            try
            {
                // Dump the argument of the parameter, eventSourceName, to the Debug output
                System.Diagnostics.Debug.WriteLine($"EventLogManager.Initialize: eventSourceName = '{eventSourceName}'");

                System.Diagnostics.Debug.WriteLine(
                    "EventLogManager.Initialize *** INFO: Checking whether the value of the parameter, 'eventSourceName', is blank..."
                );

                // Check whether the value of the parameter, 'eventSourceName', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(eventSourceName))
                {
                    // The parameter, 'eventSourceName' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "EventLogManager.Initialize: *** ERROR *** The parameter, 'eventSourceName' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"EventLogManager.Initialize: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'eventSourceName' is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "EventLogManager.Initialize: Checking whether the 'logType' parameter is set to something OTHER THAN 'Unknown' or 'None'..."
                );

                // Check to see whether the 'logType' parameter is set to something OTHER THAN 'Unknown' or 'None'.
                // If this is not the case, then write an error message to the Debug output,
                // and then terminate the execution of this method.
                if (logType == EventLogType.Unknown ||
                    logType == EventLogType.None)
                {
                    // The 'logType' parameter is set to either 'Unknown' or 'None'.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'logType' parameter is set to either 'Unknown' or 'None'.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** EventLogManager.Initialize: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "EventLogManager.Initialize: *** SUCCESS *** The 'logType' parameter is set to something OTHER THAN 'Unknown' or 'None'.  Proceeding..."
                );

                // Dump the argument of the parameter, 'logType', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: logType = '{logType}'"
                );

                /*
                 * For cybersecurity reasons, and to defeat reverse-engineering,
                 * check the value of the 'logType' parameter to ensure that it
                 * is not set to a value outside the set of valid values defined
                 * by the xyLOGIX.Core.Debug.EventLogType
                 * enumeration.
                 *
                 * In principle, since all C# enums devolve to integer values, a
                 * hacker could insert a different value into the CPU register that the
                 * 'logType' parameter is read from and thereby make this application
                 * do something it's not intended to do.
                 */

                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: Checking whether the value of the 'logType' parameter, i.e., '{logType}', is within the defined value set of its enumerated data type..."
                );

                // Check whether the value of the 'logType' parameter is within the defined value set of its
                // enumeration data type.  If this is not the case, then write an error message to the log
                // file, and then terminate the execution of this method.
                if (!Enum.IsDefined(typeof(EventLogType), logType))
                {
                    // The value of the 'logType' parameter is NOT within the defined value set for its enumerated data type.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The value of the 'logType' parameter, i.e., '{logType}', is NOT within the defined value set of its enumerated data type.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: *** SUCCESS *** The value of the 'logType' parameter, i.e., '{logType}', is within the defined value set of its enumerated data type.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "EventLogManager.Initialize: Checking whether neither the 'Unknown' nor 'None' value(s) have been specified for the 'logType' parameter..."
                );

                // Check whether neither the 'Unknown' nor 'None' value(s) have
                // been specified for the argument of the 'logType' parameter.
                // If this is NOT the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (EventLogType.Unknown.Equals(logType) ||
                    EventLogType.None.Equals(logType))
                {
                    // The 'Unknown' value has been specified for the 'logType' parameter.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'Unknown' or 'None' value(s) have been specified for the 'logType' parameter.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "EventLogManager.Initialize: *** SUCCESS *** Neither the 'Unknown' nor 'None' value(s) have NOT been specified for the 'logType' parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** EventLogManager.Initialize: Checking whether the Event Log already has a source, '{eventSourceName}'..."
                );

                // Check to see whether the Event Log already has a source by the name of
                // 'eventSourceName'.  If this is not the case, then write an error message
                // to the Debug log and then terminate the execution of this method.
                if (!EventLog.SourceExists(eventSourceName))
                {
                    // No Event Source having the name 'eventSourceName' is currently configured.  Attempt to create such a source.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** WARNING: No Event Source having the name '{eventSourceName}' is currently configured.  Attempting to create such a source..."
                    );

                    EventLog.CreateEventSource(
                        eventSourceName, logType.ToString()
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"EventLogManager.Initialize: *** SUCCESS *** The Event Source, '{eventSourceName}', has been successfully created.  Proceeding..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: *** SUCCESS *** The Event Log already has a source, '{eventSourceName}.  Proceeding..."
                );

                // Finally, save the event quote and type settings in the
                // Source and Type properties.
                Source = eventSourceName;
                Type = logType;
            }
            catch (Exception ex)
            {
                // If an exception was caught, de-initialize the member
                // prevent this class from working in future calls.

                Source = string.Empty;
                Type = EventLogType.Unknown;

                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Sends a Warning event to the system event log pointed to by the
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Source" /> and
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Type" /> properties. The
        /// content of
        /// the logging message is specified by the <paramref name="content" /> parameter.
        /// </summary>
        /// <param name="content"> String specifying the content of the event log message. </param>
        public void Warn(string content)
        {
            if (string.IsNullOrWhiteSpace(Source) ||
                Type == EventLogType.None || Type == EventLogType.Unknown)
                return;

            if (string.IsNullOrWhiteSpace(content))
                return;

            EventLog.WriteEntry(Source, content, EventLogEntryType.Warning);
        }
    }
}