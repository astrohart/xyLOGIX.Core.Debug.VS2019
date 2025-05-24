using log4net.Layout;
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
                // 
                // NOTE: This method takes care of validating the value of the 'config.File'
                // property.
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

                /*
                 * For this particular implementation and use case, it is mandatory that the value of the
                 * 'config.AppendToFile' property be set to 'true'.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** It is mandatory that the value of the 'config.AppendToFile' property be set to 'true'."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** CreateNewRollingFileAppenderConfigurationValidator.IsValid: Checking whether the configuration is set to 'Append' to the file..."
                );

                // Check to see whether the configuration is set to 'Append' to the file.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!config.AppendToFile)
                {
                    // The configuration is NOT set to 'Append' to the file.  This is not desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The configuration is NOT set to 'Append' to the file.  This is not desirable.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewRollingFileAppenderConfigurationValidator.IsValid: *** SUCCESS *** The configuration is set to 'Append' to the file.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** CreateNewRollingFileAppenderConfigurationValidator.IsValid: Checking whether the specified Layout is a PatternLayout..."
                );

                // Check to see whether the specified Layout is a PatternLayout.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!(config.Layout is PatternLayout layout))
                {
                    // The specified Layout is NOT a PatternLayout.  This is not desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The specified Layout is NOT a PatternLayout.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewRollingFileAppenderConfigurationValidator.IsValid: *** SUCCESS *** The specified Layout is a PatternLayout.  Proceeding..."
                );

                /*
                 * It is required that the 'layout.ConversionPattern' property be set to a
                 * non-null reference, non-empty string, and that it does not consist only
                 * of whitespace.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewRollingFileAppenderConfigurationValidator.IsValid: Checking whether the property, 'layout.ConversionPattern', has a null reference for a value, or is blank..."
                );

                // Check to see if the required property, 'layout.ConversionPattern', is set to a null reference,
                // the empty string, or it is otherwise consisting only of whitespace.  If any
                // one of these three case(s) is true, then throw InvalidOperationException with
                // a descriptive error message.
                if (string.IsNullOrWhiteSpace(layout.ConversionPattern))
                {
                    // The required property, 'layout.ConversionPattern', is set to a null reference, the empty string, or it consists only of whitespace.  None of these case(s) are desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The required property, 'layout.ConversionPattern', is set to a null reference, the empty string, or it consists only of whitespace."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $"CreateNewRollingFileAppenderConfigurationValidator.IsValid: *** SUCCESS *** {layout.ConversionPattern.Length} B of data appear to be present in the value of the property, 'layout.ConversionPattern'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewRollingFileAppenderConfigurationValidator.IsValid: Checking whether the max number of backup file(s) is a positive number..."
                );

                // Check to see whether the max number of backup file(s) is a positive number.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method by throwing an exception.
                if (config.MaxSizeRollBackups <= 0)
                {
                    // The max number of backup file(s) is NOT a positive number.  This is not desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The max number of backup file(s) is NOT a positive number.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewRollingFileAppenderConfigurationValidator.IsValid: *** SUCCESS *** The max number of backup file(s) is a positive number.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** CreateNewRollingFileAppenderConfigurationValidator.IsValid: Checking whether the 'RollingStyle' value is within the defined value set..."
                );

                // Check to see whether the 'RollingStyle' value is within the defined value set.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!RollingModeValidator.IsValid(config.RollingStyle))
                {
                    // The 'RollingStyle' value is NOT within the defined value set.  This is not desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The 'RollingStyle' value is NOT within the defined value set.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewRollingFileAppenderConfigurationValidator.IsValid: *** SUCCESS *** The 'RollingStyle' value is within the defined value set.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "CreateNewRollingFileAppenderConfigurationValidator.IsValid: Checking whether the property, 'config.MaximumFileSize', has a null reference for a value, or is blank..."
                );

                // Check to see if the required property, 'config.MaximumFileSize', is set to a null reference,
                // the empty string, or it is otherwise consisting only of whitespace.  If any
                // one of these three case(s) is true, then throw InvalidOperationException with
                // a descriptive error message.
                if (string.IsNullOrWhiteSpace(config.MaximumFileSize))
                {
                    // The required property, 'config.MaximumFileSize', is set to a null reference, the empty string, or it consists only of whitespace.  None of these case(s) are desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The required property, 'config.MaximumFileSize', is set to a null reference, the empty string, or it consists only of whitespace."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $"CreateNewRollingFileAppenderConfigurationValidator.IsValid: *** SUCCESS *** {config.MaximumFileSize.Length} B of data appear to be present in the value of the property, 'config.MaximumFileSize'.  Proceeding..."
                );

                /*
                 * If we made it this far with no Exception(s) getting caught, then
                 * assume that the operation(s) succeeded.
                 */

                result = true;
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