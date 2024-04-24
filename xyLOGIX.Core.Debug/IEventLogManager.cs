namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of an object that
    /// manages our access to the Windows System Event Log(s).
    /// </summary>
    public interface IEventLogManager
    {
        /// <summary>
        /// Gets a value indicating whether this object has been properly
        /// initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Gets or sets the quote of events. Typically, this is the name of the
        /// application that is sending the events.
        /// </summary>
        /// <remarks>
        /// This property must be set before logging events, otherwise an error
        /// will occur.
        /// </remarks>
        string Source { get; }

        /// <summary>
        /// Gets or sets the type of log to which events are to be sent
        /// (Application, System, Security, etc.).
        /// </summary>
        /// <remarks>
        /// This property must be set before logging events, otherwise an error
        /// will occur.
        /// </remarks>
        EventLogType Type { get; }

        /// <summary>
        /// Sends an Error event to the system event log pointed to by the
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Source" /> and
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Type" /> properties. The
        /// content of
        /// the logging message is specified by the <paramref name="content" /> parameter.
        /// </summary>
        /// <param name="content"> String specifying the content of the event log message. </param>
        void Error(string content);

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
        void Info(string content);

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
        void Initialize(string eventSourceName, EventLogType logType);

        /// <summary>
        /// Sends a Warning event to the system event log pointed to by the
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Source" /> and
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Type" /> properties. The
        /// content of
        /// the logging message is specified by the <paramref name="content" /> parameter.
        /// </summary>
        /// <param name="content"> String specifying the content of the event log message. </param>
        void Warn(string content);
    }
}