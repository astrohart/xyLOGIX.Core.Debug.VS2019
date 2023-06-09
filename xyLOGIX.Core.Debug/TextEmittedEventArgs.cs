using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides information for <c>TextEmitted</c> event handlers.
    /// </summary>
    [Log(AttributeExclude = true)]
    public class TextEmittedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.TextEmittedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="text">
        /// (Required.) A <see cref="T:System.String" /> containing the text that is
        /// otherwise going to be written to the log.
        /// </param>
        /// <param name="level">
        /// One of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> enumeration
        /// values that indicates of what level of severity is the message.
        /// </param>
        public TextEmittedEventArgs(string text, DebugLevel level)
        {
            Text = text;
            Level = level;
        }

        /// <summary>
        /// Gets of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> enumeration
        /// values that indicates of what level of severity is the message.
        /// </summary>
        public DebugLevel Level { get; }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the text that is otherwise
        /// going to be written to the log.
        /// </summary>
        public string Text { get; }
    }
}