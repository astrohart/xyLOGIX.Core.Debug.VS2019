using log4net.Appender;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    public class ObtainExistingAppenderRetriever : AppenderRetrieverBase
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.ObtainExistingAppenderRetriever" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static ObtainExistingAppenderRetriever() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.ObtainExistingAppenderRetriever" /> and returns
        /// a
        /// reference to it.
        /// </summary>
        /// <remarks>
        /// <strong>NOTE:</strong> This constructor is marked <see langword="protected" />
        /// due to the fact that this class is marked <see langword="abstract" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        protected ObtainExistingAppenderRetriever() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderManager" /> interface.
        /// </summary>
        private static IAppenderManager AppenderManager
        {
            [DebuggerStepThrough] get;
        } = GetAppenderManager.SoleInstance();

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration
        /// value that identifies how this <c>Appender Factory</c> operates.
        /// </summary>
        public override AppenderRetrievalMode Mode
        {
            [DebuggerStepThrough] get;
        } = AppenderRetrievalMode.ObtainExisting;

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
                System.Diagnostics.Debug.WriteLine(
                    "ObtainExistingAppenderRetriever.GetFileAppenderByPath: Checking whether the 'config' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, config, is null. If it is, send an 
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (config == null)
                {
                    // The parameter, 'config', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "ObtainExistingAppenderRetriever.GetFileAppenderByPath: *** ERROR *** A null reference was passed for the 'config' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** ObtainExistingAppenderRetriever.GetFileAppenderByPath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "ObtainExistingAppenderRetriever.GetFileAppenderByPath: *** SUCCESS *** We have been passed a valid object reference for the 'config' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "ObtainExistingAppenderRetriever.GetFileAppenderByPath: Checking whether the Appender Manager has existing Appender(s)..."
                );

                // Check to see whether the Appender Manager has existing Appender(s).
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!AppenderManager.HasAppenders)
                {
                    // The Appender Manager does NOT have any Appender(s) in its internal collection.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "ObtainExistingAppenderRetriever.GetFileAppenderByPath: *** ERROR *** The Appender Manager does NOT have any Appender(s) in its internal collection.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** ObtainExistingAppenderRetriever.GetFileAppenderByPath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "ObtainExistingAppenderRetriever.GetFileAppenderByPath: *** SUCCESS *** The Appender Manager has existing Appender(s).  Proceeding..."
                );
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