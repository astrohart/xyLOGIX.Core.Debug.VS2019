﻿using log4net.Appender;
using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all
    /// <c>Appender Factory</c>(ies).
    /// </summary>
    public abstract class AppenderRetrieverBase : IAppenderRetriever
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrieverBase" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static AppenderRetrieverBase() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.AppenderRetrieverBase" /> and returns a
        /// reference
        /// to it.
        /// </summary>
        /// <remarks>
        /// <strong>NOTE:</strong> This constructor is marked <see langword="protected" />
        /// due to the fact that this class is marked <see langword="abstract" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        protected AppenderRetrieverBase() { }

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration
        /// value that identifies how this <c>Appender Factory</c> operates.
        /// </summary>
        public abstract AppenderRetrievalMode Mode
        {
            [DebuggerStepThrough] get;
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator" />
        /// interface that is used to validate the value(s) of the property(ies) of an
        /// instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface
        /// for the specified <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" />
        /// that is provided by the current value of the
        /// <see cref="P:xyLOGIX.Core.Debug.AppenderRetrieverBase.Mode" /> property.
        /// </summary>
        protected IRollingFileAppenderConfigurationValidator
            RollingFileAppenderConfigurationValidator
        {
            [DebuggerStepThrough]
            get => GetRollingFileAppenderConfigurationValidator.For(Mode);
        }

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
        public abstract IAppender GetAppender(
            [NotLogged] IRollingFileAppenderConfiguration config
        );
    }
}