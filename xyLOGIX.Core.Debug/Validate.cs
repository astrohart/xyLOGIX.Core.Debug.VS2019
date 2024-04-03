using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods to validate information and settings.
    /// </summary>
    internal static class Validate
    {
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
        public static bool LoggingInfrastructureType(
            LoggingInfrastructureType type
        )
        {
            var result = false;

            try
            {
                Console.WriteLine(
                    $"LogFileManager.InitializeLogging: Validating infrastructure type '{type}'..."
                );

                if (Debug.LoggingInfrastructureType.Unknown.Equals(type))
                    return result;

                result = Enum.IsDefined(
                    typeof(LoggingInfrastructureType), type
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = false;
            }

            Console.WriteLine(
                $"Validate.LoggingInfrastructureType: Result = {result}"
            );

            return result;
        }
    }
}