using PostSharp.Patterns.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Value(s) for the name(s) of assembly(ies) that are not valid for use
    /// as a client of this library (except to wrap it).
    /// </summary>
    internal static class InvalidClientAssemblyNames
    {
        /// <summary>
        /// Contains all the name(s) of those assembly(ies) that are not valid for
        /// use as a client of this library (except to wrap it).
        /// </summary>
        internal static readonly string[] All = { CoreTemplateLoggingWizards };

        /// <summary>
        /// A <see cref="T:System.String" /> that contains the name of the
        /// <c>xyLOGIX.Core.TemplateWizard.Logging</c> assembly, which is not valid for use
        /// as a client of this library (except to wrap it).
        /// </summary>
        internal const string CoreTemplateLoggingWizards = "xyLOGIX.Core.TemplateWizard.Logging";

        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.InvalidClientAssemblyNames" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static InvalidClientAssemblyNames() { }
    }
}