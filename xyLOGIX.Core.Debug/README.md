<a name='assembly'></a>
# xyLOGIX.Core.Debug

## Contents

- [Activate](#T-xyLOGIX-Core-Debug-Activate 'xyLOGIX.Core.Debug.Activate')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Activate-#cctor 'xyLOGIX.Core.Debug.Activate.#cctor')
  - [LoggingForLogFileName(logFileName,repository)](#M-xyLOGIX-Core-Debug-Activate-LoggingForLogFileName-System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.Activate.LoggingForLogFileName(System.String,log4net.Repository.ILoggerRepository)')
- [AppDomainFriendlyNames](#T-xyLOGIX-Core-Debug-AppDomainFriendlyNames 'xyLOGIX.Core.Debug.AppDomainFriendlyNames')
  - [LINQPad](#F-xyLOGIX-Core-Debug-AppDomainFriendlyNames-LINQPad 'xyLOGIX.Core.Debug.AppDomainFriendlyNames.LINQPad')
  - [#cctor()](#M-xyLOGIX-Core-Debug-AppDomainFriendlyNames-#cctor 'xyLOGIX.Core.Debug.AppDomainFriendlyNames.#cctor')
- [CommandLineParameter](#T-xyLOGIX-Core-Debug-CommandLineParameter 'xyLOGIX.Core.Debug.CommandLineParameter')
  - [HaltOnException](#F-xyLOGIX-Core-Debug-CommandLineParameter-HaltOnException 'xyLOGIX.Core.Debug.CommandLineParameter.HaltOnException')
- [Compute](#T-xyLOGIX-Core-Debug-Compute 'xyLOGIX.Core.Debug.Compute')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Compute-#cctor 'xyLOGIX.Core.Debug.Compute.#cctor')
  - [ZeroFloor(value)](#M-xyLOGIX-Core-Debug-Compute-ZeroFloor-System-Int32- 'xyLOGIX.Core.Debug.Compute.ZeroFloor(System.Int32)')
- [ConsoleOutputLocation](#T-xyLOGIX-Core-Debug-ConsoleOutputLocation 'xyLOGIX.Core.Debug.ConsoleOutputLocation')
  - [#ctor()](#M-xyLOGIX-Core-Debug-ConsoleOutputLocation-#ctor 'xyLOGIX.Core.Debug.ConsoleOutputLocation.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-ConsoleOutputLocation-Instance 'xyLOGIX.Core.Debug.ConsoleOutputLocation.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-ConsoleOutputLocation-Type 'xyLOGIX.Core.Debug.ConsoleOutputLocation.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-ConsoleOutputLocation-#cctor 'xyLOGIX.Core.Debug.ConsoleOutputLocation.#cctor')
  - [Write(value)](#M-xyLOGIX-Core-Debug-ConsoleOutputLocation-Write-System-Object- 'xyLOGIX.Core.Debug.ConsoleOutputLocation.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-ConsoleOutputLocation-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.ConsoleOutputLocation.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine-System-Object- 'xyLOGIX.Core.Debug.ConsoleOutputLocation.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.ConsoleOutputLocation.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine 'xyLOGIX.Core.Debug.ConsoleOutputLocation.WriteLine')
- [DebugFileAndFolderHelper](#T-xyLOGIX-Core-Debug-DebugFileAndFolderHelper 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-#cctor 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.#cctor')
  - [ClearTempFileDir()](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-ClearTempFileDir 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.ClearTempFileDir')
  - [CreateDirectoryIfNotExists(directoryPath)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-CreateDirectoryIfNotExists-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.CreateDirectoryIfNotExists(System.String)')
  - [InsistPathExists()](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-InsistPathExists-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.InsistPathExists(System.String)')
  - [IsFileWriteable(path)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFileWriteable-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsFileWriteable(System.String)')
  - [IsFolderWriteable(pathname)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFolderWriteable-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsFolderWriteable(System.String)')
  - [IsValidPath(fullyQualifiedPath)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsValidPath-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsValidPath(System.String)')
- [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel')
  - [Debug](#F-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug')
  - [Error](#F-xyLOGIX-Core-Debug-DebugLevel-Error 'xyLOGIX.Core.Debug.DebugLevel.Error')
  - [Info](#F-xyLOGIX-Core-Debug-DebugLevel-Info 'xyLOGIX.Core.Debug.DebugLevel.Info')
  - [Output](#F-xyLOGIX-Core-Debug-DebugLevel-Output 'xyLOGIX.Core.Debug.DebugLevel.Output')
  - [Unknown](#F-xyLOGIX-Core-Debug-DebugLevel-Unknown 'xyLOGIX.Core.Debug.DebugLevel.Unknown')
  - [Warning](#F-xyLOGIX-Core-Debug-DebugLevel-Warning 'xyLOGIX.Core.Debug.DebugLevel.Warning')
- [DebugOutputLocation](#T-xyLOGIX-Core-Debug-DebugOutputLocation 'xyLOGIX.Core.Debug.DebugOutputLocation')
  - [#ctor()](#M-xyLOGIX-Core-Debug-DebugOutputLocation-#ctor 'xyLOGIX.Core.Debug.DebugOutputLocation.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-DebugOutputLocation-Instance 'xyLOGIX.Core.Debug.DebugOutputLocation.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-DebugOutputLocation-Type 'xyLOGIX.Core.Debug.DebugOutputLocation.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DebugOutputLocation-#cctor 'xyLOGIX.Core.Debug.DebugOutputLocation.#cctor')
  - [Write(value)](#M-xyLOGIX-Core-Debug-DebugOutputLocation-Write-System-Object- 'xyLOGIX.Core.Debug.DebugOutputLocation.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-DebugOutputLocation-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugOutputLocation.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine-System-Object- 'xyLOGIX.Core.Debug.DebugOutputLocation.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugOutputLocation.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine 'xyLOGIX.Core.Debug.DebugOutputLocation.WriteLine')
- [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils')
  - [_verbosity](#F-xyLOGIX-Core-Debug-DebugUtils-_verbosity 'xyLOGIX.Core.Debug.DebugUtils._verbosity')
  - [ApplicationName](#P-xyLOGIX-Core-Debug-DebugUtils-ApplicationName 'xyLOGIX.Core.Debug.DebugUtils.ApplicationName')
  - [ConsoleOnly](#P-xyLOGIX-Core-Debug-DebugUtils-ConsoleOnly 'xyLOGIX.Core.Debug.DebugUtils.ConsoleOnly')
  - [ExceptionLogPathname](#P-xyLOGIX-Core-Debug-DebugUtils-ExceptionLogPathname 'xyLOGIX.Core.Debug.DebugUtils.ExceptionLogPathname')
  - [InfrastructureType](#P-xyLOGIX-Core-Debug-DebugUtils-InfrastructureType 'xyLOGIX.Core.Debug.DebugUtils.InfrastructureType')
  - [IsLogging](#P-xyLOGIX-Core-Debug-DebugUtils-IsLogging 'xyLOGIX.Core.Debug.DebugUtils.IsLogging')
  - [IsPostSharp](#P-xyLOGIX-Core-Debug-DebugUtils-IsPostSharp 'xyLOGIX.Core.Debug.DebugUtils.IsPostSharp')
  - [LogFileName](#P-xyLOGIX-Core-Debug-DebugUtils-LogFileName 'xyLOGIX.Core.Debug.DebugUtils.LogFileName')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-DebugUtils-MuteConsole 'xyLOGIX.Core.Debug.DebugUtils.MuteConsole')
  - [MuteDebugLevelIfReleaseMode](#P-xyLOGIX-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'xyLOGIX.Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode')
  - [Out](#P-xyLOGIX-Core-Debug-DebugUtils-Out 'xyLOGIX.Core.Debug.DebugUtils.Out')
  - [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DebugUtils-#cctor 'xyLOGIX.Core.Debug.DebugUtils.#cctor')
  - [CanLaunchDebugger(exception,launchDebuggerConfigured)](#M-xyLOGIX-Core-Debug-DebugUtils-CanLaunchDebugger-System-Exception,System-Boolean- 'xyLOGIX.Core.Debug.DebugUtils.CanLaunchDebugger(System.Exception,System.Boolean)')
  - [ClearTempExceptionLog()](#M-xyLOGIX-Core-Debug-DebugUtils-ClearTempExceptionLog 'xyLOGIX.Core.Debug.DebugUtils.ClearTempExceptionLog')
  - [DumpCollection(collection)](#M-xyLOGIX-Core-Debug-DebugUtils-DumpCollection-System-Collections-ICollection- 'xyLOGIX.Core.Debug.DebugUtils.DumpCollection(System.Collections.ICollection)')
  - [EchoCommandLinkText(commandLink)](#M-xyLOGIX-Core-Debug-DebugUtils-EchoCommandLinkText-System-Object- 'xyLOGIX.Core.Debug.DebugUtils.EchoCommandLinkText(System.Object)')
  - [FormatException(e)](#M-xyLOGIX-Core-Debug-DebugUtils-FormatException-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.FormatException(System.Exception)')
  - [FormatExceptionAndWrite(e)](#M-xyLOGIX-Core-Debug-DebugUtils-FormatExceptionAndWrite-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.FormatExceptionAndWrite(System.Exception)')
  - [GenerateContentFromFormat(format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-GenerateContentFromFormat-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.GenerateContentFromFormat(System.String,System.Object[])')
  - [LogEachLineIfMultiline(content,logMethod,level)](#M-xyLOGIX-Core-Debug-DebugUtils-LogEachLineIfMultiline-System-String,System-Action{xyLOGIX-Core-Debug-DebugLevel,System-String},xyLOGIX-Core-Debug-DebugLevel- 'xyLOGIX.Core.Debug.DebugUtils.LogEachLineIfMultiline(System.String,System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String},xyLOGIX.Core.Debug.DebugLevel)')
  - [LogException(exception,launchDebugger)](#M-xyLOGIX-Core-Debug-DebugUtils-LogException-System-Exception,System-Boolean- 'xyLOGIX.Core.Debug.DebugUtils.LogException(System.Exception,System.Boolean)')
  - [OnTextEmitted(e)](#M-xyLOGIX-Core-Debug-DebugUtils-OnTextEmitted-xyLOGIX-Core-Debug-TextEmittedEventArgs- 'xyLOGIX.Core.Debug.DebugUtils.OnTextEmitted(xyLOGIX.Core.Debug.TextEmittedEventArgs)')
  - [OnVerbosityChanged()](#M-xyLOGIX-Core-Debug-DebugUtils-OnVerbosityChanged-xyLOGIX-Core-Debug-VerbosityChangedEventArgs- 'xyLOGIX.Core.Debug.DebugUtils.OnVerbosityChanged(xyLOGIX.Core.Debug.VerbosityChangedEventArgs)')
  - [OutputExceptionLoggingMessage(exception,message)](#M-xyLOGIX-Core-Debug-DebugUtils-OutputExceptionLoggingMessage-System-Exception,System-String- 'xyLOGIX.Core.Debug.DebugUtils.OutputExceptionLoggingMessage(System.Exception,System.String)')
  - [Write(debugLevel,format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.Write(xyLOGIX.Core.Debug.DebugLevel,System.String,System.Object[])')
  - [Write(debugLevel,content)](#M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String- 'xyLOGIX.Core.Debug.DebugUtils.Write(xyLOGIX.Core.Debug.DebugLevel,System.String)')
  - [WriteCore(debugLevel,content)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteCore-xyLOGIX-Core-Debug-DebugLevel,System-String- 'xyLOGIX.Core.Debug.DebugUtils.WriteCore(xyLOGIX.Core.Debug.DebugLevel,System.String)')
  - [WriteLine(debugLevel,format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.WriteLine(xyLOGIX.Core.Debug.DebugLevel,System.String,System.Object[])')
  - [WriteLine(format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.WriteLine(System.String,System.Object[])')
  - [WriteLine(debugLevel,content)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String- 'xyLOGIX.Core.Debug.DebugUtils.WriteLine(xyLOGIX.Core.Debug.DebugLevel,System.String)')
  - [WriteLineCore(debugLevel,content)](#M-xyLOGIX-Core-Debug-DebugUtils-WriteLineCore-xyLOGIX-Core-Debug-DebugLevel,System-String- 'xyLOGIX.Core.Debug.DebugUtils.WriteLineCore(xyLOGIX.Core.Debug.DebugLevel,System.String)')
- [DebuggerDump](#T-xyLOGIX-Core-Debug-DebuggerDump 'xyLOGIX.Core.Debug.DebuggerDump')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DebuggerDump-#cctor 'xyLOGIX.Core.Debug.DebuggerDump.#cctor')
  - [Dump(element)](#M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object- 'xyLOGIX.Core.Debug.DebuggerDump.Dump(System.Object)')
  - [Dump(element,depth)](#M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32- 'xyLOGIX.Core.Debug.DebuggerDump.Dump(System.Object,System.Int32)')
  - [Dump(element,depth,log)](#M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32,System-IO-TextWriter- 'xyLOGIX.Core.Debug.DebuggerDump.Dump(System.Object,System.Int32,System.IO.TextWriter)')
  - [DumpLines(element)](#M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object- 'xyLOGIX.Core.Debug.DebuggerDump.DumpLines(System.Object)')
  - [DumpLines(element,depth)](#M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32- 'xyLOGIX.Core.Debug.DebuggerDump.DumpLines(System.Object,System.Int32)')
  - [DumpLines(element,depth,log)](#M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32,System-IO-TextWriter- 'xyLOGIX.Core.Debug.DebuggerDump.DumpLines(System.Object,System.Int32,System.IO.TextWriter)')
- [DefaultLoggingInfrastructure](#T-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure')
  - [#ctor()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-#ctor 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.#ctor')
  - [_logFileName](#F-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-_logFileName 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure._logFileName')
  - [LogFileName](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFileName 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileName')
  - [Type](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Type 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-#cctor 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.#cctor')
  - [DeleteLogIfExists(logFileName)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-DeleteLogIfExists-System-String- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.DeleteLogIfExists(System.String)')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
  - [OnLogFileNameChanged()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-OnLogFileNameChanged 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.OnLogFileNameChanged')
  - [PrepareLogFile(repository)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-PrepareLogFile-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.PrepareLogFile(log4net.Repository.ILoggerRepository)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean)')
  - [WriteTimestamp()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-WriteTimestamp 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.WriteTimestamp')
- [Delete](#T-xyLOGIX-Core-Debug-Delete 'xyLOGIX.Core.Debug.Delete')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Delete-#cctor 'xyLOGIX.Core.Debug.Delete.#cctor')
  - [FileIfExists(pathname)](#M-xyLOGIX-Core-Debug-Delete-FileIfExists-System-String- 'xyLOGIX.Core.Debug.Delete.FileIfExists(System.String)')
  - [LogFile(pathname)](#M-xyLOGIX-Core-Debug-Delete-LogFile-System-String- 'xyLOGIX.Core.Debug.Delete.LogFile(System.String)')
- [EmergencyStopPendingEventHandler](#T-xyLOGIX-Core-Debug-EmergencyStopPendingEventHandler 'xyLOGIX.Core.Debug.EmergencyStopPendingEventHandler')
- [EventLogManager](#T-xyLOGIX-Core-Debug-EventLogManager 'xyLOGIX.Core.Debug.EventLogManager')
  - [#ctor()](#M-xyLOGIX-Core-Debug-EventLogManager-#ctor 'xyLOGIX.Core.Debug.EventLogManager.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-EventLogManager-Instance 'xyLOGIX.Core.Debug.EventLogManager.Instance')
  - [IsInitialized](#P-xyLOGIX-Core-Debug-EventLogManager-IsInitialized 'xyLOGIX.Core.Debug.EventLogManager.IsInitialized')
  - [Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source')
  - [Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-EventLogManager-#cctor 'xyLOGIX.Core.Debug.EventLogManager.#cctor')
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
- [ExceptionExtensions](#T-xyLOGIX-Core-Debug-ExceptionExtensions 'xyLOGIX.Core.Debug.ExceptionExtensions')
  - [#cctor()](#M-xyLOGIX-Core-Debug-ExceptionExtensions-#cctor 'xyLOGIX.Core.Debug.ExceptionExtensions.#cctor')
  - [IsAnyOf(exception,types)](#M-xyLOGIX-Core-Debug-ExceptionExtensions-IsAnyOf-System-Exception,System-Type[]- 'xyLOGIX.Core.Debug.ExceptionExtensions.IsAnyOf(System.Exception,System.Type[])')
  - [LogAllExceptions(exceptions)](#M-xyLOGIX-Core-Debug-ExceptionExtensions-LogAllExceptions-System-Collections-Generic-IEnumerable{System-Exception}- 'xyLOGIX.Core.Debug.ExceptionExtensions.LogAllExceptions(System.Collections.Generic.IEnumerable{System.Exception})')
- [ExceptionLoggedEventArgs](#T-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs')
  - [#ctor(exception)](#M-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs-#ctor-System-Exception- 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs.#ctor(System.Exception)')
  - [Exception](#P-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs-Exception 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs.Exception')
- [ExceptionLoggedEventHandler](#T-xyLOGIX-Core-Debug-ExceptionLoggedEventHandler 'xyLOGIX.Core.Debug.ExceptionLoggedEventHandler')
- [FileAppenderConfigurator](#T-xyLOGIX-Core-Debug-FileAppenderConfigurator 'xyLOGIX.Core.Debug.FileAppenderConfigurator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FileAppenderConfigurator-#cctor 'xyLOGIX.Core.Debug.FileAppenderConfigurator.#cctor')
  - [SetMinimalLock(appender)](#M-xyLOGIX-Core-Debug-FileAppenderConfigurator-SetMinimalLock-log4net-Appender-FileAppender- 'xyLOGIX.Core.Debug.FileAppenderConfigurator.SetMinimalLock(log4net.Appender.FileAppender)')
- [FileAppenderManager](#T-xyLOGIX-Core-Debug-FileAppenderManager 'xyLOGIX.Core.Debug.FileAppenderManager')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FileAppenderManager-#cctor 'xyLOGIX.Core.Debug.FileAppenderManager.#cctor')
  - [GetAppenderByName(name)](#M-xyLOGIX-Core-Debug-FileAppenderManager-GetAppenderByName-System-String- 'xyLOGIX.Core.Debug.FileAppenderManager.GetAppenderByName(System.String)')
  - [GetFirstAppender(loggerRepository)](#M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstAppender-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.FileAppenderManager.GetFirstAppender(log4net.Repository.ILoggerRepository)')
- [GetAssembly](#T-xyLOGIX-Core-Debug-GetAssembly 'xyLOGIX.Core.Debug.GetAssembly')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetAssembly-#cctor 'xyLOGIX.Core.Debug.GetAssembly.#cctor')
  - [Pathname(assembly)](#M-xyLOGIX-Core-Debug-GetAssembly-Pathname-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.GetAssembly.Pathname(System.Reflection.Assembly)')
  - [ToUseForEventLogging()](#M-xyLOGIX-Core-Debug-GetAssembly-ToUseForEventLogging-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.GetAssembly.ToUseForEventLogging(System.Reflection.Assembly)')
- [GetConsoleOutputLocation](#T-xyLOGIX-Core-Debug-GetConsoleOutputLocation 'xyLOGIX.Core.Debug.GetConsoleOutputLocation')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetConsoleOutputLocation-#cctor 'xyLOGIX.Core.Debug.GetConsoleOutputLocation.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetConsoleOutputLocation-SoleInstance 'xyLOGIX.Core.Debug.GetConsoleOutputLocation.SoleInstance')
- [GetDebugOutputLocation](#T-xyLOGIX-Core-Debug-GetDebugOutputLocation 'xyLOGIX.Core.Debug.GetDebugOutputLocation')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetDebugOutputLocation-#cctor 'xyLOGIX.Core.Debug.GetDebugOutputLocation.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetDebugOutputLocation-SoleInstance 'xyLOGIX.Core.Debug.GetDebugOutputLocation.SoleInstance')
- [GetEvent](#T-xyLOGIX-Core-Debug-GetEvent 'xyLOGIX.Core.Debug.GetEvent')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetEvent-#cctor 'xyLOGIX.Core.Debug.GetEvent.#cctor')
  - [SourceName()](#M-xyLOGIX-Core-Debug-GetEvent-SourceName 'xyLOGIX.Core.Debug.GetEvent.SourceName')
- [GetEventLogManager](#T-xyLOGIX-Core-Debug-GetEventLogManager 'xyLOGIX.Core.Debug.GetEventLogManager')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetEventLogManager-#cctor 'xyLOGIX.Core.Debug.GetEventLogManager.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetEventLogManager-SoleInstance 'xyLOGIX.Core.Debug.GetEventLogManager.SoleInstance')
- [GetLog](#T-xyLOGIX-Core-Debug-GetLog 'xyLOGIX.Core.Debug.GetLog')
  - [FileName](#F-xyLOGIX-Core-Debug-GetLog-FileName 'xyLOGIX.Core.Debug.GetLog.FileName')
  - [FileFolder](#P-xyLOGIX-Core-Debug-GetLog-FileFolder 'xyLOGIX.Core.Debug.GetLog.FileFolder')
  - [FilePath](#P-xyLOGIX-Core-Debug-GetLog-FilePath 'xyLOGIX.Core.Debug.GetLog.FilePath')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLog-#cctor 'xyLOGIX.Core.Debug.GetLog.#cctor')
- [GetLoggingBackend](#T-xyLOGIX-Core-Debug-GetLoggingBackend 'xyLOGIX.Core.Debug.GetLoggingBackend')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingBackend-#cctor 'xyLOGIX.Core.Debug.GetLoggingBackend.#cctor')
  - [For(type,relay)](#M-xyLOGIX-Core-Debug-GetLoggingBackend-For-xyLOGIX-Core-Debug-LoggingBackendType,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.GetLoggingBackend.For(xyLOGIX.Core.Debug.LoggingBackendType,log4net.Repository.ILoggerRepository)')
- [GetLoggingInfrastructure](#T-xyLOGIX-Core-Debug-GetLoggingInfrastructure 'xyLOGIX.Core.Debug.GetLoggingInfrastructure')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-#cctor 'xyLOGIX.Core.Debug.GetLoggingInfrastructure.#cctor')
  - [For(type)](#M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-For-xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.GetLoggingInfrastructure.For(xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [GetOutputLocation](#T-xyLOGIX-Core-Debug-GetOutputLocation 'xyLOGIX.Core.Debug.GetOutputLocation')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetOutputLocation-#cctor 'xyLOGIX.Core.Debug.GetOutputLocation.#cctor')
  - [OfType(type)](#M-xyLOGIX-Core-Debug-GetOutputLocation-OfType-xyLOGIX-Core-Debug-OutputLocationType- 'xyLOGIX.Core.Debug.GetOutputLocation.OfType(xyLOGIX.Core.Debug.OutputLocationType)')
- [GetOutputLocationProvider](#T-xyLOGIX-Core-Debug-GetOutputLocationProvider 'xyLOGIX.Core.Debug.GetOutputLocationProvider')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetOutputLocationProvider-#cctor 'xyLOGIX.Core.Debug.GetOutputLocationProvider.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetOutputLocationProvider-SoleInstance 'xyLOGIX.Core.Debug.GetOutputLocationProvider.SoleInstance')
- [GetPatternLayout](#T-xyLOGIX-Core-Debug-GetPatternLayout 'xyLOGIX.Core.Debug.GetPatternLayout')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetPatternLayout-#cctor 'xyLOGIX.Core.Debug.GetPatternLayout.#cctor')
  - [ForConversionPattern(conversionPattern)](#M-xyLOGIX-Core-Debug-GetPatternLayout-ForConversionPattern-System-String- 'xyLOGIX.Core.Debug.GetPatternLayout.ForConversionPattern(System.String)')
- [GetTraceOutputLocation](#T-xyLOGIX-Core-Debug-GetTraceOutputLocation 'xyLOGIX.Core.Debug.GetTraceOutputLocation')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetTraceOutputLocation-#cctor 'xyLOGIX.Core.Debug.GetTraceOutputLocation.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetTraceOutputLocation-SoleInstance 'xyLOGIX.Core.Debug.GetTraceOutputLocation.SoleInstance')
- [Has](#T-xyLOGIX-Core-Debug-Has 'xyLOGIX.Core.Debug.Has')
  - [IsWindowsGUI](#P-xyLOGIX-Core-Debug-Has-IsWindowsGUI 'xyLOGIX.Core.Debug.Has.IsWindowsGUI')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Has-#cctor 'xyLOGIX.Core.Debug.Has.#cctor')
  - [ConsoleWindow()](#M-xyLOGIX-Core-Debug-Has-ConsoleWindow 'xyLOGIX.Core.Debug.Has.ConsoleWindow')
  - [LoggingBeenSetUp()](#M-xyLOGIX-Core-Debug-Has-LoggingBeenSetUp 'xyLOGIX.Core.Debug.Has.LoggingBeenSetUp')
  - [WindowsGui(useEntryAssembly)](#M-xyLOGIX-Core-Debug-Has-WindowsGui-System-Boolean- 'xyLOGIX.Core.Debug.Has.WindowsGui(System.Boolean)')
- [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager')
  - [IsInitialized](#P-xyLOGIX-Core-Debug-IEventLogManager-IsInitialized 'xyLOGIX.Core.Debug.IEventLogManager.IsInitialized')
  - [Source](#P-xyLOGIX-Core-Debug-IEventLogManager-Source 'xyLOGIX.Core.Debug.IEventLogManager.Source')
  - [Type](#P-xyLOGIX-Core-Debug-IEventLogManager-Type 'xyLOGIX.Core.Debug.IEventLogManager.Type')
  - [Error(content)](#M-xyLOGIX-Core-Debug-IEventLogManager-Error-System-String- 'xyLOGIX.Core.Debug.IEventLogManager.Error(System.String)')
  - [Info(content)](#M-xyLOGIX-Core-Debug-IEventLogManager-Info-System-String- 'xyLOGIX.Core.Debug.IEventLogManager.Info(System.String)')
  - [Initialize(eventSourceName,logType)](#M-xyLOGIX-Core-Debug-IEventLogManager-Initialize-System-String,xyLOGIX-Core-Debug-EventLogType- 'xyLOGIX.Core.Debug.IEventLogManager.Initialize(System.String,xyLOGIX.Core.Debug.EventLogType)')
  - [Warn(content)](#M-xyLOGIX-Core-Debug-IEventLogManager-Warn-System-String- 'xyLOGIX.Core.Debug.IEventLogManager.Warn(System.String)')
- [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure')
  - [LogFileName](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFileName 'xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFileName')
  - [Type](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-Type 'xyLOGIX.Core.Debug.ILoggingInfrastructure.Type')
  - [DeleteLogIfExists(logFileName)](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-DeleteLogIfExists-System-String- 'xyLOGIX.Core.Debug.ILoggingInfrastructure.DeleteLogIfExists(System.String)')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.ILoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.ILoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole)](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean- 'xyLOGIX.Core.Debug.ILoggingInfrastructure.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean)')
- [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-IOutputLocation-MuteConsole 'xyLOGIX.Core.Debug.IOutputLocation.MuteConsole')
  - [Type](#P-xyLOGIX-Core-Debug-IOutputLocation-Type 'xyLOGIX.Core.Debug.IOutputLocation.Type')
  - [Write(value)](#M-xyLOGIX-Core-Debug-IOutputLocation-Write-System-Object- 'xyLOGIX.Core.Debug.IOutputLocation.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-IOutputLocation-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.IOutputLocation.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine-System-Object- 'xyLOGIX.Core.Debug.IOutputLocation.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.IOutputLocation.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine 'xyLOGIX.Core.Debug.IOutputLocation.WriteLine')
- [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsole 'xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole')
  - [AddLocation(location)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-AddLocation-xyLOGIX-Core-Debug-IOutputLocation- 'xyLOGIX.Core.Debug.IOutputLocationProvider.AddLocation(xyLOGIX.Core.Debug.IOutputLocation)')
  - [Clear()](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-Clear 'xyLOGIX.Core.Debug.IOutputLocationProvider.Clear')
  - [Write(value)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-Write-System-Object- 'xyLOGIX.Core.Debug.IOutputLocationProvider.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.IOutputLocationProvider.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine-System-Object- 'xyLOGIX.Core.Debug.IOutputLocationProvider.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.IOutputLocationProvider.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine 'xyLOGIX.Core.Debug.IOutputLocationProvider.WriteLine')
- [Initialize](#T-xyLOGIX-Core-Debug-Initialize 'xyLOGIX.Core.Debug.Initialize')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Initialize-#cctor 'xyLOGIX.Core.Debug.Initialize.#cctor')
  - [Logging(applicationName)](#M-xyLOGIX-Core-Debug-Initialize-Logging-System-String- 'xyLOGIX.Core.Debug.Initialize.Logging(System.String)')
- [IsLog](#T-xyLOGIX-Core-Debug-IsLog 'xyLOGIX.Core.Debug.IsLog')
  - [Initialized](#P-xyLOGIX-Core-Debug-IsLog-Initialized 'xyLOGIX.Core.Debug.IsLog.Initialized')
- [LogFileManager](#T-xyLOGIX-Core-Debug-LogFileManager 'xyLOGIX.Core.Debug.LogFileManager')
  - [InfrastructureType](#P-xyLOGIX-Core-Debug-LogFileManager-InfrastructureType 'xyLOGIX.Core.Debug.LogFileManager.InfrastructureType')
  - [LogFileName](#P-xyLOGIX-Core-Debug-LogFileManager-LogFileName 'xyLOGIX.Core.Debug.LogFileManager.LogFileName')
  - [LoggingInfrastructure](#P-xyLOGIX-Core-Debug-LogFileManager-LoggingInfrastructure 'xyLOGIX.Core.Debug.LogFileManager.LoggingInfrastructure')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LogFileManager-#cctor 'xyLOGIX.Core.Debug.LogFileManager.#cctor')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,infrastructureType)](#M-xyLOGIX-Core-Debug-LogFileManager-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.LogFileManager.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,xyLOGIX.Core.Debug.LoggingInfrastructureType)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole,infrastructureType)](#M-xyLOGIX-Core-Debug-LogFileManager-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean,xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.LogFileManager.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean,xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [LoggerManager](#T-xyLOGIX-Core-Debug-LoggerManager 'xyLOGIX.Core.Debug.LoggerManager')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggerManager-#cctor 'xyLOGIX.Core.Debug.LoggerManager.#cctor')
  - [GetRootLogger(loggerRepository)](#M-xyLOGIX-Core-Debug-LoggerManager-GetRootLogger-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.LoggerManager.GetRootLogger(log4net.Repository.ILoggerRepository)')
- [LoggerRepositoryManager](#T-xyLOGIX-Core-Debug-LoggerRepositoryManager 'xyLOGIX.Core.Debug.LoggerRepositoryManager')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggerRepositoryManager-#cctor 'xyLOGIX.Core.Debug.LoggerRepositoryManager.#cctor')
  - [GetHierarchyRepository()](#M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetHierarchyRepository 'xyLOGIX.Core.Debug.LoggerRepositoryManager.GetHierarchyRepository')
  - [GetLoggerRepository()](#M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetLoggerRepository 'xyLOGIX.Core.Debug.LoggerRepositoryManager.GetLoggerRepository')
- [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType')
  - [Console](#F-xyLOGIX-Core-Debug-LoggingBackendType-Console 'xyLOGIX.Core.Debug.LoggingBackendType.Console')
  - [Log4Net](#F-xyLOGIX-Core-Debug-LoggingBackendType-Log4Net 'xyLOGIX.Core.Debug.LoggingBackendType.Log4Net')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingBackendType-Unknown 'xyLOGIX.Core.Debug.LoggingBackendType.Unknown')
- [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType')
  - [Default](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Default 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Default')
  - [PostSharp](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-PostSharp 'xyLOGIX.Core.Debug.LoggingInfrastructureType.PostSharp')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Unknown 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Unknown')
- [MakeNewRollingFileAppender](#T-xyLOGIX-Core-Debug-MakeNewRollingFileAppender 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-#cctor 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.#cctor')
  - [AndHavingLogFileName(self,file)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndHavingLogFileName-log4net-Appender-RollingFileAppender,System-String- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.AndHavingLogFileName(log4net.Appender.RollingFileAppender,System.String)')
  - [AndMaximumNumberOfRollingBackups(self,maxSizeRollingBackups)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndMaximumNumberOfRollingBackups-log4net-Appender-RollingFileAppender,System-Int32- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.AndMaximumNumberOfRollingBackups(log4net.Appender.RollingFileAppender,System.Int32)')
  - [AndThatHasAStaticLogFileName(self,staticLogFileName)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndThatHasAStaticLogFileName-log4net-Appender-RollingFileAppender,System-Boolean- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.AndThatHasAStaticLogFileName(log4net.Appender.RollingFileAppender,System.Boolean)')
  - [ForRollingStyle(style)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-ForRollingStyle-log4net-Appender-RollingFileAppender-RollingMode- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.ForRollingStyle(log4net.Appender.RollingFileAppender.RollingMode)')
  - [ThatShouldAppendToFile(self,appendToFile)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-ThatShouldAppendToFile-log4net-Appender-RollingFileAppender,System-Boolean- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.ThatShouldAppendToFile(log4net.Appender.RollingFileAppender,System.Boolean)')
  - [WithMaximumFileSizeOf(self,maximumFileSize)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-WithMaximumFileSizeOf-log4net-Appender-RollingFileAppender,System-String- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.WithMaximumFileSizeOf(log4net.Appender.RollingFileAppender,System.String)')
  - [WithPatternLayout(self,layout)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-WithPatternLayout-log4net-Appender-RollingFileAppender,log4net-Layout-PatternLayout- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.WithPatternLayout(log4net.Appender.RollingFileAppender,log4net.Layout.PatternLayout)')
- [MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs')
  - [#ctor()](#M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#ctor 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs.#ctor')
  - [#ctor(newValue)](#M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#ctor-System-Boolean- 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs.#ctor(System.Boolean)')
  - [NewValue](#P-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-NewValue 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs.NewValue')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#cctor 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs.#cctor')
- [MuteConsoleChangedEventHandler](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventHandler 'xyLOGIX.Core.Debug.MuteConsoleChangedEventHandler')
- [ObjectDumper](#T-xyLOGIX-Core-Debug-ObjectDumper 'xyLOGIX.Core.Debug.ObjectDumper')
  - [#ctor(depth)](#M-xyLOGIX-Core-Debug-ObjectDumper-#ctor-System-Int32- 'xyLOGIX.Core.Debug.ObjectDumper.#ctor(System.Int32)')
  - [_currentStreamPosition](#F-xyLOGIX-Core-Debug-ObjectDumper-_currentStreamPosition 'xyLOGIX.Core.Debug.ObjectDumper._currentStreamPosition')
  - [_depth](#F-xyLOGIX-Core-Debug-ObjectDumper-_depth 'xyLOGIX.Core.Debug.ObjectDumper._depth')
  - [_indentLevel](#F-xyLOGIX-Core-Debug-ObjectDumper-_indentLevel 'xyLOGIX.Core.Debug.ObjectDumper._indentLevel')
  - [_writer](#F-xyLOGIX-Core-Debug-ObjectDumper-_writer 'xyLOGIX.Core.Debug.ObjectDumper._writer')
  - [OnTextWritten(e)](#M-xyLOGIX-Core-Debug-ObjectDumper-OnTextWritten-xyLOGIX-Core-Debug-TextWrittenEventArgs- 'xyLOGIX.Core.Debug.ObjectDumper.OnTextWritten(xyLOGIX.Core.Debug.TextWrittenEventArgs)')
  - [Write(element,depth)](#M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-Object,System-Int32- 'xyLOGIX.Core.Debug.ObjectDumper.Write(System.Object,System.Int32)')
  - [Write(element,depth,log)](#M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-Object,System-Int32,System-IO-TextWriter- 'xyLOGIX.Core.Debug.ObjectDumper.Write(System.Object,System.Int32,System.IO.TextWriter)')
  - [Write(s)](#M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-String- 'xyLOGIX.Core.Debug.ObjectDumper.Write(System.String)')
  - [WriteIndent()](#M-xyLOGIX-Core-Debug-ObjectDumper-WriteIndent 'xyLOGIX.Core.Debug.ObjectDumper.WriteIndent')
  - [WriteLine(element,depth)](#M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine-System-Object,System-Int32- 'xyLOGIX.Core.Debug.ObjectDumper.WriteLine(System.Object,System.Int32)')
  - [WriteLine(element,depth,log)](#M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine-System-Object,System-Int32,System-IO-TextWriter- 'xyLOGIX.Core.Debug.ObjectDumper.WriteLine(System.Object,System.Int32,System.IO.TextWriter)')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine 'xyLOGIX.Core.Debug.ObjectDumper.WriteLine')
  - [WriteObject(prefix,element)](#M-xyLOGIX-Core-Debug-ObjectDumper-WriteObject-System-String,System-Object- 'xyLOGIX.Core.Debug.ObjectDumper.WriteObject(System.String,System.Object)')
  - [WriteObjectToLines(prefix,element)](#M-xyLOGIX-Core-Debug-ObjectDumper-WriteObjectToLines-System-String,System-Object- 'xyLOGIX.Core.Debug.ObjectDumper.WriteObjectToLines(System.String,System.Object)')
  - [WriteTab()](#M-xyLOGIX-Core-Debug-ObjectDumper-WriteTab 'xyLOGIX.Core.Debug.ObjectDumper.WriteTab')
  - [WriteValue(o)](#M-xyLOGIX-Core-Debug-ObjectDumper-WriteValue-System-Object- 'xyLOGIX.Core.Debug.ObjectDumper.WriteValue(System.Object)')
- [OutputLocationBase](#T-xyLOGIX-Core-Debug-OutputLocationBase 'xyLOGIX.Core.Debug.OutputLocationBase')
  - [#ctor()](#M-xyLOGIX-Core-Debug-OutputLocationBase-#ctor 'xyLOGIX.Core.Debug.OutputLocationBase.#ctor')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole')
  - [Type](#P-xyLOGIX-Core-Debug-OutputLocationBase-Type 'xyLOGIX.Core.Debug.OutputLocationBase.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-OutputLocationBase-#cctor 'xyLOGIX.Core.Debug.OutputLocationBase.#cctor')
  - [Write(value)](#M-xyLOGIX-Core-Debug-OutputLocationBase-Write-System-Object- 'xyLOGIX.Core.Debug.OutputLocationBase.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-OutputLocationBase-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputLocationBase.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine-System-Object- 'xyLOGIX.Core.Debug.OutputLocationBase.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputLocationBase.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine 'xyLOGIX.Core.Debug.OutputLocationBase.WriteLine')
- [OutputLocationProvider](#T-xyLOGIX-Core-Debug-OutputLocationProvider 'xyLOGIX.Core.Debug.OutputLocationProvider')
  - [#ctor()](#M-xyLOGIX-Core-Debug-OutputLocationProvider-#ctor 'xyLOGIX.Core.Debug.OutputLocationProvider.#ctor')
  - [_muteConsole](#F-xyLOGIX-Core-Debug-OutputLocationProvider-_muteConsole 'xyLOGIX.Core.Debug.OutputLocationProvider._muteConsole')
  - [Instance](#P-xyLOGIX-Core-Debug-OutputLocationProvider-Instance 'xyLOGIX.Core.Debug.OutputLocationProvider.Instance')
  - [InternalOutputLocationList](#P-xyLOGIX-Core-Debug-OutputLocationProvider-InternalOutputLocationList 'xyLOGIX.Core.Debug.OutputLocationProvider.InternalOutputLocationList')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationProvider-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationProvider.MuteConsole')
  - [AddLocation(location)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-AddLocation-xyLOGIX-Core-Debug-IOutputLocation- 'xyLOGIX.Core.Debug.OutputLocationProvider.AddLocation(xyLOGIX.Core.Debug.IOutputLocation)')
  - [Clear()](#M-xyLOGIX-Core-Debug-OutputLocationProvider-Clear 'xyLOGIX.Core.Debug.OutputLocationProvider.Clear')
  - [InitializeInternalOutputLocationList()](#M-xyLOGIX-Core-Debug-OutputLocationProvider-InitializeInternalOutputLocationList 'xyLOGIX.Core.Debug.OutputLocationProvider.InitializeInternalOutputLocationList')
  - [OnMuteConsoleChanged(e)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-OnMuteConsoleChanged-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs- 'xyLOGIX.Core.Debug.OutputLocationProvider.OnMuteConsoleChanged(xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs)')
  - [Write(value)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-Write-System-Object- 'xyLOGIX.Core.Debug.OutputLocationProvider.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputLocationProvider.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine-System-Object- 'xyLOGIX.Core.Debug.OutputLocationProvider.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputLocationProvider.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine 'xyLOGIX.Core.Debug.OutputLocationProvider.WriteLine')
- [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType')
  - [Console](#F-xyLOGIX-Core-Debug-OutputLocationType-Console 'xyLOGIX.Core.Debug.OutputLocationType.Console')
  - [Debug](#F-xyLOGIX-Core-Debug-OutputLocationType-Debug 'xyLOGIX.Core.Debug.OutputLocationType.Debug')
  - [Trace](#F-xyLOGIX-Core-Debug-OutputLocationType-Trace 'xyLOGIX.Core.Debug.OutputLocationType.Trace')
  - [Unknown](#F-xyLOGIX-Core-Debug-OutputLocationType-Unknown 'xyLOGIX.Core.Debug.OutputLocationType.Unknown')
- [OutputMultiplexer](#T-xyLOGIX-Core-Debug-OutputMultiplexer 'xyLOGIX.Core.Debug.OutputMultiplexer')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-OutputMultiplexer-MuteConsole 'xyLOGIX.Core.Debug.OutputMultiplexer.MuteConsole')
  - [OutputLocationProvider](#P-xyLOGIX-Core-Debug-OutputMultiplexer-OutputLocationProvider 'xyLOGIX.Core.Debug.OutputMultiplexer.OutputLocationProvider')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-OutputMultiplexer-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputMultiplexer.Write(System.String,System.Object[])')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputMultiplexer.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine 'xyLOGIX.Core.Debug.OutputMultiplexer.WriteLine')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine-System-Object- 'xyLOGIX.Core.Debug.OutputMultiplexer.WriteLine(System.Object)')
- [PostSharpLoggingInfrastructure](#T-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure')
  - [#ctor()](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-#ctor 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.#ctor')
  - [_relay](#F-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-_relay 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure._relay')
  - [Type](#P-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-Type 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.Type')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
- [ProgramFlowHelper](#T-xyLOGIX-Core-Debug-ProgramFlowHelper 'xyLOGIX.Core.Debug.ProgramFlowHelper')
  - [#cctor()](#M-xyLOGIX-Core-Debug-ProgramFlowHelper-#cctor 'xyLOGIX.Core.Debug.ProgramFlowHelper.#cctor')
  - [EmergencyStop()](#M-xyLOGIX-Core-Debug-ProgramFlowHelper-EmergencyStop 'xyLOGIX.Core.Debug.ProgramFlowHelper.EmergencyStop')
  - [StartDebugger()](#M-xyLOGIX-Core-Debug-ProgramFlowHelper-StartDebugger 'xyLOGIX.Core.Debug.ProgramFlowHelper.StartDebugger')
- [Resources](#T-xyLOGIX-Core-Debug-Properties-Resources 'xyLOGIX.Core.Debug.Properties.Resources')
  - [Culture](#P-xyLOGIX-Core-Debug-Properties-Resources-Culture 'xyLOGIX.Core.Debug.Properties.Resources.Culture')
  - [Error_DepthMustBeNonNegative](#P-xyLOGIX-Core-Debug-Properties-Resources-Error_DepthMustBeNonNegative 'xyLOGIX.Core.Debug.Properties.Resources.Error_DepthMustBeNonNegative')
  - [Error_UnableFindAppConfigEntries](#P-xyLOGIX-Core-Debug-Properties-Resources-Error_UnableFindAppConfigEntries 'xyLOGIX.Core.Debug.Properties.Resources.Error_UnableFindAppConfigEntries')
  - [ExceptionMessageFormat](#P-xyLOGIX-Core-Debug-Properties-Resources-ExceptionMessageFormat 'xyLOGIX.Core.Debug.Properties.Resources.ExceptionMessageFormat')
  - [ResourceManager](#P-xyLOGIX-Core-Debug-Properties-Resources-ResourceManager 'xyLOGIX.Core.Debug.Properties.Resources.ResourceManager')
  - [TempExceptionFileMessage](#P-xyLOGIX-Core-Debug-Properties-Resources-TempExceptionFileMessage 'xyLOGIX.Core.Debug.Properties.Resources.TempExceptionFileMessage')
- [SecretStringExtensions](#T-xyLOGIX-Core-Debug-SecretStringExtensions 'xyLOGIX.Core.Debug.SecretStringExtensions')
  - [#cctor()](#M-xyLOGIX-Core-Debug-SecretStringExtensions-#cctor 'xyLOGIX.Core.Debug.SecretStringExtensions.#cctor')
  - [CollapseNewlinesToSpaces(value)](#M-xyLOGIX-Core-Debug-SecretStringExtensions-CollapseNewlinesToSpaces-System-String- 'xyLOGIX.Core.Debug.SecretStringExtensions.CollapseNewlinesToSpaces(System.String)')
- [ServiceFlowHelper](#T-xyLOGIX-Core-Debug-ServiceFlowHelper 'xyLOGIX.Core.Debug.ServiceFlowHelper')
  - [#cctor()](#M-xyLOGIX-Core-Debug-ServiceFlowHelper-#cctor 'xyLOGIX.Core.Debug.ServiceFlowHelper.#cctor')
  - [EmergencyStop(notificationAction)](#M-xyLOGIX-Core-Debug-ServiceFlowHelper-EmergencyStop-System-Action- 'xyLOGIX.Core.Debug.ServiceFlowHelper.EmergencyStop(System.Action)')
  - [OnDebuggerStartPending()](#M-xyLOGIX-Core-Debug-ServiceFlowHelper-OnDebuggerStartPending 'xyLOGIX.Core.Debug.ServiceFlowHelper.OnDebuggerStartPending')
  - [StartDebugger()](#M-xyLOGIX-Core-Debug-ServiceFlowHelper-StartDebugger 'xyLOGIX.Core.Debug.ServiceFlowHelper.StartDebugger')
- [SetLog](#T-xyLOGIX-Core-Debug-SetLog 'xyLOGIX.Core.Debug.SetLog')
  - [ApplicationName](#P-xyLOGIX-Core-Debug-SetLog-ApplicationName 'xyLOGIX.Core.Debug.SetLog.ApplicationName')
  - [#cctor()](#M-xyLOGIX-Core-Debug-SetLog-#cctor 'xyLOGIX.Core.Debug.SetLog.#cctor')
- [Setup](#T-xyLOGIX-Core-Debug-Setup 'xyLOGIX.Core.Debug.Setup')
  - [EventLogManager](#P-xyLOGIX-Core-Debug-Setup-EventLogManager 'xyLOGIX.Core.Debug.Setup.EventLogManager')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Setup-#cctor 'xyLOGIX.Core.Debug.Setup.#cctor')
  - [EventLogging(applicationName)](#M-xyLOGIX-Core-Debug-Setup-EventLogging-System-String- 'xyLOGIX.Core.Debug.Setup.EventLogging(System.String)')
- [Split](#T-xyLOGIX-Core-Debug-Split 'xyLOGIX.Core.Debug.Split')
  - [CommandLineRegex](#P-xyLOGIX-Core-Debug-Split-CommandLineRegex 'xyLOGIX.Core.Debug.Split.CommandLineRegex')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Split-#cctor 'xyLOGIX.Core.Debug.Split.#cctor')
  - [CommandLine(commandLine)](#M-xyLOGIX-Core-Debug-Split-CommandLine-System-String- 'xyLOGIX.Core.Debug.Split.CommandLine(System.String)')
- [TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs')
  - [#ctor(text,level)](#M-xyLOGIX-Core-Debug-TextEmittedEventArgs-#ctor-System-String,xyLOGIX-Core-Debug-DebugLevel- 'xyLOGIX.Core.Debug.TextEmittedEventArgs.#ctor(System.String,xyLOGIX.Core.Debug.DebugLevel)')
  - [Level](#P-xyLOGIX-Core-Debug-TextEmittedEventArgs-Level 'xyLOGIX.Core.Debug.TextEmittedEventArgs.Level')
  - [Text](#P-xyLOGIX-Core-Debug-TextEmittedEventArgs-Text 'xyLOGIX.Core.Debug.TextEmittedEventArgs.Text')
- [TextEmittedEventHandler](#T-xyLOGIX-Core-Debug-TextEmittedEventHandler 'xyLOGIX.Core.Debug.TextEmittedEventHandler')
- [TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs')
  - [#ctor(text)](#M-xyLOGIX-Core-Debug-TextWrittenEventArgs-#ctor-System-String- 'xyLOGIX.Core.Debug.TextWrittenEventArgs.#ctor(System.String)')
  - [Text](#P-xyLOGIX-Core-Debug-TextWrittenEventArgs-Text 'xyLOGIX.Core.Debug.TextWrittenEventArgs.Text')
- [TextWrittenEventHandler](#T-xyLOGIX-Core-Debug-TextWrittenEventHandler 'xyLOGIX.Core.Debug.TextWrittenEventHandler')
- [TraceOutputLocation](#T-xyLOGIX-Core-Debug-TraceOutputLocation 'xyLOGIX.Core.Debug.TraceOutputLocation')
  - [#ctor()](#M-xyLOGIX-Core-Debug-TraceOutputLocation-#ctor 'xyLOGIX.Core.Debug.TraceOutputLocation.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-TraceOutputLocation-Instance 'xyLOGIX.Core.Debug.TraceOutputLocation.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-TraceOutputLocation-Type 'xyLOGIX.Core.Debug.TraceOutputLocation.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-TraceOutputLocation-#cctor 'xyLOGIX.Core.Debug.TraceOutputLocation.#cctor')
  - [Write(value)](#M-xyLOGIX-Core-Debug-TraceOutputLocation-Write-System-Object- 'xyLOGIX.Core.Debug.TraceOutputLocation.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-TraceOutputLocation-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.TraceOutputLocation.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine-System-Object- 'xyLOGIX.Core.Debug.TraceOutputLocation.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.TraceOutputLocation.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine 'xyLOGIX.Core.Debug.TraceOutputLocation.WriteLine')
- [Validate](#T-xyLOGIX-Core-Debug-Validate 'xyLOGIX.Core.Debug.Validate')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Validate-#cctor 'xyLOGIX.Core.Debug.Validate.#cctor')
  - [LoggingInfrastructureType(type)](#M-xyLOGIX-Core-Debug-Validate-LoggingInfrastructureType-xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.Validate.LoggingInfrastructureType(xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [VerbosityChangedEventArgs](#T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs')
  - [#ctor(oldValue,newValue)](#M-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-#ctor-System-Int32,System-Int32- 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs.#ctor(System.Int32,System.Int32)')
  - [NewValue](#P-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-NewValue 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs.NewValue')
  - [OldValue](#P-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-OldValue 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs.OldValue')
- [VerbosityChangedEventHandler](#T-xyLOGIX-Core-Debug-VerbosityChangedEventHandler 'xyLOGIX.Core.Debug.VerbosityChangedEventHandler')

<a name='T-xyLOGIX-Core-Debug-Activate'></a>
## Activate `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to activate functionality,
such as logging.

<a name='M-xyLOGIX-Core-Debug-Activate-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Activate](#T-xyLOGIX-Core-Debug-Activate 'xyLOGIX.Core.Debug.Activate') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Activate-LoggingForLogFileName-System-String,log4net-Repository-ILoggerRepository-'></a>
### LoggingForLogFileName(logFileName,repository) `method`

##### Summary

Sets up logging programmatically (as opposed to using a
`app.config` file), using the specified `logFileName`
for the log and perhaps the provided log file `repository`
(say, serving as a relay to PostSharp).

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')
containing the fully-qualified pathname of the log file that is to be written. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object
that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository')
interface that plays the role of the `Hierarchy` object that is configured
for logging. |

<a name='T-xyLOGIX-Core-Debug-AppDomainFriendlyNames'></a>
## AppDomainFriendlyNames `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') constants that contain
standardized friendly names for application domains.

<a name='F-xyLOGIX-Core-Debug-AppDomainFriendlyNames-LINQPad'></a>
### LINQPad `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the friendly name of
the `AppDomain` for LINQPad.

<a name='M-xyLOGIX-Core-Debug-AppDomainFriendlyNames-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [AppDomainFriendlyNames](#T-xyLOGIX-Core-Debug-AppDomainFriendlyNames 'xyLOGIX.Core.Debug.AppDomainFriendlyNames') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-CommandLineParameter'></a>
## CommandLineParameter `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Values for command-line parameters.

<a name='F-xyLOGIX-Core-Debug-CommandLineParameter-HaltOnException'></a>
### HaltOnException `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the text of the
`Halt On Exception` command-line flag, which, if present, will force us to
call the [StartDebugger](#M-xyLOGIX-Core-Debug-ProgramFlowHelper-StartDebugger 'xyLOGIX.Core.Debug.ProgramFlowHelper.StartDebugger')
method when an exception is thrown.

<a name='T-xyLOGIX-Core-Debug-Compute'></a>
## Compute `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods for performing mathematical
computations.

<a name='M-xyLOGIX-Core-Debug-Compute-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Compute](#T-xyLOGIX-Core-Debug-Compute 'xyLOGIX.Core.Debug.Compute') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Compute-ZeroFloor-System-Int32-'></a>
### ZeroFloor(value) `method`

##### Summary

Computes the zero floor.  Meaning, if the specified
`value` is negative, then this method returns zero.



If the specified `value` is zero or greater, then this method
is the identity.

##### Returns

Zero if the specified `value` is negative;
otherwise, if the specified `value` is zero or greater, then
the method is the identity map.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Input value. |

<a name='T-xyLOGIX-Core-Debug-ConsoleOutputLocation'></a>
## ConsoleOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Writes debugging output to the standard output of the application
and/or a console window, if present.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, protected constructor to prohibit direct allocation of the
[ConsoleOutputLocation](#T-xyLOGIX-Core-Debug-ConsoleOutputLocation 'xyLOGIX.Core.Debug.ConsoleOutputLocation') class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-ConsoleOutputLocation-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the standard output of the application and/or a
console window, if present.

<a name='P-xyLOGIX-Core-Debug-ConsoleOutputLocation-Type'></a>
### Type `property`

##### Summary

Gets one of the
[OutputLocationType](#T-xyLOGIX-Core-Debug-Constants-OutputLocationType 'xyLOGIX.Core.Debug.Constants.OutputLocationType') enumeration
values
that indicates the final base of text strings that are fed to this
location.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, static constructor to prohibit direct allocation of
[ConsoleOutputLocation](#T-xyLOGIX-Core-Debug-ConsoleOutputLocation 'xyLOGIX.Core.Debug.ConsoleOutputLocation') class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the
standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to
the standard output stream using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by
the current line terminator, to the standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects,
followed by the current line terminator, to the standard output stream using
the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the standard output stream.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-DebugFileAndFolderHelper'></a>
## DebugFileAndFolderHelper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to work with files and folders in a robust way.

##### Remarks

These methods are here in order to assist applications in working
with log files and prepping for application startup and first-time use.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [DebugFileAndFolderHelper](#T-xyLOGIX-Core-Debug-DebugFileAndFolderHelper 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

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
| directoryPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) Path to the folder that you want to
create. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the required parameter,
`directoryPath`, is passed a blank or `null`
value. |

##### Remarks

If the folder specified by the `directoryPath`
parameter already exists on the filesystem, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-InsistPathExists-System-String-'></a>
### InsistPathExists() `method`

##### Summary

Checks to see if the specified file exists. If not, emits a "stop"
error message and returns false; otherwise, returns true.

##### Returns

This method returns `true` if the file with path
specified by the `fileName` parameter exists on the
filesystem in
the specified location or `false` if either the file is not
found or if it does exist but an operating system error occurs (such as
insufficient permissions) during the search.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFileWriteable-System-String-'></a>
### IsFileWriteable(path) `method`

##### Summary

Checks for write access for the given file.

##### Returns

This method returns `true` if write access is
allowed to the file with the specified `path`, otherwise
`false`.



The value `false` is also returned in the event that the
`path` parameter is a `null` value or blank.



The value `false` is also returned if an operating system
error or exception occurs while trying to look up the file's permissions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the full pathname for which
write permissions should be checked. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFolderWriteable-System-String-'></a>
### IsFolderWriteable(pathname) `method`

##### Summary

Checks for write access for the given folder.

##### Returns

This method returns `true` if write access is
allowed to the folder with the specified `pathname`,
otherwise `false`.



The value `false` is also returned in the event that the
`pathname` parameter is a `null` value or
blank.



The value `false` is also returned if an operating system
error or exception occurs while trying to look up the folder's permissions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the full pathname of the
folder whose permissions are to be checked. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsValidPath-System-String-'></a>
### IsValidPath(fullyQualifiedPath) `method`

##### Summary

Gets a value indicating whether the
`fullyQualifiedPath` is actually a valid path on the system,
according to operating-system-specific rules.

##### Returns

If the path provided in `fullyQualifiedPath` is a
valid path according to operating-system-specified rules, then this method
returns `true`. Otherwise, the return value is
`false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fullyQualifiedPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the path that
is to be validated. |

<a name='T-xyLOGIX-Core-Debug-DebugLevel'></a>
## DebugLevel `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Identifies the debug message level for a logging message.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Debug'></a>
### Debug `constants`

##### Summary

The logging message is for debugging purposes only.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Error'></a>
### Error `constants`

##### Summary

The logging message is for error purposes only.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Info'></a>
### Info `constants`

##### Summary

The logging message is for informational purposes only.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Output'></a>
### Output `constants`

##### Summary

The logging message is intended to show the output of running a child process.

##### Remarks

This debug level is to be reserved.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown logging level.

<a name='F-xyLOGIX-Core-Debug-DebugLevel-Warning'></a>
### Warning `constants`

##### Summary

The logging message is for warning purposes only.

<a name='T-xyLOGIX-Core-Debug-DebugOutputLocation'></a>
## DebugOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Writes debugging output to the window in Visual Studio
or whichever other debugger can listen to the output of the
[Debug](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Debug 'System.Diagnostics.Debug') class' methods.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, protected constructor to prohibit direct allocation of this
class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-DebugOutputLocation-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the window in Visual Studio or
whichever other debugger can listen to the output of the
[Debug](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Debug 'System.Diagnostics.Debug') class' methods.

<a name='P-xyLOGIX-Core-Debug-DebugOutputLocation-Type'></a>
### Type `property`

##### Summary

Gets one of the
[OutputLocationType](#T-xyLOGIX-Core-Debug-Constants-OutputLocationType 'xyLOGIX.Core.Debug.Constants.OutputLocationType') enumeration
values
that indicates the final base of text strings that are fed to this
location.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, static constructor to prohibit direct allocation of this
class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the
standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to
the standard output stream using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by
the current line terminator, to the standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects,
followed by the current line terminator, to the standard output stream using
the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the standard output stream.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-DebugUtils'></a>
## DebugUtils `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Helpers to manage the writing of content to the debugging log.

<a name='F-xyLOGIX-Core-Debug-DebugUtils-_verbosity'></a>
### _verbosity `constants`

##### Summary

The verbosity level.

##### Remarks

Typically, applications set this to 1.

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

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ExceptionLogPathname'></a>
### ExceptionLogPathname `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the pathname of a file to
which error text is to be appended in the event where the `WriteLineCore`
method catches an exception.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-InfrastructureType'></a>
### InfrastructureType `property`

##### Summary

Gets or sets the depth down the call stack from which Exception
information should be obtained.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-IsLogging'></a>
### IsLogging `property`

##### Summary

Gets or sets a value that turns logging as a whole on or off.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-IsPostSharp'></a>
### IsPostSharp `property`

##### Summary

Gets a value that indicates whether PostSharp is in use as the
logging infrastructure.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-LogFileName'></a>
### LogFileName `property`

##### Summary

Users should set this property to the path to the log file, if
logging.

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

Gets or sets the verbosity level.

##### Remarks

Typically, applications set this to 1.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes a new static instance of
[DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils').

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-CanLaunchDebugger-System-Exception,System-Boolean-'></a>
### CanLaunchDebugger(exception,launchDebuggerConfigured) `method`

##### Summary

Determines whether the debugger can be launched from the
[LogException](#M-xyLOGIX-Core-Debug-DebugUtils-LogException 'xyLOGIX.Core.Debug.DebugUtils.LogException') method.

##### Returns

`true` if the debugger is to be launched;
`false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that
corresponds to the particular exception that has been caught. |
| launchDebuggerConfigured | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | `true` if the user has
specified that the debugger is to be launched when an exception is caught;
`false` otherwise.



The default value of this parameter is `true`. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-ClearTempExceptionLog'></a>
### ClearTempExceptionLog() `method`

##### Summary

Erases the file having the fully-qualified pathname specified by the value of
the [ExceptionLogPathname](#P-xyLOGIX-Core-Debug-DebugUtils-ExceptionLogPathname 'xyLOGIX.Core.Debug.DebugUtils.ExceptionLogPathname')
property, if it is already present on the file system.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-DumpCollection-System-Collections-ICollection-'></a>
### DumpCollection(collection) `method`

##### Summary

Dumps a collection to the debug log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [System.Collections.ICollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.ICollection 'System.Collections.ICollection') | Reference to an instance of an object that implements
the [ICollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.ICollection 'System.Collections.ICollection') interface. |

##### Remarks

If this method is passed a `null` for
`collection` , then it does nothing. Otherwise, the method
iterates over the `collection` and writes all of its elements
to the log, one on each line.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-EchoCommandLinkText-System-Object-'></a>
### EchoCommandLinkText(commandLink) `method`

##### Summary

Writes the text of the selected control-- which is supposed to be a
CommandLink -- to the log, while, at the same time, stripping out the text
"recommended", if present, in the control's caption.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| commandLink | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Reference to an instance of an object that
implements a Command Link. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the
`commandLink` parameter is a passed a null reference. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-FormatException-System-Exception-'></a>
### FormatException(e) `method`

##### Summary

Structures the text of an [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception'), a
reference to an instance of which is passed in the `e`
parameter, to be the error message on a line by itself, followed by the stack
trace lines on the subsequent lines.

##### Returns

String to be written to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Reference to a [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that should
be formatted and dumped to the log. |

##### Remarks

If a `null` reference is passed for
`e`, then this method returns the empty string.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-FormatExceptionAndWrite-System-Exception-'></a>
### FormatExceptionAndWrite(e) `method`

##### Summary

Takes the reference to an instance of
[Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that is passed in the `e`
parameter, formats it as a friendly error message along with its stack trace,
and then dumps the result to the error log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | A [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') whose information is to be
dumped. |

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

The string content of the `format` parameter is
left untouched if there are no `args`.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-LogEachLineIfMultiline-System-String,System-Action{xyLOGIX-Core-Debug-DebugLevel,System-String},xyLOGIX-Core-Debug-DebugLevel-'></a>
### LogEachLineIfMultiline(content,logMethod,level) `method`

##### Summary

Detects whether the `content` is multiline. If so,
then each line of content is logged separately, using the
`logMethod` supplied.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required. String containing the already-formatted
content to be logged. |
| logMethod | [System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String}') | (Required.) Delegate specifying the logging code that
is to be executed for each line of content. |
| level | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | A [DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel')
specifying the debugLevel of logging to utilize. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-LogException-System-Exception,System-Boolean-'></a>
### LogException(exception,launchDebugger) `method`

##### Summary

Logs the complete information about an exception to the log, under
the Error Level. Outputs the quote file and line number where the exception
occurred, as well as the message of the exception and its stack trace.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Reference to the [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to be
logged. |
| launchDebugger | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Optional.) Value indicating whether the launch and break the debugger (if one
is attached) when this method is called.



The default value of this parameter is `true`.



It is advisable to explicitly set this parameter to
`false` in most cases, especially when this method has the
likelihood of getting called often.



The value of this parameter is ignored, and no launch of the
attached debugger occurs, when `exception` is
[TypeInitializationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TypeInitializationException 'System.TypeInitializationException') or
[FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException'), which occur so frequently as
to not be useful. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-OnTextEmitted-xyLOGIX-Core-Debug-TextEmittedEventArgs-'></a>
### OnTextEmitted(e) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DebugUtils-TextEmitted 'xyLOGIX.Core.Debug.DebugUtils.TextEmitted') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.Core.Debug.TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs') | (Required.) A
[TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-Events-TextEmittedEventArgs 'xyLOGIX.Core.Debug.Events.TextEmittedEventArgs') that contains
the
event data. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-OnVerbosityChanged-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-'></a>
### OnVerbosityChanged() `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DebugUtils-VerbosityChanged 'xyLOGIX.Core.Debug.DebugUtils.VerbosityChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

The [](#E-xyLOGIX-Core-Debug-DebugUtils-VerbosityChanged 'xyLOGIX.Core.Debug.DebugUtils.VerbosityChanged') event
is raised whenever the value of the
[Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property is updated.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-OutputExceptionLoggingMessage-System-Exception,System-String-'></a>
### OutputExceptionLoggingMessage(exception,message) `method`

##### Summary

Actually performs the work of logging the specified
`exception` to the log, using the specified
`message`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of
[Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that identifies the exception that is being
logged. |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that
contains a formatted message that is to be written to the log file. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]-'></a>
### Write(debugLevel,format,args) `method`

##### Summary

Writes the content in `format` to the
`debugLevel` log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values that indicates
which
log (DEBUG, ERROR, INFO, WARN) where the content should be written. |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format
specifier for parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be
included in the `format` and written to the log. |

##### Remarks

If the `format` parameter is a blank or empty
string, then this method does nothing. If the `DEBUG` constant is not
defined, then this method assumes that the application was built in Release
mode. If this is so, then the method checks the value of the
[MuteDebugLevelIfReleaseMode](#P-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode') property. If
the property is set to true AND the `debugLevel` parameter is
set to [Debug](#T-xyLOGIX-Core-Debug-Constants-DebugLevel-Debug 'xyLOGIX.Core.Debug.Constants.DebugLevel.Debug') , then
this
method does nothing. This method does not add a newline character after writing
its content to the log.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### Write(debugLevel,content) `method`

##### Summary

Writes non-formatted content to the log using the
`debugLevel` specified. No line terminator is appended to the
output.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values that indicates
which
log (DEBUG, ERROR, INFO, WARN) where the content should be written. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) string containing the content to be written. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`debugLevel` parameter is not one of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values. |

##### Remarks

If the `content` is a blank or empty string, then
this method does nothing. This method's behavior is identical to that of
[WriteCore](#M-xyLOGIX-Core-Debug-DebugUtils-WriteCore 'xyLOGIX.Core.Debug.DebugUtils.WriteCore'), except that a newline
character is appended to the end of the content.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteCore-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteCore(debugLevel,content) `method`

##### Summary

Provides the implementation details of writing messages to the log.
No line terminator is added to the content written.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values that determine
what
logging debugLevel to utilize. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the content to be written
to the log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`debugLevel` parameter is not one of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values. |

##### Remarks

If the string passed in `content` is blank or
empty, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]-'></a>
### WriteLine(debugLevel,format,args) `method`

##### Summary

Writes the content in `format` to the
`debugLevel` log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values that indicates
which
log (DEBUG, ERROR, INFO, WARN) where the content should be written. |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format
specifier for parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be
included in the `format` and written to the log. |

##### Remarks

If the `format` parameter is a blank or empty
string, then this method does nothing. If the `DEBUG` constant is not
defined, then this method assumes that the application was built in Release
mode. If this is so, then the method checks the value of the
[MuteDebugLevelIfReleaseMode](#P-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode') property. If
the property is set to true AND the `debugLevel` parameter is
set to [Debug](#T-xyLOGIX-Core-Debug-Constants-DebugLevel-Debug 'xyLOGIX.Core.Debug.Constants.DebugLevel.Debug') , then
this
method does nothing. This method adds a newline character after writing its
content to the log.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,args) `method`

##### Summary

Works the same as the overload which takes a
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') as its first argument,
but
if the formatted content consists of several lines of content, then the lines
are split and logged separately, all under the
[Debug](#T-xyLOGIX-Core-Debug-Constants-DebugLevel-Debug 'xyLOGIX.Core.Debug.Constants.DebugLevel.Debug') debugLevel.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format
specifier for parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be
included in the `format` and written to the log. |

##### Remarks

This overload specifies that the
[Debug](#T-xyLOGIX-Core-Debug-Constants-DebugLevel-Debug 'xyLOGIX.Core.Debug.Constants.DebugLevel.Debug') logging
debugLevel is
to be utilized for each line.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteLine(debugLevel,content) `method`

##### Summary

Writes non-formatted content to the log using the
`debugLevel` specified, terminated by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values that indicates
which
log (DEBUG, ERROR, INFO, WARN) where the content should be written. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) string containing the content to be written. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`debugLevel` parameter is not one of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values. |

##### Remarks

If the `content` is a blank or empty string, then
this method does nothing. This method's behavior is identical to that of
[WriteCore](#M-xyLOGIX-Core-Debug-DebugUtils-WriteCore 'xyLOGIX.Core.Debug.DebugUtils.WriteCore'), except that a newline
character is appended to the end of the content.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLineCore-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteLineCore(debugLevel,content) `method`

##### Summary

Provides the implementation details of writing messages to the log,
one line at a time.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values that determine
what
logging debugLevel to utilize. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the content to be written
to the log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`debugLevel` parameter is not one of the
[DebugLevel](#T-xyLOGIX-Core-Debug-Constants-DebugLevel 'xyLOGIX.Core.Debug.Constants.DebugLevel') values. |

##### Remarks

If the string passed in `content` is blank or
empty, then this method does nothing.

<a name='T-xyLOGIX-Core-Debug-DebuggerDump'></a>
## DebuggerDump `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to send objects to the log by calling an extension method
called 'Dump', like in LINQpad.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [DebuggerDump](#T-xyLOGIX-Core-Debug-DebuggerDump 'xyLOGIX.Core.Debug.DebuggerDump') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object-'></a>
### Dump(element) `method`

##### Summary

Dumps the specified object, a reference to which is in the
`element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are
to be dumped. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `element`, is passed a `null`
value. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32-'></a>
### Dump(element,depth) `method`

##### Summary

Dumps the specified object, a reference to which is in the
`element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are
to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which
the object should be dumped. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `element`, is passed a `null`
value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is less than zero. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32,System-IO-TextWriter-'></a>
### Dump(element,depth,log) `method`

##### Summary

Dumps the specified object, a reference to which is in the
`element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are
to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which
the object should be dumped. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of
[TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is open on the target log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the either of the
required parameters, `element` or `log`,
are passed a `null` value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is less than zero. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object-'></a>
### DumpLines(element) `method`

##### Summary

Dumps the specified object, a reference to which is in the
`element` parameter, to the log, followed by a newline
character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are
to be dumped. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `element`, is passed a `null`
value. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32-'></a>
### DumpLines(element,depth) `method`

##### Summary

Dumps the specified object, a reference to which is in the
`element` parameter, to the log, followed by a newline
character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are
to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which
the object should be dumped. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `element`, is passed a `null`
value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is less than zero. |

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32,System-IO-TextWriter-'></a>
### DumpLines(element,depth,log) `method`

##### Summary

Dumps the specified object, a reference to which is in the
`element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are
to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which
the object should be dumped. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of
[TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is open on the target log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the either of the
required parameters, `element` or `log`,
are passed a `null` value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is less than zero. |

<a name='T-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure'></a>
## DefaultLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Default implementation details for the
[ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure').

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of
[DefaultLoggingInfrastructure](#T-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure') and returns a
reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This constructor is marked `protected`
due to the fact that this class is marked `abstract`.

<a name='F-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-_logFileName'></a>
### _logFileName `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of
the log file.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFileName'></a>
### LogFileName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname
of the log file of this application.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-Constants-LoggingInfrastructureType 'xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType') value
that corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [DefaultLoggingInfrastructure](#T-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-DeleteLogIfExists-System-String-'></a>
### DeleteLogIfExists(logFileName) `method`

##### Summary

Deletes the log file, if it exists.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified
pathname of a file to which the log is being written. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the
[File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the first
appender in the list of appenders that is of type
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the
appender is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the
[LogFileName](#P-Core-Debug-ILoggingInfrastructure-LogFileName 'Core.Debug.ILoggingInfrastructure.LogFileName') property.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write
out "DEBUG" messages to the log file when in the Release mode. Set to false if
all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with
the latest logging sent out by this instance. |
| configurationFileNamename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the
configuration file to be utilized for initializing log4net. If blank, the
system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the
display of logging messages to the console if a log file is being used. If a
log file is not used, then no logging at all will occur if this parameter is
set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the
`XMLConfigurator` object is used to configure logging.



Else, specify here the path to the log file to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose
value must be `0` or greater.



Indicates the verbosity level.



Higher values mean more verbose.



if the `verbosity` parameter is negative, it will be ignored.



The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')
containing a user-friendly display name of the application that is using this
logging library.



Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object
that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository')
interface. Supply a value for this parameter if your infrastructure is not
utilizing the default HierarchicalRepository. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-OnLogFileNameChanged'></a>
### OnLogFileNameChanged() `method`

##### Summary

Raises the
[](#E-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFileNameChanged 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileNameChanged')
event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the
[LogFileName](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFileName 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileName')
property is updated.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-PrepareLogFile-log4net-Repository-ILoggerRepository-'></a>
### PrepareLogFile(repository) `method`

##### Summary

Prepares the log file by ensuring that the containing folder is
writeable by the current user and by then, if specified to overwrite, deleting
the current log file.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object
that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository')
interface. Supply a value for this parameter if your infrastructure is not
utilizing the default HierarchicalRepository. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') class to
initialize its functionality.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any
logging statements that are set to the
[Debug](#T-xyLOGIX-Core-Debug-Constants-DebugLevel-Debug 'xyLOGIX.Core.Debug.Constants.DebugLevel.Debug') level. |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log
file; false to suppress. Usually used with the `consoleOnly`
parameter set to true. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to
write them both to the console and to the log. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose
value must be `0` or greater.



Indicates the verbosity level.



Higher values mean more verbose.



if the `verbosity` parameter is negative, it will be ignored.



The default value of this parameter is `1`. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all
console output. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-WriteTimestamp'></a>
### WriteTimestamp() `method`

##### Summary

Writes a date and time stamp to the top of the log file.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-Delete'></a>
## Delete `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to delete files and folders.

<a name='M-xyLOGIX-Core-Debug-Delete-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Delete](#T-xyLOGIX-Core-Debug-Delete 'xyLOGIX.Core.Debug.Delete') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Delete-FileIfExists-System-String-'></a>
### FileIfExists(pathname) `method`

##### Summary

Deletes the file having the specified `pathname`, if
it exists.

##### Returns

`true` if the file having the specified
`pathname` was found on the file system and successfully
deleted; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that
contains the fully-qualified pathname of the file that is to be deleted. |

##### Remarks

If the `pathname` parameter is blank, the
[Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, or `null`, then
this method returns `false`.



This method also returns `false` if the file having the specified
`pathname` does not already exist on the file system.

<a name='M-xyLOGIX-Core-Debug-Delete-LogFile-System-String-'></a>
### LogFile(pathname) `method`

##### Summary

Deletes a log file having the specified `pathname`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the fully-qualified pathname
of the file that is to be deleted. |

##### Remarks

If the `pathname` parameter is blank or
`null`, then this method does nothing.



This method also takes no action if the file having the specified
`pathname` does not already exist on the file system.

<a name='T-xyLOGIX-Core-Debug-EmergencyStopPendingEventHandler'></a>
## EmergencyStopPendingEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `EmergencyStopPending` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.EmergencyStopPendingEventHandler](#T-T-xyLOGIX-Core-Debug-EmergencyStopPendingEventHandler 'T:xyLOGIX.Core.Debug.EmergencyStopPendingEventHandler') | A [CancelEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs 'System.ComponentModel.CancelEventArgs') that
contains the event data.



Set the [Cancel](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs.Cancel 'System.ComponentModel.CancelEventArgs.Cancel') property
to `true` to stop the pending operation. |

##### Remarks

This delegate merely specifies the signature of all methods that
handle the `EmergencyStopPending` event.

<a name='T-xyLOGIX-Core-Debug-EventLogManager'></a>
## EventLogManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Class to manage access to the event log.

<a name='M-xyLOGIX-Core-Debug-EventLogManager-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, protected constructor to prohibit direct allocation of this
class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that
implements the [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface
that
manages our access to the Windows System Event Logs.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-IsInitialized'></a>
### IsInitialized `property`

##### Summary

Gets a value indicating whether this object has been properly
initialized.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-Source'></a>
### Source `property`

##### Summary

Gets or sets the quote of events. Typically, this is the name of the
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

<a name='M-xyLOGIX-Core-Debug-EventLogManager-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, static constructor to prohibit direct allocation of this
class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Error-System-String-'></a>
### Error(content) `method`

##### Summary

Sends an Error event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The
content of
the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String specifying the content of the event log message. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Info-System-String-'></a>
### Info(content) `method`

##### Summary

Sends an Info event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The
content of
the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String specifying the content of the event
log message. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Initialize-System-String,xyLOGIX-Core-Debug-EventLogType-'></a>
### Initialize(eventSourceName,logType) `method`

##### Summary

Initializes event logging for your application.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name of the
application that will be sending events. |
| logType | [xyLOGIX.Core.Debug.EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') | (Required.) One of the
[EventLogType](#T-xyLOGIX-Core-Debug-Constants-EventLogType 'xyLOGIX.Core.Debug.Constants.EventLogType') values that
specifies the
type of log to send events to. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Warn-System-String-'></a>
### Warn(content) `method`

##### Summary

Sends a Warning event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The
content of
the logging message is specified by the `content` parameter.

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

<a name='T-xyLOGIX-Core-Debug-ExceptionExtensions'></a>
## ExceptionExtensions `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static extension methods in order to facilitate handling
exceptions.

<a name='M-xyLOGIX-Core-Debug-ExceptionExtensions-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [ExceptionExtensions](#T-xyLOGIX-Core-Debug-ExceptionExtensions 'xyLOGIX.Core.Debug.ExceptionExtensions') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-ExceptionExtensions-IsAnyOf-System-Exception,System-Type[]-'></a>
### IsAnyOf(exception,types) `method`

##### Summary

Determines whether the [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') of the specified
`exception` matches any of the specified
`types`.

##### Returns

`true` if at least one of the entry(ies) in the
`types` array matches the type of the specified
`exception`; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that
is the exception whose type is to be checked. |
| types | [System.Type[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type[] 'System.Type[]') | (Required.) One or more [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type')
value(s) that are to be compared. |

<a name='M-xyLOGIX-Core-Debug-ExceptionExtensions-LogAllExceptions-System-Collections-Generic-IEnumerable{System-Exception}-'></a>
### LogAllExceptions(exceptions) `method`

##### Summary

Iterates through the specified collection of
`exceptions` and logs each one, including its inner
exception, if any, by calling the
[LogException](#M-xyLOGIX-Core-Debug-DebugUtils-LogException 'xyLOGIX.Core.Debug.DebugUtils.LogException') method.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exceptions | [System.Collections.Generic.IEnumerable{System.Exception}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Exception}') | (Required.) A collection of references to instances
of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that represents the exception(s) to be
logged. |

##### Remarks

If the `exceptions` parameter is passed a
`null` reference, or is the empty set, then the method does
nothing.



If any element of the `exceptions` collection is
`null`, then it is skipped.

<a name='T-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs'></a>
## ExceptionLoggedEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `ExceptionLogged` event handlers.

<a name='M-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs-#ctor-System-Exception-'></a>
### #ctor(exception) `constructor`

##### Summary

Constructs a new instance of
[ExceptionLoggedEventArgs](#T-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs') and returns a
reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of the
[Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that was logged. |

<a name='P-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs-Exception'></a>
### Exception `property`

##### Summary

Gets or sets a reference to an instance of the
[Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that was logged.

<a name='T-xyLOGIX-Core-Debug-ExceptionLoggedEventHandler'></a>
## ExceptionLoggedEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `ExceptionLogged` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.ExceptionLoggedEventHandler](#T-T-xyLOGIX-Core-Debug-ExceptionLoggedEventHandler 'T:xyLOGIX.Core.Debug.ExceptionLoggedEventHandler') | A [ExceptionLoggedEventArgs](#T-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs')
that contains the event data. |

##### Remarks

This delegate merely specifies the signature of all methods that
handle the `ExceptionLogged` event.

<a name='T-xyLOGIX-Core-Debug-FileAppenderConfigurator'></a>
## FileAppenderConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods for configurating log4net's FileAppender

<a name='M-xyLOGIX-Core-Debug-FileAppenderConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [FileAppenderConfigurator](#T-xyLOGIX-Core-Debug-FileAppenderConfigurator 'xyLOGIX.Core.Debug.FileAppenderConfigurator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

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
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the instance of the object
referenced by `appender` is `null`. |

<a name='T-xyLOGIX-Core-Debug-FileAppenderManager'></a>
## FileAppenderManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods to access instances of objects of type
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [FileAppenderManager](#T-xyLOGIX-Core-Debug-FileAppenderManager 'xyLOGIX.Core.Debug.FileAppenderManager') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-GetAppenderByName-System-String-'></a>
### GetAppenderByName(name) `method`

##### Summary

Attempts to obtain a reference to an instance of
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') that is configured under a
certain name in the application configuration file.

##### Returns

If a suitable configuration file entry is found, this method returns
a [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') instance that corresponds to
the entry; otherwise, `null` is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name under which the
appender is configured in the application configuration file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the required parameter,
`name`, is passed a blank or `null` string
for a value. |

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstAppender-log4net-Repository-ILoggerRepository-'></a>
### GetFirstAppender(loggerRepository) `method`

##### Summary

If the root logger's appenders list contains appenders, returns a
reference to the first one in the list.

##### Returns

Reference to an instance of
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') , or `null` if
not found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') |  |

##### Remarks

If the `loggerRepository` parameter is passed a
`null` value, then this method attempts to obtain the root
logger object and then obtain the first
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') configured on the root logger
repository. If a suitable appender can still not be located, then the return
value of this method is `null`.

<a name='T-xyLOGIX-Core-Debug-GetAssembly'></a>
## GetAssembly `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to get information on .NET
assemblies.

<a name='M-xyLOGIX-Core-Debug-GetAssembly-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetAssembly](#T-xyLOGIX-Core-Debug-GetAssembly 'xyLOGIX.Core.Debug.GetAssembly') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetAssembly-Pathname-System-Reflection-Assembly-'></a>
### Pathname(assembly) `method`

##### Summary

Obtains the fully-qualified pathname of the specified
`assembly`.

##### Returns

If successful, the fully-qualified pathname of the specified
`assembly`; the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value if
it could not be obtained, or if the argument of the
`assembly` parameter is a `null` reference.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of
[Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') for which to obtain the
fully-qualified pathname. |

<a name='M-xyLOGIX-Core-Debug-GetAssembly-ToUseForEventLogging-System-Reflection-Assembly-'></a>
### ToUseForEventLogging() `method`

##### Summary

Attempts to obtain a reference to an instance of the
[Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that should be used for the
application event logging quote.

##### Returns

If successful, a reference to an instance of the
[Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that should be used for the
application event logging quote; `null` otherwise.

##### Parameters

This method has no parameters.

##### Remarks

To find the assembly to use as a quote for event logging, this
method first attempts to locate the assembly containing the application's
entry-point, and use that.



Failing that, the assembly that is currently executing is tried.



Failing that, then the assembly that called this method is used.

<a name='T-xyLOGIX-Core-Debug-GetConsoleOutputLocation'></a>
## GetConsoleOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the standard output of the application and/or a
console window, if present.

<a name='M-xyLOGIX-Core-Debug-GetConsoleOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetConsoleOutputLocation](#T-xyLOGIX-Core-Debug-GetConsoleOutputLocation 'xyLOGIX.Core.Debug.GetConsoleOutputLocation') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetConsoleOutputLocation-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the
[IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface, and returns a
reference to it.

##### Returns

Reference to the one, and only, instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the standard output of the application and/or a
console window, if present.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetDebugOutputLocation'></a>
## GetDebugOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the window in Visual Studio or
whichever other debugger can listen to the output of the
[Debug](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Debug 'System.Diagnostics.Debug') class' methods.

<a name='M-xyLOGIX-Core-Debug-GetDebugOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetDebugOutputLocation](#T-xyLOGIX-Core-Debug-GetDebugOutputLocation 'xyLOGIX.Core.Debug.GetDebugOutputLocation') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetDebugOutputLocation-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the
[IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface, and returns a
reference to it.

##### Returns

Reference to the one, and only, instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the window in Visual Studio or
whichever other debugger can listen to the output of the
[Debug](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Debug 'System.Diagnostics.Debug') class' methods.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetEvent'></a>
## GetEvent `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods for interacting with the
Windows Event Log.

<a name='M-xyLOGIX-Core-Debug-GetEvent-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetEvent](#T-xyLOGIX-Core-Debug-GetEvent 'xyLOGIX.Core.Debug.GetEvent') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetEvent-SourceName'></a>
### SourceName() `method`

##### Summary

Attempts to obtain a user-friendly display name for the event-logging
quote, based on the name of the application that is calling this debug logging
library.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetEventLogManager'></a>
## GetEventLogManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that
implements the [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface
that
manages our access to the Windows System Event Logs.

<a name='M-xyLOGIX-Core-Debug-GetEventLogManager-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetEventLogManager](#T-xyLOGIX-Core-Debug-GetEventLogManager 'xyLOGIX.Core.Debug.GetEventLogManager') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetEventLogManager-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the
[IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface, and returns a
reference to it.

##### Returns

Reference to the one, and only, instance of the object that
implements the [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface
that
manages our access to the Windows System Event Logs.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetLog'></a>
## GetLog `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Gets data used for logging.

<a name='F-xyLOGIX-Core-Debug-GetLog-FileName'></a>
### FileName `constants`

##### Summary

String containing the pattern to use for the name of the log file.

<a name='P-xyLOGIX-Core-Debug-GetLog-FileFolder'></a>
### FileFolder `property`

##### Summary

Gets a string that contains the fully-qualified pathname of the
current user's temporary files folder.

<a name='P-xyLOGIX-Core-Debug-GetLog-FilePath'></a>
### FilePath `property`

##### Summary

Gets a string containing the fully-qualified pathname to use for the
current log file.

<a name='M-xyLOGIX-Core-Debug-GetLog-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetLog](#T-xyLOGIX-Core-Debug-GetLog 'xyLOGIX.Core.Debug.GetLog') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='T-xyLOGIX-Core-Debug-GetLoggingBackend'></a>
## GetLoggingBackend `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Obtains a reference to a new instance of the
[LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that corresponds
to the specified
[LoggingBackendType](#T-xyLOGIX-Core-Debug-Constants-LoggingBackendType 'xyLOGIX.Core.Debug.Constants.LoggingBackendType')
enumeration value.

<a name='M-xyLOGIX-Core-Debug-GetLoggingBackend-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetLoggingBackend](#T-xyLOGIX-Core-Debug-GetLoggingBackend 'xyLOGIX.Core.Debug.GetLoggingBackend') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetLoggingBackend-For-xyLOGIX-Core-Debug-LoggingBackendType,log4net-Repository-ILoggerRepository-'></a>
### For(type,relay) `method`

##### Summary

Obtains a reference to a new instance of the
[LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that corresponds
to the specified logging backend `type` and, if necessary,
`relay`.

##### Returns

Reference to a new instance of
[LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that corresponds
to the provided `type` and/or `relay`
values.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') | (Required.) The
[LoggingBackendType](#T-xyLOGIX-Core-Debug-Constants-LoggingBackendType 'xyLOGIX.Core.Debug.Constants.LoggingBackendType') enumeration
value
that explains which type of backend to get. |
| relay | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that
implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. |

<a name='T-xyLOGIX-Core-Debug-GetLoggingInfrastructure'></a>
## GetLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Creates instances of objects that implement the
[ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetLoggingInfrastructure](#T-xyLOGIX-Core-Debug-GetLoggingInfrastructure 'xyLOGIX.Core.Debug.GetLoggingInfrastructure') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-For-xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### For(type) `method`

##### Summary

Creates an instance of an object implementing the
[ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface which
corresponds to the value specified in `type`, and returns a
reference to it.

##### Returns

A reference to the instance of the object that implements the
[ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface which
corresponds to the value specified in `type`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | One of the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-Constants-LoggingInfrastructureType 'xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType') values
that
describes what type of object you want. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if there is no
corresponding concrete type defined that implements the
[ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface and which
corresponds to the value passed in the `type` parameter. |

##### Remarks

This method will throw an exception if there are no types implemented
that correspond to the value of `type`.

<a name='T-xyLOGIX-Core-Debug-GetOutputLocation'></a>
## GetOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Obtains references to instances of objects that implement the
[IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that change
depending
on the strategy desired.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetOutputLocation](#T-xyLOGIX-Core-Debug-GetOutputLocation 'xyLOGIX.Core.Debug.GetOutputLocation') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocation-OfType-xyLOGIX-Core-Debug-OutputLocationType-'></a>
### OfType(type) `method`

##### Summary

Obtains a reference to an instance of an object that implements the
[IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface which corresponds
to
the specified meeting `type`.

##### Returns

Reference to the instance of the object that implements the
[IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface which corresponds
to
the specific enumeration value that is specified for the argument of the
`type` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') | (Required.) One of the
[OutputLocationType](#T-xyLOGIX-Core-Debug-Constants-OutputLocationType 'xyLOGIX.Core.Debug.Constants.OutputLocationType') enumeration
values
that describes the type of output location to be created. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if there is no
corresponding concrete type defined that implements the
[IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface and which
corresponds
to the specific enumeration value that was passed for the argument of the
`type` parameter, if it is not supported. |

##### Remarks

This method will throw an exception if there are no types implemented
that correspond to the enumeration value passed for the argument of the
`type` parameter.

<a name='T-xyLOGIX-Core-Debug-GetOutputLocationProvider'></a>
## GetOutputLocationProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that
implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider')
interface.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocationProvider-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetOutputLocationProvider](#T-xyLOGIX-Core-Debug-GetOutputLocationProvider 'xyLOGIX.Core.Debug.GetOutputLocationProvider') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocationProvider-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the
[IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider') interface, and
returns a
reference to it.

##### Returns

Reference to the one, and only, instance of the object that
implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider')
interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetPatternLayout'></a>
## GetPatternLayout `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Creates instances of [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout')
that are initialized properly.

<a name='M-xyLOGIX-Core-Debug-GetPatternLayout-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetPatternLayout](#T-xyLOGIX-Core-Debug-GetPatternLayout 'xyLOGIX.Core.Debug.GetPatternLayout') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetPatternLayout-ForConversionPattern-System-String-'></a>
### ForConversionPattern(conversionPattern) `method`

##### Summary

Creates a new instance of
[PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') and initializes the
[ConversionPattern](#P-log4net-Layout-PatternLayout-ConversionPattern 'log4net.Layout.PatternLayout.ConversionPattern') property with
the specified `conversionPattern` string.

##### Returns

An activated [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') instance
that is initialized with the specified `conversionPattern`,
or `null` if an error occurred or if blank input was supplied
for the `conversionPattern` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| conversionPattern | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the conversion
pattern to utilize. |

<a name='T-xyLOGIX-Core-Debug-GetTraceOutputLocation'></a>
## GetTraceOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the window in Visual Studio or
whichever other debugger can listen to the output of the
[Trace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Trace 'System.Diagnostics.Trace') class' methods.

<a name='M-xyLOGIX-Core-Debug-GetTraceOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [GetTraceOutputLocation](#T-xyLOGIX-Core-Debug-GetTraceOutputLocation 'xyLOGIX.Core.Debug.GetTraceOutputLocation') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetTraceOutputLocation-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the
[IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface, and returns a
reference to it.

##### Returns

Reference to the one, and only, instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the window in Visual Studio or
whichever other debugger can listen to the output of the
[Trace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Trace 'System.Diagnostics.Trace') class' methods.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-Has'></a>
## Has `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to determine whether a console window
is
present.

<a name='P-xyLOGIX-Core-Debug-Has-IsWindowsGUI'></a>
### IsWindowsGUI `property`

##### Summary

Gets or sets a value that is initialized with a [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean')
that indicates whether the calling application is a Windows GUI app or a
console app.

##### Remarks

We use this property to avoid re-determining the nature of the current app if
the [WindowsGui](#M-xyLOGIX-Core-Debug-Has-WindowsGui 'xyLOGIX.Core.Debug.Has.WindowsGui') method is called more
than once.

<a name='M-xyLOGIX-Core-Debug-Has-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Has](#T-xyLOGIX-Core-Debug-Has 'xyLOGIX.Core.Debug.Has') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-Has-ConsoleWindow'></a>
### ConsoleWindow() `method`

##### Summary

Determines whether the application is currently running in a console
window.

##### Returns

`true` if the application is running in a console
window; `false` otherwise.

##### Parameters

This method has no parameters.

##### Remarks

This method first tries to get the value of the
[WindowHeight](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.WindowHeight 'System.Console.WindowHeight') property.  If this throws an
exception, we return `false` since we aren't running in a
console window.



If that check passes, then we return the negation of the return value of the
[WindowsGui](#M-xyLOGIX-Core-Debug-Has-WindowsGui 'xyLOGIX.Core.Debug.Has.WindowsGui') method.



This algorithm assures us we get an accurate response, i.e.,
`false`, from this method if the caller is not running in a
console and is NOT GUI-based; i.e., it is like a console app, but it is set to
`Windows Application` type in the 
window in Visual Studio, but it never creates a window (at least, not using WPF
or WinForms; this method cannot detect native Win32 P/Invoke calls to create a
main window).

<a name='M-xyLOGIX-Core-Debug-Has-LoggingBeenSetUp'></a>
### LoggingBeenSetUp() `method`

##### Summary

Determines whether logging has been configured.

##### Returns

`true` if a backend has been assigned to the value of
the
[DefaultBackend](#P-PostSharp-Patterns-Diagnostics-LoggingServices-DefaultBackend 'PostSharp.Patterns.Diagnostics.LoggingServices.DefaultBackend')
property besides the
[NullLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Null-NullLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Null.NullLoggingBackend')
.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-Has-WindowsGui-System-Boolean-'></a>
### WindowsGui(useEntryAssembly) `method`

##### Summary

Determines whether the calling assembly (or the entry assembly, if
`useEntryAssembly` is set to `true`, which
it is not by default) is a Windows GUI application written with either WPF or
WinForms.

##### Returns

A value that indicates whether the calling assembly (or the entry
assembly, if `useEntryAssembly` is set to
`true`, which it is not by default) is a Windows GUI
application written with either WPF or WinForms.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| useEntryAssembly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Optional.) Default is `false`
.  If `true`, uses the entry-point assembly of the application
to make its determination. Setting this parameter to `false`
means the calling assembly is used instead. |

##### Remarks

This method works by assessing whether the entry or calling assembly,
per the value of the `useEntryAssembly` parameter's argument,
references either WPF or WinForm system framework assemblies.

<a name='T-xyLOGIX-Core-Debug-IEventLogManager'></a>
## IEventLogManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed methods and properties of an object that
manages our access to the Windows System Event Log(s).

<a name='P-xyLOGIX-Core-Debug-IEventLogManager-IsInitialized'></a>
### IsInitialized `property`

##### Summary

Gets a value indicating whether this object has been properly
initialized.

<a name='P-xyLOGIX-Core-Debug-IEventLogManager-Source'></a>
### Source `property`

##### Summary

Gets or sets the quote of events. Typically, this is the name of the
application that is sending the events.

##### Remarks

This property must be set before logging events, otherwise an error
will occur.

<a name='P-xyLOGIX-Core-Debug-IEventLogManager-Type'></a>
### Type `property`

##### Summary

Gets or sets the type of log to which events are to be sent
(Application, System, Security, etc.).

##### Remarks

This property must be set before logging events, otherwise an error
will occur.

<a name='M-xyLOGIX-Core-Debug-IEventLogManager-Error-System-String-'></a>
### Error(content) `method`

##### Summary

Sends an Error event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The
content of
the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String specifying the content of the event log message. |

<a name='M-xyLOGIX-Core-Debug-IEventLogManager-Info-System-String-'></a>
### Info(content) `method`

##### Summary

Sends an Info event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The
content of
the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String specifying the content of the event
log message. |

<a name='M-xyLOGIX-Core-Debug-IEventLogManager-Initialize-System-String,xyLOGIX-Core-Debug-EventLogType-'></a>
### Initialize(eventSourceName,logType) `method`

##### Summary

Initializes event logging for your application.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name of the
application that will be sending events. |
| logType | [xyLOGIX.Core.Debug.EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') | (Required.) One of the
[EventLogType](#T-xyLOGIX-Core-Debug-Constants-EventLogType 'xyLOGIX.Core.Debug.Constants.EventLogType') values that
specifies the
type of log to send events to. |

<a name='M-xyLOGIX-Core-Debug-IEventLogManager-Warn-System-String-'></a>
### Warn(content) `method`

##### Summary

Sends a Warning event to the system event log pointed to by the
[Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and
[Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The
content of
the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String specifying the content of the event log message. |

<a name='T-xyLOGIX-Core-Debug-ILoggingInfrastructure'></a>
## ILoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the methods and properties of a custom object to which the
[LogFileManager](#T-xyLOGIX-Core-Debug-LogFileManager 'xyLOGIX.Core.Debug.LogFileManager') delegates the implementation
of its properties and methods.

<a name='P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFileName'></a>
### LogFileName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname
of the log file of this application.

<a name='P-xyLOGIX-Core-Debug-ILoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-Constants-LoggingInfrastructureType 'xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType') value
that
corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-DeleteLogIfExists-System-String-'></a>
### DeleteLogIfExists(logFileName) `method`

##### Summary

Deletes the log file, if it exists.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified
pathname of a file to which the log is being written. |

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the
[File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the first
appender in the list of appenders that is of type
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the
appender is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the
[LogFileName](#P-Core-Debug-ILoggingInfrastructure-LogFileName 'Core.Debug.ILoggingInfrastructure.LogFileName') property.

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write
out "DEBUG" messages to the log file when in the Release mode. Set to false if
all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with
the latest logging sent out by this instance. |
| configurationFileNamename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the
configuration file to be utilized for initializing log4net. If blank, the
system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the
display of logging messages to the console if a log file is being used. If a
log file is not used, then no logging at all will occur if this parameter is
set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the
`XMLConfigurator` object is used to configure logging.



Else, specify here the path to the log file to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose
value must be `0` or greater.



Indicates the verbosity level.



Higher values mean more verbose.



if the `verbosity` parameter is negative, it will be ignored.



The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')
containing a user-friendly display name of the application that is using this
logging library.



Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object
that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository')
interface. Supply a value for this parameter if your infrastructure is not
utilizing the default HierarchicalRepository. |

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') to initialize
its functionality.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any
logging statements that are set to [Debug](#F-DebugLevel-Debug 'DebugLevel.Debug'). |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log
file; false to suppress. Usually used with the `consoleOnly`
parameter set to `true`. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to
write them both to the console and to the log. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Zero to suppress every message; greater than zero to
echo every message. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all
console output. |

<a name='T-xyLOGIX-Core-Debug-IOutputLocation'></a>
## IOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed methods and properties of an object that
writes output logging lines to multiple destinations at the same time..

<a name='P-xyLOGIX-Core-Debug-IOutputLocation-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is
turned on or off.

<a name='P-xyLOGIX-Core-Debug-IOutputLocation-Type'></a>
### Type `property`

##### Summary

Gets one of the
[OutputLocationType](#T-xyLOGIX-Core-Debug-Constants-OutputLocationType 'xyLOGIX.Core.Debug.Constants.OutputLocationType') enumeration
values
that indicates the final base of text strings that are fed to this
location.

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the
standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to
the standard output stream using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by
the current line terminator, to the standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects,
followed by the current line terminator, to the standard output stream using
the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the standard output stream.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-IOutputLocationProvider'></a>
## IOutputLocationProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed methods and properties of an object that
writes output logging lines to multiple destinations at the same time..

<a name='P-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is
turned on or off.

##### Remarks

This property raises the
[](#E-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsoleChanged 'xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsoleChanged')
event
when its value is updated.

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-AddLocation-xyLOGIX-Core-Debug-IOutputLocation-'></a>
### AddLocation(location) `method`

##### Summary

Adds the specified output `location` to the
internal list maintained by this object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [xyLOGIX.Core.Debug.IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') | (Required.) Reference to an instance of an object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface. |

##### Remarks

If the specified `location` has already been added,
then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-Clear'></a>
### Clear() `method`

##### Summary

Clears the internal list of output locations.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the
standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to
the standard output stream using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by
the current line terminator, to the standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects,
followed by the current line terminator, to the standard output stream using
the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the standard output stream.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-Initialize'></a>
## Initialize `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to initialize data.

<a name='M-xyLOGIX-Core-Debug-Initialize-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [Initialize](#T-xyLOGIX-Core-Debug-Initialize 'xyLOGIX.Core.Debug.Initialize') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Initialize-Logging-System-String-'></a>
### Logging(applicationName) `method`

##### Summary

Called once per application to initialize the logging subsystem.

##### Returns

`true` if the initialization was successful;
`false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name to be
used for the application in the log file's pathname.



All whitespace will be removed. |

##### Remarks

This method is to be utilized if you aren't utilizing a logging
framework, such as `log4net` or `PostSharp` etc.

<a name='T-xyLOGIX-Core-Debug-IsLog'></a>
## IsLog `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods and properties to determine whether
facts
about logs or logging are true.

<a name='P-xyLOGIX-Core-Debug-IsLog-Initialized'></a>
### Initialized `property`

##### Summary

Gets a value that determines whether the logging system has been
initialized.

##### Returns

`true` if the logging system has been initialized;
`false` otherwise.

<a name='T-xyLOGIX-Core-Debug-LogFileManager'></a>
## LogFileManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to be used to manage the application log.

<a name='P-xyLOGIX-Core-Debug-LogFileManager-InfrastructureType'></a>
### InfrastructureType `property`

##### Summary

Gets or sets the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-Constants-LoggingInfrastructureType 'xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType') value
that
represents the type of infrastructure currently in use by this
[LogFileManager](#T-xyLOGIX-Core-Debug-LogFileManager 'xyLOGIX.Core.Debug.LogFileManager').

<a name='P-xyLOGIX-Core-Debug-LogFileManager-LogFileName'></a>
### LogFileName `property`

##### Summary

Gets the full path and filename to the log file for this application.

##### Remarks

This property should only be called after the
[InitializeLogging](#M-xyLOGIX-Core-Debug-LogFileManager-InitializeLogging 'xyLOGIX.Core.Debug.LogFileManager.InitializeLogging') method has
been
called.

<a name='P-xyLOGIX-Core-Debug-LogFileManager-LoggingInfrastructure'></a>
### LoggingInfrastructure `property`

##### Summary

Gets a reference to an instance of an object that implements the
[ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface that
corresponds to the value of the
[InfrastructureType](#P-xyLOGIX-Core-Debug-LogFileManager-InfrastructureType 'xyLOGIX.Core.Debug.LogFileManager.InfrastructureType') property.

<a name='M-xyLOGIX-Core-Debug-LogFileManager-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [LogFileManager](#T-xyLOGIX-Core-Debug-LogFileManager 'xyLOGIX.Core.Debug.LogFileManager') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LogFileManager-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,infrastructureType) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write
out "DEBUG" messages to the log file when in the Release mode. Set to false if
all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with
the latest logging sent out by this instance. |
| configurationFileNamename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the
configuration file to be utilized for initializing log4net. If blank, the
system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the
display of logging messages to the console if a log file is being used. If a
log file is not used, then no logging at all will occur if this parameter is
set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the
`XMLConfigurator` object is used to configure logging.



Else, specify here the path to the log file to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose
value must be `0` or greater.



Indicates the verbosity level.



Higher values mean more verbose.



if the `verbosity` parameter is negative, it will be ignored.



The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')
containing a user-friendly display name of the application that is using this
logging library.



Leave blank to use the default value. |
| infrastructureType | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Optional.) One of the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-Constants-LoggingInfrastructureType 'xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType') values
that
indicates what type of logging infrastructure is to be utilized (default or
PostSharp, for example). |

<a name='M-xyLOGIX-Core-Debug-LogFileManager-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean,xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole,infrastructureType) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') to initialize
its functionality.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any
logging statements that are set to [Debug](#F-DebugLevel-Debug 'DebugLevel.Debug'). |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log
file; false to suppress. Usually used with the `consoleOnly`
parameter set to `true`. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to
write them both to the console and to the log. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose
value must be `0` or greater.



Indicates the verbosity level.



Higher values mean more verbose.



if the `verbosity` parameter is negative, it will be ignored.



The default value of this parameter is `1`. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all
console output. |
| infrastructureType | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Optional.) One of the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-Constants-LoggingInfrastructureType 'xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType') values
that
indicates what type of logging infrastructure is to be utilized (default or
PostSharp). |

<a name='T-xyLOGIX-Core-Debug-LoggerManager'></a>
## LoggerManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods to access objects of type
[Logger](#T-log4net-Hierarchy-Repository-Logger 'log4net.Hierarchy.Repository.Logger') from log4net.

<a name='M-xyLOGIX-Core-Debug-LoggerManager-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [LoggerManager](#T-xyLOGIX-Core-Debug-LoggerManager 'xyLOGIX.Core.Debug.LoggerManager') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggerManager-GetRootLogger-log4net-Repository-ILoggerRepository-'></a>
### GetRootLogger(loggerRepository) `method`

##### Summary

Gets a reference to the default logger repository's root instance of
[Logger](#T-log4net-Hierarchy-Repository-Logger 'log4net.Hierarchy.Repository.Logger').

##### Returns

Reference to the default logger repository's root instance of
[Logger](#T-log4net-Hierarchy-Repository-Logger 'log4net.Hierarchy.Repository.Logger') , or null if not found.

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

<a name='M-xyLOGIX-Core-Debug-LoggerRepositoryManager-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [LoggerRepositoryManager](#T-xyLOGIX-Core-Debug-LoggerRepositoryManager 'xyLOGIX.Core.Debug.LoggerRepositoryManager') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetHierarchyRepository'></a>
### GetHierarchyRepository() `method`

##### Summary

Gets a reference to an instance of the log4net repository as an
reference to an object of type
[Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy').

##### Returns

Reference to an instance of a [](#I-ILoggerRepository 'ILoggerRepository') that
derives from [Hierarchy](#T-log4net-Repository-Hierarchy 'log4net.Repository.Hierarchy'), or null if no such
object has been found.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetLoggerRepository'></a>
### GetLoggerRepository() `method`

##### Summary

Wraps the [GetRepository](#M-log4net-LogManager-GetRepository 'log4net.LogManager.GetRepository') method.

##### Returns

Reference to an instance of an object that implements
[ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') , or null if such an object cannot be found.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-LoggingBackendType'></a>
## LoggingBackendType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Enumerated values that allow us to select from among the supported
logging backends.

##### Remarks

THis enumeration is only to be used when PostSharp is selected as the
logging infrastructure.

<a name='F-xyLOGIX-Core-Debug-LoggingBackendType-Console'></a>
### Console `constants`

##### Summary

The log messages are to be routed to the console.

<a name='F-xyLOGIX-Core-Debug-LoggingBackendType-Log4Net'></a>
### Log4Net `constants`

##### Summary

The log messages are to be sent to `log4net`.

<a name='F-xyLOGIX-Core-Debug-LoggingBackendType-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown logging backend.

<a name='T-xyLOGIX-Core-Debug-LoggingInfrastructureType'></a>
## LoggingInfrastructureType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Values describing the type of logging infrastructure you want to
utilize.

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

<a name='T-xyLOGIX-Core-Debug-MakeNewRollingFileAppender'></a>
## MakeNewRollingFileAppender `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to create new instances of
[RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') and initialize them.

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [MakeNewRollingFileAppender](#T-xyLOGIX-Core-Debug-MakeNewRollingFileAppender 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndHavingLogFileName-log4net-Appender-RollingFileAppender,System-String-'></a>
### AndHavingLogFileName(self,file) `method`

##### Summary

Builder extension method that initializes the
[File](#P-log4net-Appender-RollingFileAppender-File 'log4net.Appender.RollingFileAppender.File') property.

##### Returns

Reference to the same instance of the object that called this method,
for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that
implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| file | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the
fully-qualified pathname of where logging entries will be written. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `self`, is passed a `null` value. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the required parameter,
`file`, is passed a blank or `null` string
for a value. |

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndMaximumNumberOfRollingBackups-log4net-Appender-RollingFileAppender,System-Int32-'></a>
### AndMaximumNumberOfRollingBackups(self,maxSizeRollingBackups) `method`

##### Summary

Builder extension method that initializes the
[MaxSizeRollBackups](#P-log4net-Appender-RollingFileAppender-MaxSizeRollBackups 'log4net.Appender.RollingFileAppender.MaxSizeRollBackups')
property.

##### Returns

Reference to the same instance of the object that called this method,
for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that
implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| maxSizeRollingBackups | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) An
[Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') that specifies the maximum number of backup files
that are kept before the oldest backup file is erased. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `self`, is passed a `null` value. |

##### Remarks

If set to zero, then there will be no backup files and the log file
    will be truncated when it reaches
    [MaxFileSize](#P-log4net-Appender-RollingFileAppender-MaxFileSize 'log4net.Appender.RollingFileAppender.MaxFileSize').

If a negative number is supplied then no deletions will be made.
    Note that this could result in very slow performance as a large number of
    files are rolled over unless
    [CountDirection](#P-log4net-Appender-RollingFileAppender-CountDirection 'log4net.Appender.RollingFileAppender.CountDirection') is
    used.

The maximum applies to time based group of files and
    the total.

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndThatHasAStaticLogFileName-log4net-Appender-RollingFileAppender,System-Boolean-'></a>
### AndThatHasAStaticLogFileName(self,staticLogFileName) `method`

##### Summary

Builder extension method that initializes the
[StaticLogFileName](#P-log4net-Appender-RollingFileAppender-StaticLogFileName 'log4net.Appender.RollingFileAppender.StaticLogFileName')
property.

##### Returns

Reference to the same instance of the object that called this method,
for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that
implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| staticLogFileName | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean')
value indicating whether to always log to the same file.



Set to `true` if always should be logged to the same file,
otherwise `false`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `self`, is passed a `null` value. |

##### Remarks

By default, file.log is always the current file.  Optionally
    file.log.yyyy-mm-dd for current formatted datePattern can by the currently
    logging file (or file.log.curSizeRollBackup or even
    file.log.yyyy-mm-dd.curSizeRollBackup).

This will make time based rollovers with a large number of backups
    much faster as the appender it won't have to rename all the backups!

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-ForRollingStyle-log4net-Appender-RollingFileAppender-RollingMode-'></a>
### ForRollingStyle(style) `method`

##### Summary

Creates a new instance of
[RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') and initializes it with
the specified rolling `style`.

##### Returns

If successful, a new instance of
[RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') and initializes it with
the specified rolling `style`.  Otherwise,
`null` is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| style | [log4net.Appender.RollingFileAppender.RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') | (Required.) One or a combination of the
[RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') enumeration
values that specifies how the log file should be rolled when it gets too big
for size limits. |

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-ThatShouldAppendToFile-log4net-Appender-RollingFileAppender,System-Boolean-'></a>
### ThatShouldAppendToFile(self,appendToFile) `method`

##### Summary

Builder extension method that initializes the
[AppendToFile](#P-log4net-Appender-RollingFileAppender-AppendToFile 'log4net.Appender.RollingFileAppender.AppendToFile') property.

##### Returns

Reference to the same instance of the object that called this method,
for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that
implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| appendToFile | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value
that is set to `true` if the logger should append to the log
file, `false` if the file should be overwritten. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `self`, is passed a `null` value. |

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-WithMaximumFileSizeOf-log4net-Appender-RollingFileAppender,System-String-'></a>
### WithMaximumFileSizeOf(self,maximumFileSize) `method`

##### Summary

Builder extension method that initializes the
[MaximumFileSize](#P-log4net-Appender-RollingFileAppender-MaximumFileSize 'log4net.Appender.RollingFileAppender.MaximumFileSize') property.

##### Returns

Reference to the same instance of the object that called this method,
for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that
implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| maximumFileSize | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')
that describes the maximum size that the output file is allowed to reach before
being rolled over to back up files. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `self`, is passed a `null` value. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the required parameter,
`maximumFileSize`, is passed a blank or
`null` string for a value. |

##### Remarks

This property allows you to specify the maximum size with the
    suffixes "KB", "MB" or "GB" so that the size is interpreted being expressed
    respectively in kilobytes, megabytes or gigabytes.

For example, the value "10KB" will be interpreted as 10240 bytes.

The default maximum file size is 10MB.

If you have the option to set the maximum file size programmatically
    consider using the
    [MaxFileSize](#P-log4net-Appender-RollingFileAppender-MaxFileSize 'log4net.Appender.RollingFileAppender.MaxFileSize') property
    instead as this allows you to set the size in bytes as a
    [Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64').

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-WithPatternLayout-log4net-Appender-RollingFileAppender,log4net-Layout-PatternLayout-'></a>
### WithPatternLayout(self,layout) `method`

##### Summary

Builder extension method that initializes the
[Layout](#P-log4net-Appender-RollingFileAppender-Layout 'log4net.Appender.RollingFileAppender.Layout') property.

##### Returns

Reference to the same instance of the object that called this method,
for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that
implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| layout | [log4net.Layout.PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') | (Required.) Reference to an instance of
[PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') that specifies the pattern to
utilize for each line of the log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if either of the
required parameters, `self` or `layout`,
are passed a `null` value. |

<a name='T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs'></a>
## MuteConsoleChangedEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `MuteConsoleChanged` event handlers.

<a name='M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of
[MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs') and returns a
reference to it.

##### Parameters

This constructor has no parameters.

<a name='M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#ctor-System-Boolean-'></a>
### #ctor(newValue) `constructor`

##### Summary

Constructs a new instance of
[MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs') and returns a
reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newValue | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value
that matches the current value of the
[MuteConsole](#P-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsole 'xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole')
property. |

<a name='P-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-NewValue'></a>
### NewValue `property`

##### Summary

Gets a [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value that matches the current
value of the
[MuteConsole](#P-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsole 'xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole')
property.

<a name='M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='T-xyLOGIX-Core-Debug-MuteConsoleChangedEventHandler'></a>
## MuteConsoleChangedEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `MuteConsoleChanged` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:xyLOGIX.Core.Debug.MuteConsoleChangedEventHandler](#T-T-xyLOGIX-Core-Debug-MuteConsoleChangedEventHandler 'T:xyLOGIX.Core.Debug.MuteConsoleChangedEventHandler') | Reference to the instance of the object that raised the
event. |

##### Remarks

This delegate merely specifies the signature of all methods that
handle the `MuteConsoleChanged` event.

<a name='T-xyLOGIX-Core-Debug-ObjectDumper'></a>
## ObjectDumper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Object that is responsible for writing out the string representation
of objects to the log file. Works in a way very similar to LINQPad's Dump()
method.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-#ctor-System-Int32-'></a>
### #ctor(depth) `constructor`

##### Summary

Constructs a new instance of
[ObjectDumper](#T-xyLOGIX-Core-Debug-ObjectDumper 'xyLOGIX.Core.Debug.ObjectDumper') and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth (in terms
of inheritance levels) to which to dump object data. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is not zero or greater. |

<a name='F-xyLOGIX-Core-Debug-ObjectDumper-_currentStreamPosition'></a>
### _currentStreamPosition `constants`

##### Summary

Integer specifying the current position in the output stream.

<a name='F-xyLOGIX-Core-Debug-ObjectDumper-_depth'></a>
### _depth `constants`

##### Summary

Integer specifying the depth (inheritance levels) to which to dump
object data.

##### Remarks

Must be zero or greater.

<a name='F-xyLOGIX-Core-Debug-ObjectDumper-_indentLevel'></a>
### _indentLevel `constants`

##### Summary

Integer specifying the indentation level of the logged data.

##### Remarks

Must be 1 or greater.

<a name='F-xyLOGIX-Core-Debug-ObjectDumper-_writer'></a>
### _writer `constants`

##### Summary

Reference to a [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') to which to send
the logged data.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-OnTextWritten-xyLOGIX-Core-Debug-TextWrittenEventArgs-'></a>
### OnTextWritten(e) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-ObjectDumper-TextWritten 'xyLOGIX.Core.Debug.ObjectDumper.TextWritten')
event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.Core.Debug.TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs') | A [TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-Events-TextWrittenEventArgs 'xyLOGIX.Core.Debug.Events.TextWrittenEventArgs')
that contains the event data. |

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-Object,System-Int32-'></a>
### Write(element,depth) `method`

##### Summary

Writes an object, a reference to which is specified by the
`element` parameter, to the log, to the number of inheritance
levels specified by `depth`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of an object that
should be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer specifying how far up the inheritance
chain to dump. Default is zero. Must be zero or greater. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `element`, is passed a `null`
value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is not zero or greater. |

##### Remarks

By default, this overload of the method sends the dump output to the
[Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') stream.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-Object,System-Int32,System-IO-TextWriter-'></a>
### Write(element,depth,log) `method`

##### Summary

Writes an object, a reference to which is specified by the
`element` parameter, to the log, to the number of inheritance
levels specified by `depth`, and outputs it to the
[TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') instance referred to by the
`log` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of an object that
should be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer specifying how far up the inheritance
chain to dump. Default is zero. Must be zero or greater. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of
[TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') to which output should be sent. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if either of the
required parameters, `element` or `log`,
are passed a `null` value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is not zero or greater. |

##### Remarks

By default, this overload of the method sends the dump output to the
[Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') stream.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-String-'></a>
### Write(s) `method`

##### Summary

Writes the content in the string, `s`, to the
[TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') wrapped by this object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| s | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the content to be written. |

##### Remarks

This method does nothing if `s` is a blank string.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteIndent'></a>
### WriteIndent() `method`

##### Summary

Writes an indent -- a 4 space tab -- to the
[TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is wrapped by this object in the
[_writer](#F-xyLOGIX-Core-Debug-ObjectDumper-_writer 'xyLOGIX.Core.Debug.ObjectDumper._writer') field at the indent
level
given by the value of the
[_indentLevel](#F-xyLOGIX-Core-Debug-ObjectDumper-_indentLevel 'xyLOGIX.Core.Debug.ObjectDumper._indentLevel') field.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine-System-Object,System-Int32-'></a>
### WriteLine(element,depth) `method`

##### Summary

Writes an object, a reference to which is specified by the
`element` parameter, to the log, to the number of inheritance
levels specified by `depth`, followed by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of an object that
should be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer specifying how far up the inheritance
chain to dump. Default is zero. Must be zero or greater. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `element`, is passed a `null`
value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is not zero or greater. |

##### Remarks

By default, this overload of the method sends the dump output to the
[Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') stream.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine-System-Object,System-Int32,System-IO-TextWriter-'></a>
### WriteLine(element,depth,log) `method`

##### Summary

Writes an object, a reference to which is specified by the
`element` parameter, to the log, to the number of inheritance
levels specified by `depth`, and outputs it to the
[TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') instance referred to by the
`log` parameter, followed by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of an object that
should be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer specifying how far up the inheritance
chain to dump. Default is zero. Must be zero or greater. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of
[TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') to which output should be sent. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if either of the
required parameters, `element` or `log`,
are passed a `null` value. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the
`depth` parameter is not zero or greater. |

##### Remarks

By default, this overload of the method sends the dump output to the
[Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') stream.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine'></a>
### WriteLine() `method`

##### Summary

Outputs a blank line to the [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter')
that is wrapped by this object.

##### Parameters

This method has no parameters.

##### Remarks

This method does nothing if the
[_writer](#F-xyLOGIX-Core-Debug-ObjectDumper-_writer 'xyLOGIX.Core.Debug.ObjectDumper._writer') field is a
`null` reference.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteObject-System-String,System-Object-'></a>
### WriteObject(prefix,element) `method`

##### Summary

Workhorse method that actually does the job of writing the specified
`element` object to the output stream, with the specified
`prefix`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| prefix | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) String containing the prefix to be used. May
be blank or `null`. |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the instance of the object to
be dumped to the output stream. |

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteObjectToLines-System-String,System-Object-'></a>
### WriteObjectToLines(prefix,element) `method`

##### Summary

Workhorse method that actually does the job of writing the specified
`element` object to the output stream, with the specified
`prefix`, with a newline character inserted after each line
of text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| prefix | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) String containing the prefix to be used. May
be blank or `null`. |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the instance of the object to
be dumped to the output stream. |

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteTab'></a>
### WriteTab() `method`

##### Summary

Writes a 4-space tab at teh proper level of indent, depending on the
current position within the stream.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteValue-System-Object-'></a>
### WriteValue(o) `method`

##### Summary

Formats a value, specified by the reference to the instance of the
object, `o`, in a nice way for output.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of the object to be
formatted and written to the output stream. |

<a name='T-xyLOGIX-Core-Debug-OutputLocationBase'></a>
## OutputLocationBase `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the events, methods, properties, and behaviors for all output
location objects.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of
[OutputLocationBase](#T-xyLOGIX-Core-Debug-OutputLocationBase 'xyLOGIX.Core.Debug.OutputLocationBase') and returns a reference
to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This constructor is marked `protected`
due to the fact that this class is marked `abstract`.

<a name='P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is
turned on or off.

<a name='P-xyLOGIX-Core-Debug-OutputLocationBase-Type'></a>
### Type `property`

##### Summary

Gets one of the
[OutputLocationType](#T-xyLOGIX-Core-Debug-Constants-OutputLocationType 'xyLOGIX.Core.Debug.Constants.OutputLocationType') enumeration
values
that indicates the final base of text strings that are fed to this
location.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [OutputLocationBase](#T-xyLOGIX-Core-Debug-OutputLocationBase 'xyLOGIX.Core.Debug.OutputLocationBase') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the
standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to
the standard output stream using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by
the current line terminator, to the standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects,
followed by the current line terminator, to the standard output stream using
the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the standard output stream.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-OutputLocationProvider'></a>
## OutputLocationProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to a list of output locations for debugging.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of
[OutputLocationProvider](#T-xyLOGIX-Core-Debug-OutputLocationProvider 'xyLOGIX.Core.Debug.OutputLocationProvider') and returns a
reference to it.

##### Parameters

This constructor has no parameters.

<a name='F-xyLOGIX-Core-Debug-OutputLocationProvider-_muteConsole'></a>
### _muteConsole `constants`

##### Summary

A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value indicating whether the
console output location is turned on or off.

<a name='P-xyLOGIX-Core-Debug-OutputLocationProvider-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that
implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider')
interface.

<a name='P-xyLOGIX-Core-Debug-OutputLocationProvider-InternalOutputLocationList'></a>
### InternalOutputLocationList `property`

##### Summary

Gets a reference to a collection, each element of which implements
the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface.

<a name='P-xyLOGIX-Core-Debug-OutputLocationProvider-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is
turned on or off.

##### Remarks

This property raises the
[](#E-xyLOGIX-Core-Debug-OutputLocationProvider-MuteConsoleChanged 'xyLOGIX.Core.Debug.OutputLocationProvider.MuteConsoleChanged')
event
when its value is updated.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-AddLocation-xyLOGIX-Core-Debug-IOutputLocation-'></a>
### AddLocation(location) `method`

##### Summary

Adds the specified output `location` to the
internal list maintained by this object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [xyLOGIX.Core.Debug.IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') | (Required.) Reference to an instance of an object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface. |

##### Remarks

If the specified `location` has already been added,
then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-Clear'></a>
### Clear() `method`

##### Summary

Clears the internal list of output locations.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-InitializeInternalOutputLocationList'></a>
### InitializeInternalOutputLocationList() `method`

##### Summary

Initializes the
[InternalOutputLocationList](#P-xyLOGIX-Core-Debug-OutputLocationProvider-InternalOutputLocationList 'xyLOGIX.Core.Debug.OutputLocationProvider.InternalOutputLocationList')
to have default values.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-OnMuteConsoleChanged-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-'></a>
### OnMuteConsoleChanged(e) `method`

##### Summary

Raises the
[](#E-xyLOGIX-Core-Debug-OutputLocationProvider-MuteConsoleChanged 'xyLOGIX.Core.Debug.OutputLocationProvider.MuteConsoleChanged')
event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs') | A
[MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-Events-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.Events.MuteConsoleChangedEventArgs') that
contains
the event data. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the
standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to
the standard output stream using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by
the current line terminator, to the standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects,
followed by the current line terminator, to the standard output stream using
the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the standard output stream.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-OutputLocationType'></a>
## OutputLocationType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Values that indicate the type of output location, such as the console
window, debug output pane in Visual Studio, trace listeners, etc.

<a name='F-xyLOGIX-Core-Debug-OutputLocationType-Console'></a>
### Console `constants`

##### Summary

Output is directed to the standard output of this application, and a
console window, if present.

<a name='F-xyLOGIX-Core-Debug-OutputLocationType-Debug'></a>
### Debug `constants`

##### Summary

Output is directed to the Output window in Visual Studio.

##### Remarks

This location works even in Release mode.

<a name='F-xyLOGIX-Core-Debug-OutputLocationType-Trace'></a>
### Trace `constants`

##### Summary

Output is directed to trace listeners.

##### Remarks

This output location does not work in Release mode.

<a name='F-xyLOGIX-Core-Debug-OutputLocationType-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown output location.

<a name='T-xyLOGIX-Core-Debug-OutputMultiplexer'></a>
## OutputMultiplexer `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to multiplex debugging output; i.e.,
write it
to multiple locations at the same time.

<a name='P-xyLOGIX-Core-Debug-OutputMultiplexer-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is
turned on or off.

<a name='P-xyLOGIX-Core-Debug-OutputMultiplexer-OutputLocationProvider'></a>
### OutputLocationProvider `property`

##### Summary

Gets a reference to an instance of an object that implements the
[IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider') interface.

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to
the standard output stream using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects,
followed by the current line terminator, to the standard output stream using
the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the standard output stream.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by
the current line terminator, to the standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure'></a>
## PostSharpLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Implements log-file management for the case when we are utilizing
PostSharp aspects to handle the bulk of logging for us.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of
[PostSharpLoggingInfrastructure](#T-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure') and returns
a reference to it.

##### Parameters

This constructor has no parameters.

<a name='F-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-_relay'></a>
### _relay `constants`

##### Summary

Reference to the object that relays all logging to PostSharp.

##### Remarks

This field can only be set to a reference to an instance of an object
that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository')
interface.

<a name='P-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-Constants-LoggingInfrastructureType 'xyLOGIX.Core.Debug.Constants.LoggingInfrastructureType') value
that
corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the
[File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the first
appender in the list of appenders that is of type
[FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the
appender is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the
[LogFileName](#P-Core-Debug-ILoggingInfrastructure-LogFileName 'Core.Debug.ILoggingInfrastructure.LogFileName') property.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write
out "DEBUG" messages to the log file when in the Release mode. Set to false if
all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with
the latest logging sent out by this instance. |
| configurationFileNamename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the
configuration file to be utilized for initializing log4net. If blank, the
system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the
display of logging messages to the console if a log file is being used. If a
log file is not used, then no logging at all will occur if this parameter is
set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the
`XMLConfigurator` object is used to configure logging.



Else, specify here the path to the log file to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose
value must be `0` or greater.



Indicates the verbosity level.



Higher values mean more verbose.



if the `verbosity` parameter is negative, it will be ignored.



The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')
containing a user-friendly display name of the application that is using this
logging library.



Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object
that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository')
interface. Supply a value for this parameter if your infrastructure is not
utilizing the default HierarchicalRepository. |

<a name='T-xyLOGIX-Core-Debug-ProgramFlowHelper'></a>
## ProgramFlowHelper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines methods and properties to aid in controlling the flow of the
program.

<a name='M-xyLOGIX-Core-Debug-ProgramFlowHelper-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [ProgramFlowHelper](#T-xyLOGIX-Core-Debug-ProgramFlowHelper 'xyLOGIX.Core.Debug.ProgramFlowHelper') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-ProgramFlowHelper-EmergencyStop'></a>
### EmergencyStop() `method`

##### Summary

Brings the application to an immediate halt.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ProgramFlowHelper-StartDebugger'></a>
### StartDebugger() `method`

##### Summary

Launches the Visual Studio Debugger.

##### Parameters

This method has no parameters.

##### Remarks

This method should be called only as necessary to automatically
launch the Visual Studio Debugger, attached to the currently-running process
instance.



Such calls should be commented out or deleted when no longer needed.

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

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-Error_UnableFindAppConfigEntries'></a>
### Error_UnableFindAppConfigEntries `property`

##### Summary

Looks up a localized string similar to Unable to determine the path to the log file's containing folder.  Please ensure that the necessary entries for log4net are included in your App.config file..

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-ExceptionMessageFormat'></a>
### ExceptionMessageFormat `property`

##### Summary

Looks up a localized string similar to {0}: {1}
{2}.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-TempExceptionFileMessage'></a>
### TempExceptionFileMessage `property`

##### Summary

Looks up a localized string similar to {0} at {1}: Exception caught: {2}
	{3}

---

.

<a name='T-xyLOGIX-Core-Debug-SecretStringExtensions'></a>
## SecretStringExtensions `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes "secret" [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') extension methods to help the methods in this library only.

<a name='M-xyLOGIX-Core-Debug-SecretStringExtensions-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [SecretStringExtensions](#T-xyLOGIX-Core-Debug-SecretStringExtensions 'xyLOGIX.Core.Debug.SecretStringExtensions') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-SecretStringExtensions-CollapseNewlinesToSpaces-System-String-'></a>
### CollapseNewlinesToSpaces(value) `method`

##### Summary

"Collapses" or "folds" the specified `value` so that all
newlines are transformed to single whitespace characters.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the value passed, but with
all newlines transformed to single whitespace characters.



Multiple newlines are removed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the
value that is to be collapsed. |

<a name='T-xyLOGIX-Core-Debug-ServiceFlowHelper'></a>
## ServiceFlowHelper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods and properties to assist with the
operational
flow of a Windows service.

<a name='M-xyLOGIX-Core-Debug-ServiceFlowHelper-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [ServiceFlowHelper](#T-xyLOGIX-Core-Debug-ServiceFlowHelper 'xyLOGIX.Core.Debug.ServiceFlowHelper') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-ServiceFlowHelper-EmergencyStop-System-Action-'></a>
### EmergencyStop(notificationAction) `method`

##### Summary

Brings the Windows Service screeching suddenly to a halt.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| notificationAction | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | (Optional.) Code to be called immediately
prior to the emergency stop.



If this parameter is passed a `null` reference as its
argument, then nothing will be called. |

##### Remarks

Before calling this method, services should de-configure themselves
to be automatically re-started by the operating system.

<a name='M-xyLOGIX-Core-Debug-ServiceFlowHelper-OnDebuggerStartPending'></a>
### OnDebuggerStartPending() `method`

##### Summary

Raises the
[](#E-xyLOGIX-Core-Debug-ServiceFlowHelper-DebuggerStartPending 'xyLOGIX.Core.Debug.ServiceFlowHelper.DebuggerStartPending')
event.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ServiceFlowHelper-StartDebugger'></a>
### StartDebugger() `method`

##### Summary

Call this method to invoke the just-in-time debugger.

##### Parameters

This method has no parameters.

##### Remarks

Raises the
[](#E-xyLOGIX-Core-Debug-ServiceFlowHelper-DebuggerStartPending 'xyLOGIX.Core.Debug.ServiceFlowHelper.DebuggerStartPending')
event
prior to actually breaking into the debugger. This is helpful to run, e.g.,
service configuration code, prior to the operation.

<a name='T-xyLOGIX-Core-Debug-SetLog'></a>
## SetLog `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Sets elements of the log.

<a name='P-xyLOGIX-Core-Debug-SetLog-ApplicationName'></a>
### ApplicationName `property`

##### Summary

Gets or sets a string that provides the name to use for the
application's log file.

<a name='M-xyLOGIX-Core-Debug-SetLog-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [SetLog](#T-xyLOGIX-Core-Debug-SetLog 'xyLOGIX.Core.Debug.SetLog') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-Setup'></a>
## Setup `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to perform setup tasks.

<a name='P-xyLOGIX-Core-Debug-Setup-EventLogManager'></a>
### EventLogManager `property`

##### Summary

Gets a reference to an instance of an object that implements the
[IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface.

<a name='M-xyLOGIX-Core-Debug-Setup-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Setup](#T-xyLOGIX-Core-Debug-Setup 'xyLOGIX.Core.Debug.Setup') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Setup-EventLogging-System-String-'></a>
### EventLogging(applicationName) `method`

##### Summary

Sets up the Windows Event Log Application log quote to correspond
either to the specified `applicationName`, or to a event
quote name that we automatically obtain.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String')
that provides a user-friendly version of the application's name for viewing in
the Windows Event Log Viewer; leave blank to use the default value. |

<a name='T-xyLOGIX-Core-Debug-Split'></a>
## Split `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods for splitting [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value(s) into
array(s) of argument(s)

<a name='P-xyLOGIX-Core-Debug-Split-CommandLineRegex'></a>
### CommandLineRegex `property`

##### Summary

Gets a reference to an instance of
[Regex](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex') that is a regular
expression used to split command-line arguments into individual parts.

<a name='M-xyLOGIX-Core-Debug-Split-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Split](#T-xyLOGIX-Core-Debug-Split 'xyLOGIX.Core.Debug.Split') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Split-CommandLine-System-String-'></a>
### CommandLine(commandLine) `method`

##### Summary

Splits the specified command-line string into an array of arguments,
respecting quoted segments and spaces.

##### Returns

An enumerable collection of [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') values,
each representing an argument parsed from the command line.
The empty collection is returned if the `commandLine` is
`null`, blank, or if a parsing error occurs.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| commandLine | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the full command-line
input
to be split into arguments. If `null` or blank, an empty array
is returned. |

##### Remarks

This method uses a regular expression to identify arguments based on quoted and
unquoted segments.
Quoted arguments retain their content without the surrounding quotes.
Unquoted arguments are split on spaces.

<a name='T-xyLOGIX-Core-Debug-TextEmittedEventArgs'></a>
## TextEmittedEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `TextEmitted` event handlers.

<a name='M-xyLOGIX-Core-Debug-TextEmittedEventArgs-#ctor-System-String,xyLOGIX-Core-Debug-DebugLevel-'></a>
### #ctor(text,level) `constructor`

##### Summary

Constructs a new instance of
[TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs') and returns a
reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the
text that is otherwise going to be written to the log. |
| level | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel')
enumeration values that indicates of what level of severity is the message. |

<a name='P-xyLOGIX-Core-Debug-TextEmittedEventArgs-Level'></a>
### Level `property`

##### Summary

Gets of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel')
enumeration values that indicates of what level of severity is the message.

<a name='P-xyLOGIX-Core-Debug-TextEmittedEventArgs-Text'></a>
### Text `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the text that is
otherwise going to be written to the log.

<a name='T-xyLOGIX-Core-Debug-TextEmittedEventHandler'></a>
## TextEmittedEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `TextEmitted` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.TextEmittedEventHandler](#T-T-xyLOGIX-Core-Debug-TextEmittedEventHandler 'T:xyLOGIX.Core.Debug.TextEmittedEventHandler') | A [TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs')
that contains the event data. |

##### Remarks

This delegate merely specifies the signature of all methods that
handle the `TextEmitted` event.

<a name='T-xyLOGIX-Core-Debug-TextWrittenEventArgs'></a>
## TextWrittenEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `TextWritten` event handlers.

<a name='M-xyLOGIX-Core-Debug-TextWrittenEventArgs-#ctor-System-String-'></a>
### #ctor(text) `constructor`

##### Summary

Constructs a new instance of
[TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs') and returns a
reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the text to be written. |

<a name='P-xyLOGIX-Core-Debug-TextWrittenEventArgs-Text'></a>
### Text `property`

##### Summary

Gets a string containing the text to be written.

<a name='T-xyLOGIX-Core-Debug-TextWrittenEventHandler'></a>
## TextWrittenEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a TextWritten event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.TextWrittenEventHandler](#T-T-xyLOGIX-Core-Debug-TextWrittenEventHandler 'T:xyLOGIX.Core.Debug.TextWrittenEventHandler') | A [TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs')
that contains the event data. |

##### Remarks

This delegate merely specifies the signature of all methods that
handle the TextWritten event.



The TextWritten event is raised when text has been output to a console, text
file, or other base, as a means of allowing more than one part of a
software system to participate in the output of text.

<a name='T-xyLOGIX-Core-Debug-TraceOutputLocation'></a>
## TraceOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Writes debugging output to the window in Visual Studio
or whichever other debugger can listen to the output of the
[Trace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Trace 'System.Diagnostics.Trace') class' methods.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, protected constructor to prohibit direct allocation of this
class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-TraceOutputLocation-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that
implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface
that
directs debugging output to the window in Visual Studio or
whichever other debugger can listen to the output of the
[Trace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Trace 'System.Diagnostics.Trace') class' methods.

<a name='P-xyLOGIX-Core-Debug-TraceOutputLocation-Type'></a>
### Type `property`

##### Summary

Gets one of the
[OutputLocationType](#T-xyLOGIX-Core-Debug-Constants-OutputLocationType 'xyLOGIX.Core.Debug.Constants.OutputLocationType') enumeration
values
that indicates the final base of text strings that are fed to this
location.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, static constructor to prohibit direct allocation of this
class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the
standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to
the standard output stream using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by
the current line terminator, to the standard output stream.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects,
followed by the current line terminator, to the standard output stream using
the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using
`format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or
`arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in
`format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the standard output stream.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-Validate'></a>
## Validate `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static methods to validate information and settings.

<a name='M-xyLOGIX-Core-Debug-Validate-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Validate](#T-xyLOGIX-Core-Debug-Validate 'xyLOGIX.Core.Debug.Validate') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Validate-LoggingInfrastructureType-xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### LoggingInfrastructureType(type) `method`

##### Summary

Determines whether the specified logging infrastructure
`type` value is in the set of valid values.

##### Returns

`true` if the specified logging infrastructure
`type` is in the set of valid values.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Required.) The
[LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') enumeration value
that is to be validated. |

<a name='T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs'></a>
## VerbosityChangedEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `VerbosityChanged` event handlers.

<a name='M-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-#ctor-System-Int32,System-Int32-'></a>
### #ctor(oldValue,newValue) `constructor`

##### Summary

Constructs a new instance of
[VerbosityChangedEventArgs](#T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs') and returns a
reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| oldValue | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that
is the former value of the
[Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property. |
| newValue | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that
is the current value of the
[Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property. |

<a name='P-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-NewValue'></a>
### NewValue `property`

##### Summary

Gets an [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that is the new value of
the [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property.

<a name='P-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-OldValue'></a>
### OldValue `property`

##### Summary

Gets an [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that is the former value
of the [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property.

<a name='T-xyLOGIX-Core-Debug-VerbosityChangedEventHandler'></a>
## VerbosityChangedEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `VerbosityChanged` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.VerbosityChangedEventHandler](#T-T-xyLOGIX-Core-Debug-VerbosityChangedEventHandler 'T:xyLOGIX.Core.Debug.VerbosityChangedEventHandler') | A
[VerbosityChangedEventArgs](#T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs') that contains the
event data. |

##### Remarks

This delegate merely specifies the signature of all methods that
handle the `VerbosityChanged` event.
