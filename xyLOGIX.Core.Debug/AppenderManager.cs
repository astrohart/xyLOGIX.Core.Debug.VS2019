using log4net.Appender;
using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Manages the collection of <c>Appender</c>s that are currently in use with the
    /// logging subsystem.
    /// </summary>
    [ExplicitlySynchronized, Log(AttributeExclude = true)]
    internal class AppenderManager : IAppenderManager
    {
        /// <summary>
        /// Collection mapping a <see cref="T:System.String" /> containing a log file
        /// pathname, to a reference to an instance(s) of object(s) that each implement the
        /// <see cref="T:log4net.Appender.IAppender" /> interface.
        /// </summary>
        private readonly IDictionary<string, IAppender> _appenders =
            new AdvisableDictionary<string, IAppender>();

        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static AppenderManager() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected AppenderManager()
        { }

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

                    result = _appenders.Values.ToArray();
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
        internal static IAppenderManager
            Instance
        { [DebuggerStepThrough] get; } = new AppenderManager();

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
        /// <para />
        /// The specified <paramref name="appender" /> is also not added to the internal
        /// collection if an <c>Appender</c> is already present that corresponds to the
        /// same file.
        /// <para />
        /// The specified <paramref name="appender" /> must be of type
        /// <see cref="T:log4net.Appender.FileAppender" /> or a type that inherits it.
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

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** AppenderManager.AddAppender: Checking whether the specified Appender is a FileAppender..."
                );

                // Check to see whether the specified Appender is a FileAppender.
                // If this is not the case, then write an error message to the log file
                // and then terminate the execution of this method.
                if (!(appender is FileAppender fileAppender))
                {
                    // The specified Appender is NOT a FileAppender.  This is not desirable.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR: The specified Appender is NOT a FileAppender.  Stopping..."
                    );

                    // stop.
                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.AddAppender: *** SUCCESS *** The specified Appender is a FileAppender.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.AddAppender: Checking whether the value of the property, 'fileAppender.File', is blank..."
                );

                // Check whether the value of the fileAppender.File property is blank or null.  If this is the
                // case, then write an error message to the log file, and then terminate the execution of this
                // method.
                if (string.IsNullOrWhiteSpace(fileAppender.File))
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** A blank value seems to have been passed for the property, 'fileAppender.File'. This property is required to have a non-blank value.  Stopping..."
                    );

                    // stop.
                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.AddAppender: *** SUCCESS *** The property, 'fileAppender.File', is not blank.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.AddAppender: Checking whether the internal collection already has an element corresponding to the specified file..."
                );

                // Check to see whether the internal collection already has an element corresponding to the specified file.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (HasAppenderWithFilePath(fileAppender.File))
                {
                    // The internal collection already has an element corresponding to the specified file.  This is not desirable.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** The internal collection already has an element corresponding to the specified file.  Stopping..."
                    );

                    // stop.
                    return;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.AddAppender: *** SUCCESS *** The internal collection does NOT already have an element corresponding to the specified file.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"AppenderManager.AddAppender: *** FYI *** Adding the appender, '{fileAppender.Name}', to the internal collection of appenders."
                );

                _appenders.Add(fileAppender.File, fileAppender);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }

        /// <summary>
        /// Attempts to look up the <c>Appender</c> whose <c>File</c> property matches the
        /// specified <paramref name="logFilePath" /> (ignoring case).
        /// </summary>
        /// <param name="logFilePath">
        /// (Required.) A <see cref="T:System.String" /> that contains the fully-qualified
        /// pathname of a file that is to be used to log messages.
        /// </param>
        /// <returns>
        /// If successful, a reference to an instance of an object that implements
        /// the <see cref="T:log4net.Appender.IAppender" /> interface; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        [return: NotLogged]
        public IAppender GetFileAppenderByPath([NotLogged] string logFilePath)
        {
            IAppender result = default;

            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.GetFileAppenderByPath *** INFO: Checking whether the value of the parameter, 'logFilePath', is blank..."
                );

                // Check whether the value of the parameter, 'logFilePath', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(logFilePath))
                {
                    // The parameter, 'logFilePath' was either passed a null value, or it is blank.  This is not desirable.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "AppenderManager.GetFileAppenderByPath: The parameter, 'logFilePath', was either passed a null value, or it is blank. Stopping..."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"AppenderManager.GetFileAppenderByPath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** SUCCESS *** The parameter 'logFilePath', is not blank.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** AppenderManager.GetFileAppenderByPath: Checking whether the Appender Manager has greater than zero Appender(s) in its internal collection..."
                );

                // Check to see whether the Appender Manager has greater than zero Appender(s) in its internal collection.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!HasAppenders)
                {
                    // The Appender Manager currently has zero Appender(s) in its internal collection.  This is not desirable.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** The Appender Manager currently has zero Appender(s) in its internal collection.  Stopping..."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"*** AppenderManager.GetFileAppenderByPath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.GetFileAppenderByPath: *** SUCCESS *** The Appender Manager has greater than zero Appender(s) in its internal collection.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.GetFileAppenderByPath: *** FYI *** Looking for the Appender whose File property matches the value of the parameter, 'logFilePath'..."
                );

                _appenders.TryGetValue(logFilePath, out result);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            DebugUtils.WriteLine(
                result != null ? DebugLevel.Info : DebugLevel.Error,
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to the Appender for the file, '{logFilePath}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to the Appender for the file, '{logFilePath}'.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Determines whether an <c>Appender</c> is present that corresponds to the
        /// specified <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath">
        /// (Required.) A <see cref="T:System.String" /> that contains the fully-qualified
        /// pathname of a file for which to search.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value is passed as the argument of the
        /// <paramref name="filePath" /> parameter, then the method returns
        /// <see langword="false" />.
        /// <para />
        /// The method also returns <see langword="false" /> if the internal collection is
        /// currently empty.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if an  <c>Appender</c> is present that
        /// corresponds to the specified <paramref name="filePath" />;
        /// <see langword="false" /> otherwise.
        /// </returns>
        public bool HasAppenderWithFilePath([NotLogged] string filePath)
        {
            var result = false;

            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.HasAppenderWithFilePath *** INFO: Checking whether the value of the parameter, 'filePath', is blank..."
                );

                // Check whether the value of the parameter, 'filePath', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    // The parameter, 'filePath' was either passed a null value, or it is blank.  This is not desirable.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "AppenderManager.HasAppenderWithFilePath: The parameter, 'filePath', was either passed a null value, or it is blank. Stopping..."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"AppenderManager.HasAppenderWithFilePath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** SUCCESS *** The parameter 'filePath', is not blank.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** AppenderManager.HasAppenderWithFilePath: Checking whether the Appender Manager has greater than zero entry(ies) in its internal collection..."
                );

                // Check to see whether the Appender Manager has greater than zero entry(ies) in its internal collection.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!HasAppenders)
                {
                    // The Appender Manager currently has zero entry(ies) in its internal collection.  This is not desirable.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "*** ERROR *** The Appender Manager currently has zero entry(ies) in its internal collection.  Stopping..."
                    );

                    DebugUtils.WriteLine(
                        DebugLevel.Debug,
                        $"*** AppenderManager.HasAppenderWithFilePath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "AppenderManager.HasAppenderWithFilePath: *** SUCCESS *** The Appender Manager has greater than zero entry(ies) in its internal collection.  Proceeding..."
                );

                /*
                 * We are not actually interested in obtaining the value corresponding
                 * to the specified filePath, we simply want to know if such a key
                 * exists.
                 */

                result = _appenders.ContainsKey(filePath);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            DebugUtils.WriteLine(
                DebugLevel.Debug,
                $"AppenderManager.HasAppenderWithFilePath: Result = {result}"
            );

            return result;
        }
    }
}