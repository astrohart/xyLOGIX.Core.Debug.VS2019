using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Class to manage access to the event log. </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    internal class EventLogManager : IEventLogManager
    {
        /// <summary>
        /// Empty, <see langword="static" /> constructor to prohibit direct allocation of
        /// this
        /// class.
        /// </summary>
        static EventLogManager() { }

        /// <summary>
        /// Empty, <see langword="private" /> constructor to prohibit direct allocation of
        /// this
        /// class.
        /// </summary>
        [Log(AttributeExclude = true)]
        private EventLogManager()
        {
            // set defaults
            Source = string.Empty;
            Type = EventLogType.Unknown;
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IEventLogTypeValidator" /> interface.
        /// </summary>
        private static IEventLogTypeValidator EventLogTypeValidator
        {
            [DebuggerStepThrough] get;
        } = GetEventLogTypeValidator.SoleInstance();

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IEventLogManager" /> interface
        /// that
        /// manages our access to the Windows System Event Logs.
        /// </summary>
        internal static IEventLogManager
            Instance { [DebuggerStepThrough] get; } = new EventLogManager();

        /// <summary>
        /// Gets a value indicating whether this object has been properly
        /// initialized.
        /// </summary>
        public bool IsInitialized
        {
            [DebuggerStepThrough]
            get
            {
                var result = false;

                try
                {
                    if (string.IsNullOrWhiteSpace(Source)) return result;

                    result = !EventLogType.None.Equals(Type) &&
                             !EventLogType.Unknown.Equals(Type);
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = false;
                }

                return result;
            }
        }

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
        public void Error([NotLogged] string content)
        {
            try
            {
                /*
                 * NOTE: Since it is expected that the implementation of this
                 * method is fairly straightforward, we will not be using the
                 * logging infrastructure to log the progress of this method.
                 */

                if (string.IsNullOrWhiteSpace(content)) return;
                if (!IsInitialized) return;

                EventLog.WriteEntry(Source, content, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
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
        public void Info([NotLogged] string content)
        {
            try
            {
                /*
                 * NOTE: Since it is expected that the implementation of this
                 * method is fairly straightforward, we will not be using the
                 * logging infrastructure to log the progress of this method.
                 */

                if (string.IsNullOrWhiteSpace(content)) return;
                if (!IsInitialized) return;

                EventLog.WriteEntry(
                    Source, content, EventLogEntryType.Information
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary> Initializes event logging for your application. </summary>
        /// <param name="eventSourceName">
        /// (Required.) String containing the name of the
        /// application that will be sending events.
        /// </param>
        /// <param name="logType">
        /// (Required.) One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.EventLogType" /> value(s) that
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
                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: eventSourceName = '{eventSourceName}'"
                );

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

                // Dump the argument of the parameter, 'logType', to the log
                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: logType = '{logType}'"
                );

                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: Checking whether the type of event log, '{logType}', is within the defined value set..."
                );

                // Check to see whether the type of event log is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!EventLogTypeValidator.IsValid(logType))
                {
                    // The type of event log is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The type of event log, '{logType}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** EventLogManager.Initialize: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: *** SUCCESS *** The type of event log, '{logType}', is within the defined value set.  Proceeding..."
                );


                System.Diagnostics.Debug.WriteLine(
                    $"*** EventLogManager.Initialize: Checking whether the Event Log already has a source called, '{eventSourceName}'..."
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

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"EventLogManager.Initialize: Result = {true}"
                    );

                    // stop.
                    return true;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"EventLogManager.Initialize: *** SUCCESS *** The Event Log already has a source called, '{eventSourceName}'.  Proceeding..."
                );

                // Finally, save the event quote and type settings in the
                // Source and Type properties.
                Source = eventSourceName;
                Type = logType;

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
            }
            catch (Exception ex)
            {
                // If an exception was caught, de-initialize the member
                // prevent this class from working in future calls.

                Source = string.Empty;
                Type = EventLogType.Unknown;

                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"EventLogManager.Initialize: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Sends a Warning event to the system event log pointed to by the
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Source" /> and
        /// <see cref="P:xyLOGIX.Core.Debug.EventLogManager.Type" /> properties. The
        /// content of
        /// the logging message is specified by the <paramref name="content" /> parameter.
        /// </summary>
        /// <param name="content"> String specifying the content of the event log message. </param>
        public void Warn([NotLogged] string content)
        {
            try
            {
                /*
                 * NOTE: Since it is expected that the implementation of this
                 * method is fairly straightforward, we will not be using the
                 * logging infrastructure to log the progress of this method.
                 */

                if (string.IsNullOrWhiteSpace(content)) return;
                if (!IsInitialized) return;

                EventLog.WriteEntry(Source, content, EventLogEntryType.Warning);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}