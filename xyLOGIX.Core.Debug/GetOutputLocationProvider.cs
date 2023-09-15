using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that
    /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" />
    /// interface.
    /// </summary>
    [Log(AttributeExclude = true)]
    public static class GetOutputLocationProvider
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" /> interface, and
        /// returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" />
        /// interface.
        /// </returns>
        public static IOutputLocationProvider SoleInstance()
            => OutputLocationProvider.Instance;
    }
}