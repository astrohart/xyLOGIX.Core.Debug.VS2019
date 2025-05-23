using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Validates the value(s) of the property(ies) of an instance of an object that
    /// implements the
    /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfiguration" /> interface
    /// for the <see cref="F:xyLOGIX.Core.Debug.AppenderRetrievalMode.CreateNew" /> use
    /// case.
    /// </summary>
    public class
        CreateNewRollingFileAppenderConfigurationValidator :
        RollingFileAppenderConfigurationValidatorBase
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.CreateNewRollingFileAppenderConfigurationValidator" />
        /// class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static CreateNewRollingFileAppenderConfigurationValidator() { }

        /// <summary>
        /// Creates a new instance of
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.CreateNewRollingFileAppenderConfigurationValidator" />
        /// and returns a reference to it.
        /// </summary>
        [Log(AttributeExclude = true)]
        public CreateNewRollingFileAppenderConfigurationValidator() { }

        /// <summary>
        /// Gets the <see cref="T:xyLOGIX.Core.Debug.AppenderRetrievalMode" />
        /// enumeration value that identifies how this
        /// <c>Rolling File Appender Configuration Validator</c> operates.
        /// </summary>
        public override AppenderRetrievalMode Mode
        {
            [DebuggerStepThrough] get;
        } = AppenderRetrievalMode.CreateNew;

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
        public override bool IsValid(
            [NotLogged] IRollingFileAppenderConfiguration config
        )
        {
            var result = true;

            try
            {

            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = true;
            }

            System.Diagnostics.Debug.WriteLine(
                $"CreateNewRollingFileAppenderConfigurationValidator.IsValid: Result = {result}"
            );

            return result;
        }
    }
}