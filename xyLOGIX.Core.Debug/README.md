<a name='assembly'></a>
# xyLOGIX.Core.Debug

contents## Contents

- [Activate](#T-xyLOGIX-Core-Debug-Activate 'xyLOGIX.Core.Debug.Activate')
  - [AppenderManager](#P-xyLOGIX-Core-Debug-Activate-AppenderManager 'xyLOGIX.Core.Debug.Activate.AppenderManager')
  - [LoggingForLogFileName(logFileName,repository)](#M-xyLOGIX-Core-Debug-Activate-LoggingForLogFileName-System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.Activate.LoggingForLogFileName(System.String,log4net.Repository.ILoggerRepository)')
- [AppDomainFriendlyNames](#T-xyLOGIX-Core-Debug-AppDomainFriendlyNames 'xyLOGIX.Core.Debug.AppDomainFriendlyNames')
  - [LINQPad](#F-xyLOGIX-Core-Debug-AppDomainFriendlyNames-LINQPad 'xyLOGIX.Core.Debug.AppDomainFriendlyNames.LINQPad')
- [AppenderManager](#T-xyLOGIX-Core-Debug-AppenderManager 'xyLOGIX.Core.Debug.AppenderManager')
  - [#ctor()](#M-xyLOGIX-Core-Debug-AppenderManager-#ctor 'xyLOGIX.Core.Debug.AppenderManager.#ctor')
  - [_appenders](#F-xyLOGIX-Core-Debug-AppenderManager-_appenders 'xyLOGIX.Core.Debug.AppenderManager._appenders')
  - [AppenderCount](#P-xyLOGIX-Core-Debug-AppenderManager-AppenderCount 'xyLOGIX.Core.Debug.AppenderManager.AppenderCount')
  - [Appenders](#P-xyLOGIX-Core-Debug-AppenderManager-Appenders 'xyLOGIX.Core.Debug.AppenderManager.Appenders')
  - [HasAppenders](#P-xyLOGIX-Core-Debug-AppenderManager-HasAppenders 'xyLOGIX.Core.Debug.AppenderManager.HasAppenders')
  - [Instance](#P-xyLOGIX-Core-Debug-AppenderManager-Instance 'xyLOGIX.Core.Debug.AppenderManager.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-AppenderManager-#cctor 'xyLOGIX.Core.Debug.AppenderManager.#cctor')
  - [AddAppender(appender)](#M-xyLOGIX-Core-Debug-AppenderManager-AddAppender-log4net-Appender-IAppender- 'xyLOGIX.Core.Debug.AppenderManager.AddAppender(log4net.Appender.IAppender)')
  - [GetFileAppenderByPath(logFilePath)](#M-xyLOGIX-Core-Debug-AppenderManager-GetFileAppenderByPath-System-String- 'xyLOGIX.Core.Debug.AppenderManager.GetFileAppenderByPath(System.String)')
  - [HasAppenderWithFilePath(filePath)](#M-xyLOGIX-Core-Debug-AppenderManager-HasAppenderWithFilePath-System-String- 'xyLOGIX.Core.Debug.AppenderManager.HasAppenderWithFilePath(System.String)')
- [Ascertain](#T-xyLOGIX-Core-Debug-Ascertain 'xyLOGIX.Core.Debug.Ascertain')
  - [LoggingClientLoggerCacheAddActionValidator](#P-xyLOGIX-Core-Debug-Ascertain-LoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.Ascertain.LoggingClientLoggerCacheAddActionValidator')
  - [LoggingClientLoggerCacheAddHandlerTypeValidator](#P-xyLOGIX-Core-Debug-Ascertain-LoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.Ascertain.LoggingClientLoggerCacheAddHandlerTypeValidator')
  - [LoggingClientLoggerCacheAddOutcomeValidator](#P-xyLOGIX-Core-Debug-Ascertain-LoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.Ascertain.LoggingClientLoggerCacheAddOutcomeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Ascertain-#cctor 'xyLOGIX.Core.Debug.Ascertain.#cctor')
  - [TryMapLoggingClientLoggerCacheAddAction(handlerType)](#M-xyLOGIX-Core-Debug-Ascertain-TryMapLoggingClientLoggerCacheAddAction-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType- 'xyLOGIX.Core.Debug.Ascertain.TryMapLoggingClientLoggerCacheAddAction(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType)')
  - [WhetherAddHandlerTypeAndActionComboIsValid(handlerType,action)](#M-xyLOGIX-Core-Debug-Ascertain-WhetherAddHandlerTypeAndActionComboIsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction- 'xyLOGIX.Core.Debug.Ascertain.WhetherAddHandlerTypeAndActionComboIsValid(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType,xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction)')
  - [WhetherAddHandlerTypeAndOutcomeComboIsValid(handlerType,outcome)](#M-xyLOGIX-Core-Debug-Ascertain-WhetherAddHandlerTypeAndOutcomeComboIsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome- 'xyLOGIX.Core.Debug.Ascertain.WhetherAddHandlerTypeAndOutcomeComboIsValid(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType,xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome)')
- [CommandLineParameter](#T-xyLOGIX-Core-Debug-CommandLineParameter 'xyLOGIX.Core.Debug.CommandLineParameter')
  - [HaltOnException](#F-xyLOGIX-Core-Debug-CommandLineParameter-HaltOnException 'xyLOGIX.Core.Debug.CommandLineParameter.HaltOnException')
  - [SuppressOnException](#F-xyLOGIX-Core-Debug-CommandLineParameter-SuppressOnException 'xyLOGIX.Core.Debug.CommandLineParameter.SuppressOnException')
- [Compute](#T-xyLOGIX-Core-Debug-Compute 'xyLOGIX.Core.Debug.Compute')
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
  - [DirectoryWriteabilityStatusValidator](#P-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-DirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.DirectoryWriteabilityStatusValidator')
  - [FileWriteabilityStatusValidator](#P-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-FileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.FileWriteabilityStatusValidator')
  - [FullyQualifiedUserName](#P-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-FullyQualifiedUserName 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.FullyQualifiedUserName')
  - [ClearTempFileDir()](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-ClearTempFileDir 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.ClearTempFileDir')
  - [CreateDirectoryIfNotExists(directoryPath)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-CreateDirectoryIfNotExists-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.CreateDirectoryIfNotExists(System.String)')
  - [DetermineDirectoryWriteabilityStatus(r,groups,sidCurrentUser)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-DetermineDirectoryWriteabilityStatus-System-Security-AccessControl-FileSystemAccessRule,System-Security-Principal-IdentityReferenceCollection,System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.DetermineDirectoryWriteabilityStatus(System.Security.AccessControl.FileSystemAccessRule,System.Security.Principal.IdentityReferenceCollection,System.String)')
  - [DetermineFileWriteabilityStatus(r,groups,sidCurrentUser)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-DetermineFileWriteabilityStatus-System-Security-AccessControl-FileSystemAccessRule,System-Security-Principal-IdentityReferenceCollection,System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.DetermineFileWriteabilityStatus(System.Security.AccessControl.FileSystemAccessRule,System.Security.Principal.IdentityReferenceCollection,System.String)')
  - [InsistPathExists()](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-InsistPathExists-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.InsistPathExists(System.String)')
  - [IsFileReadOnly(pathname)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFileReadOnly-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsFileReadOnly(System.String)')
  - [IsFileWriteable(pathname)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFileWriteable-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsFileWriteable(System.String)')
  - [IsFolderReadOnly(pathname)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFolderReadOnly-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsFolderReadOnly(System.String)')
  - [IsFolderWriteable(pathname)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFolderWriteable-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsFolderWriteable(System.String)')
  - [IsValidPath(fullyQualifiedPath)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsValidPath-System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.IsValidPath(System.String)')
  - [RulesFoundForUser(rules,sidCurrentUser)](#M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-RulesFoundForUser-System-Security-AccessControl-AuthorizationRuleCollection,System-String- 'xyLOGIX.Core.Debug.DebugFileAndFolderHelper.RulesFoundForUser(System.Security.AccessControl.AuthorizationRuleCollection,System.String)')
- [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel')
  - [Debug](#F-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug')
  - [Error](#F-xyLOGIX-Core-Debug-DebugLevel-Error 'xyLOGIX.Core.Debug.DebugLevel.Error')
  - [Info](#F-xyLOGIX-Core-Debug-DebugLevel-Info 'xyLOGIX.Core.Debug.DebugLevel.Info')
  - [Output](#F-xyLOGIX-Core-Debug-DebugLevel-Output 'xyLOGIX.Core.Debug.DebugLevel.Output')
  - [Unknown](#F-xyLOGIX-Core-Debug-DebugLevel-Unknown 'xyLOGIX.Core.Debug.DebugLevel.Unknown')
  - [Warning](#F-xyLOGIX-Core-Debug-DebugLevel-Warning 'xyLOGIX.Core.Debug.DebugLevel.Warning')
- [DebugLevelValidator](#T-xyLOGIX-Core-Debug-DebugLevelValidator 'xyLOGIX.Core.Debug.DebugLevelValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-DebugLevelValidator-#ctor 'xyLOGIX.Core.Debug.DebugLevelValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-DebugLevelValidator-Instance 'xyLOGIX.Core.Debug.DebugLevelValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DebugLevelValidator-#cctor 'xyLOGIX.Core.Debug.DebugLevelValidator.#cctor')
  - [IsValid(level)](#M-xyLOGIX-Core-Debug-DebugLevelValidator-IsValid-xyLOGIX-Core-Debug-DebugLevel- 'xyLOGIX.Core.Debug.DebugLevelValidator.IsValid(xyLOGIX.Core.Debug.DebugLevel)')
- [DebugOutputLocation](#T-xyLOGIX-Core-Debug-DebugOutputLocation 'xyLOGIX.Core.Debug.DebugOutputLocation')
  - [#ctor()](#M-xyLOGIX-Core-Debug-DebugOutputLocation-#ctor 'xyLOGIX.Core.Debug.DebugOutputLocation.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-DebugOutputLocation-Instance 'xyLOGIX.Core.Debug.DebugOutputLocation.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-DebugOutputLocation-Type 'xyLOGIX.Core.Debug.DebugOutputLocation.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DebugOutputLocation-#cctor 'xyLOGIX.Core.Debug.DebugOutputLocation.#cctor')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-DebugOutputLocation-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugOutputLocation.Write(System.String,System.Object[])')
  - [Write(value)](#M-xyLOGIX-Core-Debug-DebugOutputLocation-Write-System-Object- 'xyLOGIX.Core.Debug.DebugOutputLocation.Write(System.Object)')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine-System-Object- 'xyLOGIX.Core.Debug.DebugOutputLocation.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugOutputLocation.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine 'xyLOGIX.Core.Debug.DebugOutputLocation.WriteLine')
- [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils')
  - [_muteConsole](#F-xyLOGIX-Core-Debug-DebugUtils-_muteConsole 'xyLOGIX.Core.Debug.DebugUtils._muteConsole')
  - [_verbosity](#F-xyLOGIX-Core-Debug-DebugUtils-_verbosity 'xyLOGIX.Core.Debug.DebugUtils._verbosity')
  - [ApplicationName](#P-xyLOGIX-Core-Debug-DebugUtils-ApplicationName 'xyLOGIX.Core.Debug.DebugUtils.ApplicationName')
  - [ClientLogProvider](#P-xyLOGIX-Core-Debug-DebugUtils-ClientLogProvider 'xyLOGIX.Core.Debug.DebugUtils.ClientLogProvider')
  - [ConsoleOnly](#P-xyLOGIX-Core-Debug-DebugUtils-ConsoleOnly 'xyLOGIX.Core.Debug.DebugUtils.ConsoleOnly')
  - [ExceptionLogPathname](#P-xyLOGIX-Core-Debug-DebugUtils-ExceptionLogPathname 'xyLOGIX.Core.Debug.DebugUtils.ExceptionLogPathname')
  - [ExcludedExceptionTypes](#P-xyLOGIX-Core-Debug-DebugUtils-ExcludedExceptionTypes 'xyLOGIX.Core.Debug.DebugUtils.ExcludedExceptionTypes')
  - [InfrastructureType](#P-xyLOGIX-Core-Debug-DebugUtils-InfrastructureType 'xyLOGIX.Core.Debug.DebugUtils.InfrastructureType')
  - [IsLogging](#P-xyLOGIX-Core-Debug-DebugUtils-IsLogging 'xyLOGIX.Core.Debug.DebugUtils.IsLogging')
  - [IsPostSharp](#P-xyLOGIX-Core-Debug-DebugUtils-IsPostSharp 'xyLOGIX.Core.Debug.DebugUtils.IsPostSharp')
  - [LogFileName](#P-xyLOGIX-Core-Debug-DebugUtils-LogFileName 'xyLOGIX.Core.Debug.DebugUtils.LogFileName')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-DebugUtils-MuteConsole 'xyLOGIX.Core.Debug.DebugUtils.MuteConsole')
  - [MuteDebugLevelIfReleaseMode](#P-xyLOGIX-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'xyLOGIX.Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode')
  - [Out](#P-xyLOGIX-Core-Debug-DebugUtils-Out 'xyLOGIX.Core.Debug.DebugUtils.Out')
  - [OutputLocationProvider](#P-xyLOGIX-Core-Debug-DebugUtils-OutputLocationProvider 'xyLOGIX.Core.Debug.DebugUtils.OutputLocationProvider')
  - [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DebugUtils-#cctor 'xyLOGIX.Core.Debug.DebugUtils.#cctor')
  - [AppendText(text)](#M-xyLOGIX-Core-Debug-DebugUtils-AppendText-System-String- 'xyLOGIX.Core.Debug.DebugUtils.AppendText(System.String)')
  - [AppendToLog(text)](#M-xyLOGIX-Core-Debug-DebugUtils-AppendToLog-System-String- 'xyLOGIX.Core.Debug.DebugUtils.AppendToLog(System.String)')
  - [CanLaunchDebugger(exception,launchDebuggerConfigured)](#M-xyLOGIX-Core-Debug-DebugUtils-CanLaunchDebugger-System-Exception,System-Boolean- 'xyLOGIX.Core.Debug.DebugUtils.CanLaunchDebugger(System.Exception,System.Boolean)')
  - [ClearTempExceptionLog()](#M-xyLOGIX-Core-Debug-DebugUtils-ClearTempExceptionLog 'xyLOGIX.Core.Debug.DebugUtils.ClearTempExceptionLog')
  - [DumpCollection(collection)](#M-xyLOGIX-Core-Debug-DebugUtils-DumpCollection-System-Collections-ICollection- 'xyLOGIX.Core.Debug.DebugUtils.DumpCollection(System.Collections.ICollection)')
  - [EchoCommandLinkText(commandLink)](#M-xyLOGIX-Core-Debug-DebugUtils-EchoCommandLinkText-System-Object- 'xyLOGIX.Core.Debug.DebugUtils.EchoCommandLinkText(System.Object)')
  - [FormatException(e)](#M-xyLOGIX-Core-Debug-DebugUtils-FormatException-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.FormatException(System.Exception)')
  - [FormatExceptionAndWrite(e)](#M-xyLOGIX-Core-Debug-DebugUtils-FormatExceptionAndWrite-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.FormatExceptionAndWrite(System.Exception)')
  - [GenerateContentFromFormat(format,args)](#M-xyLOGIX-Core-Debug-DebugUtils-GenerateContentFromFormat-System-String,System-Object[]- 'xyLOGIX.Core.Debug.DebugUtils.GenerateContentFromFormat(System.String,System.Object[])')
  - [IsExceptionSuppressed(exception)](#M-xyLOGIX-Core-Debug-DebugUtils-IsExceptionSuppressed-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.IsExceptionSuppressed(System.Exception)')
  - [LogEachLineIfMultiline(content,logMethod,level)](#M-xyLOGIX-Core-Debug-DebugUtils-LogEachLineIfMultiline-System-String,System-Action{xyLOGIX-Core-Debug-DebugLevel,System-String},xyLOGIX-Core-Debug-DebugLevel- 'xyLOGIX.Core.Debug.DebugUtils.LogEachLineIfMultiline(System.String,System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String},xyLOGIX.Core.Debug.DebugLevel)')
  - [LogException(exception,launchDebugger)](#M-xyLOGIX-Core-Debug-DebugUtils-LogException-System-Exception,System-Boolean- 'xyLOGIX.Core.Debug.DebugUtils.LogException(System.Exception,System.Boolean)')
  - [OnExceptionLogged(ex)](#M-xyLOGIX-Core-Debug-DebugUtils-OnExceptionLogged-System-Exception- 'xyLOGIX.Core.Debug.DebugUtils.OnExceptionLogged(System.Exception)')
  - [OnTextEmitted(e)](#M-xyLOGIX-Core-Debug-DebugUtils-OnTextEmitted-xyLOGIX-Core-Debug-TextEmittedEventArgs- 'xyLOGIX.Core.Debug.DebugUtils.OnTextEmitted(xyLOGIX.Core.Debug.TextEmittedEventArgs)')
  - [OnVerbosityChanged()](#M-xyLOGIX-Core-Debug-DebugUtils-OnVerbosityChanged-xyLOGIX-Core-Debug-VerbosityChangedEventArgs- 'xyLOGIX.Core.Debug.DebugUtils.OnVerbosityChanged(xyLOGIX.Core.Debug.VerbosityChangedEventArgs)')
  - [OutputExceptionLoggingMessage(exception,message)](#M-xyLOGIX-Core-Debug-DebugUtils-OutputExceptionLoggingMessage-System-Exception,System-String- 'xyLOGIX.Core.Debug.DebugUtils.OutputExceptionLoggingMessage(System.Exception,System.String)')
  - [TryGetLogForCurrentClient(sourceType)](#M-xyLOGIX-Core-Debug-DebugUtils-TryGetLogForCurrentClient-System-Type- 'xyLOGIX.Core.Debug.DebugUtils.TryGetLogForCurrentClient(System.Type)')
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
  - [DumpLines(element,depth,log)](#M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32,System-IO-TextWriter- 'xyLOGIX.Core.Debug.DebuggerDump.DumpLines(System.Object,System.Int32,System.IO.TextWriter)')
  - [DumpLines(element,depth)](#M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32- 'xyLOGIX.Core.Debug.DebuggerDump.DumpLines(System.Object,System.Int32)')
- [DefaultLoggingInfrastructure](#T-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure')
  - [#ctor()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-#ctor 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.#ctor')
  - [_firstFileAppender](#F-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-_firstFileAppender 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure._firstFileAppender')
  - [_logFilePathnameToUse](#F-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-_logFilePathnameToUse 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure._logFilePathnameToUse')
  - [Appender](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Appender 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.Appender')
  - [Instance](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Instance 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.Instance')
  - [IsConsoleApp](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-IsConsoleApp 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.IsConsoleApp')
  - [LogFileName](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFileName 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileName')
  - [LoggingConfiguratorTypeValidator](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LoggingConfiguratorTypeValidator')
  - [Type](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Type 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-#cctor 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.#cctor')
  - [GetConsoleWindow()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetConsoleWindow 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.GetConsoleWindow')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFilePathnameToUse,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
  - [OnLogFileNameChanged()](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-OnLogFileNameChanged 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.OnLogFileNameChanged')
  - [OnLoggingInitializationFinished(overwrite,repository)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-OnLoggingInitializationFinished-System-Boolean,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.OnLoggingInitializationFinished(System.Boolean,log4net.Repository.ILoggerRepository)')
  - [PrepareLogFile(repository)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-PrepareLogFile-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.PrepareLogFile(log4net.Repository.ILoggerRepository)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean)')
  - [TryAscertainVsixSpecificLog4NetConfigFilePath(defaultConfigFilePath,effectiveConfigurationFileName)](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-TryAscertainVsixSpecificLog4NetConfigFilePath-System-String,System-String@- 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.TryAscertainVsixSpecificLog4NetConfigFilePath(System.String,System.String@)')
- [Delete](#T-xyLOGIX-Core-Debug-Delete 'xyLOGIX.Core.Debug.Delete')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Delete-#cctor 'xyLOGIX.Core.Debug.Delete.#cctor')
  - [FileIfExists(pathname)](#M-xyLOGIX-Core-Debug-Delete-FileIfExists-System-String- 'xyLOGIX.Core.Debug.Delete.FileIfExists(System.String)')
  - [FileIfExistsDo(pathname)](#M-xyLOGIX-Core-Debug-Delete-FileIfExistsDo-System-String- 'xyLOGIX.Core.Debug.Delete.FileIfExistsDo(System.String)')
  - [FileIfExistsSilent(pathname)](#M-xyLOGIX-Core-Debug-Delete-FileIfExistsSilent-System-String- 'xyLOGIX.Core.Debug.Delete.FileIfExistsSilent(System.String)')
  - [LogFile(pathname)](#M-xyLOGIX-Core-Debug-Delete-LogFile-System-String- 'xyLOGIX.Core.Debug.Delete.LogFile(System.String)')
- [Derive](#T-xyLOGIX-Core-Debug-Derive 'xyLOGIX.Core.Debug.Derive')
  - [LoggingClientLoggerCacheAddHandlerTypeValidator](#P-xyLOGIX-Core-Debug-Derive-LoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.Derive.LoggingClientLoggerCacheAddHandlerTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Derive-#cctor 'xyLOGIX.Core.Debug.Derive.#cctor')
  - [LoggingClientLoggerCacheAddOutcomeFrom(handlerType,addOperationSucceeded)](#M-xyLOGIX-Core-Debug-Derive-LoggingClientLoggerCacheAddOutcomeFrom-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,System-Boolean- 'xyLOGIX.Core.Debug.Derive.LoggingClientLoggerCacheAddOutcomeFrom(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType,System.Boolean)')
- [Determine](#T-xyLOGIX-Core-Debug-Determine 'xyLOGIX.Core.Debug.Determine')
  - [AppenderManager](#P-xyLOGIX-Core-Debug-Determine-AppenderManager 'xyLOGIX.Core.Debug.Determine.AppenderManager')
  - [ClientAssemblyContext](#P-xyLOGIX-Core-Debug-Determine-ClientAssemblyContext 'xyLOGIX.Core.Debug.Determine.ClientAssemblyContext')
  - [ClientSessionRegistry](#P-xyLOGIX-Core-Debug-Determine-ClientSessionRegistry 'xyLOGIX.Core.Debug.Determine.ClientSessionRegistry')
  - [CurrentClientAssemblyTicket](#P-xyLOGIX-Core-Debug-Determine-CurrentClientAssemblyTicket 'xyLOGIX.Core.Debug.Determine.CurrentClientAssemblyTicket')
  - [CurrentClientSession](#P-xyLOGIX-Core-Debug-Determine-CurrentClientSession 'xyLOGIX.Core.Debug.Determine.CurrentClientSession')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Determine-#cctor 'xyLOGIX.Core.Debug.Determine.#cctor')
  - [LoggingConfiguratorTypeToUse(logFileName)](#M-xyLOGIX-Core-Debug-Determine-LoggingConfiguratorTypeToUse-System-String- 'xyLOGIX.Core.Debug.Determine.LoggingConfiguratorTypeToUse(System.String)')
  - [TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse(loggerWasFound,cachedLogger)](#M-xyLOGIX-Core-Debug-Determine-TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse-System-Boolean,log4net-ILog- 'xyLOGIX.Core.Debug.Determine.TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse(System.Boolean,log4net.ILog)')
  - [TheCorrectLoggingClientLoggerCacheAddOutcomeToUse(handlerType,addOperationSucceeded)](#M-xyLOGIX-Core-Debug-Determine-TheCorrectLoggingClientLoggerCacheAddOutcomeToUse-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,System-Boolean- 'xyLOGIX.Core.Debug.Determine.TheCorrectLoggingClientLoggerCacheAddOutcomeToUse(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType,System.Boolean)')
  - [TheCorrectRootLoggerProvisioningStrategyToUse(loggerRepository)](#M-xyLOGIX-Core-Debug-Determine-TheCorrectRootLoggerProvisioningStrategyToUse-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.Determine.TheCorrectRootLoggerProvisioningStrategyToUse(log4net.Repository.ILoggerRepository)')
  - [TheCorrectSessionLoggerFetchApproachToUse(sourceType)](#M-xyLOGIX-Core-Debug-Determine-TheCorrectSessionLoggerFetchApproachToUse-System-Type- 'xyLOGIX.Core.Debug.Determine.TheCorrectSessionLoggerFetchApproachToUse(System.Type)')
  - [TheCorrectXmlLoggingConfiguratorTypeToUse(configurationFileName)](#M-xyLOGIX-Core-Debug-Determine-TheCorrectXmlLoggingConfiguratorTypeToUse-System-String- 'xyLOGIX.Core.Debug.Determine.TheCorrectXmlLoggingConfiguratorTypeToUse(System.String)')
- [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus')
  - [NoDetermination](#F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-NoDetermination 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus.NoDetermination')
  - [NotWriteable](#F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-NotWriteable 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus.NotWriteable')
  - [Unknown](#F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-Unknown 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus.Unknown')
  - [Writeable](#F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-Writeable 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus.Writeable')
- [DirectoryWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatusValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator-#ctor 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatusValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator-Instance 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatusValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator-#cctor 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatusValidator.#cctor')
  - [IsValid(status)](#M-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator-IsValid-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus- 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatusValidator.IsValid(xyLOGIX.Core.Debug.DirectoryWriteabilityStatus)')
- [EmergencyStopPendingEventHandler](#T-xyLOGIX-Core-Debug-EmergencyStopPendingEventHandler 'xyLOGIX.Core.Debug.EmergencyStopPendingEventHandler')
- [EventLogManager](#T-xyLOGIX-Core-Debug-EventLogManager 'xyLOGIX.Core.Debug.EventLogManager')
  - [#ctor()](#M-xyLOGIX-Core-Debug-EventLogManager-#ctor 'xyLOGIX.Core.Debug.EventLogManager.#ctor')
  - [EventLogTypeValidator](#P-xyLOGIX-Core-Debug-EventLogManager-EventLogTypeValidator 'xyLOGIX.Core.Debug.EventLogManager.EventLogTypeValidator')
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
- [EventLogTypeValidator](#T-xyLOGIX-Core-Debug-EventLogTypeValidator 'xyLOGIX.Core.Debug.EventLogTypeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-EventLogTypeValidator-#ctor 'xyLOGIX.Core.Debug.EventLogTypeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-EventLogTypeValidator-Instance 'xyLOGIX.Core.Debug.EventLogTypeValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-EventLogTypeValidator-#cctor 'xyLOGIX.Core.Debug.EventLogTypeValidator.#cctor')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-EventLogTypeValidator-IsValid-xyLOGIX-Core-Debug-EventLogType- 'xyLOGIX.Core.Debug.EventLogTypeValidator.IsValid(xyLOGIX.Core.Debug.EventLogType)')
- [ExceptionExtensions](#T-xyLOGIX-Core-Debug-ExceptionExtensions 'xyLOGIX.Core.Debug.ExceptionExtensions')
  - [IsAnyOf(exception,types)](#M-xyLOGIX-Core-Debug-ExceptionExtensions-IsAnyOf-System-Exception,System-Type[]- 'xyLOGIX.Core.Debug.ExceptionExtensions.IsAnyOf(System.Exception,System.Type[])')
  - [LogAllExceptions(exceptions)](#M-xyLOGIX-Core-Debug-ExceptionExtensions-LogAllExceptions-System-Collections-Generic-IEnumerable{System-Exception}- 'xyLOGIX.Core.Debug.ExceptionExtensions.LogAllExceptions(System.Collections.Generic.IEnumerable{System.Exception})')
- [ExceptionLoggedEventArgs](#T-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs')
  - [#ctor(exception)](#M-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs-#ctor-System-Exception- 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs.#ctor(System.Exception)')
  - [Exception](#P-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs-Exception 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs.Exception')
- [ExceptionLoggedEventHandler](#T-xyLOGIX-Core-Debug-ExceptionLoggedEventHandler 'xyLOGIX.Core.Debug.ExceptionLoggedEventHandler')
- [ExistingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler')
  - [#ctor()](#M-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-#ctor 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler.#ctor')
  - [Action](#P-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-Action 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler.Action')
  - [HandlerType](#P-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-HandlerType 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler.HandlerType')
  - [Instance](#P-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-Instance 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-#cctor 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler.#cctor')
- [FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher')
  - [#ctor()](#M-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-#ctor 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.#ctor')
  - [Approach](#P-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.Approach')
  - [Instance](#P-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-Instance 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-#cctor 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.#cctor')
  - [FetchLogger(sourceType,repositoryName)](#M-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-FetchLogger-System-Type,System-String- 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.FetchLogger(System.Type,System.String)')
- [FetchFromCacheSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher')
  - [#ctor()](#M-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-#ctor 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher.#ctor')
  - [Approach](#P-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher.Approach')
  - [Instance](#P-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-Instance 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-#cctor 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher.#cctor')
  - [FetchLogger(sourceType,repositoryName)](#M-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-FetchLogger-System-Type,System-String- 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher.FetchLogger(System.Type,System.String)')
- [FetchLegacyLoggerSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher')
  - [#ctor()](#M-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-#ctor 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher.#ctor')
  - [Approach](#P-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher.Approach')
  - [Instance](#P-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-Instance 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-#cctor 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher.#cctor')
  - [FetchLogger(sourceType,repositoryName)](#M-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-FetchLogger-System-Type,System-String- 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher.FetchLogger(System.Type,System.String)')
  - [TryGetLegacyLogger(sourceType)](#M-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-TryGetLegacyLogger-System-Type- 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher.TryGetLegacyLogger(System.Type)')
- [FileAppenderConfigurator](#T-xyLOGIX-Core-Debug-FileAppenderConfigurator 'xyLOGIX.Core.Debug.FileAppenderConfigurator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FileAppenderConfigurator-#cctor 'xyLOGIX.Core.Debug.FileAppenderConfigurator.#cctor')
  - [SetMinimalLock(appender)](#M-xyLOGIX-Core-Debug-FileAppenderConfigurator-SetMinimalLock-log4net-Appender-FileAppender- 'xyLOGIX.Core.Debug.FileAppenderConfigurator.SetMinimalLock(log4net.Appender.FileAppender)')
- [FileAppenderManager](#T-xyLOGIX-Core-Debug-FileAppenderManager 'xyLOGIX.Core.Debug.FileAppenderManager')
  - [GetAppenderByName(name)](#M-xyLOGIX-Core-Debug-FileAppenderManager-GetAppenderByName-System-String- 'xyLOGIX.Core.Debug.FileAppenderManager.GetAppenderByName(System.String)')
  - [GetFirstAppender(loggerRepository)](#M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstAppender-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.FileAppenderManager.GetFirstAppender(log4net.Repository.ILoggerRepository)')
  - [GetFirstFileAppender(appenders)](#M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstFileAppender-log4net-Appender-AppenderCollection- 'xyLOGIX.Core.Debug.FileAppenderManager.GetFirstFileAppender(log4net.Appender.AppenderCollection)')
  - [GetFirstFileAppenderByName(appenders,name)](#M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstFileAppenderByName-log4net-Appender-AppenderCollection,System-String- 'xyLOGIX.Core.Debug.FileAppenderManager.GetFirstFileAppenderByName(log4net.Appender.AppenderCollection,System.String)')
- [FileBasedXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator 'xyLOGIX.Core.Debug.FileBasedXmlLoggingConfigurator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-#ctor 'xyLOGIX.Core.Debug.FileBasedXmlLoggingConfigurator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-Instance 'xyLOGIX.Core.Debug.FileBasedXmlLoggingConfigurator.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-Type 'xyLOGIX.Core.Debug.FileBasedXmlLoggingConfigurator.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-#cctor 'xyLOGIX.Core.Debug.FileBasedXmlLoggingConfigurator.#cctor')
  - [Configure(repository,configurationFileName)](#M-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-Configure-log4net-Repository-ILoggerRepository,System-String- 'xyLOGIX.Core.Debug.FileBasedXmlLoggingConfigurator.Configure(log4net.Repository.ILoggerRepository,System.String)')
- [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus')
  - [NoDetermination](#F-xyLOGIX-Core-Debug-FileWriteabilityStatus-NoDetermination 'xyLOGIX.Core.Debug.FileWriteabilityStatus.NoDetermination')
  - [NotWriteable](#F-xyLOGIX-Core-Debug-FileWriteabilityStatus-NotWriteable 'xyLOGIX.Core.Debug.FileWriteabilityStatus.NotWriteable')
  - [Unknown](#F-xyLOGIX-Core-Debug-FileWriteabilityStatus-Unknown 'xyLOGIX.Core.Debug.FileWriteabilityStatus.Unknown')
  - [Writeable](#F-xyLOGIX-Core-Debug-FileWriteabilityStatus-Writeable 'xyLOGIX.Core.Debug.FileWriteabilityStatus.Writeable')
- [FileWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.FileWriteabilityStatusValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator-#ctor 'xyLOGIX.Core.Debug.FileWriteabilityStatusValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator-Instance 'xyLOGIX.Core.Debug.FileWriteabilityStatusValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator-#cctor 'xyLOGIX.Core.Debug.FileWriteabilityStatusValidator.#cctor')
  - [IsValid(status)](#M-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator-IsValid-xyLOGIX-Core-Debug-FileWriteabilityStatus- 'xyLOGIX.Core.Debug.FileWriteabilityStatusValidator.IsValid(xyLOGIX.Core.Debug.FileWriteabilityStatus)')
- [FromConfigFileLoggingConfigurator](#T-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator 'xyLOGIX.Core.Debug.FromConfigFileLoggingConfigurator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-#ctor 'xyLOGIX.Core.Debug.FromConfigFileLoggingConfigurator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-Instance 'xyLOGIX.Core.Debug.FromConfigFileLoggingConfigurator.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-Type 'xyLOGIX.Core.Debug.FromConfigFileLoggingConfigurator.Type')
  - [XmlLoggingConfiguratorTypeValidator](#P-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-XmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.FromConfigFileLoggingConfigurator.XmlLoggingConfiguratorTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-#cctor 'xyLOGIX.Core.Debug.FromConfigFileLoggingConfigurator.#cctor')
  - [Configure(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-Configure-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.FromConfigFileLoggingConfigurator.Configure(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
- [FromLogManagerRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner 'xyLOGIX.Core.Debug.FromLogManagerRootLoggerProvisioner')
  - [#ctor()](#M-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-#ctor 'xyLOGIX.Core.Debug.FromLogManagerRootLoggerProvisioner.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-Instance 'xyLOGIX.Core.Debug.FromLogManagerRootLoggerProvisioner.Instance')
  - [Strategy](#P-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-Strategy 'xyLOGIX.Core.Debug.FromLogManagerRootLoggerProvisioner.Strategy')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-#cctor 'xyLOGIX.Core.Debug.FromLogManagerRootLoggerProvisioner.#cctor')
  - [Provision(loggerRepository)](#M-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-Provision-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.FromLogManagerRootLoggerProvisioner.Provision(log4net.Repository.ILoggerRepository)')
- [FromProvidedLoggingRepositoryRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner 'xyLOGIX.Core.Debug.FromProvidedLoggingRepositoryRootLoggerProvisioner')
  - [#ctor()](#M-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-#ctor 'xyLOGIX.Core.Debug.FromProvidedLoggingRepositoryRootLoggerProvisioner.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-Instance 'xyLOGIX.Core.Debug.FromProvidedLoggingRepositoryRootLoggerProvisioner.Instance')
  - [Strategy](#P-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-Strategy 'xyLOGIX.Core.Debug.FromProvidedLoggingRepositoryRootLoggerProvisioner.Strategy')
  - [#cctor()](#M-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-#cctor 'xyLOGIX.Core.Debug.FromProvidedLoggingRepositoryRootLoggerProvisioner.#cctor')
  - [Provision(loggerRepository)](#M-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-Provision-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.FromProvidedLoggingRepositoryRootLoggerProvisioner.Provision(log4net.Repository.ILoggerRepository)')
- [GetAppenderManager](#T-xyLOGIX-Core-Debug-GetAppenderManager 'xyLOGIX.Core.Debug.GetAppenderManager')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetAppenderManager-SoleInstance 'xyLOGIX.Core.Debug.GetAppenderManager.SoleInstance')
- [GetAssembly](#T-xyLOGIX-Core-Debug-GetAssembly 'xyLOGIX.Core.Debug.GetAssembly')
  - [Pathname(assembly)](#M-xyLOGIX-Core-Debug-GetAssembly-Pathname-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.GetAssembly.Pathname(System.Reflection.Assembly)')
  - [ToUseForEventLogging()](#M-xyLOGIX-Core-Debug-GetAssembly-ToUseForEventLogging-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.GetAssembly.ToUseForEventLogging(System.Reflection.Assembly)')
- [GetConsoleOutputLocation](#T-xyLOGIX-Core-Debug-GetConsoleOutputLocation 'xyLOGIX.Core.Debug.GetConsoleOutputLocation')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetConsoleOutputLocation-SoleInstance 'xyLOGIX.Core.Debug.GetConsoleOutputLocation.SoleInstance')
- [GetDebugLevelValidator](#T-xyLOGIX-Core-Debug-GetDebugLevelValidator 'xyLOGIX.Core.Debug.GetDebugLevelValidator')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetDebugLevelValidator-SoleInstance 'xyLOGIX.Core.Debug.GetDebugLevelValidator.SoleInstance')
- [GetDebugOutputLocation](#T-xyLOGIX-Core-Debug-GetDebugOutputLocation 'xyLOGIX.Core.Debug.GetDebugOutputLocation')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetDebugOutputLocation-SoleInstance 'xyLOGIX.Core.Debug.GetDebugOutputLocation.SoleInstance')
- [GetDefaultLoggingInfrastructure](#T-xyLOGIX-Core-Debug-GetDefaultLoggingInfrastructure 'xyLOGIX.Core.Debug.GetDefaultLoggingInfrastructure')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetDefaultLoggingInfrastructure-SoleInstance 'xyLOGIX.Core.Debug.GetDefaultLoggingInfrastructure.SoleInstance')
- [GetDirectoryWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-GetDirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.GetDirectoryWriteabilityStatusValidator')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetDirectoryWriteabilityStatusValidator-SoleInstance 'xyLOGIX.Core.Debug.GetDirectoryWriteabilityStatusValidator.SoleInstance')
- [GetEvent](#T-xyLOGIX-Core-Debug-GetEvent 'xyLOGIX.Core.Debug.GetEvent')
  - [SourceAssembly()](#M-xyLOGIX-Core-Debug-GetEvent-SourceAssembly 'xyLOGIX.Core.Debug.GetEvent.SourceAssembly')
  - [SourceName()](#M-xyLOGIX-Core-Debug-GetEvent-SourceName 'xyLOGIX.Core.Debug.GetEvent.SourceName')
- [GetEventLogManager](#T-xyLOGIX-Core-Debug-GetEventLogManager 'xyLOGIX.Core.Debug.GetEventLogManager')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetEventLogManager-SoleInstance 'xyLOGIX.Core.Debug.GetEventLogManager.SoleInstance')
- [GetEventLogTypeValidator](#T-xyLOGIX-Core-Debug-GetEventLogTypeValidator 'xyLOGIX.Core.Debug.GetEventLogTypeValidator')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetEventLogTypeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetEventLogTypeValidator.SoleInstance')
- [GetExistingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-GetExistingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.GetExistingLoggerLoggingClientLoggerCacheAddHandler')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetExistingLoggerLoggingClientLoggerCacheAddHandler-#cctor 'xyLOGIX.Core.Debug.GetExistingLoggerLoggingClientLoggerCacheAddHandler.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetExistingLoggerLoggingClientLoggerCacheAddHandler-SoleInstance 'xyLOGIX.Core.Debug.GetExistingLoggerLoggingClientLoggerCacheAddHandler.SoleInstance')
- [GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher 'xyLOGIX.Core.Debug.GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-#cctor 'xyLOGIX.Core.Debug.GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-SoleInstance 'xyLOGIX.Core.Debug.GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.SoleInstance')
- [GetFetchFromCacheSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-GetFetchFromCacheSessionLoggerFetcher 'xyLOGIX.Core.Debug.GetFetchFromCacheSessionLoggerFetcher')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetFetchFromCacheSessionLoggerFetcher-#cctor 'xyLOGIX.Core.Debug.GetFetchFromCacheSessionLoggerFetcher.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetFetchFromCacheSessionLoggerFetcher-SoleInstance 'xyLOGIX.Core.Debug.GetFetchFromCacheSessionLoggerFetcher.SoleInstance')
- [GetFetchLegacyLoggerSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-GetFetchLegacyLoggerSessionLoggerFetcher 'xyLOGIX.Core.Debug.GetFetchLegacyLoggerSessionLoggerFetcher')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetFetchLegacyLoggerSessionLoggerFetcher-#cctor 'xyLOGIX.Core.Debug.GetFetchLegacyLoggerSessionLoggerFetcher.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetFetchLegacyLoggerSessionLoggerFetcher-SoleInstance 'xyLOGIX.Core.Debug.GetFetchLegacyLoggerSessionLoggerFetcher.SoleInstance')
- [GetFileBasedXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetFileBasedXmlLoggingConfigurator 'xyLOGIX.Core.Debug.GetFileBasedXmlLoggingConfigurator')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetFileBasedXmlLoggingConfigurator-SoleInstance 'xyLOGIX.Core.Debug.GetFileBasedXmlLoggingConfigurator.SoleInstance')
- [GetFileWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-GetFileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.GetFileWriteabilityStatusValidator')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetFileWriteabilityStatusValidator-SoleInstance 'xyLOGIX.Core.Debug.GetFileWriteabilityStatusValidator.SoleInstance')
- [GetFromConfigFileLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetFromConfigFileLoggingConfigurator 'xyLOGIX.Core.Debug.GetFromConfigFileLoggingConfigurator')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetFromConfigFileLoggingConfigurator-SoleInstance 'xyLOGIX.Core.Debug.GetFromConfigFileLoggingConfigurator.SoleInstance')
- [GetFromLogManagerRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-GetFromLogManagerRootLoggerProvisioner 'xyLOGIX.Core.Debug.GetFromLogManagerRootLoggerProvisioner')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetFromLogManagerRootLoggerProvisioner-SoleInstance 'xyLOGIX.Core.Debug.GetFromLogManagerRootLoggerProvisioner.SoleInstance')
- [GetFromProvidedLoggingRepositoryRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-GetFromProvidedLoggingRepositoryRootLoggerProvisioner 'xyLOGIX.Core.Debug.GetFromProvidedLoggingRepositoryRootLoggerProvisioner')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetFromProvidedLoggingRepositoryRootLoggerProvisioner-SoleInstance 'xyLOGIX.Core.Debug.GetFromProvidedLoggingRepositoryRootLoggerProvisioner.SoleInstance')
- [GetLog](#T-xyLOGIX-Core-Debug-GetLog 'xyLOGIX.Core.Debug.GetLog')
  - [FileName](#F-xyLOGIX-Core-Debug-GetLog-FileName 'xyLOGIX.Core.Debug.GetLog.FileName')
  - [FileFolder](#P-xyLOGIX-Core-Debug-GetLog-FileFolder 'xyLOGIX.Core.Debug.GetLog.FileFolder')
  - [FilePath](#P-xyLOGIX-Core-Debug-GetLog-FilePath 'xyLOGIX.Core.Debug.GetLog.FilePath')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLog-#cctor 'xyLOGIX.Core.Debug.GetLog.#cctor')
- [GetLoggingBackend](#T-xyLOGIX-Core-Debug-GetLoggingBackend 'xyLOGIX.Core.Debug.GetLoggingBackend')
  - [LoggingBackendTypeValidator](#P-xyLOGIX-Core-Debug-GetLoggingBackend-LoggingBackendTypeValidator 'xyLOGIX.Core.Debug.GetLoggingBackend.LoggingBackendTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingBackend-#cctor 'xyLOGIX.Core.Debug.GetLoggingBackend.#cctor')
  - [For(type,relay)](#M-xyLOGIX-Core-Debug-GetLoggingBackend-For-xyLOGIX-Core-Debug-LoggingBackendType,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.GetLoggingBackend.For(xyLOGIX.Core.Debug.LoggingBackendType,log4net.Repository.ILoggerRepository)')
- [GetLoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-GetLoggingBackendTypeValidator 'xyLOGIX.Core.Debug.GetLoggingBackendTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingBackendTypeValidator-#cctor 'xyLOGIX.Core.Debug.GetLoggingBackendTypeValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingBackendTypeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingBackendTypeValidator.SoleInstance')
- [GetLoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-GetLoggingClientAssemblyContext 'xyLOGIX.Core.Debug.GetLoggingClientAssemblyContext')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientAssemblyContext-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientAssemblyContext.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientAssemblyContext-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientAssemblyContext.SoleInstance')
- [GetLoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-GetLoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.GetLoggingClientAssemblyRegistry')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientAssemblyRegistry-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientAssemblyRegistry.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientAssemblyRegistry-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientAssemblyRegistry.SoleInstance')
- [GetLoggingClientLogProvider](#T-xyLOGIX-Core-Debug-GetLoggingClientLogProvider 'xyLOGIX.Core.Debug.GetLoggingClientLogProvider')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientLogProvider-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientLogProvider.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientLogProvider-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientLogProvider.SoleInstance')
- [GetLoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCache 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCache')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCache-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCache.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCache-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCache.SoleInstance')
- [GetLoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddActionValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddActionValidator-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddActionValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddActionValidator-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddActionValidator.SoleInstance')
- [GetLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandler')
  - [LoggingClientLoggerCacheAddHandlerTypeValidator](#P-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler-LoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandler.LoggingClientLoggerCacheAddHandlerTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandler.#cctor')
  - [ForHandlerType(handlerType)](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler-ForHandlerType-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType- 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandler.ForHandlerType(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType)')
- [GetLoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandlerTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandlerTypeValidator-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandlerTypeValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandlerTypeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandlerTypeValidator.SoleInstance')
- [GetLoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddOutcomeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddOutcomeValidator-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddOutcomeValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddOutcomeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddOutcomeValidator.SoleInstance')
- [GetLoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheKeyValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheKeyValidator-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheKeyValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheKeyValidator-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheKeyValidator.SoleInstance')
- [GetLoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-GetLoggingClientSessionRegistry 'xyLOGIX.Core.Debug.GetLoggingClientSessionRegistry')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingClientSessionRegistry-#cctor 'xyLOGIX.Core.Debug.GetLoggingClientSessionRegistry.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingClientSessionRegistry-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingClientSessionRegistry.SoleInstance')
- [GetLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetLoggingConfigurator 'xyLOGIX.Core.Debug.GetLoggingConfigurator')
  - [LoggingConfiguratorTypeValidator](#P-xyLOGIX-Core-Debug-GetLoggingConfigurator-LoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.GetLoggingConfigurator.LoggingConfiguratorTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingConfigurator-#cctor 'xyLOGIX.Core.Debug.GetLoggingConfigurator.#cctor')
  - [For(type)](#M-xyLOGIX-Core-Debug-GetLoggingConfigurator-For-xyLOGIX-Core-Debug-LoggingConfiguratorType- 'xyLOGIX.Core.Debug.GetLoggingConfigurator.For(xyLOGIX.Core.Debug.LoggingConfiguratorType)')
- [GetLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-GetLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.GetLoggingConfiguratorTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingConfiguratorTypeValidator-#cctor 'xyLOGIX.Core.Debug.GetLoggingConfiguratorTypeValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingConfiguratorTypeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingConfiguratorTypeValidator.SoleInstance')
- [GetLoggingInfrastructure](#T-xyLOGIX-Core-Debug-GetLoggingInfrastructure 'xyLOGIX.Core.Debug.GetLoggingInfrastructure')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-#cctor 'xyLOGIX.Core.Debug.GetLoggingInfrastructure.#cctor')
  - [OfType(type)](#M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-OfType-xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.GetLoggingInfrastructure.OfType(xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [GetLoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-GetLoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.GetLoggingInfrastructureTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetLoggingInfrastructureTypeValidator-#cctor 'xyLOGIX.Core.Debug.GetLoggingInfrastructureTypeValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetLoggingInfrastructureTypeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetLoggingInfrastructureTypeValidator.SoleInstance')
- [GetMissingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-GetMissingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.GetMissingLoggerLoggingClientLoggerCacheAddHandler')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetMissingLoggerLoggingClientLoggerCacheAddHandler-#cctor 'xyLOGIX.Core.Debug.GetMissingLoggerLoggingClientLoggerCacheAddHandler.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetMissingLoggerLoggingClientLoggerCacheAddHandler-SoleInstance 'xyLOGIX.Core.Debug.GetMissingLoggerLoggingClientLoggerCacheAddHandler.SoleInstance')
- [GetNoFileXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetNoFileXmlLoggingConfigurator 'xyLOGIX.Core.Debug.GetNoFileXmlLoggingConfigurator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetNoFileXmlLoggingConfigurator-#cctor 'xyLOGIX.Core.Debug.GetNoFileXmlLoggingConfigurator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetNoFileXmlLoggingConfigurator-SoleInstance 'xyLOGIX.Core.Debug.GetNoFileXmlLoggingConfigurator.SoleInstance')
- [GetNullLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-GetNullLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.GetNullLoggerLoggingClientLoggerCacheAddHandler')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetNullLoggerLoggingClientLoggerCacheAddHandler-#cctor 'xyLOGIX.Core.Debug.GetNullLoggerLoggingClientLoggerCacheAddHandler.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetNullLoggerLoggingClientLoggerCacheAddHandler-SoleInstance 'xyLOGIX.Core.Debug.GetNullLoggerLoggingClientLoggerCacheAddHandler.SoleInstance')
- [GetOutputLocation](#T-xyLOGIX-Core-Debug-GetOutputLocation 'xyLOGIX.Core.Debug.GetOutputLocation')
  - [OutputLocationTypeValidator](#P-xyLOGIX-Core-Debug-GetOutputLocation-OutputLocationTypeValidator 'xyLOGIX.Core.Debug.GetOutputLocation.OutputLocationTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetOutputLocation-#cctor 'xyLOGIX.Core.Debug.GetOutputLocation.#cctor')
  - [OfType(type)](#M-xyLOGIX-Core-Debug-GetOutputLocation-OfType-xyLOGIX-Core-Debug-OutputLocationType- 'xyLOGIX.Core.Debug.GetOutputLocation.OfType(xyLOGIX.Core.Debug.OutputLocationType)')
- [GetOutputLocationProvider](#T-xyLOGIX-Core-Debug-GetOutputLocationProvider 'xyLOGIX.Core.Debug.GetOutputLocationProvider')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetOutputLocationProvider-#cctor 'xyLOGIX.Core.Debug.GetOutputLocationProvider.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetOutputLocationProvider-SoleInstance 'xyLOGIX.Core.Debug.GetOutputLocationProvider.SoleInstance')
- [GetOutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-GetOutputLocationTypeValidator 'xyLOGIX.Core.Debug.GetOutputLocationTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetOutputLocationTypeValidator-#cctor 'xyLOGIX.Core.Debug.GetOutputLocationTypeValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetOutputLocationTypeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetOutputLocationTypeValidator.SoleInstance')
- [GetPatternLayout](#T-xyLOGIX-Core-Debug-GetPatternLayout 'xyLOGIX.Core.Debug.GetPatternLayout')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetPatternLayout-#cctor 'xyLOGIX.Core.Debug.GetPatternLayout.#cctor')
  - [ForConversionPattern(conversionPattern)](#M-xyLOGIX-Core-Debug-GetPatternLayout-ForConversionPattern-System-String- 'xyLOGIX.Core.Debug.GetPatternLayout.ForConversionPattern(System.String)')
- [GetPostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-GetPostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.GetPostSharpLoggingBackendRouter')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetPostSharpLoggingBackendRouter-#cctor 'xyLOGIX.Core.Debug.GetPostSharpLoggingBackendRouter.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetPostSharpLoggingBackendRouter-SoleInstance 'xyLOGIX.Core.Debug.GetPostSharpLoggingBackendRouter.SoleInstance')
- [GetPostSharpLoggingInfrastructure](#T-xyLOGIX-Core-Debug-GetPostSharpLoggingInfrastructure 'xyLOGIX.Core.Debug.GetPostSharpLoggingInfrastructure')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetPostSharpLoggingInfrastructure-#cctor 'xyLOGIX.Core.Debug.GetPostSharpLoggingInfrastructure.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetPostSharpLoggingInfrastructure-SoleInstance 'xyLOGIX.Core.Debug.GetPostSharpLoggingInfrastructure.SoleInstance')
- [GetProgrammaticLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetProgrammaticLoggingConfigurator 'xyLOGIX.Core.Debug.GetProgrammaticLoggingConfigurator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetProgrammaticLoggingConfigurator-#cctor 'xyLOGIX.Core.Debug.GetProgrammaticLoggingConfigurator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetProgrammaticLoggingConfigurator-SoleInstance 'xyLOGIX.Core.Debug.GetProgrammaticLoggingConfigurator.SoleInstance')
- [GetRollingModeValidator](#T-xyLOGIX-Core-Debug-GetRollingModeValidator 'xyLOGIX.Core.Debug.GetRollingModeValidator')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetRollingModeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetRollingModeValidator.SoleInstance')
- [GetRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-GetRootLoggerProvisioner 'xyLOGIX.Core.Debug.GetRootLoggerProvisioner')
  - [RootLoggerProvisioningStrategyValidator](#P-xyLOGIX-Core-Debug-GetRootLoggerProvisioner-RootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.GetRootLoggerProvisioner.RootLoggerProvisioningStrategyValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetRootLoggerProvisioner-#cctor 'xyLOGIX.Core.Debug.GetRootLoggerProvisioner.#cctor')
  - [For(strategy)](#M-xyLOGIX-Core-Debug-GetRootLoggerProvisioner-For-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy- 'xyLOGIX.Core.Debug.GetRootLoggerProvisioner.For(xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy)')
- [GetRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-GetRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.GetRootLoggerProvisioningStrategyValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetRootLoggerProvisioningStrategyValidator-#cctor 'xyLOGIX.Core.Debug.GetRootLoggerProvisioningStrategyValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetRootLoggerProvisioningStrategyValidator-SoleInstance 'xyLOGIX.Core.Debug.GetRootLoggerProvisioningStrategyValidator.SoleInstance')
- [GetSessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-GetSessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.GetSessionLoggerFetchApproachValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetSessionLoggerFetchApproachValidator-#cctor 'xyLOGIX.Core.Debug.GetSessionLoggerFetchApproachValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetSessionLoggerFetchApproachValidator-SoleInstance 'xyLOGIX.Core.Debug.GetSessionLoggerFetchApproachValidator.SoleInstance')
- [GetSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-GetSessionLoggerFetcher 'xyLOGIX.Core.Debug.GetSessionLoggerFetcher')
  - [SessionLoggerFetchApproachValidator](#P-xyLOGIX-Core-Debug-GetSessionLoggerFetcher-SessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.GetSessionLoggerFetcher.SessionLoggerFetchApproachValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetSessionLoggerFetcher-#cctor 'xyLOGIX.Core.Debug.GetSessionLoggerFetcher.#cctor')
  - [ForApproach(approach)](#M-xyLOGIX-Core-Debug-GetSessionLoggerFetcher-ForApproach-xyLOGIX-Core-Debug-SessionLoggerFetchApproach- 'xyLOGIX.Core.Debug.GetSessionLoggerFetcher.ForApproach(xyLOGIX.Core.Debug.SessionLoggerFetchApproach)')
- [GetTraceOutputLocation](#T-xyLOGIX-Core-Debug-GetTraceOutputLocation 'xyLOGIX.Core.Debug.GetTraceOutputLocation')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetTraceOutputLocation-#cctor 'xyLOGIX.Core.Debug.GetTraceOutputLocation.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetTraceOutputLocation-SoleInstance 'xyLOGIX.Core.Debug.GetTraceOutputLocation.SoleInstance')
- [GetXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator 'xyLOGIX.Core.Debug.GetXmlLoggingConfigurator')
  - [XmlLoggingConfiguratorTypeValidator](#P-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator-XmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.GetXmlLoggingConfigurator.XmlLoggingConfiguratorTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator-#cctor 'xyLOGIX.Core.Debug.GetXmlLoggingConfigurator.#cctor')
  - [For(type)](#M-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator-For-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType- 'xyLOGIX.Core.Debug.GetXmlLoggingConfigurator.For(xyLOGIX.Core.Debug.XmlLoggingConfiguratorType)')
- [GetXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-GetXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.GetXmlLoggingConfiguratorTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-GetXmlLoggingConfiguratorTypeValidator-#cctor 'xyLOGIX.Core.Debug.GetXmlLoggingConfiguratorTypeValidator.#cctor')
  - [SoleInstance()](#M-xyLOGIX-Core-Debug-GetXmlLoggingConfiguratorTypeValidator-SoleInstance 'xyLOGIX.Core.Debug.GetXmlLoggingConfiguratorTypeValidator.SoleInstance')
- [Has](#T-xyLOGIX-Core-Debug-Has 'xyLOGIX.Core.Debug.Has')
  - [IsWindowsGUI](#P-xyLOGIX-Core-Debug-Has-IsWindowsGUI 'xyLOGIX.Core.Debug.Has.IsWindowsGUI')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Has-#cctor 'xyLOGIX.Core.Debug.Has.#cctor')
  - [ConsoleWindow()](#M-xyLOGIX-Core-Debug-Has-ConsoleWindow 'xyLOGIX.Core.Debug.Has.ConsoleWindow')
  - [LoggingBeenSetUp()](#M-xyLOGIX-Core-Debug-Has-LoggingBeenSetUp 'xyLOGIX.Core.Debug.Has.LoggingBeenSetUp')
  - [WindowsGui(useEntryAssembly)](#M-xyLOGIX-Core-Debug-Has-WindowsGui-System-Boolean- 'xyLOGIX.Core.Debug.Has.WindowsGui(System.Boolean)')
- [IAppenderManager](#T-xyLOGIX-Core-Debug-IAppenderManager 'xyLOGIX.Core.Debug.IAppenderManager')
  - [AppenderCount](#P-xyLOGIX-Core-Debug-IAppenderManager-AppenderCount 'xyLOGIX.Core.Debug.IAppenderManager.AppenderCount')
  - [Appenders](#P-xyLOGIX-Core-Debug-IAppenderManager-Appenders 'xyLOGIX.Core.Debug.IAppenderManager.Appenders')
  - [HasAppenders](#P-xyLOGIX-Core-Debug-IAppenderManager-HasAppenders 'xyLOGIX.Core.Debug.IAppenderManager.HasAppenders')
  - [AddAppender(appender)](#M-xyLOGIX-Core-Debug-IAppenderManager-AddAppender-log4net-Appender-IAppender- 'xyLOGIX.Core.Debug.IAppenderManager.AddAppender(log4net.Appender.IAppender)')
  - [GetFileAppenderByPath(logFilePath)](#M-xyLOGIX-Core-Debug-IAppenderManager-GetFileAppenderByPath-System-String- 'xyLOGIX.Core.Debug.IAppenderManager.GetFileAppenderByPath(System.String)')
  - [HasAppenderWithFilePath(filePath)](#M-xyLOGIX-Core-Debug-IAppenderManager-HasAppenderWithFilePath-System-String- 'xyLOGIX.Core.Debug.IAppenderManager.HasAppenderWithFilePath(System.String)')
- [IDebugLevelValidator](#T-xyLOGIX-Core-Debug-IDebugLevelValidator 'xyLOGIX.Core.Debug.IDebugLevelValidator')
  - [IsValid(level)](#M-xyLOGIX-Core-Debug-IDebugLevelValidator-IsValid-xyLOGIX-Core-Debug-DebugLevel- 'xyLOGIX.Core.Debug.IDebugLevelValidator.IsValid(xyLOGIX.Core.Debug.DebugLevel)')
- [IDirectoryWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IDirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IDirectoryWriteabilityStatusValidator')
  - [IsValid(status)](#M-xyLOGIX-Core-Debug-IDirectoryWriteabilityStatusValidator-IsValid-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus- 'xyLOGIX.Core.Debug.IDirectoryWriteabilityStatusValidator.IsValid(xyLOGIX.Core.Debug.DirectoryWriteabilityStatus)')
- [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager')
  - [IsInitialized](#P-xyLOGIX-Core-Debug-IEventLogManager-IsInitialized 'xyLOGIX.Core.Debug.IEventLogManager.IsInitialized')
  - [Source](#P-xyLOGIX-Core-Debug-IEventLogManager-Source 'xyLOGIX.Core.Debug.IEventLogManager.Source')
  - [Type](#P-xyLOGIX-Core-Debug-IEventLogManager-Type 'xyLOGIX.Core.Debug.IEventLogManager.Type')
  - [Error(content)](#M-xyLOGIX-Core-Debug-IEventLogManager-Error-System-String- 'xyLOGIX.Core.Debug.IEventLogManager.Error(System.String)')
  - [Info(content)](#M-xyLOGIX-Core-Debug-IEventLogManager-Info-System-String- 'xyLOGIX.Core.Debug.IEventLogManager.Info(System.String)')
  - [Initialize(eventSourceName,logType)](#M-xyLOGIX-Core-Debug-IEventLogManager-Initialize-System-String,xyLOGIX-Core-Debug-EventLogType- 'xyLOGIX.Core.Debug.IEventLogManager.Initialize(System.String,xyLOGIX.Core.Debug.EventLogType)')
  - [Warn(content)](#M-xyLOGIX-Core-Debug-IEventLogManager-Warn-System-String- 'xyLOGIX.Core.Debug.IEventLogManager.Warn(System.String)')
- [IEventLogTypeValidator](#T-xyLOGIX-Core-Debug-IEventLogTypeValidator 'xyLOGIX.Core.Debug.IEventLogTypeValidator')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-IEventLogTypeValidator-IsValid-xyLOGIX-Core-Debug-EventLogType- 'xyLOGIX.Core.Debug.IEventLogTypeValidator.IsValid(xyLOGIX.Core.Debug.EventLogType)')
- [IFileWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IFileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IFileWriteabilityStatusValidator')
  - [IsValid(status)](#M-xyLOGIX-Core-Debug-IFileWriteabilityStatusValidator-IsValid-xyLOGIX-Core-Debug-FileWriteabilityStatus- 'xyLOGIX.Core.Debug.IFileWriteabilityStatusValidator.IsValid(xyLOGIX.Core.Debug.FileWriteabilityStatus)')
- [ILoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingBackendTypeValidator 'xyLOGIX.Core.Debug.ILoggingBackendTypeValidator')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-ILoggingBackendTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingBackendType- 'xyLOGIX.Core.Debug.ILoggingBackendTypeValidator.IsValid(xyLOGIX.Core.Debug.LoggingBackendType)')
- [ILoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext')
  - [CurrentTicket](#P-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext-CurrentTicket 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext.CurrentTicket')
  - [Clear()](#M-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext-Clear 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext.Clear')
  - [Select(ticket)](#M-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext-Select-System-Guid- 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext.Select(System.Guid)')
- [ILoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry')
  - [GetAssembly(ticket)](#M-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry-GetAssembly-System-Guid- 'xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry.GetAssembly(System.Guid)')
  - [GetTicket(assembly)](#M-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry-GetTicket-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry.GetTicket(System.Reflection.Assembly)')
  - [Register(assembly)](#M-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry-Register-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry.Register(System.Reflection.Assembly)')
- [ILoggingClientLogProvider](#T-xyLOGIX-Core-Debug-ILoggingClientLogProvider 'xyLOGIX.Core.Debug.ILoggingClientLogProvider')
  - [GetLogForType(sourceType)](#M-xyLOGIX-Core-Debug-ILoggingClientLogProvider-GetLogForType-System-Type- 'xyLOGIX.Core.Debug.ILoggingClientLogProvider.GetLogForType(System.Type)')
- [ILoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCache 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache')
  - [Count](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCache-Count 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache.Count')
  - [Clear()](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCache-Clear 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache.Clear')
  - [TryAdd(cacheKey,logger)](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCache-TryAdd-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog- 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache.TryAdd(xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey,log4net.ILog)')
  - [TryGet(cacheKey,logger)](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCache-TryGet-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog@- 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache.TryGet(xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey,log4net.ILog@)')
- [ILoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator')
  - [IsValid(action)](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction- 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator.IsValid(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction)')
- [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler')
  - [HandlerType](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler-HandlerType 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler.HandlerType')
  - [Handle()](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler-Handle 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler.Handle')
- [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType- 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator.IsValid(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType)')
- [ILoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator')
  - [IsValid(outcome)](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome- 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator.IsValid(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome)')
- [ILoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult')
  - [HandlerType](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult-HandlerType 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult.HandlerType')
  - [Outcome](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult-Outcome 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult.Outcome')
- [ILoggingClientLoggerCacheAddResultBuilder](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResultBuilder 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResultBuilder')
  - [AndOutcome(outcome)](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResultBuilder-AndOutcome-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome- 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResultBuilder.AndOutcome(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome)')
- [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey')
  - [LoggerName](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-LoggerName 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.LoggerName')
  - [Repository](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-Repository 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.Repository')
- [ILoggingClientLoggerCacheKeyBuilder](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyBuilder 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyBuilder')
  - [AndLoggerNamed(loggerName)](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyBuilder-AndLoggerNamed-System-String- 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyBuilder.AndLoggerNamed(System.String)')
- [ILoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator')
  - [IsValid(cacheKey)](#M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator-IsValid-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey- 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator.IsValid(xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey)')
- [ILoggingClientSession](#T-xyLOGIX-Core-Debug-ILoggingClientSession 'xyLOGIX.Core.Debug.ILoggingClientSession')
  - [Backend](#P-xyLOGIX-Core-Debug-ILoggingClientSession-Backend 'xyLOGIX.Core.Debug.ILoggingClientSession.Backend')
  - [ClientAssembly](#P-xyLOGIX-Core-Debug-ILoggingClientSession-ClientAssembly 'xyLOGIX.Core.Debug.ILoggingClientSession.ClientAssembly')
  - [Repository](#P-xyLOGIX-Core-Debug-ILoggingClientSession-Repository 'xyLOGIX.Core.Debug.ILoggingClientSession.Repository')
  - [RepositoryName](#P-xyLOGIX-Core-Debug-ILoggingClientSession-RepositoryName 'xyLOGIX.Core.Debug.ILoggingClientSession.RepositoryName')
  - [Ticket](#P-xyLOGIX-Core-Debug-ILoggingClientSession-Ticket 'xyLOGIX.Core.Debug.ILoggingClientSession.Ticket')
  - [Clear()](#M-xyLOGIX-Core-Debug-ILoggingClientSession-Clear 'xyLOGIX.Core.Debug.ILoggingClientSession.Clear')
  - [IsValid()](#M-xyLOGIX-Core-Debug-ILoggingClientSession-IsValid 'xyLOGIX.Core.Debug.ILoggingClientSession.IsValid')
- [ILoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry 'xyLOGIX.Core.Debug.ILoggingClientSessionRegistry')
  - [Get(ticket)](#M-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry-Get-System-Guid- 'xyLOGIX.Core.Debug.ILoggingClientSessionRegistry.Get(System.Guid)')
  - [GetOrCreate(ticket,clientAssembly)](#M-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry-GetOrCreate-System-Guid,System-Reflection-Assembly- 'xyLOGIX.Core.Debug.ILoggingClientSessionRegistry.GetOrCreate(System.Guid,System.Reflection.Assembly)')
- [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator')
  - [Type](#P-xyLOGIX-Core-Debug-ILoggingConfigurator-Type 'xyLOGIX.Core.Debug.ILoggingConfigurator.Type')
  - [Configure(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-ILoggingConfigurator-Configure-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.ILoggingConfigurator.Configure(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
- [ILoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingConfiguratorType- 'xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator.IsValid(xyLOGIX.Core.Debug.LoggingConfiguratorType)')
- [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure')
  - [LogFileName](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFileName 'xyLOGIX.Core.Debug.ILoggingInfrastructure.LogFileName')
  - [Type](#P-xyLOGIX-Core-Debug-ILoggingInfrastructure-Type 'xyLOGIX.Core.Debug.ILoggingInfrastructure.Type')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.ILoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.ILoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole)](#M-xyLOGIX-Core-Debug-ILoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean- 'xyLOGIX.Core.Debug.ILoggingInfrastructure.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean)')
- [ILoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator.IsValid(xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-IOutputLocation-MuteConsole 'xyLOGIX.Core.Debug.IOutputLocation.MuteConsole')
  - [Type](#P-xyLOGIX-Core-Debug-IOutputLocation-Type 'xyLOGIX.Core.Debug.IOutputLocation.Type')
  - [Write(value)](#M-xyLOGIX-Core-Debug-IOutputLocation-Write-System-Object- 'xyLOGIX.Core.Debug.IOutputLocation.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-IOutputLocation-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.IOutputLocation.Write(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine 'xyLOGIX.Core.Debug.IOutputLocation.WriteLine')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.IOutputLocation.WriteLine(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine-System-Object- 'xyLOGIX.Core.Debug.IOutputLocation.WriteLine(System.Object)')
- [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider')
  - [HasLocations](#P-xyLOGIX-Core-Debug-IOutputLocationProvider-HasLocations 'xyLOGIX.Core.Debug.IOutputLocationProvider.HasLocations')
  - [LocationCount](#P-xyLOGIX-Core-Debug-IOutputLocationProvider-LocationCount 'xyLOGIX.Core.Debug.IOutputLocationProvider.LocationCount')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsole 'xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole')
  - [AddOutputLocation(location)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-AddOutputLocation-xyLOGIX-Core-Debug-IOutputLocation- 'xyLOGIX.Core.Debug.IOutputLocationProvider.AddOutputLocation(xyLOGIX.Core.Debug.IOutputLocation)')
  - [Clear()](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-Clear 'xyLOGIX.Core.Debug.IOutputLocationProvider.Clear')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.IOutputLocationProvider.Write(System.String,System.Object[])')
  - [Write(value)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-Write-System-Object- 'xyLOGIX.Core.Debug.IOutputLocationProvider.Write(System.Object)')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine-System-Object- 'xyLOGIX.Core.Debug.IOutputLocationProvider.WriteLine(System.Object)')
  - [WriteLine(format,args)](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.IOutputLocationProvider.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine 'xyLOGIX.Core.Debug.IOutputLocationProvider.WriteLine')
- [IOutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-IOutputLocationTypeValidator 'xyLOGIX.Core.Debug.IOutputLocationTypeValidator')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-IOutputLocationTypeValidator-IsValid-xyLOGIX-Core-Debug-OutputLocationType- 'xyLOGIX.Core.Debug.IOutputLocationTypeValidator.IsValid(xyLOGIX.Core.Debug.OutputLocationType)')
- [IPostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter')
  - [FallbackRepository](#P-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter-FallbackRepository 'xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter.FallbackRepository')
  - [IsInstalled](#P-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter-IsInstalled 'xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter.IsInstalled')
  - [InstallOrUpdate(fallbackRepository)](#M-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter-InstallOrUpdate-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter.InstallOrUpdate(log4net.Repository.ILoggerRepository)')
- [IRollingFileAppenderConfiguration](#T-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration 'xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration')
  - [AppendToFile](#P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-AppendToFile 'xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.AppendToFile')
  - [File](#P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-File 'xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.File')
  - [Layout](#P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-Layout 'xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.Layout')
  - [MaxSizeRollBackups](#P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-MaxSizeRollBackups 'xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.MaxSizeRollBackups')
  - [MaximumFileSize](#P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-MaximumFileSize 'xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.MaximumFileSize')
  - [RollingStyle](#P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-RollingStyle 'xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.RollingStyle')
  - [StaticLogFileName](#P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-StaticLogFileName 'xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration.StaticLogFileName')
- [IRollingModeValidator](#T-xyLOGIX-Core-Debug-IRollingModeValidator 'xyLOGIX.Core.Debug.IRollingModeValidator')
  - [IsValid(mode)](#M-xyLOGIX-Core-Debug-IRollingModeValidator-IsValid-log4net-Appender-RollingFileAppender-RollingMode- 'xyLOGIX.Core.Debug.IRollingModeValidator.IsValid(log4net.Appender.RollingFileAppender.RollingMode)')
- [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner')
  - [Strategy](#P-xyLOGIX-Core-Debug-IRootLoggerProvisioner-Strategy 'xyLOGIX.Core.Debug.IRootLoggerProvisioner.Strategy')
  - [Provision(loggerRepository)](#M-xyLOGIX-Core-Debug-IRootLoggerProvisioner-Provision-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.IRootLoggerProvisioner.Provision(log4net.Repository.ILoggerRepository)')
- [IRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator')
  - [IsValid(strategy)](#M-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator-IsValid-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy- 'xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator.IsValid(xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy)')
- [ISessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator')
  - [IsValid(approach)](#M-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator-IsValid-xyLOGIX-Core-Debug-SessionLoggerFetchApproach- 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator.IsValid(xyLOGIX.Core.Debug.SessionLoggerFetchApproach)')
  - [IsValidSilent(approach)](#M-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator-IsValidSilent-xyLOGIX-Core-Debug-SessionLoggerFetchApproach- 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator.IsValidSilent(xyLOGIX.Core.Debug.SessionLoggerFetchApproach)')
- [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher')
  - [Approach](#P-xyLOGIX-Core-Debug-ISessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.ISessionLoggerFetcher.Approach')
  - [FetchLogger(sourceType,repositoryName)](#M-xyLOGIX-Core-Debug-ISessionLoggerFetcher-FetchLogger-System-Type,System-String- 'xyLOGIX.Core.Debug.ISessionLoggerFetcher.FetchLogger(System.Type,System.String)')
- [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator')
  - [Type](#P-xyLOGIX-Core-Debug-IXmlLoggingConfigurator-Type 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator.Type')
  - [Configure(repository,configurationFileName)](#M-xyLOGIX-Core-Debug-IXmlLoggingConfigurator-Configure-log4net-Repository-ILoggerRepository,System-String- 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator.Configure(log4net.Repository.ILoggerRepository,System.String)')
- [IXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator-IsValid-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType- 'xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator.IsValid(xyLOGIX.Core.Debug.XmlLoggingConfiguratorType)')
- [Initialize](#T-xyLOGIX-Core-Debug-Initialize 'xyLOGIX.Core.Debug.Initialize')
  - [#cctor()](#M-xyLOGIX-Core-Debug-Initialize-#cctor 'xyLOGIX.Core.Debug.Initialize.#cctor')
  - [Logging(applicationName)](#M-xyLOGIX-Core-Debug-Initialize-Logging-System-String- 'xyLOGIX.Core.Debug.Initialize.Logging(System.String)')
- [InvalidClientAssemblyNames](#T-xyLOGIX-Core-Debug-InvalidClientAssemblyNames 'xyLOGIX.Core.Debug.InvalidClientAssemblyNames')
  - [All](#F-xyLOGIX-Core-Debug-InvalidClientAssemblyNames-All 'xyLOGIX.Core.Debug.InvalidClientAssemblyNames.All')
  - [CoreTemplateLoggingWizards](#F-xyLOGIX-Core-Debug-InvalidClientAssemblyNames-CoreTemplateLoggingWizards 'xyLOGIX.Core.Debug.InvalidClientAssemblyNames.CoreTemplateLoggingWizards')
  - [#cctor()](#M-xyLOGIX-Core-Debug-InvalidClientAssemblyNames-#cctor 'xyLOGIX.Core.Debug.InvalidClientAssemblyNames.#cctor')
- [IsLog](#T-xyLOGIX-Core-Debug-IsLog 'xyLOGIX.Core.Debug.IsLog')
  - [Initialized](#P-xyLOGIX-Core-Debug-IsLog-Initialized 'xyLOGIX.Core.Debug.IsLog.Initialized')
- [LoggerManager](#T-xyLOGIX-Core-Debug-LoggerManager 'xyLOGIX.Core.Debug.LoggerManager')
  - [RootLoggerProvisioningStrategyValidator](#P-xyLOGIX-Core-Debug-LoggerManager-RootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.LoggerManager.RootLoggerProvisioningStrategyValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggerManager-#cctor 'xyLOGIX.Core.Debug.LoggerManager.#cctor')
  - [GetRootLogger(loggerRepository)](#M-xyLOGIX-Core-Debug-LoggerManager-GetRootLogger-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.LoggerManager.GetRootLogger(log4net.Repository.ILoggerRepository)')
- [LoggerRepositoryManager](#T-xyLOGIX-Core-Debug-LoggerRepositoryManager 'xyLOGIX.Core.Debug.LoggerRepositoryManager')
  - [InitialRepository](#P-xyLOGIX-Core-Debug-LoggerRepositoryManager-InitialRepository 'xyLOGIX.Core.Debug.LoggerRepositoryManager.InitialRepository')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggerRepositoryManager-#cctor 'xyLOGIX.Core.Debug.LoggerRepositoryManager.#cctor')
  - [GetHierarchyRepository()](#M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetHierarchyRepository 'xyLOGIX.Core.Debug.LoggerRepositoryManager.GetHierarchyRepository')
  - [GetLoggerRepository()](#M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetLoggerRepository 'xyLOGIX.Core.Debug.LoggerRepositoryManager.GetLoggerRepository')
- [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType')
  - [Console](#F-xyLOGIX-Core-Debug-LoggingBackendType-Console 'xyLOGIX.Core.Debug.LoggingBackendType.Console')
  - [Log4Net](#F-xyLOGIX-Core-Debug-LoggingBackendType-Log4Net 'xyLOGIX.Core.Debug.LoggingBackendType.Log4Net')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingBackendType-Unknown 'xyLOGIX.Core.Debug.LoggingBackendType.Unknown')
- [LoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-LoggingBackendTypeValidator 'xyLOGIX.Core.Debug.LoggingBackendTypeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingBackendTypeValidator-#ctor 'xyLOGIX.Core.Debug.LoggingBackendTypeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingBackendTypeValidator-Instance 'xyLOGIX.Core.Debug.LoggingBackendTypeValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingBackendTypeValidator-#cctor 'xyLOGIX.Core.Debug.LoggingBackendTypeValidator.#cctor')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-LoggingBackendTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingBackendType- 'xyLOGIX.Core.Debug.LoggingBackendTypeValidator.IsValid(xyLOGIX.Core.Debug.LoggingBackendType)')
- [LoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-LoggingClientAssemblyContext 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-#ctor 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext.#ctor')
  - [_currentTicket](#F-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-_currentTicket 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext._currentTicket')
  - [CurrentTicket](#P-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-CurrentTicket 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext.CurrentTicket')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-Instance 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-#cctor 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext.#cctor')
  - [Clear()](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-Clear 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext.Clear')
  - [Select(ticket)](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-Select-System-Guid- 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext.Select(System.Guid)')
- [LoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-#ctor 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.#ctor')
  - [_syncRoot](#F-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-_syncRoot 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry._syncRoot')
  - [_ticketsByAssembly](#F-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-_ticketsByAssembly 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry._ticketsByAssembly')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-Instance 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-#cctor 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.#cctor')
  - [GetAssembly(ticket)](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-GetAssembly-System-Guid- 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.GetAssembly(System.Guid)')
  - [GetTicket(assembly)](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-GetTicket-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.GetTicket(System.Reflection.Assembly)')
  - [Register(assembly)](#M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-Register-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.Register(System.Reflection.Assembly)')
- [LoggingClientLogProvider](#T-xyLOGIX-Core-Debug-LoggingClientLogProvider 'xyLOGIX.Core.Debug.LoggingClientLogProvider')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientLogProvider-#ctor 'xyLOGIX.Core.Debug.LoggingClientLogProvider.#ctor')
  - [ClientAssemblyContext](#P-xyLOGIX-Core-Debug-LoggingClientLogProvider-ClientAssemblyContext 'xyLOGIX.Core.Debug.LoggingClientLogProvider.ClientAssemblyContext')
  - [ClientSessionRegistry](#P-xyLOGIX-Core-Debug-LoggingClientLogProvider-ClientSessionRegistry 'xyLOGIX.Core.Debug.LoggingClientLogProvider.ClientSessionRegistry')
  - [CurrentClientAssemblyTicket](#P-xyLOGIX-Core-Debug-LoggingClientLogProvider-CurrentClientAssemblyTicket 'xyLOGIX.Core.Debug.LoggingClientLogProvider.CurrentClientAssemblyTicket')
  - [CurrentClientSession](#P-xyLOGIX-Core-Debug-LoggingClientLogProvider-CurrentClientSession 'xyLOGIX.Core.Debug.LoggingClientLogProvider.CurrentClientSession')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLogProvider-Instance 'xyLOGIX.Core.Debug.LoggingClientLogProvider.Instance')
  - [SessionLoggerFetchApproachValidator](#P-xyLOGIX-Core-Debug-LoggingClientLogProvider-SessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.LoggingClientLogProvider.SessionLoggerFetchApproachValidator')
  - [_sourceTypeFQNToLogMap](#P-xyLOGIX-Core-Debug-LoggingClientLogProvider-_sourceTypeFQNToLogMap 'xyLOGIX.Core.Debug.LoggingClientLogProvider._sourceTypeFQNToLogMap')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLogProvider-#cctor 'xyLOGIX.Core.Debug.LoggingClientLogProvider.#cctor')
  - [GetLogForType(sourceType)](#M-xyLOGIX-Core-Debug-LoggingClientLogProvider-GetLogForType-System-Type- 'xyLOGIX.Core.Debug.LoggingClientLogProvider.GetLogForType(System.Type)')
- [LoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCache 'xyLOGIX.Core.Debug.LoggingClientLoggerCache')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-#ctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.#ctor')
  - [_loggerMap](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCache-_loggerMap 'xyLOGIX.Core.Debug.LoggingClientLoggerCache._loggerMap')
  - [CacheKeyValidator](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-CacheKeyValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.CacheKeyValidator')
  - [Count](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-Count 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.Count')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.Instance')
  - [LoggingClientLoggerCacheAddActionValidator](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-LoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.LoggingClientLoggerCacheAddActionValidator')
  - [SyncRoot](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-SyncRoot 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.SyncRoot')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.#cctor')
  - [Clear()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-Clear 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.Clear')
  - [TryAdd(cacheKey,logger)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-TryAdd-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog- 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.TryAdd(xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey,log4net.ILog)')
  - [TryApplyCacheAddAction(action,cacheKey,logger)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-TryApplyCacheAddAction-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction,xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog- 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.TryApplyCacheAddAction(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction,xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey,log4net.ILog)')
  - [TryGet(cacheKey,logger)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-TryGet-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog@- 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.TryGet(xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey,log4net.ILog@)')
- [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction')
  - [AddLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-AddLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.AddLogger')
  - [PreserveExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-PreserveExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.PreserveExistingLogger')
  - [ReplaceNullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-ReplaceNullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.ReplaceNullLogger')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown')
- [LoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-#ctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator.#cctor')
  - [IsValid(action)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator.IsValid(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction)')
- [LoggingClientLoggerCacheAddHandlerBase](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-#ctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase.#ctor')
  - [Action](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-Action 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase.Action')
  - [ActionValidator](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-ActionValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase.ActionValidator')
  - [HandlerType](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-HandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase.HandlerType')
  - [HandlerTypeValidator](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-HandlerTypeValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase.HandlerTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase.#cctor')
  - [Handle()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-Handle 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase.Handle')
- [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType')
  - [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger')
  - [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger')
  - [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown')
- [LoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-#ctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator.#cctor')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator.IsValid(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType)')
- [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome')
  - [ExistingLoggerPreserved](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-ExistingLoggerPreserved 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.ExistingLoggerPreserved')
  - [LoggerAdded](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-LoggerAdded 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.LoggerAdded')
  - [LoggerUpdateFailed](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-LoggerUpdateFailed 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed')
  - [NullLoggerReplaced](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-NullLoggerReplaced 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.NullLoggerReplaced')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown')
- [LoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-#ctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator.#cctor')
  - [IsValid(outcome)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator.IsValid(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome)')
- [LoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult')
  - [#ctor(handlerType,outcome)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult-#ctor-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult.#ctor(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType,xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome)')
  - [HandlerType](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult-HandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult.HandlerType')
  - [Outcome](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult-Outcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult.Outcome')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult.#cctor')
- [LoggingClientLoggerCacheAddResultBuilder](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder')
  - [#ctor(handlerType)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-#ctor-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder.#ctor(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType)')
  - [HandlerType](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-HandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder.HandlerType')
  - [OutcomeValidator](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-OutcomeValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder.OutcomeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder.#cctor')
  - [AndOutcome(outcome)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-AndOutcome-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder.AndOutcome(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome)')
- [LoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey')
  - [#ctor(repository,loggerName)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-#ctor-log4net-Repository-ILoggerRepository,System-String- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.#ctor(log4net.Repository.ILoggerRepository,System.String)')
  - [HashCodeMultiplier](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-HashCodeMultiplier 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.HashCodeMultiplier')
  - [LoggerName](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-LoggerName 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.LoggerName')
  - [Repository](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-Repository 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Repository')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.#cctor')
  - [Equals(other)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-Equals-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Equals(xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey)')
  - [Equals(obj)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-Equals-System-Object- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Equals(System.Object)')
  - [GetHashCode()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-GetHashCode 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.GetHashCode')
- [LoggingClientLoggerCacheKeyBuilder](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder')
  - [#ctor(repository)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder-#ctor-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder.#ctor(log4net.Repository.ILoggerRepository)')
  - [Repository](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder-Repository 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder.Repository')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder.#cctor')
  - [AndLoggerNamed(loggerName)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder-AndLoggerNamed-System-String- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder.AndLoggerNamed(System.String)')
- [LoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-#ctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-#cctor 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator.#cctor')
  - [IsValid(cacheKey)](#M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-IsValid-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey- 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator.IsValid(xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey)')
- [LoggingClientRoutingAppender](#T-xyLOGIX-Core-Debug-LoggingClientRoutingAppender 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender')
  - [#ctor(routingRepository,fallbackRepository)](#M-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-#ctor-log4net-Repository-ILoggerRepository,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender.#ctor(log4net.Repository.ILoggerRepository,log4net.Repository.ILoggerRepository)')
  - [_isRouting](#F-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-_isRouting 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender._isRouting')
  - [FallbackRepository](#P-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-FallbackRepository 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender.FallbackRepository')
  - [RoutingRepository](#P-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-RoutingRepository 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender.RoutingRepository')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-#cctor 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender.#cctor')
  - [Append(loggingEvent)](#M-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-Append-log4net-Core-LoggingEvent- 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender.Append(log4net.Core.LoggingEvent)')
  - [GetTargetRepository()](#M-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-GetTargetRepository 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender.GetTargetRepository')
- [LoggingClientSession](#T-xyLOGIX-Core-Debug-LoggingClientSession 'xyLOGIX.Core.Debug.LoggingClientSession')
  - [#ctor(ticket,clientAssembly,repositoryName,repository,backend)](#M-xyLOGIX-Core-Debug-LoggingClientSession-#ctor-System-Guid,System-Reflection-Assembly,System-String,log4net-Repository-ILoggerRepository,PostSharp-Patterns-Diagnostics-LoggingBackend- 'xyLOGIX.Core.Debug.LoggingClientSession.#ctor(System.Guid,System.Reflection.Assembly,System.String,log4net.Repository.ILoggerRepository,PostSharp.Patterns.Diagnostics.LoggingBackend)')
  - [Backend](#P-xyLOGIX-Core-Debug-LoggingClientSession-Backend 'xyLOGIX.Core.Debug.LoggingClientSession.Backend')
  - [ClientAssembly](#P-xyLOGIX-Core-Debug-LoggingClientSession-ClientAssembly 'xyLOGIX.Core.Debug.LoggingClientSession.ClientAssembly')
  - [Repository](#P-xyLOGIX-Core-Debug-LoggingClientSession-Repository 'xyLOGIX.Core.Debug.LoggingClientSession.Repository')
  - [RepositoryName](#P-xyLOGIX-Core-Debug-LoggingClientSession-RepositoryName 'xyLOGIX.Core.Debug.LoggingClientSession.RepositoryName')
  - [Ticket](#P-xyLOGIX-Core-Debug-LoggingClientSession-Ticket 'xyLOGIX.Core.Debug.LoggingClientSession.Ticket')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientSession-#cctor 'xyLOGIX.Core.Debug.LoggingClientSession.#cctor')
  - [Clear()](#M-xyLOGIX-Core-Debug-LoggingClientSession-Clear 'xyLOGIX.Core.Debug.LoggingClientSession.Clear')
  - [IsValid()](#M-xyLOGIX-Core-Debug-LoggingClientSession-IsValid 'xyLOGIX.Core.Debug.LoggingClientSession.IsValid')
- [LoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-LoggingClientSessionRegistry 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-#ctor 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry.#ctor')
  - [_sessions](#F-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-_sessions 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry._sessions')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-Instance 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry.Instance')
  - [SyncRoot](#P-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-SyncRoot 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry.SyncRoot')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-#cctor 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry.#cctor')
  - [Get(ticket)](#M-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-Get-System-Guid- 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry.Get(System.Guid)')
  - [GetOrCreate(ticket,clientAssembly)](#M-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-GetOrCreate-System-Guid,System-Reflection-Assembly- 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry.GetOrCreate(System.Guid,System.Reflection.Assembly)')
- [LoggingConfiguratorBase](#T-xyLOGIX-Core-Debug-LoggingConfiguratorBase 'xyLOGIX.Core.Debug.LoggingConfiguratorBase')
  - [Type](#P-xyLOGIX-Core-Debug-LoggingConfiguratorBase-Type 'xyLOGIX.Core.Debug.LoggingConfiguratorBase.Type')
  - [Configure(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-LoggingConfiguratorBase-Configure-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.LoggingConfiguratorBase.Configure(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
- [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType')
  - [FromConfigFile](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-FromConfigFile 'xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile')
  - [Programmatic](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-Programmatic 'xyLOGIX.Core.Debug.LoggingConfiguratorType.Programmatic')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-Unknown 'xyLOGIX.Core.Debug.LoggingConfiguratorType.Unknown')
- [LoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.LoggingConfiguratorTypeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator-#ctor 'xyLOGIX.Core.Debug.LoggingConfiguratorTypeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator-Instance 'xyLOGIX.Core.Debug.LoggingConfiguratorTypeValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator-#cctor 'xyLOGIX.Core.Debug.LoggingConfiguratorTypeValidator.#cctor')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingConfiguratorType- 'xyLOGIX.Core.Debug.LoggingConfiguratorTypeValidator.IsValid(xyLOGIX.Core.Debug.LoggingConfiguratorType)')
- [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType')
  - [Default](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Default 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Default')
  - [PostSharp](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-PostSharp 'xyLOGIX.Core.Debug.LoggingInfrastructureType.PostSharp')
  - [Unknown](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Unknown 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Unknown')
- [LoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.LoggingInfrastructureTypeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator-#ctor 'xyLOGIX.Core.Debug.LoggingInfrastructureTypeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator-Instance 'xyLOGIX.Core.Debug.LoggingInfrastructureTypeValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator-#cctor 'xyLOGIX.Core.Debug.LoggingInfrastructureTypeValidator.#cctor')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.LoggingInfrastructureTypeValidator.IsValid(xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [LoggingSubsystemManager](#T-xyLOGIX-Core-Debug-LoggingSubsystemManager 'xyLOGIX.Core.Debug.LoggingSubsystemManager')
  - [AppenderManager](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-AppenderManager 'xyLOGIX.Core.Debug.LoggingSubsystemManager.AppenderManager')
  - [ClientAssemblyContext](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-ClientAssemblyContext 'xyLOGIX.Core.Debug.LoggingSubsystemManager.ClientAssemblyContext')
  - [ClientAssemblyRegistry](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-ClientAssemblyRegistry 'xyLOGIX.Core.Debug.LoggingSubsystemManager.ClientAssemblyRegistry')
  - [ClientSessionRegistry](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-ClientSessionRegistry 'xyLOGIX.Core.Debug.LoggingSubsystemManager.ClientSessionRegistry')
  - [CurrentClientAssembly](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientAssembly 'xyLOGIX.Core.Debug.LoggingSubsystemManager.CurrentClientAssembly')
  - [CurrentClientAssemblyTicket](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientAssemblyTicket 'xyLOGIX.Core.Debug.LoggingSubsystemManager.CurrentClientAssemblyTicket')
  - [CurrentClientBackend](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientBackend 'xyLOGIX.Core.Debug.LoggingSubsystemManager.CurrentClientBackend')
  - [CurrentClientRepository](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientRepository 'xyLOGIX.Core.Debug.LoggingSubsystemManager.CurrentClientRepository')
  - [CurrentClientSession](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientSession 'xyLOGIX.Core.Debug.LoggingSubsystemManager.CurrentClientSession')
  - [InfrastructureType](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-InfrastructureType 'xyLOGIX.Core.Debug.LoggingSubsystemManager.InfrastructureType')
  - [LogFileName](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-LogFileName 'xyLOGIX.Core.Debug.LoggingSubsystemManager.LogFileName')
  - [LoggingInfrastructure](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-LoggingInfrastructure 'xyLOGIX.Core.Debug.LoggingSubsystemManager.LoggingInfrastructure')
  - [LoggingInfrastructureTypeValidator](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-LoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.LoggingSubsystemManager.LoggingInfrastructureTypeValidator')
  - [PostSharpBackendRouter](#P-xyLOGIX-Core-Debug-LoggingSubsystemManager-PostSharpBackendRouter 'xyLOGIX.Core.Debug.LoggingSubsystemManager.PostSharpBackendRouter')
  - [#cctor()](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-#cctor 'xyLOGIX.Core.Debug.LoggingSubsystemManager.#cctor')
  - [EnsureCurrentClientSession()](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-EnsureCurrentClientSession 'xyLOGIX.Core.Debug.LoggingSubsystemManager.EnsureCurrentClientSession')
  - [GetDefaultBackendRepository()](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-GetDefaultBackendRepository 'xyLOGIX.Core.Debug.LoggingSubsystemManager.GetDefaultBackendRepository')
  - [GetLegacyRepositoryBeforeInitialization()](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-GetLegacyRepositoryBeforeInitialization 'xyLOGIX.Core.Debug.LoggingSubsystemManager.GetLegacyRepositoryBeforeInitialization')
  - [GetOrCreateCurrentClientSession()](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-GetOrCreateCurrentClientSession 'xyLOGIX.Core.Debug.LoggingSubsystemManager.GetOrCreateCurrentClientSession')
  - [GetRepositoryToConfigure()](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-GetRepositoryToConfigure 'xyLOGIX.Core.Debug.LoggingSubsystemManager.GetRepositoryToConfigure')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,infrastructureType)](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.LoggingSubsystemManager.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,xyLOGIX.Core.Debug.LoggingInfrastructureType)')
  - [ReconcilePostSharpBackendRouting(specializedSessionWasActive,legacyRepositoryBeforeInitialization)](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-ReconcilePostSharpBackendRouting-System-Boolean,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.LoggingSubsystemManager.ReconcilePostSharpBackendRouting(System.Boolean,log4net.Repository.ILoggerRepository)')
  - [RegisterAndSelectClientAssembly(assembly)](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-RegisterAndSelectClientAssembly-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.LoggingSubsystemManager.RegisterAndSelectClientAssembly(System.Reflection.Assembly)')
  - [RegisterClientAssembly(assembly)](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-RegisterClientAssembly-System-Reflection-Assembly- 'xyLOGIX.Core.Debug.LoggingSubsystemManager.RegisterClientAssembly(System.Reflection.Assembly)')
  - [SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole,infrastructureType)](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean,xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.LoggingSubsystemManager.SetUpDebugUtils(System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean,xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [MakeNewConsoleLoggingBackend](#T-xyLOGIX-Core-Debug-MakeNewConsoleLoggingBackend 'xyLOGIX.Core.Debug.MakeNewConsoleLoggingBackend')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MakeNewConsoleLoggingBackend-#cctor 'xyLOGIX.Core.Debug.MakeNewConsoleLoggingBackend.#cctor')
  - [FromScratch()](#M-xyLOGIX-Core-Debug-MakeNewConsoleLoggingBackend-FromScratch 'xyLOGIX.Core.Debug.MakeNewConsoleLoggingBackend.FromScratch')
- [MakeNewLog4NetLoggingBackend](#T-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend 'xyLOGIX.Core.Debug.MakeNewLog4NetLoggingBackend')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend-#cctor 'xyLOGIX.Core.Debug.MakeNewLog4NetLoggingBackend.#cctor')
  - [ForRelay(relay)](#M-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend-ForRelay-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.MakeNewLog4NetLoggingBackend.ForRelay(log4net.Repository.ILoggerRepository)')
  - [FromScratch()](#M-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend-FromScratch 'xyLOGIX.Core.Debug.MakeNewLog4NetLoggingBackend.FromScratch')
- [MakeNewLoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheAddResult')
  - [HandlerTypeValidator](#P-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult-HandlerTypeValidator 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheAddResult.HandlerTypeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult-#cctor 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheAddResult.#cctor')
  - [ForHandlerType(handlerType)](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult-ForHandlerType-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType- 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheAddResult.ForHandlerType(xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType)')
- [MakeNewLoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheKey')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheKey-#cctor 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheKey.#cctor')
  - [ForRepository(repository)](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheKey-ForRepository-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheKey.ForRepository(log4net.Repository.ILoggerRepository)')
- [MakeNewLoggingClientSession](#T-xyLOGIX-Core-Debug-MakeNewLoggingClientSession 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession')
  - [RepositoryNamePrefix](#F-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-RepositoryNamePrefix 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession.RepositoryNamePrefix')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-#cctor 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession.#cctor')
  - [FindRepository(repositoryName)](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-FindRepository-System-String- 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession.FindRepository(System.String)')
  - [FormulateRepositoryName(ticket,clientAssembly)](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-FormulateRepositoryName-System-Guid,System-Reflection-Assembly- 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession.FormulateRepositoryName(System.Guid,System.Reflection.Assembly)')
  - [From(ticket,clientAssembly)](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-From-System-Guid,System-Reflection-Assembly- 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession.From(System.Guid,System.Reflection.Assembly)')
  - [GetOrCreateRepository(repositoryName)](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-GetOrCreateRepository-System-String- 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession.GetOrCreateRepository(System.String)')
  - [TryCreateLoggerRepositoryNamed(repositoryName,repository)](#M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-TryCreateLoggerRepositoryNamed-System-String,log4net-Repository-ILoggerRepository@- 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession.TryCreateLoggerRepositoryNamed(System.String,log4net.Repository.ILoggerRepository@)')
- [MakeNewPatternLayout](#T-xyLOGIX-Core-Debug-MakeNewPatternLayout 'xyLOGIX.Core.Debug.MakeNewPatternLayout')
  - [HavingConversionPattern(conversionPattern)](#M-xyLOGIX-Core-Debug-MakeNewPatternLayout-HavingConversionPattern-System-String- 'xyLOGIX.Core.Debug.MakeNewPatternLayout.HavingConversionPattern(System.String)')
- [MakeNewRollingFileAppender](#T-xyLOGIX-Core-Debug-MakeNewRollingFileAppender 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender')
  - [RollingModeValidator](#P-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-RollingModeValidator 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.RollingModeValidator')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-#cctor 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.#cctor')
  - [AndMaximumNumberOfRollingBackups(self,maxSizeRollingBackups)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndMaximumNumberOfRollingBackups-log4net-Appender-RollingFileAppender,System-Int32- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.AndMaximumNumberOfRollingBackups(log4net.Appender.RollingFileAppender,System.Int32)')
  - [AndThatHasAStaticLogFileName(self,staticLogFileName)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndThatHasAStaticLogFileName-log4net-Appender-RollingFileAppender,System-Boolean- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.AndThatHasAStaticLogFileName(log4net.Appender.RollingFileAppender,System.Boolean)')
  - [ForRollingStyle(rollingStyle)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-ForRollingStyle-log4net-Appender-RollingFileAppender-RollingMode- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.ForRollingStyle(log4net.Appender.RollingFileAppender.RollingMode)')
  - [SetLogFileNameTo(self,file)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-SetLogFileNameTo-log4net-Appender-RollingFileAppender,System-String- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.SetLogFileNameTo(log4net.Appender.RollingFileAppender,System.String)')
  - [ThatShouldAppendToFile(self,appendToFile)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-ThatShouldAppendToFile-log4net-Appender-RollingFileAppender,System-Boolean- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.ThatShouldAppendToFile(log4net.Appender.RollingFileAppender,System.Boolean)')
  - [WithMaximumFileSizeOf(self,maximumFileSize)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-WithMaximumFileSizeOf-log4net-Appender-RollingFileAppender,System-String- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.WithMaximumFileSizeOf(log4net.Appender.RollingFileAppender,System.String)')
  - [WithPatternLayout(self,layout)](#M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-WithPatternLayout-log4net-Appender-RollingFileAppender,log4net-Layout-PatternLayout- 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender.WithPatternLayout(log4net.Appender.RollingFileAppender,log4net.Layout.PatternLayout)')
- [MissingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler')
  - [#ctor()](#M-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-#ctor 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler.#ctor')
  - [Action](#P-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-Action 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler.Action')
  - [HandlerType](#P-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-HandlerType 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler.HandlerType')
  - [Instance](#P-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-Instance 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-#cctor 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler.#cctor')
- [MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs')
  - [#ctor(newValue)](#M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#ctor-System-Boolean- 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs.#ctor(System.Boolean)')
  - [#ctor()](#M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#ctor 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs.#ctor')
  - [NewValue](#P-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-NewValue 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs.NewValue')
  - [#cctor()](#M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#cctor 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs.#cctor')
- [MuteConsoleChangedEventHandler](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventHandler 'xyLOGIX.Core.Debug.MuteConsoleChangedEventHandler')
- [NoFileXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator 'xyLOGIX.Core.Debug.NoFileXmlLoggingConfigurator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-#ctor 'xyLOGIX.Core.Debug.NoFileXmlLoggingConfigurator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-Instance 'xyLOGIX.Core.Debug.NoFileXmlLoggingConfigurator.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-Type 'xyLOGIX.Core.Debug.NoFileXmlLoggingConfigurator.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-#cctor 'xyLOGIX.Core.Debug.NoFileXmlLoggingConfigurator.#cctor')
  - [Configure(repository,configurationFileName)](#M-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-Configure-log4net-Repository-ILoggerRepository,System-String- 'xyLOGIX.Core.Debug.NoFileXmlLoggingConfigurator.Configure(log4net.Repository.ILoggerRepository,System.String)')
- [NullLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler')
  - [#ctor()](#M-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-#ctor 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler.#ctor')
  - [Action](#P-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-Action 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler.Action')
  - [HandlerType](#P-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-HandlerType 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler.HandlerType')
  - [Instance](#P-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-Instance 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-#cctor 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler.#cctor')
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
  - [HasLocations](#P-xyLOGIX-Core-Debug-OutputLocationProvider-HasLocations 'xyLOGIX.Core.Debug.OutputLocationProvider.HasLocations')
  - [Instance](#P-xyLOGIX-Core-Debug-OutputLocationProvider-Instance 'xyLOGIX.Core.Debug.OutputLocationProvider.Instance')
  - [InternalOutputLocationList](#P-xyLOGIX-Core-Debug-OutputLocationProvider-InternalOutputLocationList 'xyLOGIX.Core.Debug.OutputLocationProvider.InternalOutputLocationList')
  - [LocationCount](#P-xyLOGIX-Core-Debug-OutputLocationProvider-LocationCount 'xyLOGIX.Core.Debug.OutputLocationProvider.LocationCount')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationProvider-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationProvider.MuteConsole')
  - [#cctor()](#M-xyLOGIX-Core-Debug-OutputLocationProvider-#cctor 'xyLOGIX.Core.Debug.OutputLocationProvider.#cctor')
  - [AddOutputLocation(location)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-AddOutputLocation-xyLOGIX-Core-Debug-IOutputLocation- 'xyLOGIX.Core.Debug.OutputLocationProvider.AddOutputLocation(xyLOGIX.Core.Debug.IOutputLocation)')
  - [Clear()](#M-xyLOGIX-Core-Debug-OutputLocationProvider-Clear 'xyLOGIX.Core.Debug.OutputLocationProvider.Clear')
  - [InitializeInternalOutputLocationList()](#M-xyLOGIX-Core-Debug-OutputLocationProvider-InitializeInternalOutputLocationList 'xyLOGIX.Core.Debug.OutputLocationProvider.InitializeInternalOutputLocationList')
  - [OnMuteConsoleChanged(e)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-OnMuteConsoleChanged-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs- 'xyLOGIX.Core.Debug.OutputLocationProvider.OnMuteConsoleChanged(xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs)')
  - [Write(value)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-Write-System-Object- 'xyLOGIX.Core.Debug.OutputLocationProvider.Write(System.Object)')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputLocationProvider.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine-System-Object- 'xyLOGIX.Core.Debug.OutputLocationProvider.WriteLine(System.Object)')
  - [WriteLine(format,args)](#M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputLocationProvider.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine 'xyLOGIX.Core.Debug.OutputLocationProvider.WriteLine')
- [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType')
  - [Console](#F-xyLOGIX-Core-Debug-OutputLocationType-Console 'xyLOGIX.Core.Debug.OutputLocationType.Console')
  - [Debug](#F-xyLOGIX-Core-Debug-OutputLocationType-Debug 'xyLOGIX.Core.Debug.OutputLocationType.Debug')
  - [Trace](#F-xyLOGIX-Core-Debug-OutputLocationType-Trace 'xyLOGIX.Core.Debug.OutputLocationType.Trace')
  - [Unknown](#F-xyLOGIX-Core-Debug-OutputLocationType-Unknown 'xyLOGIX.Core.Debug.OutputLocationType.Unknown')
- [OutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-OutputLocationTypeValidator 'xyLOGIX.Core.Debug.OutputLocationTypeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-OutputLocationTypeValidator-#ctor 'xyLOGIX.Core.Debug.OutputLocationTypeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-OutputLocationTypeValidator-Instance 'xyLOGIX.Core.Debug.OutputLocationTypeValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-OutputLocationTypeValidator-#cctor 'xyLOGIX.Core.Debug.OutputLocationTypeValidator.#cctor')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-OutputLocationTypeValidator-IsValid-xyLOGIX-Core-Debug-OutputLocationType- 'xyLOGIX.Core.Debug.OutputLocationTypeValidator.IsValid(xyLOGIX.Core.Debug.OutputLocationType)')
- [OutputMultiplexer](#T-xyLOGIX-Core-Debug-OutputMultiplexer 'xyLOGIX.Core.Debug.OutputMultiplexer')
  - [MuteConsole](#P-xyLOGIX-Core-Debug-OutputMultiplexer-MuteConsole 'xyLOGIX.Core.Debug.OutputMultiplexer.MuteConsole')
  - [OutputLocationProvider](#P-xyLOGIX-Core-Debug-OutputMultiplexer-OutputLocationProvider 'xyLOGIX.Core.Debug.OutputMultiplexer.OutputLocationProvider')
  - [#cctor()](#M-xyLOGIX-Core-Debug-OutputMultiplexer-#cctor 'xyLOGIX.Core.Debug.OutputMultiplexer.#cctor')
  - [Write(format,arg)](#M-xyLOGIX-Core-Debug-OutputMultiplexer-Write-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputMultiplexer.Write(System.String,System.Object[])')
  - [WriteLine(value)](#M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine-System-Object- 'xyLOGIX.Core.Debug.OutputMultiplexer.WriteLine(System.Object)')
  - [WriteLine(format,arg)](#M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine-System-String,System-Object[]- 'xyLOGIX.Core.Debug.OutputMultiplexer.WriteLine(System.String,System.Object[])')
  - [WriteLine()](#M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine 'xyLOGIX.Core.Debug.OutputMultiplexer.WriteLine')
- [PostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter')
  - [#ctor()](#M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-#ctor 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.#ctor')
  - [RoutingRepositoryName](#F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-RoutingRepositoryName 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.RoutingRepositoryName')
  - [_routingAppender](#F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-_routingAppender 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter._routingAppender')
  - [_routingBackend](#F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-_routingBackend 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter._routingBackend')
  - [_routingRepository](#F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-_routingRepository 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter._routingRepository')
  - [_syncRoot](#F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-_syncRoot 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter._syncRoot')
  - [FallbackRepository](#P-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-FallbackRepository 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.FallbackRepository')
  - [Instance](#P-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-Instance 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.Instance')
  - [IsInstalled](#P-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-IsInstalled 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.IsInstalled')
  - [#cctor()](#M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-#cctor 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.#cctor')
  - [ConfigureRoutingRepository(repository,fallbackRepository)](#M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-ConfigureRoutingRepository-log4net-Repository-ILoggerRepository,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.ConfigureRoutingRepository(log4net.Repository.ILoggerRepository,log4net.Repository.ILoggerRepository)')
  - [FindRepository(repositoryName)](#M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-FindRepository-System-String- 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.FindRepository(System.String)')
  - [GetOrCreateRoutingRepository()](#M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-GetOrCreateRoutingRepository 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.GetOrCreateRoutingRepository')
  - [InstallOrUpdate(fallbackRepository)](#M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-InstallOrUpdate-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.InstallOrUpdate(log4net.Repository.ILoggerRepository)')
- [PostSharpLoggingInfrastructure](#T-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure')
  - [#ctor()](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-#ctor 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.#ctor')
  - [_relay](#F-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-_relay 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure._relay')
  - [Instance](#P-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-Instance 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-Type 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-#cctor 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.#cctor')
  - [FetchRelay()](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-FetchRelay 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.FetchRelay')
  - [GetRootFileAppenderFileName()](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-GetRootFileAppenderFileName 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.GetRootFileAppenderFileName')
  - [InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.InitializeLogging(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
  - [OnLoggingInitializationFinished(overwrite,repository)](#M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-OnLoggingInitializationFinished-System-Boolean,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure.OnLoggingInitializationFinished(System.Boolean,log4net.Repository.ILoggerRepository)')
- [ProgramFlowHelper](#T-xyLOGIX-Core-Debug-ProgramFlowHelper 'xyLOGIX.Core.Debug.ProgramFlowHelper')
  - [EmergencyStop()](#M-xyLOGIX-Core-Debug-ProgramFlowHelper-EmergencyStop 'xyLOGIX.Core.Debug.ProgramFlowHelper.EmergencyStop')
  - [StartDebugger()](#M-xyLOGIX-Core-Debug-ProgramFlowHelper-StartDebugger 'xyLOGIX.Core.Debug.ProgramFlowHelper.StartDebugger')
- [ProgrammaticLoggingConfigurator](#T-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator 'xyLOGIX.Core.Debug.ProgrammaticLoggingConfigurator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-#ctor 'xyLOGIX.Core.Debug.ProgrammaticLoggingConfigurator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-Instance 'xyLOGIX.Core.Debug.ProgrammaticLoggingConfigurator.Instance')
  - [Type](#P-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-Type 'xyLOGIX.Core.Debug.ProgrammaticLoggingConfigurator.Type')
  - [#cctor()](#M-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-#cctor 'xyLOGIX.Core.Debug.ProgrammaticLoggingConfigurator.#cctor')
  - [Configure(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFileName,verbosity,applicationName,repository)](#M-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-Configure-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.ProgrammaticLoggingConfigurator.Configure(System.Boolean,System.Boolean,System.String,System.Boolean,System.String,System.Int32,System.String,log4net.Repository.ILoggerRepository)')
- [Resources](#T-xyLOGIX-Core-Debug-Properties-Resources 'xyLOGIX.Core.Debug.Properties.Resources')
  - [Culture](#P-xyLOGIX-Core-Debug-Properties-Resources-Culture 'xyLOGIX.Core.Debug.Properties.Resources.Culture')
  - [Error_DepthMustBeNonNegative](#P-xyLOGIX-Core-Debug-Properties-Resources-Error_DepthMustBeNonNegative 'xyLOGIX.Core.Debug.Properties.Resources.Error_DepthMustBeNonNegative')
  - [Error_UnableFindAppConfigEntries](#P-xyLOGIX-Core-Debug-Properties-Resources-Error_UnableFindAppConfigEntries 'xyLOGIX.Core.Debug.Properties.Resources.Error_UnableFindAppConfigEntries')
  - [ExceptionMessageFormat](#P-xyLOGIX-Core-Debug-Properties-Resources-ExceptionMessageFormat 'xyLOGIX.Core.Debug.Properties.Resources.ExceptionMessageFormat')
  - [Regex_PathnameValidator_PathPattern](#P-xyLOGIX-Core-Debug-Properties-Resources-Regex_PathnameValidator_PathPattern 'xyLOGIX.Core.Debug.Properties.Resources.Regex_PathnameValidator_PathPattern')
  - [ResourceManager](#P-xyLOGIX-Core-Debug-Properties-Resources-ResourceManager 'xyLOGIX.Core.Debug.Properties.Resources.ResourceManager')
  - [TempExceptionFileMessage](#P-xyLOGIX-Core-Debug-Properties-Resources-TempExceptionFileMessage 'xyLOGIX.Core.Debug.Properties.Resources.TempExceptionFileMessage')
- [RollingModeValidator](#T-xyLOGIX-Core-Debug-RollingModeValidator 'xyLOGIX.Core.Debug.RollingModeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-RollingModeValidator-#ctor 'xyLOGIX.Core.Debug.RollingModeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-RollingModeValidator-Instance 'xyLOGIX.Core.Debug.RollingModeValidator.Instance')
  - [IsValid(mode)](#M-xyLOGIX-Core-Debug-RollingModeValidator-IsValid-log4net-Appender-RollingFileAppender-RollingMode- 'xyLOGIX.Core.Debug.RollingModeValidator.IsValid(log4net.Appender.RollingFileAppender.RollingMode)')
- [RootLoggerProvisionerBase](#T-xyLOGIX-Core-Debug-RootLoggerProvisionerBase 'xyLOGIX.Core.Debug.RootLoggerProvisionerBase')
  - [#ctor()](#M-xyLOGIX-Core-Debug-RootLoggerProvisionerBase-#ctor 'xyLOGIX.Core.Debug.RootLoggerProvisionerBase.#ctor')
  - [Strategy](#P-xyLOGIX-Core-Debug-RootLoggerProvisionerBase-Strategy 'xyLOGIX.Core.Debug.RootLoggerProvisionerBase.Strategy')
  - [ExecuteFallbackProvisioning()](#M-xyLOGIX-Core-Debug-RootLoggerProvisionerBase-ExecuteFallbackProvisioning 'xyLOGIX.Core.Debug.RootLoggerProvisionerBase.ExecuteFallbackProvisioning')
  - [Provision(loggerRepository)](#M-xyLOGIX-Core-Debug-RootLoggerProvisionerBase-Provision-log4net-Repository-ILoggerRepository- 'xyLOGIX.Core.Debug.RootLoggerProvisionerBase.Provision(log4net.Repository.ILoggerRepository)')
- [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy')
  - [FromLogManager](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager')
  - [FromProvidedLoggingRepository](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromProvidedLoggingRepository 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromProvidedLoggingRepository')
  - [Unknown](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-Unknown 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.Unknown')
- [RootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategyValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator-#ctor 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategyValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator-Instance 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategyValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator-#cctor 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategyValidator.#cctor')
  - [IsValid(strategy)](#M-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator-IsValid-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy- 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategyValidator.IsValid(xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy)')
- [SecretStringExtensions](#T-xyLOGIX-Core-Debug-SecretStringExtensions 'xyLOGIX.Core.Debug.SecretStringExtensions')
  - [CollapseNewlinesToSpaces(value)](#M-xyLOGIX-Core-Debug-SecretStringExtensions-CollapseNewlinesToSpaces-System-String- 'xyLOGIX.Core.Debug.SecretStringExtensions.CollapseNewlinesToSpaces(System.String)')
  - [EqualsAnyOfNoCase(value,list)](#M-xyLOGIX-Core-Debug-SecretStringExtensions-EqualsAnyOfNoCase-System-String,System-String[]- 'xyLOGIX.Core.Debug.SecretStringExtensions.EqualsAnyOfNoCase(System.String,System.String[])')
  - [IsAbsolutePath(path)](#M-xyLOGIX-Core-Debug-SecretStringExtensions-IsAbsolutePath-System-String- 'xyLOGIX.Core.Debug.SecretStringExtensions.IsAbsolutePath(System.String)')
- [ServiceFlowHelper](#T-xyLOGIX-Core-Debug-ServiceFlowHelper 'xyLOGIX.Core.Debug.ServiceFlowHelper')
  - [EmergencyStop(notificationAction)](#M-xyLOGIX-Core-Debug-ServiceFlowHelper-EmergencyStop-System-Action- 'xyLOGIX.Core.Debug.ServiceFlowHelper.EmergencyStop(System.Action)')
  - [OnDebuggerStartPending()](#M-xyLOGIX-Core-Debug-ServiceFlowHelper-OnDebuggerStartPending 'xyLOGIX.Core.Debug.ServiceFlowHelper.OnDebuggerStartPending')
  - [StartDebugger()](#M-xyLOGIX-Core-Debug-ServiceFlowHelper-StartDebugger 'xyLOGIX.Core.Debug.ServiceFlowHelper.StartDebugger')
- [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach')
  - [FetchByRepositoryNameAndSourceType](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchByRepositoryNameAndSourceType 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType')
  - [FetchFromCache](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchFromCache 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchFromCache')
  - [FetchLegacyLogger](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchLegacyLogger 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger')
  - [Unknown](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-Unknown 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.Unknown')
- [SessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-#ctor 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-Instance 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-#cctor 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator.#cctor')
  - [IsValid(approach)](#M-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-IsValid-xyLOGIX-Core-Debug-SessionLoggerFetchApproach- 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator.IsValid(xyLOGIX.Core.Debug.SessionLoggerFetchApproach)')
  - [IsValidSilent(approach)](#M-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-IsValidSilent-xyLOGIX-Core-Debug-SessionLoggerFetchApproach- 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator.IsValidSilent(xyLOGIX.Core.Debug.SessionLoggerFetchApproach)')
- [SessionLoggerFetcherBase](#T-xyLOGIX-Core-Debug-SessionLoggerFetcherBase 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase')
  - [#ctor()](#M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-#ctor 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase.#ctor')
  - [Approach](#P-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-Approach 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase.Approach')
  - [SyncRoot](#P-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-SyncRoot 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase.SyncRoot')
  - [_sourceTypeFQNToLogMap](#P-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-_sourceTypeFQNToLogMap 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase._sourceTypeFQNToLogMap')
  - [#cctor()](#M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-#cctor 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase.#cctor')
  - [ClearInternalCache()](#M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-ClearInternalCache 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase.ClearInternalCache')
  - [FetchLogger(sourceType,repositoryName)](#M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-FetchLogger-System-Type,System-String- 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase.FetchLogger(System.Type,System.String)')
  - [TryAddLoggerToInternalCache(sourceType,logger)](#M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-TryAddLoggerToInternalCache-System-Type,log4net-ILog- 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase.TryAddLoggerToInternalCache(System.Type,log4net.ILog)')
  - [TryGetLoggerFromInternalCache(sourceType)](#M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-TryGetLoggerFromInternalCache-System-Type- 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase.TryGetLoggerFromInternalCache(System.Type)')
- [SetLog](#T-xyLOGIX-Core-Debug-SetLog 'xyLOGIX.Core.Debug.SetLog')
  - [ApplicationName](#P-xyLOGIX-Core-Debug-SetLog-ApplicationName 'xyLOGIX.Core.Debug.SetLog.ApplicationName')
- [Setup](#T-xyLOGIX-Core-Debug-Setup 'xyLOGIX.Core.Debug.Setup')
  - [EventLogManager](#P-xyLOGIX-Core-Debug-Setup-EventLogManager 'xyLOGIX.Core.Debug.Setup.EventLogManager')
  - [DetermineEventSourceName(applicationName)](#M-xyLOGIX-Core-Debug-Setup-DetermineEventSourceName-System-String- 'xyLOGIX.Core.Debug.Setup.DetermineEventSourceName(System.String)')
  - [EventLogging(applicationName)](#M-xyLOGIX-Core-Debug-Setup-EventLogging-System-String- 'xyLOGIX.Core.Debug.Setup.EventLogging(System.String)')
- [SpecialVisualStudioProcessNames](#T-xyLOGIX-Core-Debug-SpecialVisualStudioProcessNames 'xyLOGIX.Core.Debug.SpecialVisualStudioProcessNames')
  - [DevEnv](#F-xyLOGIX-Core-Debug-SpecialVisualStudioProcessNames-DevEnv 'xyLOGIX.Core.Debug.SpecialVisualStudioProcessNames.DevEnv')
  - [#cctor()](#M-xyLOGIX-Core-Debug-SpecialVisualStudioProcessNames-#cctor 'xyLOGIX.Core.Debug.SpecialVisualStudioProcessNames.#cctor')
- [Split](#T-xyLOGIX-Core-Debug-Split 'xyLOGIX.Core.Debug.Split')
  - [CommandLineRegex](#P-xyLOGIX-Core-Debug-Split-CommandLineRegex 'xyLOGIX.Core.Debug.Split.CommandLineRegex')
  - [CommandLine(commandLine)](#M-xyLOGIX-Core-Debug-Split-CommandLine-System-String- 'xyLOGIX.Core.Debug.Split.CommandLine(System.String)')
- [TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs')
  - [#ctor(text,level)](#M-xyLOGIX-Core-Debug-TextEmittedEventArgs-#ctor-System-String,xyLOGIX-Core-Debug-DebugLevel- 'xyLOGIX.Core.Debug.TextEmittedEventArgs.#ctor(System.String,xyLOGIX.Core.Debug.DebugLevel)')
  - [Level](#P-xyLOGIX-Core-Debug-TextEmittedEventArgs-Level 'xyLOGIX.Core.Debug.TextEmittedEventArgs.Level')
  - [Text](#P-xyLOGIX-Core-Debug-TextEmittedEventArgs-Text 'xyLOGIX.Core.Debug.TextEmittedEventArgs.Text')
  - [#cctor()](#M-xyLOGIX-Core-Debug-TextEmittedEventArgs-#cctor 'xyLOGIX.Core.Debug.TextEmittedEventArgs.#cctor')
- [TextEmittedEventHandler](#T-xyLOGIX-Core-Debug-TextEmittedEventHandler 'xyLOGIX.Core.Debug.TextEmittedEventHandler')
- [TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs')
  - [#ctor(text)](#M-xyLOGIX-Core-Debug-TextWrittenEventArgs-#ctor-System-String- 'xyLOGIX.Core.Debug.TextWrittenEventArgs.#ctor(System.String)')
  - [Text](#P-xyLOGIX-Core-Debug-TextWrittenEventArgs-Text 'xyLOGIX.Core.Debug.TextWrittenEventArgs.Text')
  - [#cctor()](#M-xyLOGIX-Core-Debug-TextWrittenEventArgs-#cctor 'xyLOGIX.Core.Debug.TextWrittenEventArgs.#cctor')
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
- [Truncate](#T-xyLOGIX-Core-Debug-Truncate 'xyLOGIX.Core.Debug.Truncate')
  - [FileHavingPath(pathname)](#M-xyLOGIX-Core-Debug-Truncate-FileHavingPath-System-String- 'xyLOGIX.Core.Debug.Truncate.FileHavingPath(System.String)')
- [Validate](#T-xyLOGIX-Core-Debug-Validate 'xyLOGIX.Core.Debug.Validate')
  - [LoggingInfrastructureTypeValidator](#P-xyLOGIX-Core-Debug-Validate-LoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.Validate.LoggingInfrastructureTypeValidator')
  - [LoggingInfrastructureType(type)](#M-xyLOGIX-Core-Debug-Validate-LoggingInfrastructureType-xyLOGIX-Core-Debug-LoggingInfrastructureType- 'xyLOGIX.Core.Debug.Validate.LoggingInfrastructureType(xyLOGIX.Core.Debug.LoggingInfrastructureType)')
- [VerbosityChangedEventArgs](#T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs')
  - [#ctor(oldValue,newValue)](#M-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-#ctor-System-Int32,System-Int32- 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs.#ctor(System.Int32,System.Int32)')
  - [NewValue](#P-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-NewValue 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs.NewValue')
  - [OldValue](#P-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-OldValue 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs.OldValue')
  - [#cctor()](#M-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-#cctor 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs.#cctor')
- [VerbosityChangedEventHandler](#T-xyLOGIX-Core-Debug-VerbosityChangedEventHandler 'xyLOGIX.Core.Debug.VerbosityChangedEventHandler')
- [VsixHosting](#T-xyLOGIX-Core-Debug-VsixHosting 'xyLOGIX.Core.Debug.VsixHosting')
  - [_resolverInstalled](#F-xyLOGIX-Core-Debug-VsixHosting-_resolverInstalled 'xyLOGIX.Core.Debug.VsixHosting._resolverInstalled')
  - [#cctor()](#M-xyLOGIX-Core-Debug-VsixHosting-#cctor 'xyLOGIX.Core.Debug.VsixHosting.#cctor')
  - [EnsureAssemblyResolver()](#M-xyLOGIX-Core-Debug-VsixHosting-EnsureAssemblyResolver 'xyLOGIX.Core.Debug.VsixHosting.EnsureAssemblyResolver')
  - [GetContainingBaseDir()](#M-xyLOGIX-Core-Debug-VsixHosting-GetContainingBaseDir 'xyLOGIX.Core.Debug.VsixHosting.GetContainingBaseDir')
  - [GetDefaultVsixLogPath(assemblyTitle,productName)](#M-xyLOGIX-Core-Debug-VsixHosting-GetDefaultVsixLogPath-System-String,System-String- 'xyLOGIX.Core.Debug.VsixHosting.GetDefaultVsixLogPath(System.String,System.String)')
  - [IsVsixHost()](#M-xyLOGIX-Core-Debug-VsixHosting-IsVsixHost 'xyLOGIX.Core.Debug.VsixHosting.IsVsixHost')
  - [OnAssemblyResolve(sender,e)](#M-xyLOGIX-Core-Debug-VsixHosting-OnAssemblyResolve-System-Object,System-ResolveEventArgs- 'xyLOGIX.Core.Debug.VsixHosting.OnAssemblyResolve(System.Object,System.ResolveEventArgs)')
  - [TryDisposeProcess(process)](#M-xyLOGIX-Core-Debug-VsixHosting-TryDisposeProcess-System-Diagnostics-Process- 'xyLOGIX.Core.Debug.VsixHosting.TryDisposeProcess(System.Diagnostics.Process)')
  - [TryGetLog4NetConfigPath()](#M-xyLOGIX-Core-Debug-VsixHosting-TryGetLog4NetConfigPath 'xyLOGIX.Core.Debug.VsixHosting.TryGetLog4NetConfigPath')
- [Write](#T-xyLOGIX-Core-Debug-Write 'xyLOGIX.Core.Debug.Write')
  - [LogFileTimestamp()](#M-xyLOGIX-Core-Debug-Write-LogFileTimestamp 'xyLOGIX.Core.Debug.Write.LogFileTimestamp')
- [XmlLoggingConfiguratorBase](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorBase')
  - [#ctor()](#M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase-#ctor 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorBase.#ctor')
  - [Type](#P-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase-Type 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorBase.Type')
  - [Configure(repository,configurationFileName)](#M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase-Configure-log4net-Repository-ILoggerRepository,System-String- 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorBase.Configure(log4net.Repository.ILoggerRepository,System.String)')
- [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType')
  - [FileBased](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased')
  - [NoFile](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile')
  - [Unknown](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-Unknown 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.Unknown')
- [XmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorTypeValidator')
  - [#ctor()](#M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator-#ctor 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorTypeValidator.#ctor')
  - [Instance](#P-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator-Instance 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorTypeValidator.Instance')
  - [#cctor()](#M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator-#cctor 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorTypeValidator.#cctor')
  - [IsValid(type)](#M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator-IsValid-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType- 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorTypeValidator.IsValid(xyLOGIX.Core.Debug.XmlLoggingConfiguratorType)')

<a name='T-xyLOGIX-Core-Debug-Activate'></a>
## Activate `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to activate functionality, such as logging.

<a name='P-xyLOGIX-Core-Debug-Activate-AppenderManager'></a>
### AppenderManager `property`

##### Summary

Gets a reference to an instance of an object that implements the [IAppenderManager](#T-xyLOGIX-Core-Debug-IAppenderManager 'xyLOGIX.Core.Debug.IAppenderManager') interface.

<a name='M-xyLOGIX-Core-Debug-Activate-LoggingForLogFileName-System-String,log4net-Repository-ILoggerRepository-'></a>
### LoggingForLogFileName(logFileName,repository) `method`

##### Summary

Sets up logging programmatically (as opposed to using a `app.config` file), using the specified `logFileName` for the log and perhaps the provided log file `repository` (say, serving as a relay to PostSharp).

##### Returns

`true` if the operation(s) completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the log file that is to be written. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that plays the role of the `Hierarchy` object that is configured for logging. |

<a name='T-xyLOGIX-Core-Debug-AppDomainFriendlyNames'></a>
## AppDomainFriendlyNames `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') constant(s) that contain standardized friendly names for application domains.

<a name='F-xyLOGIX-Core-Debug-AppDomainFriendlyNames-LINQPad'></a>
### LINQPad `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the friendly name of the `AppDomain` for LINQPad.

##### Remarks

Such a value is used to detect when LINQPad is running this code.

<a name='T-xyLOGIX-Core-Debug-AppenderManager'></a>
## AppenderManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Manages the collection of `Appender`s that are currently in use with the logging subsystem.

<a name='M-xyLOGIX-Core-Debug-AppenderManager-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='F-xyLOGIX-Core-Debug-AppenderManager-_appenders'></a>
### _appenders `constants`

##### Summary

Collection mapping a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a log file pathname, to a reference to an instance(s) of object(s) that each implement the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface.

<a name='P-xyLOGIX-Core-Debug-AppenderManager-AppenderCount'></a>
### AppenderCount `property`

##### Summary

Gets the count of appenders in the internal collection.

<a name='P-xyLOGIX-Core-Debug-AppenderManager-Appenders'></a>
### Appenders `property`

##### Summary

Gets a reference to an instance of to an array of instances of objects that implement the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface, that are configured for use by the application.

<a name='P-xyLOGIX-Core-Debug-AppenderManager-HasAppenders'></a>
### HasAppenders `property`

##### Summary

Gets a value indicating whether the internal collection has more than zero element(s).

<a name='P-xyLOGIX-Core-Debug-AppenderManager-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IAppenderManager](#T-xyLOGIX-Core-Debug-IAppenderManager 'xyLOGIX.Core.Debug.IAppenderManager') interface.

<a name='M-xyLOGIX-Core-Debug-AppenderManager-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-AppenderManager-AddAppender-log4net-Appender-IAppender-'></a>
### AddAppender(appender) `method`

##### Summary

Adds a reference to an instance of an object that implements the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface to the list of configured appenders.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| appender | [log4net.Appender.IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') | (Required.) Reference to an instance of an object that implements the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface that is to be added to the internal collection. |

##### Remarks

If a `null` reference is passed as the argument of the `appender` parameter, then it is not added to the internal collection.



The specified `appender` is also not added to the internal collection if an `Appender` is already present that corresponds to the same file.



The specified `appender` must be of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') or a type that inherits it.

<a name='M-xyLOGIX-Core-Debug-AppenderManager-GetFileAppenderByPath-System-String-'></a>
### GetFileAppenderByPath(logFilePath) `method`

##### Summary

Attempts to look up the `Appender` whose `File` property matches the specified `logFilePath` (ignoring case).

##### Returns

If successful, a reference to an instance of an object that implements the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logFilePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of a file that is to be used to log messages. |

<a name='M-xyLOGIX-Core-Debug-AppenderManager-HasAppenderWithFilePath-System-String-'></a>
### HasAppenderWithFilePath(filePath) `method`

##### Summary

Determines whether an `Appender` is present that corresponds to the specified `filePath`.

##### Returns

`true` if an `Appender` is present that corresponds to the specified `filePath`; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of a file for which to search. |

##### Remarks

If a `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is passed as the argument of the `filePath` parameter, then the method returns `false`.



The method also returns `false` if the internal collection is currently empty.

<a name='T-xyLOGIX-Core-Debug-Ascertain'></a>
## Ascertain `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` method(s) that can be used to ascertain the state of an object or a value using business logic.

<a name='P-xyLOGIX-Core-Debug-Ascertain-LoggingClientLoggerCacheAddActionValidator'></a>
### LoggingClientLoggerCacheAddActionValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator') interface.

<a name='P-xyLOGIX-Core-Debug-Ascertain-LoggingClientLoggerCacheAddHandlerTypeValidator'></a>
### LoggingClientLoggerCacheAddHandlerTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface.

<a name='P-xyLOGIX-Core-Debug-Ascertain-LoggingClientLoggerCacheAddOutcomeValidator'></a>
### LoggingClientLoggerCacheAddOutcomeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-Ascertain-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [Ascertain](#T-xyLOGIX-Core-Debug-Ascertain 'xyLOGIX.Core.Debug.Ascertain') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Ascertain-TryMapLoggingClientLoggerCacheAddAction-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-'></a>
### TryMapLoggingClientLoggerCacheAddAction(handlerType) `method`

##### Summary

For a given logging-client logger cache `Add` handler type, `handlerType`, attempts to determine the corresponding logging-client logger cache `Add` action, which is represented as one of the value(s) of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration.

##### Returns

If successful, returns one of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') value(s) that indicates the corresponding logging-client logger cache `Add` action that we expect; otherwise, the [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown') value is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') value(s) that identifies the logging-client logger cache `Add` handler type whose corresponding action is to be determined. |

<a name='M-xyLOGIX-Core-Debug-Ascertain-WhetherAddHandlerTypeAndActionComboIsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-'></a>
### WhetherAddHandlerTypeAndActionComboIsValid(handlerType,action) `method`

##### Summary

Determines whether the particular combination of `handlerType` and `action` is valid for a logging-client logger-cache `Add` handler strategy.

##### Returns

`true` if the combination of `handlerType` and `action` is valid; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') value(s) that identifies the handler strategy whose action is being examined. |
| action | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') | (Required.) One of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') value(s) that identifies the action selected by the handler strategy. |

##### Remarks

The [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger') handler type is compatible only with the [PreserveExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-PreserveExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.PreserveExistingLogger') action.



The [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger') handler type is compatible only with the [AddLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-AddLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.AddLogger') action.



The [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger') handler type is compatible only with the [ReplaceNullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-ReplaceNullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.ReplaceNullLogger') action.

<a name='M-xyLOGIX-Core-Debug-Ascertain-WhetherAddHandlerTypeAndOutcomeComboIsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-'></a>
### WhetherAddHandlerTypeAndOutcomeComboIsValid(handlerType,outcome) `method`

##### Summary

Determines whether the particular combination of `handlerType` and `outcome` is valid, given the current state of the logging-client logger cache.

##### Returns

`true` if the combination of `handlerType` and `outcome` is valid; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') value(s) that identifies the handler strategy used for the cache-add operation. |
| outcome | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') | (Required.) One of the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') value(s) that describes the outcome of the cache-add operation. |

<a name='T-xyLOGIX-Core-Debug-CommandLineParameter'></a>
## CommandLineParameter `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Values for command-line parameters.

<a name='F-xyLOGIX-Core-Debug-CommandLineParameter-HaltOnException'></a>
### HaltOnException `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the text of the `Halt On Exception` command-line flag, which, if present, will force us to call the [StartDebugger](#M-xyLOGIX-Core-Debug-ProgramFlowHelper-StartDebugger 'xyLOGIX.Core.Debug.ProgramFlowHelper.StartDebugger') method when an exception is thrown.

<a name='F-xyLOGIX-Core-Debug-CommandLineParameter-SuppressOnException'></a>
### SuppressOnException `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the text of the `Suppress On Exception` command-line flag, which, if present, will stop us from calling the [StartDebugger](#M-xyLOGIX-Core-Debug-ProgramFlowHelper-StartDebugger 'xyLOGIX.Core.Debug.ProgramFlowHelper.StartDebugger') method when an exception is thrown.

<a name='T-xyLOGIX-Core-Debug-Compute'></a>
## Compute `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods for performing mathematical computations.

<a name='M-xyLOGIX-Core-Debug-Compute-ZeroFloor-System-Int32-'></a>
### ZeroFloor(value) `method`

##### Summary

Computes the zero floor. Meaning, if the specified `value` is negative, then this method returns zero.



If the specified `value` is zero or greater, then this method is the identity.

##### Returns

Zero if the specified `value` is negative; otherwise, if the specified `value` is zero or greater, then the method is the identity map.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Input value. |

<a name='T-xyLOGIX-Core-Debug-ConsoleOutputLocation'></a>
## ConsoleOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Writes debugging output to the standard output of the application and/or a console window, if present.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of the [ConsoleOutputLocation](#T-xyLOGIX-Core-Debug-ConsoleOutputLocation 'xyLOGIX.Core.Debug.ConsoleOutputLocation') class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-ConsoleOutputLocation-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the standard output of the application and/or a console window, if present.

<a name='P-xyLOGIX-Core-Debug-ConsoleOutputLocation-Type'></a>
### Type `property`

##### Summary

Gets one of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration values that indicates the final base of text strings that are fed to this location.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of [ConsoleOutputLocation](#T-xyLOGIX-Core-Debug-ConsoleOutputLocation 'xyLOGIX.Core.Debug.ConsoleOutputLocation') class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Remarks

It is allowable for the argument of the `value` parameter to be a `null` reference.



This method does nothing if the value of the [MuteConsole](#P-MuteConsole 'MuteConsole') property is set to `true`.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

This method takes no action if a `null`, blank, or empty [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is supplied as the argument of the `format` parameter.



This method will not work if the `format` parameter has format argument(s) in it, but the `arg` array is a `null` reference, contains a mismatching number of element(s), or if it contains element(s) whose value(s) do not match the format specifier(s) in the `format` parameter.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by the current line terminator, to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Remarks

It is allowable for the argument of the `value` parameter to be a `null` reference.



This method takes no action if the value of the [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole') property is set to `true`.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects, followed by the current line terminator, to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

This method takes no action if a `null`, blank, or empty [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is supplied as the argument of the `format` parameter.



This method will not work if the `format` parameter has format argument(s) in it, but the `arg` array is a `null` reference, contains a mismatching number of element(s), or if it contains element(s) whose value(s) do not match the format specifier(s) in the `format` parameter.



This method will not execute if the value of the [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole') property is set to `true`.

<a name='M-xyLOGIX-Core-Debug-ConsoleOutputLocation-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the output location.

##### Parameters

This method has no parameters.

##### Remarks

This method will not execute if the value of the [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole') property is set to `true`.

<a name='T-xyLOGIX-Core-Debug-DebugFileAndFolderHelper'></a>
## DebugFileAndFolderHelper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to work with files and folders in a robust way.

##### Remarks

These methods are here in order to assist applications in working with log files and prepping for application startup and first-time use.

<a name='P-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-DirectoryWriteabilityStatusValidator'></a>
### DirectoryWriteabilityStatusValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IDirectoryWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IDirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IDirectoryWriteabilityStatusValidator') interface.

<a name='P-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-FileWriteabilityStatusValidator'></a>
### FileWriteabilityStatusValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IFileWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IFileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IFileWriteabilityStatusValidator') interface.

<a name='P-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-FullyQualifiedUserName'></a>
### FullyQualifiedUserName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified username of the currently-logged-in OS user.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-ClearTempFileDir'></a>
### ClearTempFileDir() `method`

##### Summary

Attempts to clear the files and folders from the user's temporary files folder.

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
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the required parameter, `directoryPath`, is passed a blank or `null` value. |

##### Remarks

If the folder specified by the `directoryPath` parameter already exists on the filesystem, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-DetermineDirectoryWriteabilityStatus-System-Security-AccessControl-FileSystemAccessRule,System-Security-Principal-IdentityReferenceCollection,System-String-'></a>
### DetermineDirectoryWriteabilityStatus(r,groups,sidCurrentUser) `method`

##### Summary

Determines whether a folder having the `FileSystemAccessRule`, `r`, is NOT writeable by the user having the SID specified in `sidCurrentUser`, who is a member of the specified `groups`.

##### Returns

One of the [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') enumeration value(s) that indicates the results of the determination, or [NoDetermination](#F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-NoDetermination 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus.NoDetermination') if the `Directory Writeability Status` value could not be ascertained from the information available.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| r | [System.Security.AccessControl.FileSystemAccessRule](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.AccessControl.FileSystemAccessRule 'System.Security.AccessControl.FileSystemAccessRule') | (Required.) Reference to an instance of [FileSystemAccessRule](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.AccessControl.FileSystemAccessRule 'System.Security.AccessControl.FileSystemAccessRule') that is a rule that is to be checked. |
| groups | [System.Security.Principal.IdentityReferenceCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Principal.IdentityReferenceCollection 'System.Security.Principal.IdentityReferenceCollection') | (Required.) Reference to an instance of [IdentityReferenceCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Principal.IdentityReferenceCollection 'System.Security.Principal.IdentityReferenceCollection') that identifies the group(s) of which the user is a member. |
| sidCurrentUser | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the SID of the currently-logged-in user. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-DetermineFileWriteabilityStatus-System-Security-AccessControl-FileSystemAccessRule,System-Security-Principal-IdentityReferenceCollection,System-String-'></a>
### DetermineFileWriteabilityStatus(r,groups,sidCurrentUser) `method`

##### Summary

Determines whether a file system entry having the `FileSystemAccessRule`, `r`, is NOT writeable by the user having the SID specified in `sidCurrentUser`, who is a member of the specified `groups`.

##### Returns

One of the [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') enumeration value(s) that indicates the results of the determination, or [NoDetermination](#F-xyLOGIX-Core-Debug-FileWriteabilityStatus-NoDetermination 'xyLOGIX.Core.Debug.FileWriteabilityStatus.NoDetermination') if the `File Writeability Status` value could not be ascertained from the information available.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| r | [System.Security.AccessControl.FileSystemAccessRule](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.AccessControl.FileSystemAccessRule 'System.Security.AccessControl.FileSystemAccessRule') | (Required.) Reference to an instance of [FileSystemAccessRule](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.AccessControl.FileSystemAccessRule 'System.Security.AccessControl.FileSystemAccessRule') that is a rule that is to be checked. |
| groups | [System.Security.Principal.IdentityReferenceCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Principal.IdentityReferenceCollection 'System.Security.Principal.IdentityReferenceCollection') | (Required.) Reference to an instance of [IdentityReferenceCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.Principal.IdentityReferenceCollection 'System.Security.Principal.IdentityReferenceCollection') that identifies the group(s) of which the user is a member. |
| sidCurrentUser | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the SID of the currently-logged-in user. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-InsistPathExists-System-String-'></a>
### InsistPathExists() `method`

##### Summary

Checks to see if the specified file exists. If not, emits a "stop" error message and returns false; otherwise, returns true.

##### Returns

This method returns `true` if the file with path specified by the `fileName` parameter exists on the filesystem in the specified location or `false` if either the file is not found or if it does exist but an operating system error occurs (such as insufficient permissions) during the search.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFileReadOnly-System-String-'></a>
### IsFileReadOnly(pathname) `method`

##### Summary

Determines whether the file having the `pathname` is marked with the 'Read-Only' attribute.

##### Returns

`true` if the file having the `pathname` is marked with the 'Read-Only' attribute; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the file whose 'Read-Only' attribute is to be checked. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFileWriteable-System-String-'></a>
### IsFileWriteable(pathname) `method`

##### Summary

Checks for write access for the given file.

##### Returns

This method returns `true` if write access is allowed to the file with the specified `pathname`, otherwise `false`.



The value `false` is also returned in the event that the `pathname` parameter is a `null` value or blank.



The value `false` is also returned if an operating system error or exception occurs while trying to look up the file's permissions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the full pathname for which write permissions should be checked. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFolderReadOnly-System-String-'></a>
### IsFolderReadOnly(pathname) `method`

##### Summary

Determines whether the folder having the `pathname` is marked with the 'Read-Only' attribute.

##### Returns

`true` if the folder having the `pathname` is marked with the 'Read-Only' attribute; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the folder whose 'Read-Only' attribute is to be checked. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsFolderWriteable-System-String-'></a>
### IsFolderWriteable(pathname) `method`

##### Summary

Checks for write access for the given folder.

##### Returns

This method returns `true` if write access is allowed to the folder with the specified `pathname`, otherwise `false`.



The value `false` is also returned in the event that the `pathname` parameter is a `null` value or blank.



The value `false` is also returned if an operating system error or exception occurs while trying to look up the folder's permissions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the full pathname for which write permissions should be checked. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-IsValidPath-System-String-'></a>
### IsValidPath(fullyQualifiedPath) `method`

##### Summary

Gets a value indicating whether the `fullyQualifiedPath` is actually a valid path on the system, according to operating-system-specific rules.

##### Returns

If the path provided in `fullyQualifiedPath` is a valid path according to operating-system-specified rules, then this method returns `true`. Otherwise, the return value is `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fullyQualifiedPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the path that is to be validated. |

<a name='M-xyLOGIX-Core-Debug-DebugFileAndFolderHelper-RulesFoundForUser-System-Security-AccessControl-AuthorizationRuleCollection,System-String-'></a>
### RulesFoundForUser(rules,sidCurrentUser) `method`

##### Summary

Determines whether at least element of the specified collection of ACL `rules` pertains to the currently-logged-in user.

##### Returns

`true` if the specified `rules` collection contains at least one rule that pertains to the currently-logged-in user; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rules | [System.Security.AccessControl.AuthorizationRuleCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.AccessControl.AuthorizationRuleCollection 'System.Security.AccessControl.AuthorizationRuleCollection') | (Required.) Reference to an instance of [AuthorizationRuleCollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.AccessControl.AuthorizationRuleCollection 'System.Security.AccessControl.AuthorizationRuleCollection') that contains the rule(s) that are to be checked. |
| sidCurrentUser | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the SID of the currently-logged-in user. |

##### Remarks

This method returns `false` if a `null` reference is passed as the argument of the `rules` parameter, or if it contains zero element(s), or if the `sidCurrentUser` parameter is passed a `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.

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

<a name='T-xyLOGIX-Core-Debug-DebugLevelValidator'></a>
## DebugLevelValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration.

<a name='M-xyLOGIX-Core-Debug-DebugLevelValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-DebugLevelValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IDebugLevelValidator](#T-xyLOGIX-Core-Debug-Interfaces-IDebugLevelValidator 'xyLOGIX.Core.Debug.Interfaces.IDebugLevelValidator') interface.

<a name='M-xyLOGIX-Core-Debug-DebugLevelValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugLevelValidator-IsValid-xyLOGIX-Core-Debug-DebugLevel-'></a>
### IsValid(level) `method`

##### Summary

Determines whether the debug `level` value passed is within the value set that is defined by the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration.

##### Returns

`true` if the debug `level` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| level | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | (Required.) One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-DebugOutputLocation'></a>
## DebugOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Writes debugging output to the window in Visual Studio or whichever other debugger can listen to the output of the [Debug](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Debug 'System.Diagnostics.Debug') class' methods.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-DebugOutputLocation-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the window in Visual Studio or whichever other debugger can listen to the output of the [Debug](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Debug 'System.Diagnostics.Debug') class' methods.

<a name='P-xyLOGIX-Core-Debug-DebugOutputLocation-Type'></a>
### Type `property`

##### Summary

Gets one of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration values that indicates the final base of text strings that are fed to this location.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

If `format` is blank, or if a debugger is not attached and is not configured for logging, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Remarks

It is allowable for the argument of the `value` parameter to be a `null` reference.



If a debugger is not attached, or if logging is not enabled on the attached debugger, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by the current line terminator, to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Remarks

It is allowable for the argument of the `value` parameter to be a `null` reference.



If a debugger is not attached, or if logging is not enabled on the attached debugger, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects, followed by the current line terminator, to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

If `format` is blank, or if a debugger is not attached and is not configured for logging, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebugOutputLocation-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the output location.

##### Parameters

This method has no parameters.

##### Remarks

If a debugger is not attached, or if logging is not enabled on the attached debugger, then this method does nothing.

<a name='T-xyLOGIX-Core-Debug-DebugUtils'></a>
## DebugUtils `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Helpers to manage the writing of content to the debugging log.

##### Remarks

This class is one of the main object(s) exposed by this library.

<a name='F-xyLOGIX-Core-Debug-DebugUtils-_muteConsole'></a>
### _muteConsole `constants`

##### Summary

Value indicating whether no output should be sent to the console.

<a name='F-xyLOGIX-Core-Debug-DebugUtils-_verbosity'></a>
### _verbosity `constants`

##### Summary

The verbosity level.

##### Remarks

Typically, applications set this to 1.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ApplicationName'></a>
### ApplicationName `property`

##### Summary

Gets or sets the name of the application. Used for Windows event logging. Leave blank to not send events to the Application event log.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ClientLogProvider'></a>
### ClientLogProvider `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLogProvider](#T-xyLOGIX-Core-Debug-ILoggingClientLogProvider 'xyLOGIX.Core.Debug.ILoggingClientLogProvider') interface.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ConsoleOnly'></a>
### ConsoleOnly `property`

##### Summary

Gets or sets a value indicating whether the logging produced by this object should only be written to the console as opposed to a log file.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ExceptionLogPathname'></a>
### ExceptionLogPathname `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the pathname of a file to which error text is to be appended in the event where the `WriteLineCore` method catches an exception.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-ExcludedExceptionTypes'></a>
### ExcludedExceptionTypes `property`

##### Summary

Gets a list of [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value(s), each of which is the fully-qualified type name of an exception, for which we will NOT force the user into the Visual Studio JIT debugger.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-InfrastructureType'></a>
### InfrastructureType `property`

##### Summary

Gets or sets the depth down the call stack from which Exception information should be obtained.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-IsLogging'></a>
### IsLogging `property`

##### Summary

Gets or sets a value that turns logging as a whole on or off.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-IsPostSharp'></a>
### IsPostSharp `property`

##### Summary

Gets a value that indicates whether PostSharp is in use as the logging infrastructure.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-LogFileName'></a>
### LogFileName `property`

##### Summary

Users should set this property to the path to the log file, if logging.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value telling us to mute all console output.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode'></a>
### MuteDebugLevelIfReleaseMode `property`

##### Summary

Gets or sets a value indicating whether to mute "DEBUG" log messages in Release mode.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-Out'></a>
### Out `property`

##### Summary

Gets or sets a value that represents the spigot of text from that which is produced by calls to this class' methods.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-OutputLocationProvider'></a>
### OutputLocationProvider `property`

##### Summary

Gets a reference to an instance of an object that implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider') interface.

<a name='P-xyLOGIX-Core-Debug-DebugUtils-Verbosity'></a>
### Verbosity `property`

##### Summary

Gets or sets the verbosity level.

##### Remarks

Typically, applications set this to 1.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes a new static instance of [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils').

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-AppendText-System-String-'></a>
### AppendText(text) `method`

##### Summary

Appends the specified `text` directly to the file whose fully-qualified pathname is stored in the value of the [LogFileName](#P-xyLOGIX-Core-Debug-DebugUtils-LogFileName 'xyLOGIX.Core.Debug.DebugUtils.LogFileName') property, if that file exists and is writeable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the content that is to be appended to the log file. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-AppendToLog-System-String-'></a>
### AppendToLog(text) `method`

##### Summary

Appends the specified `text` directly to the file whose fully-qualified pathname is stored in the value of the [LogFileName](#P-xyLOGIX-Core-Debug-DebugUtils-LogFileName 'xyLOGIX.Core.Debug.DebugUtils.LogFileName') property, if that file exists and is writeable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the content that is to be appended to the log file. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-CanLaunchDebugger-System-Exception,System-Boolean-'></a>
### CanLaunchDebugger(exception,launchDebuggerConfigured) `method`

##### Summary

Determines whether the debugger can be launched from the [LogException](#M-xyLOGIX-Core-Debug-DebugUtils-LogException 'xyLOGIX.Core.Debug.DebugUtils.LogException') method.

##### Returns

`true` if the debugger is to be launched; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that corresponds to the particular exception that has been caught. |
| launchDebuggerConfigured | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | `true` if the user has specified that the debugger is to be launched when an exception is caught; `false` otherwise.    The default value of this parameter is `true`. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-ClearTempExceptionLog'></a>
### ClearTempExceptionLog() `method`

##### Summary

Erases the file having the fully-qualified pathname specified by the value of the [ExceptionLogPathname](#P-xyLOGIX-Core-Debug-DebugUtils-ExceptionLogPathname 'xyLOGIX.Core.Debug.DebugUtils.ExceptionLogPathname') property, if it is already present on the file system.

##### Returns

`true` if the file having the fully-qualified pathname specified by the value of the [ExceptionLogPathname](#P-xyLOGIX-Core-Debug-DebugUtils-ExceptionLogPathname 'xyLOGIX.Core.Debug.DebugUtils.ExceptionLogPathname') property was successfully deleted; `false` otherwise.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-DumpCollection-System-Collections-ICollection-'></a>
### DumpCollection(collection) `method`

##### Summary

Dumps a collection to the debug log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| collection | [System.Collections.ICollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.ICollection 'System.Collections.ICollection') | Reference to an instance of an object that implements the [ICollection](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.ICollection 'System.Collections.ICollection') interface. |

##### Remarks

If this method is passed a `null` for `collection` , then it does nothing. Otherwise, the method iterates over the `collection` and writes all of its elements to the log, one on each line.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-EchoCommandLinkText-System-Object-'></a>
### EchoCommandLinkText(commandLink) `method`

##### Summary

Writes the text of the selected control-- which is supposed to be a CommandLink -- to the log, while, at the same time, stripping out the text "recommended", if present, in the control's caption.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| commandLink | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Reference to an instance of an object that implements a Command Link. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the `commandLink` parameter is a passed a null reference. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-FormatException-System-Exception-'></a>
### FormatException(e) `method`

##### Summary

Structures the text of an [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception'), a reference to an instance of which is passed in the `e` parameter, to be the error message on a line by itself, followed by the stack trace lines on the subsequent lines.

##### Returns

String to be written to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Reference to a [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that should be formatted and dumped to the log. |

##### Remarks

If a `null` reference is passed for `e`, then this method returns the empty string.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-FormatExceptionAndWrite-System-Exception-'></a>
### FormatExceptionAndWrite(e) `method`

##### Summary

Takes the reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that is passed in the `e` parameter, formats it as a friendly error message along with its stack trace, and then dumps the result to the error log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | A [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') whose information is to be dumped. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-GenerateContentFromFormat-System-String,System-Object[]-'></a>
### GenerateContentFromFormat(format,args) `method`

##### Summary

Helper method to, basically, carry out the formatting of a string.

##### Returns

The string content of `format`, processed using the [Format](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Format 'System.String.Format') method.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String value to be formatted. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Array of format values. |

##### Remarks

The string content of the `format` parameter is left untouched if there are no `args`.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-IsExceptionSuppressed-System-Exception-'></a>
### IsExceptionSuppressed(exception) `method`

##### Summary

Determines whether the exception passed in the `exception` is not to be used to jump into the JIT debugger.

##### Returns

`true` if debugging of the specified `exception` is to be suppressed; `false` to allow the JIT debugger to be launched.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that refers to the exception object that is to be examined. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-LogEachLineIfMultiline-System-String,System-Action{xyLOGIX-Core-Debug-DebugLevel,System-String},xyLOGIX-Core-Debug-DebugLevel-'></a>
### LogEachLineIfMultiline(content,logMethod,level) `method`

##### Summary

Detects whether the `content` is multiline. If so, then each line of content is logged separately, using the `logMethod` supplied.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required. String containing the already-formatted content to be logged. |
| logMethod | [System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{xyLOGIX.Core.Debug.DebugLevel,System.String}') | (Required.) Delegate specifying the logging code that is to be executed for each line of content. |
| level | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | A [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') specifying the debugLevel of logging to utilize. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-LogException-System-Exception,System-Boolean-'></a>
### LogException(exception,launchDebugger) `method`

##### Summary

Logs the complete information about an exception to the log, under the Error Level. Outputs the quote file and line number where the exception occurred, as well as the message of the exception and its stack trace.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Reference to the [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') to be logged. |
| launchDebugger | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Optional.) Value indicating whether the launch and break the debugger (if one is attached) when this method is called.    The default value of this parameter is `true`.    It is advisable to explicitly set this parameter to `false` in most cases, especially when this method has the likelihood of getting called often.    The value of this parameter is ignored, and no launch of the attached debugger occurs, when `exception` is [TypeInitializationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TypeInitializationException 'System.TypeInitializationException') or [FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException'), which occur so frequently as to not be useful. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-OnExceptionLogged-System-Exception-'></a>
### OnExceptionLogged(ex) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DebugUtils-ExceptionLogged 'xyLOGIX.Core.Debug.DebugUtils.ExceptionLogged') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ex | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that is the exception that was just logged. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-OnTextEmitted-xyLOGIX-Core-Debug-TextEmittedEventArgs-'></a>
### OnTextEmitted(e) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DebugUtils-TextEmitted 'xyLOGIX.Core.Debug.DebugUtils.TextEmitted') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.Core.Debug.TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs') | (Required.) A [TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-Events-TextEmittedEventArgs 'xyLOGIX.Core.Debug.Events.TextEmittedEventArgs') that contains the event data. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-OnVerbosityChanged-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-'></a>
### OnVerbosityChanged() `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DebugUtils-VerbosityChanged 'xyLOGIX.Core.Debug.DebugUtils.VerbosityChanged') event.

##### Parameters

This method has no parameters.

##### Remarks

The [](#E-xyLOGIX-Core-Debug-DebugUtils-VerbosityChanged 'xyLOGIX.Core.Debug.DebugUtils.VerbosityChanged') event is raised whenever the value of the [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property is updated.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-OutputExceptionLoggingMessage-System-Exception,System-String-'></a>
### OutputExceptionLoggingMessage(exception,message) `method`

##### Summary

Actually performs the work of logging the specified `exception` to the log, using the specified `message`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that identifies the exception that is being logged. |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains a formatted message that is to be written to the log file. |

<a name='M-xyLOGIX-Core-Debug-DebugUtils-TryGetLogForCurrentClient-System-Type-'></a>
### TryGetLogForCurrentClient(sourceType) `method`

##### Summary

Gets a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface for the current logging-client session.

##### Returns

Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that identifies the source of the logging record(s). |

##### Remarks

If `sourceType` is `null`, or the logging-client log provider is unavailable, then this method returns `null`.



When no specialized session is active, the ordinary legacy log4net repository is utilized.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]-'></a>
### Write(debugLevel,format,args) `method`

##### Summary

Writes the content in `format` to the `debugLevel` log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') value(s) that indicates which log (DEBUG, ERROR, INFO, WARN) where the content should be written. |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format specifier for parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be included in the `format` and written to the log. |

##### Remarks

If the `format` parameter is a blank or empty string, then this method does nothing. If the `DEBUG` constant is not defined, then this method assumes that the application was built in Release mode. If this is so, then the method checks the value of the [MuteDebugLevelIfReleaseMode](#P-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode') property. If the property is set to true AND the `debugLevel` parameter is set to [Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug') , then this method does nothing. This method does not add a newline character after writing its content to the log.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-Write-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### Write(debugLevel,content) `method`

##### Summary

Writes non-formatted content to the log using the `debugLevel` specified. No line terminator is appended to the output.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') value(s) that indicates which log (`DEBUG`, `ERROR`, `INFO`, `WARN`) where the content should be written. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) string containing the content to be written. |

##### Remarks

If the `content` is a blank or empty string, then this method does nothing. This method's behavior is identical to that of [WriteCore](#M-xyLOGIX-Core-Debug-DebugUtils-WriteCore 'xyLOGIX.Core.Debug.DebugUtils.WriteCore'), except that a newline character is appended to the end of the content.



This method does nothing if the value specified for the `debugLevel` parameter is not within the defined value set of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration, or if the [Unknown](#F-xyLOGIX-Core-Debug-DebugLevel-Unknown 'xyLOGIX.Core.Debug.DebugLevel.Unknown') value is specified for the `debugLevel` parameter.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteCore-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteCore(debugLevel,content) `method`

##### Summary

Provides the implementation details of writing messages to the log. No line terminator is added to the content written.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') value(s) that determine what logging debugLevel to utilize. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the content to be written to the log file. |

##### Remarks

If the `content` parameter is a blank or empty string, then this method does nothing. If the `DEBUG` constant is not defined, then this method assumes that the application was built in Release mode. If this is so, then the method checks the value of the [MuteDebugLevelIfReleaseMode](#P-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode') property. If the property is set to true AND the `debugLevel` parameter is set to [Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug') , then this method does nothing. This method adds a newline character after writing its content to the log.



If the value of the `debugLevel` parameter is not within the defined value set of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration, or if it is set to [Unknown](#F-xyLOGIX-Core-Debug-DebugLevel-Unknown 'xyLOGIX.Core.Debug.DebugLevel.Unknown'), then this method, likewise, also takes no action.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String,System-Object[]-'></a>
### WriteLine(debugLevel,format,args) `method`

##### Summary

Writes the content in `format` to the `debugLevel` log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') value(s) that indicates which log (DEBUG, ERROR, INFO, WARN) where the content should be written. |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format specifier for parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be included in the `format` and written to the log. |

##### Remarks

If the `format` parameter is a blank or empty string, then this method does nothing. If the `DEBUG` constant is not defined, then this method assumes that the application was built in Release mode. If this is so, then the method checks the value of the [MuteDebugLevelIfReleaseMode](#P-Core-Debug-DebugUtils-MuteDebugLevelIfReleaseMode 'Core.Debug.DebugUtils.MuteDebugLevelIfReleaseMode') property. If the property is set to true AND the `debugLevel` parameter is set to [Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug') , then this method does nothing. This method adds a newline character after writing its content to the log.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,args) `method`

##### Summary

Works the same as the overload which takes a [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') as its first argument, but if the formatted content consists of several lines of content, then the lines are split and logged separately, all under the [Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug') debugLevel.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing an optional format specifier for parameters passed in `args`. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | (Optional.) Collection of objects whose values should be included in the `format` and written to the log. |

##### Remarks

If the value of the `format` parameter is `null`, a blank string, a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains only whitespace, or the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, then this method does nothing.



This overload specifies that the [Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug') logging debugLevel is to be utilized for each line.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLine-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteLine(debugLevel,content) `method`

##### Summary

Writes non-formatted content to the log using the `debugLevel` specified, terminated by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') value(s) that indicates which log (DEBUG, ERROR, INFO, WARN) where the content should be written. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) string containing the content to be written. |

##### Remarks

If the `content` is a blank or empty string, then this method does nothing. This method's behavior is identical to that of [WriteCore](#M-xyLOGIX-Core-Debug-DebugUtils-WriteCore 'xyLOGIX.Core.Debug.DebugUtils.WriteCore'), except that a newline character is appended to the end of the content.



This method does nothing if the value specified for the `debugLevel` parameter is not within the defined value set of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration, or if the [Unknown](#F-xyLOGIX-Core-Debug-DebugLevel-Unknown 'xyLOGIX.Core.Debug.DebugLevel.Unknown') value is specified for the `debugLevel` parameter.

<a name='M-xyLOGIX-Core-Debug-DebugUtils-WriteLineCore-xyLOGIX-Core-Debug-DebugLevel,System-String-'></a>
### WriteLineCore(debugLevel,content) `method`

##### Summary

Provides the implementation details of writing messages to the log, one line at a time.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| debugLevel | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') value(s) that determine what logging debugLevel to utilize. |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the content to be written to the log file. |

##### Remarks

This method will not do anything if the `content` is `null`, blank, or the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.



This method does nothing if the value specified for the `debugLevel` parameter is not within the defined value set of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration, or if the [Unknown](#F-xyLOGIX-Core-Debug-DebugLevel-Unknown 'xyLOGIX.Core.Debug.DebugLevel.Unknown') value is specified for the `debugLevel` parameter.

<a name='T-xyLOGIX-Core-Debug-DebuggerDump'></a>
## DebuggerDump `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to send objects to the log by calling an extension method called 'Dump', like in LINQpad.

##### Remarks

This class is part of the publicly-exposed API of this class library.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object-'></a>
### Dump(element) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |

##### Remarks

If a `null` reference is passed for `element`, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32-'></a>
### Dump(element,depth) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which the object should be dumped. |

##### Remarks

If a `null` reference is passed for `element`, or if `depth` is negative, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-Dump-System-Object,System-Int32,System-IO-TextWriter-'></a>
### Dump(element,depth,log) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which the object should be dumped. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is open on the target log file. |

##### Remarks

If a `null` reference is passed for either `element` or `log`, or if `depth` is negative, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object-'></a>
### DumpLines(element) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log, followed by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |

##### Remarks

If a `null` reference is passed for `element`, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32,System-IO-TextWriter-'></a>
### DumpLines(element,depth,log) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which the object should be dumped. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is open on the target log file. |

##### Remarks

If a `null` reference is passed for either `element` or `log`, or if `depth` is negative, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-DebuggerDump-DumpLines-System-Object,System-Int32-'></a>
### DumpLines(element,depth) `method`

##### Summary

Dumps the specified object, a reference to which is in the `element` parameter, to the log, followed by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the object whose contents are to be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth to which the object should be dumped. |

##### Remarks

If a `null` reference is passed for `element`, or if `depth` is negative, then this method does nothing.

<a name='T-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure'></a>
## DefaultLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Default implementation details for the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure').

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='F-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-_firstFileAppender'></a>
### _firstFileAppender `constants`

##### Summary

Represents the first file appender used for logging operations.

##### Remarks

This field is intended for internal use only and holds a reference to the primary [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') instance. It is initialized to its default value.

<a name='F-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-_logFilePathnameToUse'></a>
### _logFilePathnameToUse `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of the log file.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Appender'></a>
### Appender `property`

##### Summary

Gets a reference to an instance of [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') that represents the first file appender in the list of appenders maintained by the logging infrastructure.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface for the [Default](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Default 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Default') logging infrastructure type value.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-IsConsoleApp'></a>
### IsConsoleApp `property`

##### Summary

Gets a value indicating whether the current application is a console application.

##### Remarks

This property determines if the application has an associated console window by invoking the [GetConsoleWindow](#M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetConsoleWindow 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.GetConsoleWindow') method. If the method returns a non-zero pointer, the application is considered a console application. If an exception occurs during this process, the exception is logged, and the property returns `false`.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFileName'></a>
### LogFileName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the log file of this application.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LoggingConfiguratorTypeValidator'></a>
### LoggingConfiguratorTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator') interface.

<a name='P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') value that corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetConsoleWindow'></a>
### GetConsoleWindow() `method`

##### Summary

Retrieves the handle to the console window used by the calling process.

##### Returns

A handle to the console window associated with the calling process, or [Zero](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IntPtr.Zero 'System.IntPtr.Zero') if the process does not have a console window.

##### Parameters

This method has no parameters.

##### Remarks

If the calling process is not attached to a console, the return value is [Zero](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IntPtr.Zero 'System.IntPtr.Zero'). This function is useful for determining whether the current application is a console application and for interacting with the console window, such as resizing or hiding it.

##### See Also

- [MSDN Documentation for GetConsoleWindow](https://learn.microsoft.com/en-us/windows/console/getconsolewindow)

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the [File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the first appender in the list of appenders that is of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the appender is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the [LogFileName](#P-Core-Debug-ILoggingInfrastructure-LogFileName 'Core.Debug.ILoggingInfrastructure.LogFileName') property.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFilePathnameToUse,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Returns

`true` if the logging subsystem initialization process completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write out "DEBUG" messages to the Debug output when in the Release mode. Set to false if all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for initializing log4net. If blank, the system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the console if a log file is being used. If a log file is not used, then no logging at all will occur if this parameter is set to `true`. |
| logFilePathnameToUse | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the `XMLConfigurator` object is used to configure logging.    Else, specify here the path to the Debug output to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a user-friendly display name of the application that is using this logging library.    Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is to be configured for the current specialized logging-client session.    If `null`, the implementation utilizes its existing legacy repository-selection behavior. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-OnLogFileNameChanged'></a>
### OnLogFileNameChanged() `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFileNameChanged 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileNameChanged') event.

##### Parameters

This method has no parameters.

##### Remarks

This method is called when the value of the [LogFileName](#P-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LogFileName 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LogFileName') property is updated.

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-OnLoggingInitializationFinished-System-Boolean,log4net-Repository-ILoggerRepository-'></a>
### OnLoggingInitializationFinished(overwrite,repository) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LoggingInitializationFinished 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LoggingInitializationFinished') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface.    Supply a value for this parameter if your infrastructure is not utilizing the default `HierarchyRepository`.    The default value of this parameter is a `null` reference. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-PrepareLogFile-log4net-Repository-ILoggerRepository-'></a>
### PrepareLogFile(repository) `method`

##### Summary

Prepares the log file by ensuring that the containing folder is writeable by the current user and by then, if specified to overwrite, deleting the current log file.

##### Returns

`true` if the log file has been prepared successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. Supply a value for this parameter if your infrastructure is not utilizing the default HierarchicalRepository. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') class to initialize its functionality.

##### Returns

`true` if the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') class could be configured properly; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any logging statements that are set to the [Debug](#T-xyLOGIX-Core-Debug-DebugLevel-Debug 'xyLOGIX.Core.Debug.DebugLevel.Debug') level. |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log file; false to suppress. Usually used with the `consoleOnly` parameter set to true. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to write them both to the console and to the Debug output. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all console output. |

<a name='M-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-TryAscertainVsixSpecificLog4NetConfigFilePath-System-String,System-String@-'></a>
### TryAscertainVsixSpecificLog4NetConfigFilePath(defaultConfigFilePath,effectiveConfigurationFileName) `method`

##### Summary

Attempts to ascertain the fully-qualified pathname of a VSIX-specific log4net configuration file, if any, using the provided `defaultConfigFilePath` as a starting point.

##### Returns

`true` if a VSIX-specific log4net configuration file was found; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| defaultConfigFilePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that is set to the fully-qualified pathname of the default log4net configuration file.    If this parameter is `null`, blank, or the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, then the method will attempt to locate a VSIX-specific log4net configuration file. |
| effectiveConfigurationFileName | [System.String@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String@ 'System.String@') | (Output.) If found, receives the fully-qualified pathname of a VSIX-specific log4net configuration file; otherwise, receives the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value. |

##### Remarks

If this code is not being called from within a hosted VSIX package, then the method returns `false`, and the value of the `effectiveConfigurationFileName` parameter is set to the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.



This method attempts to ascertain whether this code is running inside an instance of Visual Studio (i.e., with `devenv` as the parent process) and, if so, then looks in the folder on the file system from which the current extension is presently running for a log4net configuration file.



If one is found, then the `effectiveConfigurationFileName` parameter is set to the fully-qualified pathname of such a file.



If a non-blank value is passed for the argument of the `defaultConfigFilePath` parameter, then the method simply sets the `effectiveConfigurationFileName` parameter to be identically equal to the value of the `defaultConfigFilePath` parameter.

<a name='T-xyLOGIX-Core-Debug-Delete'></a>
## Delete `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to delete files and folders.

<a name='M-xyLOGIX-Core-Debug-Delete-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [Delete](#T-xyLOGIX-Core-Debug-Delete 'xyLOGIX.Core.Debug.Delete') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Delete-FileIfExists-System-String-'></a>
### FileIfExists(pathname) `method`

##### Summary

Deletes the file having the specified `pathname`, if it exists.

##### Returns

`true` if the file having the specified `pathname` was found on the file system and successfully deleted; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of the file that is to be deleted. |

##### Remarks

If the `pathname` parameter is blank, the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, or `null`, then this method returns `false`.



This method also returns `false` if the file having the specified `pathname` does not already exist on the file system.

<a name='M-xyLOGIX-Core-Debug-Delete-FileIfExistsDo-System-String-'></a>
### FileIfExistsDo(pathname) `method`

##### Summary

Deletes the file having the specified `pathname`, if it exists.

##### Returns

`true` if the file having the specified `pathname` was found on the file system and successfully deleted; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of the file that is to be deleted. |

##### Remarks

If the `pathname` parameter is blank, the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, or `null`, then this method returns `false`.



This method also returns `true` if the file having the specified `pathname` does not already exist on the file system.



This version of the method only logs to the window of Visual Studio, and only when this software system is running in the Visual Studio Debugger.



It does not log to the log file, and it does not log when this software system is running outside of the Visual Studio Debugger.



This method is intended to be used in situations where the caller wants to attempt to delete a file, but does not care whether the file was actually deleted or not, and just wants to know whether the file was found on the file system or not.



In such cases, this method will log more information about what it is doing than the [FileIfExistsSilent](#M-xyLOGIX-Core-Debug-Delete-FileIfExistsSilent-System-String- 'xyLOGIX.Core.Debug.Delete.FileIfExistsSilent(System.String)') method, but it will only log that information to the window of Visual Studio, and only when this software system is running in the Visual Studio Debugger.

<a name='M-xyLOGIX-Core-Debug-Delete-FileIfExistsSilent-System-String-'></a>
### FileIfExistsSilent(pathname) `method`

##### Summary

Deletes the file having the specified `pathname`, if it exists.

##### Returns

`true` if the file having the specified `pathname` was found on the file system and successfully deleted; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of the file that is to be deleted. |

##### Remarks

If the `pathname` parameter is blank, the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, or `null`, then this method returns `false`.



This method also returns `false` if the file having the specified `pathname` does not already exist on the file system.

<a name='M-xyLOGIX-Core-Debug-Delete-LogFile-System-String-'></a>
### LogFile(pathname) `method`

##### Summary

Deletes a log file having the specified `pathname`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the fully-qualified pathname of the file that is to be deleted. |

##### Remarks

If the `pathname` parameter is blank or `null`, then this method does nothing.



This method also takes no action if the file having the specified `pathname` does not already exist on the file system.

<a name='T-xyLOGIX-Core-Debug-Derive'></a>
## Derive `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` method(s) that derive a value from one or more related input value(s).

##### Remarks

It is imperative that the methods of this class only be called from the code of either the [Determine](#T-xyLOGIX-Core-Debug-Determine 'xyLOGIX.Core.Debug.Determine') or [Ascertain](#T-xyLOGIX-Core-Debug-Ascertain 'xyLOGIX.Core.Debug.Ascertain') classes.

<a name='P-xyLOGIX-Core-Debug-Derive-LoggingClientLoggerCacheAddHandlerTypeValidator'></a>
### LoggingClientLoggerCacheAddHandlerTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-Derive-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [Derive](#T-xyLOGIX-Core-Debug-Derive 'xyLOGIX.Core.Debug.Derive') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Derive-LoggingClientLoggerCacheAddOutcomeFrom-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,System-Boolean-'></a>
### LoggingClientLoggerCacheAddOutcomeFrom(handlerType,addOperationSucceeded) `method`

##### Summary

Derives the logging-client logger-cache `Add` operation outcome that corresponds to the specified `handlerType` and `addOperationSucceeded` state.

##### Returns

If successful, one of the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') value(s) corresponding to the specified handler type and operation-success state; otherwise, [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown') is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') value(s) that identifies the handler strategy whose corresponding outcome is to be derived. |
| addOperationSucceeded | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value indicating whether the logging-client logger-cache `Add` operation succeeded. |

##### Remarks

The [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger') handler type has no failure outcome because it preserves an existing logger and performs no cache mutation.



The [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger') and [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger') handler types derive the [LoggerUpdateFailed](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-LoggerUpdateFailed 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.LoggerUpdateFailed') outcome when `addOperationSucceeded` is `false`.

<a name='T-xyLOGIX-Core-Debug-Determine'></a>
## Determine `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static method(s) to determine whether program flow is to follow a given path based on data, or other value(s) that are dependent on yet other data.

<a name='P-xyLOGIX-Core-Debug-Determine-AppenderManager'></a>
### AppenderManager `property`

##### Summary

Gets a reference to an instance of an object that implements the [IAppenderManager](#T-xyLOGIX-Core-Debug-IAppenderManager 'xyLOGIX.Core.Debug.IAppenderManager') interface.

<a name='P-xyLOGIX-Core-Debug-Determine-ClientAssemblyContext'></a>
### ClientAssemblyContext `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext') interface.

<a name='P-xyLOGIX-Core-Debug-Determine-ClientSessionRegistry'></a>
### ClientSessionRegistry `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry 'xyLOGIX.Core.Debug.ILoggingClientSessionRegistry') interface.

<a name='P-xyLOGIX-Core-Debug-Determine-CurrentClientAssemblyTicket'></a>
### CurrentClientAssemblyTicket `property`

##### Summary

Gets the ticket that identifies the logging-client assembly associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, the client-assembly context is unavailable, or the property cannot be evaluated, then this property returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

<a name='P-xyLOGIX-Core-Debug-Determine-CurrentClientSession'></a>
### CurrentClientSession `property`

##### Summary

Gets the logging-client session associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, or no session has been created for the selected ticket, this property returns `null`.

<a name='M-xyLOGIX-Core-Debug-Determine-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [Determine](#T-xyLOGIX-Core-Debug-Determine 'xyLOGIX.Core.Debug.Determine') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Determine-LoggingConfiguratorTypeToUse-System-String-'></a>
### LoggingConfiguratorTypeToUse(logFileName) `method`

##### Summary

Determines whether the application is to use a programmatic logging configurator or configure logging from either the `app.config` or `web.config` file(s).



It all hinges on whether a `logFileName` is already known at this juncture or not.

##### Returns

If the value of the `logFileName` parameter is not blank, then the [Programmatic](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-Programmatic 'xyLOGIX.Core.Debug.LoggingConfiguratorType.Programmatic') value is returned; otherwise, the [FromConfigFile](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-FromConfigFile 'xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile') value is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the programmatically-configured, fully-qualified pathname of the file to which logging is to be written. |

<a name='M-xyLOGIX-Core-Debug-Determine-TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse-System-Boolean,log4net-ILog-'></a>
### TheCorrectLoggingClientLoggerCacheAddHandlerTypeToUse(loggerWasFound,cachedLogger) `method`

##### Summary

Determines the correct [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the handler strategy to be utilized for the current state of a logging-client logger-cache entry.

##### Returns

One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value(s) that identifies the correct handler strategy to utilize; otherwise, [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown') is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerWasFound | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value that indicates whether an entry corresponding to the specified cache key was found. |
| cachedLogger | [log4net.ILog](#T-log4net-ILog 'log4net.ILog') | (Optional.) Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that was obtained from the cache. |

##### Remarks

If `loggerWasFound` is `false`, then this method returns [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger') .



If `loggerWasFound` is `true` and `cachedLogger` has a `null` reference for a value, then this method returns [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger') .



If `loggerWasFound` is `true` and `cachedLogger` has a valid object reference for a value, then this method returns [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger') .



If the correct handler strategy cannot be determined, or an error occurs, then this method returns [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown') .

<a name='M-xyLOGIX-Core-Debug-Determine-TheCorrectLoggingClientLoggerCacheAddOutcomeToUse-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,System-Boolean-'></a>
### TheCorrectLoggingClientLoggerCacheAddOutcomeToUse(handlerType,addOperationSucceeded) `method`

##### Summary

Determines the correct [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration value that corresponds to the specified logging-client logger-cache `Add` handler type and operation-success state.

##### Returns

If successful, one of the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration value(s) that corresponds to the specified handler type and operation-success state; otherwise, [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown') is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') value(s) that identifies the handler strategy utilized for the logging-client logger-cache `Add` operation. |
| addOperationSucceeded | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value that indicates whether the logging-client logger-cache `Add` operation succeeded. |

##### Remarks

This method delegates the derivation of the corresponding outcome to the [Derive](#T-xyLOGIX-Core-Debug-Derive 'xyLOGIX.Core.Debug.Derive') action class.



If the correct outcome cannot be determined, then this method returns [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown').

<a name='M-xyLOGIX-Core-Debug-Determine-TheCorrectRootLoggerProvisioningStrategyToUse-log4net-Repository-ILoggerRepository-'></a>
### TheCorrectRootLoggerProvisioningStrategyToUse(loggerRepository) `method`

##### Summary

Attempts to determine which of the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration value(s) most likely pertain to the situation at hand.

##### Returns

One of the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration value(s) that most likely pertains to the situation at hand, or the [Unknown](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-Unknown 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.Unknown') if such a value cannot be ascertained.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface.    Can be set to a `null` reference.    The default value of this parameter is a `null` reference. |

<a name='M-xyLOGIX-Core-Debug-Determine-TheCorrectSessionLoggerFetchApproachToUse-System-Type-'></a>
### TheCorrectSessionLoggerFetchApproachToUse(sourceType) `method`

##### Summary

Determines the correct [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that is to be returned, that corresponds to the correct approach that is to be utilized in getting a logger for the specified `sourceType`.

##### Returns

If successful, returns one of the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') value(s) that indicates the correct approach for fetching a logger that is to be used for the specified `sourceType`; otherwise, the [Unknown](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-Unknown 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.Unknown') value is returned if such an approach cannot be determined otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) A [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that contains the type of the object for which a logger is to be fetched. |

<a name='M-xyLOGIX-Core-Debug-Determine-TheCorrectXmlLoggingConfiguratorTypeToUse-System-String-'></a>
### TheCorrectXmlLoggingConfiguratorTypeToUse(configurationFileName) `method`

##### Summary

Determines the proper [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration value that is to be used to choose the XML-based logging subsystem configuration strategy, given the presence (or lack thereof) of an `app.config` or `web.config` file having the specified `configurationFileName`.

##### Returns

If successful, one of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration value(s) that is to be used to choose the XML-based logging subsystem configuration strategy, given the presence (or lack thereof) of an `app.config` or `web.config` file having the specified `configurationFileName`; if we cannot make this determination with the information provided, then the [Unknown](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-Unknown 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.Unknown') value is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the `app.config` or `web.config` that has logging-subsystem configuration setting(s) in it. |

<a name='T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus'></a>
## DirectoryWriteabilityStatus `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Value(s) that indicate whether a folder is writeable or not, or whether it cannot be determined from the information available.

<a name='F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-NoDetermination'></a>
### NoDetermination `constants`

##### Summary

No determination could be made as to whether the folder is writeable or not.

<a name='F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-NotWriteable'></a>
### NotWriteable `constants`

##### Summary

The folder is not writeable by the currently-logged-in user.

<a name='F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown writeability status.

<a name='F-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-Writeable'></a>
### Writeable `constants`

##### Summary

The folder is writeable by the currently-logged-in user.

<a name='T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator'></a>
## DirectoryWriteabilityStatusValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') enumeration.

<a name='M-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IDirectoryWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-Interfaces-IDirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.Interfaces.IDirectoryWriteabilityStatusValidator') interface.

<a name='M-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-DirectoryWriteabilityStatusValidator-IsValid-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-'></a>
### IsValid(status) `method`

##### Summary

Determines whether the directory writeability `status` value passed is within the value set that is defined by the [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') enumeration.

##### Returns

`true` if the directory writeability `status` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| status | [xyLOGIX.Core.Debug.DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') | (Required.) One of the [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-EmergencyStopPendingEventHandler'></a>
## EmergencyStopPendingEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `EmergencyStopPending` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.EmergencyStopPendingEventHandler](#T-T-xyLOGIX-Core-Debug-EmergencyStopPendingEventHandler 'T:xyLOGIX.Core.Debug.EmergencyStopPendingEventHandler') | A [CancelEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs 'System.ComponentModel.CancelEventArgs') that contains the event data.    Set the [Cancel](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.CancelEventArgs.Cancel 'System.ComponentModel.CancelEventArgs.Cancel') property to `true` to stop the pending operation. |

##### Remarks

This delegate merely specifies the signature of all methods that handle the `EmergencyStopPending` event.

<a name='T-xyLOGIX-Core-Debug-EventLogManager'></a>
## EventLogManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Class to manage access to the event log.

<a name='M-xyLOGIX-Core-Debug-EventLogManager-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-EventLogTypeValidator'></a>
### EventLogTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IEventLogTypeValidator](#T-xyLOGIX-Core-Debug-IEventLogTypeValidator 'xyLOGIX.Core.Debug.IEventLogTypeValidator') interface.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface that manages our access to the Windows System Event Logs.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-IsInitialized'></a>
### IsInitialized `property`

##### Summary

Gets a value indicating whether this object has been properly initialized.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-Source'></a>
### Source `property`

##### Summary

Gets or sets the quote of events. Typically, this is the name of the application that is sending the events.

##### Remarks

This property must be set before logging events, otherwise an error will occur.

<a name='P-xyLOGIX-Core-Debug-EventLogManager-Type'></a>
### Type `property`

##### Summary

Gets or sets the type of log to which events are to be sent (Application, System, Security, etc.).

##### Remarks

This property must be set before logging events, otherwise an error will occur.

<a name='M-xyLOGIX-Core-Debug-EventLogManager-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Error-System-String-'></a>
### Error(content) `method`

##### Summary

Sends an Error event to the system event log pointed to by the [Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and [Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The content of the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String specifying the content of the event log message. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Info-System-String-'></a>
### Info(content) `method`

##### Summary

Sends an Info event to the system event log pointed to by the [Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and [Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The content of the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String specifying the content of the event log message. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Initialize-System-String,xyLOGIX-Core-Debug-EventLogType-'></a>
### Initialize(eventSourceName,logType) `method`

##### Summary

Initializes event logging for your application.

##### Returns

`true` if the operation(s) completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name of the application that will be sending events. |
| logType | [xyLOGIX.Core.Debug.EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') | (Required.) One of the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') value(s) that specifies the type of log to send events to. |

<a name='M-xyLOGIX-Core-Debug-EventLogManager-Warn-System-String-'></a>
### Warn(content) `method`

##### Summary

Sends a Warning event to the system event log pointed to by the [Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and [Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The content of the logging message is specified by the `content` parameter.

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

<a name='T-xyLOGIX-Core-Debug-EventLogTypeValidator'></a>
## EventLogTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') enumeration.

<a name='M-xyLOGIX-Core-Debug-EventLogTypeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-EventLogTypeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IEventLogTypeValidator](#T-xyLOGIX-Core-Debug-Interfaces-IEventLogTypeValidator 'xyLOGIX.Core.Debug.Interfaces.IEventLogTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-EventLogTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-EventLogTypeValidator-IsValid-xyLOGIX-Core-Debug-EventLogType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the event log `type` value passed is within the value set that is defined by the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') enumeration.

##### Returns

`true` if the event log `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') | (Required.) One of the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-ExceptionExtensions'></a>
## ExceptionExtensions `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static extension methods in order to facilitate handling exceptions.

##### Remarks

This class is part of the publicly-exposed API of this library.

<a name='M-xyLOGIX-Core-Debug-ExceptionExtensions-IsAnyOf-System-Exception,System-Type[]-'></a>
### IsAnyOf(exception,types) `method`

##### Summary

Determines whether the [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') of the specified `exception` matches any of the specified `types`.

##### Returns

`true` if at least one of the entry(ies) in the `types` array matches the type of the specified `exception`; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that is the exception whose type is to be checked. |
| types | [System.Type[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type[] 'System.Type[]') | (Required.) One or more [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') value(s) that are to be compared. |

<a name='M-xyLOGIX-Core-Debug-ExceptionExtensions-LogAllExceptions-System-Collections-Generic-IEnumerable{System-Exception}-'></a>
### LogAllExceptions(exceptions) `method`

##### Summary

Iterates through the specified collection of `exceptions` and logs each one, including its inner exception, if any, by calling the [LogException](#M-xyLOGIX-Core-Debug-DebugUtils-LogException 'xyLOGIX.Core.Debug.DebugUtils.LogException') method.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exceptions | [System.Collections.Generic.IEnumerable{System.Exception}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Exception}') | (Required.) A collection of references to instances of [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that represents the exception(s) to be logged. |

##### Remarks

If the `exceptions` parameter is passed a `null` reference, or is the empty set, then the method does nothing.



If any element of the `exceptions` collection is `null`, then it is skipped.

<a name='T-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs'></a>
## ExceptionLoggedEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `ExceptionLogged` event handlers.

<a name='M-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs-#ctor-System-Exception-'></a>
### #ctor(exception) `constructor`

##### Summary

Constructs a new instance of [ExceptionLoggedEventArgs](#T-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs') and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | (Required.) Reference to an instance of the [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that was logged. |

<a name='P-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs-Exception'></a>
### Exception `property`

##### Summary

Gets or sets a reference to an instance of the [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') that was logged.

<a name='T-xyLOGIX-Core-Debug-ExceptionLoggedEventHandler'></a>
## ExceptionLoggedEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `ExceptionLogged` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.ExceptionLoggedEventHandler](#T-T-xyLOGIX-Core-Debug-ExceptionLoggedEventHandler 'T:xyLOGIX.Core.Debug.ExceptionLoggedEventHandler') | A [ExceptionLoggedEventArgs](#T-xyLOGIX-Core-Debug-ExceptionLoggedEventArgs 'xyLOGIX.Core.Debug.ExceptionLoggedEventArgs') that contains the event data. |

##### Remarks

This delegate merely specifies the signature of all methods that handle the `ExceptionLogged` event.

<a name='T-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler'></a>
## ExistingLoggerLoggingClientLoggerCacheAddHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Selects the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration value that preserves an existing, usable logger in the logging-client logger cache.

<a name='M-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of the [ExistingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler') class and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-Instance 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler.Instance') property.

<a name='P-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-Action'></a>
### Action `property`

##### Summary

Gets the [PreserveExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-PreserveExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.PreserveExistingLogger') value that identifies the action selected by this handler strategy.

<a name='P-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-HandlerType'></a>
### HandlerType `property`

##### Summary

Gets the [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger') value that identifies the cache-add handler strategy implemented by this object.

<a name='P-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for an existing, usable logger for the [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger') logging-client logger cache add handler strategy.

<a name='M-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [ExistingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ExistingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ExistingLoggerLoggingClientLoggerCacheAddHandler') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher'></a>
## FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Gets a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface for a client session by using the specified source [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') and optional [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that is set to the name of the targeted log4net repository, if specified, per the [FetchByRepositoryNameAndSourceType](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchByRepositoryNameAndSourceType 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType') approach.

<a name='M-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-Instance 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher.Instance') property.

<a name='P-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-Approach'></a>
### Approach `property`

##### Summary

Gets the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that identifies the particular approach that is to be utilized to fetch a logger for a client session, or to use the legacy logger if no other approach is available.

<a name='P-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchByRepositoryNameAndSourceType](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchByRepositoryNameAndSourceType 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType') approach.

<a name='M-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-FetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-FetchLogger-System-Type,System-String-'></a>
### FetchLogger(sourceType,repositoryName) `method`

##### Summary

Attempts to fetch a logger for a client session by using specified `sourceType` and optional `repositoryName`, if specified, per the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that is specified by the [Approach](#P-xyLOGIX-Core-Debug-ISessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.ISessionLoggerFetcher.Approach') property.

##### Returns

If successful, a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that is utilized to identify the logger that is to be fetched for a client session.    Perhaps this value might come from an internal cache. |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that is set to the name of the repository that is associated with the logger that is to be fetched for a client session.    If this value is not specified, then the default repository name will be used.    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.    The repository name is only to be provided when a more refined search is to be employed.    In such a case where we are searching on the repository name, then the value of the `repositoryName` parameter must be specified, and it must not be [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty'). |

<a name='T-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher'></a>
## FetchFromCacheSessionLoggerFetcher `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Gets a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface for a client session by using the specified `sourceType` and optional `repositoryName`, if specified, per the [FetchFromCache](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchFromCache 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchFromCache') approach.

<a name='M-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [FetchFromCacheSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-Instance 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher.Instance') property.

<a name='P-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-Approach'></a>
### Approach `property`

##### Summary

Gets the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that identifies the particular approach that is to be utilized to fetch a logger for a client session, or to use the legacy logger if no other approach is available.

<a name='P-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchFromCache](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchFromCache 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchFromCache') approach.

<a name='M-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [FetchFromCacheSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchFromCacheSessionLoggerFetcher') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-FetchFromCacheSessionLoggerFetcher-FetchLogger-System-Type,System-String-'></a>
### FetchLogger(sourceType,repositoryName) `method`

##### Summary

Attempts to fetch a logger for a client session by using specified `sourceType` and optional `repositoryName`, if specified, per the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that is specified by the [Approach](#P-xyLOGIX-Core-Debug-ISessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.ISessionLoggerFetcher.Approach') property.

##### Returns

If successful, a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that is utilized to identify the logger that is to be fetched for a client session.    Perhaps this value might come from an internal cache. |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that is set to the name of the repository that is associated with the logger that is to be fetched for a client session.    If this value is not specified, then the default repository name will be used.    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.    The repository name is only to be provided when a more refined search is to be employed.    In such a case where we are searching on the repository name, then the value of the `repositoryName` parameter must be specified, and it must not be [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty'). |

<a name='T-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher'></a>
## FetchLegacyLoggerSessionLoggerFetcher `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Gets a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface for a client session by using the specified `sourceType` and optional `repositoryName`, if specified, per the [FetchLegacyLogger](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchLegacyLogger 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger') approach.

<a name='M-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [FetchLegacyLoggerSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-Instance 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher.Instance') property.

<a name='P-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-Approach'></a>
### Approach `property`

##### Summary

Gets the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that identifies the particular approach that is to be utilized to fetch a logger for a client session, or to use the legacy logger if no other approach is available.

<a name='P-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchLegacyLogger](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchLegacyLogger 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger') approach.

<a name='M-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [FetchLegacyLoggerSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher 'xyLOGIX.Core.Debug.FetchLegacyLoggerSessionLoggerFetcher') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-FetchLogger-System-Type,System-String-'></a>
### FetchLogger(sourceType,repositoryName) `method`

##### Summary

Attempts to fetch a logger for a client session by using specified `sourceType` and optional `repositoryName`, if specified, per the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that is specified by the [Approach](#P-xyLOGIX-Core-Debug-ISessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.ISessionLoggerFetcher.Approach') property.

##### Returns

If successful, a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that is utilized to identify the logger that is to be fetched for a client session.    Perhaps this value might come from an internal cache. |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that is set to the name of the repository that is associated with the logger that is to be fetched for a client session.    If this value is not specified, then the default repository name will be used.    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.    The repository name is only to be provided when a more refined search is to be employed.    In such a case where we are searching on the repository name, then the value of the `repositoryName` parameter must be specified, and it must not be [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty'). |

<a name='M-xyLOGIX-Core-Debug-FetchLegacyLoggerSessionLoggerFetcher-TryGetLegacyLogger-System-Type-'></a>
### TryGetLegacyLogger(sourceType) `method`

##### Summary

Gets a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface from the ordinary log4net repository.

##### Returns

Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that identifies the source of the logging record(s). |

##### Remarks

If `sourceType` is `null`, or log4net cannot supply the logger, then this method returns `null`.

<a name='T-xyLOGIX-Core-Debug-FileAppenderConfigurator'></a>
## FileAppenderConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods for configurating log4net's FileAppender

<a name='M-xyLOGIX-Core-Debug-FileAppenderConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [FileAppenderConfigurator](#T-xyLOGIX-Core-Debug-FileAppenderConfigurator 'xyLOGIX.Core.Debug.FileAppenderConfigurator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-FileAppenderConfigurator-SetMinimalLock-log4net-Appender-FileAppender-'></a>
### SetMinimalLock(appender) `method`

##### Summary

Sets the option to get the minimal locking option set on the specified `appender`.

##### Returns

`true` if locking was configured properly for the specified file `appender`; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| appender | [log4net.Appender.FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') | Reference to an instance of an object of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender'). |

##### Remarks

If a `null` reference is passed as the argument of the `appender` parameter, then this method does nothing, but does return `false`.

<a name='T-xyLOGIX-Core-Debug-FileAppenderManager'></a>
## FileAppenderManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods to access instances of objects of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-GetAppenderByName-System-String-'></a>
### GetAppenderByName(name) `method`

##### Summary

Attempts to obtain a reference to an instance of [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') that is configured under a certain name in the application configuration file.

##### Returns

If a suitable configuration file entry is found, this method returns a [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') instance that corresponds to the entry; otherwise, `null` is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name under which the appender is configured in the application configuration file. |

##### Remarks

If a `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is provided as the value of the `name` parameter, then the method returns a `null` reference.

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstAppender-log4net-Repository-ILoggerRepository-'></a>
### GetFirstAppender(loggerRepository) `method`

##### Summary

If the root logger's appenders list contains appenders, returns a reference to the first one in the list.

##### Returns

Reference to an instance of [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') , or `null` if not found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') |  |

##### Remarks

If the `loggerRepository` parameter is passed a `null` value, then this method attempts to obtain the root logger object and then obtain the first [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') configured on the root logger repository. If a suitable appender can still not be located, then the return value of this method is `null`.

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstFileAppender-log4net-Appender-AppenderCollection-'></a>
### GetFirstFileAppender(appenders) `method`

##### Summary

If feasible, attempts to obtain a reference to the first instance of [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') in the provided `appenders` collection.

##### Returns

If successful, a reference to an instance of [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') that represents the first such entry in the specified `appenders` collection; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| appenders | [log4net.Appender.AppenderCollection](#T-log4net-Appender-AppenderCollection 'log4net.Appender.AppenderCollection') | (Required.) Reference to an instance of [AppenderCollection](#T-log4net-Appender-AppenderCollection 'log4net.Appender.AppenderCollection') that refers to the collection of `Appender`s that is to be searched. |

##### Remarks

This method returns a `null` reference if the `appenders` collection contains zero element(s).

<a name='M-xyLOGIX-Core-Debug-FileAppenderManager-GetFirstFileAppenderByName-log4net-Appender-AppenderCollection,System-String-'></a>
### GetFirstFileAppenderByName(appenders,name) `method`

##### Summary

Attempts to obtain a reference to the first instance of [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') that is configured under a certain `name` in the application configuration file.

##### Returns

If a suitable configuration file entry is found, this method returns a [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender') instance that corresponds to the entry; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| appenders | [log4net.Appender.AppenderCollection](#T-log4net-Appender-AppenderCollection 'log4net.Appender.AppenderCollection') | (Required.) Reference to an instance of [AppenderCollection](#T-log4net-Appender-AppenderCollection 'log4net.Appender.AppenderCollection') that refers to the collection of `Appender`s that is to be searched. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name under which the appender is configured in the application configuration file. |

##### Remarks

If a `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is provided as the value of the `name` parameter, then the method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator'></a>
## FileBasedXmlLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

A `XML Logging Configurator` that relies on a particular `.config` file to contain the logging setting(s).

<a name='M-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator') interface for the [FileBased](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased')`XML Logging Configurator Type`.

<a name='P-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-Type'></a>
### Type `property`

##### Summary

Gets or sets one of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration values that specifies how the logging subsystem is to be configured.

<a name='M-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-FileBasedXmlLoggingConfigurator-Configure-log4net-Repository-ILoggerRepository,System-String-'></a>
### Configure(repository,configurationFileName) `method`

##### Summary

Attempts to configure the logging subsystem, optionally with the settings that are present in the configuration file having the specified `configurationFileName`.

##### Returns

`true` if the configuration operation(s) succeeded; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified configurationFileName of the XML-formatted configuration file containing the necessary logging setting(s).    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value. |

##### Remarks

The value of the `configurationFileName` parameter is ignored if this is a `XML Logging Configurator` object of type [NoFile](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile').



Otherwise, if this `XML Logging Configurator` is of type, [FileBased](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased'), then the `configurationFileName` had better contain the fully-qualified configurationFileName of a `.config` file containing the logging settings, or else this method will fail.

<a name='T-xyLOGIX-Core-Debug-FileWriteabilityStatus'></a>
## FileWriteabilityStatus `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Value(s) that indicate whether a file is writeable or not, or whether it cannot be determined from the information available.

<a name='F-xyLOGIX-Core-Debug-FileWriteabilityStatus-NoDetermination'></a>
### NoDetermination `constants`

##### Summary

No determination could be made as to whether the file is writeable or not.

<a name='F-xyLOGIX-Core-Debug-FileWriteabilityStatus-NotWriteable'></a>
### NotWriteable `constants`

##### Summary

The file is not writeable by the currently-logged-in user.

<a name='F-xyLOGIX-Core-Debug-FileWriteabilityStatus-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown writeability status.

<a name='F-xyLOGIX-Core-Debug-FileWriteabilityStatus-Writeable'></a>
### Writeable `constants`

##### Summary

The file is writeable by the currently-logged-in user.

<a name='T-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator'></a>
## FileWriteabilityStatusValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') enumeration.

<a name='M-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IFileWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-Interfaces-IFileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.Interfaces.IFileWriteabilityStatusValidator') interface.

<a name='M-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-FileWriteabilityStatusValidator-IsValid-xyLOGIX-Core-Debug-FileWriteabilityStatus-'></a>
### IsValid(status) `method`

##### Summary

Determines whether the file writeability `status` value passed is within the value set that is defined by the [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') enumeration.

##### Returns

`true` if the file writeability `status` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| status | [xyLOGIX.Core.Debug.FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') | (Required.) One of the [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator'></a>
## FromConfigFileLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a `Logging Configurator` file that sets up logging based on setting(s) that are found in an `app.config` or a `web.config` file.

<a name='M-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface for the [FromConfigFile](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-FromConfigFile 'xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile')`Logging Configurator Type`.

<a name='P-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-Type'></a>
### Type `property`

##### Summary

Gets or sets one of the [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') enumeration value(s) that indicates which type of configuration this `Logging Configurator` does.

<a name='P-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-XmlLoggingConfiguratorTypeValidator'></a>
### XmlLoggingConfiguratorTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-FromConfigFileLoggingConfigurator-Configure-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### Configure(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Returns

`true` if the configuration operation(s) succeeded; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` if we should not write out `DEBUG` messages to the `Debug` output when in the `Release` mode. Set to `false` if all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for initializing log4net. If blank, the system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the console if a log file is being used. If a log file is not used, then no logging at all will occur if this parameter is set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the `XMLConfigurator` object is used to configure logging.    Else, specify here the path to the `Debug` output to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a user-friendly display name of the application that is using this logging library.    Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. Supply a value for this parameter if your infrastructure is not utilizing the default HierarchicalRepository. |

<a name='T-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner'></a>
## FromLogManagerRootLoggerProvisioner `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

This concrete class simply executes the fallback provisioning strategy and attempts to return the value of such, ignoring any provided reference to a `Logging Repository`.

<a name='M-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface for the [FromLogManager](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager') root-logger provisioning strategy.

<a name='P-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-Strategy'></a>
### Strategy `property`

##### Summary

Gets the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration value that indicates the strategy used to provision the `Root Logger`.

<a name='M-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-FromLogManagerRootLoggerProvisioner-Provision-log4net-Repository-ILoggerRepository-'></a>
### Provision(loggerRepository) `method`

##### Summary

Provisions the `Root Logger` for the application depending on the value of the `loggerRepository` parameter.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') |  |

##### Remarks

If the provided `loggerRepository` can be directly cast to [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy'), then this method returns a reference to an instance of [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger') that is at the root of such a [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy').



If a `null` reference is passed for the value of the `loggerRepository` parameter, then this method attempts to find the default appender configuration and attempts to then return a reference to that configuration's [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger').



If the first two attempts fail, then this method returns a `null` reference.



If this particular `Root Logger Provisioner` is configured to use the [FromLogManager](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager') strategy, then this method attempts to find the default appender configuration and attempts to then return a reference to that configuration's [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger').



Failing that, a `null` reference is returned.

<a name='T-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner'></a>
## FromProvidedLoggingRepositoryRootLoggerProvisioner `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Attempts to provision the root logger from an existing `Logger Repository` component that has been determined, in advance, to be convertible to a reference to an instance of [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy').

<a name='M-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface for the [FromProvidedLoggingRepository](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromProvidedLoggingRepository 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromProvidedLoggingRepository') root-logger provisioning strategy.

<a name='P-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-Strategy'></a>
### Strategy `property`

##### Summary

Gets the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration value that indicates the strategy used to provision the `Root Logger`.

<a name='M-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-FromProvidedLoggingRepositoryRootLoggerProvisioner-Provision-log4net-Repository-ILoggerRepository-'></a>
### Provision(loggerRepository) `method`

##### Summary

Provisions the `Root Logger` for the application depending on the value of the `loggerRepository` parameter.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') |  |

##### Remarks

If the provided `loggerRepository` can be directly cast to [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy'), then this method returns a reference to an instance of [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger') that is at the root of such a [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy').



If a `null` reference is passed for the value of the `loggerRepository` parameter, then this method attempts to find the default appender configuration and attempts to then return a reference to that configuration's [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger').



If the first two attempts fail, then this method returns a `null` reference.



If this particular `Root Logger Provisioner` is configured to use the [FromLogManager](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager') strategy, then this method attempts to find the default appender configuration and attempts to then return a reference to that configuration's [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger').



Failing that, a `null` reference is returned.

<a name='T-xyLOGIX-Core-Debug-GetAppenderManager'></a>
## GetAppenderManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IAppenderManager](#T-xyLOGIX-Core-Debug-IAppenderManager 'xyLOGIX.Core.Debug.IAppenderManager') interface.

<a name='M-xyLOGIX-Core-Debug-GetAppenderManager-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IAppenderManager](#T-xyLOGIX-Core-Debug-IAppenderManager 'xyLOGIX.Core.Debug.IAppenderManager') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IAppenderManager](#T-xyLOGIX-Core-Debug-IAppenderManager 'xyLOGIX.Core.Debug.IAppenderManager') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetAssembly'></a>
## GetAssembly `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to get information on .NET assemblies.

<a name='M-xyLOGIX-Core-Debug-GetAssembly-Pathname-System-Reflection-Assembly-'></a>
### Pathname(assembly) `method`

##### Summary

Obtains the fully-qualified pathname of the specified `assembly`.

##### Returns

If successful, the fully-qualified pathname of the specified `assembly`; the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value if it could not be obtained, or if the argument of the `assembly` parameter is a `null` reference.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') for which to obtain the fully-qualified pathname. |

<a name='M-xyLOGIX-Core-Debug-GetAssembly-ToUseForEventLogging-System-Reflection-Assembly-'></a>
### ToUseForEventLogging() `method`

##### Summary

Attempts to obtain a reference to an instance of the [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that should be used for the application event logging quote.

##### Returns

If successful, a reference to an instance of the [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that should be used for the application event logging quote; `null` otherwise.

##### Parameters

This method has no parameters.

##### Remarks

To find the assembly to use as a quote for event logging, this method first attempts to locate the assembly containing the application's entry-point, and use that.



Failing that, the assembly that is currently executing is tried.



Failing that, then the assembly that called this method is used.

<a name='T-xyLOGIX-Core-Debug-GetConsoleOutputLocation'></a>
## GetConsoleOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the standard output of the application and/or a console window, if present.

<a name='M-xyLOGIX-Core-Debug-GetConsoleOutputLocation-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the standard output of the application and/or a console window, if present.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetDebugLevelValidator'></a>
## GetDebugLevelValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IDebugLevelValidator](#T-xyLOGIX-Core-Debug-IDebugLevelValidator 'xyLOGIX.Core.Debug.IDebugLevelValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetDebugLevelValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IDebugLevelValidator](#T-xyLOGIX-Core-Debug-IDebugLevelValidator 'xyLOGIX.Core.Debug.IDebugLevelValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IDebugLevelValidator](#T-xyLOGIX-Core-Debug-IDebugLevelValidator 'xyLOGIX.Core.Debug.IDebugLevelValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetDebugOutputLocation'></a>
## GetDebugOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the window in Visual Studio or whichever other debugger can listen to the output of the [Debug](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Debug 'System.Diagnostics.Debug') class' methods.

<a name='M-xyLOGIX-Core-Debug-GetDebugOutputLocation-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the window in Visual Studio or whichever other debugger can listen to the output of the [Debug](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Debug 'System.Diagnostics.Debug') class' methods.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetDefaultLoggingInfrastructure'></a>
## GetDefaultLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface for the [Default](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Default 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Default') logging infrastructure type value.

<a name='M-xyLOGIX-Core-Debug-GetDefaultLoggingInfrastructure-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface for the [Default](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-Default 'xyLOGIX.Core.Debug.LoggingInfrastructureType.Default') logging infrastructure type value.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetDirectoryWriteabilityStatusValidator'></a>
## GetDirectoryWriteabilityStatusValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IDirectoryWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IDirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IDirectoryWriteabilityStatusValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetDirectoryWriteabilityStatusValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IDirectoryWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IDirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IDirectoryWriteabilityStatusValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IDirectoryWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IDirectoryWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IDirectoryWriteabilityStatusValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetEvent'></a>
## GetEvent `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods for interacting with the Windows Event Log.

<a name='M-xyLOGIX-Core-Debug-GetEvent-SourceAssembly'></a>
### SourceAssembly() `method`

##### Summary

Attempts to obtain a reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that represents the proper assembly to use for event logging.

##### Returns

If successful, a reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that represents the proper assembly to use for event logging; otherwise, a `null` reference is returned.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-GetEvent-SourceName'></a>
### SourceName() `method`

##### Summary

Attempts to obtain a user-friendly display name for the event-logging quote, based on the name of the application that is calling this debug logging library.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetEventLogManager'></a>
## GetEventLogManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface that manages our access to the Windows System Event Logs.

<a name='M-xyLOGIX-Core-Debug-GetEventLogManager-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface that manages our access to the Windows System Event Logs.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetEventLogTypeValidator'></a>
## GetEventLogTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IEventLogTypeValidator](#T-xyLOGIX-Core-Debug-IEventLogTypeValidator 'xyLOGIX.Core.Debug.IEventLogTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetEventLogTypeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IEventLogTypeValidator](#T-xyLOGIX-Core-Debug-IEventLogTypeValidator 'xyLOGIX.Core.Debug.IEventLogTypeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IEventLogTypeValidator](#T-xyLOGIX-Core-Debug-IEventLogTypeValidator 'xyLOGIX.Core.Debug.IEventLogTypeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetExistingLoggerLoggingClientLoggerCacheAddHandler'></a>
## GetExistingLoggerLoggingClientLoggerCacheAddHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger') logging-client logger cache add handler strategy.

<a name='M-xyLOGIX-Core-Debug-GetExistingLoggerLoggingClientLoggerCacheAddHandler-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetExistingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-GetExistingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.GetExistingLoggerLoggingClientLoggerCacheAddHandler') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetExistingLoggerLoggingClientLoggerCacheAddHandler-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger') logging-client logger cache add handler strategy, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [ExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.ExistingLogger') logging-client logger cache add handler strategy.

##### Parameters

This method has no parameters.

##### Remarks

If the singleton instance cannot be obtained, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher'></a>
## GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchByRepositoryNameAndSourceType](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchByRepositoryNameAndSourceType 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType') approach.

<a name='M-xyLOGIX-Core-Debug-GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher](#T-GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher 'GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetFetchByRepositoryNameAndSourceTypeSessionLoggerFetcher-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchByRepositoryNameAndSourceType](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchByRepositoryNameAndSourceType 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType') approach, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchByRepositoryNameAndSourceType](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchByRepositoryNameAndSourceType 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchByRepositoryNameAndSourceType') approach.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetFetchFromCacheSessionLoggerFetcher'></a>
## GetFetchFromCacheSessionLoggerFetcher `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchFromCache](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchFromCache 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchFromCache') approach.

<a name='M-xyLOGIX-Core-Debug-GetFetchFromCacheSessionLoggerFetcher-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetFetchFromCacheSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-GetFetchFromCacheSessionLoggerFetcher 'xyLOGIX.Core.Debug.GetFetchFromCacheSessionLoggerFetcher') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetFetchFromCacheSessionLoggerFetcher-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchFromCache](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchFromCache 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchFromCache') approach, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchFromCache](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchFromCache 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchFromCache') approach.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetFetchLegacyLoggerSessionLoggerFetcher'></a>
## GetFetchLegacyLoggerSessionLoggerFetcher `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchLegacyLogger](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchLegacyLogger 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger') approach.

<a name='M-xyLOGIX-Core-Debug-GetFetchLegacyLoggerSessionLoggerFetcher-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetFetchLegacyLoggerSessionLoggerFetcher](#T-GetFetchLegacyLoggerSessionLoggerFetcher 'GetFetchLegacyLoggerSessionLoggerFetcher') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetFetchLegacyLoggerSessionLoggerFetcher-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchLegacyLogger](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchLegacyLogger 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger') approach, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the [FetchLegacyLogger](#F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchLegacyLogger 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach.FetchLegacyLogger') approach.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetFileBasedXmlLoggingConfigurator'></a>
## GetFileBasedXmlLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [FileBased](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased')`XML Logging Configurator Type`.

<a name='M-xyLOGIX-Core-Debug-GetFileBasedXmlLoggingConfigurator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [FileBased](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased')`XML Logging Configurator Type`.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetFileWriteabilityStatusValidator'></a>
## GetFileWriteabilityStatusValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IFileWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IFileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IFileWriteabilityStatusValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetFileWriteabilityStatusValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IFileWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IFileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IFileWriteabilityStatusValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IFileWriteabilityStatusValidator](#T-xyLOGIX-Core-Debug-IFileWriteabilityStatusValidator 'xyLOGIX.Core.Debug.IFileWriteabilityStatusValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetFromConfigFileLoggingConfigurator'></a>
## GetFromConfigFileLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface for the [FromConfigFile](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-FromConfigFile 'xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile')`Logging Configurator Type`.

<a name='M-xyLOGIX-Core-Debug-GetFromConfigFileLoggingConfigurator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface for the [FromConfigFile](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-FromConfigFile 'xyLOGIX.Core.Debug.LoggingConfiguratorType.FromConfigFile')`Logging Configurator Type`.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetFromLogManagerRootLoggerProvisioner'></a>
## GetFromLogManagerRootLoggerProvisioner `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [FromLogManager](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager') root-logger provisioning strategy.

<a name='M-xyLOGIX-Core-Debug-GetFromLogManagerRootLoggerProvisioner-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [FromLogManager](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager') root-logger provisioning strategy.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetFromProvidedLoggingRepositoryRootLoggerProvisioner'></a>
## GetFromProvidedLoggingRepositoryRootLoggerProvisioner `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface for the [FromProvidedLoggingRepository](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromProvidedLoggingRepository 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromProvidedLoggingRepository') root-logger provisioning strategy.

<a name='M-xyLOGIX-Core-Debug-GetFromProvidedLoggingRepositoryRootLoggerProvisioner-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface for the [FromProvidedLoggingRepository](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromProvidedLoggingRepository 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromProvidedLoggingRepository') root-logger provisioning strategy.

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

Gets a string that contains the fully-qualified pathname of the current user's temporary files folder.

<a name='P-xyLOGIX-Core-Debug-GetLog-FilePath'></a>
### FilePath `property`

##### Summary

Gets a string containing the fully-qualified pathname to use for the current log file.

<a name='M-xyLOGIX-Core-Debug-GetLog-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetLog](#T-xyLOGIX-Core-Debug-GetLog 'xyLOGIX.Core.Debug.GetLog') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='T-xyLOGIX-Core-Debug-GetLoggingBackend'></a>
## GetLoggingBackend `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Obtains a reference to a new instance of the [LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that corresponds to the specified [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration value.

<a name='P-xyLOGIX-Core-Debug-GetLoggingBackend-LoggingBackendTypeValidator'></a>
### LoggingBackendTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingBackendTypeValidator 'xyLOGIX.Core.Debug.ILoggingBackendTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingBackend-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetLoggingBackend](#T-xyLOGIX-Core-Debug-GetLoggingBackend 'xyLOGIX.Core.Debug.GetLoggingBackend') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetLoggingBackend-For-xyLOGIX-Core-Debug-LoggingBackendType,log4net-Repository-ILoggerRepository-'></a>
### For(type,relay) `method`

##### Summary

Obtains a reference to a new instance of the [LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that corresponds to the specified logging backend `type` and, if necessary, `relay`.

##### Returns

Reference to a new instance of [LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that corresponds to the provided `type` and/or `relay` values.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') | (Required.) The [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration value that explains which type of backend to get. |
| relay | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. |

<a name='T-xyLOGIX-Core-Debug-GetLoggingBackendTypeValidator'></a>
## GetLoggingBackendTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingBackendTypeValidator 'xyLOGIX.Core.Debug.ILoggingBackendTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingBackendTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetLoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-GetLoggingBackendTypeValidator 'xyLOGIX.Core.Debug.GetLoggingBackendTypeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetLoggingBackendTypeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingBackendTypeValidator 'xyLOGIX.Core.Debug.ILoggingBackendTypeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingBackendTypeValidator 'xyLOGIX.Core.Debug.ILoggingBackendTypeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientAssemblyContext'></a>
## GetLoggingClientAssemblyContext `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientAssemblyContext-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetLoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-GetLoggingClientAssemblyContext 'xyLOGIX.Core.Debug.GetLoggingClientAssemblyContext') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientAssemblyContext-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientAssemblyRegistry'></a>
## GetLoggingClientAssemblyRegistry `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the sole instance of the logging-client assembly registry.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientAssemblyRegistry-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-GetLoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.GetLoggingClientAssemblyRegistry') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientAssemblyRegistry-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Gets a reference to the sole instance of an object that implements the [ILoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry') interface.

##### Returns

Reference to the sole instance of an object that implements the [ILoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry') interface; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If the registry cannot be obtained, then the exception information is written to the Debug output and `null` is returned.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientLogProvider'></a>
## GetLoggingClientLogProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the sole logging-client log-provider object.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLogProvider-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientLogProvider](#T-xyLOGIX-Core-Debug-GetLoggingClientLogProvider 'xyLOGIX.Core.Debug.GetLoggingClientLogProvider') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically before any `static` member is referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLogProvider-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Gets a reference to the sole instance of an object that implements the [ILoggingClientLogProvider](#T-xyLOGIX-Core-Debug-ILoggingClientLogProvider 'xyLOGIX.Core.Debug.ILoggingClientLogProvider') interface.

##### Returns

Reference to the sole instance of an object that implements the [ILoggingClientLogProvider](#T-xyLOGIX-Core-Debug-ILoggingClientLogProvider 'xyLOGIX.Core.Debug.ILoggingClientLogProvider') interface; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If the provider cannot be obtained, then the exception information is written to the Debug output and this method returns `null`.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCache'></a>
## GetLoggingClientLoggerCache `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCache 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCache-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCache 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCache') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCache-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCache 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCache 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddActionValidator'></a>
## GetLoggingClientLoggerCacheAddActionValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddActionValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddActionValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddActionValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator') interface and returns a reference to it.

##### Returns

Reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator') interface; otherwise, a `null` reference is returned.

##### Parameters

This method has no parameters.

##### Remarks

If the singleton instance cannot be obtained, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler'></a>
## GetLoggingClientLoggerCacheAddHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for a specified [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value, if one is implemented for the value specified.

<a name='P-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler-LoggingClientLoggerCacheAddHandlerTypeValidator'></a>
### LoggingClientLoggerCacheAddHandlerTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddHandler') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandler-ForHandlerType-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-'></a>
### ForHandlerType(handlerType) `method`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the specified `handlerType`.

##### Returns

If successful, a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the specified `handlerType`; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') value(s) that identifies the logging-client logger-cache `Add` handler strategy that is to be obtained. |

##### Remarks

If the specified `handlerType` is outside the defined value set of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration, is equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown') , or no corresponding handler strategy can be obtained, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandlerTypeValidator'></a>
## GetLoggingClientLoggerCacheAddHandlerTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandlerTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientLoggerCacheAddHandlerTypeValidator](#T-GetLoggingClientLoggerCacheAddHandlerTypeValidator 'GetLoggingClientLoggerCacheAddHandlerTypeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddHandlerTypeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddOutcomeValidator'></a>
## GetLoggingClientLoggerCacheAddOutcomeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddOutcomeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheAddOutcomeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheAddOutcomeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheKeyValidator'></a>
## GetLoggingClientLoggerCacheKeyValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheKeyValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.GetLoggingClientLoggerCacheKeyValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientLoggerCacheKeyValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator') interface and returns a reference to it.

##### Returns

Reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetLoggingClientSessionRegistry'></a>
## GetLoggingClientSessionRegistry `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the sole logging-client session registry instance.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientSessionRegistry-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetLoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-GetLoggingClientSessionRegistry 'xyLOGIX.Core.Debug.GetLoggingClientSessionRegistry') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingClientSessionRegistry-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Gets a reference to the sole instance of an object that implements the [ILoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry 'xyLOGIX.Core.Debug.ILoggingClientSessionRegistry') interface.

##### Returns

Reference to the sole logging-client session registry instance; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If the registry cannot be obtained, this method writes the exception information to the Debug output and returns `null`.

<a name='T-xyLOGIX-Core-Debug-GetLoggingConfigurator'></a>
## GetLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Obtains references to instance(s) of object(s) that implement the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface that change depending on the strategy desired.

<a name='P-xyLOGIX-Core-Debug-GetLoggingConfigurator-LoggingConfiguratorTypeValidator'></a>
### LoggingConfiguratorTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetLoggingConfigurator 'xyLOGIX.Core.Debug.GetLoggingConfigurator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetLoggingConfigurator-For-xyLOGIX-Core-Debug-LoggingConfiguratorType-'></a>
### For(type) `method`

##### Summary

Obtains a reference to an instance of an object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface which corresponds to the specified meeting `type`.

##### Returns

Reference to the instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface which corresponds to the specific enumeration value that is specified for the argument of the `type` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') | (Required.) One of the [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') enumeration values that describes the type of `Logging Configurator` that is to be used. |

##### Remarks

If the specified `Logging Configurator``type` is not supported, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-GetLoggingConfiguratorTypeValidator'></a>
## GetLoggingConfiguratorTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingConfiguratorTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-GetLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.GetLoggingConfiguratorTypeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetLoggingConfiguratorTypeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.ILoggingConfiguratorTypeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetLoggingInfrastructure'></a>
## GetLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Creates instance(s) of object(s) that implement the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetLoggingInfrastructure](#T-xyLOGIX-Core-Debug-GetLoggingInfrastructure 'xyLOGIX.Core.Debug.GetLoggingInfrastructure') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetLoggingInfrastructure-OfType-xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### OfType(type) `method`

##### Summary

Creates an instance of an object implementing the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface which corresponds to the value specified in `type`, and returns a reference to it.

##### Returns

A reference to the instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface which corresponds to the value specified in `type`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | One of the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') value(s) that describes what type of object you want. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if there is no corresponding concrete type defined that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface and which corresponds to the value passed in the `type` parameter. |

##### Remarks

This method will throw an exception if there are no types implemented that correspond to the value of `type`.

<a name='T-xyLOGIX-Core-Debug-GetLoggingInfrastructureTypeValidator'></a>
## GetLoggingInfrastructureTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetLoggingInfrastructureTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetLoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-GetLoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.GetLoggingInfrastructureTypeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetLoggingInfrastructureTypeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetMissingLoggerLoggingClientLoggerCacheAddHandler'></a>
## GetMissingLoggerLoggingClientLoggerCacheAddHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger') logging-client logger cache add handler strategy.

<a name='M-xyLOGIX-Core-Debug-GetMissingLoggerLoggingClientLoggerCacheAddHandler-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetMissingLoggerLoggingClientLoggerCacheAddHandler](#T-GetMissingLoggerLoggingClientLoggerCacheAddHandler 'GetMissingLoggerLoggingClientLoggerCacheAddHandler') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetMissingLoggerLoggingClientLoggerCacheAddHandler-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger') logging-client logger cache add handler strategy, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger') logging-client logger cache add handler strategy.

##### Parameters

This method has no parameters.

##### Remarks

If the singleton instance cannot be obtained, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-GetNoFileXmlLoggingConfigurator'></a>
## GetNoFileXmlLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [NoFile](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile')`XML Logging Configurator Type`.

<a name='M-xyLOGIX-Core-Debug-GetNoFileXmlLoggingConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetNoFileXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetNoFileXmlLoggingConfigurator 'xyLOGIX.Core.Debug.GetNoFileXmlLoggingConfigurator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetNoFileXmlLoggingConfigurator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [NoFile](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile')`XML Logging Configurator Type`.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetNullLoggerLoggingClientLoggerCacheAddHandler'></a>
## GetNullLoggerLoggingClientLoggerCacheAddHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger') logging-client logger cache add handler strategy.

<a name='M-xyLOGIX-Core-Debug-GetNullLoggerLoggingClientLoggerCacheAddHandler-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetNullLoggerLoggingClientLoggerCacheAddHandler](#T-GetNullLoggerLoggingClientLoggerCacheAddHandler 'GetNullLoggerLoggingClientLoggerCacheAddHandler') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetNullLoggerLoggingClientLoggerCacheAddHandler-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger') logging-client logger cache add handler strategy, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger') logging-client logger cache add handler strategy.

##### Parameters

This method has no parameters.

##### Remarks

If the singleton instance cannot be obtained, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-GetOutputLocation'></a>
## GetOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Obtains references to instance(s) of object(s) that implement the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that change depending on the strategy desired.

<a name='P-xyLOGIX-Core-Debug-GetOutputLocation-OutputLocationTypeValidator'></a>
### OutputLocationTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IOutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-IOutputLocationTypeValidator 'xyLOGIX.Core.Debug.IOutputLocationTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetOutputLocation](#T-xyLOGIX-Core-Debug-GetOutputLocation 'xyLOGIX.Core.Debug.GetOutputLocation') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocation-OfType-xyLOGIX-Core-Debug-OutputLocationType-'></a>
### OfType(type) `method`

##### Summary

Obtains a reference to an instance of an object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface which corresponds to the specified meeting `type`.

##### Returns

Reference to the instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface which corresponds to the specific enumeration value that is specified for the argument of the `type` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') | (Required.) One of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration values that describes the type of output location to be created. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if there is no corresponding concrete type defined that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface and which corresponds to the specific enumeration value that was passed for the argument of the `type` parameter, if it is not supported. |

##### Remarks

This method will throw an exception if there are no types implemented that correspond to the enumeration value passed for the argument of the `type` parameter.

<a name='T-xyLOGIX-Core-Debug-GetOutputLocationProvider'></a>
## GetOutputLocationProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider') interface.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocationProvider-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetOutputLocationProvider](#T-xyLOGIX-Core-Debug-GetOutputLocationProvider 'xyLOGIX.Core.Debug.GetOutputLocationProvider') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocationProvider-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetOutputLocationTypeValidator'></a>
## GetOutputLocationTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IOutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-IOutputLocationTypeValidator 'xyLOGIX.Core.Debug.IOutputLocationTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocationTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetOutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-GetOutputLocationTypeValidator 'xyLOGIX.Core.Debug.GetOutputLocationTypeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetOutputLocationTypeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IOutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-IOutputLocationTypeValidator 'xyLOGIX.Core.Debug.IOutputLocationTypeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IOutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-IOutputLocationTypeValidator 'xyLOGIX.Core.Debug.IOutputLocationTypeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetPatternLayout'></a>
## GetPatternLayout `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Creates instances of [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') that are initialized properly.

<a name='M-xyLOGIX-Core-Debug-GetPatternLayout-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetPatternLayout](#T-xyLOGIX-Core-Debug-GetPatternLayout 'xyLOGIX.Core.Debug.GetPatternLayout') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetPatternLayout-ForConversionPattern-System-String-'></a>
### ForConversionPattern(conversionPattern) `method`

##### Summary

Creates a new instance of [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') and initializes the [ConversionPattern](#P-log4net-Layout-PatternLayout-ConversionPattern 'log4net.Layout.PatternLayout.ConversionPattern') property with the specified `conversionPattern` string.

##### Returns

An activated [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') instance that is initialized with the specified `conversionPattern`, or `null` if an error occurred or if blank input was supplied for the `conversionPattern` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| conversionPattern | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the conversion pattern to utilize. |

<a name='T-xyLOGIX-Core-Debug-GetPostSharpLoggingBackendRouter'></a>
## GetPostSharpLoggingBackendRouter `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the sole PostSharp logging-backend router instance.

<a name='M-xyLOGIX-Core-Debug-GetPostSharpLoggingBackendRouter-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetPostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-GetPostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.GetPostSharpLoggingBackendRouter') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetPostSharpLoggingBackendRouter-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Gets a reference to the sole instance of an object that implements the [IPostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter') interface.

##### Returns

Reference to the sole router instance; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If the router cannot be obtained, the exception information is written to the Debug output and this method returns `null`.

<a name='T-xyLOGIX-Core-Debug-GetPostSharpLoggingInfrastructure'></a>
## GetPostSharpLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface for the [PostSharp](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-PostSharp 'xyLOGIX.Core.Debug.LoggingInfrastructureType.PostSharp') logging infrastructure type value.

<a name='M-xyLOGIX-Core-Debug-GetPostSharpLoggingInfrastructure-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetPostSharpLoggingInfrastructure](#T-xyLOGIX-Core-Debug-GetPostSharpLoggingInfrastructure 'xyLOGIX.Core.Debug.GetPostSharpLoggingInfrastructure') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetPostSharpLoggingInfrastructure-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface for the [PostSharp](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-PostSharp 'xyLOGIX.Core.Debug.LoggingInfrastructureType.PostSharp') logging infrastructure type value.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetProgrammaticLoggingConfigurator'></a>
## GetProgrammaticLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface for the [Programmatic](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-Programmatic 'xyLOGIX.Core.Debug.LoggingConfiguratorType.Programmatic')`Logging Configurator Type`.

<a name='M-xyLOGIX-Core-Debug-GetProgrammaticLoggingConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetProgrammaticLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetProgrammaticLoggingConfigurator 'xyLOGIX.Core.Debug.GetProgrammaticLoggingConfigurator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetProgrammaticLoggingConfigurator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface for the [Programmatic](#F-xyLOGIX-Core-Debug-LoggingConfiguratorType-Programmatic 'xyLOGIX.Core.Debug.LoggingConfiguratorType.Programmatic')`Logging Configurator Type`.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetRollingModeValidator'></a>
## GetRollingModeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IRollingModeValidator](#T-xyLOGIX-Core-Debug-IRollingModeValidator 'xyLOGIX.Core.Debug.IRollingModeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetRollingModeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IRollingModeValidator](#T-xyLOGIX-Core-Debug-IRollingModeValidator 'xyLOGIX.Core.Debug.IRollingModeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IRollingModeValidator](#T-xyLOGIX-Core-Debug-IRollingModeValidator 'xyLOGIX.Core.Debug.IRollingModeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetRootLoggerProvisioner'></a>
## GetRootLoggerProvisioner `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Obtains references to instance(s) of object(s) that implement the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface that change depending on the strategy desired.

<a name='P-xyLOGIX-Core-Debug-GetRootLoggerProvisioner-RootLoggerProvisioningStrategyValidator'></a>
### RootLoggerProvisioningStrategyValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetRootLoggerProvisioner-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-GetRootLoggerProvisioner 'xyLOGIX.Core.Debug.GetRootLoggerProvisioner') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetRootLoggerProvisioner-For-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-'></a>
### For(strategy) `method`

##### Summary

Obtains a reference to an instance of an object that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface which corresponds to the specified meeting `strategy`.

##### Returns

Reference to the instance of the object that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface which corresponds to the specific enumeration value that is specified for the argument of the `strategy` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| strategy | [xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') | (Required.) One of the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration values that describes the root-logger provisioning strategy. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if there is no corresponding concrete type defined that implements the [IRootLoggerProvisioner](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioner 'xyLOGIX.Core.Debug.IRootLoggerProvisioner') interface and which corresponds to the specific enumeration value that was passed for the argument of the `strategy` parameter, if it is not supported. |

##### Remarks

This method will throw an exception if there are no types implemented that correspond to the enumeration value passed for the argument of the `strategy` parameter.

<a name='T-xyLOGIX-Core-Debug-GetRootLoggerProvisioningStrategyValidator'></a>
## GetRootLoggerProvisioningStrategyValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetRootLoggerProvisioningStrategyValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-GetRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.GetRootLoggerProvisioningStrategyValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetRootLoggerProvisioningStrategyValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetSessionLoggerFetchApproachValidator'></a>
## GetSessionLoggerFetchApproachValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [ISessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetSessionLoggerFetchApproachValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetSessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-GetSessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.GetSessionLoggerFetchApproachValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetSessionLoggerFetchApproachValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [ISessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [ISessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetSessionLoggerFetcher'></a>
## GetSessionLoggerFetcher `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Gets a reference to an instance of an object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for a specified [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value, if one is implemented for the value specified.

<a name='P-xyLOGIX-Core-Debug-GetSessionLoggerFetcher-SessionLoggerFetchApproachValidator'></a>
### SessionLoggerFetchApproachValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ISessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetSessionLoggerFetcher-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [GetSessionLoggerFetcher](#T-xyLOGIX-Core-Debug-GetSessionLoggerFetcher 'xyLOGIX.Core.Debug.GetSessionLoggerFetcher') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetSessionLoggerFetcher-ForApproach-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-'></a>
### ForApproach(approach) `method`

##### Summary

Gets a reference to an instance of an object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the specified [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value, if one is implemented for the value specified.

##### Returns

If successful, a reference to an instance of an object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface, if one is available that corresponds to the specified `approach`; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| approach | [xyLOGIX.Core.Debug.SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') | (Required.) One of the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') value(s) that identifies the session-logger fetching approach that is to be utilized for the purposes of getting a reference to an instance of an object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface is to be obtained. |

##### Remarks

If the specified `approach` is outside of the defined value set of the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration, then the method returns a `null` reference.



A `null` reference is also returned if an error occurs while attempting to obtain a reference to an instance of an object that implements the [ISessionLoggerFetcher](#T-xyLOGIX-Core-Debug-ISessionLoggerFetcher 'xyLOGIX.Core.Debug.ISessionLoggerFetcher') interface for the specified `approach`.

<a name='T-xyLOGIX-Core-Debug-GetTraceOutputLocation'></a>
## GetTraceOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the window in Visual Studio or whichever other debugger can listen to the output of the [Trace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Trace 'System.Diagnostics.Trace') class' methods.

<a name='M-xyLOGIX-Core-Debug-GetTraceOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetTraceOutputLocation](#T-xyLOGIX-Core-Debug-GetTraceOutputLocation 'xyLOGIX.Core.Debug.GetTraceOutputLocation') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetTraceOutputLocation-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the window in Visual Studio or whichever other debugger can listen to the output of the [Trace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Trace 'System.Diagnostics.Trace') class' methods.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator'></a>
## GetXmlLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Obtains references to instance(s) of object(s) that implement the [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator') interface that change depending on the strategy desired.

<a name='P-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator-XmlLoggingConfiguratorTypeValidator'></a>
### XmlLoggingConfiguratorTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator 'xyLOGIX.Core.Debug.GetXmlLoggingConfigurator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-GetXmlLoggingConfigurator-For-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-'></a>
### For(type) `method`

##### Summary

Obtains a reference to an instance of an object that implements the [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator') interface which corresponds to the specified meeting `type`.

##### Returns

Reference to the instance of the object that implements the [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator') interface which corresponds to the specific enumeration value that is specified for the argument of the `type` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') | (Required.) One of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration values that describes the type of `XML Logging Configurator` object that is to be utilized to configure the logging subsystem. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if there is no corresponding concrete type defined that implements the [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator') interface and which corresponds to the specific enumeration value that was passed for the argument of the `type` parameter, if it is not supported. |

##### Remarks

This method will throw an exception if there are no types implemented that correspond to the enumeration value passed for the argument of the `type` parameter.

<a name='T-xyLOGIX-Core-Debug-GetXmlLoggingConfiguratorTypeValidator'></a>
## GetXmlLoggingConfiguratorTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to the one and only instance of the object that implements the [IXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-GetXmlLoggingConfiguratorTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [GetXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-GetXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.GetXmlLoggingConfiguratorTypeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-GetXmlLoggingConfiguratorTypeValidator-SoleInstance'></a>
### SoleInstance() `method`

##### Summary

Obtains access to the sole instance of the object that implements the [IXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator') interface, and returns a reference to it.

##### Returns

Reference to the one, and only, instance of the object that implements the [IXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.IXmlLoggingConfiguratorTypeValidator') interface.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-Has'></a>
## Has `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to determine whether a console window is present.

<a name='P-xyLOGIX-Core-Debug-Has-IsWindowsGUI'></a>
### IsWindowsGUI `property`

##### Summary

Gets or sets a value that is initialized with a [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') that indicates whether the calling application is a Windows GUI app or a console app.

##### Remarks

We use this property to avoid re-determining the nature of the current app if the [WindowsGui](#M-xyLOGIX-Core-Debug-Has-WindowsGui 'xyLOGIX.Core.Debug.Has.WindowsGui') method is called more than once.

<a name='M-xyLOGIX-Core-Debug-Has-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [Has](#T-xyLOGIX-Core-Debug-Has 'xyLOGIX.Core.Debug.Has') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-Has-ConsoleWindow'></a>
### ConsoleWindow() `method`

##### Summary

Determines whether the application is currently running in a console window.

##### Returns

`true` if the application is running in a console window; `false` otherwise.

##### Parameters

This method has no parameters.

##### Remarks

This method first tries to get the value of the [WindowHeight](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.WindowHeight 'System.Console.WindowHeight') property. If this throws an exception, we return `false` since we aren't running in a console window.



If that check passes, then we return the negation of the return value of the [WindowsGui](#M-xyLOGIX-Core-Debug-Has-WindowsGui 'xyLOGIX.Core.Debug.Has.WindowsGui') method.



This algorithm assures us we get an accurate response, i.e., `false`, from this method if the caller is not running in a console and is NOT GUI-based; i.e., it is like a console app, but it is set to `Windows Application` type in the window in Visual Studio, but it never creates a window (at least, not using WPF or WinForms; this method cannot detect native Win32 P/Invoke calls to create a main window).

<a name='M-xyLOGIX-Core-Debug-Has-LoggingBeenSetUp'></a>
### LoggingBeenSetUp() `method`

##### Summary

Determines whether logging has been configured.

##### Returns

`true` if a backend has been assigned to the value of the [DefaultBackend](#P-PostSharp-Patterns-Diagnostics-LoggingServices-DefaultBackend 'PostSharp.Patterns.Diagnostics.LoggingServices.DefaultBackend') property besides the [NullLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Null-NullLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Null.NullLoggingBackend') .

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-Has-WindowsGui-System-Boolean-'></a>
### WindowsGui(useEntryAssembly) `method`

##### Summary

Determines whether the calling assembly (or the entry assembly, if `useEntryAssembly` is set to `true`, which it is not by default) is a Windows GUI application written with either WPF or WinForms.

##### Returns

A value that indicates whether the calling assembly (or the entry assembly, if `useEntryAssembly` is set to `true`, which it is not by default) is a Windows GUI application written with either WPF or WinForms.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| useEntryAssembly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Optional.) Default is `false` . If `true`, uses the entry-point assembly of the application to make its determination. Setting this parameter to `false` means the calling assembly is used instead. |

##### Remarks

This method works by assessing whether the entry or calling assembly, per the value of the `useEntryAssembly` parameter's argument, references either WPF or WinForm system framework assemblies.

<a name='T-xyLOGIX-Core-Debug-IAppenderManager'></a>
## IAppenderManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an `Appender Manager` object, that allows application-wide access to configured appender(s).

<a name='P-xyLOGIX-Core-Debug-IAppenderManager-AppenderCount'></a>
### AppenderCount `property`

##### Summary

Gets the count of appenders in the internal collection.

<a name='P-xyLOGIX-Core-Debug-IAppenderManager-Appenders'></a>
### Appenders `property`

##### Summary

Gets a reference to an instance of to an array of instances of objects that implement the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface, that are configured for use by the application.

<a name='P-xyLOGIX-Core-Debug-IAppenderManager-HasAppenders'></a>
### HasAppenders `property`

##### Summary

Gets a value indicating whether the internal collection has more than zero element(s).

<a name='M-xyLOGIX-Core-Debug-IAppenderManager-AddAppender-log4net-Appender-IAppender-'></a>
### AddAppender(appender) `method`

##### Summary

Adds a reference to an instance of an object that implements the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface to the list of configured appenders.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| appender | [log4net.Appender.IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') | (Required.) Reference to an instance of an object that implements the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface that is to be added to the internal collection. |

<a name='M-xyLOGIX-Core-Debug-IAppenderManager-GetFileAppenderByPath-System-String-'></a>
### GetFileAppenderByPath(logFilePath) `method`

##### Summary

Attempts to look up the `Appender` whose `File` property matches the specified `logFilePath` (ignoring case).

##### Returns

If successful, a reference to an instance of an object that implements the [IAppender](#T-log4net-Appender-IAppender 'log4net.Appender.IAppender') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| logFilePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of a file that is to be used to log messages. |

<a name='M-xyLOGIX-Core-Debug-IAppenderManager-HasAppenderWithFilePath-System-String-'></a>
### HasAppenderWithFilePath(filePath) `method`

##### Summary

Determines whether an `Appender` is present that corresponds to the specified `filePath`.

##### Returns

`true` if an `Appender` is present that corresponds to the specified `filePath`; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of a file for which to search. |

##### Remarks

If a `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is passed as the argument of the `filePath` parameter, then the method returns `false`.



The method also returns `false` if the internal collection is currently empty.

<a name='T-xyLOGIX-Core-Debug-IDebugLevelValidator'></a>
## IDebugLevelValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration.

<a name='M-xyLOGIX-Core-Debug-IDebugLevelValidator-IsValid-xyLOGIX-Core-Debug-DebugLevel-'></a>
### IsValid(level) `method`

##### Summary

Determines whether the debug `level` value passed is within the value set that is defined by the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration.

##### Returns

`true` if the debug `level` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| level | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | (Required.) One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-IDirectoryWriteabilityStatusValidator'></a>
## IDirectoryWriteabilityStatusValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') enumeration.

<a name='M-xyLOGIX-Core-Debug-IDirectoryWriteabilityStatusValidator-IsValid-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus-'></a>
### IsValid(status) `method`

##### Summary

Determines whether the directory writeability `status` value passed is within the value set that is defined by the [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') enumeration.

##### Returns

`true` if the directory writeability `status` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| status | [xyLOGIX.Core.Debug.DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') | (Required.) One of the [DirectoryWriteabilityStatus](#T-xyLOGIX-Core-Debug-DirectoryWriteabilityStatus 'xyLOGIX.Core.Debug.DirectoryWriteabilityStatus') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-IEventLogManager'></a>
## IEventLogManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed methods and properties of an object that manages our access to the Windows System Event Log(s).

<a name='P-xyLOGIX-Core-Debug-IEventLogManager-IsInitialized'></a>
### IsInitialized `property`

##### Summary

Gets a value indicating whether this object has been properly initialized.

<a name='P-xyLOGIX-Core-Debug-IEventLogManager-Source'></a>
### Source `property`

##### Summary

Gets or sets the quote of events. Typically, this is the name of the application that is sending the events.

##### Remarks

This property must be set before logging events, otherwise an error will occur.

<a name='P-xyLOGIX-Core-Debug-IEventLogManager-Type'></a>
### Type `property`

##### Summary

Gets or sets the type of log to which events are to be sent (Application, System, Security, etc.).

##### Remarks

This property must be set before logging events, otherwise an error will occur.

<a name='M-xyLOGIX-Core-Debug-IEventLogManager-Error-System-String-'></a>
### Error(content) `method`

##### Summary

Sends an Error event to the system event log pointed to by the [Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and [Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The content of the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String specifying the content of the event log message. |

<a name='M-xyLOGIX-Core-Debug-IEventLogManager-Info-System-String-'></a>
### Info(content) `method`

##### Summary

Sends an Info event to the system event log pointed to by the [Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and [Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The content of the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String specifying the content of the event log message. |

<a name='M-xyLOGIX-Core-Debug-IEventLogManager-Initialize-System-String,xyLOGIX-Core-Debug-EventLogType-'></a>
### Initialize(eventSourceName,logType) `method`

##### Summary

Initializes event logging for your application.

##### Returns

`true` if the operation(s) completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| eventSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name of the application that will be sending events. |
| logType | [xyLOGIX.Core.Debug.EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') | (Required.) One of the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') value(s) that specifies the type of log to send events to. |

<a name='M-xyLOGIX-Core-Debug-IEventLogManager-Warn-System-String-'></a>
### Warn(content) `method`

##### Summary

Sends a Warning event to the system event log pointed to by the [Source](#P-xyLOGIX-Core-Debug-EventLogManager-Source 'xyLOGIX.Core.Debug.EventLogManager.Source') and [Type](#P-xyLOGIX-Core-Debug-EventLogManager-Type 'xyLOGIX.Core.Debug.EventLogManager.Type') properties. The content of the logging message is specified by the `content` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String specifying the content of the event log message. |

<a name='T-xyLOGIX-Core-Debug-IEventLogTypeValidator'></a>
## IEventLogTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') enumeration.

<a name='M-xyLOGIX-Core-Debug-IEventLogTypeValidator-IsValid-xyLOGIX-Core-Debug-EventLogType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the event log `type` value passed is within the value set that is defined by the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') enumeration.

##### Returns

`true` if the event log `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') | (Required.) One of the [EventLogType](#T-xyLOGIX-Core-Debug-EventLogType 'xyLOGIX.Core.Debug.EventLogType') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-IFileWriteabilityStatusValidator'></a>
## IFileWriteabilityStatusValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') enumeration.

<a name='M-xyLOGIX-Core-Debug-IFileWriteabilityStatusValidator-IsValid-xyLOGIX-Core-Debug-FileWriteabilityStatus-'></a>
### IsValid(status) `method`

##### Summary

Determines whether the file writeability `status` value passed is within the value set that is defined by the [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') enumeration.

##### Returns

`true` if the file writeability `status` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| status | [xyLOGIX.Core.Debug.FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') | (Required.) One of the [FileWriteabilityStatus](#T-xyLOGIX-Core-Debug-FileWriteabilityStatus 'xyLOGIX.Core.Debug.FileWriteabilityStatus') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-ILoggingBackendTypeValidator'></a>
## ILoggingBackendTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration.

<a name='M-xyLOGIX-Core-Debug-ILoggingBackendTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingBackendType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the logging backend `type` value passed is within the value set that is defined by the [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration.

##### Returns

`true` if the logging backend `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') | (Required.) One of the [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') value(s) that is to be examined. |

##### Remarks

Besides the usual checks to see whether the value of the `type` parameter is within the defined value set of the [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration, or to make sure that the value of the `type` parameter is not set to [Unknown](#F-xyLOGIX-Core-Debug-LoggingBackendType-Unknown 'xyLOGIX.Core.Debug.LoggingBackendType.Unknown'), this method also ensures that the value of the `type` parameter can only ever be set to either [Console](#F-xyLOGIX-Core-Debug-LoggingBackendType-Console 'xyLOGIX.Core.Debug.LoggingBackendType.Console') or [Log4Net](#F-xyLOGIX-Core-Debug-LoggingBackendType-Log4Net 'xyLOGIX.Core.Debug.LoggingBackendType.Log4Net'), which are the only currently-supported value(s).

<a name='T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext'></a>
## ILoggingClientAssemblyContext `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that manages the logging-client assembly ticket that is associated with the current logical execution flow.

##### Remarks

Implementers maintain the current logging-client ticket independently for each logical execution flow.



A ticket value of [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty') indicates that no logging-client assembly is currently selected.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext-CurrentTicket'></a>
### CurrentTicket `property`

##### Summary

Gets the ticket that identifies the logging-client assembly associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, then this property returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

<a name='M-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext-Clear'></a>
### Clear() `method`

##### Summary

Clears the logging-client assembly ticket associated with the current logical execution flow.

##### Returns

`true` if the current ticket was successfully cleared; otherwise, `false`.

##### Parameters

This method has no parameters.

##### Remarks

This method assigns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty') to the current ticket.



If the operation fails, then the exception information is written to the Debug output and this method returns `false`.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext-Select-System-Guid-'></a>
### Select(ticket) `method`

##### Summary

Selects the logging-client assembly associated with the specified ticket for the current logical execution flow.

##### Returns

`true` if the specified ticket was successfully selected; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies a registered logging-client assembly. |

##### Remarks

If `ticket` is equal to [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), then this method returns `false` without changing the current ticket.



If the operation fails, then the exception information is written to the Debug output and this method returns `false`.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry'></a>
## ILoggingClientAssemblyRegistry `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that manages the registration of logging-client assembly(ies).

##### Remarks

Implementers associate each registered [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') with a unique [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') ticket.



Re-registering the same [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') returns the ticket that was assigned during its original registration.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry-GetAssembly-System-Guid-'></a>
### GetAssembly(ticket) `method`

##### Summary

Gets the assembly that is associated with the specified logging-client ticket.

##### Returns

Reference to the registered [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') associated with the specified ticket; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies a registered logging-client assembly. |

##### Remarks

If `ticket` is equal to [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), or no assembly is associated with it, then this method returns `null`.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry-GetTicket-System-Reflection-Assembly-'></a>
### GetTicket(assembly) `method`

##### Summary

Gets the logging-client ticket associated with the specified assembly.

##### Returns

A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies the specified assembly; otherwise, [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') whose ticket is to be obtained. |

##### Remarks

If `assembly` is `null`, or has not been registered, then this method returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

<a name='M-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry-Register-System-Reflection-Assembly-'></a>
### Register(assembly) `method`

##### Summary

Registers the specified logging-client assembly.

##### Returns

A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that uniquely identifies the registered assembly; otherwise, [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that is requesting logging services. |

##### Remarks

If `assembly` is `null`, then this method returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').



If the assembly has already been registered, then its existing ticket is returned.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLogProvider'></a>
## ILoggingClientLogProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that provides log4net logger object(s) for the current logging-client session.

##### Remarks

Implementers utilize the ordinary log4net repository when no specialized logging-client session is active.



If a valid specialized logging-client session is active, then implementers obtain logger object(s) exclusively from that session's repository.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLogProvider-GetLogForType-System-Type-'></a>
### GetLogForType(sourceType) `method`

##### Summary

Gets a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface for the specified source type.

##### Returns

Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that identifies the source of the logging record(s). |

##### Remarks

If `sourceType` is `null`, then this method returns `null`.



If no specialized logging-client session is active, then this method obtains the logger from the ordinary log4net repository.



If a specialized session is active but its logger cannot be obtained, then this method returns `null` rather than falling back to a repository owned by another in-process software component.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCache'></a>
## ILoggingClientLoggerCache `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a component that stores and retrieves logger object(s) by their logging-client logger-cache key(s).

##### Remarks

Implementers must perform each cache operation atomically and must not expose their synchronization object(s) or underlying collection(s) to callers.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientLoggerCache-Count'></a>
### Count `property`

##### Summary

Gets an [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that indicates the number of logger object(s) currently stored in the cache.

##### Remarks

The value returned by this property is an atomic, point-in-time snapshot of the cache element count.



Callers must not assume that the count remains unchanged after the property getter returns.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCache-Clear'></a>
### Clear() `method`

##### Summary

Removes all logger object(s) from the cache.

##### Returns

`true` if the cache already contains zero element(s) or is cleared successfully; otherwise, `false`.

##### Parameters

This method has no parameters.

##### Remarks

If the cache already contains zero element(s), then this method returns `true` without modifying the cache.



If the cache cannot be cleared, then this method returns `false`.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCache-TryAdd-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog-'></a>
### TryAdd(cacheKey,logger) `method`

##### Summary

Attempts to add the specified `logger` to the cache by using the specified `cacheKey`.

##### Returns

`true` if the logger is already cached or is added successfully; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cacheKey | [xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') | (Required.) Reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface that uniquely identifies the logger within a particular log4net repository. |
| logger | [log4net.ILog](#T-log4net-ILog 'log4net.ILog') | (Required.) Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that is to be stored in the cache. |

##### Remarks

If a `null` reference is passed for the `cacheKey` or `logger` parameter, then this method returns `false`.



If a non-`null` logger is already cached for the specified `cacheKey`, then this method leaves the existing logger unchanged and returns `true`.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCache-TryGet-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog@-'></a>
### TryGet(cacheKey,logger) `method`

##### Summary

Attempts to obtain the logger associated with the specified `cacheKey`.

##### Returns

`true` if a non-`null` logger is obtained from the cache; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cacheKey | [xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') | (Required.) Reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface that uniquely identifies the logger within a particular log4net repository. |
| logger | [log4net.ILog@](#T-log4net-ILog@ 'log4net.ILog@') | (Output.) If successful, receives a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that is associated with the specified `cacheKey`; otherwise, receives a `null` reference. |

##### Remarks

If a `null` reference is passed for the `cacheKey` parameter, no matching cache entry exists, or the matching cache entry contains a `null` reference, then this method assigns a `null` reference to the `logger` parameter and returns `false`.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator'></a>
## ILoggingClientLoggerCacheAddActionValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration value(s).

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-'></a>
### IsValid(action) `method`

##### Summary

Determines whether the logging-client logger-cache `Add``action` value passed is within the value set defined by the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration.

##### Returns

`true` if the logging-client logger-cache `Add``action` falls within the defined value set and is not equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') | (Required.) One of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') value(s) that is to be examined. |

##### Remarks

If the value of the `action` parameter is outside the defined value set, or is equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown'), then this method returns `false`.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler'></a>
## ILoggingClientLoggerCacheAddHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a handler strategy that selects the action to perform for a particular logging-client logger-cache `Add` scenario.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler-HandlerType'></a>
### HandlerType `property`

##### Summary

Gets a [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the cache-add handler strategy implemented by this object.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler-Handle'></a>
### Handle() `method`

##### Summary

Selects the logging-client logger-cache `Add` action that corresponds to the scenario represented by this handler strategy.

##### Returns

One of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration value(s) that identifies the action to perform; otherwise, [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown') is returned.

##### Parameters

This method has no parameters.

##### Remarks

This method does not access or mutate the logging-client logger cache.



The caller is responsible for applying the returned action, verifying the resulting cache state, and constructing the corresponding [ILoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult') object.



If the correct action cannot be selected, or an error occurs, then this method returns [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown').

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator'></a>
## ILoggingClientLoggerCacheAddHandlerTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the internally-exposed events, methods and properties of a validator of [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the logging-client logger cache `Add` handler `type` value passed is within the value set that is defined by the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration.

##### Returns

`true` if the logging-client logger cache `Add` handler `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') values that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator'></a>
## ILoggingClientLoggerCacheAddOutcomeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the internally-exposed events, methods and properties of a validator of [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-'></a>
### IsValid(outcome) `method`

##### Summary

Determines whether the logging-client logger-cache `Add``outcome` value passed is within the value set that is defined by the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration.

##### Returns

`true` if the logging-client logger-cache `Add``outcome` falls within the defined value set and is not equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| outcome | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') | (Required.) One of the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') values that is to be examined. |

##### Remarks

If the value of the `outcome` parameter is outside the defined value set, or is equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown'), then this method returns `false`.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult'></a>
## ILoggingClientLoggerCacheAddResult `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that describes the result of an attempt to add a logger to the logging-client logger cache.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult-HandlerType'></a>
### HandlerType `property`

##### Summary

Gets a [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the Handler Chain link that accepted responsibility for the cache-add operation.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult-Outcome'></a>
### Outcome `property`

##### Summary

Gets a [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration value that describes the final outcome of the cache-add operation.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResultBuilder'></a>
## ILoggingClientLoggerCacheAddResultBuilder `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed methods and properties of a builder that completes the construction of a logging-client logger-cache `Add` result.

##### Remarks

An object that implements this interface retains a previously validated [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') value and completes construction when supplied with a valid, compatible [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') value.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResultBuilder-AndOutcome-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-'></a>
### AndOutcome(outcome) `method`

##### Summary

Completes the construction of a logging-client logger-cache `Add` result having the specified `outcome`.

##### Returns

If successful, a reference to a new instance of an object that implements the [ILoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| outcome | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') | (Required.) A [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration value that describes the final outcome of the cache-add operation. |

##### Remarks

The specified `outcome` must be valid and compatible with the Handler Chain link type previously supplied to the builder.



If the specified value is invalid, is incompatible with the retained Handler Chain link type, or an error occurs, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey'></a>
## ILoggingClientLoggerCacheKey `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that uniquely identifies a logger within a particular log4net repository.

##### Remarks

Implementers identify a logger by combining the object identity of its repository with its ordinal logger name.



Two cache-key object(s) that refer to the same repository instance and contain the same logger name represent the same logical cache entry.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-LoggerName'></a>
### LoggerName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the name of the logger within the repository identified by the [Repository](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-Repository 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.Repository') property.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-Repository'></a>
### Repository `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that contains the logger identified by the [LoggerName](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-LoggerName 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.LoggerName') property.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyBuilder'></a>
## ILoggingClientLoggerCacheKeyBuilder `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a component that completes the construction of a logging-client logger-cache key.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyBuilder-AndLoggerNamed-System-String-'></a>
### AndLoggerNamed(loggerName) `method`

##### Summary

Creates a new logging-client logger-cache key for the repository previously supplied to the builder and the specified `loggerName`.

##### Returns

If successful, a reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value containing the name of the logger within the repository previously supplied to the builder. |

##### Remarks

If a `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is passed for the `loggerName` parameter, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator'></a>
## ILoggingClientLoggerCacheKeyValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a component that validates logging-client logger-cache key object(s).

<a name='M-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator-IsValid-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-'></a>
### IsValid(cacheKey) `method`

##### Summary

Determines whether the specified `cacheKey` contains all the information required to identify a logger within a particular log4net repository.

##### Returns

`true` if the specified cache key is valid; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cacheKey | [xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') | (Required.) Reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface that is to be validated. |

##### Remarks

If a `null` reference is passed for the `cacheKey` parameter, then this method returns `false`.



This method also returns `false` if the [Repository](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-Repository 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.Repository') property has a `null` reference for a value or the [LoggerName](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-LoggerName 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.LoggerName') property is blank.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientSession'></a>
## ILoggingClientSession `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that represents the logging services assigned to a registered logging-client assembly.

##### Remarks

Each logging-client session owns a dedicated [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') and corresponding [LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend').

<a name='P-xyLOGIX-Core-Debug-ILoggingClientSession-Backend'></a>
### Backend `property`

##### Summary

Gets a reference to an instance of [LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that writes PostSharp logging record(s) to the repository assigned to this session.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientSession-ClientAssembly'></a>
### ClientAssembly `property`

##### Summary

Gets a reference to the [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that requested this logging session.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientSession-Repository'></a>
### Repository `property`

##### Summary

Gets a reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is dedicated to this logging-client session.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientSession-RepositoryName'></a>
### RepositoryName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the unique name assigned to the log4net repository for this logging-client session.

<a name='P-xyLOGIX-Core-Debug-ILoggingClientSession-Ticket'></a>
### Ticket `property`

##### Summary

Gets a [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that uniquely identifies this logging-client session.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientSession-Clear'></a>
### Clear() `method`

##### Summary

Resets the property(ies) of this session to their default value(s).

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientSession-IsValid'></a>
### IsValid() `method`

##### Summary

Determines whether this logging-client session contains all required information and service reference(s).

##### Returns

`true` if this logging-client session is valid; otherwise, `false`.

##### Parameters

This method has no parameters.

##### Remarks

This method returns `false` if the [Ticket](#P-xyLOGIX-Core-Debug-ILoggingClientSession-Ticket 'xyLOGIX.Core.Debug.ILoggingClientSession.Ticket') property is equal to [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), any required reference is `null`, or the repository name is blank.

<a name='T-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry'></a>
## ILoggingClientSessionRegistry `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that manages registered logging-client session object(s).

<a name='M-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry-Get-System-Guid-'></a>
### Get(ticket) `method`

##### Summary

Gets the logging-client session associated with the specified ticket.

##### Returns

Reference to an instance of an object that implements the [ILoggingClientSession](#T-xyLOGIX-Core-Debug-ILoggingClientSession 'xyLOGIX.Core.Debug.ILoggingClientSession') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies a registered logging-client session. |

##### Remarks

If `ticket` equals [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), or no corresponding session exists, this method returns `null`.

<a name='M-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry-GetOrCreate-System-Guid,System-Reflection-Assembly-'></a>
### GetOrCreate(ticket,clientAssembly) `method`

##### Summary

Gets or creates the logging-client session associated with the specified ticket and assembly.

##### Returns

Reference to the existing or newly created instance of an object that implements the [ILoggingClientSession](#T-xyLOGIX-Core-Debug-ILoggingClientSession 'xyLOGIX.Core.Debug.ILoggingClientSession') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies the registered logging-client assembly. |
| clientAssembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that requested logging services. |

##### Remarks

If either argument is invalid, or session creation fails, this method returns `null`.

<a name='T-xyLOGIX-Core-Debug-ILoggingConfigurator'></a>
## ILoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a `Logging Configurator` object that initializes logging based on whether said configuration is specifically spelled out in the `app.config` or `web.config` file, or if we are programmatically configuring logging.

<a name='P-xyLOGIX-Core-Debug-ILoggingConfigurator-Type'></a>
### Type `property`

##### Summary

Gets or sets one of the [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') enumeration value(s) that indicates which type of configuration this `Logging Configurator` does.

<a name='M-xyLOGIX-Core-Debug-ILoggingConfigurator-Configure-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### Configure(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` if we should not write out `DEBUG` messages to the log file when in the `Release` mode. Set to `false` if all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for initializing log4net. If blank, the system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the console if a log file is being used. If a log file is not used, then no logging at all will occur if this parameter is set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the `XMLConfigurator` object is used to configure logging.    Else, specify here the path to the log file to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a user-friendly display name of the application that is using this logging library.    Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. Supply a value for this parameter if your infrastructure is not utilizing the default HierarchicalRepository. |

<a name='T-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator'></a>
## ILoggingConfiguratorTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') enumeration.

<a name='M-xyLOGIX-Core-Debug-ILoggingConfiguratorTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingConfiguratorType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the logging configurator `type` value passed is within the value set that is defined by the [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') enumeration.

##### Returns

`true` if the logging configurator `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') | (Required.) One of the [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-ILoggingInfrastructure'></a>
## ILoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the methods and properties of a custom object to which the [LoggingSubsystemManager](#T-xyLOGIX-Core-Debug-LoggingSubsystemManager 'xyLOGIX.Core.Debug.LoggingSubsystemManager') delegates the implementation of its properties and methods.

<a name='P-xyLOGIX-Core-Debug-ILoggingInfrastructure-LogFileName'></a>
### LogFileName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the log file of this application.

<a name='P-xyLOGIX-Core-Debug-ILoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') value that corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the [File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the first appender in the list of appenders that is of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the appender is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the [LogFileName](#P-Core-Debug-ILoggingInfrastructure-LogFileName 'Core.Debug.ILoggingInfrastructure.LogFileName') property.

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Returns

`true` if the logging subsystem initialization process completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write out "DEBUG" messages to the log file when in the Release mode. Set to false if all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| configurationFileNamename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for initializing log4net. If blank, the system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the console if a log file is being used. If a log file is not used, then no logging at all will occur if this parameter is set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the `XMLConfigurator` object is used to configure logging.    Else, specify here the path to the log file to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a user-friendly display name of the application that is using this logging library.    Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is to be configured for the current specialized logging-client session.    If `null`, the implementation utilizes its existing legacy repository-selection behavior. |

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructure-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') to initialize its functionality.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any logging statements that are set to [Debug](#F-DebugLevel-Debug 'DebugLevel.Debug'). |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log file; false to suppress. Usually used with the `consoleOnly` parameter set to `true`. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to write them both to the console and to the log. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Zero to suppress every message; greater than zero to echo every message. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all console output. |

<a name='T-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator'></a>
## ILoggingInfrastructureTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') enumeration.

<a name='M-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the logging infrastructure `type` value passed is within the value set that is defined by the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') enumeration.

##### Returns

`true` if the logging infrastructure `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Required.) One of the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-IOutputLocation'></a>
## IOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed methods and properties of an object that writes output logging lines to multiple destinations at the same time..

<a name='P-xyLOGIX-Core-Debug-IOutputLocation-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is turned on or off.

<a name='P-xyLOGIX-Core-Debug-IOutputLocation-Type'></a>
### Type `property`

##### Summary

Gets one of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration values that indicates the final base of text strings that are fed to this location.

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Remarks

This method does nothing if the specified `value` is a `null` reference, or if the value of the [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole') property is set to `true`.

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

This method takes no action if a `null`, blank, or empty [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is supplied as the argument of the `format` parameter.



This method will not work if the `format` parameter has format argument(s) in it, but the `arg` array is a `null` reference, contains a mismatching number of element(s), or if it contains element(s) whose value(s) do not match the format specifier(s) in the `format` parameter.

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the output location.

##### Parameters

This method has no parameters.

##### Remarks

This method takes no action if the [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole') property is set to `true`.

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects, followed by the current line terminator, to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

This method takes no action if a `null`, blank, or empty [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is supplied as the argument of the `format` parameter.



This method will not work if the `format` parameter has format argument(s) in it, but the `arg` array is a `null` reference, contains a mismatching number of element(s), or if it contains element(s) whose value(s) do not match the format specifier(s) in the `format` parameter.

<a name='M-xyLOGIX-Core-Debug-IOutputLocation-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by the current line terminator, to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Remarks

This method does nothing if the specified `value` is a `null` reference, or if the value of the [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole') property is set to `true`.

<a name='T-xyLOGIX-Core-Debug-IOutputLocationProvider'></a>
## IOutputLocationProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed methods and properties of an object that writes output logging lines to multiple destinations at the same time..

<a name='P-xyLOGIX-Core-Debug-IOutputLocationProvider-HasLocations'></a>
### HasLocations `property`

##### Summary

Gets a value indicating whether greater than zero output location(s) are currently configured.

##### Returns

`true` if greater than zero output location(s) are currently configured; `false` otherwise.

<a name='P-xyLOGIX-Core-Debug-IOutputLocationProvider-LocationCount'></a>
### LocationCount `property`

##### Summary

Gets the count of `Output Location`(s) that are currently defined.

##### Returns

An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that is set to the count of `Output Location`(s) that are currently defined.

##### Remarks

If an exception is caught during the execution of the getter of this property, then the property evaluates to zero.

<a name='P-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is turned on or off.

##### Remarks

This property raises the [](#E-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsoleChanged 'xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsoleChanged') event when its value is updated.

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-AddOutputLocation-xyLOGIX-Core-Debug-IOutputLocation-'></a>
### AddOutputLocation(location) `method`

##### Summary

Adds the specified output `location` to the public list maintained by this object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [xyLOGIX.Core.Debug.IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') | (Required.) Reference to an instance of an object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface. |

##### Remarks

If the specified `location` has already been added, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-Clear'></a>
### Clear() `method`

##### Summary

Clears the public list of output locations.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or `arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in `format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by the current line terminator, to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,args) `method`

##### Summary

Writes the text representation of the specified array of objects, followed by the current line terminator, to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or `args` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in `format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-IOutputLocationProvider-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the output location.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='T-xyLOGIX-Core-Debug-IOutputLocationTypeValidator'></a>
## IOutputLocationTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration.

<a name='M-xyLOGIX-Core-Debug-IOutputLocationTypeValidator-IsValid-xyLOGIX-Core-Debug-OutputLocationType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the output location `type` value passed is within the value set that is defined by the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration.

##### Returns

`true` if the output location `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') | (Required.) One of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter'></a>
## IPostSharpLoggingBackendRouter `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that manages the process-wide PostSharp logging backend used to route logging record(s) to specialized logging-client repository(ies).

##### Remarks

Implementers preserve the ordinary logging repository as a fallback while routing logging record(s) associated with a specialized logging-client session to that session's dedicated repository.

<a name='P-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter-FallbackRepository'></a>
### FallbackRepository `property`

##### Summary

Gets a reference to the log4net repository that receives logging record(s) when no specialized logging-client session is active.

<a name='P-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter-IsInstalled'></a>
### IsInstalled `property`

##### Summary

Gets a value indicating whether the process-wide PostSharp logging router has been installed.

<a name='M-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter-InstallOrUpdate-log4net-Repository-ILoggerRepository-'></a>
### InstallOrUpdate(fallbackRepository) `method`

##### Summary

Installs the process-wide PostSharp logging router, or updates its fallback repository if the router has already been installed.

##### Returns

`true` if the router was successfully installed or updated; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fallbackRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is to receive logging record(s) when no specialized logging-client session is active. |

##### Remarks

A `null` value for `fallbackRepository` is permitted.



If no fallback repository is available, logging record(s) emitted outside a specialized session are not forwarded to another logging repository.

<a name='T-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration'></a>
## IRollingFileAppenderConfiguration `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that encapsulates the configuration for a [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender').

<a name='P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-AppendToFile'></a>
### AppendToFile `property`

##### Summary

Gets or sets a flag that indicates whether the file should be appended to or overwritten.

##### Remarks

If the value is set to `false` then the file will be overwritten, if it is set to `true` then the file will be appended to.

The default value is `true`.

<a name='P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-File'></a>
### File `property`

##### Summary

Gets or sets the path to the file that logging will be written to.

##### Remarks

If the path is relative it is taken as relative from the application     base directory.

<a name='P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-Layout'></a>
### Layout `property`

##### Summary

Gets or sets the [ILayout](#T-log4net-Layout-ILayout 'log4net.Layout.ILayout') for this appender.

##### Remarks

See [RequiresLayout](#P-log4net-Appender-AppenderSkeleton-RequiresLayout 'log4net.Appender.AppenderSkeleton.RequiresLayout') for more information.

##### See Also

- [RequiresLayout](#!-RequiresLayout 'RequiresLayout')

<a name='P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-MaxSizeRollBackups'></a>
### MaxSizeRollBackups `property`

##### Summary

Gets or sets the maximum number of backup files that are kept before the oldest is erased.

##### Remarks

If set to zero, then there will be no backup files and the log file     will be truncated when it reaches     [MaxFileSize](#P-log4net-Appender-RollingFileAppender-MaxFileSize 'log4net.Appender.RollingFileAppender.MaxFileSize').

If a negative number is supplied then no deletions will be made. Note     that this could result in very slow performance as a large number of files     are rolled over unless     [CountDirection](#P-log4net-Appender-RollingFileAppender-CountDirection 'log4net.Appender.RollingFileAppender.CountDirection') is     used.

The maximum applies to time based group of files and     the total.

<a name='P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-MaximumFileSize'></a>
### MaximumFileSize `property`

##### Summary

Gets or sets the maximum size that the output file is allowed to reach before being rolled over to back-up files.

##### Remarks

This property allows you to specify the maximum size with the     suffixes "KB", "MB" or "GB" so that the size is interpreted being expressed     respectively in kilobytes, megabytes or gigabytes.

For example, the value "10KB" will be interpreted as 10240 bytes.

The default maximum file size is 10MB.

<a name='P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-RollingStyle'></a>
### RollingStyle `property`

##### Summary

Gets or sets the rolling style.

##### Remarks

The default rolling style is     [Composite](#F-log4net-Appender-RollingFileAppender-RollingMode-Composite 'log4net.Appender.RollingFileAppender.RollingMode.Composite') .

When set to     [Once](#F-log4net-Appender-RollingFileAppender-RollingMode-Once 'log4net.Appender.RollingFileAppender.RollingMode.Once') this     appender's [AppendToFile](#P-log4net-Appender-FileAppender-AppendToFile 'log4net.Appender.FileAppender.AppendToFile') property is set to `false`, otherwise the appender would     append to a single file rather than rolling the file each time it is     opened.

<a name='P-xyLOGIX-Core-Debug-IRollingFileAppenderConfiguration-StaticLogFileName'></a>
### StaticLogFileName `property`

##### Summary

Gets or sets a value indicating whether to always log to the same file.

##### Remarks

By default, file.log is always the current file. Optionally     file.log.yyyy-mm-dd for current formatted datePattern can by the currently     logging file (or file.log.curSizeRollBackup or even     file.log.yyyy-mm-dd.curSizeRollBackup).

This will make time based rollovers with a large number of backups     much faster as the appender it won't have to rename all the backups!

<a name='T-xyLOGIX-Core-Debug-IRollingModeValidator'></a>
## IRollingModeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') enumeration.

<a name='M-xyLOGIX-Core-Debug-IRollingModeValidator-IsValid-log4net-Appender-RollingFileAppender-RollingMode-'></a>
### IsValid(mode) `method`

##### Summary

Determines whether the rolling `mode` value passed is within the value set that is defined by the [RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') enumeration.

##### Returns

`true` if the rolling `mode` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mode | [log4net.Appender.RollingFileAppender.RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') | (Required.) One of the [RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-IRootLoggerProvisioner'></a>
## IRootLoggerProvisioner `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provisions the `Root Logger` for the application depending on the determined [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy').

<a name='P-xyLOGIX-Core-Debug-IRootLoggerProvisioner-Strategy'></a>
### Strategy `property`

##### Summary

Gets the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration value that indicates the strategy used to provision the `Root Logger`.

<a name='M-xyLOGIX-Core-Debug-IRootLoggerProvisioner-Provision-log4net-Repository-ILoggerRepository-'></a>
### Provision(loggerRepository) `method`

##### Summary

Provisions the `Root Logger` for the application depending on the value of the `loggerRepository` parameter.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') |  |

##### Remarks

If the provided `loggerRepository` can be directly cast to [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy'), then this method returns a reference to an instance of [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger') that is at the root of such a [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy').



If a `null` reference is passed for the value of the `loggerRepository` parameter, then this method attempts to find the default appender configuration and attempts to then return a reference to that configuration's [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger').



If the first two attempts fail, then this method returns a `null` reference.



If this particular `Root Logger Provisioner` is configured to use the [FromLogManager](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager') strategy, then this method attempts to find the default appender configuration and attempts to then return a reference to that configuration's [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger').



Failing that, a `null` reference is returned.

<a name='T-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator'></a>
## IRootLoggerProvisioningStrategyValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration.

<a name='M-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator-IsValid-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-'></a>
### IsValid(strategy) `method`

##### Summary

Determines whether the root-logger provisioning `strategy` value passed is within the value set that is defined by the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration.

##### Returns

`true` if the root-logger provisioning `strategy` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| strategy | [xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') | (Required.) One of the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator'></a>
## ISessionLoggerFetchApproachValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the internally-exposed events, methods and properties of a validator of [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration.

<a name='M-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator-IsValid-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-'></a>
### IsValid(approach) `method`

##### Summary

Determines whether the session logger fetching `approach` value passed is within the value set that is defined by the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration.

##### Returns

`true` if the session logger fetching `approach` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| approach | [xyLOGIX.Core.Debug.SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') | (Required.) One of the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') values that is to be examined. |

<a name='M-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator-IsValidSilent-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-'></a>
### IsValidSilent(approach) `method`

##### Summary

Determines whether the session logger fetching `approach` value passed is within the value set that is defined by the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration.

##### Returns

`true` if the session logger fetching `approach` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| approach | [xyLOGIX.Core.Debug.SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') | (Required.) One of the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') values that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-ISessionLoggerFetcher'></a>
## ISessionLoggerFetcher `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of an object that is responsible for fetching loggers for client session(s).

<a name='P-xyLOGIX-Core-Debug-ISessionLoggerFetcher-Approach'></a>
### Approach `property`

##### Summary

Gets the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that identifies the particular approach that is to be utilized to fetch a logger for a client session, or to use the legacy logger if no other approach is available.

<a name='M-xyLOGIX-Core-Debug-ISessionLoggerFetcher-FetchLogger-System-Type,System-String-'></a>
### FetchLogger(sourceType,repositoryName) `method`

##### Summary

Attempts to fetch a logger for a client session by using specified `sourceType` and optional `repositoryName`, if specified, per the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that is specified by the [Approach](#P-xyLOGIX-Core-Debug-ISessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.ISessionLoggerFetcher.Approach') property.

##### Returns

If successful, a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that is utilized to identify the logger that is to be fetched for a client session.    Perhaps this value might come from an internal cache. |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that is set to the name of the repository that is associated with the logger that is to be fetched for a client session.    If this value is not specified, then the default repository name will be used.    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.    The repository name is only to be provided when a more refined search is to be employed.    In such a case where we are searching on the repository name, then the value of the `repositoryName` parameter must be specified, and it must not be [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty'). |

<a name='T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator'></a>
## IXmlLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a `XML Logging Configurator` object.

##### Remarks

Such an object configures the logging subsystem by one means or another, depending on whether an XML configuration file is available or not.

<a name='P-xyLOGIX-Core-Debug-IXmlLoggingConfigurator-Type'></a>
### Type `property`

##### Summary

Gets or sets one of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration values that specifies how the logging subsystem is to be configured.

<a name='M-xyLOGIX-Core-Debug-IXmlLoggingConfigurator-Configure-log4net-Repository-ILoggerRepository,System-String-'></a>
### Configure(repository,configurationFileName) `method`

##### Summary

Attempts to configure the logging subsystem, optionally with the settings that are present in the configuration file having the specified `configurationFileName`.

##### Returns

`true` if the configuration operation(s) succeeded; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified configurationFileName of the XML-formatted configuration file containing the necessary logging setting(s).    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value. |

##### Remarks

The value of the `configurationFileName` parameter is ignored if this is a `XML Logging Configurator` object of type [NoFile](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile').



Otherwise, if this `XML Logging Configurator` is of type, [FileBased](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased'), then the `configurationFileName` had better contain the fully-qualified configurationFileName of a `.config` file containing the logging settings, or else this method will fail.

<a name='T-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator'></a>
## IXmlLoggingConfiguratorTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a validator of [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration values.

##### Remarks

Specifically, objects that implement this interface ascertain whether the values of variables fall within the value set that is defined by the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration.

<a name='M-xyLOGIX-Core-Debug-IXmlLoggingConfiguratorTypeValidator-IsValid-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the XML logging configurator `type` value passed is within the value set that is defined by the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration.

##### Returns

`true` if the XML logging configurator `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') | (Required.) One of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') value(s) that is to be examined. |

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



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-Initialize-Logging-System-String-'></a>
### Logging(applicationName) `method`

##### Summary

Called once per application to initialize the logging subsystem.

##### Returns

`true` if the initialization was successful; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the name to be used for the application in the log file's pathname.    All whitespace will be removed. |

##### Remarks

This method is to be utilized if you aren't utilizing a logging framework, such as `log4net` or `PostSharp` etc.

<a name='T-xyLOGIX-Core-Debug-InvalidClientAssemblyNames'></a>
## InvalidClientAssemblyNames `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Value(s) for the name(s) of assembly(ies) that are not valid for use as a client of this library (except to wrap it).

<a name='F-xyLOGIX-Core-Debug-InvalidClientAssemblyNames-All'></a>
### All `constants`

##### Summary

Contains all the name(s) of those assembly(ies) that are not valid for use as a client of this library (except to wrap it).

<a name='F-xyLOGIX-Core-Debug-InvalidClientAssemblyNames-CoreTemplateLoggingWizards'></a>
### CoreTemplateLoggingWizards `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the name of the `xyLOGIX.Core.TemplateWizard.Logging` assembly, which is not valid for use as a client of this library (except to wrap it).

<a name='M-xyLOGIX-Core-Debug-InvalidClientAssemblyNames-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [InvalidClientAssemblyNames](#T-xyLOGIX-Core-Debug-InvalidClientAssemblyNames 'xyLOGIX.Core.Debug.InvalidClientAssemblyNames') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-IsLog'></a>
## IsLog `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods and properties to determine whether facts about logs or logging are true.

<a name='P-xyLOGIX-Core-Debug-IsLog-Initialized'></a>
### Initialized `property`

##### Summary

Gets a value that determines whether the logging system has been initialized.

##### Returns

`true` if the logging system has been initialized; `false` otherwise.

<a name='T-xyLOGIX-Core-Debug-LoggerManager'></a>
## LoggerManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods to access objects of type [Logger](#T-log4net-Hierarchy-Repository-Logger 'log4net.Hierarchy.Repository.Logger') from log4net.

<a name='P-xyLOGIX-Core-Debug-LoggerManager-RootLoggerProvisioningStrategyValidator'></a>
### RootLoggerProvisioningStrategyValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-IRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.IRootLoggerProvisioningStrategyValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggerManager-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [LoggerManager](#T-xyLOGIX-Core-Debug-LoggerManager 'xyLOGIX.Core.Debug.LoggerManager') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggerManager-GetRootLogger-log4net-Repository-ILoggerRepository-'></a>
### GetRootLogger(loggerRepository) `method`

##### Summary

Gets a reference to the default logger repository's root instance of [Logger](#T-log4net-Hierarchy-Repository-Logger 'log4net.Hierarchy.Repository.Logger').

##### Returns

Reference to an instance of [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger') that refers to the `Root Logger` component that is to be used, if found; a `null` reference is returned otherwise.

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

<a name='P-xyLOGIX-Core-Debug-LoggerRepositoryManager-InitialRepository'></a>
### InitialRepository `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that was provided to the subsystem at initialization time.

<a name='M-xyLOGIX-Core-Debug-LoggerRepositoryManager-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [LoggerRepositoryManager](#T-xyLOGIX-Core-Debug-LoggerRepositoryManager 'xyLOGIX.Core.Debug.LoggerRepositoryManager') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetHierarchyRepository'></a>
### GetHierarchyRepository() `method`

##### Summary

Gets a reference to an instance of the log4net repository as an reference to an object of type [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy').

##### Returns

Reference to an instance of a [](#I-ILoggerRepository 'ILoggerRepository') that derives from [Hierarchy](#T-log4net-Repository-Hierarchy 'log4net.Repository.Hierarchy'), or null if no such object has been found.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-LoggerRepositoryManager-GetLoggerRepository'></a>
### GetLoggerRepository() `method`

##### Summary

Wraps the [GetRepository](#M-log4net-LogManager-GetRepository 'log4net.LogManager.GetRepository') method.

##### Returns

Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface, or null if such an object cannot be found.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-LoggingBackendType'></a>
## LoggingBackendType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Enumerated values that allow us to select from among the supported logging backends.

##### Remarks

THis enumeration is only to be used when PostSharp is selected as the logging infrastructure.

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

<a name='T-xyLOGIX-Core-Debug-LoggingBackendTypeValidator'></a>
## LoggingBackendTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration.

<a name='M-xyLOGIX-Core-Debug-LoggingBackendTypeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-LoggingBackendTypeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingBackendTypeValidator](#T-xyLOGIX-Core-Debug-Interfaces-ILoggingBackendTypeValidator 'xyLOGIX.Core.Debug.Interfaces.ILoggingBackendTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingBackendTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-LoggingBackendTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingBackendType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the logging backend `type` value passed is within the value set that is defined by the [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration.

##### Returns

`true` if the logging backend `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') | (Required.) One of the [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') value(s) that is to be examined. |

##### Remarks

Besides the usual checks to see whether the value of the `type` parameter is within the defined value set of the [LoggingBackendType](#T-xyLOGIX-Core-Debug-LoggingBackendType 'xyLOGIX.Core.Debug.LoggingBackendType') enumeration, or to make sure that the value of the `type` parameter is not set to [Unknown](#F-xyLOGIX-Core-Debug-LoggingBackendType-Unknown 'xyLOGIX.Core.Debug.LoggingBackendType.Unknown'), this method also ensures that the value of the `type` parameter can only ever be set to either [Console](#F-xyLOGIX-Core-Debug-LoggingBackendType-Console 'xyLOGIX.Core.Debug.LoggingBackendType.Console') or [Log4Net](#F-xyLOGIX-Core-Debug-LoggingBackendType-Log4Net 'xyLOGIX.Core.Debug.LoggingBackendType.Log4Net'), which are the only currently-supported value(s).

<a name='T-xyLOGIX-Core-Debug-LoggingClientAssemblyContext'></a>
## LoggingClientAssemblyContext `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Manages the logging-client assembly ticket associated with the current logical execution flow.

##### Remarks

This class utilizes [AsyncLocal\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.AsyncLocal`1 'System.Threading.AsyncLocal`1') so that the selected logging-client assembly follows the current logical execution flow, including continuations that occur after an `await` operation.



This class does not utilize any attribute(s) from `PostSharp.Patterns.Threading`.

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-LoggingClientAssemblyContext 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-Instance 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext.Instance') property.

<a name='F-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-_currentTicket'></a>
### _currentTicket `constants`

##### Summary

Reference to an instance of [AsyncLocal\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.AsyncLocal`1 'System.Threading.AsyncLocal`1') that stores the logging-client assembly ticket associated with the current logical execution flow.

<a name='P-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-CurrentTicket'></a>
### CurrentTicket `property`

##### Summary

Gets the ticket that identifies the logging-client assembly associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, then this property returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

<a name='P-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-LoggingClientAssemblyContext 'xyLOGIX.Core.Debug.LoggingClientAssemblyContext') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-Clear'></a>
### Clear() `method`

##### Summary

Clears the logging-client assembly ticket associated with the current logical execution flow.

##### Returns

`true` if the current ticket was successfully cleared; otherwise, `false`.

##### Parameters

This method has no parameters.

##### Remarks

This method assigns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty') to the current ticket.



If the operation fails, then the exception information is written to the Debug output and this method returns `false`.

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyContext-Select-System-Guid-'></a>
### Select(ticket) `method`

##### Summary

Selects the logging-client assembly associated with the specified ticket for the current logical execution flow.

##### Returns

`true` if the specified ticket was successfully selected; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies a registered logging-client assembly. |

##### Remarks

If `ticket` is equal to [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), then this method returns `false` without changing the current ticket.



If the operation fails, then the exception information is written to the Debug output and this method returns `false`.

<a name='T-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry'></a>
## LoggingClientAssemblyRegistry `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Manages the registration of assembly(ies) that request logging services.

##### Remarks

This class implements a thread-safe, process-local ticket registry.



A single instance is shared by all callers through the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-Instance 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.Instance') property.

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-Instance 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry.Instance') property.

<a name='F-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-_syncRoot'></a>
### _syncRoot `constants`

##### Summary

Reference to an object used to synchronize access to the registered assembly/ticket mapping.

<a name='F-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-_ticketsByAssembly'></a>
### _ticketsByAssembly `constants`

##### Summary

Reference to a collection that associates each registered [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') with its corresponding [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') ticket.

<a name='P-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.LoggingClientAssemblyRegistry') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-GetAssembly-System-Guid-'></a>
### GetAssembly(ticket) `method`

##### Summary

Gets the assembly that is associated with the specified logging-client ticket.

##### Returns

Reference to the registered [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') associated with the specified ticket; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies a registered logging-client assembly. |

##### Remarks

If `ticket` is equal to [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), or no assembly is associated with it, then this method returns `null`.

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-GetTicket-System-Reflection-Assembly-'></a>
### GetTicket(assembly) `method`

##### Summary

Gets the logging-client ticket associated with the specified assembly.

##### Returns

A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies the specified assembly; otherwise, [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') whose ticket is to be obtained. |

##### Remarks

If `assembly` is `null`, or has not been registered, then this method returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

<a name='M-xyLOGIX-Core-Debug-LoggingClientAssemblyRegistry-Register-System-Reflection-Assembly-'></a>
### Register(assembly) `method`

##### Summary

Registers the specified logging-client assembly.

##### Returns

A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that uniquely identifies the registered assembly; otherwise, [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that is requesting logging services. |

##### Remarks

If `assembly` is `null`, then this method returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').



If the assembly has already been registered, then its existing ticket is returned.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLogProvider'></a>
## LoggingClientLogProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides log4net logger object(s) for the current logging-client session.

##### Remarks

This class dynamically selects the appropriate repository whenever a logger is requested.



Logger object(s) are not cached globally because the current logging-client session may vary between logical execution flow(s).

<a name='M-xyLOGIX-Core-Debug-LoggingClientLogProvider-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientLogProvider](#T-xyLOGIX-Core-Debug-LoggingClientLogProvider 'xyLOGIX.Core.Debug.LoggingClientLogProvider') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLogProvider-Instance 'xyLOGIX.Core.Debug.LoggingClientLogProvider.Instance') property.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLogProvider-ClientAssemblyContext'></a>
### ClientAssemblyContext `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLogProvider-ClientSessionRegistry'></a>
### ClientSessionRegistry `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry 'xyLOGIX.Core.Debug.ILoggingClientSessionRegistry') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLogProvider-CurrentClientAssemblyTicket'></a>
### CurrentClientAssemblyTicket `property`

##### Summary

Gets the ticket that identifies the logging-client assembly associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, the client-assembly context is unavailable, or the property cannot be evaluated, then this property returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

<a name='P-xyLOGIX-Core-Debug-LoggingClientLogProvider-CurrentClientSession'></a>
### CurrentClientSession `property`

##### Summary

Gets the logging-client session associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, or no session has been created for the selected ticket, this property returns `null`.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLogProvider-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLogProvider](#T-xyLOGIX-Core-Debug-ILoggingClientLogProvider 'xyLOGIX.Core.Debug.ILoggingClientLogProvider') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLogProvider-SessionLoggerFetchApproachValidator'></a>
### SessionLoggerFetchApproachValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ISessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLogProvider-_sourceTypeFQNToLogMap'></a>
### _sourceTypeFQNToLogMap `property`

##### Summary

Gets a reference to an instance of an object that implements the [IDictionary\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IDictionary`2 'System.Collections.Generic.IDictionary`2') that maps [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value(s), consisting of the fully-qualified name(s) of source type(s), to reference(s) to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that is a logger of that type.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLogProvider-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLogProvider](#T-xyLOGIX-Core-Debug-LoggingClientLogProvider 'xyLOGIX.Core.Debug.LoggingClientLogProvider') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLogProvider-GetLogForType-System-Type-'></a>
### GetLogForType(sourceType) `method`

##### Summary

Gets a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface for the specified source type.

##### Returns

Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that identifies the source of the logging record(s). |

##### Remarks

If `sourceType` is `null`, then this method returns `null`.



If no valid specialized logging-client session is active, then the ordinary log4net repository is utilized.



If a valid specialized session is active but a logger cannot be obtained from its repository, then this method returns `null`.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCache'></a>
## LoggingClientLoggerCache `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides a singleton cache for logger instances used by logging clients.

##### Remarks

Access is restricted to the Instance property to enforce the singleton pattern and prevent direct instantiation.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCache 'xyLOGIX.Core.Debug.LoggingClientLoggerCache') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.Instance') property.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCache-_loggerMap'></a>
### _loggerMap `constants`

##### Summary

Reference to an instance of an object that implements the [IDictionary\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IDictionary`2 'System.Collections.Generic.IDictionary`2') interface that maps logging-client logger-cache key(s) to their corresponding logger object(s).

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-CacheKeyValidator'></a>
### CacheKeyValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator') interface that validates logging-client logger-cache key object(s).

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-Count'></a>
### Count `property`

##### Summary

Gets an [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that indicates the number of logger object(s) currently stored in the cache.

##### Remarks

The value returned by this property is an atomic, point-in-time snapshot of the cache element count.



Callers must not assume that the count remains unchanged after the property getter returns.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCache 'xyLOGIX.Core.Debug.ILoggingClientLoggerCache') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-LoggingClientLoggerCacheAddActionValidator'></a>
### LoggingClientLoggerCacheAddActionValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-SyncRoot'></a>
### SyncRoot `property`

##### Summary

Reference to an instance of [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') that is utilized to synchronize access to the logging-client logger cache.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCache](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCache 'xyLOGIX.Core.Debug.LoggingClientLoggerCache') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-Clear'></a>
### Clear() `method`

##### Summary

Removes all logger object(s) from the cache.

##### Returns

`true` if the cache already contains zero element(s) or is cleared successfully; otherwise, `false`.

##### Parameters

This method has no parameters.

##### Remarks

If the cache already contains zero element(s), then this method returns `true` without modifying the cache.



If the cache cannot be cleared, then this method returns `false`.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-TryAdd-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog-'></a>
### TryAdd(cacheKey,logger) `method`

##### Summary

Attempts to add the specified `logger` to the cache by using the specified `cacheKey`.

##### Returns

`true` if a usable logger is already cached, the supplied logger is added successfully, or an existing `null` logger reference is replaced successfully; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cacheKey | [xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') | (Required.) Reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface that uniquely identifies the logger within a particular log4net repository. |
| logger | [log4net.ILog](#T-log4net-ILog 'log4net.ILog') | (Required.) Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that is to be stored in the cache. |

##### Remarks

If a `null` reference is passed for the `cacheKey` or `logger` parameter, then this method returns `false`.



If a non-`null` logger is already cached for the specified `cacheKey`, then this method leaves the existing logger unchanged and returns `true`.



If an existing cache entry contains a `null` logger reference, then this method attempts to replace it with the specified `logger`.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-TryApplyCacheAddAction-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction,xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog-'></a>
### TryApplyCacheAddAction(action,cacheKey,logger) `method`

##### Summary

Attempts to apply the specified logging-client logger-cache `Add``action`.

##### Returns

`true` if the specified action is applied successfully; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') | (Required.) One of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') value(s) that identifies the action to be applied. |
| cacheKey | [xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') | (Required.) Reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface that identifies the cache entry to be updated. |
| logger | [log4net.ILog](#T-log4net-ILog 'log4net.ILog') | (Required.) Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that is to be stored when the specified `action` requires a cache update. |

##### Remarks

The caller must own the synchronization lock represented by the [SyncRoot](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCache-SyncRoot 'xyLOGIX.Core.Debug.LoggingClientLoggerCache.SyncRoot') property before invoking this method.



The [PreserveExistingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-PreserveExistingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.PreserveExistingLogger') action performs no cache mutation and is treated as successful.



The [AddLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-AddLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.AddLogger') and [ReplaceNullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-ReplaceNullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.ReplaceNullLogger') action(s) update the cache and then verify that it contains the same logger object reference that was supplied.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCache-TryGet-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey,log4net-ILog@-'></a>
### TryGet(cacheKey,logger) `method`

##### Summary

Attempts to obtain the logger associated with the specified `cacheKey`.

##### Returns

`true` if a non-`null` logger is obtained from the cache; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cacheKey | [xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') | (Required.) Reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface that uniquely identifies the logger within a particular log4net repository. |
| logger | [log4net.ILog@](#T-log4net-ILog@ 'log4net.ILog@') | (Output.) If successful, receives a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that is associated with the specified `cacheKey`; otherwise, receives a `null` reference. |

##### Remarks

If a `null` reference is passed for the `cacheKey` parameter, no matching cache entry exists, or the matching cache entry contains a `null` reference, then this method assigns a `null` reference to the `logger` parameter and returns `false`.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction'></a>
## LoggingClientLoggerCacheAddAction `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Specifies the action(s) that may be performed while adding a logger to the logging-client logger cache.

##### Remarks

A logging-client logger-cache `Add` handler strategy returns one of these value(s) after being selected for the current cache-entry state.



The logging-client logger cache is responsible for applying the selected action, verifying its result, and constructing the corresponding [ILoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult') object.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-AddLogger'></a>
### AddLogger `constants`

##### Summary

Indicates that the supplied logger is to be added to a cache entry that does not currently exist.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-PreserveExistingLogger'></a>
### PreserveExistingLogger `constants`

##### Summary

Indicates that the usable logger already contained in the cache is to be preserved without modification.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-ReplaceNullLogger'></a>
### ReplaceNullLogger `constants`

##### Summary

Indicates that the supplied logger is to replace a `null` logger reference contained in an existing cache entry.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown'></a>
### Unknown `constants`

##### Summary

Indicates that the cache-add action is unknown or has not been determined.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator'></a>
## LoggingClientLoggerCacheAddActionValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator.Instance') property.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddActionValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddActionValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-'></a>
### IsValid(action) `method`

##### Summary

Determines whether the logging-client logger-cache `Add``action` value passed is within the value set defined by the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration.

##### Returns

`true` if the logging-client logger-cache `Add``action` falls within the defined value set and is not equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') | (Required.) One of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') value(s) that is to be examined. |

##### Remarks

If the value of the `action` parameter is outside the defined value set, or is equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown'), then this method returns `false`.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase'></a>
## LoggingClientLoggerCacheAddHandlerBase `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the events, methods, properties, and shared behavior of all logging-client logger-cache `Add` handler strategy object(s).

##### Remarks

This class validates the handler type and action supplied by each concrete strategy and ensures that they form a permitted combination.



Concrete child class(es) specify only the handler type and action that identify their strategy.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [LoggingClientLoggerCacheAddHandlerBase](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase') class and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This constructor is marked `protected` because this class is marked `abstract`.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-Action'></a>
### Action `property`

##### Summary

Gets a [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration value that identifies the action selected by this handler strategy.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-ActionValidator'></a>
### ActionValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddActionValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddActionValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddActionValidator') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-HandlerType'></a>
### HandlerType `property`

##### Summary

Gets a [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the cache-add handler strategy implemented by this object.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-HandlerTypeValidator'></a>
### HandlerTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheAddHandlerBase](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerBase') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerBase-Handle'></a>
### Handle() `method`

##### Summary

Selects the logging-client logger-cache `Add` action that corresponds to the scenario represented by this handler strategy.

##### Returns

One of the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration value(s) that identifies the action to perform; otherwise, [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown') is returned.

##### Parameters

This method has no parameters.

##### Remarks

This method validates the handler type and action supplied by the concrete strategy and verifies that they form a permitted combination.



This method does not access or mutate the logging-client logger cache.



If either value is invalid, the combination is not permitted, a required validator is unavailable, or an error occurs, then this method returns [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.Unknown').

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType'></a>
## LoggingClientLoggerCacheAddHandlerType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Specifies the handler type(s) that can determine how a logger is to be added to the logging-client logger cache.

##### Remarks

Each value identifies one mutually-exclusive state that may be encountered when attempting to add a logger to the cache.



The applicable handler terminates the Handler Chain after determining how the cache-add operation is to proceed.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-ExistingLogger'></a>
### ExistingLogger `constants`

##### Summary

Indicates that the cache already contains a usable logger corresponding to the specified cache key.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger'></a>
### MissingLogger `constants`

##### Summary

Indicates that the cache does not contain an entry corresponding to the specified cache key.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger'></a>
### NullLogger `constants`

##### Summary

Indicates that the cache contains an entry corresponding to the specified cache key, but its logger has a `null` reference for a value.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-Unknown'></a>
### Unknown `constants`

##### Summary

Indicates that the handler type is unknown or has not been determined.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator'></a>
## LoggingClientLoggerCacheAddHandlerTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator.Instance') property.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerTypeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the logging-client logger cache `Add` handler `type` value passed is within the value set that is defined by the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration.

##### Returns

`true` if the logging-client logger cache `Add` handler `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) One of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') values that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome'></a>
## LoggingClientLoggerCacheAddOutcome `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Specifies the outcome(s) that can result from an attempt to add a logger to the logging-client logger cache.

##### Remarks

This value describes the final result of the cache-add operation, rather than merely identifying the Handler Chain link that processed the request.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-ExistingLoggerPreserved'></a>
### ExistingLoggerPreserved `constants`

##### Summary

Indicates that the cache already contained a usable logger and that the existing logger was preserved.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-LoggerAdded'></a>
### LoggerAdded `constants`

##### Summary

Indicates that the supplied logger was added to a previously missing cache entry.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-LoggerUpdateFailed'></a>
### LoggerUpdateFailed `constants`

##### Summary

Indicates that the cache could not be updated or that the updated entry could not be verified.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-NullLoggerReplaced'></a>
### NullLoggerReplaced `constants`

##### Summary

Indicates that an existing cache entry contained a `null` logger reference and was replaced with the supplied logger.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown'></a>
### Unknown `constants`

##### Summary

Indicates that the outcome is unknown or has not been determined.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator'></a>
## LoggingClientLoggerCacheAddOutcomeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator.Instance') property.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcomeValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcomeValidator-IsValid-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-'></a>
### IsValid(outcome) `method`

##### Summary

Determines whether the logging-client logger-cache `Add``outcome` value passed is within the value set that is defined by the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration.

##### Returns

`true` if the logging-client logger-cache `Add``outcome` falls within the defined value set and is not equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown'); otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| outcome | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') | (Required.) One of the [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') values that is to be examined. |

##### Remarks

If the value of the `outcome` parameter is outside the defined value set, or is equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome.Unknown'), then this method returns `false`.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult'></a>
## LoggingClientLoggerCacheAddResult `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Describes the result of an attempt to add a logger to the logging-client logger cache.

##### Remarks

This object is immutable after construction and can therefore be safely shared among multiple thread(s).

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult-#ctor-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType,xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-'></a>
### #ctor(handlerType,outcome) `constructor`

##### Summary

Constructs a new instance of [LoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult') and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) A [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the Handler Chain link that accepted responsibility for the cache-add operation. |
| outcome | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') | (Required.) A [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration value that describes the final outcome of the cache-add operation. |

##### Remarks

The supplied value(s) are retained without modification.



Validation that the handler type and outcome form a permitted combination is the responsibility of the factory that constructs this object.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult-HandlerType'></a>
### HandlerType `property`

##### Summary

Gets a [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the Handler Chain link that accepted responsibility for the cache-add operation.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult-Outcome'></a>
### Outcome `property`

##### Summary

Gets a [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration value that describes the final outcome of the cache-add operation.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResult') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder'></a>
## LoggingClientLoggerCacheAddResultBuilder `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Completes the construction of a logging-client logger-cache `Add` result for a previously specified Handler Chain link type.

##### Remarks

This builder retains a previously validated [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') value and completes construction when supplied with a valid, compatible [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') value.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-#ctor-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-'></a>
### #ctor(handlerType) `constructor`

##### Summary

Initializes a new instance of the [LoggingClientLoggerCacheAddResultBuilder](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder') class and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) A [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the Handler Chain link that accepted responsibility for the cache-add operation. |

##### Remarks

The specified `handlerType` is retained without modification.



The caller is responsible for validating the value prior to constructing this builder.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-HandlerType'></a>
### HandlerType `property`

##### Summary

Gets the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the Handler Chain link for which the result is being constructed.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-OutcomeValidator'></a>
### OutcomeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddOutcomeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddOutcomeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddOutcomeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheAddResultBuilder](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddResultBuilder') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddResultBuilder-AndOutcome-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome-'></a>
### AndOutcome(outcome) `method`

##### Summary

Completes the construction of a logging-client logger-cache `Add` result having the specified `outcome`.

##### Returns

If successful, a reference to a new instance of an object that implements the [ILoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResult') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| outcome | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') | (Required.) A [LoggingClientLoggerCacheAddOutcome](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddOutcome 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddOutcome') enumeration value that describes the final outcome of the cache-add operation. |

##### Remarks

The specified `outcome` must be valid and compatible with the Handler Chain link type previously supplied to the builder.



If the specified value is invalid, is incompatible with the retained Handler Chain link type, or an error occurs, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey'></a>
## LoggingClientLoggerCacheKey `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents the identity of a logger that is stored in the logging-client logger cache.

##### Remarks

A logger is uniquely identified by the object identity of its log4net repository and its ordinal logger name.



Repository object identity is utilized instead of repository-name equality so that separate repository instance(s) having the same name remain distinct.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-#ctor-log4net-Repository-ILoggerRepository,System-String-'></a>
### #ctor(repository,loggerName) `constructor`

##### Summary

Initializes a new instance of the [LoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey') class and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that contains the logger. |
| loggerName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the name of the logger within the specified `repository`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if a `null` reference is passed for the `repository` parameter. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if a `null` reference, blank value, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') is passed for the `loggerName` parameter. |

##### Remarks

If a `null` reference is passed for the `repository` parameter, then an [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') is thrown.



If a `null` reference, blank value, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') is passed for the `loggerName` parameter, then an [ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') is thrown.

<a name='F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-HashCodeMultiplier'></a>
### HashCodeMultiplier `constants`

##### Summary

An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value by which the repository-identity hash code is multiplied when computing the combined hash code for this key.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-LoggerName'></a>
### LoggerName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the name of the logger within the repository identified by the [Repository](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-Repository 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.Repository') property.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-Repository'></a>
### Repository `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that contains the logger identified by the [LoggerName](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-LoggerName 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey.LoggerName') property.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKey') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-Equals-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-'></a>
### Equals(other) `method`

##### Summary

Determines whether this cache key and the specified `other` cache key identify the same logger.

##### Returns

`true` if both cache key(s) identify the same logger; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') | (Required.) Reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface to compare with this cache key. |

##### Remarks

If a `null` reference is passed for the `other` parameter, then this method returns `false`.



This method returns `false` if the repository properties do not refer to the same object instance or the logger name(s) are not ordinally equal.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Determines whether this cache key and the specified `obj` identify the same logger.

##### Returns

`true` if the supplied object identifies the same logger; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of [Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') to compare with this cache key. |

##### Remarks

If a `null` reference is passed for the `obj` parameter, or the supplied object does not implement the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface, then this method returns `false`.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKey-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Returns the hash code for this logger-cache key.

##### Returns

An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value containing the hash code for this logger-cache key.

##### Parameters

This method has no parameters.

##### Remarks

The repository portion of the hash code is based upon object identity rather than an overridden repository equality implementation.



The logger-name portion is computed by using ordinal string-comparison semantics.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder'></a>
## LoggingClientLoggerCacheKeyBuilder `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Completes the construction of a logging-client logger-cache key for a previously specified log4net repository.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder-#ctor-log4net-Repository-ILoggerRepository-'></a>
### #ctor(repository) `constructor`

##### Summary

Initializes a new instance of the [LoggingClientLoggerCacheKeyBuilder](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder') class and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that contains the logger to be represented by the completed cache key. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if a `null` reference is passed for the `repository` parameter. |

##### Remarks

If a `null` reference is passed for the `repository` parameter, then an [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') is thrown.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder-Repository'></a>
### Repository `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that contains the logger to be represented by the completed cache key.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheKeyBuilder](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyBuilder') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyBuilder-AndLoggerNamed-System-String-'></a>
### AndLoggerNamed(loggerName) `method`

##### Summary

Creates a new logging-client logger-cache key for the repository previously supplied to the builder and the specified `loggerName`.

##### Returns

If successful, a reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value containing the name of the logger within the repository previously supplied to the builder. |

##### Remarks

If a `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is passed for the `loggerName` parameter, then this method returns a `null` reference.



A `null` reference is also returned if the repository previously supplied to the builder is unavailable.

<a name='T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator'></a>
## LoggingClientLoggerCacheKeyValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates logging-client logger-cache key object(s).

##### Remarks

This component is stateless and can therefore be utilized concurrently by multiple thread(s).

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-Instance 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator.Instance') property.

<a name='P-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientLoggerCacheKeyValidator](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheKeyValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientLoggerCacheKeyValidator-IsValid-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-'></a>
### IsValid(cacheKey) `method`

##### Summary

Determines whether the specified `cacheKey` contains all the information required to identify a logger within a particular log4net repository.

##### Returns

`true` if the specified cache key is valid; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cacheKey | [xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') | (Required.) Reference to an instance of an object that implements the [ILoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey') interface that is to be validated. |

##### Remarks

If a `null` reference is passed for the `cacheKey` parameter, then this method returns `false`.



This method also returns `false` if the [Repository](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-Repository 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.Repository') property has a `null` reference for a value or the [LoggerName](#P-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKey-LoggerName 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKey.LoggerName') property is blank.

<a name='T-xyLOGIX-Core-Debug-LoggingClientRoutingAppender'></a>
## LoggingClientRoutingAppender `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Routes log4net logging event(s) to the repository assigned to the current specialized logging-client session.

##### Remarks

If no specialized logging-client session is active, logging event(s) are forwarded to the repository identified by the [FallbackRepository](#P-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-FallbackRepository 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender.FallbackRepository') property.



This appender is installed only in the dedicated PostSharp routing repository.

<a name='M-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-#ctor-log4net-Repository-ILoggerRepository,log4net-Repository-ILoggerRepository-'></a>
### #ctor(routingRepository,fallbackRepository) `constructor`

##### Summary

Initializes a new instance of the [LoggingClientRoutingAppender](#T-xyLOGIX-Core-Debug-LoggingClientRoutingAppender 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender') class and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| routingRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that contains this appender. |
| fallbackRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is to receive logging event(s) when no specialized logging-client session is active. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if any of the required parameters, `routingRepository` or `fallbackRepository`, are passed a `null` reference for a value. |

##### Remarks

If `routingRepository` is `null`, this appender cannot route logging event(s).



A `null` value for `fallbackRepository` is permitted.

<a name='F-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-_isRouting'></a>
### _isRouting `constants`

##### Summary

A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value indicating whether the current thread is already routing a logging event.

##### Remarks

This field prevents recursive routing if a target appender emits another logging event while processing the original event.

<a name='P-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-FallbackRepository'></a>
### FallbackRepository `property`

##### Summary

Gets or sets a reference to the log4net repository that receives logging event(s) when no specialized logging-client session is active.

<a name='P-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-RoutingRepository'></a>
### RoutingRepository `property`

##### Summary

Gets a reference to the log4net repository that contains this appender.

<a name='M-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientRoutingAppender](#T-xyLOGIX-Core-Debug-LoggingClientRoutingAppender 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically before the first instance is created or before any `static` member is referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-Append-log4net-Core-LoggingEvent-'></a>
### Append(loggingEvent) `method`

##### Summary

Appends the specified logging event to the repository assigned to the current specialized logging-client session.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggingEvent | [log4net.Core.LoggingEvent](#T-log4net-Core-LoggingEvent 'log4net.Core.LoggingEvent') | (Required.) Reference to an instance of [LoggingEvent](#T-log4net-Core-LoggingEvent 'log4net.Core.LoggingEvent') containing the logging event to route. |

##### Remarks

If `loggingEvent` is `null`, the current thread is already routing another event, or no suitable target repository can be resolved, this method returns without forwarding the event.



Exceptions are written directly to the Debug output to avoid recursively invoking the logging subsystem.

<a name='M-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-GetTargetRepository'></a>
### GetTargetRepository() `method`

##### Summary

Gets the log4net repository to which the current logging event should be forwarded.

##### Returns

Reference to the repository assigned to the current specialized logging-client session; otherwise, the fallback repository.

##### Parameters

This method has no parameters.

##### Remarks

If no valid specialized logging-client session is active, this method returns the value of the [FallbackRepository](#P-xyLOGIX-Core-Debug-LoggingClientRoutingAppender-FallbackRepository 'xyLOGIX.Core.Debug.LoggingClientRoutingAppender.FallbackRepository') property.



If no fallback repository is available, this method returns `null`.

<a name='T-xyLOGIX-Core-Debug-LoggingClientSession'></a>
## LoggingClientSession `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents the logging services assigned to a registered logging-client assembly.

##### Remarks

Each instance associates one registered assembly ticket with one dedicated log4net repository and one PostSharp logging backend.

<a name='M-xyLOGIX-Core-Debug-LoggingClientSession-#ctor-System-Guid,System-Reflection-Assembly,System-String,log4net-Repository-ILoggerRepository,PostSharp-Patterns-Diagnostics-LoggingBackend-'></a>
### #ctor(ticket,clientAssembly,repositoryName,repository,backend) `constructor`

##### Summary

Initializes a new instance of the [LoggingClientSession](#T-xyLOGIX-Core-Debug-LoggingClientSession 'xyLOGIX.Core.Debug.LoggingClientSession') class and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that uniquely identifies this logging-client session. |
| clientAssembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that requested this logging session. |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the unique name of the log4net repository assigned to this session. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') assigned to this session. |
| backend | [PostSharp.Patterns.Diagnostics.LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') | (Required.) Reference to an instance of [LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that writes PostSharp logging record(s) to the assigned repository. |

##### Remarks

Invalid argument value(s) leave the corresponding property initialized to its default value.



Call [IsValid](#M-xyLOGIX-Core-Debug-LoggingClientSession-IsValid 'xyLOGIX.Core.Debug.LoggingClientSession.IsValid') after construction to verify that initialization succeeded.

<a name='P-xyLOGIX-Core-Debug-LoggingClientSession-Backend'></a>
### Backend `property`

##### Summary

Gets a reference to an instance of [LoggingBackend](#T-PostSharp-Patterns-Diagnostics-LoggingBackend 'PostSharp.Patterns.Diagnostics.LoggingBackend') that writes PostSharp logging record(s) to the repository assigned to this session.

<a name='P-xyLOGIX-Core-Debug-LoggingClientSession-ClientAssembly'></a>
### ClientAssembly `property`

##### Summary

Gets a reference to the [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that requested this logging session.

<a name='P-xyLOGIX-Core-Debug-LoggingClientSession-Repository'></a>
### Repository `property`

##### Summary

Gets a reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is dedicated to this logging-client session.

<a name='P-xyLOGIX-Core-Debug-LoggingClientSession-RepositoryName'></a>
### RepositoryName `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the unique name assigned to the log4net repository for this logging-client session.

<a name='P-xyLOGIX-Core-Debug-LoggingClientSession-Ticket'></a>
### Ticket `property`

##### Summary

Gets a [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that uniquely identifies this logging-client session.

<a name='M-xyLOGIX-Core-Debug-LoggingClientSession-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientSession](#T-xyLOGIX-Core-Debug-LoggingClientSession 'xyLOGIX.Core.Debug.LoggingClientSession') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientSession-Clear'></a>
### Clear() `method`

##### Summary

Resets the property(ies) of this session to their default value(s).

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-LoggingClientSession-IsValid'></a>
### IsValid() `method`

##### Summary

Determines whether this logging-client session contains all required information and service reference(s).

##### Returns

`true` if this logging-client session is valid; otherwise, `false`.

##### Parameters

This method has no parameters.

##### Remarks

This method returns `false` if the [Ticket](#P-xyLOGIX-Core-Debug-LoggingClientSession-Ticket 'xyLOGIX.Core.Debug.LoggingClientSession.Ticket') property is equal to [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), any required reference is `null`, or the repository name is blank.

<a name='T-xyLOGIX-Core-Debug-LoggingClientSessionRegistry'></a>
## LoggingClientSessionRegistry `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Manages registered logging-client session object(s).

<a name='M-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [LoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-LoggingClientSessionRegistry 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-Instance 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry.Instance') property.

<a name='F-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-_sessions'></a>
### _sessions `constants`

##### Summary

Reference to a collection that associates each logging-client ticket with its corresponding logging-client session.

<a name='P-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry 'xyLOGIX.Core.Debug.ILoggingClientSessionRegistry') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-SyncRoot'></a>
### SyncRoot `property`

##### Summary

Gets a reference to an instance of an object that is to be used for thread synchronization purposes.

<a name='M-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-LoggingClientSessionRegistry 'xyLOGIX.Core.Debug.LoggingClientSessionRegistry') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-Get-System-Guid-'></a>
### Get(ticket) `method`

##### Summary

Gets the logging-client session associated with the specified ticket.

##### Returns

Reference to an instance of an object that implements the [ILoggingClientSession](#T-xyLOGIX-Core-Debug-ILoggingClientSession 'xyLOGIX.Core.Debug.ILoggingClientSession') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies a registered logging-client session. |

##### Remarks

If `ticket` equals [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), or no corresponding session exists, this method returns `null`.

<a name='M-xyLOGIX-Core-Debug-LoggingClientSessionRegistry-GetOrCreate-System-Guid,System-Reflection-Assembly-'></a>
### GetOrCreate(ticket,clientAssembly) `method`

##### Summary

Gets or creates the logging-client session associated with the specified ticket and assembly.

##### Returns

Reference to the existing or newly created instance of an object that implements the [ILoggingClientSession](#T-xyLOGIX-Core-Debug-ILoggingClientSession 'xyLOGIX.Core.Debug.ILoggingClientSession') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies the registered logging-client assembly. |
| clientAssembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that requested logging services. |

##### Remarks

If either argument is invalid, or session creation fails, this method returns `null`.



If a session already exists for the ticket but belongs to a different assembly reference, this method returns `null`.

<a name='T-xyLOGIX-Core-Debug-LoggingConfiguratorBase'></a>
## LoggingConfiguratorBase `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the events, methods, properties, and behaviors for all `Logging Configurator` object(s).

<a name='P-xyLOGIX-Core-Debug-LoggingConfiguratorBase-Type'></a>
### Type `property`

##### Summary

Gets or sets one of the [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') enumeration value(s) that indicates which type of configuration this `Logging Configurator` does.

<a name='M-xyLOGIX-Core-Debug-LoggingConfiguratorBase-Configure-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### Configure(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Returns

`true` if the configuration operation(s) succeeded; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` if we should not write out `DEBUG` messages to the `Debug` output when in the `Release` mode. Set to `false` if all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for initializing log4net. If blank, the system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the console if a log file is being used. If a log file is not used, then no logging at all will occur if this parameter is set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the `XMLConfigurator` object is used to configure logging.    Else, specify here the path to the `Debug` output to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a user-friendly display name of the application that is using this logging library.    Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. Supply a value for this parameter if your infrastructure is not utilizing the default HierarchicalRepository. |

<a name='T-xyLOGIX-Core-Debug-LoggingConfiguratorType'></a>
## LoggingConfiguratorType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Value(s) that indicate which type of `Logging Configurator` is being used to configure the logging of the application.

<a name='F-xyLOGIX-Core-Debug-LoggingConfiguratorType-FromConfigFile'></a>
### FromConfigFile `constants`

##### Summary

A `Logging Configurator` that configures logging using the `app.config` or `web.config` file settings.

<a name='F-xyLOGIX-Core-Debug-LoggingConfiguratorType-Programmatic'></a>
### Programmatic `constants`

##### Summary

A `Logging Configurator` that programmatically configures logging.

<a name='F-xyLOGIX-Core-Debug-LoggingConfiguratorType-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown type of `Logging Configurator`.

<a name='T-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator'></a>
## LoggingConfiguratorTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [LoggingConfiguratorTypeToUse](#T-xyLOGIX-Core-Debug-LoggingConfiguratorTypeToUse 'xyLOGIX.Core.Debug.LoggingConfiguratorTypeToUse') enumeration.

<a name='M-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-Interfaces-ILoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.Interfaces.ILoggingConfiguratorTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-LoggingConfiguratorTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingConfiguratorType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the logging configurator `type` value passed is within the value set that is defined by the [LoggingConfiguratorTypeToUse](#T-xyLOGIX-Core-Debug-LoggingConfiguratorTypeToUse 'xyLOGIX.Core.Debug.LoggingConfiguratorTypeToUse') enumeration.

##### Returns

`true` if the logging configurator `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') | (Required.) One of the [LoggingConfiguratorTypeToUse](#T-xyLOGIX-Core-Debug-LoggingConfiguratorTypeToUse 'xyLOGIX.Core.Debug.LoggingConfiguratorTypeToUse') value(s) that is to be examined. |

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

<a name='T-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator'></a>
## LoggingInfrastructureTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') enumeration.

<a name='M-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-Interfaces-ILoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.Interfaces.ILoggingInfrastructureTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-LoggingInfrastructureTypeValidator-IsValid-xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the logging infrastructure `type` value passed is within the value set that is defined by the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') enumeration.

##### Returns

`true` if the logging infrastructure `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Required.) One of the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-LoggingSubsystemManager'></a>
## LoggingSubsystemManager `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Methods to be used to manage the application log.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-AppenderManager'></a>
### AppenderManager `property`

##### Summary

Gets a reference to an instance of an object that implements the [IAppenderManager](#T-xyLOGIX-Core-Debug-IAppenderManager 'xyLOGIX.Core.Debug.IAppenderManager') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-ClientAssemblyContext'></a>
### ClientAssemblyContext `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientAssemblyContext](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyContext 'xyLOGIX.Core.Debug.ILoggingClientAssemblyContext') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-ClientAssemblyRegistry'></a>
### ClientAssemblyRegistry `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientAssemblyRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientAssemblyRegistry 'xyLOGIX.Core.Debug.ILoggingClientAssemblyRegistry') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-ClientSessionRegistry'></a>
### ClientSessionRegistry `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientSessionRegistry](#T-xyLOGIX-Core-Debug-ILoggingClientSessionRegistry 'xyLOGIX.Core.Debug.ILoggingClientSessionRegistry') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientAssembly'></a>
### CurrentClientAssembly `property`

##### Summary

Gets the logging-client assembly associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, the corresponding registration cannot be found, or the operation fails, then this property returns `null`.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientAssemblyTicket'></a>
### CurrentClientAssemblyTicket `property`

##### Summary

Gets the ticket that identifies the logging-client assembly associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, the client-assembly context is unavailable, or the property cannot be evaluated, then this property returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientBackend'></a>
### CurrentClientBackend `property`

##### Summary

Gets a reference to the PostSharp logging backend assigned to the current logging-client session.

##### Remarks

If no current logging-client session exists, this property returns `null`.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientRepository'></a>
### CurrentClientRepository `property`

##### Summary

Gets a reference to the log4net repository assigned to the current logging-client session.

##### Remarks

If no current logging-client session exists, this property returns `null`.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-CurrentClientSession'></a>
### CurrentClientSession `property`

##### Summary

Gets the logging-client session associated with the current logical execution flow.

##### Remarks

If no logging-client assembly is currently selected, or no session has been created for the selected ticket, this property returns `null`.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-InfrastructureType'></a>
### InfrastructureType `property`

##### Summary

Gets or sets the [LoggingInfrastructureType](#T-LoggingInfrastructureType 'LoggingInfrastructureType') value that represents the type of infrastructure currently in use by this [LoggingSubsystemManager](#T-xyLOGIX-Core-Debug-LoggingSubsystemManager 'xyLOGIX.Core.Debug.LoggingSubsystemManager').

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-LogFileName'></a>
### LogFileName `property`

##### Summary

Gets the full path and filename to the log file for this application.

##### Remarks

This property should only be called after the [InitializeLogging](#M-xyLOGIX-Core-Debug-LoggingSubsystemManager-InitializeLogging 'xyLOGIX.Core.Debug.LoggingSubsystemManager.InitializeLogging') method has been called.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-LoggingInfrastructure'></a>
### LoggingInfrastructure `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface that corresponds to the value of the [Type](#P-Type 'Type') property.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-LoggingInfrastructureTypeValidator'></a>
### LoggingInfrastructureTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator') interface.

<a name='P-xyLOGIX-Core-Debug-LoggingSubsystemManager-PostSharpBackendRouter'></a>
### PostSharpBackendRouter `property`

##### Summary

Gets a reference to an instance of an object that implements the [IPostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter') interface.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [LoggingSubsystemManager](#T-xyLOGIX-Core-Debug-LoggingSubsystemManager 'xyLOGIX.Core.Debug.LoggingSubsystemManager') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-EnsureCurrentClientSession'></a>
### EnsureCurrentClientSession() `method`

##### Summary

Ensures that a logging-client session exists when a logging-client assembly has been selected.

##### Returns

`true` if no specialized logging client is selected, or a valid logging-client session exists; otherwise, `false`.

##### Parameters

This method has no parameters.

##### Remarks

Applications that do not register a specialized in-process logging client continue through the legacy initialization path.



If a specialized logging client has been selected but its session cannot be created, this method returns `false` so initialization does not silently fall back to another component's repository.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-GetDefaultBackendRepository'></a>
### GetDefaultBackendRepository() `method`

##### Summary

Gets the log4net repository associated with the current process-wide PostSharp default backend.

##### Returns

Reference to the repository associated with the current [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') ; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If the current PostSharp default backend is not a [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') , this method returns `null`.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-GetLegacyRepositoryBeforeInitialization'></a>
### GetLegacyRepositoryBeforeInitialization() `method`

##### Summary

Gets the ordinary log4net repository that should be retained while a specialized logging-client session is initialized.

##### Returns

Reference to the ordinary fallback repository; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If the PostSharp routing backend is already installed, its existing fallback repository is returned.



Otherwise, the repository associated with the current PostSharp default backend is returned.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-GetOrCreateCurrentClientSession'></a>
### GetOrCreateCurrentClientSession() `method`

##### Summary

Gets or creates the logging-client session associated with the currently selected logging-client assembly.

##### Returns

Reference to an instance of an object that implements the [ILoggingClientSession](#T-xyLOGIX-Core-Debug-ILoggingClientSession 'xyLOGIX.Core.Debug.ILoggingClientSession') interface; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If no logging-client assembly is currently selected, its registration cannot be resolved, or session creation fails, this method returns `null`.



This method does not assign the session backend to [DefaultBackend](#P-PostSharp-Patterns-Diagnostics-LoggingServices-DefaultBackend 'PostSharp.Patterns.Diagnostics.LoggingServices.DefaultBackend').

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-GetRepositoryToConfigure'></a>
### GetRepositoryToConfigure() `method`

##### Summary

Gets a reference to the log4net repository that should be configured for the current logging operation.

##### Returns

Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') associated with the current specialized logging-client session; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If no specialized logging-client session is active, this method returns `null`.



A `null` return value instructs the existing logging infrastructure to utilize its legacy repository-selection behavior.



If the current session is invalid or the operation fails, this method returns `null`.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,infrastructureType) `method`

##### Summary

Initializes the application's logging subsystem.

##### Returns

`true` if the logging subsystem has been initialized successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write out "DEBUG" messages to the log file when in the Release mode. Set to false if all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| configurationFileNamename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for initializing log4net. If blank, the system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the console if a log file is being used. If a log file is not used, then no logging at all will occur if this parameter is set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the `XMLConfigurator` object is used to configure logging.    Else, specify here the path to the log file to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a user-friendly display name of the application that is using this logging library.    Leave blank to use the default value. |
| infrastructureType | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Optional.) One of the [LoggingInfrastructureType](#T-LoggingInfrastructureType 'LoggingInfrastructureType') value(s) that indicates what type of logging infrastructure is to be utilized (default or PostSharp, for example). |

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-ReconcilePostSharpBackendRouting-System-Boolean,log4net-Repository-ILoggerRepository-'></a>
### ReconcilePostSharpBackendRouting(specializedSessionWasActive,legacyRepositoryBeforeInitialization) `method`

##### Summary

Reconciles the process-wide PostSharp backend after logging initialization completes.

##### Returns

`true` if no routing work was required, or the PostSharp routing backend was successfully installed or updated; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| specializedSessionWasActive | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value indicating whether a valid specialized logging-client session was active when initialization began. |
| legacyRepositoryBeforeInitialization | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to the ordinary log4net repository that was active before initialization began. |

##### Remarks

If no specialized session has ever been selected and the router has not been installed, this method returns `true` without changing [DefaultBackend](#P-PostSharp-Patterns-Diagnostics-LoggingServices-DefaultBackend 'PostSharp.Patterns.Diagnostics.LoggingServices.DefaultBackend').



Once the router has been installed, ordinary initialization updates its fallback repository and restores the routing backend if another initializer replaced it.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-RegisterAndSelectClientAssembly-System-Reflection-Assembly-'></a>
### RegisterAndSelectClientAssembly(assembly) `method`

##### Summary

Registers the specified assembly as a logging client and selects it for the current logical execution flow.

##### Returns

A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies the registered and selected logging-client assembly; otherwise, [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that is requesting logging services. |

##### Remarks

If `assembly` is `null`, the assembly cannot be registered, or its ticket cannot be selected for the current logical execution flow, then this method returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').



Registering an assembly that has already been registered reuses its existing ticket.



Because this method may execute before the logging subsystem has been initialized, exception information is written directly to the Debug output.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-RegisterClientAssembly-System-Reflection-Assembly-'></a>
### RegisterClientAssembly(assembly) `method`

##### Summary

Registers an assembly that is requesting logging services.

##### Returns

A [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that uniquely identifies the registered assembly; otherwise, [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that is requesting logging services. |

##### Remarks

This method is primarily intended for logging-subsystem adapter(s), such as `WizardLoggingSubsystemManager`.



If `assembly` is `null`, the registry is unavailable, or registration fails, then this method returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty').



Because this method may execute before the logging subsystem has been initialized, exception information is written directly to the Debug output.

<a name='M-xyLOGIX-Core-Debug-LoggingSubsystemManager-SetUpDebugUtils-System-Boolean,System-Boolean,System-Boolean,System-Int32,System-Boolean,xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### SetUpDebugUtils(muteDebugLevelIfReleaseMode,isLogging,consoleOnly,verbosity,muteConsole,infrastructureType) `method`

##### Summary

Sets up the [DebugUtils](#T-xyLOGIX-Core-Debug-DebugUtils 'xyLOGIX.Core.Debug.DebugUtils') to initialize its functionality.

##### Returns

`true` if the operation(s) completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to true, does not echo any logging statements that are set to [Debug](#F-DebugLevel-Debug 'DebugLevel.Debug'). |
| isLogging | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to activate the functionality of writing to a log file; false to suppress. Usually used with the `consoleOnly` parameter set to `true`. |
| consoleOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True to only write messages to the console; false to write them both to the console and to the log. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If set to `true`, suppresses all console output. |
| infrastructureType | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Optional.) One of the [LoggingInfrastructureType](#T-LoggingInfrastructureType 'LoggingInfrastructureType') value(s) that indicates what type of logging infrastructure is to be utilized (default or PostSharp). |

<a name='T-xyLOGIX-Core-Debug-MakeNewConsoleLoggingBackend'></a>
## MakeNewConsoleLoggingBackend `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static method(s) that create and initialize new instances of the [ConsoleLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Console-ConsoleLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Console.ConsoleLoggingBackend') class, and return references to them.

<a name='M-xyLOGIX-Core-Debug-MakeNewConsoleLoggingBackend-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [MakeNewConsoleLoggingBackend](#T-xyLOGIX-Core-Debug-MakeNewConsoleLoggingBackend 'xyLOGIX.Core.Debug.MakeNewConsoleLoggingBackend') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-MakeNewConsoleLoggingBackend-FromScratch'></a>
### FromScratch() `method`

##### Summary

Creates a new instance of [ConsoleLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Console-ConsoleLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Console.ConsoleLoggingBackend') and returns a reference to it.

##### Returns

Reference to a newly-created instance of [ConsoleLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Console-ConsoleLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Console.ConsoleLoggingBackend') .

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend'></a>
## MakeNewLog4NetLoggingBackend `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static method(s) that create and initialize new instances of the [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') class, and return references to them.

<a name='M-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [MakeNewLog4NetLoggingBackend](#T-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend 'xyLOGIX.Core.Debug.MakeNewLog4NetLoggingBackend') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend-ForRelay-log4net-Repository-ILoggerRepository-'></a>
### ForRelay(relay) `method`

##### Summary

Creates a new instance of [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') , initialized for the specified `relay`, and returns a reference to it.

##### Returns

If successful, a reference to a newly-created instance of [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') initialized with the specified `relay`; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| relay | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that specifies the relay to be used for sending logging to another destination, or in which loggers are to be stored. |

##### Remarks

If a `null` reference is passed as the argument of the `relay` parameter, then this method returns a `null` reference. i

<a name='M-xyLOGIX-Core-Debug-MakeNewLog4NetLoggingBackend-FromScratch'></a>
### FromScratch() `method`

##### Summary

Creates a new instance of [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') and returns a reference to it.

##### Returns

Reference to a newly-created instance of [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') .

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult'></a>
## MakeNewLoggingClientLoggerCacheAddResult `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Creates new logging-client logger-cache `Add` result object(s) by using a fluent builder.

<a name='P-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult-HandlerTypeValidator'></a>
### HandlerTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddHandlerTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandlerTypeValidator 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandlerTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [MakeNewLoggingClientLoggerCacheAddResult](#T-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheAddResult') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically before any `static` member is referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheAddResult-ForHandlerType-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-'></a>
### ForHandlerType(handlerType) `method`

##### Summary

Begins creating a new logging-client logger-cache `Add` result for the specified handler strategy type.

##### Returns

If successful, a reference to an instance of an object that implements the [ILoggingClientLoggerCacheAddResultBuilder](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddResultBuilder 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddResultBuilder') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| handlerType | [xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') | (Required.) A [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration value that identifies the handler strategy responsible for the cache-add operation. |

##### Remarks

The specified `handlerType` must be within the defined value set of the [LoggingClientLoggerCacheAddHandlerType](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType') enumeration and must not be equal to [Unknown](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-Unknown 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.Unknown') .



If the handler-type validator is unavailable, the specified value is invalid, or an error occurs, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheKey'></a>
## MakeNewLoggingClientLoggerCacheKey `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Creates new logging-client logger-cache key object(s) by using a fluent builder.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheKey-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [MakeNewLoggingClientLoggerCacheKey](#T-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheKey 'xyLOGIX.Core.Debug.MakeNewLoggingClientLoggerCacheKey') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically before any `static` member is referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientLoggerCacheKey-ForRepository-log4net-Repository-ILoggerRepository-'></a>
### ForRepository(repository) `method`

##### Summary

Begins creating a new logging-client logger-cache key for the specified `repository`.

##### Returns

If successful, a reference to an instance of an object that implements the [ILoggingClientLoggerCacheKeyBuilder](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheKeyBuilder 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheKeyBuilder') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface that contains the logger to be represented by the completed cache key. |

##### Remarks

If a `null` reference is passed for the `repository` parameter, then this method returns a `null` reference.

<a name='T-xyLOGIX-Core-Debug-MakeNewLoggingClientSession'></a>
## MakeNewLoggingClientSession `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Creates logging-client session object(s).

##### Remarks

Logging-client object(s) are created for a specific assembly and ticket.



A named log4net repository and a corresponding [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') are created for the session.

<a name='F-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-RepositoryNamePrefix'></a>
### RepositoryNamePrefix `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the prefix assigned to every logging-client repository name.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [MakeNewLoggingClientSession](#T-xyLOGIX-Core-Debug-MakeNewLoggingClientSession 'xyLOGIX.Core.Debug.MakeNewLoggingClientSession') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically before any `static` member is referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-FindRepository-System-String-'></a>
### FindRepository(repositoryName) `method`

##### Summary

Finds the log4net repository having the specified name.

##### Returns

Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') having the specified name; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the name of the repository to find. |

##### Remarks

If `repositoryName` is blank, no repository(ies) are available, or no matching repository exists, this method returns `null`.



Repository-name comparison is performed without regard to character casing.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-FormulateRepositoryName-System-Guid,System-Reflection-Assembly-'></a>
### FormulateRepositoryName(ticket,clientAssembly) `method`

##### Summary

Gets the unique log4net repository name for the specified logging-client assembly and ticket.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the unique repository name; otherwise, [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A nonempty [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies the registered logging-client assembly. |
| clientAssembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') for which a repository name is being generated. |

##### Remarks

If `ticket` equals [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), or `clientAssembly` is `null`, this method returns [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty').

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-From-System-Guid,System-Reflection-Assembly-'></a>
### From(ticket,clientAssembly) `method`

##### Summary

Creates a new logging-client session for the specified assembly and ticket.

##### Returns

Reference to a new instance of an object that implements the [ILoggingClientSession](#T-xyLOGIX-Core-Debug-ILoggingClientSession 'xyLOGIX.Core.Debug.ILoggingClientSession') interface; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ticket | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | (Required.) A nonempty [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') value that identifies the registered logging-client assembly. |
| clientAssembly | [System.Reflection.Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') | (Required.) Reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that requested logging services. |

##### Remarks

If `ticket` equals [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid.Empty 'System.Guid.Empty'), or `clientAssembly` is `null`, this method returns `null`.



A named log4net repository and a corresponding [Log4NetLoggingBackend](#T-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetLoggingBackend 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend') are created for the session.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-GetOrCreateRepository-System-String-'></a>
### GetOrCreateRepository(repositoryName) `method`

##### Summary

Gets or creates the log4net repository having the specified name.

##### Returns

Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') having the specified name; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the unique repository name. |

##### Remarks

If `repositoryName` is blank, this method returns `null`.



Existing repository(ies) are examined before a new repository is created.



If another caller creates the repository after the initial examination but before this method attempts to create it, the repository collection is examined again after the exception is caught.

<a name='M-xyLOGIX-Core-Debug-MakeNewLoggingClientSession-TryCreateLoggerRepositoryNamed-System-String,log4net-Repository-ILoggerRepository@-'></a>
### TryCreateLoggerRepositoryNamed(repositoryName,repository) `method`

##### Summary

Attempts to create a new instance of a log4net repository that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface, that has the name, `repositoryName`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that is set to the name to use for the new log4net repository.    The value of this parameter may not be `null`, blank, nor the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.    If it is, then this method will not attempt to create a new log4net repository. |
| repository | [log4net.Repository.ILoggerRepository@](#T-log4net-Repository-ILoggerRepository@ 'log4net.Repository.ILoggerRepository@') | (Output.) If successful, receives a reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface; otherwise, a `null` reference is placed in the argument of this parameter. |

##### Remarks

This method attempts to create a new log4net repository having the name specified in the `repositoryName` parameter.



If the repository is successfully created, then a reference to it is placed in the argument of the `repository` parameter.



If a `null`, blank [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String'), or the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is passed for the argument of the `repositoryName` parameter, then this method does nothing.



The `repository` parameter receives a `null` reference if an error was encountered during the process of attempting to create the new repository.

<a name='T-xyLOGIX-Core-Debug-MakeNewPatternLayout'></a>
## MakeNewPatternLayout `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static method(s) to create instances of [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') that are initialized properly, and return a reference to them.

<a name='M-xyLOGIX-Core-Debug-MakeNewPatternLayout-HavingConversionPattern-System-String-'></a>
### HavingConversionPattern(conversionPattern) `method`

##### Summary

Creates a new instance of [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') that is initialized with the specified `conversionPattern`, and returns a reference to it.

##### Returns

If successful, a reference to an instance of [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') that has been initialized with the specified `conversionPattern`; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| conversionPattern | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the conversion pattern that is to be assigned. |

##### Remarks

If the value of the `conversionPattern` parameter is a `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, then this method returns a `null` reference.



A `null` reference is also returned if an [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') is caught during the execution of this method.

<a name='T-xyLOGIX-Core-Debug-MakeNewRollingFileAppender'></a>
## MakeNewRollingFileAppender `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to create new instances of [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') and initialize them.

<a name='P-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-RollingModeValidator'></a>
### RollingModeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [IRollingModeValidator](#T-xyLOGIX-Core-Debug-IRollingModeValidator 'xyLOGIX.Core.Debug.IRollingModeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [MakeNewRollingFileAppender](#T-xyLOGIX-Core-Debug-MakeNewRollingFileAppender 'xyLOGIX.Core.Debug.MakeNewRollingFileAppender') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndMaximumNumberOfRollingBackups-log4net-Appender-RollingFileAppender,System-Int32-'></a>
### AndMaximumNumberOfRollingBackups(self,maxSizeRollingBackups) `method`

##### Summary

Builder extension method that initializes the [MaxSizeRollBackups](#P-log4net-Appender-RollingFileAppender-MaxSizeRollBackups 'log4net.Appender.RollingFileAppender.MaxSizeRollBackups') property.

##### Returns

Reference to the same instance of the object that called this method, for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| maxSizeRollingBackups | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') that specifies the maximum number of backup files that are kept before the oldest backup file is erased. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required parameter, `self`, is passed a `null` value. |

##### Remarks

If set to zero, then there will be no backup files and the log file     will be truncated when it reaches     [MaxFileSize](#P-log4net-Appender-RollingFileAppender-MaxFileSize 'log4net.Appender.RollingFileAppender.MaxFileSize').

If a negative number is supplied then no deletions will be made. Note     that this could result in very slow performance as a large number of files     are rolled over unless     [CountDirection](#P-log4net-Appender-RollingFileAppender-CountDirection 'log4net.Appender.RollingFileAppender.CountDirection') is     used.

The maximum applies to time based group of files and     the total.

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-AndThatHasAStaticLogFileName-log4net-Appender-RollingFileAppender,System-Boolean-'></a>
### AndThatHasAStaticLogFileName(self,staticLogFileName) `method`

##### Summary

Builder extension method that initializes the [StaticLogFileName](#P-log4net-Appender-RollingFileAppender-StaticLogFileName 'log4net.Appender.RollingFileAppender.StaticLogFileName') property.

##### Returns

Reference to the same instance of the object that called this method, for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| staticLogFileName | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value indicating whether to always log to the same file.    Set to `true` if always should be logged to the same file, otherwise `false`. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required parameter, `self`, is passed a `null` value. |

##### Remarks

By default, file.log is always the current file. Optionally     file.log.yyyy-mm-dd for current formatted datePattern can by the currently     logging file (or file.log.curSizeRollBackup or even     file.log.yyyy-mm-dd.curSizeRollBackup).

This will make time based rollovers with a large number of backups     much faster as the appender it won't have to rename all the backups!

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-ForRollingStyle-log4net-Appender-RollingFileAppender-RollingMode-'></a>
### ForRollingStyle(rollingStyle) `method`

##### Summary

Creates a new instance of [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') and initializes it with the specified rolling `rollingStyle`.

##### Returns

If successful, a new instance of [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') and initializes it with the specified rolling `rollingStyle`. Otherwise, `null` is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rollingStyle | [log4net.Appender.RollingFileAppender.RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') | (Required.) One or a combination of the [RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') enumeration values that specifies how the log file should be rolled when it gets too big for size limits. |

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-SetLogFileNameTo-log4net-Appender-RollingFileAppender,System-String-'></a>
### SetLogFileNameTo(self,file) `method`

##### Summary

Builder extension method that initializes the [File](#P-log4net-Appender-RollingFileAppender-File 'log4net.Appender.RollingFileAppender.File') property.

##### Returns

Reference to the same instance of the object that called this method, for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| file | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of where logging entries will be written. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required parameter, `self`, is passed a `null` value. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the required parameter, `file`, is passed a blank or `null` string for a value. |

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-ThatShouldAppendToFile-log4net-Appender-RollingFileAppender,System-Boolean-'></a>
### ThatShouldAppendToFile(self,appendToFile) `method`

##### Summary

Builder extension method that initializes the [AppendToFile](#P-log4net-Appender-RollingFileAppender-AppendToFile 'log4net.Appender.RollingFileAppender.AppendToFile') property.

##### Returns

Reference to the same instance of the object that called this method, for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| appendToFile | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value that is set to `true` if the logger should append to the log file, `false` if the file should be overwritten. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required parameter, `self`, is passed a `null` value. |

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-WithMaximumFileSizeOf-log4net-Appender-RollingFileAppender,System-String-'></a>
### WithMaximumFileSizeOf(self,maximumFileSize) `method`

##### Summary

Builder extension method that initializes the [MaximumFileSize](#P-log4net-Appender-RollingFileAppender-MaximumFileSize 'log4net.Appender.RollingFileAppender.MaximumFileSize') property.

##### Returns

Reference to the same instance of the object that called this method, for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| maximumFileSize | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that describes the maximum size that the output file is allowed to reach before being rolled over to back up files. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required parameter, `self`, is passed a `null` value. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown if the required parameter, `maximumFileSize`, is passed a blank or `null` string for a value. |

##### Remarks

This property allows you to specify the maximum size with the     suffixes "KB", "MB" or "GB" so that the size is interpreted being expressed     respectively in kilobytes, megabytes or gigabytes.

OfType example, the value "10KB" will be interpreted as 10240 bytes.

The default maximum file size is 10MB.

If you have the option to set the maximum file size programmatically     consider using the     [MaxFileSize](#P-log4net-Appender-RollingFileAppender-MaxFileSize 'log4net.Appender.RollingFileAppender.MaxFileSize') property     instead as this allows you to set the size in bytes as a     [Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64').

<a name='M-xyLOGIX-Core-Debug-MakeNewRollingFileAppender-WithPatternLayout-log4net-Appender-RollingFileAppender,log4net-Layout-PatternLayout-'></a>
### WithPatternLayout(self,layout) `method`

##### Summary

Builder extension method that initializes the [Layout](#P-log4net-Appender-RollingFileAppender-Layout 'log4net.Appender.RollingFileAppender.Layout') property.

##### Returns

Reference to the same instance of the object that called this method, for fluent use.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| self | [log4net.Appender.RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') | (Required.) Reference to an instance of an object that implements the [RollingFileAppender](#T-log4net-Appender-RollingFileAppender 'log4net.Appender.RollingFileAppender') interface. |
| layout | [log4net.Layout.PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') | (Required.) Reference to an instance of [PatternLayout](#T-log4net-Layout-PatternLayout 'log4net.Layout.PatternLayout') that specifies the pattern to utilize for each line of the log file. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if either of the required parameters, `self` or `layout`, are passed a `null` value. |

<a name='T-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler'></a>
## MissingLoggerLoggingClientLoggerCacheAddHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Selects the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration value that adds a logger to a cache entry that does not currently exist.

<a name='M-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of the [MissingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler') class and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-Instance 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler.Instance') property.

<a name='P-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-Action'></a>
### Action `property`

##### Summary

Gets the [AddLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-AddLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.AddLogger') value that identifies the action selected by this handler strategy.

<a name='P-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-HandlerType'></a>
### HandlerType `property`

##### Summary

Gets the [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger') value that identifies the cache-add handler strategy implemented by this object.

<a name='P-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [MissingLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-MissingLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.MissingLogger') logging-client logger-cache `Add` handler strategy.

<a name='M-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [MissingLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-MissingLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.MissingLoggerLoggingClientLoggerCacheAddHandler') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs'></a>
## MuteConsoleChangedEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `MuteConsoleChanged` event handlers.

<a name='M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#ctor-System-Boolean-'></a>
### #ctor(newValue) `constructor`

##### Summary

Constructs a new instance of [MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs') and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| newValue | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | (Required.) A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value that matches the current value of the [MuteConsole](#P-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsole 'xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole') property. |

<a name='M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of [MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs') and returns a reference to it.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-NewValue'></a>
### NewValue `property`

##### Summary

Gets a [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value that matches the current value of the [MuteConsole](#P-xyLOGIX-Core-Debug-IOutputLocationProvider-MuteConsole 'xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole') property.

<a name='M-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='T-xyLOGIX-Core-Debug-MuteConsoleChangedEventHandler'></a>
## MuteConsoleChangedEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `MuteConsoleChanged` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [T:xyLOGIX.Core.Debug.MuteConsoleChangedEventHandler](#T-T-xyLOGIX-Core-Debug-MuteConsoleChangedEventHandler 'T:xyLOGIX.Core.Debug.MuteConsoleChangedEventHandler') | Reference to the instance of the object that raised the event. |

##### Remarks

This delegate merely specifies the signature of all methods that handle the `MuteConsoleChanged` event.

<a name='T-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator'></a>
## NoFileXmlLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

A `XML Logging Configurator` that relies on a particular `.config` file to contain the logging setting(s).

<a name='M-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IXmlLoggingConfigurator](#T-xyLOGIX-Core-Debug-IXmlLoggingConfigurator 'xyLOGIX.Core.Debug.IXmlLoggingConfigurator') interface for the [NoFile](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile')`XML Logging Configurator Type`.

<a name='P-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-Type'></a>
### Type `property`

##### Summary

Gets or sets one of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration values that specifies how the logging subsystem is to be configured.

<a name='M-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-NoFileXmlLoggingConfigurator-Configure-log4net-Repository-ILoggerRepository,System-String-'></a>
### Configure(repository,configurationFileName) `method`

##### Summary

Attempts to configure the logging subsystem, optionally with the settings that are present in the configuration file having the specified `configurationFileName`.

##### Returns

`true` if the configuration operation(s) succeeded; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified configurationFileName of the XML-formatted configuration file containing the necessary logging setting(s).    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value. |

##### Remarks

The value of the `configurationFileName` parameter is ignored if this is a `XML Logging Configurator` object of type [NoFile](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile').



Otherwise, if this `XML Logging Configurator` is of type, [FileBased](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased'), then the `configurationFileName` had better contain the fully-qualified configurationFileName of a `.config` file containing the logging settings, or else this method will fail.

<a name='T-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler'></a>
## NullLoggerLoggingClientLoggerCacheAddHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Selects the [LoggingClientLoggerCacheAddAction](#T-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction') enumeration value that replaces a `null` logger reference contained in an existing logging-client logger-cache entry.

<a name='M-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of the [NullLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler') class and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-Instance 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler.Instance') property.

<a name='P-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-Action'></a>
### Action `property`

##### Summary

Gets the [ReplaceNullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddAction-ReplaceNullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddAction.ReplaceNullLogger') value that identifies the action selected by this handler strategy.

<a name='P-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-HandlerType'></a>
### HandlerType `property`

##### Summary

Gets the [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger') value that identifies the cache-add handler strategy implemented by this object.

<a name='P-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-ILoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.ILoggingClientLoggerCacheAddHandler') interface for the [NullLogger](#F-xyLOGIX-Core-Debug-LoggingClientLoggerCacheAddHandlerType-NullLogger 'xyLOGIX.Core.Debug.LoggingClientLoggerCacheAddHandlerType.NullLogger') logging-client logger-cache `Add` handler strategy.

<a name='M-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [NullLoggerLoggingClientLoggerCacheAddHandler](#T-xyLOGIX-Core-Debug-NullLoggerLoggingClientLoggerCacheAddHandler 'xyLOGIX.Core.Debug.NullLoggerLoggingClientLoggerCacheAddHandler') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` member(s) are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-ObjectDumper'></a>
## ObjectDumper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Object that is responsible for writing out the [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') representation of objects to the log file. Works in a way very similar to LINQPad's Dump() method.

##### Remarks

This class is marked `public` because it is part of the public API exposed by this library.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-#ctor-System-Int32-'></a>
### #ctor(depth) `constructor`

##### Summary

Constructs a new instance of [ObjectDumper](#T-xyLOGIX-Core-Debug-ObjectDumper 'xyLOGIX.Core.Debug.ObjectDumper') and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer value specifying the depth (in terms of inheritance levels) to which to dump object data. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | Thrown if the `depth` parameter is not zero or greater. |

<a name='F-xyLOGIX-Core-Debug-ObjectDumper-_currentStreamPosition'></a>
### _currentStreamPosition `constants`

##### Summary

Integer specifying the current position in the output stream.

<a name='F-xyLOGIX-Core-Debug-ObjectDumper-_depth'></a>
### _depth `constants`

##### Summary

Integer specifying the depth (inheritance levels) to which to dump object data.

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

Reference to a [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') to which to send the logged data.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-OnTextWritten-xyLOGIX-Core-Debug-TextWrittenEventArgs-'></a>
### OnTextWritten(e) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-ObjectDumper-TextWritten 'xyLOGIX.Core.Debug.ObjectDumper.TextWritten') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.Core.Debug.TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs') | A [TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-Events-TextWrittenEventArgs 'xyLOGIX.Core.Debug.Events.TextWrittenEventArgs') that contains the event data. |

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-Object,System-Int32-'></a>
### Write(element,depth) `method`

##### Summary

Writes an object, a reference to which is specified by the `element` parameter, to the log, to the number of inheritance levels specified by `depth`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of an object that should be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer specifying how far up the inheritance chain to dump. Default is zero. Must be zero or greater. |

##### Remarks

By default, this overload of the method sends the dump output to the [Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') stream.



This method does nothing if either a `null` reference is passed as the argument of the `element` parameter, or if the value of the `depth` parameter is less than zero.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-Object,System-Int32,System-IO-TextWriter-'></a>
### Write(element,depth,log) `method`

##### Summary

Writes an object, a reference to which is specified by the `element` parameter, to the log, to the number of inheritance levels specified by `depth`, and outputs it to the [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') instance referred to by the `log` parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of an object that should be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer specifying how far up the inheritance chain to dump. Default is zero. Must be zero or greater. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') to which output should be sent. |

##### Remarks

By default, this overload of the method sends the dump output to the [Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') stream.



If a `null` reference is passed as the argument of the `element` parameter, or if the `depth` parameter is less than zero, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-Write-System-String-'></a>
### Write(s) `method`

##### Summary

Writes the content in the string, `s`, to the [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') wrapped by this object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| s | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the content to be written. |

##### Remarks

This method does nothing if `s` is a blank string.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteIndent'></a>
### WriteIndent() `method`

##### Summary

Writes an indent -- a 4 space tab -- to the [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is wrapped by this object in the [_writer](#F-xyLOGIX-Core-Debug-ObjectDumper-_writer 'xyLOGIX.Core.Debug.ObjectDumper._writer') field at the indent level given by the value of the [_indentLevel](#F-xyLOGIX-Core-Debug-ObjectDumper-_indentLevel 'xyLOGIX.Core.Debug.ObjectDumper._indentLevel') field.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine-System-Object,System-Int32-'></a>
### WriteLine(element,depth) `method`

##### Summary

Writes an object, a reference to which is specified by the `element` parameter, to the log, to the number of inheritance levels specified by `depth`, followed by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of an object that should be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer specifying how far up the inheritance chain to dump. Default is zero. Must be zero or greater. |

##### Remarks

By default, this overload of the method sends the dump output to the [Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') stream.



This method does nothing if either a `null` reference is passed as the argument of the `element` parameter, or if the value of the `depth` parameter is less than zero.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine-System-Object,System-Int32,System-IO-TextWriter-'></a>
### WriteLine(element,depth,log) `method`

##### Summary

Writes an object, a reference to which is specified by the `element` parameter, to the log, to the number of inheritance levels specified by `depth`, and outputs it to the [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') instance referred to by the `log` parameter, followed by a newline character.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of an object that should be dumped. |
| depth | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) Integer specifying how far up the inheritance chain to dump. Default is zero. Must be zero or greater. |
| log | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | (Required.) Reference to an instance of [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') to which output should be sent. |

##### Remarks

By default, this overload of the method sends the dump output to the [Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') stream.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteLine'></a>
### WriteLine() `method`

##### Summary

Outputs a blank line to the [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') that is wrapped by this object.

##### Parameters

This method has no parameters.

##### Remarks

This method does nothing if the [_writer](#F-xyLOGIX-Core-Debug-ObjectDumper-_writer 'xyLOGIX.Core.Debug.ObjectDumper._writer') field is a `null` reference.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteObject-System-String,System-Object-'></a>
### WriteObject(prefix,element) `method`

##### Summary

Workhorse method that actually does the job of writing the specified `element` object to the output stream, with the specified `prefix`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| prefix | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) String containing the prefix to be used. May be blank or `null`. |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the instance of the object to be dumped to the output stream. |

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteObjectToLines-System-String,System-Object-'></a>
### WriteObjectToLines(prefix,element) `method`

##### Summary

Workhorse method that actually does the job of writing the specified `element` object to the output stream, with the specified `prefix`, with a newline character inserted after each line of text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| prefix | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) String containing the prefix to be used. May be blank or `null`. |
| element | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to the instance of the object to be dumped to the output stream. |

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteTab'></a>
### WriteTab() `method`

##### Summary

Writes a 4-space tab at teh proper level of indent, depending on the current position within the stream.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ObjectDumper-WriteValue-System-Object-'></a>
### WriteValue(o) `method`

##### Summary

Formats a value, specified by the reference to the instance of the object, `o`, in a nice way for output.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) Reference to an instance of the object to be formatted and written to the output stream. |

<a name='T-xyLOGIX-Core-Debug-OutputLocationBase'></a>
## OutputLocationBase `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the events, methods, properties, and behaviors for all output location objects.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of [OutputLocationBase](#T-xyLOGIX-Core-Debug-OutputLocationBase 'xyLOGIX.Core.Debug.OutputLocationBase') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This constructor is marked `protected` due to the fact that this class is marked `abstract`.

<a name='P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is turned on or off.

<a name='P-xyLOGIX-Core-Debug-OutputLocationBase-Type'></a>
### Type `property`

##### Summary

Gets one of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration values that indicates the final base of text strings that are fed to this location.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [OutputLocationBase](#T-xyLOGIX-Core-Debug-OutputLocationBase 'xyLOGIX.Core.Debug.OutputLocationBase') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or a `null` reference. |

##### Remarks

It is allowable for the argument of the `value` parameter to be a `null` reference.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

This method takes no action if a `null`, blank, or empty [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is supplied as the argument of the `format` parameter.



This method will not work if the `format` parameter has format argument(s) in it, but the `arg` array is a `null` reference, contains a mismatching number of element(s), or if it contains element(s) whose value(s) do not match the format specifier(s) in the `format` parameter.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by the current line terminator, to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Remarks

This method does nothing if the specified `value` is a `null` reference, or if the value of the [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole') property is set to `true`.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects, followed by the current line terminator, to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

This method takes no action if a `null`, blank, or empty [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is supplied as the argument of the `format` parameter.



This method will not work if the `format` parameter has format argument(s) in it, but the `arg` array is a `null` reference, contains a mismatching number of element(s), or if it contains element(s) whose value(s) do not match the format specifier(s) in the `format` parameter.

<a name='M-xyLOGIX-Core-Debug-OutputLocationBase-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the output location.

##### Parameters

This method has no parameters.

##### Remarks

This method takes no action if the [MuteConsole](#P-xyLOGIX-Core-Debug-OutputLocationBase-MuteConsole 'xyLOGIX.Core.Debug.OutputLocationBase.MuteConsole') property is set to `true`.

<a name='T-xyLOGIX-Core-Debug-OutputLocationProvider'></a>
## OutputLocationProvider `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides access to a list of output locations for debugging.

##### Remarks

This class must be exposed as part of the public API of the library, so we are not marking it as having `internal` visibility here.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [OutputLocationProvider](#T-xyLOGIX-Core-Debug-OutputLocationProvider 'xyLOGIX.Core.Debug.OutputLocationProvider') and returns a reference to it.

##### Parameters

This constructor has no parameters.

<a name='F-xyLOGIX-Core-Debug-OutputLocationProvider-_muteConsole'></a>
### _muteConsole `constants`

##### Summary

A [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') value indicating whether the console output location is turned on or off.

<a name='P-xyLOGIX-Core-Debug-OutputLocationProvider-HasLocations'></a>
### HasLocations `property`

##### Summary

Gets a value indicating whether greater than zero output location(s) are currently configured.

##### Returns

`true` if greater than zero output location(s) are currently configured; `false` otherwise.

<a name='P-xyLOGIX-Core-Debug-OutputLocationProvider-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider') interface.

<a name='P-xyLOGIX-Core-Debug-OutputLocationProvider-InternalOutputLocationList'></a>
### InternalOutputLocationList `property`

##### Summary

Gets a reference to a collection, each element of which implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface.

<a name='P-xyLOGIX-Core-Debug-OutputLocationProvider-LocationCount'></a>
### LocationCount `property`

##### Summary

Gets the count of `Output Location`(s) that are currently defined.

##### Returns

An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that is set to the count of `Output Location`(s) that are currently defined.

##### Remarks

If an exception is caught during the execution of the getter of this property, then the property evaluates to zero.

<a name='P-xyLOGIX-Core-Debug-OutputLocationProvider-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is turned on or off.

##### Remarks

This property raises the [](#E-xyLOGIX-Core-Debug-OutputLocationProvider-MuteConsoleChanged 'xyLOGIX.Core.Debug.OutputLocationProvider.MuteConsoleChanged') event when its value is updated.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [OutputLocationProvider](#T-xyLOGIX-Core-Debug-OutputLocationProvider 'xyLOGIX.Core.Debug.OutputLocationProvider') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-AddOutputLocation-xyLOGIX-Core-Debug-IOutputLocation-'></a>
### AddOutputLocation(location) `method`

##### Summary

Adds the specified output `location` to the public list maintained by this object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [xyLOGIX.Core.Debug.IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') | (Required.) Reference to an instance of an object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface. |

##### Remarks

If the specified `location` has already been added, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-Clear'></a>
### Clear() `method`

##### Summary

Clears the public list of output locations.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-InitializeInternalOutputLocationList'></a>
### InitializeInternalOutputLocationList() `method`

##### Summary

Initializes the [InternalOutputLocationList](#P-xyLOGIX-Core-Debug-OutputLocationProvider-InternalOutputLocationList 'xyLOGIX.Core.Debug.OutputLocationProvider.InternalOutputLocationList') to have default values.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-OnMuteConsoleChanged-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs-'></a>
### OnMuteConsoleChanged(e) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-OutputLocationProvider-MuteConsoleChanged 'xyLOGIX.Core.Debug.OutputLocationProvider.MuteConsoleChanged') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.MuteConsoleChangedEventArgs') | A [MuteConsoleChangedEventArgs](#T-xyLOGIX-Core-Debug-Events-MuteConsoleChangedEventArgs 'xyLOGIX.Core.Debug.Events.MuteConsoleChangedEventArgs') that contains the event data. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Remarks

If the public collection has zero `Output Location`(s) configured, then this method takes no action.

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or `arg` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in `format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by the current line terminator, to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,args) `method`

##### Summary

Writes the text representation of the specified array of objects, followed by the current line terminator, to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') | An I/O error occurred. |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `format` or `args` is `null`. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | The format specification in `format` is invalid. |

<a name='M-xyLOGIX-Core-Debug-OutputLocationProvider-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the output location.

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

Values that indicate the type of output location, such as the console window, debug output pane in Visual Studio, trace listeners, etc.

<a name='F-xyLOGIX-Core-Debug-OutputLocationType-Console'></a>
### Console `constants`

##### Summary

Output is directed to the standard output of this application, and a console window, if present.

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

<a name='T-xyLOGIX-Core-Debug-OutputLocationTypeValidator'></a>
## OutputLocationTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration.

<a name='M-xyLOGIX-Core-Debug-OutputLocationTypeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-OutputLocationTypeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IOutputLocationTypeValidator](#T-xyLOGIX-Core-Debug-Interfaces-IOutputLocationTypeValidator 'xyLOGIX.Core.Debug.Interfaces.IOutputLocationTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-OutputLocationTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-OutputLocationTypeValidator-IsValid-xyLOGIX-Core-Debug-OutputLocationType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the output location `type` value passed is within the value set that is defined by the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration.

##### Returns

`true` if the output location `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') | (Required.) One of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-OutputMultiplexer'></a>
## OutputMultiplexer `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to multiplex debugging output; i.e., write it to multiple locations at the same time.

<a name='P-xyLOGIX-Core-Debug-OutputMultiplexer-MuteConsole'></a>
### MuteConsole `property`

##### Summary

Gets or sets a value indicating whether the console multiplexer is turned on or off.

<a name='P-xyLOGIX-Core-Debug-OutputMultiplexer-OutputLocationProvider'></a>
### OutputLocationProvider `property`

##### Summary

Gets a reference to an instance of an object that implements the [IOutputLocationProvider](#T-xyLOGIX-Core-Debug-IOutputLocationProvider 'xyLOGIX.Core.Debug.IOutputLocationProvider') interface.

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [OutputMultiplexer](#T-xyLOGIX-Core-Debug-OutputMultiplexer 'xyLOGIX.Core.Debug.OutputMultiplexer') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

If the value of the `format` parameter is blank, `null`, or the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, then this method does nothing.



This method also takes no action if there are zero `Output Location`(s) defined.

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by the current line terminator, to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Remarks

If a `null` reference is passed as the argument of the `value` parameter, then this method takes no action.



This method also will not work if there are zero `Output Location`(s) defined.

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects, followed by the current line terminator, to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

If the value of the `format` parameter is blank, `null`, or the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, then this method does nothing.



This method also takes no action if there are zero `Output Location`(s) defined.

<a name='M-xyLOGIX-Core-Debug-OutputMultiplexer-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the output location.

##### Parameters

This method has no parameters.

##### Remarks

This method takes no action if there are zero `Output Location` (s) currently defined.

<a name='T-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter'></a>
## PostSharpLoggingBackendRouter `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Manages the process-wide PostSharp logging backend that routes logging record(s) to specialized logging-client repository(ies).

##### Remarks

The routing backend is installed only when explicitly requested by the session-aware logging path.



Until that occurs, ordinary consumers of [LoggingSubsystemManager](#T-xyLOGIX-Core-Debug-LoggingSubsystemManager 'xyLOGIX.Core.Debug.LoggingSubsystemManager') retain the existing PostSharp backend behavior.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [PostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-Instance 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter.Instance') property.

<a name='F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-RoutingRepositoryName'></a>
### RoutingRepositoryName `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the unique name assigned to the process-wide PostSharp routing repository.

<a name='F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-_routingAppender'></a>
### _routingAppender `constants`

##### Summary

Reference to the routing appender installed in the dedicated PostSharp routing repository.

<a name='F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-_routingBackend'></a>
### _routingBackend `constants`

##### Summary

Reference to the PostSharp backend bound to the dedicated routing repository.

<a name='F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-_routingRepository'></a>
### _routingRepository `constants`

##### Summary

Reference to the dedicated log4net repository used by the process-wide PostSharp routing backend.

<a name='F-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-_syncRoot'></a>
### _syncRoot `constants`

##### Summary

Reference to an object used to synchronize installation and update operation(s).

<a name='P-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-FallbackRepository'></a>
### FallbackRepository `property`

##### Summary

Gets a reference to the log4net repository that receives logging record(s) when no specialized logging-client session is active.

<a name='P-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IPostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-IPostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.IPostSharpLoggingBackendRouter') interface.

<a name='P-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-IsInstalled'></a>
### IsInstalled `property`

##### Summary

Gets a value indicating whether the process-wide PostSharp logging router has been installed.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [PostSharpLoggingBackendRouter](#T-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter 'xyLOGIX.Core.Debug.PostSharpLoggingBackendRouter') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-ConfigureRoutingRepository-log4net-Repository-ILoggerRepository,log4net-Repository-ILoggerRepository-'></a>
### ConfigureRoutingRepository(repository,fallbackRepository) `method`

##### Summary

Configures the specified repository as the dedicated PostSharp routing repository.

##### Returns

`true` if the repository was successfully configured; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') to configure. |
| fallbackRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is to receive logging record(s) when no specialized session is active. |

##### Remarks

If `repository` is `null`, or is not a [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy'), this method returns `false`.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-FindRepository-System-String-'></a>
### FindRepository(repositoryName) `method`

##### Summary

Finds the log4net repository having the specified name.

##### Returns

Reference to the matching repository; otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the repository name to find. |

##### Remarks

If `repositoryName` is blank, no repository(ies) are available, or no matching repository exists, this method returns `null`.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-GetOrCreateRoutingRepository'></a>
### GetOrCreateRoutingRepository() `method`

##### Summary

Gets or creates the dedicated PostSharp routing repository.

##### Returns

Reference to the dedicated routing repository; otherwise, `null`.

##### Parameters

This method has no parameters.

##### Remarks

If the repository already exists, the existing reference is returned.



If repository creation fails, the repository collection is examined again in case another caller created it concurrently.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingBackendRouter-InstallOrUpdate-log4net-Repository-ILoggerRepository-'></a>
### InstallOrUpdate(fallbackRepository) `method`

##### Summary

Installs the process-wide PostSharp logging router, or updates its fallback repository if the router has already been installed.

##### Returns

`true` if the router was successfully installed or updated; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fallbackRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is to receive logging record(s) when no specialized logging-client session is active. |

##### Remarks

A `null` fallback repository is permitted.



If the router is already installed, this method updates its fallback repository and restores the routing backend as [DefaultBackend](#P-PostSharp-Patterns-Diagnostics-LoggingServices-DefaultBackend 'PostSharp.Patterns.Diagnostics.LoggingServices.DefaultBackend').

<a name='T-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure'></a>
## PostSharpLoggingInfrastructure `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Implements log-file management for the case when we are utilizing PostSharp aspects to handle the bulk of logging for us.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='F-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-_relay'></a>
### _relay `constants`

##### Summary

Reference to the object that relays all logging to PostSharp.

##### Remarks

This field can only be set to a reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface.

<a name='P-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingInfrastructure](#T-xyLOGIX-Core-Debug-ILoggingInfrastructure 'xyLOGIX.Core.Debug.ILoggingInfrastructure') interface for the [PostSharp](#F-xyLOGIX-Core-Debug-LoggingInfrastructureType-PostSharp 'xyLOGIX.Core.Debug.LoggingInfrastructureType.PostSharp') logging infrastructure type value.

<a name='P-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-Type'></a>
### Type `property`

##### Summary

Gets the [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') value that corresponds to the type of infrastructure that is being utilized.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-FetchRelay'></a>
### FetchRelay() `method`

##### Summary

Attempts to fetch the `log4net` relay for PostSharp by calling the [RedirectLoggingToPostSharp](#M-PostSharp-Patterns-Diagnostics-Backends-Log4Net-Log4NetCollectingRepositorySelector-RedirectLoggingToPostSharp 'PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetCollectingRepositorySelector.RedirectLoggingToPostSharp') method.

##### Returns

`true` if no Exception(s) were caught during the execution of this method, and if the [_relay](#F-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-_relay 'xyLOGIX.Core.Debug.PostSharpLoggingInfrastructure._relay') field ends up not being set to a `null` reference; otherwise, `false`.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-GetRootFileAppenderFileName'></a>
### GetRootFileAppenderFileName() `method`

##### Summary

Gets the value of the [File](#P-log4net-Appender-FileAppender-File 'log4net.Appender.FileAppender.File') property from the first appender in the list of appenders that is of type [FileAppender](#T-log4net-Appender-FileAppender 'log4net.Appender.FileAppender').

##### Returns

String containing the full path and file name of the file the appender is writing to.

##### Parameters

This method has no parameters.

##### Remarks

This method is solely utilized in order to implement the [LogFileName](#P-Core-Debug-ILoggingInfrastructure-LogFileName 'Core.Debug.ILoggingInfrastructure.LogFileName') property.

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-InitializeLogging-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### InitializeLogging(muteDebugLevelIfReleaseMode,overwrite,configurationFileNamename,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Returns

`true` if the logging subsystem initialization process completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true if we should not write out "DEBUG" messages to the Debug output when in the Release mode. Set to false if all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| configurationFileNamename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for initializing log4net. If blank, the system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the console if a log file is being used. If a log file is not used, then no logging at all will occur if this parameter is set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the `XMLConfigurator` object is used to configure logging.    Else, specify here the path to the Debug output to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a user-friendly display name of the application that is using this logging library.    Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') that is to be configured for the current specialized logging-client session.    If `null`, the implementation utilizes its existing legacy repository-selection behavior. |

<a name='M-xyLOGIX-Core-Debug-PostSharpLoggingInfrastructure-OnLoggingInitializationFinished-System-Boolean,log4net-Repository-ILoggerRepository-'></a>
### OnLoggingInitializationFinished(overwrite,repository) `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-DefaultLoggingInfrastructure-LoggingInitializationFinished 'xyLOGIX.Core.Debug.DefaultLoggingInfrastructure.LoggingInitializationFinished') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface.    Supply a value for this parameter if your infrastructure is not utilizing the default `HierarchyRepository`.    The default value of this parameter is a `null` reference. |

<a name='T-xyLOGIX-Core-Debug-ProgramFlowHelper'></a>
## ProgramFlowHelper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines methods and properties to aid in controlling the flow of the program.

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

This method should be called only as necessary to automatically launch the Visual Studio Debugger, attached to the currently-running process instance.



Such calls should be commented out or deleted when no longer needed.

<a name='T-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator'></a>
## ProgrammaticLoggingConfigurator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the publicly-exposed events, methods and properties of a `Logging Configurator` file that sets up logging purely programmatically.

<a name='M-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ILoggingConfigurator](#T-xyLOGIX-Core-Debug-ILoggingConfigurator 'xyLOGIX.Core.Debug.ILoggingConfigurator') interface.

<a name='P-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-Type'></a>
### Type `property`

##### Summary

Gets or sets one of the [LoggingConfiguratorType](#T-xyLOGIX-Core-Debug-LoggingConfiguratorType 'xyLOGIX.Core.Debug.LoggingConfiguratorType') enumeration value(s) that indicates which type of configuration this `Logging Configurator` does.

<a name='M-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ProgrammaticLoggingConfigurator-Configure-System-Boolean,System-Boolean,System-String,System-Boolean,System-String,System-Int32,System-String,log4net-Repository-ILoggerRepository-'></a>
### Configure(muteDebugLevelIfReleaseMode,overwrite,configurationFileName,muteConsole,logFileName,verbosity,applicationName,repository) `method`

##### Summary

Initializes the application's logging subsystem.

##### Returns

`true` if the configuration operation(s) succeeded; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| muteDebugLevelIfReleaseMode | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` if we should not write out `DEBUG` messages to the `Debug` output when in the `Release` mode. Set to `false` if all messages should always be logged. |
| overwrite | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Overwrites any existing logs for the application with the latest logging sent out by this instance. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specifies the path to the configuration file to be utilized for initializing log4net. If blank, the system attempts to utilize the default App.config file. |
| muteConsole | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` to suppress the display of logging messages to the console if a log file is being used. If a log file is not used, then no logging at all will occur if this parameter is set to `true`. |
| logFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) If blank, then the `XMLConfigurator` object is used to configure logging.    Else, specify here the path to the `Debug` output to be created. |
| verbosity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Optional.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') whose value must be `0` or greater.    Indicates the verbosity level.    Higher values mean more verbose.    if the `verbosity` parameter is negative, it will be ignored.    The default value of this parameter is `1`. |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing a user-friendly display name of the application that is using this logging library.    Leave blank to use the default value. |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Optional.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. Supply a value for this parameter if your infrastructure is not utilizing the default HierarchicalRepository. |

<a name='T-xyLOGIX-Core-Debug-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.Core.Debug.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-Error_DepthMustBeNonNegative'></a>
### Error_DepthMustBeNonNegative `property`

##### Summary

Looks up a localized string similar to The 'depth' parameter must be zero or greater..

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-Error_UnableFindAppConfigEntries'></a>
### Error_UnableFindAppConfigEntries `property`

##### Summary

Looks up a localized string similar to Unable to determine the path to the log file's containing folder. Please ensure that the necessary entries for log4net are included in your App.config file..

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-ExceptionMessageFormat'></a>
### ExceptionMessageFormat `property`

##### Summary

Looks up a localized string similar to {0}: {1} {2}.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-Regex_PathnameValidator_PathPattern'></a>
### Regex_PathnameValidator_PathPattern `property`

##### Summary

Looks up a localized string similar to ^(?:[a-zA-Z]:\\|\\\\[^\\/:*?"&lt;&gt;|]+\\[^\\/:*?"&lt;&gt;|]+\\?)(?:[^\\/:*?"&lt;&gt;|]+\\?)*$.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='P-xyLOGIX-Core-Debug-Properties-Resources-TempExceptionFileMessage'></a>
### TempExceptionFileMessage `property`

##### Summary

Looks up a localized string similar to {0} at {1}: Exception caught: {2} {3} --- .

<a name='T-xyLOGIX-Core-Debug-RollingModeValidator'></a>
## RollingModeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') enumeration.

<a name='M-xyLOGIX-Core-Debug-RollingModeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-RollingModeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IRollingModeValidator](#T-xyLOGIX-Core-Debug-Interfaces-IRollingModeValidator 'xyLOGIX.Core.Debug.Interfaces.IRollingModeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-RollingModeValidator-IsValid-log4net-Appender-RollingFileAppender-RollingMode-'></a>
### IsValid(mode) `method`

##### Summary

Determines whether the rolling `mode` value passed is within the value set that is defined by the [RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') enumeration.

##### Returns

`true` if the rolling `mode` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mode | [log4net.Appender.RollingFileAppender.RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') | (Required.) One of the [RollingMode](#T-log4net-Appender-RollingFileAppender-RollingMode 'log4net.Appender.RollingFileAppender.RollingMode') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-RootLoggerProvisionerBase'></a>
## RootLoggerProvisionerBase `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the events, methods, properties, and behaviors for all `Root Logger Provisioner` object(s).

<a name='M-xyLOGIX-Core-Debug-RootLoggerProvisionerBase-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of [RootLoggerProvisionerBase](#T-xyLOGIX-Core-Debug-RootLoggerProvisionerBase 'xyLOGIX.Core.Debug.RootLoggerProvisionerBase') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This constructor is marked `protected` due to the fact that this class is marked `abstract`.

<a name='P-xyLOGIX-Core-Debug-RootLoggerProvisionerBase-Strategy'></a>
### Strategy `property`

##### Summary

Gets the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration value that indicates the strategy used to provision the `Root Logger`.

<a name='M-xyLOGIX-Core-Debug-RootLoggerProvisionerBase-ExecuteFallbackProvisioning'></a>
### ExecuteFallbackProvisioning() `method`

##### Summary

Executes the fallback provisioning strategy for the `Root Logger` .

##### Returns

If successful, a reference to an instance of [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger') that represents the `Root Logger` that is to be utilized; otherwise, a `null` reference is returned.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-RootLoggerProvisionerBase-Provision-log4net-Repository-ILoggerRepository-'></a>
### Provision(loggerRepository) `method`

##### Summary

Provisions the `Root Logger` for the application depending on the value of the `loggerRepository` parameter.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| loggerRepository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') |  |

##### Remarks

If the provided `loggerRepository` can be directly cast to [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy'), then this method returns a reference to an instance of [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger') that is at the root of such a [Hierarchy](#T-log4net-Repository-Hierarchy-Hierarchy 'log4net.Repository.Hierarchy.Hierarchy').



If a `null` reference is passed for the value of the `loggerRepository` parameter, then this method attempts to find the default appender configuration and attempts to then return a reference to that configuration's [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger').



If the first two attempts fail, then this method returns a `null` reference.



If this particular `Root Logger Provisioner` is configured to use the [FromLogManager](#F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy.FromLogManager') strategy, then this method attempts to find the default appender configuration and attempts to then return a reference to that configuration's [Logger](#T-log4net-Repository-Hierarchy-Logger 'log4net.Repository.Hierarchy.Logger').



Failing that, a `null` reference is returned.

<a name='T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy'></a>
## RootLoggerProvisioningStrategy `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Value(s) that determine what approach is used for provisioning access to the `Root Logger` component.

<a name='F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromLogManager'></a>
### FromLogManager `constants`

##### Summary

Call LogManager.GetRepository() to get the root logger.

<a name='F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-FromProvidedLoggingRepository'></a>
### FromProvidedLoggingRepository `constants`

##### Summary

A `loggerRepository` parameter is being provided to the method that needs to provision the `Root Logger` component; use its value.

<a name='F-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown root-logger provisioning strategy.

<a name='T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator'></a>
## RootLoggerProvisioningStrategyValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration.

<a name='M-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IRootLoggerProvisioningStrategyValidator](#T-xyLOGIX-Core-Debug-Interfaces-IRootLoggerProvisioningStrategyValidator 'xyLOGIX.Core.Debug.Interfaces.IRootLoggerProvisioningStrategyValidator') interface.

<a name='M-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategyValidator-IsValid-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy-'></a>
### IsValid(strategy) `method`

##### Summary

Determines whether the root-logger provisioning `strategy` value passed is within the value set that is defined by the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') enumeration.

##### Returns

`true` if the root-logger provisioning `strategy` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| strategy | [xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') | (Required.) One of the [RootLoggerProvisioningStrategy](#T-xyLOGIX-Core-Debug-RootLoggerProvisioningStrategy 'xyLOGIX.Core.Debug.RootLoggerProvisioningStrategy') value(s) that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-SecretStringExtensions'></a>
## SecretStringExtensions `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes "secret" [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') extension methods to help the methods in this library only.

<a name='M-xyLOGIX-Core-Debug-SecretStringExtensions-CollapseNewlinesToSpaces-System-String-'></a>
### CollapseNewlinesToSpaces(value) `method`

##### Summary

"Collapses" or "folds" the specified `value` so that all newlines are transformed to single whitespace characters.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the value passed, but with all newlines transformed to single whitespace characters.



Multiple newlines are removed.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the value that is to be collapsed. |

<a name='M-xyLOGIX-Core-Debug-SecretStringExtensions-EqualsAnyOfNoCase-System-String,System-String[]-'></a>
### EqualsAnyOfNoCase(value,list) `method`

##### Summary

Determines whether the specified `value` is equal to, regardless of case, any of the item(s) in the specified `list`.

##### Returns

`true` if one of the element(s) of the specified `list` matches the value, regardless of case; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the value that is to be examined. |
| list | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | (Required.) One or more [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value(s) that are to be checked for equality without regard to case. |

##### Remarks

If nothing is passed for the `list` parameter, then the method returns `false`.



If the value is the `null`, blank, or [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, and one of the element(s) of the `list` is also, then this method returns `true`.

<a name='M-xyLOGIX-Core-Debug-SecretStringExtensions-IsAbsolutePath-System-String-'></a>
### IsAbsolutePath(path) `method`

##### Summary

Determines whether the specified `path` is a fully-qualified, absolute path or not.

##### Returns

`true` if the `path` specified is a fully-qualified, absolute path; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the path to be checked. |

<a name='T-xyLOGIX-Core-Debug-ServiceFlowHelper'></a>
## ServiceFlowHelper `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods and properties to assist with the operational flow of a Windows service.

<a name='M-xyLOGIX-Core-Debug-ServiceFlowHelper-EmergencyStop-System-Action-'></a>
### EmergencyStop(notificationAction) `method`

##### Summary

Brings the Windows Service screeching suddenly to a halt.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| notificationAction | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | (Optional.) Code to be called immediately prior to the emergency stop.    If this parameter is passed a `null` reference as its argument, then nothing will be called. |

##### Remarks

Before calling this method, services should de-configure themselves to be automatically re-started by the operating system.

<a name='M-xyLOGIX-Core-Debug-ServiceFlowHelper-OnDebuggerStartPending'></a>
### OnDebuggerStartPending() `method`

##### Summary

Raises the [](#E-xyLOGIX-Core-Debug-ServiceFlowHelper-DebuggerStartPending 'xyLOGIX.Core.Debug.ServiceFlowHelper.DebuggerStartPending') event.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-ServiceFlowHelper-StartDebugger'></a>
### StartDebugger() `method`

##### Summary

Call this method to invoke the just-in-time debugger.

##### Parameters

This method has no parameters.

##### Remarks

Raises the [](#E-xyLOGIX-Core-Debug-ServiceFlowHelper-DebuggerStartPending 'xyLOGIX.Core.Debug.ServiceFlowHelper.DebuggerStartPending') event prior to actually breaking into the debugger. This is helpful to run, e.g., service configuration code, prior to the operation.

<a name='T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach'></a>
## SessionLoggerFetchApproach `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Value(s) that identify the particular approach that is to be utilized to fetch a logger for a client session, or to use the legacy logger if no other approach is available.

<a name='F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchByRepositoryNameAndSourceType'></a>
### FetchByRepositoryNameAndSourceType `constants`

##### Summary

Attempt to fetch the logger for a particular client session by using the name of the repository that is associated with the logger and the type of the source that is requesting the logger.

<a name='F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchFromCache'></a>
### FetchFromCache `constants`

##### Summary

Attempt to fetch the logger from an internal cache that maps source type(s) to previously-retrieved logger(s).

<a name='F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-FetchLegacyLogger'></a>
### FetchLegacyLogger `constants`

##### Summary

Attempt to fetch the logger by the legacy method.

<a name='F-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown session-logger fetching approach.

##### Remarks

This value is used to indicate that the session-logger fetching approach is unknown or has not been specified.



It can be used as a default value or to handle cases where the fetching approach cannot be determined.

<a name='T-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator'></a>
## SessionLoggerFetchApproachValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration.

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of [SessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This is an empty, `private` constructor to prohibit direct allocation of this class, as it is a `Singleton` object accessible via the [Instance](#P-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-Instance 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator.Instance') property.

<a name='P-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [ISessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-ISessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.ISessionLoggerFetchApproachValidator') interface.

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [SessionLoggerFetchApproachValidator](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator 'xyLOGIX.Core.Debug.SessionLoggerFetchApproachValidator') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-IsValid-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-'></a>
### IsValid(approach) `method`

##### Summary

Determines whether the session-logger fetching `approach` value passed is within the value set that is defined by the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration.

##### Returns

`true` if the session-logger fetching `approach` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| approach | [xyLOGIX.Core.Debug.SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') | (Required.) One of the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') values that is to be examined. |

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetchApproachValidator-IsValidSilent-xyLOGIX-Core-Debug-SessionLoggerFetchApproach-'></a>
### IsValidSilent(approach) `method`

##### Summary

Determines whether the session-logger fetching `approach` value passed is within the value set that is defined by the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration.

##### Returns

`true` if the session-logger fetching `approach` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| approach | [xyLOGIX.Core.Debug.SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') | (Required.) One of the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') values that is to be examined. |

<a name='T-xyLOGIX-Core-Debug-SessionLoggerFetcherBase'></a>
## SessionLoggerFetcherBase `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the events, methods, properties, and behaviors for all `Session Logger Fetcher` component(s).

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of [SessionLoggerFetcherBase](#T-xyLOGIX-Core-Debug-SessionLoggerFetcherBase 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This constructor is marked `protected` due to the fact that this class is marked `abstract`.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='P-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-Approach'></a>
### Approach `property`

##### Summary

Gets the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that identifies the particular approach that is to be utilized to fetch a logger for a client session, or to use the legacy logger if no other approach is available.

<a name='P-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-SyncRoot'></a>
### SyncRoot `property`

##### Summary

Gets a reference to an instance of an object that is to be used for thread synchronization purposes.

<a name='P-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-_sourceTypeFQNToLogMap'></a>
### _sourceTypeFQNToLogMap `property`

##### Summary

Gets a reference to an instance of an object that implements the [IDictionary\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IDictionary`2 'System.Collections.Generic.IDictionary`2') that maps [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value(s), consisting of the fully-qualified name(s) of source type(s), to reference(s) to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that is a logger of that type.

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [SessionLoggerFetcherBase](#T-xyLOGIX-Core-Debug-SessionLoggerFetcherBase 'xyLOGIX.Core.Debug.SessionLoggerFetcherBase') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-ClearInternalCache'></a>
### ClearInternalCache() `method`

##### Summary

Clears the internal logging-client session logger cache.

##### Parameters

This method has no parameters.

##### Remarks

If the cache already has zero elements, then this method takes no action.

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-FetchLogger-System-Type,System-String-'></a>
### FetchLogger(sourceType,repositoryName) `method`

##### Summary

Attempts to fetch a logger for a client session by using specified `sourceType` and optional `repositoryName`, if specified, per the [SessionLoggerFetchApproach](#T-xyLOGIX-Core-Debug-SessionLoggerFetchApproach 'xyLOGIX.Core.Debug.SessionLoggerFetchApproach') enumeration value that is specified by the [Approach](#P-xyLOGIX-Core-Debug-ISessionLoggerFetcher-Approach 'xyLOGIX.Core.Debug.ISessionLoggerFetcher.Approach') property.

##### Returns

If successful, a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that is utilized to identify the logger that is to be fetched for a client session.    Perhaps this value might come from an internal cache. |
| repositoryName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that is set to the name of the repository that is associated with the logger that is to be fetched for a client session.    If this value is not specified, then the default repository name will be used.    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.    The repository name is only to be provided when a more refined search is to be employed.    In such a case where we are searching on the repository name, then the value of the `repositoryName` parameter must be specified, and it must not be [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty'). |

<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-TryAddLoggerToInternalCache-System-Type,log4net-ILog-'></a>
### TryAddLoggerToInternalCache(sourceType,logger) `method`

##### Summary

Attempts to add the specified `logger` to the internal cache, keyed by the fully-qualified name of the specified `sourceType`.

##### Returns

`true` if the specified operation(s) have completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that identifies the type for which to cache the logger. |
| logger | [log4net.ILog](#T-log4net-ILog 'log4net.ILog') | (Required.) Reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that identifies the logger that corresponds to the specified `sourceType` for which to cache the logger. |

##### Remarks



<a name='M-xyLOGIX-Core-Debug-SessionLoggerFetcherBase-TryGetLoggerFromInternalCache-System-Type-'></a>
### TryGetLoggerFromInternalCache(sourceType) `method`

##### Summary

Looks up the specified `sourceType` in the internal cache; if found, returns a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface that can be utilized for logging.

##### Returns

If successful, a reference to an instance of an object that implements the [ILog](#T-log4net-ILog 'log4net.ILog') interface; otherwise, a `null` reference is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | (Required.) Reference to an instance of [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') that identifies the source of the logging record(s). |

<a name='T-xyLOGIX-Core-Debug-SetLog'></a>
## SetLog `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Sets elements of the log.

<a name='P-xyLOGIX-Core-Debug-SetLog-ApplicationName'></a>
### ApplicationName `property`

##### Summary

Gets or sets a string that provides the name to use for the application's log file.

<a name='T-xyLOGIX-Core-Debug-Setup'></a>
## Setup `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes `static` methods to perform setup tasks.

<a name='P-xyLOGIX-Core-Debug-Setup-EventLogManager'></a>
### EventLogManager `property`

##### Summary

Gets a reference to an instance of an object that implements the [IEventLogManager](#T-xyLOGIX-Core-Debug-IEventLogManager 'xyLOGIX.Core.Debug.IEventLogManager') interface.

<a name='M-xyLOGIX-Core-Debug-Setup-DetermineEventSourceName-System-String-'></a>
### DetermineEventSourceName(applicationName) `method`

##### Summary

Attempts to determine the proper value for the [ApplicationName](#P-xyLOGIX-Core-Debug-DebugUtils-ApplicationName 'xyLOGIX.Core.Debug.DebugUtils.ApplicationName') property, given the specified `applicationName`.

##### Returns

If successful, a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value that is to be used for the [ApplicationName](#P-xyLOGIX-Core-Debug-DebugUtils-ApplicationName 'xyLOGIX.Core.Debug.DebugUtils.ApplicationName') property; otherwise, the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the application name that is to be used; if this value is blank, `null`, or the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value, then the result of attempting to get the assembly `ProductName` value is used instead.    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value. |

<a name='M-xyLOGIX-Core-Debug-Setup-EventLogging-System-String-'></a>
### EventLogging(applicationName) `method`

##### Summary

Sets up the Windows Event Log Application log quote to correspond either to the specified `applicationName`, or to a event quote name that we automatically obtain.

##### Returns

`true` if the operation completed successfully; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| applicationName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that provides a user-friendly version of the application's name for viewing in the Windows Event Log Viewer; leave blank to use the default value. |

<a name='T-xyLOGIX-Core-Debug-SpecialVisualStudioProcessNames'></a>
## SpecialVisualStudioProcessNames `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Value(s) that represent the names of special Visual Studio process(es).

<a name='F-xyLOGIX-Core-Debug-SpecialVisualStudioProcessNames-DevEnv'></a>
### DevEnv `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the value, `devenv`, which is the name of the `DevEnv` process of Visual Studio.

<a name='M-xyLOGIX-Core-Debug-SpecialVisualStudioProcessNames-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [SpecialVisualStudioProcessNames](#T-xyLOGIX-Core-Debug-SpecialVisualStudioProcessNames 'xyLOGIX.Core.Debug.SpecialVisualStudioProcessNames') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-Split'></a>
## Split `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides methods for splitting [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value(s) into array(s) of argument(s)

<a name='P-xyLOGIX-Core-Debug-Split-CommandLineRegex'></a>
### CommandLineRegex `property`

##### Summary

Gets a reference to an instance of [Regex](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex') that is a regular expression used to split command-line arguments into individual parts.

<a name='M-xyLOGIX-Core-Debug-Split-CommandLine-System-String-'></a>
### CommandLine(commandLine) `method`

##### Summary

Splits the specified command-line string into an array of arguments, respecting quoted segments and spaces.

##### Returns

An enumerable collection of [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') value(s), each representing an argument parsed from the command line. The empty collection is returned if the `commandLine` is `null`, blank, or if a parsing error occurs.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| commandLine | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the full command-line input to be split into arguments. If `null` or blank, an empty array is returned. |

##### Remarks

This method uses a regular expression to identify arguments based on quoted and unquoted segments. Quoted arguments retain their content without the surrounding quotes. Unquoted arguments are split on spaces.

<a name='T-xyLOGIX-Core-Debug-TextEmittedEventArgs'></a>
## TextEmittedEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `TextEmitted` event handlers.

<a name='M-xyLOGIX-Core-Debug-TextEmittedEventArgs-#ctor-System-String,xyLOGIX-Core-Debug-DebugLevel-'></a>
### #ctor(text,level) `constructor`

##### Summary

Constructs a new instance of [TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs') and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the text that is otherwise going to be written to the log. |
| level | [xyLOGIX.Core.Debug.DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') | One of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration values that indicates of what level of severity is the message. |

<a name='P-xyLOGIX-Core-Debug-TextEmittedEventArgs-Level'></a>
### Level `property`

##### Summary

Gets of the [DebugLevel](#T-xyLOGIX-Core-Debug-DebugLevel 'xyLOGIX.Core.Debug.DebugLevel') enumeration values that indicates of what level of severity is the message.

<a name='P-xyLOGIX-Core-Debug-TextEmittedEventArgs-Text'></a>
### Text `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the text that is otherwise going to be written to the log.

<a name='M-xyLOGIX-Core-Debug-TextEmittedEventArgs-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-TextEmittedEventHandler'></a>
## TextEmittedEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `TextEmitted` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.TextEmittedEventHandler](#T-T-xyLOGIX-Core-Debug-TextEmittedEventHandler 'T:xyLOGIX.Core.Debug.TextEmittedEventHandler') | A [TextEmittedEventArgs](#T-xyLOGIX-Core-Debug-TextEmittedEventArgs 'xyLOGIX.Core.Debug.TextEmittedEventArgs') that contains the event data. |

##### Remarks

This delegate merely specifies the signature of all methods that handle the `TextEmitted` event.

<a name='T-xyLOGIX-Core-Debug-TextWrittenEventArgs'></a>
## TextWrittenEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `TextWritten` event handlers.

<a name='M-xyLOGIX-Core-Debug-TextWrittenEventArgs-#ctor-System-String-'></a>
### #ctor(text) `constructor`

##### Summary

Constructs a new instance of [TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs') and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the text to be written. |

<a name='P-xyLOGIX-Core-Debug-TextWrittenEventArgs-Text'></a>
### Text `property`

##### Summary

Gets a string containing the text to be written.

<a name='M-xyLOGIX-Core-Debug-TextWrittenEventArgs-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-TextWrittenEventHandler'></a>
## TextWrittenEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a TextWritten event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.TextWrittenEventHandler](#T-T-xyLOGIX-Core-Debug-TextWrittenEventHandler 'T:xyLOGIX.Core.Debug.TextWrittenEventHandler') | A [TextWrittenEventArgs](#T-xyLOGIX-Core-Debug-TextWrittenEventArgs 'xyLOGIX.Core.Debug.TextWrittenEventArgs') that contains the event data. |

##### Remarks

This delegate merely specifies the signature of all methods that handle the TextWritten event.



The TextWritten event is raised when text has been output to a console, text file, or other base, as a means of allowing more than one part of a software system to participate in the output of text.

<a name='T-xyLOGIX-Core-Debug-TraceOutputLocation'></a>
## TraceOutputLocation `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Writes debugging output to the window in Visual Studio or whichever other debugger can listen to the output of the [Trace](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Trace 'System.Diagnostics.Trace') class' methods.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-TraceOutputLocation-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IOutputLocation](#T-xyLOGIX-Core-Debug-IOutputLocation 'xyLOGIX.Core.Debug.IOutputLocation') interface that directs debugging output to the window in Visual Studio when running in Release mode.

<a name='P-xyLOGIX-Core-Debug-TraceOutputLocation-Type'></a>
### Type `property`

##### Summary

Gets one of the [OutputLocationType](#T-xyLOGIX-Core-Debug-OutputLocationType 'xyLOGIX.Core.Debug.OutputLocationType') enumeration values that indicates the final base of text strings that are fed to this location.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-Write-System-Object-'></a>
### Write(value) `method`

##### Summary

Writes the text representation of the specified object to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write, or `null`. |

##### Remarks

It is allowable for the argument of the `value` parameter to be a `null` reference.



This method also takes no action if a debugger is listening or attached.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-Write-System-String,System-Object[]-'></a>
### Write(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

If a `null`, blank, or empty [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is supplied as the argument of the `format` paramreter, then this method does nothing.



This method also takes no action if a debugger is listening or attached.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine-System-Object-'></a>
### WriteLine(value) `method`

##### Summary

Writes the text representation of the specified object, followed by the current line terminator, to the output location.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to write. |

##### Remarks

It is allowable for the argument of the `value` parameter to be a `null` reference.



This method also takes no action if a debugger is listening or attached.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine-System-String,System-Object[]-'></a>
### WriteLine(format,arg) `method`

##### Summary

Writes the text representation of the specified array of objects, followed by the current line terminator, to the output location using the specified format information.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| format | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A composite format string. |
| arg | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | An array of objects to write using `format` . |

##### Remarks

If a `null`, blank, or empty [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') is supplied as the argument of the `format` paramreter, then this method does nothing.



This method also takes no action if a debugger is listening or attached.

<a name='M-xyLOGIX-Core-Debug-TraceOutputLocation-WriteLine'></a>
### WriteLine() `method`

##### Summary

Writes the current line terminator to the output location.

##### Parameters

This method has no parameters.

##### Remarks

This method takes no action if a debugger is listening or is attached.

<a name='T-xyLOGIX-Core-Debug-Truncate'></a>
## Truncate `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static method(s) that truncate an existing file(s) to zero bytes.

<a name='M-xyLOGIX-Core-Debug-Truncate-FileHavingPath-System-String-'></a>
### FileHavingPath(pathname) `method`

##### Summary

Truncates the file identified by `pathname` so its length becomes zero bytes while leaving the file entry itself on the file system. If the file does not exist, the method returns `true` because there is nothing to do. If `pathname` is `null`, empty, or contains only whitespace, the method returns `false`.

##### Returns

`true` when the operation succeeds or when the target file is absent; `false` when the path is invalid or an error occurs while truncating.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pathname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) The fully-qualified path of the file to truncate. |

<a name='T-xyLOGIX-Core-Debug-Validate'></a>
## Validate `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static method(s) to validate information and settings.

<a name='P-xyLOGIX-Core-Debug-Validate-LoggingInfrastructureTypeValidator'></a>
### LoggingInfrastructureTypeValidator `property`

##### Summary

Gets a reference to an instance of an object that implements the [ILoggingInfrastructureTypeValidator](#T-xyLOGIX-Core-Debug-ILoggingInfrastructureTypeValidator 'xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-Validate-LoggingInfrastructureType-xyLOGIX-Core-Debug-LoggingInfrastructureType-'></a>
### LoggingInfrastructureType(type) `method`

##### Summary

Determines whether the specified logging infrastructure `type` value is in the set of valid values.

##### Returns

`true` if the specified logging infrastructure `type` is in the set of valid values.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') | (Required.) The [LoggingInfrastructureType](#T-xyLOGIX-Core-Debug-LoggingInfrastructureType 'xyLOGIX.Core.Debug.LoggingInfrastructureType') enumeration value that is to be validated. |

<a name='T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs'></a>
## VerbosityChangedEventArgs `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Provides information for `VerbosityChanged` event handlers.

<a name='M-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-#ctor-System-Int32,System-Int32-'></a>
### #ctor(oldValue,newValue) `constructor`

##### Summary

Constructs a new instance of [VerbosityChangedEventArgs](#T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs') and returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| oldValue | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that is the former value of the [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property. |
| newValue | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | (Required.) An [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that is the current value of the [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property. |

<a name='P-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-NewValue'></a>
### NewValue `property`

##### Summary

Gets an [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that is the new value of the [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property.

<a name='P-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-OldValue'></a>
### OldValue `property`

##### Summary

Gets an [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') value that is the former value of the [Verbosity](#P-xyLOGIX-Core-Debug-DebugUtils-Verbosity 'xyLOGIX.Core.Debug.DebugUtils.Verbosity') property.

<a name='M-xyLOGIX-Core-Debug-VerbosityChangedEventArgs-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only for the [VerbosityChangedEventArgs](#T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='T-xyLOGIX-Core-Debug-VerbosityChangedEventHandler'></a>
## VerbosityChangedEventHandler `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Represents a handler for a `VerbosityChanged` event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [T:xyLOGIX.Core.Debug.VerbosityChangedEventHandler](#T-T-xyLOGIX-Core-Debug-VerbosityChangedEventHandler 'T:xyLOGIX.Core.Debug.VerbosityChangedEventHandler') | A [VerbosityChangedEventArgs](#T-xyLOGIX-Core-Debug-VerbosityChangedEventArgs 'xyLOGIX.Core.Debug.VerbosityChangedEventArgs') that contains the event data. |

##### Remarks

This delegate merely specifies the signature of all methods that handle the `VerbosityChanged` event.

<a name='T-xyLOGIX-Core-Debug-VsixHosting'></a>
## VsixHosting `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Helpers for VSIX hosting (Visual Studio runs inside devenv.exe). Ensures dependent assemblies (e.g., log4net, PostSharp runtime) are found in the VSIX folder even if the host didn't add a binding path.

<a name='F-xyLOGIX-Core-Debug-VsixHosting-_resolverInstalled'></a>
### _resolverInstalled `constants`

##### Summary

Value that indicates whether the assembly resolver has been installed.

<a name='M-xyLOGIX-Core-Debug-VsixHosting-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes `static` data or performs actions that need to be performed once only for the [VsixHosting](#T-xyLOGIX-Core-Debug-VsixHosting 'xyLOGIX.Core.Debug.VsixHosting') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being created or before any `static` members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]` attribute in order to simplify the logging output.

<a name='M-xyLOGIX-Core-Debug-VsixHosting-EnsureAssemblyResolver'></a>
### EnsureAssemblyResolver() `method`

##### Summary

Installs a conservative `AppDomain.AssemblyResolve` handler that probes the folder of this assembly.



This complements Visual Studio's probing rules.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-VsixHosting-GetContainingBaseDir'></a>
### GetContainingBaseDir() `method`

##### Summary

Attempts to obtain the fully-qualified pathname of the folder that contains whatever assembly this code is running in.

##### Returns

If successful, a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the folder that contains whatever assembly this code is running in; otherwise, the method returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-VsixHosting-GetDefaultVsixLogPath-System-String,System-String-'></a>
### GetDefaultVsixLogPath(assemblyTitle,productName) `method`

##### Summary

Returns a sensible log file path under `%PROGRAMDATA%` for a VSIX.

##### Returns

If successful, a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the log file to use for the target VSIX extension; otherwise, the method returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblyTitle | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the title of the assembly that is to be logged.    The value of this parameter must not be blank.    Furthermore, it cannot contain any whitespace. |
| productName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the name of the product.    The value of this parameter cannot be blank.    It can contain whitespace. |

##### Remarks

If `null`, a blank [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String'), or the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is passed as the argument of either of the `assemblyTitle` or `productName` parameters, then this method returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.

<a name='M-xyLOGIX-Core-Debug-VsixHosting-IsVsixHost'></a>
### IsVsixHost() `method`

##### Summary

Determines whether this code is running inside Visual Studio (i.e., the host process' name is `devenv.exe`) or not.



If so, then it's highly likely that this code is being called from a VSIX extension or a template wizard.

##### Returns

`true` if the current process is `devenv.exe`; otherwise, `false`.

##### Parameters

This method has no parameters.

##### Remarks

If this method cannot make the determination due to an error, then this method returns `false`.

<a name='M-xyLOGIX-Core-Debug-VsixHosting-OnAssemblyResolve-System-Object,System-ResolveEventArgs-'></a>
### OnAssemblyResolve(sender,e) `method`

##### Summary

Handles the [](#E-System-AppDomain-AssemblyResolve 'System.AppDomain.AssemblyResolve') event raised by the current `AppDomain` when it fails to resolve an assembly.

##### Returns

If successful, a reference to an instance of [Assembly](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly 'System.Reflection.Assembly') that resolves the type, assembly, or resource; or a `null` reference if the assembly cannot be resolved.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Reference to an instance of the object that raised the event. |
| e | [System.ResolveEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ResolveEventArgs 'System.ResolveEventArgs') | A [ResolveEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ResolveEventArgs 'System.ResolveEventArgs') that contains the event data. |

<a name='M-xyLOGIX-Core-Debug-VsixHosting-TryDisposeProcess-System-Diagnostics-Process-'></a>
### TryDisposeProcess(process) `method`

##### Summary

Attempts to dispose of the Windows `HPROCESS` handle for the specified `process` object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| process | [System.Diagnostics.Process](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Process 'System.Diagnostics.Process') | (Required.) Reference to an instance of [Process](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Diagnostics.Process 'System.Diagnostics.Process') that is to be disposed. |

##### Remarks

If a `null` reference is passed for the argument of the `process` parameter, then this method does nothing.

<a name='M-xyLOGIX-Core-Debug-VsixHosting-TryGetLog4NetConfigPath'></a>
### TryGetLog4NetConfigPath() `method`

##### Summary

Gets the fully-qualified pathname of the VSIX-local log4net config file, e.g., `log4net.vsix.config`, or `log4net.config`, if present in the same folder as which the `*.dll` file containing this code also lives.

##### Returns

If successful, a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified pathname of the VSIX-local log4net config file, e.g., `log4net.vsix.config`, or `log4net.config`, if present in the same folder as which the `*.dll` file containing this code also lives; otherwise, the method returns the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value.

##### Parameters

This method has no parameters.

##### Remarks

If the method fails, then the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value is returned.

<a name='T-xyLOGIX-Core-Debug-Write'></a>
## Write `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Exposes static method(s) for writing to the log file.

<a name='M-xyLOGIX-Core-Debug-Write-LogFileTimestamp'></a>
### LogFileTimestamp() `method`

##### Summary

Emits a timestamp to the log file. This is useful for debugging purposes.

##### Parameters

This method has no parameters.

<a name='T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase'></a>
## XmlLoggingConfiguratorBase `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Defines the events, methods, properties, and behaviors for all `XML Logging Configurator`s.

<a name='M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of [XmlLoggingConfiguratorBase](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorBase') and returns a reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

This constructor is marked `protected` due to the fact that this class is marked `abstract`.

<a name='P-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase-Type'></a>
### Type `property`

##### Summary

Gets or sets one of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration values that specifies how the logging subsystem is to be configured.

<a name='M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorBase-Configure-log4net-Repository-ILoggerRepository,System-String-'></a>
### Configure(repository,configurationFileName) `method`

##### Summary

Attempts to configure the logging subsystem, optionally with the settings that are present in the configuration file having the specified `configurationFileName`.

##### Returns

`true` if the configuration operation(s) succeeded; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [log4net.Repository.ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') | (Required.) Reference to an instance of an object that implements the [ILoggerRepository](#T-log4net-Repository-ILoggerRepository 'log4net.Repository.ILoggerRepository') interface. |
| configurationFileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Optional.) A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the fully-qualified configurationFileName of the XML-formatted configuration file containing the necessary logging setting(s).    The default value of this parameter is the [Empty](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String.Empty 'System.String.Empty') value. |

##### Remarks

The value of the `configurationFileName` parameter is ignored if this is a `XML Logging Configurator` object of type [NoFile](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.NoFile').



Otherwise, if this `XML Logging Configurator` is of type, [FileBased](#F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType.FileBased'), then the `configurationFileName` had better contain the fully-qualified configurationFileName of a `.config` file containing the logging settings, or else this method will fail.

<a name='T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType'></a>
## XmlLoggingConfiguratorType `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Value(s) that specify the manner in which the logging subsystem is configured.

<a name='F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-FileBased'></a>
### FileBased `constants`

##### Summary

An XML-formatted `app.config` or `web.config` file is available for configuration of the logging subsystem.

<a name='F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-NoFile'></a>
### NoFile `constants`

##### Summary

No XML-formatted `app.config` or `web.config` file is available for configuration of the logging subsystem.

<a name='F-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-Unknown'></a>
### Unknown `constants`

##### Summary

Unknown XML logging configurator type.

<a name='T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator'></a>
## XmlLoggingConfiguratorTypeValidator `type`

##### Namespace

xyLOGIX.Core.Debug

##### Summary

Validates whether certain value(s) are within the defined value set of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration.

<a name='M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator-#ctor'></a>
### #ctor() `constructor`

##### Summary

Empty, `private` constructor to prohibit direct allocation of this class.

##### Parameters

This constructor has no parameters.

<a name='P-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator-Instance'></a>
### Instance `property`

##### Summary

Gets a reference to the one and only instance of the object that implements the [IXmlLoggingConfiguratorTypeValidator](#T-xyLOGIX-Core-Debug-Interfaces-IXmlLoggingConfiguratorTypeValidator 'xyLOGIX.Core.Debug.Interfaces.IXmlLoggingConfiguratorTypeValidator') interface.

<a name='M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator-#cctor'></a>
### #cctor() `method`

##### Summary

Empty, `static` constructor to prohibit direct allocation of this class.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Core-Debug-XmlLoggingConfiguratorTypeValidator-IsValid-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType-'></a>
### IsValid(type) `method`

##### Summary

Determines whether the XML logging configurator `type` value passed is within the value set that is defined by the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') enumeration.

##### Returns

`true` if the XML logging configurator `type` falls within the defined value set; `false` otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [xyLOGIX.Core.Debug.XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') | (Required.) One of the [XmlLoggingConfiguratorType](#T-xyLOGIX-Core-Debug-XmlLoggingConfiguratorType 'xyLOGIX.Core.Debug.XmlLoggingConfiguratorType') value(s) that is to be examined. |
