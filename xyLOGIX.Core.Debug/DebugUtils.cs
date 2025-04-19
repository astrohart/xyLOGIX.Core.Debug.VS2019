using log4net;
using PostSharp.Patterns;
using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Model;
using PostSharp.Patterns.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using xyLOGIX.Core.Debug.Properties;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Helpers to manage the writing of content to the debugging log. </summary>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public static class DebugUtils
    {
        private static bool _muteConsole;

        /// <summary> The verbosity level. </summary>
        /// <remarks> Typically, applications set this to 1. </remarks>
        private static int _verbosity = 1;

        /// <summary>
        /// Initializes a new static instance of
        /// <see cref="T:xyLOGIX.Core.Debug.DebugUtils" />.
        /// </summary>
        static DebugUtils()
        {
            // default ExceptionStackDepth is 1 for a Windows Forms app. Set to
            // 2 for a Console App.
            ExceptionStackDepth = 1;

            // Create the pathname of a file that is to be utilized for logging when
            // WriteUtils is incapable of logging (such as when the logging
            // infrastructure has not yet been initialized.
            ExceptionLogPathname = Path.Combine(
                Path.GetTempPath(), $"{Guid.NewGuid():N}_log.tmp"
            );

            ClearTempExceptionLog();
        }

        /// <summary>
        /// Gets or sets the name of the application. Used for Windows event
        /// logging. Leave blank to not send events to the Application event log.
        /// </summary>
        public static string ApplicationName
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the logging produced by this
        /// object should only be written to the console as opposed to a log file.
        /// </summary>
        public static bool ConsoleOnly
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets a <see cref="T:System.String" /> that contains the pathname of a file to
        /// which error text is to be appended in the event where the <c>WriteLineCore</c>
        /// method catches an exception.
        /// </summary>
        public static string ExceptionLogPathname { [DebuggerStepThrough] get; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public static int ExceptionStackDepth
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets a list of <see cref="T:System.String" /> value(s), each of which is the
        /// fully-qualified type name of an exception, for which we will NOT force the user
        /// into the Visual Studio JIT debugger.
        /// </summary>
        public static IList<string> ExcludedExceptionTypes
        {
            [DebuggerStepThrough] get;
        } = new AdvisableCollection<string>();

        /// <summary>
        /// Gets or sets the depth down the call stack from which Exception
        /// information should be obtained.
        /// </summary>
        /// <summary>
        /// Gets or sets a
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType" /> value
        /// indicating which type of logging infrastructure is in use.
        /// </summary>
        public static LoggingInfrastructureType InfrastructureType
        {
            get;
            internal set;
        }

        /// <summary> Gets or sets a value that turns logging as a whole on or off. </summary>
        public static bool IsLogging
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets a value that indicates whether PostSharp is in use as the
        /// logging infrastructure.
        /// </summary>
        private static bool IsPostSharp
            => InfrastructureType == LoggingInfrastructureType.PostSharp;

        /// <summary>
        /// Users should set this property to the path to the log file, if
        /// logging.
        /// </summary>
        public static string LogFileName
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary> Gets or sets a value telling us to mute all console output. </summary>
        public static bool MuteConsole
        {
            [DebuggerStepThrough] get => _muteConsole;
            [DebuggerStepThrough]
            set => OutputLocationProvider.MuteConsole = _muteConsole = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to mute "DEBUG" log messages
        /// in Release mode.
        /// </summary>
        public static bool MuteDebugLevelIfReleaseMode
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets a value that represents the spigot of text from that
        /// which is produced by calls to this class' methods.
        /// </summary>
        public static TextWriter Out
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" /> interface.
        /// </summary>
        private static IOutputLocationProvider OutputLocationProvider
        {
            [DebuggerStepThrough] get;
        } = GetOutputLocationProvider.SoleInstance();

        /// <summary> Gets or sets the verbosity level. </summary>
        /// <remarks> Typically, applications set this to 1. </remarks>
        public static int Verbosity
        {
            [DebuggerStepThrough] get => _verbosity;
            [DebuggerStepThrough]
            set
            {
                var changed = _verbosity != value;
                var oldValue = _verbosity;
                _verbosity = value;
                if (changed)
                    OnVerbosityChanged(
                        new VerbosityChangedEventArgs(oldValue, value)
                    );
            }
        }

        /// <summary>
        /// Appends the specified <paramref name="text" /> directly to the file whose
        /// fully-qualified pathname is stored in the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.LogFileName" /> property, if that
        /// file exists and is writeable.
        /// </summary>
        /// <param name="text">
        /// (Required.) A <see cref="T:System.String" /> containing the
        /// content that is to be appended to the log file.
        /// </param>
        [Log(AttributeExclude = true)]
        public static void AppendText([NotLogged] string text)
            => AppendToLog(text);

        /// <summary>
        /// Appends the specified <paramref name="text" /> directly to the file whose
        /// fully-qualified pathname is stored in the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.LogFileName" /> property, if that
        /// file exists and is writeable.
        /// </summary>
        /// <param name="text">
        /// (Required.) A <see cref="T:System.String" /> containing the
        /// content that is to be appended to the log file.
        /// </param>
        [Log(AttributeExclude = true)]
        public static void AppendToLog([NotLogged] string text)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LogFileName)) return;
                if (!File.Exists(LogFileName)) return;
                if (string.IsNullOrWhiteSpace(text)) return;

                File.AppendAllText(
                    LogFileName, $"### BEGIN RAW TEXT ###{Environment.NewLine}"
                );

                File.AppendAllText(LogFileName, text);

                if (!text.EndsWith(Environment.NewLine))
                    File.AppendAllText(LogFileName, Environment.NewLine);

                File.AppendAllText(
                    LogFileName, $"### END RAW TEXT ###{Environment.NewLine}"
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                LogException(ex);
            }
        }

        /// <summary>
        /// Determines whether the debugger can be launched from the
        /// <see cref="M:xyLOGIX.Core.Debug.DebugUtils.LogException" /> method.
        /// </summary>
        /// <param name="exception">
        /// (Required.) Reference to an instance of <see cref="T:System.Exception" /> that
        /// corresponds to the particular exception that has been caught.
        /// </param>
        /// <param name="launchDebuggerConfigured">
        /// <see langword="true" /> if the user has
        /// specified that the debugger is to be launched when an exception is caught;
        /// <see langword="false" /> otherwise.
        /// <para />
        /// The default value of this parameter is <see langword="true" />.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the debugger is to be launched;
        /// <see langword="false" /> otherwise.
        /// </returns>
        [Log(AttributeExclude = true)]
        public static bool CanLaunchDebugger(
            Exception exception,
            bool launchDebuggerConfigured = true
        )
        {
            var result = false;

            try
            {
                /*
                 * Only launch the debugger if the application is already running in Debug mode.
                 *
                 * NOTE: A program can be forced to disregard the fact of whether there is a debugger
                 * attached, and still cause an abort, if the user passes the '--hoe' command-line
                 * flag to the executable. This is useful for debugging purposes, as it allows the user
                 * to see the exception message and stack trace in the console window, and then decide
                 * whether to launch the debugger or not.
                 */
                if (!Split.CommandLine(Environment.CommandLine)
                          .Contains(CommandLineParameter.HaltOnException) &
                    !Debugger.IsAttached) return result;

                /*
                 * ALWAYS stop for Assertion Exceptions.
                 */

                if (exception.IsAnyOf(typeof(AssertionFailedException)))
                    return true;

                if (!Debugger.IsAttached) return result;
                if (exception == null) return result;
                if (!launchDebuggerConfigured) return result;

                // Always launch the debugger if the message starts with
                // 'Could not load file or assembly'
                if (!IsExceptionSuppresed(exception) &&
                    exception.Message.StartsWith(
                        "Could not load file or assembly"
                    )) return true;

                // Screen out the most common and often-thrown exceptions (that are almost
                // always caught)

                if (exception.StackTrace == null) return true;

                if (exception.StackTrace.Contains("Does.FileExist") ||
                    exception.StackTrace.Contains("Does.DirectoryExist") ||
                    exception.StackTrace.Contains("Does.FolderExist"))
                    return result;

                result = !IsExceptionSuppresed(exception);
            }
            catch
            {
                //Ignored.

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Erases the file having the fully-qualified pathname specified by the value of
        /// the <see cref="P:xyLOGIX.Core.Debug.DebugUtils.ExceptionLogPathname" />
        /// property, if it is already present on the file system.
        /// </summary>
        public static void ClearTempExceptionLog()
        {
            try
            {
                if (!File.Exists(ExceptionLogPathname)) return;

                File.Delete(ExceptionLogPathname);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                LogException(ex);
            }
        }

        /// <summary> Dumps a collection to the debug log. </summary>
        /// <param name="collection">
        /// Reference to an instance of an object that implements
        /// the <see cref="T:System.Collections.ICollection" /> interface.
        /// </param>
        /// <remarks>
        /// If this method is passed a <see langword="null" /> for
        /// <paramref name="collection" /> , then it does nothing. Otherwise, the method
        /// iterates over the <paramref name="collection" /> and writes all of its elements
        /// to the log, one on each line.
        /// </remarks>
        public static void DumpCollection(ICollection collection)
        {
            if (collection == null || collection.Count <= 0) return;

            foreach (var element in collection)
            {
                if (element == null) continue;

                WriteLine(DebugLevel.Debug, element.ToString());
            }
        }

        /// <summary>
        /// Writes the text of the selected control-- which is supposed to be a
        /// CommandLink -- to the log, while, at the same time, stripping out the text
        /// "recommended", if present, in the control's caption.
        /// </summary>
        /// <param name="commandLink">
        /// Reference to an instance of an object that
        /// implements a Command Link.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the
        /// <paramref name="commandLink" /> parameter is a passed a null reference.
        /// </exception>
        public static void EchoCommandLinkText(dynamic commandLink)
        {
            if (commandLink == null)
                throw new ArgumentNullException(nameof(commandLink));

            WriteLine(
                DebugLevel.Debug, "Command link '{0}' selected",
                commandLink.Text.Replace(" (recommended)", string.Empty)
            );
        }

        /// <summary>
        /// Structures the text of an <see cref="T:System.Exception" />, a
        /// reference to an instance of which is passed in the <paramref name="e" />
        /// parameter, to be the error message on a line by itself, followed by the stack
        /// trace lines on the subsequent lines.
        /// </summary>
        /// <param name="e">
        /// Reference to a <see cref="T:System.Exception" /> that should
        /// be formatted and dumped to the log.
        /// </param>
        /// <returns> String to be written to the log. </returns>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for
        /// <paramref name="e" />, then this method returns the empty string.
        /// </remarks>
        public static string FormatException(Exception e)
        {
            if (e == null) return string.Empty;

            return string.Format(
                Resources.ExceptionMessageFormat, e.GetType(),
                e.Message.CollapseNewlinesToSpaces(), e.StackTrace
            );
        }

        /// <summary>
        /// Takes the reference to an instance of
        /// <see cref="T:System.Exception" /> that is passed in the <paramref name="e" />
        /// parameter, formats it as a friendly error message along with its stack trace,
        /// and then dumps the result to the error log.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:System.Exception" /> whose information is to be
        /// dumped.
        /// </param>
        public static void FormatExceptionAndWrite(Exception e)
            => WriteLine(DebugLevel.Error, FormatException(e));

        /// <summary> Helper method to, basically, carry out the formatting of a string. </summary>
        /// <param name="format"> (Required.) String value to be formatted. </param>
        /// <param name="args"> (Optional.) Array of format values. </param>
        /// <returns>
        /// The string content of <paramref name="format" />, processed using the
        /// <see cref="T:System.String.Format" /> method.
        /// </returns>
        /// <remarks>
        /// The string content of the <paramref name="format" /> parameter is
        /// left untouched if there are no <paramref name="args" />.
        /// </remarks>
        private static string GenerateContentFromFormat(
            string format,
            params object[] args
        )
            => args.Any() ? string.Format(format, args) : format;

        /// <summary>
        /// Determines whether the exception passed in the <paramref name="exception" /> is
        /// not to be used to jump into the JIT debugger.
        /// </summary>
        /// <param name="exception">
        /// (Required.) Reference to an instance of <see cref="T:System.Exception" /> that
        /// refers to the exception object that is to be examined.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if debugging of the specified
        /// <paramref name="exception" /> is to be suppressed; <see langword="false" /> to
        /// allow the JIT debugger to be launched.
        /// </returns>
        private static bool IsExceptionSuppresed(
            [NotLogged] Exception exception
        )
        {
            var result = false;

            try
            {
                if (exception == null) return true;

                var exceptionTypeString = exception.GetType()
                                                   .ToString();

                if (string.IsNullOrWhiteSpace(exceptionTypeString))
                    return result;

                result = exception.IsAnyOf(
                    typeof(TypeInitializationException),
                    typeof(TypeLoadException), typeof(FileNotFoundException),
                    typeof(DirectoryNotFoundException), typeof(COMException)
                ) | ExcludedExceptionTypes.Contains(exceptionTypeString);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                LogException(ex);

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Detects whether the <paramref name="content" /> is multiline. If so,
        /// then each line of content is logged separately, using the
        /// <paramref name="logMethod" /> supplied.
        /// </summary>
        /// <param name="content">
        /// (Required. String containing the already-formatted
        /// content to be logged.
        /// </param>
        /// <param name="logMethod">
        /// (Required.) Delegate specifying the logging code that
        /// is to be executed for each line of content.
        /// </param>
        /// <param name="level">
        /// A <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" />
        /// specifying the debugLevel of logging to utilize.
        /// </param>
        [DebuggerStepThrough]
        private static void LogEachLineIfMultiline(
            string content,
            Action<DebugLevel, string> logMethod,
            DebugLevel level = DebugLevel.Debug
        )
        {
            // first, format the text with string.Format
            if (string.IsNullOrWhiteSpace(content))

                // stop if the format output is blank or null
                return;
            if (logMethod == null)
                return;

            if (!content.Contains(Environment.NewLine))
            {
                logMethod(level, content);
                return;
            }

            var lines = content.Split(
                new[] { Environment.NewLine }, StringSplitOptions.None
            );
            if (!lines.Any()) return;

            // For each line, write it out at the debugLevel indicated, one by
            // one. We do this by calling the delegate supplied to this method
            foreach (var line in lines) logMethod(level, line);
        }

        /// <summary>
        /// Logs the complete information about an exception to the log, under
        /// the Error Level. Outputs the quote file and line number where the exception
        /// occurred, as well as the message of the exception and its stack trace.
        /// </summary>
        /// <param name="exception">
        /// Reference to the <see cref="T:System.Exception" /> to be
        /// logged.
        /// </param>
        /// <param name="launchDebugger">
        /// (Optional.) Value indicating whether the launch and break the debugger (if one
        /// is attached) when this method is called.
        /// <para />
        /// The default value of this parameter is <see langword="true" />.
        /// <para />
        /// <b>EXTREME CAUTION</b> It is advisable to explicitly set this parameter to
        /// <see langword="false" /> in most cases, especially when this method has the
        /// likelihood of getting called often.
        /// <para />
        /// <b>NOTE:</b> The value of this parameter is ignored, and no launch of the
        /// attached debugger occurs, when <paramref name="exception" /> is
        /// <see cref="T:System.TypeInitializationException" /> or
        /// <see cref="T:System.IO.FileNotFoundException" />, which occur so frequently as
        /// to not be useful.
        /// </param>
        public static void LogException(
            Exception exception,
            bool launchDebugger = true
        )
        {
            if (exception == null) return;

            if (exception is TypeInitializationException)
                exception = exception.InnerException;

            var message = string.Format(
                Resources.ExceptionMessageFormat, exception.GetType(),
                exception.Message, exception.StackTrace
            );

            OutputExceptionLoggingMessage(exception, message);

            /*
             * Only launch the debugger if the required condition(s) are
             * met and only after having written the detailed exception info
             * to the log file.
             */

            if (CanLaunchDebugger(exception, launchDebugger))
                ProgramFlowHelper.StartDebugger();
        }

        /// <summary> Raises the <see cref="TextEmitted" /> event. </summary>
        /// <param name="e">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Debug.Events.TextEmittedEventArgs" /> that contains
        /// the
        /// event data.
        /// </param>
        [Yielder]
        private static void OnTextEmitted([NotLogged] TextEmittedEventArgs e)
            => TextEmitted?.Invoke(e);

        /// <summary>
        /// Raises the <see cref="E:xyLOGIX.Core.Debug.DebugUtils.VerbosityChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// The <see cref="E:xyLOGIX.Core.Debug.DebugUtils.VerbosityChanged" /> event
        /// is raised whenever the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.Verbosity" /> property is updated.
        /// </remarks>
        [Yielder]
        private static void OnVerbosityChanged(
            [NotLogged] VerbosityChangedEventArgs e
        )
            => VerbosityChanged?.Invoke(e);

        /// <summary>
        /// Actually performs the work of logging the specified
        /// <paramref name="exception" /> to the log, using the specified
        /// <paramref name="message" />.
        /// </summary>
        /// <param name="exception">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.Exception" /> that identifies the exception that is being
        /// logged.
        /// </param>
        /// <param name="message">
        /// (Required.) A <see cref="T:System.String" /> that
        /// contains a formatted message that is to be written to the log file.
        /// </param>
        private static void OutputExceptionLoggingMessage(
            [NotLogged] Exception exception,
            [NotLogged] string message
        )
        {
            WriteLine(DebugLevel.Error, message);

            if (exception.InnerException == null ||
                exception is TypeInitializationException) return;

            WriteLine(DebugLevel.Error, "---");
            LogException(exception.InnerException);
        }

        /// <summary>
        /// Occurs whenever text has been emitted by the
        /// <see cref="M:xyLOGIX.Core.Debug.DebugUtils.Write" /> or
        /// <see cref="M:xyLOGIX.Core.Debug.DebugUtils.WriteLine" /> methods.
        /// </summary>
        [WeakEvent]
        public static event TextEmittedEventHandler TextEmitted;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.Verbosity" /> property is updated.
        /// </summary>
        [WeakEvent]
        public static event VerbosityChangedEventHandler VerbosityChanged;

        /// <summary>
        /// Writes the content in <paramref name="format" /> to the
        /// <paramref name="debugLevel" /> log.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values that indicates
        /// which
        /// log (DEBUG, ERROR, INFO, WARN) where the content should be written.
        /// </param>
        /// <param name="format">
        /// (Required.) String containing an optional format
        /// specifier for parameters passed in <paramref name="args" />.
        /// </param>
        /// <param name="args">
        /// (Optional.) Collection of objects whose values should be
        /// included in the <paramref name="format" /> and written to the log.
        /// </param>
        /// <remarks>
        /// If the <paramref name="format" /> parameter is a blank or empty
        /// string, then this method does nothing. If the <c>DEBUG</c> constant is not
        /// defined, then this method assumes that the application was built in Release
        /// mode. If this is so, then the method checks the value of the
        /// <see cref="P:Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode" /> property. If
        /// the property is set to true AND the <paramref name="debugLevel" /> parameter is
        /// set to <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel.Debug" /> , then
        /// this
        /// method does nothing. This method does not add a newline character after writing
        /// its content to the log.
        /// </remarks>
        public static void Write(
            DebugLevel debugLevel,
            string format,
            params object[] args
        )
        {
            if (string.IsNullOrWhiteSpace(format))

                // cannot do anything with a blank entry.
                return;

#if !DEBUG
            /* If this software is currently running in Release mode, then do not output ANY lines of text
             * that are meant to be debugging logging statements! So, that is, if we detect that the debugLevel
             * parameter is set to DebugLevel.Debug, simply stop executing this method. */

            if (MuteDebugLevelIfReleaseMode && debugLevel == DebugLevel.Debug)
                return;
#endif

            LogEachLineIfMultiline(
                GenerateContentFromFormat(format, args), WriteCore, debugLevel
            );
        }

        /// <summary>
        /// Writes non-formatted content to the log using the
        /// <paramref name="debugLevel" /> specified. No line terminator is appended to the
        /// output.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values that indicates
        /// which
        /// log (DEBUG, ERROR, INFO, WARN) where the content should be written.
        /// </param>
        /// <param name="content"> (Required.) string containing the content to be written. </param>
        /// <remarks>
        /// If the <paramref name="content" /> is a blank or empty string, then
        /// this method does nothing. This method's behavior is identical to that of
        /// <see cref="M:xyLOGIX.Core.Debug.DebugUtils.WriteCore" />, except that a newline
        /// character is appended to the end of the content.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="debugLevel" /> parameter is not one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values.
        /// </exception>
        public static void Write(DebugLevel debugLevel, string content)
            => LogEachLineIfMultiline(content, WriteCore, debugLevel);

        /// <summary>
        /// Provides the implementation details of writing messages to the log.
        /// No line terminator is added to the content written.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values that determine
        /// what
        /// logging debugLevel to utilize.
        /// </param>
        /// <param name="content">
        /// (Required.) String containing the content to be written
        /// to the log file.
        /// </param>
        /// <remarks>
        /// If the string passed in <paramref name="content" /> is blank or
        /// empty, then this method does nothing.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="debugLevel" /> parameter is not one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values.
        /// </exception>
        private static void WriteCore(DebugLevel debugLevel, string content)
        {
            // Do nothing if blank content provided.
            if (string.IsNullOrWhiteSpace(content)) return;

            try
            {
                if (Verbosity == 0) return;

                if (!MuteConsole) Console.Write(content);

                if (ConsoleOnly) return;

                if (!IsLogging) return;

                // If we are being called from LINQPad, then use Debug.WriteLine
                if ("LINQPad".Equals(AppDomain.CurrentDomain.FriendlyName))
                {
                    Console.Write(content);
                    return;
                }

                var currentMethod = MethodBase.GetCurrentMethod();
                var logger = LogManager.GetLogger(currentMethod.DeclaringType);
                switch (debugLevel)
                {
                    case DebugLevel.Error:
                        logger.Error(content);
                        EventLogManager.Instance.Error(content);
                        break;

                    case DebugLevel.Info:
                        logger.Info(content);
                        EventLogManager.Instance.Info(content);
                        break;

                    case DebugLevel.Warning:
                        logger.Warn(content);
                        EventLogManager.Instance.Warn(content);
                        break;

                    case DebugLevel.Debug:
                        logger.Debug(content);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(debugLevel), debugLevel, null
                        );
                }

                OnTextEmitted(new TextEmittedEventArgs(content, debugLevel));
            }
            catch (Exception)
            {
                //ignore
            }
        }

        /// <summary>
        /// Writes the content in <paramref name="format" /> to the
        /// <paramref name="debugLevel" /> log.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values that indicates
        /// which
        /// log (DEBUG, ERROR, INFO, WARN) where the content should be written.
        /// </param>
        /// <param name="format">
        /// (Required.) String containing an optional format
        /// specifier for parameters passed in <paramref name="args" />.
        /// </param>
        /// <param name="args">
        /// (Optional.) Collection of objects whose values should be
        /// included in the <paramref name="format" /> and written to the log.
        /// </param>
        /// <remarks>
        /// If the <paramref name="format" /> parameter is a blank or empty
        /// string, then this method does nothing. If the <c>DEBUG</c> constant is not
        /// defined, then this method assumes that the application was built in Release
        /// mode. If this is so, then the method checks the value of the
        /// <see cref="P:Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode" /> property. If
        /// the property is set to true AND the <paramref name="debugLevel" /> parameter is
        /// set to <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel.Debug" /> , then
        /// this
        /// method does nothing. This method adds a newline character after writing its
        /// content to the log.
        /// </remarks>
        public static void WriteLine(
            DebugLevel debugLevel,
            string format,
            params object[] args
        )
        {
            if (string.IsNullOrWhiteSpace(format))

                // cannot do anything with a blank entry.
                return;

#if !DEBUG
            /* If this software is currently running in Release mode, then do not output ANY lines of text
             * that are meant to be debugging logging statements! So, that is, if we detect that the debugLevel
             * parameter is set to DebugLevel.Debug, simply stop executing this method. */

            if (MuteDebugLevelIfReleaseMode && debugLevel == DebugLevel.Debug)
                return;
#endif

            LogEachLineIfMultiline(
                GenerateContentFromFormat(format, args), WriteLine, debugLevel
            );
        }

        /// <summary>
        /// Works the same as the overload which takes a
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> as its first argument,
        /// but
        /// if the formatted content consists of several lines of content, then the lines
        /// are split and logged separately, all under the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel.Debug" /> debugLevel.
        /// </summary>
        /// <param name="format">
        /// (Required.) String containing an optional format
        /// specifier for parameters passed in <paramref name="args" />.
        /// </param>
        /// <param name="args">
        /// (Optional.) Collection of objects whose values should be
        /// included in the <paramref name="format" /> and written to the log.
        /// </param>
        /// <remarks>
        /// This overload specifies that the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel.Debug" /> logging
        /// debugLevel is
        /// to be utilized for each line.
        /// </remarks>
        public static void WriteLine(string format, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(format))

                // cannot do anything with a blank entry.
                return;

            LogEachLineIfMultiline(
                GenerateContentFromFormat(format, args), WriteLine
            );
        }

        /// <summary>
        /// Writes non-formatted content to the log using the
        /// <paramref name="debugLevel" /> specified, terminated by a newline character.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values that indicates
        /// which
        /// log (DEBUG, ERROR, INFO, WARN) where the content should be written.
        /// </param>
        /// <param name="content"> (Required.) string containing the content to be written. </param>
        /// <remarks>
        /// If the <paramref name="content" /> is a blank or empty string, then
        /// this method does nothing. This method's behavior is identical to that of
        /// <see cref="M:xyLOGIX.Core.Debug.DebugUtils.WriteCore" />, except that a newline
        /// character is appended to the end of the content.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="debugLevel" /> parameter is not one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values.
        /// </exception>
        [DebuggerStepThrough]
        public static void WriteLine(DebugLevel debugLevel, string content)
            => LogEachLineIfMultiline(content, WriteLineCore, debugLevel);

        /// <summary>
        /// Provides the implementation details of writing messages to the log,
        /// one line at a time.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values that determine
        /// what
        /// logging debugLevel to utilize.
        /// </param>
        /// <param name="content">
        /// (Required.) String containing the content to be written
        /// to the log file.
        /// </param>
        /// <remarks>
        /// If the string passed in <paramref name="content" /> is blank or
        /// empty, then this method does nothing.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the
        /// <paramref name="debugLevel" /> parameter is not one of the
        /// <see cref="T:xyLOGIX.Core.Debug.Constants.DebugLevel" /> values.
        /// </exception>
        private static void WriteLineCore(
            [NotLogged] DebugLevel debugLevel,
            [NotLogged] string content
        )
        {
            // Do nothing if the content is blank or the empty string.
            if (string.IsNullOrWhiteSpace(content)) return;

            /* Do not proceed any further if PostSharp logging infrastructure is being
               utilized and the content to be log contains the word In or Done. These
               logging lines are typically made during method entry or exit, which is
               something that PostSharp handles for us. */
            if ((IsPostSharp && content.Contains("In ")) ||
                content.Contains("Done.")) return;

            try
            {
                if (Verbosity == 0) return;

                //OutputLocationProvider.WriteLine(content);

                // If we are being called from LINQPad, then use Debug.WriteLine
                if (AppDomain.CurrentDomain.FriendlyName.Contains("LINQPad"))
                {
                    return;
                }

                if (ConsoleOnly) return;

                if (!IsLogging) return;

                var currentMethod = MethodBase.GetCurrentMethod();
                var logger = LogManager.GetLogger(currentMethod.DeclaringType);

                switch (debugLevel)
                {
                    case DebugLevel.Error:
                        logger.Error(content);
                        EventLogManager.Instance.Error(content);
                        break;

                    case DebugLevel.Output:
                    case DebugLevel.Info:
                        logger.Info(content);
                        EventLogManager.Instance.Info(content);
                        break;

                    case DebugLevel.Warning:
                        logger.Warn(content);
                        EventLogManager.Instance.Warn(content);
                        break;

                    case DebugLevel.Debug:
                        logger.Debug(content);

                        //#endif
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(debugLevel), debugLevel, null
                        );
                }

                OnTextEmitted(new TextEmittedEventArgs(content, debugLevel));
            }
            catch (Exception ex)
            {
                var message = string.Format(
                    Resources.TempExceptionFileMessage,
                    DateTime.Now.ToLongDateString(),
                    DateTime.Now.ToShortTimeString(), ex.Message, ex.StackTrace
                ) + content;

                File.AppendAllText(ExceptionLogPathname, message);
            }
        }
    }
}