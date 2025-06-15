using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see cref="T:System.String" /> constant(s) that contain
    /// standardized friendly names for application domains.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class AppDomainFriendlyNames
    {
        /// <summary>
        /// A <see cref="T:System.String" /> that contains the friendly name of
        /// the <c>AppDomain</c> for LINQPad.
        /// </summary>
        /// <remarks>Such a value is used to detect when LINQPad is running this code.</remarks>
        public const string LINQPad = "LINQPad";
    }
}