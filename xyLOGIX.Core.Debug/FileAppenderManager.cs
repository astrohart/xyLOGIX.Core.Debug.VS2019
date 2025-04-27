using log4net.Appender;
using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Provides methods to access instances of objects of type
    /// <see cref="T:log4net.Appender.FileAppender" />.
    /// </summary>
    public static class FileAppenderManager
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.FileAppenderManager" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static FileAppenderManager() { }

        /// <summary>
        /// Attempts to obtain a reference to an instance of
        /// <see cref="T:log4net.Appender.FileAppender" /> that is configured under a
        /// certain name in the application configuration file.
        /// </summary>
        /// <param name="name">
        /// (Required.) String containing the name under which the
        /// appender is configured in the application configuration file.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value is provided as the value of the
        /// <paramref name="name" /> parameter, then the method returns a
        /// <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// If a suitable configuration file entry is found, this method returns
        /// a <see cref="T:log4net.Appender.FileAppender" /> instance that corresponds to
        /// the entry; otherwise, <see langword="null" /> is returned.
        /// </returns>
        public static FileAppender GetAppenderByName([NotLogged] string name)
        {
            FileAppender result = default;

            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** FYI *** Attempting to obtain a FileAppender by name: '{name}'..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAppenderManager.GetAppenderByName *** INFO: Checking whether the value of the parameter, 'name', is blank..."
                );

                // Check whether the value of the parameter, 'name', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(name))
                {
                    // The parameter, 'name' was either passed a null value, or it is blank.  This is not desirable.
                    DebugUtils.WriteLine(
                        DebugLevel.Error,
                        "FileAppenderManager.GetAppenderByName: The parameter, 'name' was either passed a null value, or it is blank. Stopping..."
                    );

                    // stop.
                    return result;
                }

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** SUCCESS *** The parameter 'name' is not blank.  Proceeding..."
                );

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "*** FYI *** Attempting to obtain a reference to the Root Logger..."
                );

                var root = LoggerManager.GetRootLogger();

                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "FileAppenderManager.GetAppenderByName: Checking whether the variable, 'root', has a null reference for a value..."
                );

                // Check to see if the variable, root, is null.  If it is, send an error
                // to the log file, and then terminate the execution of this method,
                // returning the default return value.
                if (root == null)
                {
                    // the variable root is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetAppenderByName: *** ERROR ***  The variable, 'root', has a null reference.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, root, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetAppenderByName: *** SUCCESS *** The variable, 'root', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to obtain a reference to the first FileAppender present in the 'root.Appenders' collection whose name matches '{name}'..."
                );

                result = GetFirstFileAppenderByName(root.Appenders, name);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"FileAppenderManager.GetAppenderByName: *** SUCCESS *** Obtained a reference to the FileAppender whose name matches '{name}'.  Proceeding..."
                    : $"FileAppenderManager.GetAppenderByName: *** ERROR *** FAILED to obtain a reference to the FileAppender whose name matches '{name}'.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// If the root logger's appenders list contains appenders, returns a
        /// reference to the first one in the list.
        /// </summary>
        /// <param name="loggerRepository"> </param>
        /// <returns>
        /// Reference to an instance of
        /// <see cref="T:log4net.Appender.FileAppender" /> , or <see langword="null" /> if
        /// not found.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="loggerRepository" /> parameter is passed a
        /// <see langword="null" /> value, then this method attempts to obtain the root
        /// logger object and then obtain the first
        /// <see cref="T:log4net.Appender.FileAppender" /> configured on the root logger
        /// repository. If a suitable appender can still not be located, then the return
        /// value of this method is <see langword="null" />.
        /// </remarks>
        public static FileAppender GetFirstAppender(
            [NotLogged] ILoggerRepository loggerRepository = null
        )
        {
            FileAppender result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    loggerRepository != null
                        ? "FileAppenderManager.GetFirstAppender: *** SUCCESS *** We have been passed a valid object reference to an instance of an object that implements ILoggerRepository.  Proceeding..."
                        : "FileAppenderManager.GetFirstAppender: *** WARNING *** A null reference has been passed for the 'loggerRepository' parameter.  No matter, we will try to obtain the Root Logger instead..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetFirstAppender: Attempting to get the Root Logger..."
                );

                var root = LoggerManager.GetRootLogger(loggerRepository);

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetFirstAppender: Checking whether the variable, 'root', has a null reference for a value..."
                );

                // Check to see if the variable, root, is null.  If it is, send an error
                // to the log file, and then terminate the execution of this method,
                // returning the default return value.
                if (root == null)
                {
                    // the variable root is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstAppender: *** ERROR ***  The variable, 'root', has a null reference.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, root, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetFirstAppender: *** SUCCESS *** The variable, 'root', has a valid object reference for its value.  Proceeding..."
                );

                result = GetFirstFileAppender(root.Appenders);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to the FileAppender.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to the FileAppender.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// If feasible, attempts to obtain a reference to the first instance of
        /// <see cref="T:log4net.Appender.FileAppender" /> in the provided
        /// <paramref name="appenders" /> collection.
        /// </summary>
        /// <param name="appenders">
        /// (Required.) Reference to an instance of
        /// <see cref="T:log4net.Appender.AppenderCollection" /> that refers to the
        /// collection of <c>Appender</c>s that is to be searched.
        /// </param>
        /// <remarks>
        /// This method returns a <see langword="null" /> reference if the
        /// <paramref name="appenders" /> collection contains zero element(s).
        /// </remarks>
        /// <returns>
        /// If successful, a reference to an instance of
        /// <see cref="T:log4net.Appender.FileAppender" /> that represents the first such
        /// entry in the specified <paramref name="appenders" /> collection; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        private static FileAppender GetFirstFileAppender(
            [NotLogged] AppenderCollection appenders
        )
        {
            FileAppender result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to obtain a reference to the first FileAppender in the 'appenders' collection..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetFirstFileAppender: Checking whether the 'appenders' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, appenders, is null. If it is, send an
                // error to the log file and quit, returning the default return value of this
                // method.
                if (appenders == null)
                {
                    // The parameter, 'appenders', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppender: *** ERROR *** A null reference was passed for the 'appenders' method parameter.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetFirstFileAppender: *** SUCCESS *** We have been passed a valid object reference for the 'appenders' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FileAppenderManager.GetFirstFileAppender: Checking whether the 'appenders' collection contains greater than zero elements..."
                );

                // Check to see whether the 'appenders' collection contains greater than zero
                // elements.  Otherwise, write an error message to the log file, return the default
                // return value, and then terminate the execution of this method.
                if (appenders.Count <= 0)
                {
                    // The 'appenders' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'appenders' collection contains zero elements.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"FileAppenderManager.GetFirstFileAppender: *** SUCCESS *** {appenders.Count} element(s) were found in the 'appenders' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Searching for the first FileAppender in the 'appenders' collection..."
                );

                foreach (var appender in appenders.ToArray())
                {
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppender: Checking whether the variable 'appender' has a null reference for a value..."
                    );

                    // Check to see if the variable, appender, is null. If it is, send an error to the log file and continue to the next loop iteration.
                    if (appender == null)
                    {
                        // the variable appender is required to have a valid object reference.
                        System.Diagnostics.Debug.WriteLine(
                            "FileAppenderManager.GetFirstFileAppender: *** ERROR ***  The 'appender' variable has a null reference.  Skipping to the next loop iteration..."
                        );

                        // continue to the next loop iteration.
                        continue;
                    }

                    // We can use the variable, appender, because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppender: *** SUCCESS *** The 'appender' variable has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** FileAppenderManager.GetFirstFileAppender: Checking whether the current Appender is a FileAppender..."
                    );

                    // Check to see whether the current Appender is a FileAppender.
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next loop iteration.
                    if (!(appender is FileAppender fileAppender))
                    {
                        // The current Appender is NOT a FileAppender.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The current Appender is NOT a FileAppender.  Skipping to the next Appender..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppender: *** SUCCESS *** The current Appender is a FileAppender.  Proceeding..."
                    );

                    result = fileAppender;
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }

        /// <summary>
        /// Attempts to obtain a reference to the first instance of
        /// <see cref="T:log4net.Appender.FileAppender" /> that is configured under a
        /// certain <paramref name="name" />  in the application configuration file.
        /// </summary>
        /// <param name="appenders">
        /// (Required.) Reference to an instance of
        /// <see cref="T:log4net.Appender.AppenderCollection" /> that refers to the
        /// collection of <c>Appender</c>s that is to be searched.
        /// </param>
        /// <param name="name">
        /// (Required.) String containing the name under which the
        /// appender is configured in the application configuration file.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" />, blank, or
        /// <see cref="F:System.String.Empty" /> value is provided as the value of the
        /// <paramref name="name" /> parameter, then the method returns a
        /// <see langword="null" /> reference.
        /// </remarks>
        /// <returns>
        /// If a suitable configuration file entry is found, this method returns a
        /// <see cref="T:log4net.Appender.FileAppender" /> instance that corresponds to the
        /// entry; otherwise, a <see langword="null" /> reference is returned.
        /// </returns>
        private static FileAppender GetFirstFileAppenderByName(
            [NotLogged] AppenderCollection appenders,
            string name
        )
        {
            FileAppender result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to obtain a reference to the first FileAppender in the 'appenders' collection whose name matches '{name}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetFirstFileAppenderByName *** INFO: Checking whether the value of the parameter, 'name', is blank..."
                );

                // Check whether the value of the parameter, 'name', is blank.
                // If this is so, then emit an error message to the log file, and
                // then terminate the execution of this method.
                if (string.IsNullOrWhiteSpace(name))
                {
                    // The parameter, 'name' was either passed a null value, or it is blank.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppenderByName: The parameter, 'name' was either passed a null value, or it is blank. Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"FileAppenderManager.GetFirstFileAppenderByName: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The parameter 'name' is not blank.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetFirstFileAppenderByName: Checking whether the 'appenders' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, appenders, is null. If it is, send an
                // error to the log file and quit, returning the default return value of this
                // method.
                if (appenders == null)
                {
                    // The parameter, 'appenders', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppenderByName: *** ERROR *** A null reference was passed for the 'appenders' method parameter.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderManager.GetFirstFileAppenderByName: *** SUCCESS *** We have been passed a valid object reference for the 'appenders' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FileAppenderManager.GetFirstFileAppenderByName: Checking whether the 'appenders' collection contains greater than zero elements..."
                );

                // Check to see whether the 'appenders' collection contains greater than zero
                // elements.  Otherwise, write an error message to the log file, return the default
                // return value, and then terminate the execution of this method.
                if (appenders.Count <= 0)
                {
                    // The 'appenders' collection contains zero elements.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The 'appenders' collection contains zero elements.  Stopping..."
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"FileAppenderManager.GetFirstFileAppenderByName: *** SUCCESS *** {appenders.Count} element(s) were found in the 'appenders' collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Searching for the first FileAppender in the 'appenders' collection..."
                );

                foreach (var appender in appenders.ToArray())
                {
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppenderByName: Checking whether the variable 'appender' has a null reference for a value..."
                    );

                    // Check to see if the variable, appender, is null. If it is, send an error to the log file and continue to the next loop iteration.
                    if (appender == null)
                    {
                        // the variable appender is required to have a valid object reference.
                        System.Diagnostics.Debug.WriteLine(
                            "FileAppenderManager.GetFirstFileAppenderByName: *** ERROR ***  The 'appender' variable has a null reference.  Skipping to the next loop iteration..."
                        );

                        // continue to the next loop iteration.
                        continue;
                    }

                    // We can use the variable, appender, because it's not set to a null reference.
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppenderByName: *** SUCCESS *** The 'appender' variable has a valid object reference for its value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** FileAppenderManager.GetFirstFileAppenderByName: Checking whether the current Appender is a FileAppender..."
                    );

                    // Check to see whether the current Appender is a FileAppender.
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next loop iteration.
                    if (!(appender is FileAppender fileAppender))
                    {
                        // The current Appender is NOT a FileAppender.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "*** ERROR: The current Appender is NOT a FileAppender.  Skipping to the next Appender..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderManager.GetFirstFileAppenderByName: *** SUCCESS *** The current Appender is a FileAppender.  Checking its name..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FileAppenderManager.GetFirstFileAppenderByName: Checking whether the name of the current Appender matches '{name}'..."
                    );

                    // Check to see whether the name of the current Appender matches the name we
                    // were provided.  If this is not the case, then write an error message to the
                    // Debug log, and then skip to the next loop iteration.
                    if (!name.Equals(appender.Name))
                    {
                        // The name of the current Appender does NOT match the name we were provided.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            $"*** ERROR: The name of the current Appender does NOT match '{name}'.  Skipping to the next Appender..."
                        );

                        // skip to the next loop iteration.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"FileAppenderManager.GetFirstFileAppenderByName: *** SUCCESS *** The name of the current Appender matches '{name}'.  Proceeding..."
                    );

                    result = fileAppender;
                    break;
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}