using log4net.Appender;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    public class GetExistingAppenderFactory : AppenderFactoryBase
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.GetExistingAppenderFactory" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static GetExistingAppenderFactory() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.GetExistingAppenderFactory" /> and returns a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// <strong>NOTE:</strong> This constructor is marked <see langword="protected" />
        /// due to the fact that this class is marked <see langword="abstract" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        protected GetExistingAppenderFactory() { }

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration
        /// value that identifies how this <c>Appender Factory</c> operates.
        /// </summary>
        public override AppenderRetrievalMode Mode
        {
            [DebuggerStepThrough] get;
        } = AppenderRetrievalMode.GetExisting;

        /// <summary>
        /// Given the specified <paramref name="config" />, creates or retrieves an
        /// <c>Appender</c> associated with the specified settings.
        /// </summary>
        /// <param name="config">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" />
        /// interface.
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:log4net.Appender.IAppender" /> interface; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        public override IAppender GetAppender(
            [NotLogged] IRollingFileAppenderConfiguration config
        )
        {
            IAppender result = default;

            try
            {

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