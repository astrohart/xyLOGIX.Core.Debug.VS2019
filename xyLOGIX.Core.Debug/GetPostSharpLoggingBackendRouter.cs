using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>Provides access to the sole PostSharp logging-backend router instance.</summary>
    [Log(AttributeExclude = true)]
    internal static class GetPostSharpLoggingBackendRouter
    {
        /// <summary>
        /// Initializes <see langword="static" /> data or performs actions that
        /// need to be performed once only for the
        /// <see cref="T:xyLOGIX.Core.Debug.GetPostSharpLoggingBackendRouter" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance
        /// being created or before any <see langword="static" /> members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetPostSharpLoggingBackendRouter() { }

        /// <summary>
        /// Gets a reference to the sole instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter" /> interface.
        /// </summary>
        /// <returns>
        /// Reference to the sole router instance; otherwise,
        /// <see langword="null" />.
        /// </returns>
        /// <remarks>
        /// If the router cannot be obtained, the exception information is written
        /// to the Debug output and this method returns <see langword="null" />.
        /// </remarks>
        [return: NotLogged]
        internal static IPostSharpLoggingBackendRouter SoleInstance()
        {
            IPostSharpLoggingBackendRouter result;

            try
            {
                result = PostSharpLoggingBackendRouter.Instance;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}