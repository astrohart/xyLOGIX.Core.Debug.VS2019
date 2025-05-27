using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Threading;
using System;
using System.IO;

namespace xyLOGIX.Core.Debug
{
    /// <summary>
    /// Methods to send objects to the log by calling an extension method
    /// called 'Dump', like in LINQpad.
    /// </summary>
    /// <remarks>This class is part of the publicly-exposed API of this class library.</remarks>
    [Log(AttributeExclude = true), ExplicitlySynchronized]
    public static class DebuggerDump
    {
        /// <summary>
        /// Dumps the specified object, a reference to which is in the
        /// <paramref name="element" /> parameter, to the log.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are
        /// to be dumped.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for
        /// <paramref name="element" />, then this method does nothing.
        /// </remarks>
        public static void Dump([NotLogged] this object element)
        {
            try
            {
                if (element == null) return;

                ObjectDumper.Write(element);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the
        /// <paramref name="element" /> parameter, to the log.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are
        /// to be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth to which
        /// the object should be dumped.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for
        /// <paramref name="element" />, or if <paramref name="depth" /> is negative, then
        /// this method does nothing.
        /// </remarks>
        public static void Dump([NotLogged] this object element, int depth)
        {
            try
            {
                if (element == null) return;
                if (depth < 0) return;

                ObjectDumper.Write(element, depth);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the
        /// <paramref name="element" /> parameter, to the log.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are
        /// to be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth to which
        /// the object should be dumped.
        /// </param>
        /// <param name="log">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.IO.TextWriter" /> that is open on the target log file.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for either
        /// <paramref name="element" /> or <paramref name="log" />, or if
        /// <paramref name="depth" />  is negative, then this method does nothing.
        /// </remarks>
        public static void Dump(this object element, int depth, TextWriter log)
        {
            try
            {
                if (element == null) return;
                if (depth < 0) return;
                if (log == null) return;

                ObjectDumper.Write(element, depth, log);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the
        /// <paramref name="element" /> parameter, to the log, followed by a newline
        /// character.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are
        /// to be dumped.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for
        /// <paramref name="element" />, then this method does nothing.
        /// </remarks>
        public static void DumpLines(this object element)
        {
            try
            {
                if (element == null) return;

                ObjectDumper.WriteLine(element);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the
        /// <paramref name="element" /> parameter, to the log, followed by a newline
        /// character.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are
        /// to be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth to which
        /// the object should be dumped.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for
        /// <paramref name="element" />, or if <paramref name="depth" /> is negative, then
        /// this method does nothing.
        /// </remarks>
        public static void DumpLines(this object element, int depth)
        {
            try
            {
                try
                {
                    if (element == null) return;
                    if (depth < 0) return;

                    ObjectDumper.WriteLine(element, depth);
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the Debug output.
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Dumps the specified object, a reference to which is in the
        /// <paramref name="element" /> parameter, to the log.
        /// </summary>
        /// <param name="element">
        /// (Required.) Reference to the object whose contents are
        /// to be dumped.
        /// </param>
        /// <param name="depth">
        /// (Required.) Integer value specifying the depth to which
        /// the object should be dumped.
        /// </param>
        /// <param name="log">
        /// (Required.) Reference to an instance of
        /// <see cref="T:System.IO.TextWriter" /> that is open on the target log file.
        /// </param>
        /// <remarks>
        /// If a <see langword="null" /> reference is passed for either
        /// <paramref name="element" /> or <paramref name="log" />, or if
        /// <paramref name="depth" />  is negative, then this method does nothing.
        /// </remarks>
        public static void DumpLines(
            this object element,
            int depth,
            TextWriter log
        )
        {
            try
            {
                if (element == null) return;
                if (depth < 0) return;
                if (log == null) return;

                ObjectDumper.WriteLine(element, depth, log);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the Debug output.
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}