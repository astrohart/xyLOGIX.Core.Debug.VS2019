using log4net.Appender;
using log4net.Layout;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes <see langword="static" /> methods to create new instances of
    /// <see cref="T:log4net.Appender.RollingFileAppender" /> and initialize them.
    /// </summary>
    [Log(AttributeExclude = true)]
    public static class MakeNewRollingFileAppender
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.MakeNewRollingFileAppender" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MakeNewRollingFileAppender() { }

        /// <summary>
        /// Builder extension method that initializes the
        /// <see cref="P:log4net.Appender.RollingFileAppender.File" /> property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Appender.RollingFileAppender" /> interface.
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
        public static RollingFileAppender AndHavingLogFileName(
            [NotLogged] this RollingFileAppender self,
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
        /// <see cref="P:log4net.Appender.RollingFileAppender.MaxSizeRollBackups" />
        /// property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Appender.RollingFileAppender" /> interface.
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
        ///     <see cref="P:log4net.Appender.RollingFileAppender.MaxFileSize" />.
        ///     </para>
        ///     <para>
        ///     If a negative number is supplied then no deletions will be made.
        ///     Note that this could result in very slow performance as a large number of
        ///     files are rolled over unless
        ///     <see cref="P:log4net.Appender.RollingFileAppender.CountDirection" /> is
        ///     used.
        ///     </para>
        ///     <para>
        ///     The maximum applies to <b>each</b> time based group of files and
        ///     <b>not</b> the total.
        ///     </para>
        /// </remarks>
        [DebuggerStepThrough]
        public static RollingFileAppender AndMaximumNumberOfRollingBackups(
            [NotLogged] this RollingFileAppender self,
            int maxSizeRollingBackups
        )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));

            self.MaxSizeRollBackups = maxSizeRollingBackups;
            return self;
        }

        /// <summary>
        /// Builder extension method that initializes the
        /// <see cref="P:log4net.Appender.RollingFileAppender.StaticLogFileName" />
        /// property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Appender.RollingFileAppender" /> interface.
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
        ///     file.log.yyyy-mm-dd for current formatted datePattern can by the currently
        ///     logging file (or file.log.curSizeRollBackup or even
        ///     file.log.yyyy-mm-dd.curSizeRollBackup).
        ///     </para>
        ///     <para>
        ///     This will make time based rollovers with a large number of backups
        ///     much faster as the appender it won't have to rename all the backups!
        ///     </para>
        /// </remarks>
        [DebuggerStepThrough]
        public static RollingFileAppender AndThatHasAStaticLogFileName(
            [NotLogged] this RollingFileAppender self,
            bool staticLogFileName
        )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));

            self.StaticLogFileName = staticLogFileName;
            return self;
        }

        /// <summary>
        /// Creates a new instance of
        /// <see cref="T:log4net.Appender.RollingFileAppender" /> and initializes it with
        /// the specified rolling <paramref name="style" />.
        /// </summary>
        /// <param name="style">
        /// (Required.) One or a combination of the
        /// <see cref="T:log4net.Appender.RollingFileAppender.RollingMode" /> enumeration
        /// values that specifies how the log file should be rolled when it gets too big
        /// for size limits.
        /// </param>
        /// <returns>
        /// If successful, a new instance of
        /// <see cref="T:log4net.Appender.RollingFileAppender" /> and initializes it with
        /// the specified rolling <paramref name="style" />.  Otherwise,
        /// <see langword="null" /> is returned.
        /// </returns>
        [DebuggerStepThrough]
        public static RollingFileAppender ForRollingStyle(
            RollingFileAppender.RollingMode style
        )
            => new RollingFileAppender { RollingStyle = style };

        /// <summary>
        /// Builder extension method that initializes the
        /// <see cref="P:log4net.Appender.RollingFileAppender.AppendToFile" /> property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Appender.RollingFileAppender" /> interface.
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
        public static RollingFileAppender ThatShouldAppendToFile(
            [NotLogged] this RollingFileAppender self,
            bool appendToFile
        )
        {
            if (self == null) throw new ArgumentNullException(nameof(self));

            self.AppendToFile = appendToFile;
            return self;
        }

        /// <summary>
        /// Builder extension method that initializes the
        /// <see cref="P:log4net.Appender.RollingFileAppender.MaximumFileSize" /> property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Appender.RollingFileAppender" /> interface.
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
        ///     <see cref="P:log4net.Appender.RollingFileAppender.MaxFileSize" /> property
        ///     instead as this allows you to set the size in bytes as a
        ///     <see cref="T:System.Int64" />.
        ///     </para>
        /// </remarks>
        [DebuggerStepThrough]
        public static RollingFileAppender WithMaximumFileSizeOf(
            [NotLogged] this RollingFileAppender self,
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
        /// <see cref="P:log4net.Appender.RollingFileAppender.Layout" /> property.
        /// </summary>
        /// <param name="self">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:log4net.Appender.RollingFileAppender" /> interface.
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
        public static RollingFileAppender WithPatternLayout(
            [NotLogged] this RollingFileAppender self,
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