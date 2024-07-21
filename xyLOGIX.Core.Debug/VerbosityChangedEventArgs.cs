using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides information for <c>VerbosityChanged</c> event handlers. </summary>
    [ExplicitlySynchronized]
    public class VerbosityChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.VerbosityChangedEventArgs" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static VerbosityChangedEventArgs() { }

        /// <summary>
        /// Creates a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.VerbosityChangedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        [Log(AttributeExclude = true)]
        public VerbosityChangedEventArgs() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.VerbosityChangedEventArgs" /> and returns a
        /// reference to it.
        /// </summary>
        /// <param name="oldValue">
        /// (Required.) An <see cref="T:System.Int32" /> value that
        /// is the former value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.Verbosity" /> property.
        /// </param>
        /// <param name="newValue">
        /// (Required.) An <see cref="T:System.Int32" /> value that
        /// is the current value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.Verbosity" /> property.
        /// </param>
        [Log(AttributeExclude = true)]
        public VerbosityChangedEventArgs(int oldValue, int newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Gets an <see cref="T:System.Int32" /> value that is the new value of
        /// the <see cref="P:xyLOGIX.Core.Debug.DebugUtils.Verbosity" /> property.
        /// </summary>
        public int NewValue { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets an <see cref="T:System.Int32" /> value that is the former value
        /// of the <see cref="P:xyLOGIX.Core.Debug.DebugUtils.Verbosity" /> property.
        /// </summary>
        public int OldValue { [DebuggerStepThrough] get; }
    }
}