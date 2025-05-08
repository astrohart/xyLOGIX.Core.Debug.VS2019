using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Model;
using PostSharp.Patterns.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace xyLOGIX.Core.Debug
{
    /// <summary> Provides access to a list of output locations for debugging. </summary>
    [Log(AttributeExclude = true), Aggregatable, ExplicitlySynchronized]
    public class OutputLocationProvider : IOutputLocationProvider
    {
        /// <summary>
        /// A <see cref="T:System.Boolean" /> value indicating whether the
        /// console output location is turned on or off.
        /// </summary>
        private bool _muteConsole;

        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:xyLOGIX.Core.Debug.OutputLocationProvider" /> and returns a
        /// reference to it.
        /// </summary>
        protected OutputLocationProvider()
            => InitializeInternalOutputLocationList();

        /// <summary>
        /// Gets a value indicating whether greater than zero output location(s) are
        /// currently configured.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if greater than zero output location(s) are
        /// currently configured; <see langword="false" /> otherwise.
        /// </returns>
        public bool HasLocations
        {
            [DebuggerStepThrough]
            get
            {
                var result = false;

                try
                {
                    if (InternalOutputLocationList == null) return result;

                    result = InternalOutputLocationList.ToArray()
                        .Length > 0;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = false;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a reference to the one and only instance of the object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocationProvider" />
        /// interface.
        /// </summary>
        public static IOutputLocationProvider Instance
        {
            [DebuggerStepThrough] get;
        } = new OutputLocationProvider();

        /// <summary>
        /// Gets a reference to a collection, each element of which implements
        /// the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface.
        /// </summary>
        [Child]
        private IList<IOutputLocation> InternalOutputLocationList
        {
            [DebuggerStepThrough] get;
        } = new AdvisableCollection<IOutputLocation>();

        /// <summary>
        /// Gets the count of <c>Output Location</c>(s) that are currently defined.
        /// </summary>
        /// <remarks>
        /// If an exception is caught during the execution of the getter of this
        /// property, then the property evaluates to zero.
        /// </remarks>
        /// <returns>
        /// An <see cref="T:System.Int32" /> value that is set to the count of
        /// <c>Output Location</c>(s) that are currently defined.
        /// </returns>
        public int LocationCount
        {
            [DebuggerStepThrough]
            get
            {
                var result = 0;

                try
                {
                    if (InternalOutputLocationList == null) return result;

                    result = InternalOutputLocationList.ToArray()
                        .Length;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);

                    result = 0;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the console multiplexer is
        /// turned on or off.
        /// </summary>
        /// <remarks>
        /// This property raises the
        /// <see cref="E:xyLOGIX.Core.Debug.OutputLocationProvider.MuteConsoleChanged" />
        /// event
        /// when its value is updated.
        /// </remarks>
        public bool MuteConsole
        {
            [DebuggerStepThrough] get => _muteConsole;
            [DebuggerStepThrough]
            set
            {
                var changed = _muteConsole != value;
                _muteConsole = value;
                if (changed)
                    OnMuteConsoleChanged(
                        new MuteConsoleChangedEventArgs(value)
                    );
            }
        }

        /// <summary>
        /// Adds the specified output <paramref name="location" /> to the
        /// public list maintained by this object.
        /// </summary>
        /// <param name="location">
        /// (Required.) Reference to an instance of an object that
        /// implements the <see cref="T:xyLOGIX.Core.Debug.IOutputLocation" /> interface.
        /// </param>
        /// <remarks>
        /// If the specified <paramref name="location" /> has already been added,
        /// then this method does nothing.
        /// </remarks>
        public void AddOutputLocation([NotLogged] IOutputLocation location)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** There is a request to add an Output Location."
                );

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.AddOutputLocation: Checking whether the 'location' method parameter has a null reference for a value..."
                );

                // Check to see if the required parameter, location, is null. If it is, send an
                // error to the log file and quit, returning from this method.
                if (location == null)
                {
                    // The parameter, 'location', is required and is not supposed to have a NULL value.
                    System.Diagnostics.Debug.WriteLine(
                        "OutputLocationProvider.AddOutputLocation: *** *ERROR *** A null reference was passed for the 'location' method parameter.  Stopping."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.AddOutputLocation: *** SUCCESS *** We have been passed a valid object reference for the 'location' method parameter."
                );

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.AddOutputLocation: Checking whether the property, 'InternalOutputLocationList', has a null reference for a value..."
                );

                // Check to see if the required property, 'InternalOutputLocationList', has a null reference for a value.
                // If that is the case, then we will write an error message to the log file, and then
                // terminate the execution of this method.
                if (InternalOutputLocationList == null)
                {
                    // The property, 'InternalOutputLocationList', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "OutputLocationProvider.AddOutputLocation: *** ERROR *** The property, 'InternalOutputLocationList', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.AddOutputLocation: *** SUCCESS *** The property, 'InternalOutputLocationList', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** OutputLocationProvider.AddOutputLocation: Checking whether the Output Location specified is already a member of the internal collection..."
                );

                // Check to see whether the Output Location specified
                // is already a member of the internal collection.
                // Otherwise, write an error message to the log file,
                // and then terminate the execution of this method.
                if (InternalOutputLocationList.Contains(location))
                {
                    // The Output Location specified is already a member of the internal collection.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "*** ERROR *** The Output Location specified is already a member of the internal collection.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.AddOutputLocation: *** SUCCESS *** The Output Location specified is NOT already a member of the internal collection.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    $"*** FYI *** Adding output location of type, '{location.Type}', to the internal collection..."
                );

                InternalOutputLocationList.Add(location);

                System.Diagnostics.Debug.WriteLine(
                    $"OutputLocationProvider.AddOutputLocation: *** SUCCESS *** The output location of type, '{location.Type}', has been added."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary> Clears the public list of output locations. </summary>
        public void Clear()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to clear the internal collection..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.Clear: Checking whether the property, 'InternalOutputLocationList', has a null reference for a value..."
                );

                // Check to see if the required property, 'InternalOutputLocationList', has a null reference for a
                // value. If that is the case, then we will write an error message to the Debug
                // output, and then terminate the execution of this method.
                if (InternalOutputLocationList == null)
                {
                    // The property, 'InternalOutputLocationList', has a null reference for a value.  This is not desirable.
                    System.Diagnostics.Debug.WriteLine(
                        "OutputLocationProvider.Clear: *** ERROR *** The property, 'InternalOutputLocationList', has a null reference for a value.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.Clear: *** SUCCESS *** The property, 'InternalOutputLocationList', has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.Clear *** INFO: Checking whether the 'InternalOutputLocationList' list has greater than zero elements..."
                );

                // Check if the list, 'InternalOutputLocationList', has greater than zero elements.  If this is not
                // the case, then write an error message to the log file, and then terminate the execution
                // of this method.
                if (InternalOutputLocationList.ToArray()
                                              .Length <= 0)
                {
                    // The list, 'InternalOutputLocationList', has zero elements, but we can't proceed if this is so.
                    System.Diagnostics.Debug.WriteLine(
                        "OutputLocationProvider.Clear *** ERROR *** The list, 'InternalOutputLocationList', has zero elements.  Stopping..."
                    );

                    // stop.
                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    $"OutputLocationProvider.Clear *** SUCCESS *** {InternalOutputLocationList.ToArray().Length} element(s) were found in the 'InternalOutputLocationList' list.  Clearing it..."
                );

                InternalOutputLocationList.Clear();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }

            System.Diagnostics.Debug.WriteLine(
                !HasLocations
                    ? "*** SUCCESS *** Cleared all Output Location(s) from the internal collection.  Proceeding..."
                    : "*** ERROR *** FAILED to clear all output location(s) from the internal collection.  Stopping..."
            );
        }

        /// <summary>
        /// Occurs when the value of the
        /// <see cref="P:xyLOGIX.Core.Debug.IOutputLocationProvider.MuteConsole" />
        /// property is
        /// updated.
        /// </summary>
        public event MuteConsoleChangedEventHandler MuteConsoleChanged;

        /// <summary>
        /// Writes the text representation of the specified object to the
        /// output location.
        /// </summary>
        /// <param name="value">The value to write, or <see langword="null" />.</param>
        /// <remarks>
        /// If the internal collection has zero <c>Output Location</c>(s)
        /// configured, then this method takes no action.
        /// </remarks>
        [Log(AttributeExclude = true)]
        public void Write([NotLogged] object value)
        {
            try
            {
                /*
                 * NOTE: We should refrain from doing any logging during the
                 * execution of this method.
                 */

                if (InternalOutputLocationList == null) return;
                if (!HasLocations) return;

                foreach (var location in InternalOutputLocationList.Where(l
                             => l != null
                         ))
                {
                    if (MuteConsole &&
                        OutputLocationType.Console.Equals(location.Type))
                        continue;

                    location.Write(value);
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects to
        /// the output location using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">
        /// An array of objects to write using
        /// <paramref name="format" /> .
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or
        /// <paramref name="arg" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.FormatException">
        /// The format specification in
        /// <paramref name="format" /> is invalid.
        /// </exception>
        [Log(AttributeExclude = true)]
        public void Write([NotLogged] string format, params object[] arg)
        {
            try
            {
                /*
                 * NOTE: We should refrain from doing any logging during the
                 * execution of this method.
                 */

                if (InternalOutputLocationList == null) return;
                if (!HasLocations) return;

                if (string.IsNullOrWhiteSpace(format) &
                    ((arg == null) | (arg.Length <= 0)))
                    return;

                foreach (var location in InternalOutputLocationList.Where(l
                             => l != null
                         ))
                {
                    if (MuteConsole &&
                        OutputLocationType.Console.Equals(location.Type))
                        continue;

                    location.Write(format, arg);
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by
        /// the current line terminator, to the output location.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        [Log(AttributeExclude = true)]
        public void WriteLine([NotLogged] object value)
        {
            try
            {
                /*
                 * NOTE: We should refrain from doing any logging during the
                 * execution of this method.
                 */

                if (InternalOutputLocationList == null) return;
                if (!HasLocations) return;

                foreach (var location in InternalOutputLocationList.Where(l
                             => l != null
                         ))
                {
                    if (MuteConsole &&
                        OutputLocationType.Console.Equals(location.Type))
                        continue;

                    location.WriteLine(value);
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects,
        /// followed by the current line terminator, to the output location using
        /// the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">
        /// An array of objects to write using
        /// <paramref name="format" /> .
        /// </param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="format" /> or
        /// <paramref name="args" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="T:System.FormatException">
        /// The format specification in
        /// <paramref name="format" /> is invalid.
        /// </exception>
        [Log(AttributeExclude = true)]
        public void WriteLine([NotLogged] string format, params object[] args)
        {
            try
            {
                /*
                 * NOTE: We should refrain from doing any logging during the
                 * execution of this method.
                 */

                if (InternalOutputLocationList == null) return;
                if (!HasLocations) return;

                if (string.IsNullOrWhiteSpace(format) &
                    ((args == null) | (args.Length <= 0)))
                    return;

                foreach (var location in InternalOutputLocationList.Where(l
                             => l != null
                         ))
                {
                    if (MuteConsole &&
                        OutputLocationType.Console.Equals(location.Type))
                        continue;

                    location.WriteLine(format, args);
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>Writes the current line terminator to the output location.</summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        [Log(AttributeExclude = true)]
        public void WriteLine()
        {
            try
            {
                /*
                 * NOTE: We should refrain from doing any logging during the
                 * execution of this method.
                 */

                if (InternalOutputLocationList == null) return;
                if (!HasLocations) return;

                foreach (var location in InternalOutputLocationList.Where(l
                             => l != null
                         ))
                {
                    if (MuteConsole &&
                        OutputLocationType.Console.Equals(location.Type))
                        continue;

                    location.WriteLine();
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Initializes the
        /// <see
        ///     cref="P:xyLOGIX.Core.Debug.OutputLocationProvider.InternalOutputLocationList" />
        /// to have default values.
        /// </summary>
        [EntryPoint]
        private void InitializeInternalOutputLocationList()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Initializing the output location(s)..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to obtain a reference to the Console output location..."
                );

                var consoleOutputLocation =
                    GetOutputLocation.OfType(OutputLocationType.Console);

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.InitializeInternalOutputLocationList: Checking whether the variable 'consoleOutputLocation' has a null reference for a value..."
                );

                // Check to see if the variable, consoleOutputLocation, is null. If it is, send an error to the
                // Debug output and quit, returning from the method.
                if (consoleOutputLocation == null)
                {
                    // the variable consoleOutputLocation is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "OutputLocationProvider.InitializeInternalOutputLocationList: *** ERROR ***  The 'consoleOutputLocation' variable has a null reference.  Stopping..."
                    );

                    // stop.
                    return;
                }

                // We can use the variable, consoleOutputLocation, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.InitializeInternalOutputLocationList: *** SUCCESS *** The 'consoleOutputLocation' variable has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Adding the Console Output Location to the internal collection..."
                );

                AddOutputLocation(consoleOutputLocation);

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to obtain a reference to the Debug output location..."
                );

                var debugOutputLocation =
                    GetOutputLocation.OfType(OutputLocationType.Debug);

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.InitializeInternalOutputLocationList: Checking whether the variable 'debugOutputLocation' has a null reference for a value..."
                );

                // Check to see if the variable, debugOutputLocation, is null. If it is, send an error to the
                // Debug output and quit, returning from the method.
                if (debugOutputLocation == null)
                {
                    // the variable debugOutputLocation is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "OutputLocationProvider.InitializeInternalOutputLocationList: *** ERROR ***  The 'debugOutputLocation' variable has a null reference.  Stopping..."
                    );

                    // stop.
                    return;
                }

                // We can use the variable, debugOutputLocation, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.InitializeInternalOutputLocationList: *** SUCCESS *** The 'debugOutputLocation' variable has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Adding the Debug Output Location to the internal collection..."
                );

                AddOutputLocation(debugOutputLocation);

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Attempting to obtain a reference to the Trace output location..."
                );

                var traceOutputLocation =
                    GetOutputLocation.OfType(OutputLocationType.Trace);

                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.InitializeInternalOutputLocationList: Checking whether the variable 'traceOutputLocation' has a null reference for a value..."
                );

                // Check to see if the variable, traceOutputLocation, is null. If it is, send an error to the
                // Debug output and quit, returning from the method.
                if (traceOutputLocation == null)
                {
                    // the variable traceOutputLocation is required to have a valid object reference.
                    System.Diagnostics.Debug.WriteLine(
                        "OutputLocationProvider.InitializeInternalOutputLocationList: *** ERROR ***  The 'traceOutputLocation' variable has a null reference.  Stopping..."
                    );

                    // stop.
                    return;
                }

                // We can use the variable, traceOutputLocation, because it's not set to a null reference.
                System.Diagnostics.Debug.WriteLine(
                    "OutputLocationProvider.InitializeInternalOutputLocationList: *** SUCCESS *** The 'traceOutputLocation' variable has a valid object reference for its value.  Proceeding..."
                );

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** Adding the Trace Output Location to the internal collection..."
                );

                AddOutputLocation(traceOutputLocation);

                System.Diagnostics.Debug.WriteLine(
                    "*** FYI *** DONE adding the Output Location(s) to the internal collection."
                );
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Raises the
        /// <see cref="E:xyLOGIX.Core.Debug.OutputLocationProvider.MuteConsoleChanged" />
        /// event.
        /// </summary>
        /// <param name="e">
        /// A
        /// <see cref="T:xyLOGIX.Core.Debug.Events.MuteConsoleChangedEventArgs" /> that
        /// contains
        /// the event data.
        /// </param>
        protected virtual void OnMuteConsoleChanged(
            [NotLogged] MuteConsoleChangedEventArgs e
        )
            => MuteConsoleChanged?.Invoke(this, e);
    }
}