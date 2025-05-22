using PostSharp.Patterns.Diagnostics;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Defines the events, methods, properties, and behaviors for all
    /// <c>Rolling File Appender Configuration Validator</c> class(es).
    /// </summary>
    public abstract class
        RollingFileAppenderConfigurationValidatorBase :
        IRollingFileAppenderConfigurationValidator
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the
        /// <see cref="T:xyLOGIX.Core.Debug.RollingFileAppenderConfigurationValidatorBase" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static RollingFileAppenderConfigurationValidatorBase() { }

        /// <summary>
        /// Initializes a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.RollingFileAppenderConfigurationValidatorBase" />
        /// and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// <strong>NOTE:</strong> This constructor is marked <see langword="protected" />
        /// due to the fact that this class is marked <see langword="abstract" />.
        /// </remarks>
        [Log(AttributeExclude = true)]
        protected RollingFileAppenderConfigurationValidatorBase() { }

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" />
        /// enumeration value that identifies how this
        /// <c>Rolling File Appender Configuration Validator</c> operates.
        /// </summary>
        public abstract AppenderRetrievalMode Mode
        {
            [DebuggerStepThrough] get;
        }

        /// <summary>
        /// Validates the value(s) of the property(ies) of the specified
        /// <paramref name="config" />, given the current value of the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator.Mode" />
        /// property.
        /// </summary>
        /// <param name="config">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface
        /// that is to be validated.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the property(ies) of the particular
        /// <paramref name="config" /> instance have valid value(s).
        /// </returns>
        public abstract bool IsValid(
            [NotLogged] IRollingFileAppenderConfiguration config
        );
    }
}