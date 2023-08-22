using log4net;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using xyLOGIX.Core.Debug.Properties;
using Console = xyLOGIX.Core.Debug.OutputMultiplexer;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Helpers to manage the writing of content to the debugging log.
    /// </summary>
    [Log(AttributeExclude = true)]
    public static class DebugUtils
    {
        /// <summary>
        /// Value that indicates whether to mute any log messages that ordinarily would be
        /// written to the interactive console.
        /// </summary>
        private static bool _muteConsole;

        /// <summary>
        /// The verbosity level.
        /// </summary>
        /// <remarks>
        /// Typically, applications set this to 1.
        /// </remarks>
        private static int _verbosity = 1;

        /// <summary>
        /// Initializes a new static instance of <see cref="DebugUtils" />.
        /// </summary>
        static DebugUtils()
        {
            InitializeOutputLocationProvider();

            // default ExceptionStackDepth is 1 for a Windows Forms app. Set to
            // 2 for a Console App.
            ExceptionStackDepth = 1;
        }

        /// <summary>
        /// Gets or sets the name of the application. Used for Windows event
        /// logging. Leave blank to not send events to the Application event log.
        /// </summary>
        public static string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the logging produced by this
        /// object should only be written to the console as opposed to a log file.
        /// </summary>
        public static bool ConsoleOnly { get; set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public static int ExceptionStackDepth { get; set; }

        /// <summary>
        /// Gets or sets the depth down the call stack from which Exception
        /// information should be obtained.
        /// </summary>
        /// <summary>
        /// Gets or sets a
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType" />
        /// value
        /// indicating which type of logging infrastructure is in use.
        /// </summary>
        public static LoggingInfrastructureType InfrastructureType
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets a value that turns logging as a whole on or off.
        /// </summary>
        public static bool IsLogging { get; set; }

        /// <summary>
        /// Gets a value that indicates whether PostSharp is in use as the
        /// logging infrastructure.
        /// </summary>
        private static bool IsPostSharp
            => InfrastructureType == LoggingInfrastructureType.PostSharp;

        /// <summary>
        /// Users should set this property to the path to the log file, if logging.
        /// </summary>
        public static string LogFilePath { get; set; }

        /// <summary>
        /// Gets or sets a value telling us to mute all console output.
        /// </summary>
        /// <remarks>
        /// When this property's value is updated, it raises the
        /// <see cref="E:xyLOGIX.Core.Debug.DebugUtils.MuteConsoleChanged" /> event.
        /// </remarks>
        public static bool MuteConsole
        {
            get => _muteConsole;
            set
            {
                var changed = _muteConsole != value;
                _muteConsole = value;
                if (changed) OnMuteConsoleChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to mute "DEBUG" log messages
        /// in Release mode.
        /// </summary>
        public static bool MuteDebugLevelIfReleaseMode { get; set; }

        /// <summary>
        /// Gets or sets a value that represents the spigot of text from that
        /// which is produced by calls to this class' methods.
        /// </summary>
        public static TextWriter Out { get; set; }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" /> interface.
        /// </summary>
        private static IOutputLocationProvider OutputLocationProvider { get; } =
            GetOutputLocationProvider.SoleInstance();

        /// <summary>
        /// Gets or sets the verbosity level.
        /// </summary>
        /// <remarks>
        /// Typically, applications set this to 1.
        /// </remarks>
        public static int Verbosity
        {
            get => _verbosity;
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
        /// Raised when the <see cref="M:xyLOGIX.Core.Debug.DebugUtils.LogException" />
        /// method has been called.
        /// </summary>
        public static event ExceptionLoggedEventHandler ExceptionLogged;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.MuteConsole" /> property is updated.
        /// </summary>
        public static event Action MuteConsoleChanged;

        /// <summary>
        /// Occurs whenever text has been emitted by the
        /// <see
        ///     cref="M:xyLOGIX.Core.Debug.DebugUtils.Write" />
        /// or
        /// <see
        ///     cref="M:xyLOGIX.Core.Debug.DebugUtils.WriteLine" />
        /// methods.
        /// </summary>
        public static event TextEmittedEventHandler TextEmitted;

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.Verbosity" />
        /// property is updated.
        /// </summary>
        public static event VerbosityChangedEventHandler VerbosityChanged;

        /// <summary>
        /// Dumps a collection to the debug log.
        /// </summary>
        /// <param name="collection">
        /// Reference to an instance of an object that implements the
        /// <see
        ///     cref="T:System.Collections.ICollection" />
        /// interface.
        /// </param>
        /// <remarks>
        /// If this method is passed a <see langword="null" /> for
        /// <paramref
        ///     name="collection" />
        /// , then it does nothing. Otherwise, the method
        /// iterates over the <paramref name="collection" /> and writes all of
        /// its elements to the log, one on each line.
        /// </remarks>
        public static void DumpCollection(ICollection collection)
        {
            if (collection == null || collection.Count == 0) return;

            foreach (var element in collection)
            {
                if (element == null) continue;

                WriteLine(DebugLevel.Debug, element.ToString());
            }
        }

        /// <summary>
        /// Writes the text of the selected control-- which is supposed to be a
        /// CommandLink -- to the log, while, at the same time, stripping out
        /// the text "recommended", if present, in the control's caption.
        /// </summary>
        /// <param name="commandLink">
        /// Reference to an instance of an object that implements a Command Link.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the <paramref name="commandLink" /> parameter is a passed a
        /// null reference.
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
        /// reference to an instance of which is passed in the
        /// <paramref
        ///     name="e" />
        /// parameter, to be the error message on a line by itself,
        /// followed by the stack trace lines on the subsequent lines.
        /// </summary>
        /// <param name="e">
        /// Reference to a <see cref="T:System.Exception" /> that should be
        /// formatted and dumped to the log.
        /// </param>
        /// <returns>
        /// String to be written to the log.
        /// </returns>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for <paramref name="e" />,
        /// then
        /// this method returns the empty string.
        /// </remarks>
        public static string FormatException(Exception e)
        {
            if (e == null) return string.Empty;

            return string.Format(
                Resources.ExceptionMessageFormat, e.Message, e.StackTrace
            );
        }

        /// <summary>
        /// Takes the reference to an instance of
        /// <see
        ///     cref="T:System.Exception" />
        /// that is passed in the
        /// <paramref
        ///     name="e" />
        /// parameter, formats it as a friendly error message along
        /// with its stack trace, and then dumps the result to the error log.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:System.Exception" /> whose information is to be dumped.
        /// </param>
        public static void FormatExceptionAndWrite(Exception e)
            => WriteLine(DebugLevel.Error, FormatException(e));

        /// <summary>
        ///     <summary>
        ///     Logs the complete information about an exception to the log, under
        ///     the Error Level. Outputs the source file and line number where the
        ///     exception occurred, as well as the message of the exception and its
        ///     stack trace.
        ///     </summary>
        ///     <param name="e">
        ///     Reference to the <see cref="Exception" /> to be logged.
        ///     </param>
        public static void LogException(Exception e)
        {
            if (e == null) return;

            if (e is TypeInitializationException)
                e = e.InnerException;

            var message = string.Format(
                Resources.ExceptionMessageFormat, e.GetType(), e.Message,
                e.StackTrace
            );

            WriteLine(DebugLevel.Error, message);

            OnExceptionLogged(new ExceptionLoggedEventArgs(e));
        }

        /// <summary>
        /// Writes the content in <paramref name="format" /> to the
        /// <paramref
        ///     name="debugLevel" />
        /// log.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values that
        /// indicates which log (DEBUG, ERROR, INFO, WARN) where the content
        /// should be written.
        /// </param>
        /// <param name="format">
        /// (Required.) String containing an optional format specifier for
        /// parameters passed in <paramref name="args" />.
        /// </param>
        /// <param name="args">
        /// (Optional.) Collection of objects whose values should be included in
        /// the <paramref name="format" /> and written to the log.
        /// </param>
        /// <remarks>
        /// If the <paramref name="format" /> parameter is a blank or empty
        /// string, then this method does nothing. If the <c>DEBUG</c> constant
        /// is not defined, then this method assumes that the application was
        /// built in Release mode. If this is so, then the method checks the
        /// value of the
        /// <see
        ///     cref="P:Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode" />
        /// property. If the property is set to true AND the
        /// <paramref
        ///     name="debugLevel" />
        /// parameter is set to
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.DebugLevel.Debug" />
        /// , then this method
        /// does nothing. This method does not add a newline character after
        /// writing its content to the log.
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

            if (MuteDebugLevelIfReleaseMode
                && debugLevel == DebugLevel.Debug)
                return;
#endif

            LogEachLineIfMultiline(
                GenerateContentFromFormat(format, args), WriteCore, debugLevel
            );
        }

        /// <summary>
        /// Writes non-formatted content to the log using the
        /// <paramref
        ///     name="debugLevel" />
        /// specified. No line terminator is appended to the output.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values that
        /// indicates which log (DEBUG, ERROR, INFO, WARN) where the content
        /// should be written.
        /// </param>
        /// <param name="content">
        /// (Required.) string containing the content to be written.
        /// </param>
        /// <remarks>
        /// If the <paramref name="content" /> is a blank or empty string, then
        /// this method does nothing. This method's behavior is identical to
        /// that of <see cref="M:xyLOGIX.Core.Debug.DebugUtils.WriteCore" />,
        /// except that a newline character is appended to the end of the content.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="debugLevel" /> parameter is not one of
        /// the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values.
        /// </exception>
        public static void Write(DebugLevel debugLevel, string content)
            => LogEachLineIfMultiline(content, WriteCore, debugLevel);

        /// <summary>
        /// Writes the content in <paramref name="format" /> to the
        /// <paramref
        ///     name="debugLevel" />
        /// log.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values that
        /// indicates which log (DEBUG, ERROR, INFO, WARN) where the content
        /// should be written.
        /// </param>
        /// <param name="format">
        /// (Required.) String containing an optional format specifier for
        /// parameters passed in <paramref name="args" />.
        /// </param>
        /// <param name="args">
        /// (Optional.) Collection of objects whose values should be included in
        /// the <paramref name="format" /> and written to the log.
        /// </param>
        /// <remarks>
        /// If the <paramref name="format" /> parameter is a blank or empty
        /// string, then this method does nothing. If the <c>DEBUG</c> constant
        /// is not defined, then this method assumes that the application was
        /// built in Release mode. If this is so, then the method checks the
        /// value of the
        /// <see
        ///     cref="P:Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode" />
        /// property. If the property is set to true AND the
        /// <paramref
        ///     name="debugLevel" />
        /// parameter is set to
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.DebugLevel.Debug" />
        /// , then this method
        /// does nothing. This method adds a newline character after writing its
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

            if (MuteDebugLevelIfReleaseMode
                && debugLevel == DebugLevel.Debug)
                return;
#endif

            LogEachLineIfMultiline(
                GenerateContentFromFormat(format, args), WriteLine, debugLevel
            );
        }

        /// <summary>
        /// Works the same as the overload which takes a
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.DebugLevel" />
        /// as its first argument, but
        /// if the formatted content consists of several lines of content, then
        /// the lines are split and logged separately, all under the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.DebugLevel.Debug" />
        /// debugLevel.
        /// </summary>
        /// <param name="format">
        /// (Required.) String containing an optional format specifier for
        /// parameters passed in <paramref name="args" />.
        /// </param>
        /// <param name="args">
        /// (Optional.) Collection of objects whose values should be included in
        /// the <paramref name="format" /> and written to the log.
        /// </param>
        /// <remarks>
        /// This overload specifies that the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.DebugLevel.Debug" />
        /// logging debugLevel is
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
        /// <paramref
        ///     name="debugLevel" />
        /// specified, terminated by a newline character.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values that
        /// indicates which log (DEBUG, ERROR, INFO, WARN) where the content
        /// should be written.
        /// </param>
        /// <param name="content">
        /// (Required.) string containing the content to be written.
        /// </param>
        /// <remarks>
        /// If the <paramref name="content" /> is a blank or empty string, then
        /// this method does nothing. This method's behavior is identical to
        /// that of <see cref="M:xyLOGIX.Core.Debug.DebugUtils.WriteCore" />,
        /// except that a newline character is appended to the end of the content.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="debugLevel" /> parameter is not one of
        /// the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values.
        /// </exception>
        [DebuggerStepThrough] public static void WriteLine(DebugLevel debugLevel, string content)
            => LogEachLineIfMultiline(content, WriteLineCore, debugLevel);

        /// <summary>
        /// Helper method to, basically, carry out the formatting of a string.
        /// </summary>
        /// <param name="format">
        /// (Required.) String value to be formatted.
        /// </param>
        /// <param name="args">
        /// (Optional.) Array of format values.
        /// </param>
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

        private static void InitializeOutputLocationProvider()
            => OutputLocationProvider.MuteConsoleChanged +=
                OnMuteConsoleChangedInOutputLocationProvider;

        /// <summary>
        /// Detects whether the <paramref name="content" /> is multiline. If so,
        /// then each line of content is logged separately, using the
        /// <paramref
        ///     name="logMethod" />
        /// supplied.
        /// </summary>
        /// <param name="content">
        /// (Required. String containing the already-formatted content to be logged.
        /// </param>
        /// <param name="logMethod">
        /// (Required.) Delegate specifying the logging code that is to be
        /// executed for each line of content.
        /// </param>
        /// <param name="level">
        /// A <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> specifying the
        /// debugLevel of logging to utilize.
        /// </param>
        [DebuggerStepThrough] private static void LogEachLineIfMultiline(
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
        /// Raises the <see cref="E:xyLOGIX.Core.Debug.DebugUtils.ExceptionLogged" />
        /// event.
        /// </summary>
        /// <param name="e">
        /// (Required.) A
        /// <see cref="T:xyLOGIX.Core.Debug.ExceptionLoggedEventArgs" /> that contains the
        /// event data.
        /// </param>
        private static void OnExceptionLogged(ExceptionLoggedEventArgs e)
            => ExceptionLogged?.Invoke(e);

        /// <summary>
        /// Raises the <see cref="E:xyLOGIX.Core.Debug.DebugUtils.MuteConsoleChanged" />
        /// event.
        /// </summary>
        private static void OnMuteConsoleChanged()
            => MuteConsoleChanged?.Invoke();

        /// <summary>
        /// Handles the
        /// <see cref="E:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsoleChanged" />
        /// event raised by the <b>Output Location Provider</b> component..
        /// </summary>
        /// <param name="sender">
        /// Reference to an instance of the object that raised the
        /// event.
        /// </param>
        /// <param name="e">
        /// A
        /// <see cref="T:xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs" /> that contains
        /// the event data.
        /// </param>
        /// <remarks>
        /// The event that this handler responds to is raised when the value of
        /// the <see cref="P:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole" />
        /// property is updated.
        /// <para />
        /// This handler responds by synchronizing the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.MuteConsole" /> property with its
        /// own.
        /// </remarks>
        private static void OnMuteConsoleChangedInOutputLocationProvider(
            object sender,
            MuteConsoleChangedEventArgs e
        )
        {
            if (MuteConsole == e.NewValue) return;

            MuteConsole = e.NewValue;
        }

        /// <summary>
        /// Raises the <see cref="TextEmitted" /> event.
        /// </summary>
        /// <param name="e">
        /// (Required.) A <see cref="T:xyLOGIX.Core.Debug.TextEmittedEventArgs" /> that
        /// contains the event data.
        /// </param>
        private static void OnTextEmitted(TextEmittedEventArgs e)
            => TextEmitted?.Invoke(e);

        /// <summary>
        /// Raises the <see cref="E:xyLOGIX.Core.Debug.DebugUtils.VerbosityChanged" />
        /// event.
        /// </summary>
        /// <remarks>
        /// The <see cref="E:xyLOGIX.Core.Debug.DebugUtils.VerbosityChanged" /> event is
        /// raised
        /// whenever the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.DebugUtils.Verbosity" />
        /// property is updated.
        /// </remarks>
        private static void OnVerbosityChanged(VerbosityChangedEventArgs e)
            => VerbosityChanged?.Invoke(e);

        /// <summary>
        /// Provides the implementation details of writing messages to the log.
        /// No line terminator is added to the content written.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values that
        /// determine what logging debugLevel to utilize.
        /// </param>
        /// <param name="content">
        /// (Required.) String containing the content to be written to the log file.
        /// </param>
        /// <remarks>
        /// If the string passed in <paramref name="content" /> is blank or
        /// empty, then this method does nothing.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="debugLevel" /> parameter is not one of
        /// the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values.
        /// </exception>
        private static void WriteCore(DebugLevel debugLevel, string content)
        {
            // Do nothing if blank content provided.
            if (string.IsNullOrWhiteSpace(content)) return;

            try
            {
                if (Verbosity == 0) return;

                if (!MuteConsole) OutputMultiplexer.Write(content);

                if (ConsoleOnly) return;

                if (!IsLogging) return;

                // If we are being called from LINQPad, then use Debug.WriteLine
                if ("LINQPad".Equals(AppDomain.CurrentDomain.FriendlyName))
                {
                    OutputLocationProvider.MuteConsole = true;
                    OutputMultiplexer.Write(content);
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
        /// Provides the implementation details of writing messages to the log,
        /// one line at a time.
        /// </summary>
        /// <param name="debugLevel">
        /// One of the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values that
        /// determine what logging debugLevel to utilize.
        /// </param>
        /// <param name="content">
        /// (Required.) String containing the content to be written to the log file.
        /// </param>
        /// <remarks>
        /// If the string passed in <paramref name="content" /> is blank or
        /// empty, then this method does nothing.
        /// </remarks>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="debugLevel" /> parameter is not one of
        /// the <see cref="T:xyLOGIX.Core.Debug.DebugLevel" /> values.
        /// </exception>
        private static void WriteLineCore(DebugLevel debugLevel, string content)
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

                // If we are being called from LINQPad, then use Debug.WriteLine
                if (AppDomain.CurrentDomain.FriendlyName.Contains("LINQPad"))
                {
                    OutputMultiplexer.WriteLine(content);
                    return;
                }

                if (!MuteConsole)
                    OutputMultiplexer.WriteLine(content);

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
            catch (Exception)
            {
                //ignore
            }
        }
    }
}