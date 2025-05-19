using log4net.Appender;
using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace xyLOGIX.Core.Debug
{
    public class AppenderManager : IAppenderManager
    {
        /// <summary>
        /// Collection of reference to an instance(s) object(s) that each implement the
        /// <see cref="T:log4net.Appender.IAppender" /> interface.
        /// </summary>
        private readonly IList<IAppender> _appenders =
            new AdvisableCollection<IAppender>();

        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static AppenderManager() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected AppenderManager() { }

        /// <summary>
        /// Gets the count of appenders in the internal collection.
        /// </summary>
        public int AppenderCount
        {
            [DebuggerStepThrough]
            get
            {
                int result;

                try
                {
                    result = Appenders.Length;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = 0;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to an instance of to an array of instances of objects that
        /// implement the <see cref="T:log4net.Appender.IAppender" /> interface, that are
        /// configured for use by the application.
        /// </summary>
        public IAppender[] Appenders
        {
            [DebuggerStepThrough]
            get
            {
                var result = Array.Empty<IAppender>();

                try
                {
                    if (_appenders == null) return result;
                    if (_appenders.Count <= 0) return result;

                    result = _appenders.ToArray();
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = Array.Empty<IAppender>();
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the internal collection has more than zero
        /// element(s).
        /// </summary>
        public bool HasAppenders
        {
            [DebuggerStepThrough]
            get
            {
                bool result;

                try
                {
                    result = Appenders.Length > 0;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = false;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderManager" /> interface.
        /// </summary>
        public static IAppenderManager Instance { [DebuggerStepThrough] get; } =
            new AppenderManager();

        /// <summary>
        /// Adds a reference to an instance of an object that implements the
        /// <see cref="T:log4net.Appender.IAppender" /> interface to the list of configured
        /// appenders.
        /// </summary>
        /// <param name="appender">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Appender.IAppender" /> interface that is to be added to
        /// the internal collection.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed as the argument of
        /// the <paramref name="appender" /> parameter, then it is not added to the
        /// internal collection.
        /// </remarks>
        public void AddAppender([NotLogged] IAppender appender)
        {
            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.AddAppender: Checking whether the 'appender' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, appender, is null. If it is, send an 
                // error to the log file and quit, returning from this method.
                if (appender == null)
                {
                    // The parameter, 'appender', is required and is not supposed to have a NULL value.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "AppenderManager.AddAppender: *** *ERROR *** A null reference was passed for the 'appender' method parameter.  Stopping."
                    );

                    // stop.
                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.AddAppender: *** SUCCESS *** We have been passed a valid object reference for the 'appender' method parameter."
                );

                _appenders.Add(appender);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }
    }
}