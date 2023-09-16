using System.ComponentModel;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Represents a handler for a <c>EmergencyStopPending</c> event. </summary>
    /// <param name="e" >
    /// A <see cref="T:System.ComponentModel.CancelEventArgs" /> that
    /// contains the event data.
    /// <para />
    /// Set the <see cref="P:System.ComponentModel.CancelEventArgs.Cancel" /> property
    /// to <see langword="true" /> to stop the pending operation.
    /// </param>
    /// <remarks>
    /// This delegate merely specifies the signature of all methods that
    /// handle the <c>EmergencyStopPending</c> event.
    /// </remarks>
    public delegate void EmergencyStopPendingEventHandler(CancelEventArgs e);
}