﻿using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods to validate information and settings.
    /// </summary>
    [Log(AttributeExclude = true)]
    internal static class Validate
    {
        /// <summary>
        /// Gets a reference to an instance of an object that implements the
        /// <see cref="T:xyLOGIX.Core.Debug.ILoggingInfrastructureTypeValidator" />
        /// interface.
        /// </summary>
        private static ILoggingInfrastructureTypeValidator
            LoggingInfrastructureTypeValidator { [DebuggerStepThrough] get; } =
            GetLoggingInfrastructureTypeValidator.SoleInstance();

        /// <summary>
        /// Determines whether the specified logging infrastructure
        /// <paramref name="type" /> value is in the set of valid values.
        /// </summary>
        /// <param name="type">
        /// (Required.) The
        /// <see cref="T:xyLOGIX.Core.Debug.LoggingInfrastructureType" /> enumeration value
        /// that is to be validated.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the specified logging infrastructure
        /// <paramref name="type" /> is in the set of valid values.
        /// </returns>
        internal static bool LoggingInfrastructureType(
            LoggingInfrastructureType type
        )
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Validate.LoggingInfrastructureType: Validating the Logging Infrastructure Type value, '{type}'..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** Validate.LoggingInfrastructureType: Checking whether the specified Logging Infrastructure Type value, '{type}', is within the defined value set..."
                );

                // Check to see whether the specified Logging Infrastructure Type value is
                // within the defined value set.  If this is not the case, then write an
                // error message to the Debug output, and then terminate the execution of
                // this method.
                if (!LoggingInfrastructureTypeValidator.IsValid(type))
                {
                    // The specified Logging Infrastructure Type value is NOT within the defined value set.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        $"*** ERROR *** The specified Logging Infrastructure Type value, '{type}', is NOT within the defined value set.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** Validate.LoggingInfrastructureType: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"Validate.LoggingInfrastructureType: *** SUCCESS *** The specified Logging Infrastructure Type value, '{type}', is within the defined value set.  Proceeding..."
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
                $"Validate.LoggingInfrastructureType: Result = {result}"
            );

            return result;
        }
    }
}