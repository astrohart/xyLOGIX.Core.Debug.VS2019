using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
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
        static EventLogManager() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this
        /// class.
        /// </summary>
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
        public string Source { get; private set; }

        /// <summary>
        /// Gets or sets the type of log to which events are to be sent
        /// (Application, System, Security, etc.).
        /// </summary>
        /// <remarks>
        /// This property must be set before logging events, otherwise an error
        /// will occur.
        /// </remarks>
        public EventLogType Type { get; private set; }

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
        public void Initialize(string eventSourceName, EventLogType logType)
        {
            // Check to see if the required parameter, eventSource, is blank,
            // whitespace, or null. If it is any of these, send an error to the

            // The 'eventSource' parameter must not be blank.
            if (string.IsNullOrWhiteSpace(eventSourceName))

                // stop.
                return;
            if (logType == EventLogType.Unknown || logType == EventLogType.None)
                return;

            try
            {
                // If an event quote does not exist with the specified name,
                // then create one.
                if (!EventLog.SourceExists(eventSourceName))
                    EventLog.CreateEventSource(
                        eventSourceName, logType.ToString()
                    );

                // Finally, save the event quote and type settings in the
                // Source and Type properties.
                Source = eventSourceName;
                Type = logType;
            }
            catch
            {
                // If an exception was caught, de-initialize the member
                // prevent this class from working in future calls.

                Source = string.Empty;
                Type = EventLogType.Unknown;
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