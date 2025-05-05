using log4net.Appender;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides methods for configurating log4net's FileAppender </summary>
    public static class FileAppenderConfigurator
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.FileAppenderConfigurator" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static FileAppenderConfigurator() { }

        /// <summary>
        /// Sets the option to get the minimal locking option set on the
        /// specified <paramref name="appender" />.
        /// </summary>
        /// <param name="appender">
        /// Reference to an instance of an object of type
        /// <see cref="T:log4net.Appender.FileAppender" />.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed as the argument of
        /// the <paramref name="appender" /> parameter, then this method does nothing, but
        /// does return <see langword="false" />.
        /// </remarks>
        /// <returns>
        /// <see langword="true" /> if locking was configured properly for the
        /// specified file <paramref name="appender" />; <see langword="false" />
        /// otherwise.
        /// </returns>
        public static bool SetMinimalLock(FileAppender appender)
        {
            var result = false;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Attempting to set minimal lock on appender: {appender.Name}"
                );

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderConfigurator.SetMinimalLock: Checking whether the 'appender' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, appender, is null. If it is, send an 
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (appender == null)
                {
                    // The parameter, 'appender', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "FileAppenderConfigurator.SetMinimalLock: *** ERROR *** A null reference was passed for the 'appender' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** FileAppenderConfigurator.SetMinimalLock: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "FileAppenderConfigurator.SetMinimalLock: *** SUCCESS *** We have been passed a valid object reference for the 'appender' method parameter.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Configuring the appender '{appender.Name}' to use the minimal lock option..."
                );

                appender.ImmediateFlush = true;
                appender.LockingModel = new FileAppender.MinimalLock();
                appender.ActivateOptions();

                System.Diagnostics.Debug.WriteLine(
                    $"FileAppenderConfigurator.SetMinimalLock: *** SUCCESS *** The appender '{appender.Name}' has been configured to use the minimal lock option."
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
                $"FileAppenderConfigurator.SetMinimalLock: Result = {result}"
            );

            return result;
        }
    }
}