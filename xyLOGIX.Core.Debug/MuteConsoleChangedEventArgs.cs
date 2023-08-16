using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides information for <c>MuteConsoleChanged</c> event handlers.
    /// </summary>
    [Log(AttributeExclude = true)]
    public class MuteConsoleChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="newValue">
        /// (Required.) A <see cref="T:System.Boolean" /> value that matches the current
        /// value of the
        /// <see cref="P:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole" />
        /// property.
        /// </param>
        public MuteConsoleChangedEventArgs(bool newValue)
            => NewValue = newValue;

        /// <summary>
        /// Gets a <see cref="T:System.Boolean" /> value that matches the current value of
        /// the <see cref="P:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole" />
        /// property.
        /// </summary>
        public bool NewValue { get; }
    }
}