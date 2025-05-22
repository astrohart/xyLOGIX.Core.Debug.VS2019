using log4net.Appender;
using log4net.Layout;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the publicly-exposed events, methods and properties of an object that
    /// encapsulates the configuration for a
    /// <see cref="T:log4net.Appender.RollingFileAppender" />.
    /// </summary>
    public interface IRollingFileAppenderConfiguration
    {
        /// <summary>
        /// Gets or sets a flag that indicates whether the file should be appended
        /// to or overwritten.
        /// </summary>
        /// <value>Indicates whether the file should be appended to or overwritten.</value>
        /// <remarks>
        /// <para>
        /// If the value is set to <see langword="false" /> then the file will be
        /// overwritten, if  it is set to <see langword="true" /> then the file will be
        /// appended to.
        /// </para>
        /// The default value is <see langword="true" />.
        /// </remarks>
        bool AppendToFile
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets the path to the file that logging will be written to.
        /// </summary>
        /// <value>
        /// The path to the file that logging will be written to.
        /// </value>
        /// <remarks>
        ///     <para>
        ///     If the path is relative it is taken as relative from
        ///     the application base directory.
        ///     </para>
        /// </remarks>
        string File { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets the <see cref="T:log4net.Layout.ILayout" /> for this appender.
        /// </summary>
        /// <value>The layout of the appender.</value>
        /// <remarks>
        ///     <para>
        ///     See <see cref="P:log4net.Appender.AppenderSkeleton.RequiresLayout" /> for
        ///     more information.
        ///     </para>
        /// </remarks>
        /// <seealso cref="RequiresLayout" />
        ILayout Layout { [DebuggerStepThrough] get; [DebuggerStepThrough] set; }

        /// <summary>
        /// Gets or sets the maximum size that the output file is allowed to reach
        /// before being rolled over to back-up files.
        /// </summary>
        /// <value>
        /// The maximum size that the output file is allowed to reach before being
        /// rolled over to back-up files.
        /// </value>
        /// <remarks>
        ///     <para>
        ///     This property allows you to specify the maximum size with the
        ///     suffixes "KB", "MB" or "GB" so that the size is interpreted being
        ///     expressed respectively in kilobytes, megabytes or gigabytes.
        ///     </para>
        ///     <para>
        ///     For example, the value "10KB" will be interpreted as 10240 bytes.
        ///     </para>
        ///     <para>
        ///     The default maximum file size is 10MB.
        ///     </para>
        /// </remarks>
        string MaximumFileSize
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets the maximum number of backup files that are kept before
        /// the oldest is erased.
        /// </summary>
        /// <value>
        /// The maximum number of backup files that are kept before the oldest is
        /// erased.
        /// </value>
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
        int MaxSizeRollBackups
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>Gets or sets the rolling style.</summary>
        /// <value>The rolling style.</value>
        /// <remarks>
        ///     <para>
        ///     The default rolling style is
        ///     <see cref="F:log4net.Appender.RollingFileAppender.RollingMode.Composite" />
        ///     .
        ///     </para>
        ///     <para>
        ///     When set to
        ///     <see cref="F:log4net.Appender.RollingFileAppender.RollingMode.Once" /> this
        ///     appender's <see cref="P:log4net.Appender.FileAppender.AppendToFile" />
        ///     property is set to <see langword="false" />, otherwise the appender would
        ///     append to a single file rather than rolling the file each time it is
        ///     opened.
        ///     </para>
        /// </remarks>
        RollingFileAppender.RollingMode RollingStyle
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to always log to
        /// the same file.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if always should be logged to the same file, otherwise
        /// <see langword="false" />.
        /// </value>
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
        bool StaticLogFileName
        {
            [DebuggerStepThrough] get;
            [DebuggerStepThrough] set;
        }
    }
}