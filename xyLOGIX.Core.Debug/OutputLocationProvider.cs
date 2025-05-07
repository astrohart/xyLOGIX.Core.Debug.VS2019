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
                if (location == null) return;
                if (InternalOutputLocationList == null) return;
                if (InternalOutputLocationList.Contains(location)) return;

                System.Diagnostics.Debug.WriteLine(
                    $"OutputLocationProvider.AddOutputLocation: Adding output location of type, '{location.Type}'..."
                );

                InternalOutputLocationList.Add(location);

                System.Diagnostics.Debug.WriteLine(
                    $"OutputLocationProvider.AddOutputLocation: The output location of type, '{location.Type}', has been added."
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
                if (InternalOutputLocationList == null) return;
                if (!InternalOutputLocationList.Any()) return;

                InternalOutputLocationList.Clear();
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                System.Diagnostics.Debug.WriteLine(ex);
            }
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
        /// <exception cref="T:System.IO.IOException">An I/O error occurred.</exception>
        [Log(AttributeExclude = true)]
        public void Write([NotLogged] object value)
        {
            try
            {
                if (InternalOutputLocationList == null) return;
                if (!InternalOutputLocationList.Any()) return;

                foreach (var location in InternalOutputLocationList.Where(
                             l => l != null
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
                if (InternalOutputLocationList == null) return;
                if (!InternalOutputLocationList.Any()) return;

                if (string.IsNullOrWhiteSpace(format) &
                    ((arg == null) | (arg.Length <= 0)))
                    return;

                foreach (var location in InternalOutputLocationList.Where(
                             l => l != null
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
                if (InternalOutputLocationList == null) return;
                if (!InternalOutputLocationList.Any()) return;

                foreach (var location in InternalOutputLocationList.Where(
                             l => l != null
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
                if (InternalOutputLocationList == null) return;
                if (!InternalOutputLocationList.Any()) return;

                if (string.IsNullOrWhiteSpace(format) &
                    ((args == null) | (args.Length <= 0)))
                    return;

                foreach (var location in InternalOutputLocationList.Where(
                             l => l != null
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
                if (InternalOutputLocationList == null) return;
                if (!InternalOutputLocationList.Any()) return;

                foreach (var location in InternalOutputLocationList.Where(
                             l => l != null
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
                if (InternalOutputLocationList == null) return;

                AddOutputLocation(
                    GetOutputLocation.OfType(OutputLocationType.Console)
                );
                AddOutputLocation(
                    GetOutputLocation.OfType(OutputLocationType.Debug)
                );
                AddOutputLocation(
                    GetOutputLocation.OfType(OutputLocationType.Trace)
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