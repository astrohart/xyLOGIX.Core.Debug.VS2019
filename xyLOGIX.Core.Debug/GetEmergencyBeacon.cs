using xyLOGIX.Beacons.Interfaces;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides access to the one and only instance of the object that implements the
    /// <see cref="T:xyLOGIX.Beacons.Interfaces.IBeacon" /> interface that is reserved for emergencies.
    /// </summary>
    public static class GetEmergencyBeacon
    {
        /// <summary>
        /// Obtains access to the sole instance of the object that implements the
        /// <see cref="T:xyLOGIX.Beacons.Interfaces.IBeacon" /> interface, and returns a
        /// reference to it.
        /// </summary>
        /// <returns>
        /// Reference to the one, and only, instance of the object that implements the
        /// <see cref="T:xyLOGIX.Beacons.Interfaces.IBeacon" /> interface.
        /// </returns>
        public static IBeacon SoleInstance()
            => EmergencyBeacon.Instance;
    }
}