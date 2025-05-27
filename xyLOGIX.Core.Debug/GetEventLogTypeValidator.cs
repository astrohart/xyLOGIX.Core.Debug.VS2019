using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="T:xyLOGIX.Core.Debug.IEventLogTypeValidator" /> interface.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class GetEventLogTypeValidator
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IEventLogTypeValidator" /> interface, and
        /// returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IEventLogTypeValidator" /> interface.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static IEventLogTypeValidator SoleInstance()
        {
            IEventLogTypeValidator result;

            try
            {
                result = EventLogTypeValidator.Instance;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}