# Contributing to xyLOGIX.Core.Debug

Thank you for contributing to `xyLOGIX.Core.Debug`.

This repository contains a proprietary .NET Framework class library that provides centralized debugging, logging, log-file initialization, output multiplexing, exception logging, VSIX-host compatibility, and log4net/PostSharp logging-infrastructure support for xyLOGIX software.

## Important licensing and header notice

This codebase is **not MIT licensed**.

Do not add MIT license text, MIT license references, or MIT-style source-file header blocks to new or existing files.

Source files in this repository generally begin directly with `using` directives or a `namespace` declaration. Preserve any existing file header or above-namespace documentation if it is already present, but do not introduce a new mandatory file-header standard.

All source code, documentation, designs, specifications, and related artifacts are confidential and proprietary to xyLOGIX, LLC unless explicitly stated otherwise by the repository owner.

## Technology stack

Use the repository's existing stack and project style:

- .NET Framework 4.8.
- C# 7.3.
- Legacy MSBuild `.csproj` project format.
- `packages.config` NuGet package management.
- Visual Studio 2022/2026-compatible `.sln` files.
- `log4net` for concrete logging output.
- PostSharp 2024.1.6 and PostSharp Diagnostics for aspect-oriented logging support.
- AlphaFS 2.2.6 for file-system operations where the code already uses it.
- Vsxmd 1.4.5 for XML-documentation-to-Markdown generation.
- StrongNamer 0.2.5 where already present.

Do not convert the project to SDK-style format, change package-management style, introduce nullable reference types, or use C# language features newer than C# 7.3.

## Repository shape

The current solution contains a single project:

- `xyLOGIX.Core.Debug.sln`
- `xyLOGIX.Core.Debug/xyLOGIX.Core.Debug.csproj`
- Namespace: `xyLOGIX.Core.Debug`
- Assembly name: `xyLOGIX.Core.Debug`

Keep the project structure simple. Do not split this repository into new module projects unless explicitly requested.

If a new type is added, place it in the existing `xyLOGIX.Core.Debug` namespace unless the repository owner explicitly requests a new project or namespace.

## Design intent

`xyLOGIX.Core.Debug` is a foundational support library. Changes should preserve its role as a small, dependable logging and diagnostics layer that can be reused by other xyLOGIX products.

Prioritize:

- Backward compatibility for public API consumers.
- Deterministic, fault-tolerant behavior.
- Simple static action/factory entry points where the existing code uses that style.
- Interface-oriented internal design where interfaces already exist.
- Clear XML documentation suitable for generated Markdown output.
- Compatibility with Visual Studio extension hosting scenarios.

Avoid large architectural rewrites unless explicitly requested.

## Primary architecture patterns

### Static action classes

The repository uses public static classes with short verb names, such as `Activate`, `Compute`, `Delete`, `Determine`, `Get`, `Has`, `Initialize`, `SetLog`, `Setup`, `Split`, `Truncate`, `Validate`, and `Write`.

When extending one of these classes:

- Keep methods fluent and phrase-like at the call site.
- Preserve the existing static-class style.
- Validate inputs before performing work.
- Log significant decision points.
- Return safe default values on failure.

### Factories and singleton accessors

Factory classes use names such as `GetAppenderManager`, `GetLoggingInfrastructure`, `GetLoggingBackend`, `GetPatternLayout`, and `MakeNewRollingFileAppender`.

Follow the existing conventions:

- `GetXxx.SoleInstance()` returns a singleton or shared instance.
- `GetXxx.OfType(...)` selects a strategy by enum value.
- `MakeNewXxx...` creates a new instance.
- Validate enum inputs with the corresponding validator before selecting a strategy.
- Return `default` or another safe value when selection cannot be completed.

### Strategy and template method patterns

The codebase uses interfaces and abstract base classes for logging infrastructure, logging configurators, output locations, and root logger provisioning.

When extending a strategy family:

1. Add or update the enum value only when the strategy set truly changes.
2. Update the corresponding validator.
3. Implement or update the relevant interface if the common surface changes.
4. Use an abstract base class for shared behavior when appropriate.
5. Add the concrete strategy.
6. Add or update factory selection logic.
7. Ensure `Unknown = -1` remains the last enum member.

Protected template-method hooks should use `OnXxx` names when they represent overridable behavior.

### Validators

The repository has dedicated validator interfaces and concrete validator classes for enum value sets and file-system status enums.

When adding constrained values:

- Add or update a dedicated `*Validator` class.
- Add or update a matching `I*Validator` interface when needed.
- Add or update the matching `Get*Validator.SoleInstance()` factory.
- Use the validator before switching on an enum or accepting externally supplied values.

### Output locations and multiplexing

The library supports multiple output destinations, including console output, `System.Diagnostics.Debug`, `System.Diagnostics.Trace`, log4net appenders, and Windows Event Log integration.

When changing output behavior:

- Preserve `DebugUtils.Write`, `DebugUtils.WriteLine`, and `DebugUtils.LogException` semantics unless the prompt explicitly requests an API change.
- Respect `DebugUtils.ConsoleOnly`, `DebugUtils.MuteConsole`, `DebugUtils.IsLogging`, verbosity, and related state gates.
- Avoid writing to destinations that the current configuration has intentionally disabled.
- Preserve event-raising behavior such as text-emission and exception-logged notifications.

### VSIX hosting

`VsixHosting` and the `LoggingSubsystemManager` static constructor handle Visual Studio extension hosting concerns.

When touching this area:

- Preserve defensive guards around VSIX detection.
- Avoid creating assembly-resolution side effects outside Visual Studio hosting scenarios.
- Keep failure paths non-fatal and diagnostic-friendly.

## Coding standards

### C# language level

Use C# 7.3 syntax only.

Do not use:

- Nullable reference types.
- Records.
- Init-only setters.
- File-scoped namespaces.
- Top-level statements.
- Global using directives.
- Switch expressions.
- Range or index syntax.
- `using var` declarations.
- Default interface members.

### Defensive programming

Validate inputs early and explicitly.

Do not assume:

- Strings are nonblank.
- Paths exist.
- Collections contain useful values.
- Enum values are inside the defined value set.
- PostSharp/log4net state has already been initialized.
- File-system operations succeed.
- Event subscribers are present.

Prefer simple guard clauses and early returns over deep nesting.

### Result-variable pattern

Methods that return a value should normally use a local `result` variable initialized to the default failure value.

```csharp
public bool TryDoSomething(string value)
{
    var result = false;

    try
    {
        if (string.IsNullOrWhiteSpace(value)) return result;

        // Perform work here.

        /* If we made it this far with no Exception(s) getting caught, then assume that the operation(s) succeeded. */
        result = true;
    }
    catch (Exception ex)
    {
        // dump all the exception info to the log
        DebugUtils.LogException(ex);

        result = false;
    }

    return result;
}
```

For methods that cannot safely call `DebugUtils` because logging may not yet be initialized, use `System.Diagnostics.Debug.WriteLine` consistently with the surrounding file.

### Exception handling

Most method bodies in this repository are wrapped in `try`/`catch` blocks.

When adding or modifying methods:

- Catch `Exception` only at the method boundary where the existing style does so.
- Log exceptions using the same mechanism used by the surrounding class.
- Place `// dump all the exception info to the log` immediately before `DebugUtils.LogException(ex);` when using `DebugUtils`.
- Return a safe default after logging.
- Do not swallow exceptions silently.

### Logging style

Preserve the repository's explicit logging style.

Typical log messages include:

- An operation prefix containing the declaring type and method name.
- `*** SUCCESS ***` for successful gates or completed operations.
- `*** ERROR ***` for failed gates or failed operations.
- `*** WARNING ***` for non-fatal anomalies.
- `Proceeding...` or `Stopping...` to make control flow clear.

Do not replace explicit logging with terse or implicit behavior.

### PostSharp attributes

This codebase uses PostSharp attributes heavily.

When adding static constructors, simple factory constructors, or methods that should not be logged, follow the surrounding pattern and use:

```csharp
[Log(AttributeExclude = true)]
```

Do not apply `[Log(AttributeExclude = true)]` to enums or enum members.

### Thread safety

`DebugUtils` is decorated with PostSharp synchronization attributes and exposes global/static state.

When changing shared static state:

- Avoid unnecessary new mutable static state.
- Validate values before assignment when feasible.
- Consider existing synchronization and event behavior.
- Do not introduce unsafe lazy initialization patterns.

## XML documentation standards

XML documentation is important because this repository uses Vsxmd to generate Markdown documentation.

### General rules

- Document public, internal, protected, and private code entities when generating or revising code.
- Prefer fully qualified `<see cref="..." />` references when they resolve without creating a circular dependency or requiring an inappropriate project reference.
- Use `<c>...</c>` for file names, attributes, code constructs, and conceptual type mentions that should not be cross-reference targets.
- Use `<see langword="null" />`, `<see langword="true" />`, and `<see langword="false" />` for C# keywords when referring to the keyword value.
- Use `<paramref name="..." />` when referring to a method parameter.
- Use `<para />` between adjacent documentation sentences when multiline remarks are needed.
- Prefer XML documentation that resembles Microsoft Learn output.

### Enum documentation

Enums in this repository are value-set boundaries and often sit near the leaves of the dependency tree.

For enum documentation:

- Alphabetize enum members.
- Do not assign explicit values except `Unknown = -1`.
- Keep `Unknown = -1` as the final member.
- XML document every enum and every enum member.
- Use `<c>InterfaceName</c>` for conceptual references that would otherwise create an unnecessary or circular dependency.
- Use `<see cref="T:..." />` only when the referenced type is in the same project or already safely referenced.

### Interface documentation

When creating or updating interfaces:

- Define only the public contract needed by consumers or strategy/factory code.
- Keep documentation duplicatable on implementing members.
- Avoid referring to private helper methods in interface documentation.

## Events

When adding events:

- Do not declare an event unless it is actually raised.
- Provide a corresponding `protected virtual OnXxx(...)` method for instance members.
- Use null-conditional invocation, for example `SomeEvent?.Invoke(...)`.
- Preserve existing delegate and `EventArgs` patterns.

For static classes, follow the existing event-raising pattern used by the surrounding code.

## Package and dependency management

This project intentionally uses `packages.config` and locked package versions.

When changing dependencies:

- Do not migrate to `PackageReference` unless explicitly requested.
- Do not update package versions as an incidental cleanup.
- Keep `allowedVersions` ranges aligned with pinned package versions where already present.
- Keep `PostSharp.props`, `PostSharp.targets`, and `Vsxmd.targets` imports intact.
- Do not add project references unless there is a clear requirement.

## Build and generated documentation behavior

The project imports Vsxmd targets and contains build-event logic that checks generated Markdown output.

When changing XML documentation or project metadata:

- Ensure the generated documentation remains useful.
- Avoid breaking Vsxmd generation.
- Keep `README.md` and XML docs conceptually aligned when public API behavior changes.

## Source formatting

Preserve the existing formatting style unless the prompt specifically requests formatting changes.

The codebase currently contains:

- Legacy CRLF-formatted files.
- BOM-prefixed C# files in many places.
- Multi-line attribute and XML documentation formatting.
- ReSharper-friendly property accessor attributes such as `[DebuggerStepThrough] get;`.

Do not churn files for formatting-only reasons unless that is the requested change.

## Testing guidance

This repository does not currently contain a dedicated test project in the tarball.

When tests are requested:

- Use NUnit 4.3.2.
- Prefer a separate test project only when explicitly requested.
- Wrap test bodies in `try`/`catch` when following the user's repository-wide test style.
- Log exceptions and rethrow them; do not swallow test failures.

## Read-before-write workflow

Before modifying existing code:

1. Read the target file.
2. Read nearby related files, especially interfaces, validators, factories, enums, and abstract base classes.
3. Check the `.csproj` for compile inclusion and package/reference context.
4. Determine whether the requested change already exists.
5. Emit the smallest useful delta.

Do not regenerate an entire file when a small targeted change is sufficient.

## Commit-message guidance

Commit messages should follow the repository's concise outline style:

- First line: present-tense, sentence-case summary, no more than 50 characters.
- Second line: blank.
- Body: present-tense outline bullets.
- Wrap file names, paths, code entities, package IDs, XML elements, and values in backticks in the body.
- Do not put backticks in the top line.

## Pull request and issue guidance

When drafting issues or pull requests:

- Be concise and technical.
- Use backticks around code entities, file names, paths, package IDs, and configuration values.
- Do not use Comprehensive Commit format for titles.
- Keep the focus on the requested change and observed repository behavior.

## Out-of-scope guidance from other repositories

Do not copy ProjectCloner-specific, WinForms-specific, wizard-specific, or Visual Studio Template Wizard dialog conventions into this repository unless this codebase later adds those components.

In particular, this `CONTRIBUTING.md` intentionally does not require:

- Windows Forms dark-theme control conventions.
- MVP presenter wiring rules.
- Wizard step dialog conventions.
- MIT license headers.
- Mandatory source-file header blocks.

Those patterns belong to other xyLOGIX repositories unless explicitly introduced here.
