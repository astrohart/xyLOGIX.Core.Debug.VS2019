using log4net.Repository;
using PostSharp.Patterns.Diagnostics;
using System;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Exposes static method(s) that create and initialize new instances of the
    /// <see
    ///     cref="T:xyLOGIX.Core.Debug.ContextAwareBackend" />
    /// class, and return references to them.
    /// </summary>
    internal static class MakeNewLog4NetLoggingBackend
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:xyLOGIX.Core.Debug.MakeNewLog4NetLoggingBackend" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static MakeNewLog4NetLoggingBackend() { }

        /// <summary>
        /// Creates a new instance of
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ContextAwareBackend" />
        /// , initialized for the specified <paramref name="relay" />, and returns a
        /// reference to it.
        /// </summary>
        /// <param name="relay">
        /// (Required.) Reference to an instance of an object that implements the
        /// <see cref="T:log4net.Repository.ILoggerRepository" /> interface that specifies
        /// the relay to be used for sending logging to another destination, or in which
        /// loggers are to be stored.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed as the argument of
        /// the <paramref name="relay" /> parameter, then this method returns a
        /// <see langword="null" /> reference. i
        /// </remarks>
        /// <returns>
        /// If successful, a reference to a newly-created instance of
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ContextAwareBackend" />
        /// initialized with the specified <paramref name="relay" />; otherwise, a
        /// <see langword="null" /> reference is returned.
        /// </returns>
        internal static ContextAwareBackend ForRelay(
            [NotLogged] ILoggerRepository relay
        )
        {
            ContextAwareBackend result = default;

            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLog4NetLoggingBackend.ForRelay: Checking whether the 'relay' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, relay, is null. If it is, send an 
                // error to the Debug output and quit, returning the default return value of
                // this method.
                if (relay == null)
                {
                    // The parameter, 'relay', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "MakeNewLog4NetLoggingBackend.ForRelay: *** ERROR *** A null reference was passed for the 'relay' method parameter.  Stopping..."
                    );

                    System.Diagnostics.Debug.WriteLine(
                        $"*** MakeNewLog4NetLoggingBackend.ForRelay: Result = {result}"
                    );

                    // stop.
                    return result;
                }

                System.Diagnostics.Debug.WriteLine(
                    "MakeNewLog4NetLoggingBackend.ForRelay: *** SUCCESS *** We have been passed a valid object reference for the 'relay' method parameter.  Proceeding..."
                );

                result = new ContextAwareBackend(relay);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            System.Diagnostics.Debug.WriteLine(
                result != null
                    ? "*** SUCCESS *** Obtained a reference to the log4net backend with the specified relay.  Proceeding..."
                    : "*** ERROR *** FAILED to obtain a reference to the log4net backend with the specified relay.  Stopping..."
            );

            return result;
        }

        /// <summary>
        /// Creates a new instance of
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ContextAwareBackend" />
        /// and returns a reference to it.
        /// </summary>
        /// <returns>
        /// Reference to a newly-created instance of
        /// <see
        ///     cref="T:xyLOGIX.Core.Debug.ContextAwareBackend" />
        /// .
        /// </returns>
        internal static ContextAwareBackend FromScratch()
        {
            ContextAwareBackend result = default;

            try
            {
                result = new ContextAwareBackend();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);

                result = default;
            }

            return result;
        }
    }
}