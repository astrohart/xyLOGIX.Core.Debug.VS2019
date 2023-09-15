namespace xyLOGIX.Core.Debug
{
    /// <summary> Exposes static methods for performing mathematical computations. </summary>
    public static class Compute
    {
        /// <summary>
        /// Computes the zero floor.  Meaning, if the specified
        /// <paramref name="value" /> is negative, then this method returns zero.
        /// <para />
        /// If the specified <paramref name="value" /> is zero or greater, then this method
        /// is the identity.
        /// </summary>
        /// <param name="value">(Required.) Input value.</param>
        /// <returns>
        /// Zero if the specified <paramref name="value" /> is negative;
        /// otherwise, if the specified <paramref name="value" /> is zero or greater, then
        /// the method is the identity map.
        /// </returns>
        public static int ZeroFloor(this int value)
            => value < 0 ? 0 : value;
    }
}