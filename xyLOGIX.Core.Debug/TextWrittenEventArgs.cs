using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides information for <c>TextWritten</c> event handlers. </summary>
    [ExplicitlySynchronized]
    public class TextWrittenEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.TextWrittenEventArgs" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static TextWrittenEventArgs() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.TextWrittenEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        [Log(AttributeExclude = true)]
        public TextWrittenEventArgs() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.TextWrittenEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="text">(Required.) String containing the text to be written.</param>
        [Log(AttributeExclude = true)]
        public TextWrittenEventArgs(string text)
            => Text = text;

        /// <summary> Gets a string containing the text to be written. </summary>
        public string Text { get; }
    }
}