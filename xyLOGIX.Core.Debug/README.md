<a name='assembly'></a>
# xyLOGIX.Core.Debug

## Contents

- [DebugFileAndFolderHelper](#T-xyLOGIX-Core-Debug-DebugFileAndFolderHelper 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper')
  - [ClearTempFileDir()](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-ClearTempFileDir 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.ClearTempFileDir')
  - [CreateDirectoryIfNotExists(directoryPath)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-CreateDirectoryIfNotExists-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.CreateDirectoryIfNotExists(System.String)')
  - [GetFilesInFolder(folder)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-GetFilesInFolder-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.GetFilesInFolder(System.String)')
  - [InsistPathExists()](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-InsistPathExists-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.InsistPathExists(System.String)')
  - [IsFileWriteable(path)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFileWriteable-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsFileWriteable(System.String)')
  - [IsFolderWriteable(path)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFolderWriteable-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsFolderWriteable(System.String)')
  - [IsValidPath(fullyQualifiedPath)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsValidPath-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsValidPath(System.String)')
- [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel')
  - [Debug](#F-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug')
  - [Error](#F-xyLOGIX-Core-Debug-DebugLevel-Error 'xyLOGIX.Core.Debug.DebugLevel.Error')
  - [Info](#F-xyLOGIX-Core-Debug-DebugLevel-Info 'xyLOGIX.Core.Debug.DebugLevel.Info')
  - [Warning](#F-xyLOGIX-Core-Debug-DebugLevel-Warning 'xyLOGIX.Core.Debug.DebugLevel.Warning')
- [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils')
  - [ApplicationName](#P-xyLOGIX-Core-Debug-DebugUtils-ApplicationName 'xyLOGIX.Core.Debug.DebugUtils.ApplicationName')
  - [ConsoleOnly](#P-xyLOGIX-Core-Debug-DebugUtils-ConsoleOnly 'xyLOGIX.Core.Debug.DebugUtils.ConsoleOnly')
  - [ExceptionStackDepth](#P-xyLOGIX-Core-Debug-DebugUtils-ExceptionStackDepth 'xyLOGIX.Core.Debug.DebugUtils.ExceptionStackDepth')
  - [InfrastructureType](#P-xyLOGIX-Core-Debug-DebugUtils-InfrastructureType 'xyLOGIX.Core.Debug.DebugUtils.InfrastructureType')
  - [IsLogging](#P-xyLOGIX-Core-Debug-DebugUtils-IsLogging 'xyLOGIX.Core.Debug.DebugUtils.IsLogging')
  - [IsPostSharp](#P-xyLOGIX-Core-Debug-DebugUtils-IsPostSharp 'xyLOGIX.Core.Debug.DebugUtils.IsPostSharp')
  - [LogFilePath](#P-xyLOGIX-Core-Debug-DebugUtils-LogFilePath 'xyLOGIX.Core.Debug.DebugUtils.LogFilePath')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-DebugUtils-MuteConsole 'xyLOGIX.Core.Debug.DebugUtils.MuteConsole')
  - [MuteDebugLevelIfReleaseMode](#P-xyLOGIX-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'xyLOGIX.Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode')
  - [Out](#P-xyLOGIX-Core-Debug-DebugUtils-Out 'xyLOGIX.Core.Debug.DebugUtils.Out')
  - [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DebugUtils-#cctor 'xyLOGIX.Core.Debug.DebugUtils.#cctor')
  - [DumpCollection(collection)](#M-xyLOGIX-Core-Debug-DebugUtils-DumpCollection-System-Collections-ICollection- 'xyLOGIX.Core.Debug.DebugUtils.DumpCollection(System.Collections.ICollection)')
  - [EchoCommandLinkText(commandLink)](#M-xyLOGIX-Core-Debug-DebugUtils-EchoCommandLinkText-System-Object- 'xyLOGIX.Core.Debug.DebugUtils.EchoCommandLinkText(System.Object)')
  - [FormatException(e)](#M-xyLOGIX-Core-Debug-DebugUtils-FormatException-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.FormatException(System.Exception)')
  - [FormatExceptionAndWrite(e)](#M-xyLOGIX-Core-Debug-DebugUtils-FormatExceptionAndWrite-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.FormatExceptionAndWrite(System.Exception)')
  - [GenerateContentFromFormat(format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-GenerateContentFromFormat-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.GenerateContentFromFormat(System.String,System.Object[])')
  - [LogEachLineIfMultiline(content,logMethod,level)](#M-xyLOGIX-Core-Debug-DebugUtils-LogEachLineIfMultiline-System-String,System-Action{xyLOGIX-Core-Debug-DebugLevel,System-String},xyLOGIX-Core-Debug-DebugLevel- 'xyLOGIX.Core.Debug.DebugUtils.LogEachLineIfMultiline(System.String,System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String},xyLOGIX.Core.Debug.DebugLevel)')
  - [LogException(e)](#M-xyLOGIX-Core-Debug-DebugUtils-LogException-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.LogException(System.Exception)')
  - [OnTextEmitted(text,debugLevel)](#M-xyLOGIX-Core-Debug-DebugUtils-OnTextEmitted-System-String,xyLOGIX-Core-Debug-DebugLevel- 'xyLOGIX.Core.Debug.DebugUtils.OnTextEmitted(System.String,xyLOGIX.Core.Debug.DebugLevel)')
  - [Write(debugLevel,format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.Write(xyLOGIX.Core.Debug.DebugLevel,System.String,System.Object[])')
  - [Write(debugLevel,content)](#M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String- 'xyLOGIX.Core.Debug.DebugUtils.Write(xyLOGIX.Core.Debug.DebugLevel,System.String)')
  - [WriteCore(debugLevel,content)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteCore-xyLOGIX-Core-Debug-DebugLevel,System-String- 'xyLOGIX.Core.Debug.DebugUtils.WriteCore(xyLOGIX.Core.Debug.DebugLevel,System.String)')
  - [WriteLine(debugLevel,format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.WriteLine(xyLOGIX.Core.Debug.DebugLevel,System.String,System.Object[])')
  - [WriteLine(format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.WriteLine(System.String,System.Object[])')
  - [WriteLine(debugLevel,content)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String- 'xyLOGIX.Core.Debug.DebugUtils.WriteLine(xyLOGIX.Core.Debug.DebugLevel,System.String)')
  - [WriteLineCore(debugLevel,content)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteLineCore-xyLOGIX-Core-Debug-DebugLevel,System-String- 'xyLOGIX.Core.Debug.DebugUtils.WriteLineCore(xyLOGIX.Core.Debug.DebugLevel,System.String)')
- [DebuggerDump](#T-xyLOGIX-Core-Debug-DebuggerDump 'xyLOGIX.Core.Debug.DebuggerDump')
  - [Dump(element)](#M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object- 'xyLOGIX.Core.Debug.DebuggerDump.Dump(System.Object)')
  - [Dump(element,depth)](#M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32- 'xyLOGIX.Core.Debug.DebuggerDump.Dump(System.Object,System.Int32)')
  - [Dump(element,depth,log)](#M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32,System-IO-TextWriter- 'xyLOGIX.Core.Debug.DebuggerDump.Dump(System.Object,System.Int32,System.IO.TextWriter)')
  - [DumpLines(element)](#M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object- 'xyLOGIX.Core.Debug.DebuggerDump.DumpLines(System.Object)')
  - [DumpLines(element,depth)](#M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32- 'xyLOGIX.Core.Debug.DebuggerDump.DumpLines(System.Object,System.Int32)')
  - [DumpLines(element,depth,log)](#M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32,System-IO-TextWriter- 'xyLOGIX.Core.Debug.DebuggerDump.DumpLines(System.Object,System.Int32,System.IO.TextWriter)')
- [DefaultLoggingInfrastructure](#T-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure')
  - [LogFilePath](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFilePath 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFilePath')
  - [Type](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Type 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.Type')
  - [DeleteLogIfExists()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-DeleteLogIfExists 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.DeleteLogIfExists')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFilePathname,muteConsole,repository)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,log4net.Repository.ILoggerRepository)')
  - [PrepareLogFile(overwrite,repository)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-PrepareLogFile-System-Boolean,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.PrepareLogFile(System.Boolean,log4net.Repository.ILoggerRepository)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean)')
  - [WriteTimestamp()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-WriteTimestamp 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.WriteTimestamp')
- [EventLogManager](#T-xyLOGIX-Core-Debug-EventLogManager 'xyLOGIX.Core.Debug.EventLogManager')
  - [#ctor()](#M-xyLOGIX-Core-Debug-EventLogManager-#ctor 'xyLOGIX.Core.Debug.EventLogManager.#ctor')
  - [_theEventLogManager](#F-xyLOGIX-Core-Debug-EventLogManager-_theEventLogManager 'xyLOGIX.Core.Debug.EventLogManager._theEventLogManager')
  - [Instance](#P-xyLOGIX-Core-Debug-EventLogManager-Instance 'xyLOGIX.Core.Debug.EventLogManager.Instance')
  - [IsInitialized](#P-xyLOGIX-Core-Debug-EventLogManager-IsInitialized 'xyLOGIX.Core.Debug.EventLogManager.IsInitialized')
  - [Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source')
  - [Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type')
  - [Error(content)](#M-xyLOGIX-Core-Debug-EventLogManager-Error-System-String- 'xyLOGIX.Core.Debug.EventLogManager.Error(System.String)')
  - [Info(content)](#M-xyLOGIX-Core-Debug-EventLogManager-Info-System-String- 'xyLOGIX.Core.Debug.EventLogManager.Info(System.String)')
  - [Initialize(eventSourceName,logType)](#M-xyLOGIX-Core-Debug-EventLogManager-Initialize-System-String,xyLOGIX-Core-Debug-EventLogType- 'xyLOGIX.Core.Debug.EventLogManager.Initialize(System.String,xyLOGIX.Core.Debug.EventLogType)')
  - [Warn(content)](#M-xyLOGIX-Core-Debug-EventLogManager-Warn-System-String- 'xyLOGIX.Core.Debug.EventLogManager.Warn(System.String)')
- [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType')
  - [Application](#F-xyLOGIX-Core-Debug-EventLogType-Application 'xyLOGIX.Core.Debug.EventLogType.Application')
  - [None](#F-xyLOGIX-Core-Debug-EventLogType-None 'xyLOGIX.Core.Debug.EventLogType.None')
  - [Security](#F-xyLOGIX-Core-Debug-EventLogType-Security 'xyLOGIX.Core.Debug.EventLogType.Security')
  - [System](#F-xyLOGIX-Core-Debug-EventLogType-System 'xyLOGIX.Core.Debug.EventLogType.System')
  - [Unknown](#F-xyLOGIX-Core-Debug-EventLogType-Unknown 'xyLOGIX.Core.Debug.EventLogType.Unknown')
- [FileAppenderConfigurator](#T-xyLOGIX-Core-Debug-FileAppenderConfigurator 'xyLOGIX.Core.Debug.FileAppenderConfigurator')
  - [SetMinimalLock(appender)](#M-xyLOGIX-Core-Debug-FileAppenderConfigurator-SetMinimalLock-log4net-Appender-FileAppender- 'xyLOGIX.Core.Debug.FileAppenderConfigurator.SetMinimalLock(log4net.Appender.FileAppender)')
- [FileAppenderManager](#T-xyLOGIX-Core-Debug-FileAppenderManager 'xyLOGIX.Core.Debug.FileAppenderManager')
  - [GetAppenderByName(name)](#M-xyLOGIX-Core-Debug-FileAppenderManager-GetAppenderByName-System-String- 'xyLOGIX.Core.Debug.FileAppenderManager.GetAppenderByName(System.String)')
  - [GetFirstAppender(loggerRepository)](#M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstAppender-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.FileAppenderManager.GetFirstAppender(log4net.Repository.ILoggerRepository)')
- [GetLoggingInfrastructure](#T-xyLOGIX-Core-Debug-GetLoggingInfrastructure 'xyLOGIX.Core.Debug.GetLoggingInfrastructure')
  - [For(type)](#M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-For-xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.GetLoggingInfrastructure.For(xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure')
  - [LogFilePath](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFilePath 'xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFilePath')
  - [Type](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-Type 'xyLOGIX.Core.Debug.ILoggingInfrastructure.Type')
  - [DeleteLogIfExists()](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-DeleteLogIfExists 'xyLOGIX.Core.Debug.ILoggingInfrastructure.DeleteLogIfExists')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.ILoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFilePathname,muteConsole,repository)](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.ILoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,log4net.Repository.ILoggerRepository)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole)](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean- 'xyLOGIX.Core.Debug.ILoggingInfrastructure.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean)')
- [LogFileManager](#T-xyLOGIX-Core-Debug-LogFileManager 'xyLOGIX.Core.Debug.LogFileManager')
  - [_infrastructure](#F-xyLOGIX-Core-Debug-LogFileManager-_infrastructure 'xyLOGIX.Core.Debug.LogFileManager._infrastructure')
  - [InfrastructureType](#P-xyLOGIX-Core-Debug-LogFileManager-InfrastructureType 'xyLOGIX.Core.Debug.LogFileManager.InfrastructureType')
  - [LogFilePath](#P-xyLOGIX-Core-Debug-LogFileManager-LogFilePath 'xyLOGIX.Core.Debug.LogFileManager.LogFilePath')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFilePathname,muteConsole,infrastructureType)](#M-xyLOGIX-Core-Debug-LogFileManager-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.LogFileManager.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,xyLOGIX.Core.Debug.LoggingInfrastructureType)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole,infrastructureType)](#M-xyLOGIX-Core-Debug-LogFileManager-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean,xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.LogFileManager.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean,xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [LoggerManager](#T-xyLOGIX-Core-Debug-LoggerManager 'xyLOGIX.Core.Debug.LoggerManager')
  - [GetRootLogger(loggerRepository)](#M-xyLOGIX-Core-Debug-LoggerManager-GetRootLogger-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.LoggerManager.GetRootLogger(log4net.Repository.ILoggerRepository)')
- [LoggerRepositoryManager](#T-xyLOGIX-Core-Debug-LoggerRepositoryManager 'xyLOGIX.Core.Debug.LoggerRepositoryManager')
  - [GetHierarchyRepository()](#M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetHierarchyRepository 'xyLOGIX.Core.Debug.LoggerRepositoryManager.GetHierarchyRepository')
  - [GetLoggerRepository()](#M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetLoggerRepository 'xyLOGIX.Core.Debug.LoggerRepositoryManager.GetLoggerRepository')
- [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType')
  - [Default](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Default 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Default')
  - [PostSharp](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-PostSharp 'xyLOGIX.Core.Debug.LoggingInfrastructureType.PostSharp')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Unknown 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Unknown')
- [PostSharpLoggingInfrastructure](#T-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure')
  - [_relay](#F-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-_relay 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure._relay')
  - [Type](#P-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-Type 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.Type')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFilePathname,muteConsole,repository)](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,log4net.Repository.ILoggerRepository)')
- [Resources](#T-xyLOGIX-Core-Debug-Properties-Resources 'xyLOGIX.Core.Debug.Properties.Resources')
  - [Culture](#P-xyLOGIX-Core-Debug-Properties-Resources-Culture 'xyLOGIX.Core.Debug.Properties.Resources.Culture')
  - [Error_DepthMustBeNonNegative](#P-xyLOGIX-Core-Debug-Properties-Resources-Error_DepthMustBeNonNegative 'xyLOGIX.Core.Debug.Properties.Resources.Error_DepthMustBeNonNegative')
  - [ExceptionMessageFormat](#P-xyLOGIX-Core-Debug-Properties-Resources-ExceptionMessageFormat 'xyLOGIX.Core.Debug.Properties.Resources.ExceptionMessageFormat')
  - [ResourceManager](#P-xyLOGIX-Core-Debug-Properties-Resources-ResourceManager 'xyLOGIX.Core.Debug.Properties.Resources.ResourceManager')

<a name='T-xyLOGIX-Core-Debug-DebugFileAndFolderHelper'></a>
## DebugFileAndFolderHelper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to work with files and folders in a robust way.

##### Remarks

These methods are here in order to assist applications in working with
log files and prepping for application startup and first-time use.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-ClearTempFileDir'></a>
### ClearTempFileDir() `method`

##### Summary

Attempts to clear the files and folders from the user's temporary
files folder.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-CreateDirectoryIfNotExists-System-String-'></a>
### CreateDirectoryIfNotExists(directoryPath) `method`

##### Summary

Creates a folder if the folder does not already exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| directoryPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) Path to the folder that you want to create. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the required parameter, `directoryPath`,
is passed a blank or `null` value. |

##### Remarks

If the folder specified by the `directoryPath`
parameter already exists on the disk, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-GetFilesInFolder-System-String-'></a>
### GetFilesInFolder(folder) `method`

##### Summary

Gets a collection of strings, each of which contains the pathname of
a file is present in the specified `folder`..

##### Returns

Collection of strings, each element of which contains the pathname
of a file located in the specified `folder`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| folder | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the full pathname of the folder whose files are to be listed. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-InsistPathExists-System-String-'></a>
### InsistPathExists() `method`

##### Summary

Checks to see if the specified file exists. If not, emits a "stop"
error message and returns false; otherwise, returns true.

##### Returns

This method returns `true` if the file with path specified by
the `fileName` parameter exists on the disk in the
specified location or `false` if either the file is not found
or if it does exist but an operating system error occurs (such as
insufficient permissions) during the search.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFileWriteable-System-String-'></a>
### IsFileWriteable(path) `method`

##### Summary

Checks for write access for the given file.

##### Returns

This method returns `true` if write access is allowed to the
file with the specified `path`, otherwise `false`.



The value `false` is also returned in the event that the
`path` parameter is a `null` value or blank.



The value `false` is also returned if an operating system error
or exception occurs while trying to look up the file's permissions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the full pathname for which write
permissions should be checked. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFolderWriteable-System-String-'></a>
### IsFolderWriteable(path) `method`

##### Summary

Checks for write access for the given folder.

##### Returns

This method returns `true` if write access is allowed to the
folder with the specified `path`, otherwise `false`.



The value `false` is also returned in the event that the
`path` parameter is a `null` value or blank.



The value `false` is also returned if an operating system error
or exception occurs while trying to look up the folder's permissions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the full pathname of the folder whose permissions are to be checked. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsValidPath-System-String-'></a>
### IsValidPath(fullyQualifiedPath) `method`

##### Summary

Gets a value indicating whether the
`fullyQualifiedPath`
is actually a valid path on the system,
according to operating-system-specific rules.

##### Returns

If the path provided in `fullyQualifiedPath` is a
valid path according to operating-system-specified rules, then this
method returns `true`. Otherwise, the return value is `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fullyQualifiedPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the path that is to be validated. |

<a name='T-xyLOGIX-Core-Debug-DebugLevel'></a>
## DebugLevel `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Values to indicate the level of logging message to be utilized for the
debugging log.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Debug'></a>
### Debug `constants`

##### Summary

Informational message that may only be visible from a Debug mode executable.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Error'></a>
### Error `constants`

##### Summary

Error that indicates an issue that has led to the stoppage of an
operation or the software as a whole.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Info'></a>
### Info `constants`

##### Summary

Informational message to be displayed even in Release mode.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Warning'></a>
### Warning `constants`

##### Summary

Warning that indicates a potential risk that has not yet become an issue.

<a name='T-xyLOGIX-Core-Debug-DebugUtils'></a>
## DebugUtils `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Helpers to manage the writing of content to the debugging log.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ApplicationName'></a>
### ApplicationName `property`

##### Summary

Gets or sets the name of the application. Used for Windows event
logging. Leave blank to not send events to the Application event log.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ConsoleOnly'></a>
### ConsoleOnly `property`

##### Summary

Gets or sets a value indicating whether the logging produced by this
object should only be written to the console as opposed to a log file.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ExceptionStackDepth'></a>
### ExceptionStackDepth `property`

##### Summary

Gets or sets the depth down the call stack from which Exception
information should be obtained.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-InfrastructureType'></a>
### InfrastructureType `property`

##### Summary

Gets or sets a
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType')
value
indicating which type of logging infrastructure is in use.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-IsLogging'></a>
### IsLogging `property`

##### Summary

Gets or sets a value that turns logging as a whole on or off.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-IsPostSharp'></a>
### IsPostSharp `property`

##### Summary

Gets a value that indicates whether PostSharp is in use as the logging
infrastructure.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-LogFilePath'></a>
### LogFilePath `property`

##### Summary

Users should set this property to the path to the log file, if logging.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value telling us to mute all console output.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode'></a>
### MuteDebugLevelIfReleaseMode `property`

##### Summary

Gets or sets a value indicating whether to mute "DEBUG" log messages
in Release mode.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-Out'></a>
### Out `property`

##### Summary

Gets or sets a value that represents the spigot of text from that
which is produced by calls to this class' methods.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-Verbosity'></a>
### Verbosity `property`

##### Summary

Gets or sets the verbosity debugLevel.

##### Remarks

Typically, applications set this to 1.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes a new static instance of [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils').

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-DumpCollection-System-Collections-ICollection-'></a>
### DumpCollection(collection) `method`

##### Summary

Dumps a collection to the debug log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [System.Collections.ICollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.ICollection 'System.Collections.ICollection') | Reference to an instance of an object that implements the
[ICollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.ICollection 'System.Collections.ICollection')
interface. |

##### Remarks

If this method is passed a `null` for
`collection`
, then it does nothing. Otherwise, the method
iterates over the `collection` and writes all of its
elements to the log, one on each line.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-EchoCommandLinkText-System-Object-'></a>
### EchoCommandLinkText(commandLink) `method`

##### Summary

Writes the text of the selected control-- which is supposed to be a
CommandLink -- to the log, while, at the same time, stripping out the
text "recommended", if present, in the control's caption.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| commandLink | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Reference to an instance of an object that implements a Command Link. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the `commandLink` parameter is a passed a
null reference. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-FormatException-System-Exception-'></a>
### FormatException(e) `method`

##### Summary

Structures the text of an [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception'), a
reference to an instance of which is passed in the
`e`
parameter, to be the error message on a line by itself,
followed by the stack trace lines on the subsequent lines.

##### Returns

String to be written to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Reference to a [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that should be
formatted and dumped to the log. |

##### Remarks

If a `null` reference is passed for `e`, then
this method returns the empty string.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-FormatExceptionAndWrite-System-Exception-'></a>
### FormatExceptionAndWrite(e) `method`

##### Summary

Takes the reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception')
that is passed in the `e` parameter, formats it as a
friendly error message along with its stack trace, and then dumps the
result to the error log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | A [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') whose information is to be dumped. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-GenerateContentFromFormat-System-String,System-Object[]-'></a>
### GenerateContentFromFormat(format,args) `method`

##### Summary

Helper method to, basically, carry out the formatting of a string.

##### Returns

The string content of `format`, processed using the
[Format](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Format 'System.String.Format') method.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String value to be formatted. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Array of format values. |

##### Remarks

The string content of the `format` parameter is left
untouched if there are no `args`.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-LogEachLineIfMultiline-System-String,System-Action{xyLOGIX-Core-Debug-DebugLevel,System-String},xyLOGIX-Core-Debug-DebugLevel-'></a>
### LogEachLineIfMultiline(content,logMethod,level) `method`

##### Summary

Detects whether the `content` is multiline. If so,
then each line of content is logged separately, using the
`logMethod`
supplied.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required. String containing the already-formatted content to be logged. |
| logMethod | [System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String}') | (Required.) Delegate specifying the logging code that is to be
executed for each line of content. |
| level | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | A [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') specifying the
debugLevel of logging to utilize. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-LogException-System-Exception-'></a>
### LogException(e) `method`

##### Summary

Logs the complete information about an exception to the log, under the
Error Level. Outputs the source file and line number where the
exception occurred, as well as the message of the exception and its
stack trace.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Reference to the [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to be logged. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-OnTextEmitted-System-String,xyLOGIX-Core-Debug-DebugLevel-'></a>
### OnTextEmitted(text,debugLevel) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DebugUtils-TextEmitted 'xyLOGIX.Core.Debug.DebugUtils.TextEmitted') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text that has been written or logged. |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | The [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') of the message. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]-'></a>
### Write(debugLevel,format,args) `method`

##### Summary

Writes the content in `format` to the
`debugLevel`
log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values that
indicates which log (DEBUG, ERROR, INFO, WARN) where the content
should be written. |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format specifier for
parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be included in
the `format` and written to the log. |

##### Remarks

If the `format` parameter is a blank or empty string,
then this method does nothing. If the `DEBUG` constant is not
defined, then this method assumes that the application was built in
Release mode. If this is so, then the method checks the value of the
[MuteDebugLevelIfReleaseMode](#P-xyLOGIX-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'xyLOGIX.Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode')
property. If the property is set to true AND the
`debugLevel`
parameter is set to
[Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug')
, then this method does
nothing. This method does not add a newline character after writing
its content to the log.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### Write(debugLevel,content) `method`

##### Summary

Writes non-formatted content to the log using the
`debugLevel`
specified. No line terminator is appended to the output.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values that
indicates which log (DEBUG, ERROR, INFO, WARN) where the content
should be written. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) string containing the content to be written. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `debugLevel` parameter is not one of
the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values. |

##### Remarks

If the `content` is a blank or empty string, then
this method does nothing. This method's behavior is identical to that
of [WriteCore](#M-xyLOGIX-Core-Debug-DebugUtils-WriteCore 'xyLOGIX.Core.Debug.DebugUtils.WriteCore'), except
that a newline character is appended to the end of the content.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteCore-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteCore(debugLevel,content) `method`

##### Summary

Provides the implementation details of writing messages to the log. No
line terminator is added to the content written.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values that
determine what logging debugLevel to utilize. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the content to be written to the log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `debugLevel` parameter is not one of
the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values. |

##### Remarks

If the string passed in `content` is blank or empty,
then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]-'></a>
### WriteLine(debugLevel,format,args) `method`

##### Summary

Writes the content in `format` to the
`debugLevel`
log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values that
indicates which log (DEBUG, ERROR, INFO, WARN) where the content
should be written. |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format specifier for
parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be included in
the `format` and written to the log. |

##### Remarks

If the `format` parameter is a blank or empty string,
then this method does nothing. If the `DEBUG` constant is not
defined, then this method assumes that the application was built in
Release mode. If this is so, then the method checks the value of the
[MuteDebugLevelIfReleaseMode](#P-xyLOGIX-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'xyLOGIX.Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode')
property. If the property is set to true AND the
`debugLevel`
parameter is set to
[Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug')
, then this method does
nothing. This method adds a newline character after writing its
content to the log.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,args) `method`

##### Summary

Works the same as the overload which takes a
[DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel')
as its first argument, but if
the formatted content consists of several lines of content, then the
lines are split and logged separately, all under the
[Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug')
debugLevel.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format specifier for
parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be included in
the `format` and written to the log. |

##### Remarks

This overload specifies that the
[Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug')
logging debugLevel is
to be utilized for each line.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteLine(debugLevel,content) `method`

##### Summary

Writes non-formatted content to the log using the
`debugLevel`
specified, terminated by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values that
indicates which log (DEBUG, ERROR, INFO, WARN) where the content
should be written. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) string containing the content to be written. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `debugLevel` parameter is not one of
the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values. |

##### Remarks

If the `content` is a blank or empty string, then
this method does nothing. This method's behavior is identical to that
of [WriteCore](#M-xyLOGIX-Core-Debug-DebugUtils-WriteCore 'xyLOGIX.Core.Debug.DebugUtils.WriteCore'), except
that a newline character is appended to the end of the content.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLineCore-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteLineCore(debugLevel,content) `method`

##### Summary

Provides the implementation details of writing messages to the log,
one line at a time.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values that
determine what logging debugLevel to utilize. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the content to be written to the log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `debugLevel` parameter is not one of
the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') values. |

##### Remarks

If the string passed in `content` is blank or empty,
then this method does nothing.

<a name='T-xyLOGIX-Core-Debug-DebuggerDump'></a>
## DebuggerDump `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to send objects to the log by calling an extension method called
'Dump', like in LINQpad.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object-'></a>
### Dump(element) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [ArgumentNullException](#T-ArgumentNullException 'ArgumentNullException') | Thrown if the required parameter, `element`, is
passed a `null` value. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32-'></a>
### Dump(element,depth) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which the object
should be dumped. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [ArgumentNullException](#T-ArgumentNullException 'ArgumentNullException') | Thrown if the required parameter, `element`, is
passed a `null` value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `depth` parameter is less than zero. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32,System-IO-TextWriter-'></a>
### Dump(element,depth,log) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which the object
should be dumped. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is open on the target log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [ArgumentNullException](#T-ArgumentNullException 'ArgumentNullException') | Thrown if the either of the required parameters, `element` or `log`, are passed a `null` value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `depth` parameter is less than zero. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object-'></a>
### DumpLines(element) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log, followed by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [ArgumentNullException](#T-ArgumentNullException 'ArgumentNullException') | Thrown if the required parameter, `element`, is
passed a `null` value. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32-'></a>
### DumpLines(element,depth) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log, followed by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which the object
should be dumped. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [ArgumentNullException](#T-ArgumentNullException 'ArgumentNullException') | Thrown if the required parameter, `element`, is
passed a `null` value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `depth` parameter is less than zero. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32,System-IO-TextWriter-'></a>
### DumpLines(element,depth,log) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which the object
should be dumped. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is open on the target log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [ArgumentNullException](#T-ArgumentNullException 'ArgumentNullException') | Thrown if the either of the required parameters, `element` or `log`, are passed a `null` value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `depth` parameter is less than zero. |

<a name='T-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure'></a>
## DefaultLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Default implementation details for the [LogFileManager](#T-xyLOGIX-Core-Debug-LogFileManager 'xyLOGIX.Core.Debug.LogFileManager').

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFilePath'></a>
### LogFilePath `property`

##### Summary

Gets the full path and filename to the log file for this application.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') value that
corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-DeleteLogIfExists'></a>
### DeleteLogIfExists() `method`

##### Summary

Deletes the log file, if it exists.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the [File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the
first appender in the list of appenders that is of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the
appender is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the [LogFilePath](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFilePath 'xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFilePath') property.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFilePathname,muteConsole,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write out "DEBUG" messages to the log
file when in the Release mode. Set to false if all messages should
always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest
logging sent out by this instance. |
| configurationFilePathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for
initializing log4net. If blank, the system attempts to utilize the
default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to
the console if a log file is being used. If a log file is not used,
then no logging at all will occur if this parameter is set to `true`. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements
the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface.
Supply a value for this parameter if your infrastructure is not
utilizing the default HierarchicalRepository. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-PrepareLogFile-System-Boolean,log4net-Repository-ILoggerRepository-'></a>
### PrepareLogFile(overwrite,repository) `method`

##### Summary

Prepares the log file by ensuring that the containing folder is
writeable by the current user and by then, if specified to
overwrite, deleting the current log file.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest
logging sent out by this instance. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements
the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface.
Supply a value for this parameter if your infrastructure is not
utilizing the default HierarchicalRepository. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') to
initialize its functionality.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any logging statements that are set to the
[Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug') level. |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log file; false
to suppress. Usually used with the `consoleOnly`
parameter set to true. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to write them both
to the console and to the log. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Zero to suppress every message; greater than zero to echo every message. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all console output. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-WriteTimestamp'></a>
### WriteTimestamp() `method`

##### Summary

Writes a date and time stamp to the top of the log file.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-EventLogManager'></a>
## EventLogManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Class to manage access to the event log.

<a name='M-xyLOGIX-Core-Debug-EventLogManager-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs an instance of [EventLogManager](#T-EventLogManager 'EventLogManager') and returns a
reference to the new instance.

##### Parameters

This constructor has no parameters.

<a name='F-xyLOGIX-Core-Debug-EventLogManager-_theEventLogManager'></a>
### _theEventLogManager `constants`

##### Summary

Holds an reference to the one and only instance of
[EventLogManager](#T-xyLOGIX-Core-Debug-EventLogManager 'xyLOGIX.Core.Debug.EventLogManager').

<a name='P-xyLOGIX-Core-Debug-EventLogManager-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of [EventLogManager](#T-xyLOGIX-Core-Debug-EventLogManager 'xyLOGIX.Core.Debug.EventLogManager')
.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-IsInitialized'></a>
### IsInitialized `property`

##### Summary

Gets a value indicating whether this object has been properly initialized.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-Source'></a>
### Source `property`

##### Summary

Gets or sets the source of events. Typically this is the name of the
application that is sending the events.

##### Remarks

This property must be set before logging events, otherwise an error
will occur.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-Type'></a>
### Type `property`

##### Summary

Gets or sets the type of log to which events are to be sent
(Application, System, Security, etc.).

##### Remarks

This property must be set before logging events, otherwise an error
will occur.

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Error-System-String-'></a>
### Error(content) `method`

##### Summary

Sends an Error event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source')
and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type')
properties. The
content of the logging message is specified by the
`content`
parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String specifying the content of the event log message. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Info-System-String-'></a>
### Info(content) `method`

##### Summary

Sends an Info event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source')
and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type')
properties. The
content of the logging message is specified by the
`content`
parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String specifying the content of the event log message. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Initialize-System-String,xyLOGIX-Core-Debug-EventLogType-'></a>
### Initialize(eventSourceName,logType) `method`

##### Summary

Initializes event logging for your application.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name of the application that will be
sending events. |
| logType | [xyLOGIX.Core.Debug.EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') | (Required.) One of the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType')
values that specifies the type of log to send events to. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Warn-System-String-'></a>
### Warn(content) `method`

##### Summary

Sends a Warning event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source')
and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type')
properties. The
content of the logging message is specified by the
`content`
parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String specifying the content of the event log message. |

<a name='T-xyLOGIX-Core-Debug-EventLogType'></a>
## EventLogType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

The type of event log to write events to.

<a name='F-xyLOGIX-Core-Debug-EventLogType-Application'></a>
### Application `constants`

##### Summary

Events get directed to the Application event log.

<a name='F-xyLOGIX-Core-Debug-EventLogType-None'></a>
### None `constants`

##### Summary

No event log is to be utilized.

<a name='F-xyLOGIX-Core-Debug-EventLogType-Security'></a>
### Security `constants`

##### Summary

Events get directed to the Security event log.

<a name='F-xyLOGIX-Core-Debug-EventLogType-System'></a>
### System `constants`

##### Summary

Events get directed to the System event log.

<a name='F-xyLOGIX-Core-Debug-EventLogType-Unknown'></a>
### Unknown `constants`

##### Summary

The event log type is unknown.

<a name='T-xyLOGIX-Core-Debug-FileAppenderConfigurator'></a>
## FileAppenderConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods for configurating log4net's FileAppender

<a name='M-xyLOGIX-Core-Debug-FileAppenderConfigurator-SetMinimalLock-log4net-Appender-FileAppender-'></a>
### SetMinimalLock(appender) `method`

##### Summary

Sets the option to get the minimal locking option set on the
specified `appender`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| appender | [log4net.Appender.FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') | Reference to an instance of an object of type
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the instance of the object referenced by
`appender`
is `null`. |

<a name='T-xyLOGIX-Core-Debug-FileAppenderManager'></a>
## FileAppenderManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods to access instances of objects of type
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-GetAppenderByName-System-String-'></a>
### GetAppenderByName(name) `method`

##### Summary

Attempts to obtain a reference to an instance of
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender')
that is configured under a
certain name in the application configuration file.

##### Returns

If a suitable configuration file entry is found, this method returns
a [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') instance that
corresponds to the entry; otherwise, `null` is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name under which the appender is
configured in the application configuration file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [ArgumentException](#T-ArgumentException 'ArgumentException') | Thrown if the required parameter, `name`, is passed
a blank or `null` string for a value. |

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstAppender-log4net-Repository-ILoggerRepository-'></a>
### GetFirstAppender(loggerRepository) `method`

##### Summary

If the root logger's appenders list contains appenders, returns a
reference to the first one in the list.

##### Returns

Reference to an instance of
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender')
, or `null` if not found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') |  |

##### Remarks

If the `loggerRepository` parameter is passed a
`null` value, then this method attempts to obtain the root
logger object and then obtain the first
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender')
configured on the root
logger repository. If a suitable appender can still not be located,
then the return value of this method is `null`.

<a name='T-xyLOGIX-Core-Debug-GetLoggingInfrastructure'></a>
## GetLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Creates instances of objects that implement the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-For-xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### For(type) `method`

##### Summary

Creates an instance of an object implementing the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface which
corresponds to the value specified in `type`, and
returns a reference to it.

##### Returns

A reference to the instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface which
corresponds to the value specified in `type`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | One of the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') values that
describes what type of object you want. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if there is no corresponding concrete type defined that
implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface and
which corresponds to the value passed in the `type` parameter. |

##### Remarks

This method will throw an exception if there are no types implemented
that correspond to the value of `type`.

<a name='T-xyLOGIX-Core-Debug-ILoggingInfrastructure'></a>
## ILoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the methods and properties of a custom object to which the [LogFileManager](#T-xyLOGIX-Core-Debug-LogFileManager 'xyLOGIX.Core.Debug.LogFileManager') delegates the
implementation of its properties and methods.

<a name='P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFilePath'></a>
### LogFilePath `property`

##### Summary

Gets the full path and filename to the log file for this application.

<a name='P-xyLOGIX-Core-Debug-ILoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') value that
corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-DeleteLogIfExists'></a>
### DeleteLogIfExists() `method`

##### Summary

Deletes the log file, if it exists.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the [File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the
first appender in the list of appenders that is of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the
appender is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the [LogFilePath](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFilePath 'xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFilePath') property.

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFilePathname,muteConsole,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write out "DEBUG" messages to the log
file when in the Release mode. Set to false if all messages should
always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest
logging sent out by this instance. |
| configurationFilePathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for
initializing log4net. If blank, the system attempts to utilize the
default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to
the console if a log file is being used. If a log file is not used,
then no logging at all will occur if this parameter is set to `true`. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements
the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface.
Supply a value for this parameter if your infrastructure is not
utilizing the default HierarchicalRepository. |

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') to
initialize its functionality.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any logging statements that are set to
[Debug](#F-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug'). |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log file; false
to suppress. Usually used with the `consoleOnly`
parameter set to `true`. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to write them both
to the console and to the log. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Zero to suppress every message; greater than zero to echo every message. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all console output. |

<a name='T-xyLOGIX-Core-Debug-LogFileManager'></a>
## LogFileManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to be used to manage the application log.

<a name='F-xyLOGIX-Core-Debug-LogFileManager-_infrastructure'></a>
### _infrastructure `constants`

##### Summary

Reference to an instance of the object that implements the
[ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure')
interface for
the logging infrastructure type chosen.

##### Remarks

This is the object that will provide the behind-the-scenes
implementation for this object from now on.

<a name='P-xyLOGIX-Core-Debug-LogFileManager-InfrastructureType'></a>
### InfrastructureType `property`

##### Summary

Gets the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType')
value that
represents the type of infrastructure currently in use by this
[LogFileManager](#T-xyLOGIX-Core-Debug-LogFileManager 'xyLOGIX.Core.Debug.LogFileManager').

<a name='P-xyLOGIX-Core-Debug-LogFileManager-LogFilePath'></a>
### LogFilePath `property`

##### Summary

Gets the full path and filename to the log file for this application.

##### Remarks

This property should only be called after the
[InitializeLogging](#M-xyLOGIX-Core-Debug-LogFileManager-InitializeLogging 'xyLOGIX.Core.Debug.LogFileManager.InitializeLogging')
method has been called.

<a name='M-xyLOGIX-Core-Debug-LogFileManager-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFilePathname,muteConsole,infrastructureType) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write out "DEBUG" messages to the log
file when in the Release mode. Set to false if all messages should
always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest
logging sent out by this instance. |
| configurationFilePathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for
initializing log4net. If blank, the system attempts to utilize the
default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to
the console if a log file is being used. If a log file is not used,
then no logging at all will occur if this parameter is set to `true`. |
| infrastructureType | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Optional.) One of the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType')
values that
indicates what type of logging infrastructure is to be utilized
(default or PostSharp, for example). |

<a name='M-xyLOGIX-Core-Debug-LogFileManager-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean,xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole,infrastructureType) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') to
initialize its functionality.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any logging statements that are set to
[Debug](#F-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug'). |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log file; false
to suppress. Usually used with the `consoleOnly`
parameter set to `true`. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to write them both
to the console and to the log. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Zero to suppress every message; greater than zero to echo every message. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all console output. |
| infrastructureType | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Optional.) One of the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType')
values that
indicates what type of logging infrastructure is to be utilized
(default or PostSharp). |

<a name='T-xyLOGIX-Core-Debug-LoggerManager'></a>
## LoggerManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods to access objects of type [Logger](#T-log4net-Hierarchy-Repository-Logger 'log4net.Hierarchy.Repository.Logger') from log4net.

<a name='M-xyLOGIX-Core-Debug-LoggerManager-GetRootLogger-log4net-Repository-ILoggerRepository-'></a>
### GetRootLogger(loggerRepository) `method`

##### Summary

Gets a reference to the default logger repository's root instance of
[Logger](#T-log4net-Hierarchy-Repository-Logger 'log4net.Hierarchy.Repository.Logger').

##### Returns

Reference to the default logger repository's root instance of [Logger](#T-log4net-Hierarchy-Repository-Logger 'log4net.Hierarchy.Repository.Logger'), or null if not found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') |  |

<a name='T-xyLOGIX-Core-Debug-LoggerRepositoryManager'></a>
## LoggerRepositoryManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods to access the log4net Repository.

<a name='M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetHierarchyRepository'></a>
### GetHierarchyRepository() `method`

##### Summary

Gets a reference to an instance of the log4net repository as an
reference to an object of type Hierachy.

##### Returns

Reference to an instance of a [](#I-ILoggerRepository 'ILoggerRepository') that
derives from [Hierarchy](#T-log4net-Repository-Hierarchy 'log4net.Repository.Hierarchy'), or null if
no such object has been found.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetLoggerRepository'></a>
### GetLoggerRepository() `method`

##### Summary

Wraps the [GetRepository](#M-log4net-LogManager-GetRepository 'log4net.LogManager.GetRepository') method.

##### Returns

Reference to an instance of an object that implements [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository'), or null if such an object cannot be found.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-LoggingInfrastructureType'></a>
## LoggingInfrastructureType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Values describing the type of logging infrastructure you want to utilize.

<a name='F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Default'></a>
### Default `constants`

##### Summary

Default logging for legacy code.

<a name='F-xyLOGIX-Core-Debug-LoggingInfrastructureType-PostSharp'></a>
### PostSharp `constants`

##### Summary

PostSharp-compatible logging infrastructure initialization.

<a name='F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown strategy type.

<a name='T-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure'></a>
## PostSharpLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Implements log-file management for the case when we are utilizing
PostSharp aspects to handle the bulk of logging for us.

<a name='F-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-_relay'></a>
### _relay `constants`

##### Summary

Reference to the object that relays all logging to PostSharp.

##### Remarks

This field can only be set to a reference to an instance of an object
that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface.

<a name='P-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType')
value that corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the [File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the first
appender in the list of appenders that is of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the appender
is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the [LogFilePath](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFilePath 'xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFilePath') property.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFilePathname,muteConsole,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write out "DEBUG" messages to the log
file when in the Release mode. Set to false if all messages should
always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest
logging sent out by this instance. |
| configurationFilePathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for
initializing log4net. If blank, the system attempts to utilize the
default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the
console if a log file is being used. If a log file is not used, then
no logging at all will occur if this parameter is set to `true`. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the
[ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. Supply
a value for this parameter if your infrastructure is not utilizing the
default HierarchicalRepository. |

##### Remarks

This override bolts the PostSharp aspect-oriented-programming
infrastructure up into our already well-crafted logging infrastructure
by switching out the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository')
-implementing object that will tie our logging framework to PostSharp.

<a name='T-xyLOGIX-Core-Debug-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.Core.Debug.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-Error_DepthMustBeNonNegative'></a>
### Error_DepthMustBeNonNegative `property`

##### Summary

Looks up a localized string similar to The 'depth' parameter must be zero or greater..

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-ExceptionMessageFormat'></a>
### ExceptionMessageFormat `property`

##### Summary

Looks up a localized string similar to {0}: {1}
{2}.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.
