using log4net.Core;
using log4net.Layout;
using PostSharp.Patterns.Diagnostics;
using System.IO;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Represents a custom layout for log4net, a tool for outputting log statements
    /// from applications.
    /// This class extends the PatternLayout class provided by log4net.
    /// </summary>
    /// <remarks>
    /// The Format method in this class modifies the log message by removing any
    /// trailing period before logging it.
    /// </remarks>
    [Log(AttributeExclude = true)]
    public class CustomLog4NetLayout : PatternLayout
    {
        /// <summary>
        /// Produces a formatted string as specified by the conversion pattern.
        /// </summary>
        /// <param name="loggingEvent">the event being logged</param>
        /// <param name="writer">The TextWriter to write the formatted event to</param>
        /// <remarks>
        /// Parse the <see cref="T:log4net.Core.LoggingEvent" /> using the patter
        /// format specified in the
        /// <see cref="P:log4net.Layout.PatternLayout.ConversionPattern" /> property.
        /// </remarks>
        public override void Format(
            TextWriter writer,
            LoggingEvent loggingEvent
        )
        {
            try
            {
                if (writer == null)
                    return;

                if (loggingEvent == null)
                    return;

                // Get the log message
                var message = loggingEvent.RenderedMessage;
                if (string.IsNullOrWhiteSpace(message)) return;

                // Remove trailing period if present
                if (!message.EndsWith("."))
                {
                    writer.Write(message);
                    return;
                }

                // To save memory and processor cycles, write the message
                // (except for the trailing period), character-by-character.
                for (var i = 0; i < message.Length - 1; i++)
                    writer.Write(message[i]);
            }
            catch
            {
                //Ignored.
            }
        }
    }
}