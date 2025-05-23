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
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        static CreateNewRollingFileAppenderConfigurationValidator() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        [Log(AttributeExclude = true)]
        protected CreateNewRollingFileAppenderConfigurationValidator() { }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.IRollingFileAppenderConfigurationValidator" />
        /// interface for the
        /// <see cref="F:xyLOGIX.Core.Debug.AppenderRetrievalMode.CreateNew" /> use case.
        /// </summary>
        public static IRollingFileAppenderConfigurationValidator Instance
        {
            [DebuggerStepThrough] get;
        } = new CreateNewRollingFileAppenderConfigurationValidator();

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
                System.Diagnostics.Debug.WriteLine(
                    "*** CreateNewRollingFileAppenderConfigurationValidator.IsValid: Checking whether the base-class version of this method worked properly..."
                );

                // Check to see whether the base-class version of this method worked properly.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!base.IsValid(config))
                {
                    // The base-class version of this method did NOT work properly.  This is not desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The base-class version of this method did NOT work properly.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewRollingFileAppenderConfigurationValidator.IsValid: *** SUCCESS *** The base-class version of this method worked properly.  Proceeding..."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            System.Diagnostics.Debug.WriteLine(
                $"CreateNewRollingFileAppenderConfigurationValidator.IsValid: Result = {result}"
            );

            return result;
        }
    }
}