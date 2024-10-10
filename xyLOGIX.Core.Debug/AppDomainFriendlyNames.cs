using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see cref="T:System.String" /> constants that contain
    /// standardized friendly names for application domains.
    /// </summary>
    public static class AppDomainFriendlyNames
    {
        /// <summary>
        /// A <see cref="T:System.String" /> that contains the friendly name of
        /// the <c>AppDomain</c> for LINQPad.
        /// </summary>
        public const string LINQPad = "LINQPad";

        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.AppDomainFriendlyNames" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static AppDomainFriendlyNames() { }
    }
}