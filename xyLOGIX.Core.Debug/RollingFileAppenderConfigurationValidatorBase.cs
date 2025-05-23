using Alphaleonis.Win32.Filesystem;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using xyLOGIX.Core.Debug.Properties;

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
        /// Array of reserved Windows device names that are not allowed in any path
        /// segment.
        /// </summary>
        protected static readonly string[] ReservedDeviceNames =
        {
            "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4",
            "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3",
            "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
        };

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
        /// Regex pattern to match valid Windows config.Files.
        /// </summary>
        /// <remarks>
        /// Supports both drive-letter paths and UNC config.Files.
        /// <para />
        /// Allows folder and file names that start with a dot (<c>.</c>).
        /// </remarks>
        protected static Regex PathPattern { [DebuggerStepThrough] get; } =
            new Regex(
                Resources.Regex_PathnameValidator_PathPattern,
                RegexOptions.Compiled
            );

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
        public virtual bool IsValid(
            [NotLogged] IRollingFileAppenderConfiguration config
        )
        {
            /*
             * The return value starts off as TRUE.  If any of the property values of the
             * specified 'config' instance are invalid, then an exception is to be thrown,
             * which will then revert hte return value to FALSE.
             */

            var result = true;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "RollingFileAppenderConfigurationValidatorBase.IsValid: Checking whether the method parameter, 'config', has a null reference for a value..."
                );

                // Check to see if the required parameter, 'config', is null. If it is, then
                // throw ArgumentNullException with a descriptive error message.
                if (config == null)
                {
                    // The parameter, 'config', appears to be set to a null reference.  This is not desirable.
                    throw new ArgumentNullException(
                        nameof(config),
                        "*** ERROR *** A null reference was passed for the 'config' method parameter.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    "RollingFileAppenderConfigurationValidatorBase.IsValid: *** SUCCESS *** We have been passed a valid object reference for the method parameter, 'config'."
                );

                /*
                 * For the action of getting an existing Appender, all we really care
                 * about is that the 'File' property of the config is filled in with a
                 * properly-formatted, absolute config.File to a log file.
                 *
                 * Said file need not exist, but it must be a valid config.File.
                 */

                System.Diagnostics.Debug.WriteLine(
                    "RollingFileAppenderConfigurationValidatorBase.IsValid: Checking whether the property, 'config.File', has a null reference for a value, or is blank..."
                );

                // Check to see if the required property, 'config.File', is set to a null reference,
                // the empty string, or it is otherwise consisting only of whitespace.  If any
                // one of these three case(s) is true, then throw InvalidOperationException with
                // a descriptive error message.
                if (string.IsNullOrWhiteSpace(config.File))
                {
                    // The required property, 'config.File', is set to a null reference, the empty string, or it consists only of whitespace.  None of these case(s) are desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The required property, 'config.File', is set to a null reference, the empty string, or it consists only of whitespace."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $"RollingFileAppenderConfigurationValidatorBase.IsValid: *** SUCCESS *** {config.File.Length} B of data appear to be present in the value of the property, 'config.File'.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** RollingFileAppenderConfigurationValidatorBase.IsValid: Checking whether the log file config.File is an absolute path..."
                );

                // Check to see whether the log file config.File is an absolute path.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!config.File.IsAbsolutePath())
                {
                    // The log file config.File is NOT an absolute path.  This is not desirable.
                    throw new InvalidOperationException(
                        "*** ERROR *** The log file config.File is NOT an absolute path.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    "RollingFileAppenderConfigurationValidatorBase.IsValid: *** SUCCESS *** The log file config.File is an absolute path.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Calculating the maximum path length for the current operating system..."
                );

                // ✅ NEW FIX: Enforce MAX_PATH limits
                var maxPathLength = Is.LongPathSupportEnabled()
                    ? MaxPathLength.NTFS
                    : MaxPathLength.Legacy;

                // Dump the variable, maxPathLength, to the Debug output
                System.Diagnostics.Debug.WriteLine(
                    $"RollingFileAppenderConfigurationValidatorBase.IsValid: maxPathLength = {maxPathLength}"
                );

                System.Diagnostics.Debug.WriteLine(
                    $"RollingFileAppenderConfigurationValidatorBase.IsValid: Checking whether the configured log file pathname is NOT longer than {maxPathLength} B..."
                );

                // Check to see whether the configured log file pathname is NOT longer than the maximum.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method by throwing an exception.
                if (config.File.Length > maxPathLength)
                {
                    // The configured log file pathname is longer than the maximum.  This is not desirable.
                    throw new InvalidOperationException(
                        $"*** ERROR *** The configured log file pathname is longer than {maxPathLength} B.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $"RollingFileAppenderConfigurationValidatorBase.IsValid: *** SUCCESS *** The configured log file pathname is NOT longer than {maxPathLength} B.  Proceeding..."
                );

                // Match the input against the PathPattern regex
                var match = PathPattern.Match(config.File);

                System.Diagnostics.Debug.WriteLine(
                    $"*** RollingFileAppenderConfigurationValidatorBase.IsValid: Checking whether the configured log file pathname, '{config.File}', matches the valid format..."
                );

                // Check to see whether the configured log file pathname matches the valid format.
                // If this is not the case, then write an error message to the log file,
                // and then terminate the execution of this method.
                if (!match.Success)
                {
                    // The configured log file pathname does NOT match the valid format.  This is not desirable.
                    throw new InvalidOperationException(
                        $"*** ERROR *** The configured log file pathname, '{config.File}', does NOT match the valid format.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $"RollingFileAppenderConfigurationValidatorBase.IsValid: *** SUCCESS *** The configured log file pathname, '{config.File}', matches the valid format.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Breaking the path into segments, and analyzing each..."
                );

                // Check for reserved device names in each '\'-delineated config.File segment
                var pathSegments = config.File.Split('\\');

                System.Diagnostics.Debug.WriteLine(
                    "RollingFileAppenderConfigurationValidatorBase.IsValid: Checking whether the variable, 'pathSegments', has a null reference for a value..."
                );

                // Check to see if the variable, pathSegments, is null. If it is, send an error to the
                // Debug output and quit, returning from the method.
                if (pathSegments == null)
                {
                    // the variable pathSegments is required to have a valid object reference.
                    throw new InvalidOperationException(
                        "*** ERROR ***  The variable, 'pathSegments', has a null reference.  Stopping..."
                    );
                }

                // We can use the variable, pathSegments, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "RollingFileAppenderConfigurationValidatorBase.IsValid: *** SUCCESS *** The variable, 'pathSegments', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "RollingFileAppenderConfigurationValidatorBase.IsValid *** INFO: Checking whether the array, 'pathSegments', has greater than zero elements..."
                );

                // Check whether the array, 'pathSegments', has greater than zero elements.  If it is empty,
                // then write an error message to the log file, and then terminate the execution of this method.
                // It is preferred for the array to have greater than zero elements.
                if (pathSegments.Length <= 0)
                {
                    // The array, 'pathSegments', has zero elements, and we can't proceed if this is so.
                    throw new InvalidOperationException(
                        "*** ERROR *** The array, 'pathSegments', has zero elements.  Stopping..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    $"RollingFileAppenderConfigurationValidatorBase.IsValid *** SUCCESS *** {pathSegments.Length} element(s) were found in the 'pathSegments' array.  Proceeding..."
                );

                foreach (var segment in pathSegments)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "RollingFileAppenderConfigurationValidatorBase.IsValid: *** FYI *** Checking whether the variable, 'segment', appears to have a null or blank value..."
                    );

                    // Check to see if the required variable, 'segment', appears to have a null 
                    // or blank value. If it does, then send an error to the log file and then 
                    // skip to the next loop iteration.
                    if (string.IsNullOrWhiteSpace(segment))
                    {
                        // The variable, 'segment', appears to have a null or blank value.  This is not desirable.
                        System.Diagnostics.Debug.WriteLine(
                            "RollingFileAppenderConfigurationValidatorBase.IsValid: *** ERROR: The variable, 'segment', appears to have a null or blank value.  Skipping to the next path segment..."
                        );

                        // skip to the next iteration of this loop.
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine(
                        "RollingFileAppenderConfigurationValidatorBase.IsValid: *** SUCCESS *** The variable, 'segment', seems to have a non-blank value.  Proceeding..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        "*** RollingFileAppenderConfigurationValidatorBase.IsValid: Checking whether the current path segment is a reserved name..."
                    );

                    // Check to see whether the current path segment is a reserved name.
                    // If this is not the case, then write an error message to the log file,
                    // and then skip to the next iteration of the loop.
                    if (IsReservedDeviceName(segment))
                    {
                        // The current path segment is a reserved name.  This is not desirable.
                        // We will actually throw InvalidOperationException here, because this is a fatal error.
                        throw new InvalidOperationException(
                            $"*** ERROR *** The current path segment, '{segment}', is a reserved name.  Stopping..."
                        );
                    }

                    System.Diagnostics.Debug.WriteLine(
                        $"RollingFileAppenderConfigurationValidatorBase.IsValid: *** SUCCESS *** The path segment, '{segment}', is NOT a reserved name.  Proceeding..."
                    );
                }

                System.Diagnostics.Debug.WriteLine(
                    "*** SUCCESS *** The pathname is valid."
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
                $"RollingFileAppenderConfigurationValidatorBase.IsValid: Result = {result}"
            );

            return result;
        }

        /// <summary>
        /// Checks if the specified <paramref name="segment" /> is a reserved device name.
        /// </summary>
        /// <param name="segment">
        /// (Required.) A <see cref="T:System.String" /> containing the pathname segment to
        /// check.
        /// </param>
        /// <remarks>
        /// If the value of the <paramref name="segment" /> parameter is the
        /// <see langword="null" />, blank, or <see cref="F:System.String.Empty" />
        /// <see cref="T:System.String" />, then this method returns
        /// <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if the specified <paramref name="segment" />
        /// is a reserved device name; <see langword="false" /> otherwise.
        /// </returns>
        [Log(AttributeExclude = true)]
        protected static bool IsReservedDeviceName(string segment)
        {
            var result = false;

            try
            {
                if (string.IsNullOrWhiteSpace(segment)) return result;

                result = segment.EqualsAnyOfNoCase(ReservedDeviceNames) || Path
                    .GetFileNameWithoutExtension(segment)
                    .EqualsAnyOfNoCase(ReservedDeviceNames);
            }
            catch (Exception ex)
            {
                DebugUtils.LogException(ex);
                result = false;
            }

            return result;
        }
    }
}