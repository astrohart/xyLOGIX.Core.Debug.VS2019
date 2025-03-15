using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Diagnostics;

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
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static VerbosityChangedEventArgs() { }

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
        public VerbosityChangedEventArgs(
            [NotLogged] int oldValue,
            [NotLogged] int newValue
        )
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