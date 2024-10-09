using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods for performing mathematical
    /// computations.
    /// </summary>
    internal static class Compute
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Compute" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Compute() { }

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
        internal static int ZeroFloor(int value)
            => value < 0 ? 0 : value;
    }
}