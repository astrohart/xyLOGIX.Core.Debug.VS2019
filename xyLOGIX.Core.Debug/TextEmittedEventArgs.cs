using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides information for <c>TextEmitted</c> event handlers. </summary>
    [ExplicitlySynchronized]
    public class TextEmittedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.TextEmittedEventArgs" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static TextEmittedEventArgs() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.TextEmittedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="text">
        /// (Required.) A <see cref="T:System.String" /> containing the
        /// text that is otherwise going to be written to the log.
        /// </param>
        /// <param name="level">
        /// One of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" />
        /// enumeration values that indicates of what level of severity is the message.
        /// </param>
        [Log(AttributeExclude = true)]
        public TextEmittedEventArgs(
            [NotLogged] string text,
            [NotLogged] DebugLevel level
        )
        {
            Text = text;
            Level = level;
        }

        /// <summary>
        /// Gets of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" />
        /// enumeration values that indicates of what level of severity is the message.
        /// </summary>
        public DebugLevel Level { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> containing the text that is
        /// otherwise going to be written to the log.
        /// </summary>
        public string Text { [DebuggerStepThrough] get; }
    }
}