using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides information for <c>MuteConsoleChanged</c> event handlers. </summary>
    public class MuteConsoleChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MuteConsoleChangedEventArgs() { }

        /// <summary>
        /// Creates a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        [Log(AttributeExclude = true)]
        public MuteConsoleChangedEventArgs() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="newValue">
        /// (Required.) A <see cref="T:System.Boolean" /> value
        /// that matches the current value of the
        /// <see cref="P:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole" />
        /// property.
        /// </param>
        [Log(AttributeExclude = true)]
        public MuteConsoleChangedEventArgs(bool newValue)
            => NewValue = newValue;

        /// <summary>
        /// Gets a <see cref="T:System.Boolean" /> value that matches the current
        /// value of the
        /// <see cref="P:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole" />
        /// property.
        /// </summary>
        public bool NewValue { get; }
    }
}