using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" />
    /// interface.
    /// </summary>
    internal static class GetOutputLocationProvider
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetOutputLocationProvider" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetOutputLocationProvider() { }

        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" /> interface, and
        /// returns a
        /// reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" />
        /// interface.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static IOutputLocationProvider SoleInstance()
        {
            IOutputLocationProvider result;

            try
            {
                result = OutputLocationProvider.Instance;
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