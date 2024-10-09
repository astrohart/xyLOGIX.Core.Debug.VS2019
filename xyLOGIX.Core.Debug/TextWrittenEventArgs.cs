using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides information for <c>TextWritten</c> event handlers. </summary>
    [ExplicitlySynchronized, Log(AttributeExclude = true)]
    public class TextWrittenEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.TextWrittenEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="text">(Required.) String containing the text to be written.</param>
        public TextWrittenEventArgs(string text)
            => Text = text;

        /// <summary> Gets a string containing the text to be written. </summary>
        public string Text { [DebuggerStepThrough] get; }
    }
}