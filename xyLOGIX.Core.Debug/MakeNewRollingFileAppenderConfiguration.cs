using log4net.Appender;
using log4net.Layout;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to create new instances of
    /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> and
    /// initialize them.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class MakeNewFoo
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.MakeNewFoo" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MakeNewFoo() { }

        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingModeValidator" /> interface.
        /// </summary>
        private static IRollingModeValidator RollingModeValidator
        {
            [DebuggerStepThrough] get;
        } = GetRollingModeValidator.SoleInstance();

        /// <summary>
        /// Builder extension method that initializes the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.MaxSizeRollBackups" />
        /// property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface.
        /// </param>
        /// <param name="maxSizeRollingBackups">
        /// (Required.) An
        /// <see cref="T:System.Int32" /> that specifies the maximum number of backup files
        /// that are kept before the oldest backup file is erased.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this method,
        /// for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="self" />, is passed a <see langword="null" /> value.
        /// </exception>
        /// <remarks>
        ///     <para>
        ///     If set to zero, then there will be no backup files and the log file
        ///     will be truncated when it reaches
        ///     <see
        ///         cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.MaxFileSize" />
        ///     .
        ///     </para>
        ///     <para>
        ///     If a negative number is supplied then no deletions will be made.
        ///     Note that this could result in very slow performance as a large number of
        ///     files are rolled over unless
        ///     <see
        ///         cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.CountDirection" />
        ///     is
        ///     used.
        ///     </para>
        ///     <para>
        ///     The maximum applies to <b>each</b> time based group of files and
        ///     <b>not</b> the total.
        ///     </para>
        /// </remarks>
        [DebuggerStepThrough]
        internal static IRollingFileAppenderConfiguration
            AndMaximumNumberOfRollingBackups(
                [NotLogged] this IRollingFileAppenderConfiguration self,
                int maxSizeRollingBackups
            )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));

            self.MaxSizeRollBackups = maxSizeRollingBackups;
            return self;
        }

        /// <summary>
        /// Builder extension method that initializes the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.StaticLogFileName" />
        /// property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface.
        /// </param>
        /// <param name="staticLogFileName">
        /// (Required.) A <see cref="T:System.Boolean" />
        /// value indicating whether to always log to the same file.
        /// <para />
        /// Set to <see langword="true" /> if always should be logged to the same file,
        /// otherwise <see langword="false" />.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this method,
        /// for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="self" />, is passed a <see langword="null" /> value.
        /// </exception>
        /// <remarks>
        ///     <para>
        ///     By default, file.log is always the current file.  Optionally
        ///     file.log.yyyy-mm-dd for current formatted datePattern can be the currently
        ///     logging file (or file.log.curSizeRollBackup or even
        ///     file.log.yyyy-mm-dd.curSizeRollBackup).
        ///     </para>
        ///     <para>
        ///     This will make time based rollovers with a large number of backups
        ///     much faster as the appender it won't have to rename all the backups!
        ///     </para>
        /// </remarks>
        [DebuggerStepThrough]
        internal static IRollingFileAppenderConfiguration
            AndThatHasAStaticLogFileName(
                [NotLogged] this IRollingFileAppenderConfiguration self,
                bool staticLogFileName
            )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));

            self.StaticLogFileName = staticLogFileName;
            return self;
        }

        /// <summary>
        /// Creates a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> and
        /// initializes it with
        /// the specified rolling <paramref name="rollingStyle" />.
        /// </summary>
        /// <param name="rollingStyle">
        /// (Required.) One or a combination of the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.RollingMode" />
        /// enumeration
        /// values that specifies how the log file should be rolled when it gets too big
        /// for size limits.
        /// </param>
        /// <returns>
        /// If successful, a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> and
        /// initializes it with
        /// the specified rolling <paramref name="rollingStyle" />.  Otherwise,
        /// <see langword="null" /> is returned.
        /// </returns>
        [DebuggerStepThrough]
        [return: NotLogged]
        internal static IRollingFileAppenderConfiguration ForRollingStyle(
            RollingFileAppender.RollingMode rollingStyle
        )
        {
            IRollingFileAppenderConfiguration result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewIRollingFileAppenderConfiguration.ForRollingStyle: Checking whether the specified rolling style, '{rollingStyle}', is valid..."
                );

                // Check to see whether the specified rolling style, is valid.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!RollingModeValidator.IsValid(rollingStyle))
                {
                    // The specified rolling style is NOT valid.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The specified rolling style, '{rollingStyle}', is NOT valid.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** MakeNewIRollingFileAppenderConfiguration.ForRollingStyle: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"MakeNewIRollingFileAppenderConfiguration.ForRollingStyle: *** SUCCESS *** The specified rolling style, '{rollingStyle}', is valid.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Making a new Rolling File Appender having the '{rollingStyle}' rolling style..."
                );

                result =
                    new RollingFileAppenderConfiguration
                    {
                        RollingStyle = rollingStyle
                    };
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? $"*** SUCCESS *** Obtained a reference to a new Rolling File Appender having rolling style, '{rollingStyle}'.  Proceeding..."
                    : $"*** ERROR *** FAILED to obtain a reference to a new Rolling File Appender having rolling style, '{rollingStyle}'.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Builder extension method that initializes the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.File" />
        /// property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface.
        /// </param>
        /// <param name="file">
        /// (Required.) A <see cref="T:System.String" /> containing the
        /// fully-qualified pathname of where logging entries will be written.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this method,
        /// for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="self" />, is passed a <see langword="null" /> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if the required parameter,
        /// <paramref name="file" />, is passed a blank or <see langword="null" /> string
        /// for a value.
        /// </exception>
        [DebuggerStepThrough]
        internal static IRollingFileAppenderConfiguration SetLogFileNameTo(
            [NotLogged] this IRollingFileAppenderConfiguration self,
            string file
        )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentException(
                    "Value cannot be null or whitespace.", nameof(file)
                );

            self.File = file;
            return self;
        }

        /// <summary>
        /// Builder extension method that initializes the
        /// <see cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.AppendToFile" />
        /// property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface.
        /// </param>
        /// <param name="appendToFile">
        /// (Required.) A <see cref="T:System.Boolean" /> value
        /// that is set to <see langword="true" /> if the logger should append to the log
        /// file, <see langword="false" /> if the file should be overwritten.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this method,
        /// for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="self" />, is passed a <see langword="null" /> value.
        /// </exception>
        [DebuggerStepThrough]
        internal static IRollingFileAppenderConfiguration
            ThatShouldAppendToFile(
                [NotLogged] this IRollingFileAppenderConfiguration self,
                bool appendToFile
            )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));

            self.AppendToFile = appendToFile;
            return self;
        }

        /// <summary>
        /// Builder extension method that initializes the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.MaximumFileSize" />
        /// property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface.
        /// </param>
        /// <param name="maximumFileSize">
        /// (Required.) A <see cref="T:System.String" />
        /// that describes the maximum size that the output file is allowed to reach before
        /// being rolled over to back up files.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this method,
        /// for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required
        /// parameter, <paramref name="self" />, is passed a <see langword="null" /> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if the required parameter,
        /// <paramref name="maximumFileSize" />, is passed a blank or
        /// <see langword="null" /> string for a value.
        /// </exception>
        /// <remarks>
        ///     <para>
        ///     This property allows you to specify the maximum size with the
        ///     suffixes "KB", "MB" or "GB" so that the size is interpreted being expressed
        ///     respectively in kilobytes, megabytes or gigabytes.
        ///     </para>
        ///     <para> OfType example, the value "10KB" will be interpreted as 10240 bytes. </para>
        ///     <para> The default maximum file size is 10MB. </para>
        ///     <para>
        ///     If you have the option to set the maximum file size programmatically
        ///     consider using the
        ///     <see
        ///         cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.MaxFileSize" />
        ///     property
        ///     instead as this allows you to set the size in bytes as a
        ///     <see cref="T:System.Int64" />.
        ///     </para>
        /// </remarks>
        [DebuggerStepThrough]
        internal static IRollingFileAppenderConfiguration WithMaximumFileSizeOf(
            [NotLogged] this IRollingFileAppenderConfiguration self,
            string maximumFileSize
        )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));
            if (string.IsNullOrWhiteSpace(maximumFileSize))
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(maximumFileSize)
                );

            self.MaximumFileSize = maximumFileSize;
            return self;
        }

        /// <summary>
        /// Builder extension method that initializes the
        /// <see cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.Layout" />
        /// property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface.
        /// </param>
        /// <param name="layout">
        /// (Required.) Reference to an instance of
        /// <see cref="T:log4net.Layout.PatternLayout" /> that specifies the pattern to
        /// utilize for each line of the log file.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this method,
        /// for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if either of the
        /// required parameters, <paramref name="self" /> or <paramref name="layout" />,
        /// are passed a <see langword="null" /> value.
        /// </exception>
        [DebuggerStepThrough]
        internal static IRollingFileAppenderConfiguration WithPatternLayout(
            [NotLogged] this IRollingFileAppenderConfiguration self,
            PatternLayout layout
        )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));
            self.Layout =
                layout ?? throw new ArgumentNullException(nameof(layout));
            return self;
        }
    }
}