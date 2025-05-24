using log4net.Appender;
using log4net.Layout;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Implements an <c>Appender Factory</c> that creates new <c>Appender</c>(s) from
    /// scratch.
    /// </summary>
    public class CreateNewAppenderRetriever : AppenderRetrieverBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static CreateNewAppenderRetriever() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected CreateNewAppenderRetriever() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IAppenderRetriever" /> interface.
        /// </summary>
        public static IAppenderRetriever
            Instance { [DebuggerStepThrough] get; } =
            new CreateNewAppenderRetriever();

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" /> enumeration
        /// value that identifies how this <c>Appender Factory</c> operates.
        /// </summary>
        public override AppenderRetrievalMode Mode
        {
            [DebuggerStepThrough] get;
        } = AppenderRetrievalMode.CreateNew;

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
            IRollingFileAppenderConfiguration config
        )
        {
            IAppender result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "CreateNewAppenderRetriever.GetFileAppenderByPath: Checking whether the 'config' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, config, is null. If it is, send an
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (config == null)
                {
                    // The parameter, 'config', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "CreateNewAppenderRetriever.GetFileAppenderByPath: *** ERROR *** A null reference was passed for the 'config' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** CreateNewAppenderRetriever.GetFileAppenderByPath: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewAppenderRetriever.GetFileAppenderByPath: *** SUCCESS *** We have been passed a valid object reference for the 'config' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewAppenderRetriever.GetAppender: Checking whether the Rolling File Appender Configuration has valid settings..."
                );

                // Check to see whether the Rolling File Appender Configuration has valid settings.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!RollingFileAppenderConfigurationValidator.IsValid(config))
                {
                    // The Rolling File Appender Configuration does NOT have valid settings.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "CreateNewAppenderRetriever.GetAppender: *** ERROR *** The Rolling File Appender Configuration does NOT have valid settings.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** CreateNewAppenderRetriever.GetAppender: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewAppenderRetriever.GetAppender: *** SUCCESS *** The Rolling File Appender Configuration has valid settings.  Getting a new 'RollingFileAppender'..."
                );

                var rollerToUse =
                    MakeNewRollingFileAppender.ForRollingStyle(
                        config.RollingStyle
                    );

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewAppenderRetriever.GetAppender: Checking whether the variable, 'rollerToUse', has a null reference for a value..."
                );

                // Check to see if the variable, 'rollerToUse', has a null reference for a value.
                // If it does, then emit an error to the Debug output, and terminate the execution
                // of this method, returning the default return value.
                if (rollerToUse == null)
                {
                    // The variable, 'rollerToUse', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "CreateNewAppenderRetriever.GetAppender: *** ERROR ***  The variable, 'rollerToUse', has a null reference for a value.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** CreateNewAppenderRetriever.GetAppender: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                // We can use the variable, 'rollerToUse', because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "CreateNewAppenderRetriever.GetAppender: *** SUCCESS *** The variable, 'rollerToUse', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Configuring the 'RollingFileAppender' with the following settings: {Environment.NewLine}\tFile = {config.File}{Environment.NewLine}\tLayout = {config.Layout}{Environment.NewLine}\tMaxSizeRollBackups = {config.MaxSizeRollBackups}{Environment.NewLine}\tMaximumFileSize = {config.MaximumFileSize}{Environment.NewLine}\tAppendToFile = {config.AppendToFile}{Environment.NewLine}\tStaticLogFileName = {config.StaticLogFileName}"
                );

                result = rollerToUse.SetLogFileNameTo(config.File)
                                    .WithPatternLayout(
                                        config.Layout as PatternLayout
                                    )
                                    .AndMaximumNumberOfRollingBackups(
                                        config.MaxSizeRollBackups
                                    )
                                    .WithMaximumFileSizeOf(
                                        config.MaximumFileSize
                                    )
                                    .ThatShouldAppendToFile(config.AppendToFile)
                                    .AndThatHasAStaticLogFileName(
                                        config.StaticLogFileName
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