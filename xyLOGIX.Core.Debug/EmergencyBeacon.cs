using xyLOGIX.Beacons;
using xyLOGIX.Beacons.Interfaces;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Beacon that appraises the AI that someone's pulled "the cord."
    /// </summary>
    /// <remarks>
    /// Here, "the cord" means that "pull here to stop the train" sort of
    /// cord.
    /// </remarks>
    public class EmergencyBeacon : Beacon
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static EmergencyBeacon() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected EmergencyBeacon() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Beacons.Interfaces.IBeacon" /> interface.
        /// </summary>
        public static IBeacon Instance { get; } = new EmergencyBeacon();
    }
}