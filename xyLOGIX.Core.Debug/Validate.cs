using PostSharp.Patterns.Diagnostics;
using System;
using System.Diagnostics;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static methods to validate information and settings.
    /// </summary>
    internal static class Validate
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.Validate" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Validate() { }

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
        [DebuggerStepThrough]
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
                System.Diagnostics.Debug.WriteLine(ex);

                result = false;
            }

            Console.WriteLine(
                $"Validate.LoggingInfrastructureType: Result = {result}"
            );

            return result;
        }
    }
}