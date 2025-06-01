using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// A concrete implementation of a
    /// <see
    ///     cref="T:PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend" />
    /// that does not include the context in the log message if it comes from the
    /// <see cref="T:xyLOGIX.Core.Debug.DebugUtils" /> class directly.
    /// </summary>
    [Log(AttributeExclude = true)]
    public sealed class ContextAwareBackend : Log4NetLoggingBackend
    {
        /// <summary>
        /// The name only, of the <see cref="T:xyLOGIX.Core.Debug.DebugUtils" /> class.
        /// </summary>
        private const string DebugUtilsFqn = "DebugUtils";

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.ContextAwareBackend" /> and returns a reference
        /// to it.
        /// </summary>
        public ContextAwareBackend() { }

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.ContextAwareBackend" /> and returns a reference
        /// to it.
        /// </summary>
        /// <param name="repo">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface.
        /// </param>
        public ContextAwareBackend(ILoggerRepository repo) : base(repo) { }

        /// <summary>
        /// Gets the last component of the name of the type or namespace. For instance,
        /// when
        /// <see cref="P:PostSharp.Patterns.Diagnostics.LoggingNamespaceSource.FullName" />
        /// is
        /// <c>PostSharp.Patterns.Diagnostics.LoggingBackend</c>,
        /// <see cref="P:PostSharp.Patterns.Diagnostics.LoggingNamespaceSource.Name" /> is
        /// <c>LoggingBackend</c>.
        /// For generic types, the
        /// <see cref="P:PostSharp.Patterns.Diagnostics.LoggingNamespaceSource.Name" />
        /// property includes the arity, i.e. the name of <c>List&lt;T&gt;</c> is
        /// <c>List`1</c>.
        /// If this source is based on a source name rather than a type, this is the
        /// complete source name.
        /// </summary>
        private string GetSourceName()
        {
            var result = string.Empty;

            try
            {
                if (CurrentContext == null) return result;
                if (CurrentContext.Source == null) return result;

                result = CurrentContext.Source.Name;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = string.Empty;
            }

            return result;
        }

        /// <inheritdoc />
        protected override TextLoggingBackendOptions GetTextBackendOptions()
        {
            var options = base.GetTextBackendOptions();

            var sourceName = GetSourceName();

            if (string.IsNullOrWhiteSpace(sourceName)) return options;

            options.IncludeType = !DebugUtilsFqn.Equals(sourceName);

            return options;
        }
    }
}